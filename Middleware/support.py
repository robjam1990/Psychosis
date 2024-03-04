# File: robjam1990/Psychosis/Middleware/support.py
import sys
import clr
import os
import datetime

# Add reference to necessary assemblies
sys.path.append(os.path.dirname(os.path.realpath(__file__)))
clr.AddReference("System")
clr.AddReference("Microsoft.CSharp")

from System import ArgumentException
from System.Diagnostics import Debugger
from System.IO import File, StreamWriter
from System.CodeDom.Compiler import CompilerParameters, CompilerResults
from Microsoft.CSharp import CSharpCodeProvider

def main():
    source_code = """
        using System;
        namespace HelloThear
        {
            public static class Program
            {
                public static void Main()
                {
                    Console.WriteLine("Hello, Thear!");
                }
            }
        }
    """

    debug_parse_compile(source_code)

def debug_parse_compile(source_code):
    try:
        # Input validation
        if source_code is None or source_code.strip() == "":
            raise ArgumentException("Source code cannot be null or empty.")

        # Debugging
        Debugger.Break()

        # Parsing
        parse_example_data()

        # Compiling
        parameters = CompilerParameters()
        parameters.GenerateExecutable = False
        parameters.GenerateInMemory = True

        provider = CSharpCodeProvider()
        results = provider.CompileAssemblyFromSource(parameters, source_code)

        # Error handling
        if results.Errors.Count > 0:
            log_compilation_errors(results.Errors)
        else:
            print("Compilation successful.")
    except ArgumentException as ex:
        print(f"ArgumentException: {ex.Message}")
    except Exception as ex:
        print(f"An error occurred: {ex.Message}")

def parse_example_data():
    str_value = "123"
    parsed_value = int(str_value)

    str_enum = "Monday"
    day = eval(f"DayOfWeek.{str_enum}")

def log_compilation_errors(errors):
    log_file_path = "CompilationErrors.log"
    with StreamWriter(log_file_path, True) as writer:
        writer.WriteLine(f"Compilation errors at {datetime.datetime.now()}:")
        for error in errors:
            writer.WriteLine(f"Error ({error.ErrorNumber}): {error.ErrorText}")

    print(f"Compilation failed. Check '{log_file_path}' for details.")

if __name__ == "__main__":
    main()
