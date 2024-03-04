const fs = require('fs');
const uuid = require('uuid');
const sqlite3 = require('sqlite3').verbose();
const { createLogger, transports, format } = require('winston');

class BugTracker {
    constructor(saveLocation) {
        this.saveLocation = saveLocation;
        this.bugReportsFile = `${saveLocation}/bug_reports.db`;
        this._initializeDatabase();
        this.logger = this._setupLogger();
    }

    _initializeDatabase() {
        try {
            // Initialize database and table if not exists
            const db = new sqlite3.Database(this.bugReportsFile);
            db.serialize(() => {
                db.run(`CREATE TABLE IF NOT EXISTS bugs
                        (id TEXT PRIMARY KEY, description TEXT, status TEXT)`);
            });
            db.close();
        } catch (e) {
            this.logger.error(`Error initializing database: ${e}`);
        }
    }

    _setupLogger() {
        const logger = createLogger({
            level: 'debug',
            format: format.combine(
                format.timestamp(),
                format.simple()
            ),
            transports: [
                new transports.File({ filename: `${this.saveLocation}/bug_tracker.log` })
            ]
        });
        return logger;
    }

    reportBug(bugDescription) {
        try {
            if (!bugDescription) {
                throw new Error("Bug description cannot be empty.");
            }
            // Store bug reports in the database
            const bugId = uuid.v4();
            const db = new sqlite3.Database(this.bugReportsFile);
            db.run("INSERT INTO bugs (id, description, status) VALUES (?, ?, ?)", [bugId, bugDescription, "Open"], (err) => {
                if (err) {
                    this.logger.error(`Error reporting bug: ${err}`);
                    console.log("An error occurred while reporting the bug.");
                } else {
                    this.logger.info(`Bug reported successfully. Bug ID: ${bugId}`);
                    console.log(`Bug reported successfully. Bug ID: ${bugId}`);
                }
            });
            db.close();
        } catch (e) {
            this.logger.error(`Error reporting bug: ${e}`);
            console.log("An error occurred while reporting the bug.");
        }
    }

    viewBugs() {
        try {
            // View all reported bugs
            const db = new sqlite3.Database(this.bugReportsFile);
            db.all("SELECT * FROM bugs", (err, bugs) => {
                if (err) {
                    this.logger.error(`Error viewing bugs: ${err}`);
                    console.log("An error occurred while viewing bugs.");
                } else {
                    if (bugs && bugs.length > 0) {
                        bugs.forEach(bug => {
                            console.log(`${bug.id} - ${bug.description} (${bug.status})`);
                        });
                    } else {
                        console.log("No bugs reported.");
                    }
                }
            });
            db.close();
        } catch (e) {
            this.logger.error(`Error viewing bugs: ${e}`);
            console.log("An error occurred while viewing bugs.");
        }
    }

    fixBug(bugId) {
        try {
            const db = new sqlite3.Database(this.bugReportsFile);
            db.get("SELECT * FROM bugs WHERE id=?", [bugId], (err, bug) => {
                if (err) {
                    this.logger.error(`Error fixing bug: ${err}`);
                    console.log("An error occurred while fixing the bug.");
                } else {
                    if (!bug) {
                        console.log("Bug ID not found.");
                    } else {
                        db.run("UPDATE bugs SET status = ? WHERE id = ?", ["Fixed", bugId], (err) => {
                            if (err) {
                                this.logger.error(`Error fixing bug: ${err}`);
                                console.log("An error occurred while fixing the bug.");
                            } else {
                                this.logger.info(`Bug ID ${bugId} has been marked as fixed.`);
                                console.log(`Bug ID ${bugId} has been marked as fixed.`);
                            }
                        });
                    }
                }
            });
            db.close();
        } catch (e) {
            this.logger.error(`Error fixing bug: ${e}`);
            console.log("An error occurred while fixing the bug.");
        }
    }
}

// Example usage:
const bugTracker = new BugTracker('robjam1990/Psychosis/Middleware/');

// Report a bug
bugTracker.reportBug("Encountered a glitch when accessing inventory.");

// View all reported bugs
console.log("All reported bugs:");
bugTracker.viewBugs();

// Assuming you know the bug ID from the viewBugs output, let's say it's "123e4567-e89b-12d3-a456-426614174000"
const bugIdToFix = "123e4567-e89b-12d3-a456-426614174000";
bugTracker.fixBug(bugIdToFix);
