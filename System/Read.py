# File = robjam1990/Psychosis/Gameplay/System/Read.py
# Dependencies
from tkinter import filedialog
from tkinter import messagebox
import tkinter as tk
import threading

# Initialize tkinter
root = tk.Tk()
root.withdraw()

# DOM elements
fileBox = tk.Entry()
btnBrowse = tk.Button(text="Browse")
btnRead = tk.Button(text="Read")
btnCancel = tk.Button(text="Cancel")
progressBarMain = tk.Progressbar(orient="horizontal", length=100, mode="determinate")
progressBarDetail = tk.Progressbar(orient="horizontal", length=100, mode="determinate")
lblRemainingTime = tk.Label(text="Remaining Time: ")

# Function to browse for file
def browseForFile():
    file_path = filedialog.askopenfilename()
    return file_path

# Function to display alert message
def displayAlert(message):
    messagebox.showinfo("Alert", message)

# Event listeners
def btnBrowseClicked():
    try:
        file_path = browseForFile()
        fileBox.insert(0, file_path)
    except Exception as e:
        displayAlert(str(e))

def btnReadClicked():
    # Validate file path
    if not fileBox.get().strip():
        displayAlert("Please select a file to read.")
        return

    # Start reading file
    file_path = fileBox.get()
    try:
        # Perform file reading operation, updating progress bars accordingly
        t = threading.Thread(target=readFile, args=(file_path,))
        t.start()
    except Exception as e:
        displayAlert(f"An error occurred while reading the file: {str(e)}")

def btnCancelClicked():
    # Implement cancellation logic if needed
    # You can use threading.Event to cancel threads

def fileBoxChanged():
    # Update UI or perform validation if needed
    pass

# Asynchronous file reading function
def readFile(file_path):
    try:
        with open(file_path, 'r') as file:
            data = file.read()
            # Process the file data
            processGameData(data)
    except Exception as e:
        displayAlert(f"Failed to read file: {str(e)}")

# Function to process game data read from file
def processGameData(data):
    # Implement logic to process game data
    pass

# Function to update progress bars and remaining time label
def updateProgress(bytesRead, totalFileSize, isComplete=False):
    # Calculate progress percentage based on bytesRead and total file size
    progress_percentage = (bytesRead / totalFileSize) * 100

    # Update main progress bar
    progressBarMain['value'] = progress_percentage

    # Update detail progress bar (if needed)
    progressBarDetail['value'] = progress_percentage

    # Update remaining time label (if needed)
    if isComplete:
        lblRemainingTime.config(text="File reading completed.")
    else:
        remaining_bytes = totalFileSize - bytesRead
        remaining_time_seconds = remaining_bytes / bytesPerSecond
        lblRemainingTime.config(text=f"Remaining Time: {remaining_time_seconds:.2f} seconds")

# Initialize UI
fileBox.grid(row=0, column=0)
btnBrowse.grid(row=0, column=1)
btnRead.grid(row=1, column=0)
btnCancel.grid(row=1, column=1)
progressBarMain.grid(row=2, column=0)
progressBarDetail.grid(row=3, column=0)
lblRemainingTime.grid(row=4, column=0)

# Event listeners
btnBrowse.config(command=btnBrowseClicked)
btnRead.config(command=btnReadClicked)
btnCancel.config(command=btnCancelClicked)
fileBox.bind("<FocusOut>", lambda event: fileBoxChanged())

# Start tkinter main loop
root.mainloop()
