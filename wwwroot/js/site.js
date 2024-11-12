// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function() {
    const textElement = document.getElementById("animatedText");
    const messages = [
        "Stay connected with us and keep your story alive.",
        "Join us and make every memory count!",
        "Reach out to us and start capturing your moments today!"
    ];

    let messageIndex = 0;

    function typeMessage() {
        textElement.textContent = "";  // Clear the text for each new message
        textElement.classList.remove("typing");  // Reset typing animation
        
        setTimeout(() => {
            textElement.textContent = messages[messageIndex];
            textElement.classList.add("typing");
            messageIndex = (messageIndex + 1) % messages.length;  // Loop back to the first message
        }, 100);  // Short delay to reset typing animation
        
        setTimeout(typeMessage, 3000);  // Restart typing after the current message (4s + 3s typing time)
    }

    typeMessage();
});


// Fading-in Animation

    document.addEventListener('DOMContentLoaded', function () {
        // Select all elements with the 'fade-in' class
        const fadeInElements = document.querySelectorAll('.fade-in');

        // Intersection Observer to detect when elements come into the viewport
        const observer = new IntersectionObserver((entries, observer) => {
            entries.forEach(entry => {
                // When the element is at least 50% visible in the viewport
                if (entry.isIntersecting) {
                    entry.target.classList.add('fade-in');
                    observer.unobserve(entry.target); // Stop observing after the fade-in
                }
            });
        }, { threshold: 0.5 }); // Change threshold as needed

        // Observe each element
        fadeInElements.forEach(element => {
            observer.observe(element);
        });
    });

