// Select main display elements
const mainImage = document.getElementById('main-image');
const mainHeading = document.getElementById('main-heading');
const description = document.getElementById('description');
const mainLink = document.getElementById('main-link');

// Add event listeners to each tab
document.querySelectorAll('.tab').forEach(tab => {
    tab.addEventListener('click', () => {
        // Get data from the clicked tab
        const src = tab.getAttribute('data-src');
        const title = tab.getAttribute('data-title');
        const desc = tab.getAttribute('data-description');
        const link = tab.getAttribute('data-link');

        // Update main display content
        mainImage.src = src;
        mainHeading.textContent = title;
        description.textContent = desc;

        // Update main link if needed
        mainLink.href = link;  // Set appropriate link here
    });
});
