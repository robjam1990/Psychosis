# File: robjam1990/Psychosis/Models/popup.py
# Import the Settings Controller module
import settings_controller

def handle_options_form_change(settings):
    settings = read_settings_from_dom_and_persist()
    configure_visible_settings(settings)

def configure_visible_settings(settings):
    options_categories_list = find('.options__categories')
    if options_categories_list.parentElement:
        options_categories_list.parentElement.classList.toggle('hidden', settings.backend == 'psi')

def read_settings_from_dom_and_persist():
    backend_input = find('.options__backend input:checked')
    backend = backend_input.value if backend_input else 'defaultBackend'

    # Construct settings object with input validation
    settings = {
        'backend': backend,
        # Add validation for other settings here
    }

    # Save settings
    settings_controller.save_settings(settings)

    return settings

def find(query, context=document):
    result = context.querySelector(query)
    if not result:
        raise ValueError(f'Element with query "{query}" not found')
    return result

async def init_popup():
    try:
        site_url = await get_site_url()
        settings = await settings_controller.load_settings()

        # Show browser-specific elements
        browser_brand_el = find('.browser-brand--chrome') # Assuming chrome for simplicity
        browser_brand_el.classList.remove('hidden')

        # Add event listener for generating report
        generate_report_button = find('button.button--generate')
        generate_report_button.addEventListener('click', lambda: on_generate_report_button_click(settings['backend'], site_url.href, settings))

        # Add event listener for options form change
        options_form_el = find('.options__form')
        options_form_el.addEventListener('change', lambda: handle_options_form_change(settings))
    except Exception as error:
        handle_initialization_error(error)

async def get_site_url():
    return new Promise((resolve, reject) => {
        chrome.tabs.query({ active: True, lastFocusedWindow: True }, lambda tabs: {
            if len(tabs) == 0 or not tabs[0].url:
                reject(ValueError('No active tab found'))
                return

            url = URL(tabs[0].url)
            if url.hostname == 'localhost':
                reject(ValueError('Use DevTools to audit pages on localhost'))
            elif re.match('^(chrome|about)', url.protocol):
                reject(ValueError(f'Cannot audit {url.protocol}// pages'))
            else:
                resolve(url)
        })

def handle_initialization_error(error):
    generate_report_button = find('button.button--generate')
    psi_disclaimer_el = find('.psi-disclaimer')
    error_message_el = find('.errormsg')

    generate_report_button.disabled = True
    psi_disclaimer_el.remove()
    error_message_el.textContent = error.message

# Initialize the popup
init_popup()
