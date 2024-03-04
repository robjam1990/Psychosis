// File = robjam1990/Psychosis/Gameplay/Characters/NPC_NN.cs
// "This is the basic neural network for Animals and NPC's."

using System.Collections.Generic;

public class NPC_NN
{
    public Dictionary<string, object> OLog = new Dictionary<string, object>
    {
        { "Y", new List<string> { "top" } },
        {
            "modelTopology", new Dictionary<string, object>
            {
                { "class_name", "Neurological" },
                {
                    "config", new Dictionary<string, object>
                    {
                        { "name", "sequential" },
                        {
                            "layers", new List<Dictionary<string, object>>
                            {
                                new Dictionary<string, object>
                                {
                                    { "class_name", "Dense" },
                                    {
                                        "config", new Dictionary<string, object>
                                        {
                                            { "units", 1 },
                                            { "activation", "sigmoid" },
                                            { "use_bias", true },
                                            {
                                                "kernel_initializer", new Dictionary<string, object>
                                                {
                                                    { "class_name", "VarianceScaling" },
                                                    {
                                                        "config", new Dictionary<string, object>
                                                        {
                                                            { "scale", 1 },
                                                            { "mode", "fan_avg" },
                                                            { "distribution", "normal" },
                                                            { "seed", null }
                                                        }
                                                    }
                                                }
                                            },
                                            {
                                                "bias_initializer", new Dictionary<string, object>
                                                {
                                                    { "class_name", "Zeros" },
                                                    { "config", new Dictionary<string, object>() }
                                                }
                                            },
                                            { "kernel_regularizer", null },
                                            { "bias_regularizer", null },
                                            { "activity_regularizer", null },
                                            { "kernel_constraint", null },
                                            { "bias_constraint", null },
                                            { "name", "dense_Dense35" },
                                            { "trainable", true },
                                            { "batch_input_shape", new List<object> { null, 10 } },
                                            { "dtype", "float32" }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                { "keras_version", "tfjs-layers 4.17.0" },
                { "backend", "matrix.js" }
            }
        },
        { "format", "layers-model" },
        { "generatedBy", "self" },
        { "convertedBy", null },
        {
            "weightsManifest", new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    {
                        "paths", new List<string>
                        {
                            "./mymodel.weights.bin"
                        }
                    },
                    {
                        "weights", new List<Dictionary<string, object>>
                        {
                            new Dictionary<string, object>
                            {
                                { "name", "dense_Dense35/kernel" },
                                { "shape", new List<int> { 10, 1 } },
                                { "dtype", "float32" }
                            },
                            new Dictionary<string, object>
                            {
                                { "name", "dense_Dense35/bias" },
                                { "shape", new List<int> { 1 } },
                                { "dtype", "float32" }
                            }
                        }
                    }
                }
            }
        }
    };
}
