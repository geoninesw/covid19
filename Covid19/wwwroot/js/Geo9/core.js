$.fn.digits = function () {
    return this.each(function () {
        $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
    })
}

//$.fn.select2.defaults.set("language", "th");

function formatNumber(num) {
    if (num != null && num != "") {
        var parts = num.split(".");
        var firstPart = parts[0];
        firstPart = firstPart.toString().replace(/,/g, "");
        firstPart = firstPart.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
        parts.shift(); // removes the first item from the array
        var nextParts = parts.join('');
        if (nextParts)
            return firstPart + "." + nextParts;
        else
            return firstPart;
    } else {
        return "";
    }
}