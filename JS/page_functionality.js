
var currentPage = window.location.href;
var navLinks = document.querySelectorAll('.nav-link');

// Loop through the navigation links and check if their href matches the current page URL
for (var i = 0; i < navLinks.length; i++) {
    if (navLinks[i].href === currentPage) {
        navLinks[i].classList.add('active'); // Add the "active" class to the matching link
    }
}

// If no navigation link is active, make the "Home" link active by default
var homeLink = document.querySelector('.nav-link.home');
if (!homeLink.classList.contains('active')) {
    homeLink.classList.add('active');
}

function deleteCookie(name) {
    document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
}

function logout() {
    deleteCookie('User');
    window.location.href = '/Webforms/LogIn.aspx';
}
