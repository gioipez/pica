# app.py - a minimal flask api using flask_restful
from flask import Flask
from flask_restful import Resource, Api
import socket
from flask import request
import random
import time

app = Flask(__name__)
api = Api(app)

class MainPage(Resource):
    def get(self):
    	id_producto = request.args['id']
    	number  = random.randrange(1000, 9999)
    	time.sleep(2)
        return { 'product': id_producto, "stock": number}

api.add_resource(MainPage, '/stock-service')

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')