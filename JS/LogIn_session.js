// Retrieve the value of a specific cookie by name
function getCookieValue(cookieName, valueName) {
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(cookieName) === 0) {
            var cookieValue = c.substring(cookieName.length + 1); // Remove the cookie name
            var valuePairs = cookieValue.split('&');
            for (var j = 0; j < valuePairs.length; j++) {
                var pair = valuePairs[j].split('=');
                if (pair[0].trim() === valueName) {
                    return pair[1].trim();
                }
            }
        }
    }
    return "";
}
// Check login status and retrieve username and user ID
function checkLoginStatus() {
    var username = getCookieValue("UserInfo", "Username");
    var userId = getCookieValue("UserInfo", "UserID");

    if (username && userId) {
        document.getElementById("user_div").textContent = "Hello, " + username + "!";
    } else {
        window.location.href = "/Webforms/LogIn.aspx";
    }
}

checkLoginStatus();
