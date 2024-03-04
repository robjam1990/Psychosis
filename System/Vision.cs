using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FaceRecognitionDotNet;
using CommandLine;

namespace Psychosis.Gameplay.System
{
    class Vision
    {
        // Scan known people for facial recognition
        static (List<string> names, List<FaceEncoding> faceEncodings) ScanKnownPeople(string knownPeopleFolder)
        {
            try
            {
                var names = new List<string>();
                var faceEncodings = new List<FaceEncoding>();

                // Function to retrieve image files in folder
                string[] ImageFilesInFolder(string folder)
                {
                    return Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)
                                    .Where(file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                   file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                   file.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                    .ToArray();
                }

                // Scan known people folder
                foreach (var file in ImageFilesInFolder(knownPeopleFolder))
                {
                    var basename = Path.GetFileNameWithoutExtension(file);
                    using (var img = FaceRecognition.LoadImageFile(file))
                    {
                        var encodings = FaceRecognition.FaceEncodings(img).ToArray();

                        if (encodings.Length > 1)
                        {
                            Console.WriteLine($"WARNING: More than one face found in {file}. Only considering the first face.");
                        }

                        if (encodings.Length == 0)
                        {
                            Console.WriteLine($"WARNING: No faces found in {file}. Ignoring file.");
                        }
                        else
                        {
                            names.Add(basename);
                            faceEncodings.Add(encodings[0]);
                        }
                    }
                }

                return (names, faceEncodings);
            }
            catch (Exception error)
            {
                throw new Exception($"Error scanning known people: {error.Message}");
            }
        }

        // Test image for facial recognition
        static void TestImage(string imageToCheck, List<string> knownNames, List<FaceEncoding> knownFaceEncodings, float tolerance = 0.6f, bool showDistance = false)
        {
            // Implementation remains the same
        }

        // Main function
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed(options =>
                  {
                      try
                      {
                          if (string.IsNullOrEmpty(options.KnownPeopleFolder) || string.IsNullOrEmpty(options.ImageToCheck))
                          {
                              throw new Exception("Please provide paths for known people folder and image to check.");
                          }

                          if (!Directory.Exists(options.KnownPeopleFolder))
                          {
                              throw new Exception($"Known people folder '{options.KnownPeopleFolder}' does not exist.");
                          }

                          if (!File.Exists(options.ImageToCheck))
                          {
                              throw new Exception($"Image to check '{options.ImageToCheck}' does not exist.");
                          }

                          // Ensure cpus is a valid number
                          if (!int.TryParse(options.Cpus, out int cpus) || cpus < 1)
                          {
                              Console.WriteLine("Invalid value for --cpus option. Defaulting to 1.");
                              cpus = 1;
                          }

                          // Ensure tolerance is a valid number between 0 and 1
                          if (!float.TryParse(options.Tolerance, out float tolerance) || tolerance < 0 || tolerance > 1)
                          {
                              Console.WriteLine("Invalid value for --tolerance option. Defaulting to 0.6.");
                              tolerance = 0.6f;
                          }

                          var known = ScanKnownPeople(options.KnownPeopleFolder);

                          // Multi-core processing only supported on .NET Framework 4.5 or greater
                          if (Environment.Version < new Version(4, 5) && cpus != 1)
                          {
                              Console.WriteLine("WARNING: Multi-processing support requires .NET Framework 4.5 or greater. Falling back to single-threaded processing!");
                              cpus = 1;
                          }

                          if (File.Exists(options.ImageToCheck))
                          {
                              if (cpus == 1)
                              {
                                  foreach (var imageFile in Directory.GetFiles(options.ImageToCheck, "*.*", SearchOption.AllDirectories))
                                  {
                                      TestImage(imageFile, known.names, known.faceEncodings, tolerance, options.ShowDistance);
                                  }
                              }
                              else
                              {
                                  ProcessImagesInProcessPool(Directory.GetFiles(options.ImageToCheck, "*.*", SearchOption.AllDirectories), known.names, known.faceEncodings, cpus, tolerance, options.ShowDistance);
                              }
                          }
                          else
                          {
                              TestImage(options.ImageToCheck, known.names, known.faceEncodings, tolerance, options.ShowDistance);
                          }
                      }
                      catch (Exception error)
                      {
                          Console.WriteLine($"Error in main function: {error.Message}");
                          Environment.Exit(1);
                      }
                  });
        }

        // Define command line options
        class Options
        {
            [Value(0, MetaName = "known_people_folder", Required = true, HelpText = "Folder containing images of known people for facial recognition.")]
            public string KnownPeopleFolder { get; set; }

            [Value(1, MetaName = "image_to_check", Required = true, HelpText = "Image file to check for facial recognition.")]
            public string ImageToCheck { get; set; }

            [Option('c', "cpus", Default = "1", HelpText = "Number of CPU cores to use in parallel (can speed up processing lots of images). -1 means 'use all in system'")]
            public string Cpus { get; set; }

            [Option('t', "tolerance", Default = "0.6", HelpText = "Tolerance for face comparisons. Default is 0.6. Lower this if you get multiple matches for the same person.")]
            public string Tolerance { get; set; }

            [Option('s', "show-distance", Default = false, HelpText = "Output face distance. Useful for tweaking tolerance setting.")]
            public bool ShowDistance { get; set; }
        }
    }
}
