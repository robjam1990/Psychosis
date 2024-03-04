const fs = require('fs');
const { CSharpCodeProvider, CompilerParameters } = require('Microsoft.CSharp');
const { ArgumentException } = require('System');
const { Debugger } = require('System.Diagnostics');

function main() {
    const sourceCode = `
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
    `;

    debugParseCompile(sourceCode);
}

function debugParseCompile(sourceCode) {
    try {
        // Input validation
        if (!sourceCode || sourceCode.trim() === "") {
            throw new ArgumentException("Source code cannot be null or empty.");
        }

        // Debugging
        Debugger.Break();

        // Parsing
        parseExampleData();

        // Compiling
        const parameters = new CompilerParameters();
        parameters.GenerateExecutable = false;
        parameters.GenerateInMemory = true;

        const provider = new CSharpCodeProvider();
        const results = provider.CompileAssemblyFromSource(parameters, sourceCode);

        // Error handling
        if (results.Errors.Count > 0) {
            logCompilationErrors(results.Errors);
        } else {
            console.log("Compilation successful.");
        }
    } catch (ex) {
        if (ex instanceof ArgumentException) {
            console.log(`ArgumentException: ${ex.Message}`);
        } else {
            console.log(`An error occurred: ${ex.Message}`);
        }
    }
}

function parseExampleData() {
    const strValue = "123";
    const parsedValue = parseInt(strValue);

    const strEnum = "Monday";
    const day = DayOfWeek[strEnum];
}

function logCompilationErrors(errors) {
    const logFilePath = "CompilationErrors.log";
    const timestamp = new Date().toISOString();
    let errorLog = `Compilation errors at ${timestamp}:\n`;

    errors.forEach(error => {
        errorLog += `Error (${error.ErrorNumber}): ${error.ErrorText}\n`;
    });

    fs.appendFileSync(logFilePath, errorLog);
    console.log(`Compilation failed. Check '${logFilePath}' for details.`);
}

if (require.main === module) {
    main();
}
