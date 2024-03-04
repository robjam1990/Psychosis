using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Psychosis.Gameplay.System
{
    public partial class ReadForm : Form
    {
        private Thread fileReadingThread;

        public ReadForm()
        {
            InitializeComponent();
        }

        // Event handlers
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = BrowseForFile();
                fileBox.Text = filePath;
            }
            catch (Exception ex)
            {
                DisplayAlert(ex.Message);
            }
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            // Validate file path
            if (string.IsNullOrWhiteSpace(fileBox.Text))
            {
                DisplayAlert("Please select a file to read.");
                return;
            }

            // Start reading file
            string filePath = fileBox.Text;
            try
            {
                // Perform file reading operation in a separate thread
                fileReadingThread = new Thread(() => ReadFile(filePath));
                fileReadingThread.Start();
            }
            catch (Exception ex)
            {
                DisplayAlert($"An error occurred while reading the file: {ex.Message}");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Implement cancellation logic if needed
            // You can use CancellationTokenSource to cancel asynchronous operations
        }

        private void FileBox_TextChanged(object sender, EventArgs e)
        {
            // Update UI or perform validation if needed
        }

        // Function to browse for file
        private string BrowseForFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    throw new Exception("No file selected.");
                }
            }
        }

        // Function to display alert message
        private void DisplayAlert(string message)
        {
            MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Asynchronous file reading function
        private void ReadFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string data = reader.ReadToEnd();
                    // Process the file data 
                    ProcessGameData(data);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert($"Failed to read file: {ex.Message}");
            }
        }

        // Function to process game data read from file
        private void ProcessGameData(string data)
        {
            // Implement logic to process game data
        }

        // Function to update progress bars and remaining time label
        private void UpdateProgress(int bytesRead, int totalFileSize, bool isComplete = false)
        {
            // Calculate progress percentage based on bytesRead and total file size
            double progressPercentage = (double)bytesRead / totalFileSize * 100;

            // Update main progress bar
            progressBarMain.Value = (int)progressPercentage;

            // Update detail progress bar (if needed)
            progressBarDetail.Value = (int)progressPercentage;

            // Update remaining time label (if needed)
            if (isComplete)
            {
                lblRemainingTime.Text = "File reading completed.";
            }
            else
            {
                int remainingBytes = totalFileSize - bytesRead;
                double remainingTimeSeconds = (double)remainingBytes / bytesPerSecond;
                lblRemainingTime.Text = $"Remaining Time: {remainingTimeSeconds:F2} seconds";
            }
        }
    }
}
