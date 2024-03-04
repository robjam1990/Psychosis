using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using NLog;

public class BugTracker
{
    private string saveLocation;
    private string bugReportsFile;
    private Logger logger;

    public BugTracker(string saveLocation)
    {
        this.saveLocation = saveLocation;
        this.bugReportsFile = Path.Combine(saveLocation, "bug_reports.db");
        this.InitializeDatabase();
        this.logger = SetupLogger();
    }

    private void InitializeDatabase()
    {
        try
        {
            // Initialize database and table if not exists
            using (var connection = new SQLiteConnection($"Data Source={bugReportsFile};Version=3;"))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS bugs
                                        (id TEXT PRIMARY KEY, description TEXT, status TEXT)";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            logger.Error($"Error initializing database: {e}");
        }
    }

    private Logger SetupLogger()
    {
        var logger = LogManager.GetCurrentClassLogger();
        return logger;
    }

    public void ReportBug(string bugDescription)
    {
        try
        {
            if (string.IsNullOrEmpty(bugDescription))
            {
                throw new ArgumentException("Bug description cannot be empty.");
            }
            // Store bug reports in the database
            var bugId = Guid.NewGuid().ToString();
            using (var connection = new SQLiteConnection($"Data Source={bugReportsFile};Version=3;"))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO bugs (id, description, status) VALUES (@id, @description, @status)";
                    cmd.Parameters.AddWithValue("@id", bugId);
                    cmd.Parameters.AddWithValue("@description", bugDescription);
                    cmd.Parameters.AddWithValue("@status", "Open");
                    cmd.ExecuteNonQuery();
                }
            }
            logger.Info($"Bug reported successfully. Bug ID: {bugId}");
            Console.WriteLine($"Bug reported successfully. Bug ID: {bugId}");
        }
        catch (Exception e)
        {
            logger.Error($"Error reporting bug: {e}");
            Console.WriteLine("An error occurred while reporting the bug.");
        }
    }

    public void ViewBugs()
    {
        try
        {
            // View all reported bugs
            using (var connection = new SQLiteConnection($"Data Source={bugReportsFile};Version=3;"))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM bugs";
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["id"]} - {reader["description"]} ({reader["status"]})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No bugs reported.");
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            logger.Error($"Error viewing bugs: {e}");
            Console.WriteLine("An error occurred while viewing bugs.");
        }
    }

    public void FixBug(string bugId)
    {
        try
        {
            using (var connection = new SQLiteConnection($"Data Source={bugReportsFile};Version=3;"))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM bugs WHERE id=@id";
                    cmd.Parameters.AddWithValue("@id", bugId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Bug ID not found.");
                            return;
                        }
                    }
                    cmd.CommandText = "UPDATE bugs SET status=@status WHERE id=@id";
                    cmd.Parameters.AddWithValue("@status", "Fixed");
                    cmd.ExecuteNonQuery();
                }
            }
            logger.Info($"Bug ID {bugId} has been marked as fixed.");
            Console.WriteLine($"Bug ID {bugId} has been marked as fixed.");
        }
        catch (Exception e)
        {
            logger.Error($"Error fixing bug: {e}");
            Console.WriteLine("An error occurred while fixing the bug.");
        }
    }

    public static void Main(string[] args)
    {
        // Example usage:
        var bugTracker = new BugTracker("robjam1990/Psychosis/Middleware/");

        // Report a bug
        bugTracker.ReportBug("Encountered a glitch when accessing inventory.");

        // View all reported bugs
        Console.WriteLine("All reported bugs:");
        bugTracker.ViewBugs();

        // Assuming you know the bug ID from the viewBugs output, let's say it's "123e4567-e89b-12d3-a456-426614174000"
        string bugIdToFix = "123e4567-e89b-12d3-a456-426614174000";
        bugTracker.FixBug(bugIdToFix);
    }
}
