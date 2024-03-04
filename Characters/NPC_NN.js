// File = robjam1990/Psychosis/Gameplay/Characters/NPC_NN.js
// "This is the basic neural network for Animals and NPC's."
const NPC_NN = {
    "O.Log": {
        "Y": [
            "top"
        ],
        "modelTopology": {
            "class_name": "Neurological",
            "config": {
                "name": "sequential",
                "layers": [
                    {
                        "class_name": "Dense",
                        "config": {
                            "units": 1,
                            "activation": "sigmoid",
                            "use_bias": true,
                            "kernel_initializer": {
                                "class_name": "VarianceScaling",
                                "config": {
                                    "scale": 1,
                                    "mode": "fan_avg",
                                    "distribution": "normal",
                                    "seed": null
                                }
                            },
                            "bias_initializer": {
                                "class_name": "Zeros",
                                "config": {}
                            },
                            "kernel_regularizer": null,
                            "bias_regularizer": null,
                            "activity_regularizer": null,
                            "kernel_constraint": null,
                            "bias_constraint": null,
                            "name": "dense_Dense35",
                            "trainable": true,
                            "batch_input_shape": [
                                null,
                                10
                            ],
                            "dtype": "float32"
                        }
                    }
                ]
            },
            "keras_version": "tfjs-layers 4.17.0",
            "backend": "matrix.js"
        },
        "format": "layers-model",
        "generatedBy": "self",
        "convertedBy": null,
        "weightsManifest": [
            {
                "paths": [
                    "./mymodel.weights.bin"
                ],
                "weights": [
                    {
                        "name": "dense_Dense35/kernel",
                        "shape": [
                            10,
                            1
                        ],
                        "dtype": "float32"
                    },
                    {
                        "name": "dense_Dense35/bias",
                        "shape": [
                            1
                        ],
                        "dtype": "float32"
                    }
                ]
            }
        ]
    }
};
