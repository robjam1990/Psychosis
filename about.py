from flask import Flask, request

app = Flask(__name__)

@app.before_request
def before_request():
    # Middleware logic here
    pass

@app.route('/about', methods=['GET', 'POST', 'PUT'])
def about():
    if request.method == 'GET':
        return 'About page'
    elif request.method == 'POST':
        # Logic for handling POST requests to the about page
        return 'About page (POST)'
    elif request.method == 'PUT':
        # Logic for handling PUT requests to the about page
        return 'About page (PUT)'

if __name__ == '__main__':
    app.run()
