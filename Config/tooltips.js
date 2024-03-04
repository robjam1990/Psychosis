// Example UI tooltip implementation
function showTooltip(element, message) {
    // Display tooltip when hovering over element
    element.addEventListener('mouseover', function () {
        // Create and position tooltip element
        const tooltip = document.createElement('div');
        tooltip.classList.add('tooltip');
        tooltip.textContent = message;
        tooltip.style.position = 'absolute';
        tooltip.style.left = (element.offsetLeft + element.offsetWidth) + 'px';
        tooltip.style.top = element.offsetTop + 'px';

        // Append tooltip to the document body
        document.body.appendChild(tooltip);

        // Remove tooltip when mouse leaves element
        element.addEventListener('mouseout', function () {
            tooltip.remove();
        });
    });
}
