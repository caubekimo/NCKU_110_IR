from nltk.tokenize import sent_tokenize, word_tokenize
import textstat
import jieba

import json
import flask
from flask import jsonify, request

app = flask.Flask(__name__)

@app.route('/TextStat', methods=['GET'])
def TextStat():
    if 'content' in request.args:
        content = request.args['content']

        charCount = textstat.char_count(content, ignore_spaces=True) #利用 textstat 計算字元數
        wordCount = len(jieba.lcut(content)) #利用 jieba 計算字數
        sentenceCount = len(sent_tokenize(content)) #利用 Nltk 計算句數

        stat = [{'char': charCount,'word': wordCount,'sentence': sentenceCount}]
        return json.dumps(stat) #回傳 JSON 格式的結果

    else:
        return 'Error: No content provided. Please specify a content.'


app.run()