import difflib
import json
import flask
from flask import jsonify, request

app = flask.Flask(__name__)

@app.route('/CompareAbstract', methods=['GET'])
def TextStat():
    if 'content1' in request.args and 'content2' in request.args:
        content1 = request.args['content1']
        content2 = request.args['content2']

        seq = difflib.SequenceMatcher(None, content1, content2)
        ratio = seq.ratio()
        longestMatch = seq.find_longest_match(0, len(content1), 0, len(content2))
        stat = [{'ratio': ratio, 'longestMatch': longestMatch}]
        return json.dumps(stat) #回傳 JSON 格式的結果

    else:
        return 'Error: No content provided. Please specify 2 contents.'

app.run()