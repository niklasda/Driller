/* log javascript */
"use strict";

function showStatus(message) {
    $('#statusBar').find("#statusItem").text(message);
}

function log(message) {
    $("#log").prepend(message + "<br/>");
    console.log(message);
}
