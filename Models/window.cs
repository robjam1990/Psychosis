using System;
using System.Threading.Tasks;

namespace Psychosis.Models
{
    public class Window
    {
        // This function runs when the window has finished loading
        public static void OnWindowLoad()
        {
            // Check if the browser supports the Notification API
            if (Notification.IsSupported)
            {
                // Check if the notification permission is already granted
                if (Notification.Permission == "granted")
                {
                    // If permission is granted, create and show the notification
                    new Notification("Woof!", new { body = "🐶" });
                }
                // If permission is not granted or denied, request permission from the user
                else if (Notification.Permission != "denied")
                {
                    Notification.RequestPermission().ContinueWith(permission =>
                    {
                        // If permission is granted, create and show the notification
                        if (permission.Result == "granted")
                        {
                            new Notification("Woof!", new { body = "🐶" });
                        }
                        else
                        {
                            // If permission is denied, log an error
                            Console.Error.WriteLine("Notification permission denied");
                        }
                    });
                }
                else
                {
                    // If notification permission is denied, log an error
                    Console.Error.WriteLine("Notification permission denied");
                }
            }
            else
            {
                // If the browser does not support notifications, log an error
                Console.Error.WriteLine("Browser does not support notifications");
            }
        }

        // Define a function to perform expensive work
        public static void DoSomeVeryExpensiveWork()
        {
            // Placeholder for expensive work
        }

        public static void Main(string[] args)
        {
            // Start a timer to measure the duration of the expensive work
            Console.WriteLine("Starting expensive work timer...");
            var startTime = DateTime.Now;
            // Perform the expensive work here
            DoSomeVeryExpensiveWork();
            // End the timer and log the duration
            var endTime = DateTime.Now;
            var duration = endTime - startTime;
            Console.WriteLine($"Expensive work completed in {duration.TotalSeconds} seconds");
        }
    }
}
