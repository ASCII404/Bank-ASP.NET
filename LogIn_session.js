function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

// Usage
var myCookieValue = getCookie("User");
console.log(myCookieValue);
if (myCookieValue !== "") {
    document.getElementById("user_div").textContent = "Hello, " +myCookieValue + "!";
} else {
    console.log("Cookie not found.");
}


// Get the value of the cookie
function getCookie(name) {
    var cookieValue = document.cookie.match("(^|;)\\s*" + name + "\\s*=\\s*([^;]+)");
    return cookieValue ? cookieValue.pop() : "";
}

// Function to check login status and redirect if not logged in
function checkLoginStatus() {
    var isLoggedIn = getCookie("User");
    if (!isLoggedIn) {
        // Redirect to login page
        window.location.href = "LogIn.aspx";
    }
}

// Call the function to check login status on page load
checkLoginStatus();
