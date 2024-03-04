# File: robjam1990/Psychosis/Models/Dependencies.py
from flask import Flask, request, jsonify

app = Flask(__name__)
PORT = 5000

# Serve MLflow model
@app.route('/invocations', methods=['POST'])
def invocations():
    req_data = request.get_json()

    # Handle different types of input data formats

    # Serialized pandas DataFrame format
    if 'dataframe_records' in req_data:
        data = req_data['dataframe_records']
        # Process data
        print(data)
        return jsonify(data)  # Sending back processed data as response (dummy response)

    # Split serialized pandas DataFrame format
    elif 'dataframe_split' in req_data:
        columns = req_data['dataframe_split']['columns']
        index = req_data['dataframe_split']['index']
        data = req_data['dataframe_split']['data']
        # Process data
        print(columns, index, data)
        return jsonify(data)  # Sending back processed data as response (dummy response)

    # List format for processing
    elif 'inputs' in req_data:
        inputs = req_data['inputs']
        # Process data
        print(inputs)
        return jsonify(inputs)  # Sending back processed data as response (dummy response)

    # Tensor data instances for processing
    elif 'instances' in req_data:
        instances = req_data['instances']
        # Process data
        print(instances)
        return jsonify(instances)  # Sending back processed data as response (dummy response)

    else:
        return 'Invalid request', 400

# Start server
if __name__ == '__main__':
    app.run(port=PORT)
