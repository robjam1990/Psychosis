// File = robjam1990/Psychosis/Gameplay/System/Read.js
// Dependencies
import { readFile as _readFile } from 'fs';
import { showOpenDialog } from 'dialog';

// DOM elements
const fileBox = document.getElementById('fileBox');
const btnBrowse = document.getElementById('btnBrowse');
const btnRead = document.getElementById('btnRead');
const btnCancel = document.getElementById('btnCancel');
const progressBarMain = document.getElementById('progressBarMain');
const progressBarDetail = document.getElementById('progressBarDetail');
const lblRemainingTime = document.getElementById('lblRemainingTime');

// Event listeners
btnBrowse.addEventListener('click', async () => {
    try {
        const filePath = await browseForFile();
        fileBox.value = filePath;
    } catch (error) {
        displayAlert(error.message);
    }
});

btnRead.addEventListener('click', async () => {
    // Validate file path
    if (!fileBox.value.trim()) {
        displayAlert("Please select a file to read.");
        return;
    }

    // Start reading file
    const filePath = fileBox.value;
    try {
        // Perform file reading operation, updating progress bars accordingly
        await readFile(filePath);
    } catch (error) {
        displayAlert(`An error occurred while reading the file: ${error.message}`);
    }
});

btnCancel.addEventListener('click', () => {
    // Implement cancellation logic if needed
    // You can use AbortController to cancel async operations
});

fileBox.addEventListener('change', () => {
    // Update UI or perform validation if needed
});

// Function to browse for file
async function browseForFile() {
    return new Promise((resolve, reject) => {
        showOpenDialog({
            properties: ['openFile']
        }, filePaths => {
            if (filePaths && filePaths.length > 0) {
                resolve(filePaths[0]);
            } else {
                reject(new Error("No file selected."));
            }
        });
    });
}

// Asynchronous file reading function
async function readFile(filePath) {
    return new Promise((resolve, reject) => {
        const fileReader = _readFile(filePath, 'utf8', (err, data) => {
            if (err) {
                reject(new Error(`Failed to read file: ${err.message}`));
                return;
            }
            // Process the file data 
            processGameData(data);
            resolve();
        });

        // Track progress of file reading
        let totalFileSize = 0;
        let bytesPerSecond = 1000; // Placeholder value for demonstration
        fileReader.on('data', (chunk) => {
            // Update progress bars and remaining time label
            updateProgress(chunk.length, totalFileSize);
        });

        // Handle file read completion
        fileReader.on('end', () => {
            // Update progress bars and remaining time label
            updateProgress(0, totalFileSize, true);
        });
    });
}

// Function to update progress bars and remaining time label
function updateProgress(bytesRead, totalFileSize, isComplete = false) {
    // Calculate progress percentage based on bytesRead and total file size
    const progressPercentage = (bytesRead / totalFileSize) * 100;

    // Update main progress bar
    progressBarMain.value = progressPercentage;

    // Update detail progress bar (if needed)
    progressBarDetail.value = progressPercentage;

    // Update remaining time label (if needed)
    if (isComplete) {
        lblRemainingTime.textContent = "File reading completed.";
    } else {
        const remainingBytes = totalFileSize - bytesRead;
        const remainingTimeSeconds = remainingBytes / bytesPerSecond;
        lblRemainingTime.textContent = `Remaining Time: ${remainingTimeSeconds.toFixed(2)} seconds`;
    }
}

// Function to process game data read from file
function processGameData(data) {
    // Implement logic to process game data
}

// Function to display alert message
function displayAlert(message) {
    alert(message);
}
