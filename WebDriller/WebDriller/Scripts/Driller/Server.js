/* server comm javascript */
"use strict";

function pingServer(actionId, squareName, fknDone) {
    var statusObj = {
        SourceSquareName: squareName,
        ActionId: actionId
    };

    $.ajax({
        type: "POST",
        url: "/Game/Ping",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(statusObj)
    })
        .done(function (data, status, xhr) {
            showStatus(data.StatusText);
            log("Success: " + data.MessageFromServer);
            fknDone(data);
        })
        .fail(function (xhr, status, errorThrown) {
            log(xhr.responseText);
        });
}
