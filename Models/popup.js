// File: robjam1990/Psychosis/Models/popup.js
// Import the Settings Controller module
import * as SettingsController from './settings-controller.js';

/**
 * Handle change events on the options form.
 * @param {SettingsController.Settings} settings
 */
function handleOptionsFormChange(settings) {
    settings = readSettingsFromDomAndPersist();
    configureVisibleSettings(settings);
}

/**
 * Configure visibility of settings based on backend.
 * @param {SettingsController.Settings} settings
 */
function configureVisibleSettings(settings) {
    const optionsCategoriesList = find('.options__categories');
    optionsCategoriesList.parentElement?.classList.toggle('hidden', settings.backend === 'psi');
}

/**
 * Read settings from the DOM and save them.
 * @return {SettingsController.Settings}
 */
function readSettingsFromDomAndPersist() {
    const backendInput = find('.options__backend input:checked');
    const backend = backendInput ? backendInput.value : 'defaultBackend';

    // Construct settings object with input validation
    const settings = {
        backend: backend,
        // Add validation for other settings here
    };

    // Save settings
    SettingsController.saveSettings(settings);

    return settings;
}

/**
 * Find an element in the DOM with a given query.
 * Throws an error if not found.
 * @template {string} T
 * @param {T} query
 * @param {ParentNode=} context
 * @return {HTMLElement}
 */
function find(query, context = document) {
    const result = context.querySelector(query);
    if (!result) {
        throw new Error(`Element with query "${query}" not found`);
    }
    return result;
}

/**
 * Initialize the popup's state and UI elements.
 */
async function initPopup() {
    try {
        const siteUrl = await getSiteUrl();
        const settings = await SettingsController.loadSettings();

        // Show browser-specific elements
        const browserBrandEl = find('.browser-brand--chrome'); // Assuming chrome for simplicity
        browserBrandEl.classList.remove('hidden');

        // Add event listener for generating report
        const generateReportButton = find('button.button--generate');
        generateReportButton.addEventListener('click', () => {
            onGenerateReportButtonClick(settings.backend, siteUrl.href, settings);
        });

        // Add event listener for options form change
        const optionsFormEl = find('.options__form');
        optionsFormEl.addEventListener('change', () => {
            handleOptionsFormChange(settings);
        });
    } catch (error) {
        handleInitializationError(error);
    }
}

/**
 * Get the site URL.
 * @return {Promise<URL>}
 */
function getSiteUrl() {
    return new Promise((resolve, reject) => {
        chrome.tabs.query({ active: true, lastFocusedWindow: true }, function (tabs) {
            if (tabs.length === 0 || !tabs[0].url) {
                reject(new Error('No active tab found'));
                return;
            }

            const url = new URL(tabs[0].url);
            if (url.hostname === 'localhost') {
                reject(new Error('Use DevTools to audit pages on localhost'));
            } else if (/^(chrome|about)/.test(url.protocol)) {
                reject(new Error(`Cannot audit ${url.protocol}// pages`));
            } else {
                resolve(url);
            }
        });
    });
}

/**
 * Handle initialization errors.
 * @param {Error} error
 */
function handleInitializationError(error) {
    const generateReportButton = find('button.button--generate');
    const psiDisclaimerEl = find('.psi-disclaimer');
    const errorMessageEl = find('.errormsg');

    generateReportButton.disabled = true;
    psiDisclaimerEl.remove();
    errorMessageEl.textContent = error.message;
}

// Initialize the popup
initPopup();
