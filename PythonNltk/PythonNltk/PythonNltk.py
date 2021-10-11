from nltk.tokenize import sent_tokenize, word_tokenize
import textstat
import jieba

import json
import flask
from flask import jsonify, request

app = flask.Flask(__name__)

#@app.route('/Nltk', methods=['GET'])
#def Nltk():
#    if 'content' in request.args:
#        content = request.args['content']

#        blog = {'char': 'datacamp.com', 'name': 'Datacamp'}

#        return 'There are ' + str(len(sent_tokenize(content))) + ' sentences
#        in your content.'
#    else:
#        return 'Error: No content provided.  Please specify a content.'

@app.route('/TextStat', methods=['GET'])
def TextStat():
    if 'content' in request.args:
        content = request.args['content']
        charCount = textstat.char_count(content, ignore_spaces=True)
        wordCount = len(jieba.lcut(content))
        sentenceCount = len(sent_tokenize(content))

        stat = [{'char': charCount,'word': wordCount,'sentence': sentenceCount}]
        return json.dumps(stat)

    else:
        return 'Error: No content provided. Please specify a content.'



app.run()