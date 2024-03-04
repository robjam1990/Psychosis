// File = robjam1990/Psychosis/Models/Dependencies.js
// Initialize dependencies
const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const PORT = 5000;

// Serve MLflow model
app.post('/invocations', bodyParser.json(), (req, res) => {
    // Handle different types of input data formats

    // Serialized pandas DataFrame format
    if (req.body.dataframe_records) {
        const data = req.body.dataframe_records;
        // Process data
        console.log(data);
        res.send(data); // Sending back processed data as response (dummy response)
    }
    // Split serialized pandas DataFrame format
    else if (req.body.dataframe_split) {
        const { columns, index, data } = req.body.dataframe_split;
        // Process data
        console.log(columns, index, data);
        res.send(data); // Sending back processed data as response (dummy response)
    }
    // List format for processing
    else if (req.body.inputs) {
        const inputs = req.body.inputs;
        // Process data
        console.log(inputs);
        res.send(inputs); // Sending back processed data as response (dummy response)
    }
    // Tensor data instances for processing
    else if (req.body.instances) {
        const instances = req.body.instances;
        // Process data
        console.log(instances);
        res.send(instances); // Sending back processed data as response (dummy response)
    } else {
        res.status(400).send('Invalid request');
    }
});

// Start server
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
