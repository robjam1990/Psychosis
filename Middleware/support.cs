// File = robjam1990/Psychosis/Middleware/support.cs
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using Microsoft.CSharp;

namespace DebugParseCompile
{
    /// <summary>
    /// Utility for debugging, parsing, and compiling C# code strings.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        public static void Main()
        {
            string sourceCode = @"
                using System;
                namespace HelloThear
                {
                    public static class Program
                    {
                        public static void Main()
                        {
                            Console.WriteLine(""Hello, Thear!"");
                        }
                    }
                }
            ";

            DebugParseCompile(sourceCode);
        }

        /// <summary>
        /// Debug, parse, and compile the provided C# source code.
        /// </summary>
        /// <param name="sourceCode">The C# source code to compile.</param>
        public static void DebugParseCompile(string sourceCode)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(sourceCode))
                {
                    throw new ArgumentException("Source code cannot be null or empty.");
                }

                // Debugging
                Debugger.Break();

                // Parsing
                ParseExampleData();

                // Compiling
                CompilerParameters parameters = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true
                };

                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerResults results = provider.CompileAssemblyFromSource(parameters, sourceCode);

                // Error handling
                if (results.Errors.Count > 0)
                {
                    LogCompilationErrors(results.Errors);
                }
                else
                {
                    Console.WriteLine("Compilation successful.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ArgumentException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Parse example data for demonstration purposes.
        /// </summary>
        private static void ParseExampleData()
        {
            string strValue = "123";
            int parsedValue;

            if (int.TryParse(strValue, out parsedValue))
            {
                // Parsing successful, use 'parsedValue'
            }
            else
            {
                // Parsing failed
            }

            string strEnum = "Monday";
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), strEnum, true);
        }

        /// <summary>
        /// Log compilation errors to a file.
        /// </summary>
        /// <param name="errors">The collection of compilation errors.</param>
        private static void LogCompilationErrors(CompilerErrorCollection errors)
        {
            string logFilePath = "CompilationErrors.log";
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                writer.WriteLine($"Compilation errors at {DateTime.Now}:");
                foreach (CompilerError error in errors)
                {
                    writer.WriteLine($"Error ({error.ErrorNumber}): {error.ErrorText}");
                }
            }

            Console.WriteLine($"Compilation failed. Check '{logFilePath}' for details.");
        }
    }
}
