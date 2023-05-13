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
