function showTooltip(element, message) {
    let tooltip; // Declare tooltip variable outside the event listener for better scope management

    element.addEventListener('mouseover', function () {
        tooltip = document.createElement('div');
        tooltip.textContent = message;
        tooltip.classList.add('tooltip');

        // Calculate tooltip position relative to the viewport
        const rect = element.getBoundingClientRect();
        tooltip.style.left = rect.left + window.scrollX + element.offsetWidth + 'px';
        tooltip.style.top = rect.top + window.scrollY + 'px';

        document.body.appendChild(tooltip);

        // Remove tooltip when mouse leaves element
        element.addEventListener('mouseout', hideTooltip);
    });

    function hideTooltip() {
        if (tooltip) {
            tooltip.remove();
            element.removeEventListener('mouseout', hideTooltip);
        }
    }
}
