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
import numpy as np

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
    import matplotlib.pyplot as plt
    import random

    random.seed(0)

    plt.figure(figsize=(12, 12))
    plt.scatter(x_vals, y_vals)

    #
    # Label randomly subsampled 1000 data points
    #
    indices = list(range(len(labels)))
    selected_indices = random.sample(indices, (lambda x: 1000 if (x > 1000) else x)(len(indices)))
    for i in selected_indices:
        plt.annotate(labels[i], (x_vals[i], y_vals[i]), fontsize=4)

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
            for sent in nltk.tokenize.sent_tokenize(abstract):
                sents.append(sent)

        # 斷詞
        words = []
        for sent in sents:
            temWords = nltk.tokenize.word_tokenize(sent)
            # 去除標點符號、停用字及數字
            words.append([word for word in temWords if (not word in nltk_stopwords and not word.isdigit() and not re.fullmatch('[' + string.punctuation + ']+', word))])

        model = word2vec.Word2Vec(words, vector_size = 1000, window = 10, min_count = 5, workers = 8, sg = int(use_sg))
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
            res = model.most_similar(pattern, topn = 30)
            return json.dumps([{'res': res}])
        except:
            return json.dumps([{'res': None}])
    else:
        return 'Error: Not all parameters provided. Please include model_file_path.'

app.run()
