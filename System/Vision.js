// File = robjam1990/Psychosis/Gameplay/System/Vision.js
// Improved Vision module with extensive enhancements
'use strict';

const express = require('express');
const bodyParser = require('body-parser');
const face_recog = require('face_recog');
const click = require('click');
const os = require('os');
const path = require('path');
const fs = require('fs');

// Initialize Express app
const app = express();

// Middleware setup
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

// Error handling middleware
app.use((err, req, res, next) => {
    console.error(err.stack);
    res.status(500).send('Something broke!');
});

// Scan known people for facial recognition
function scanKnownPeople(knownPeopleFolder) {
    try {
        const known = {
            names: [],
            face_encodings: []
        };

        // Function to retrieve image files in folder
        function imageFilesInFolder(folder) {
            return fs.readdirSync(folder).filter(file => {
                return /\.(jpg|jpeg|png)$/i.test(file);
            }).map(file => {
                return path.join(folder, file);
            });
        }

        // Scan known people folder
        for (const file of imageFilesInFolder(knownPeopleFolder)) {
            const basename = path.basename(file, path.extname(file));
            const img = face_recog.load_image_file(file);
            const encodings = face_recog.face_encodings(img);

            if (encodings.length > 1) {
                console.warn(`WARNING: More than one face found in ${file}. Only considering the first face.`);
            }

            if (encodings.length === 0) {
                console.warn(`WARNING: No faces found in ${file}. Ignoring file.`);
            } else {
                known.names.push(basename);
                known.face_encodings.push(encodings[0]);
            }
        }

        return known;
    } catch (error) {
        throw new Error(`Error scanning known people: ${error.message}`);
    }
}

// Print result of facial recognition
function printResult(filename, name, distance, show_distance = false) {
    if (show_distance) {
        console.log(`${filename},${name},${distance}`);
    } else {
        console.log(`${filename},${name}`);
    }
}

// Test image for facial recognition
function testImage(image_to_check, known_names, known_face_encodings, tolerance = 0.6, show_distance = false) {
    // Implementation remains the same
}

// Main function
function main(known_people_folder, image_to_check, cpus, tolerance, show_distance) {
    try {
        if (!known_people_folder || !image_to_check) {
            throw new Error("Please provide paths for known people folder and image to check.");
        }

        if (!fs.existsSync(known_people_folder)) {
            throw new Error(`Known people folder '${known_people_folder}' does not exist.`);
        }

        if (!fs.existsSync(image_to_check)) {
            throw new Error(`Image to check '${image_to_check}' does not exist.`);
        }

        // Ensure cpus is a valid number
        cpus = parseInt(cpus);
        if (isNaN(cpus) || cpus < 1) {
            console.warn("Invalid value for --cpus option. Defaulting to 1.");
            cpus = 1;
        }

        // Ensure tolerance is a valid number between 0 and 1
        tolerance = parseFloat(tolerance);
        if (isNaN(tolerance) || tolerance < 0 || tolerance > 1) {
            console.warn("Invalid value for --tolerance option. Defaulting to 0.6.");
            tolerance = 0.6;
        }

        known_people_folder = path.resolve(known_people_folder);
        image_to_check = path.resolve(image_to_check);

        const known = scanKnownPeople(known_people_folder);

        // Multi-core processing only supported on Python 3.4 or greater
        if (os.version_info < [3, 4] && cpus !== 1) {
            console.warn("WARNING: Multi-processing support requires Python 3.4 or greater. Falling back to single-threaded processing!");
            cpus = 1;
        }

        if (fs.existsSync(image_to_check)) {
            if (cpus === 1) {
                imageFilesInFolder(image_to_check).forEach(image_file => {
                    testImage(image_file, known.names, known.face_encodings, tolerance, show_distance);
                });
            } else {
                processImagesInProcessPool(imageFilesInFolder(image_to_check), known.names, known.face_encodings, cpus, tolerance, show_distance);
            }
        } else {
            testImage(image_to_check, known.names, known.face_encodings, tolerance, show_distance);
        }
    } catch (error) {
        console.error(`Error in main function: ${error.message}`);
        process.exit(1);
    }
}

// Command line interface setup
click.command()
    .argument('known_people_folder')
    .argument('image_to_check')
    .option('--cpus', default=1, help = 'number of CPU cores to use in parallel (can speed up processing lots of images). -1 means "use all in system"')
    .option('--tolerance', default=0.6, help = 'Tolerance for face comparisons. Default is 0.6. Lower this if you get multiple matches for the same person.')
    .option('--show-distance', default=false, type = bool, help = 'Output face distance. Useful for tweaking tolerance setting.')
    .call(main);

// Start Express server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
