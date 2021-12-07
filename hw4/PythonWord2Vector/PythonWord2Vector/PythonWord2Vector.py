import os
import glob
import pandas as pd
import numpy as np
import operator
import re
import string
import json
import flask
from flask import jsonify, request
import nltk
from nltk.stem import PorterStemmer
from gensim.models import word2vec
from gensim.models import KeyedVectors
import matplotlib.pyplot as plt
from sklearn.manifold import TSNE
from sklearn.feature_extraction.text import TfidfVectorizer
import random

#nltk.download('stopwords') # run once only
nltk_stopwords = nltk.corpus.stopwords.words('english') # load stop words from NTLK
app = flask.Flask(__name__)

def reduce_dimensions(model):
    num_dimensions = 2  # final num dimensions (2D, 3D, etc)

    # extract the words & their vectors, as numpy arrays
    vectors = np.asarray(model.wv.vectors)
    labels = np.asarray(model.wv.index_to_key)

    # reduce using t-SNE
    tsne = TSNE(n_components=num_dimensions, random_state=0)
    vectors = tsne.fit_transform(vectors)

    x_vals = [v[0] for v in vectors]
    y_vals = [v[1] for v in vectors]
    return x_vals, y_vals, labels

def plot_with_matplotlib(x_vals, y_vals, labels, save_to_fig):
    random.seed(0)

    plt.figure(figsize=(16, 16))
    plt.scatter(x_vals, y_vals, s=4)

    #
    # Label randomly subsampled 1000 data points
    #
    indices = list(range(len(labels)))
    selected_indices = random.sample(indices, (lambda x: 2500 if (x > 2500) else x)(len(indices)))
    for i in selected_indices:
        plt.annotate(labels[i], (x_vals[i], y_vals[i]), fontsize=2)

    plt.savefig(fname=save_to_fig, format='svg')

@app.route('/Word2Vector', methods=['GET'])
def Word2Vector():
    if 'file_path' in request.args and 'use_sg' in request.args and 'save_to_model' in request.args and 'save_to_fig' in request.args:
        file_path = request.args['file_path']
        use_sg = request.args['use_sg']
        save_to_model = request.args['save_to_model']
        save_to_fig = request.args['save_to_fig']

        '''讀取檔案的內容'''
        allContent = pd.read_excel(file_path)

        abstracts = allContent['Abstract'].dropna().values.tolist()

        '''處理 abstract'''
        # 斷句
        sents = []
        for abstract in abstracts:
            for sent in nltk.tokenize.sent_tokenize(abstract.lower()):
                sents.append(sent)

        # 斷詞
        words = []
        for sent in sents:
            temWords = nltk.tokenize.word_tokenize(sent)

            # 去除標點符號、停用字
            words.append([word for word in temWords if (not word in nltk_stopwords and (re.match(r'^-?\d+(?:\.\d+)$', word) is None) and not re.fullmatch('[' + string.punctuation + ']+', word))])

        model = word2vec.Word2Vec(words, vector_size = 80, window = 30, min_count = 5, workers = 8, sg = int(use_sg))
        # Save model
        model.wv.save_word2vec_format(save_to_model, binary = True)
        print("model 已儲存完畢")
        
        vocabs = list(model.wv.index_to_key)

        # 視覺化
        x_vals, y_vals, labels = reduce_dimensions(model)
        plot_with_matplotlib(x_vals, y_vals, labels, save_to_fig)

        return 'Training is done, please check model file:' + save_to_model
    else:
        return 'Error: Not all parameters provided. Please include file_path, use_sg, save_to_model and save_to_fig.'

@app.route('/SimilarWord', methods=['GET'])
def SimilarWord():
    if 'model_file_path' in request.args and 'pattern' in request.args:
        model_file_path = request.args['model_file_path']
        pattern = request.args['pattern']

        model = KeyedVectors.load_word2vec_format(model_file_path, binary=True) 
        try:
            res = model.most_similar(pattern, topn = 50)
            return json.dumps([{'res': res}])
        except:
            return json.dumps([{'res': None}])
    else:
        return 'Error: Not all parameters provided. Please include model_file_path.'

@app.route('/GetEvidence', methods=['GET'])
def GetEvidence():
    if 'corpus_file_path' in request.args and 'model_file_path' in request.args and 'pattern' in request.args and 'usesublinear' in request.args:
        corpus_file_path = request.args['corpus_file_path']
        model_file_path = request.args['model_file_path']
        pattern = request.args['pattern']
        usesublinear = request.args['usesublinear']

        '''讀取檔案的內容'''
        allContent = pd.read_excel(corpus_file_path)

        #abstracts = allContent['Abstract'].dropna().values.tolist()
        abstracts = allContent['Abstract'].dropna().values.tolist()[:100]

        '''處理 abstract'''
        # 斷句
        sents = []
        for abstract in abstracts:
            for sent in nltk.tokenize.sent_tokenize(abstract.lower()):
                sents.append(sent)

        # 斷詞
        wordArrs = []
        for sent in sents:
            temWords = nltk.tokenize.word_tokenize(sent)

            # 去除標點符號、停用字
            wordArrs.append([word for word in temWords if (not word in nltk_stopwords and (re.match(r'^-?\d+(?:\.\d+)$', word) is None) and not re.fullmatch('[' + string.punctuation + ']+', word))])

        model = KeyedVectors.load_word2vec_format(model_file_path, binary=True) 
        try:
            similarRes = model.most_similar(pattern, topn = 50)
        except:
            return json.dumps([{'res': None}])

        sents = [' '.join(wordArr) for wordArr in wordArrs]

        #vectorizer= CountVectorizer()    
        #transformer = TfidfTransformer(sublinear_tf=False)
        #tfidf = transformer.fit_transform(vectorizer.fit_transform(sents))

        vectorizer= TfidfVectorizer(sublinear_tf = (usesublinear == 1), stop_words=None)
        tfidf = vectorizer.fit_transform(sents)

        # 所有文件中的所有字的列表 (不取重複字)
        wordFeatures = vectorizer.get_feature_names()
        
        # 每個字所對應的 tfidf 陣列
        weight = tfidf.toarray()

        # 將 Tfidf 中的每個字，與相似字中的字做比對，找出相似字的 idf 權重是多少
        stemmer = PorterStemmer()
        stemSimilarWords = [stemmer.stem(arr[0]) for arr in similarRes]
        wordWeight = []

        forLen = len(wordFeatures)

        for i in range(0, forLen):
            wordFeature = wordFeatures[i]
            if stemmer.stem(wordFeature) in stemSimilarWords:
                maxTfidf = np.max(weight[:i])
                maxSent = sents[np.where(weight[:i] == np.max(weight[:i]))[0][0]]
                print(i, maxTfidf, maxSent, weight[:i], np.where(weight[:i] == np.max(weight[:i]))[0][0])
                wordWeight.append((wordFeature, [res[1] for res in similarRes if stemmer.stem(res[0]) == stemmer.stem(wordFeatures[i])][0], maxTfidf, maxSent))
            else:
                wordWeight = wordWeight
        return json.dumps([{'wordWeight': wordWeight}])
        # 3069 字、756 句子
        """debug"""

        #try:
        #    res = model.most_similar(pattern, topn = 30)
        #    return json.dumps([{'res': res}])
        #except:
        #    return json.dumps([{'res': None}])
    else:
        return 'Error: Not all parameters provided. Please include model_file_path.'

app.run()
