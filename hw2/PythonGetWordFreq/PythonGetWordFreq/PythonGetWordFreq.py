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

#nltk.download('stopwords') # run once only
nltk_stopwords = nltk.corpus.stopwords.words('english') # load stop words from NTLK
app = flask.Flask(__name__)

@app.route('/GetWordFreq', methods=['GET'])
def TextStat():
    if 'folder_path' in request.args and 'remove_stop_words' in request.args:
        folder_path = request.args['folder_path']
        remove_stop_words = request.args['remove_stop_words'] == '1'
        apply_porter_stemming = request.args['apply_porter_stemming'] == '1'

        '''讀取資料夾裡全部 .csv 檔案的內容'''
        dfArr = []

        for filename in glob.glob(os.path.join(folder_path, '*.csv')):
           tempDF = pd.read_csv(filename)
           dfArr.append(tempDF)

        allContent = pd.concat(dfArr, ignore_index=True)

        titles = pd.Series(allContent['title'].values.tolist()).str.cat(sep=', ')
        abstracts = pd.Series(allContent['abstract'].values.tolist()).str.cat(sep=', ')

        '''處理 title'''
        titleWords = nltk.tokenize.word_tokenize(titles.lower()) # 切詞
        titleWords = [word for word in titleWords if not re.fullmatch('[' + string.punctuation + ']+', word)] # 去除標點符號
        titleWords = ['covid-19' if word.lower().find('covid') > -1 else word for word in titleWords] # 處理 covid 與 covid-19

        # 移除停用字
        if remove_stop_words:
            titleWords = [word for word in titleWords if not word in nltk_stopwords]
        
        # 套用 Porter 演算法
        if apply_porter_stemming:
            stemmer = PorterStemmer()
            for word in titleWords:
                word = stemmer.stem(word)

        titleFdist = nltk.FreqDist(titleWords) # 統計字頻
        titleFdist = dict((word, freq) for word, freq in titleFdist.items() if not word.isdigit()) # 去掉數字
        titleFdist = dict(sorted(titleFdist.items(), key=operator.itemgetter(1), reverse=True)) # 反向排序

        print(titleFdist)

        '''處理 abstract'''
        absWords = nltk.tokenize.word_tokenize(abstracts.lower()) # 切詞
        absWords = [word for word in absWords if not re.fullmatch('[' + string.punctuation + ']+', word)] # 去除標點符號
        absWords = ['covid-19' if word.lower().find('covid') > -1 else word for word in absWords] # 處理 covid 與 covid-19

        # 移除停用字
        if remove_stop_words:
            absWords = [word for word in absWords if not word in nltk_stopwords]

        # 套用 Porter 演算法
        if apply_porter_stemming:
            stemmer = PorterStemmer()
            for word in absWords:
                word = stemmer.stem(word)

        absFdist = nltk.FreqDist(absWords) # 統計字頻
        absFdist = dict((word, freq) for word, freq in absFdist.items() if not word.isdigit()) # 去掉數字
        absFdist = dict(sorted(absFdist.items(), key=operator.itemgetter(1), reverse=True)) # 反向排序

        print(absFdist)

        return json.dumps([{'titleFdist': titleFdist, 'absFdist': absFdist}])
        
    else:
        return 'Error: No folder path provided. Please specify it.'

app.run()
