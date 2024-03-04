# File = robjam1990/Psychosis/Gameplay/Characters/NPC_NN.py
# "This is the basic neural network for Animals and NPC's."

NPC_NN = {
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
                            "use_bias": True,
                            "kernel_initializer": {
                                "class_name": "VarianceScaling",
                                "config": {
                                    "scale": 1,
                                    "mode": "fan_avg",
                                    "distribution": "normal",
                                    "seed": None
                                }
                            },
                            "bias_initializer": {
                                "class_name": "Zeros",
                                "config": {}
                            },
                            "kernel_regularizer": None,
                            "bias_regularizer": None,
                            "activity_regularizer": None,
                            "kernel_constraint": None,
                            "bias_constraint": None,
                            "name": "dense_Dense35",
                            "trainable": True,
                            "batch_input_shape": [
                                None,
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
        "convertedBy": None,
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
}
