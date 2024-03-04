# File = robjam1990/Psychosis/Models/window.py

import time
from js import Notification

# Define a function to perform expensive work
def do_some_very_expensive_work():
    pass  # Placeholder for expensive work

# This function runs when the window has finished loading
def on_window_load():
    # Check if the browser supports the Notification API
    if Notification:
        # Check if the notification permission is already granted
        if Notification.permission == "granted":
            # If permission is granted, create and show the notification
            Notification('Woof!', {'body': '🐶'})
        # If permission is not granted or denied, request permission from the user
        elif Notification.permission != "denied":
            permission = Notification.requestPermission()
            # If permission is granted, create and show the notification
            if permission == "granted":
                Notification('Woof!', {'body': '🐶'})
            else:
                # If permission is denied, log an error
                print('Notification permission denied')
        else:
            # If notification permission is denied, log an error
            print('Notification permission denied')
    else:
        # If the browser does not support notifications, log an error
        print('Browser does not support notifications')

# Bind the onload event to the on_window_load function
window.onload = on_window_load

# Start a timer to measure the duration of the expensive work
print('Starting expensive work timer...')
start_time = time.time()
# Perform the expensive work here
do_some_very_expensive_work()
# End the timer and log the duration
end_time = time.time()
duration = end_time - start_time
print(f'Expensive work completed in {duration} seconds')
