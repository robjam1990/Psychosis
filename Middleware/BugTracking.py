# File = robjam1990/Psychosis/Middleware/BugTracking.py
import os
import uuid
import sqlite3
import logging

class BugTracker:
    def __init__(self, save_location):
        self.save_location = save_location
        self.bug_reports_file = os.path.join(save_location, 'bug_reports.db')
        self._initialize_database()
        self.logger = self._setup_logger()

    def _initialize_database(self):
        try:
            # Initialize database and table if not exists
            conn = sqlite3.connect(self.bug_reports_file)
            c = conn.cursor()
            c.execute('''CREATE TABLE IF NOT EXISTS bugs
                         (id TEXT PRIMARY KEY, description TEXT, status TEXT)''')
            conn.commit()
            conn.close()
        except Exception as e:
            self.logger.error(f"Error initializing database: {str(e)}")

    def _setup_logger(self):
        logger = logging.getLogger(__name__)
        logger.setLevel(logging.DEBUG)
        formatter = logging.Formatter('%(asctime)s - %(levelname)s - %(message)s')
        file_handler = logging.FileHandler(os.path.join(self.save_location, 'bug_tracker.log'))
        file_handler.setFormatter(formatter)
        logger.addHandler(file_handler)
        return logger

    def report_bug(self, bug_description):
        try:
            if not bug_description:
                raise ValueError("Bug description cannot be empty.")
            # Store bug reports in the database
            bug_id = str(uuid.uuid4())
            conn = sqlite3.connect(self.bug_reports_file)
            c = conn.cursor()
            c.execute("INSERT INTO bugs (id, description, status) VALUES (?, ?, ?)", (bug_id, bug_description, "Open"))
            conn.commit()
            conn.close()
            self.logger.info(f"Bug reported successfully. Bug ID: {bug_id}")
            print(f"Bug reported successfully. Bug ID: {bug_id}")
        except Exception as e:
            self.logger.error(f"Error reporting bug: {str(e)}")
            print("An error occurred while reporting the bug.")

    def view_bugs(self):
        try:
            # View all reported bugs
            conn = sqlite3.connect(self.bug_reports_file)
            c = conn.cursor()
            c.execute("SELECT * FROM bugs")
            bugs = c.fetchall()
            conn.close()
            if bugs:
                for bug in bugs:
                    print(f"{bug[0]} - {bug[1]} ({bug[2]})")
            else:
                print("No bugs reported.")
        except Exception as e:
            self.logger.error(f"Error viewing bugs: {str(e)}")
            print("An error occurred while viewing bugs.")

    def fix_bug(self, bug_id):
        try:
            conn = sqlite3.connect(self.bug_reports_file)
            c = conn.cursor()
            c.execute("SELECT * FROM bugs WHERE id=?", (bug_id,))
            bug = c.fetchone()
            if not bug:
                print("Bug ID not found.")
                return
            c.execute("UPDATE bugs SET status = ? WHERE id = ?", ("Fixed", bug_id))
            conn.commit()
            conn.close()
            self.logger.info(f"Bug ID {bug_id} has been marked as fixed.")
            print(f"Bug ID {bug_id} has been marked as fixed.")
        except Exception as e:
            self.logger.error(f"Error fixing bug: {str(e)}")
            print("An error occurred while fixing the bug.")

if __name__ == "__main__":
    # Example usage:
    bug_tracker = BugTracker(save_location='robjam1990/Psychosis/Middleware/')

    # Report a bug
    bug_tracker.report_bug("Encountered a glitch when accessing inventory.")

    # View all reported bugs
    print("All reported bugs:")
    bug_tracker.view_bugs()

    # Assuming you know the bug ID from the view_bugs output, let's say it's "123e4567-e89b-12d3-a456-426614174000"
    bug_id_to_fix = "123e4567-e89b-12d3-a456-426614174000"
    bug_tracker.fix_bug(bug_id_to_fix)
