using System;
using System.Linq;
using System.Threading.Tasks;

namespace RobJam1990.Psychosis.Models
{
    // Import the Settings Controller module
    using SettingsController = SettingsController;

    public static class Popup
    {
        public static async Task InitPopup()
        {
            try
            {
                var siteUrl = await GetSiteUrl();
                var settings = await SettingsController.LoadSettings();

                // Show browser-specific elements
                var browserBrandEl = Find(".browser-brand--chrome"); // Assuming chrome for simplicity
                browserBrandEl.RemoveClass("hidden");

                // Add event listener for generating report
                var generateReportButton = Find("button.button--generate");
                generateReportButton.AddEventListener("click", () =>
                {
                    OnGenerateReportButtonClick(settings["backend"], siteUrl.Href, settings);
                });

                // Add event listener for options form change
                var optionsFormEl = Find(".options__form");
                optionsFormEl.AddEventListener("change", () =>
                {
                    HandleOptionsFormChange(settings);
                });
            }
            catch (Exception error)
            {
                HandleInitializationError(error);
            }
        }

        public static void HandleOptionsFormChange(SettingsController.Settings settings)
        {
            settings = ReadSettingsFromDomAndPersist();
            ConfigureVisibleSettings(settings);
        }

        public static void ConfigureVisibleSettings(SettingsController.Settings settings)
        {
            var optionsCategoriesList = Find(".options__categories");
            optionsCategoriesList?.ParentElement?.ClassList.Toggle("hidden", settings["backend"] == "psi");
        }

        public static SettingsController.Settings ReadSettingsFromDomAndPersist()
        {
            var backendInput = Find(".options__backend input:checked");
            var backend = backendInput != null ? backendInput.Value : "defaultBackend";

            // Construct settings object with input validation
            var settings = new SettingsController.Settings
            {
                ["backend"] = backend,
                // Add validation for other settings here
            };

            // Save settings
            SettingsController.SaveSettings(settings);

            return settings;
        }

        public static Element Find(string query, Element context = Document)
        {
            var result = context.QuerySelector(query);
            if (result == null)
            {
                throw new Exception($"Element with query \"{query}\" not found");
            }
            return result;
        }

        public static async Task<URL> GetSiteUrl()
        {
            // Implement your logic to get site URL asynchronously
        }

        public static void HandleInitializationError(Exception error)
        {
            var generateReportButton = Find("button.button--generate");
            var psiDisclaimerEl = Find(".psi-disclaimer");
            var errorMessageEl = Find(".errormsg");

            generateReportButton.Disabled = true;
            psiDisclaimerEl.Remove();
            errorMessageEl.TextContent = error.Message;
        }

        // Define other methods and classes as needed
    }
}
