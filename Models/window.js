// File = robjam1990/Psychosis/Models/window.js

// This function runs when the window has finished loading
window.onload = function() {
    // Check if the browser supports the Notification API
    if (window.Notification) {
        // Check if the notification permission is already granted
        if (Notification.permission === "granted") {
            // If permission is granted, create and show the notification
            new Notification('Woof!', { body: '🐶' });
        } 
        // If permission is not granted or denied, request permission from the user
        else if (Notification.permission !== "denied") {
            Notification.requestPermission().then(function (permission) {
                // If permission is granted, create and show the notification
                if (permission === "granted") {
                    new Notification('Woof!', { body: '🐶' });
                } else {
                    // If permission is denied, log an error
                    console.error('Notification permission denied');
                }
            });
        } else {
            // If notification permission is denied, log an error
            console.error('Notification permission denied');
        }
    } else {
        // If the browser does not support notifications, log an error
        console.error('Browser does not support notifications');
    }
};

// Start a timer to measure the duration of the expensive work
console.time('doSomeVeryExpensiveWork');
// Perform the expensive work here
doSomeVeryExpensiveWork();
// End the timer and log the duration
console.timeEnd('doSomeVeryExpensiveWork');
