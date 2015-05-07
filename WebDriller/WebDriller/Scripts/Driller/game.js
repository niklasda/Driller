/* game play javascript */
"use strict";

function showInfo(sq, event) {
    log(event.target.id);

    $('#marketSquareMenu').hide('fast');
    $('#storageSquareMenu').hide('fast');
    $('#drillableSquareMenu').hide('fast');
}

function countDownToRemove(divId, endState, timeLeft) {
    var div = $('#' + divId);

    $(div).text(timeLeft + ' s');

    var timer = setInterval(function () {
        timeLeft = Math.max(0, timeLeft - 1);
        $(div).text(timeLeft + ' s');
    }, 1000);

    setTimeout(function () {
        $(div).text("done");
        $(div).hide('slow');
        clearInterval(timer);
        $(div).parent().data('driller-state', endState);

    }, timeLeft * 1000);

}

function buyLand(sq) {
    pingServer(SquareActionCode.DrillLandBuy, sq.id, function (response) {
        if (response.Success) {

            $(sq).data('driller-state', response.StateCode); /* new state needed */
            $(sq).text("bought");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/land.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot buy'); 
        }
    });
}

function buildStation(sq) {
    pingServer(SquareActionCode.MarketPumpStationBuild, sq.id, function (response) {
        if (response.Success) {

            $(sq).data('driller-state', response.StateCode);
            $(sq).text("building");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/station.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot build station'); 
        }
    });
}

function buildRefinery(sq) {
    pingServer(SquareActionCode.StorageBuild, sq.id, function (response) {
        if (response.Success) {

            $(sq).data('driller-state', response.StateCode);
            $(sq).text("building");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/refinery.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot build refinery');
        }
    });
}


function buildDrill(sq) {
    pingServer(SquareActionCode.DrillBuild, sq.id, function (response) {
        if (response.Success) {

            $(sq).data('driller-state', response.StateCode);
            $(sq).text("building");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/drill.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot build drill'); 
        }
    });
}

function upgradeStationCapacity(sq) {
    pingServer(SquareActionCode.MarketPumpStationUprade, sq.id, function (response) {
        if (response.Success) {

            $(sq).data('driller-state', response.StateCode);
            $(sq).text("upgrading");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/station.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot upgrade station');
        }
    });
}

function upgradeRefineryStorageCapacity(sq) {
    pingServer(SquareActionCode.StorageCapacityUpgrade, sq.id, function (response) {
        if (response.Success) {

            $(sq).data('driller-state', response.StateCode);
            $(sq).text("upgrading");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/refinery.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot upgrade refinery');
        }
    });
}

function upgradeRefineryProcessingCapacity(sq) {
    pingServer(SquareActionCode.StorageProcessingUpgrade, sq.id, function (response) {
        if (response.Success) {
            $(sq).data('driller-state', response.StateCode);
            $(sq).text("upgrading");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/refinery.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot upgrade refinery'); 
        }
    });
}

function oneDrill(sq) {
    pingServer(SquareActionCode.Drill, sq.id, function (response) {
        if (response.Success) {
            $(sq).data('driller-state', response.StateCode);
            $(sq).text("drilling");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/drill.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot drill');
        }
    });
}

function oneSell(sq) {
    pingServer(SquareActionCode.MarketSell, sq.id, function (response) {
        if (response.Success) {
            $(sq).data('driller-state', response.StateCode);
            $(sq).text("selling");

            var divId = 'blockingTimerDiv_' + sq.id;
            $(sq).prepend('<img id="theImg" class="actionComplete" src="/Content/Driller/Images/station.png" />');
            $(sq).prepend('<div id="' + divId + '" class="blockingTimerDiv"></div>');
            countDownToRemove(divId, response.StateCodeWhenDone, response.TimeCost);
        } else {
            log('Cannot sell');
        }
    });
}

function positionAndOpenMenu(menu, sq) {

    $(menu).css('left', $(sq).position().left + 9);
    $(menu).css('top', $(sq).position().top + 4);
    $(menu).css("position", "absolute");
    $(menu).show('fast');
}

function openMarketSquareMenu(sq, event) {
    $('#storageSquareMenu').hide('fast');
    $('#pumpableSquareMenu').hide('fast');
    $('#drillableSquareMenu').hide('fast');

    var menu = $('#marketSquareMenu');

    $(menu).find("#marketSquareBuyLand").hide().unbind().bind("tap", function (ev) { $('#marketSquareMenu').hide('fast'); });
    $(menu).find("#marketSquareBuildStation").hide().unbind().bind("tap", function (ev) { $('#marketSquareMenu').hide('fast'); });
    //$(menu).find("#marketSquareStockUp").hide().unbind().bind("tap", function (ev) { $('#marketSquareMenu').hide('fast'); });
    $(menu).find("#marketSquareStartSelling").hide().unbind().bind("tap", function (ev) { $('#marketSquareMenu').hide('fast'); });
    $(menu).find("#marketSquareUpgradeCapacity").hide().unbind().bind("tap", function (ev) { $('#marketSquareMenu').hide('fast'); });

    var squareState = $(sq).data("driller-state");
    if (squareState === SquareStateCode.Available) {
        $(menu).find("#marketSquareBuyLand").show().bind("tap", function (ev) { buyLand(sq); });
    } else if (squareState === SquareStateCode.Owned) {
        $(menu).find("#marketSquareBuildStation").show().bind("tap", function (ev) { buildStation(sq); });
    } else if (squareState === SquareStateCode.Built) {
        $(menu).find("#marketSquareStartSelling").show().bind("tap", function (ev) { oneSell(sq); });
        $(menu).find("#marketSquareUpgradeCapacity").show().bind("tap", function (ev) { upgradeStationCapacity(sq); });
    }

    positionAndOpenMenu(menu, sq);
}

function openStorageSquareMenu(sq, event) {
    $('#marketSquareMenu').hide('fast');
    $('#pumpableSquareMenu').hide('fast');
    $('#drillableSquareMenu').hide('fast');

    var menu = $('#storageSquareMenu');

    $(menu).find("#storageSquareBuyLand").hide().unbind().bind("tap", function (ev) { $('#storageSquareMenu').hide('fast'); });
    $(menu).find("#storageSquareBuildRefinery").hide().unbind().bind("tap", function (ev) { $('#storageSquareMenu').hide('fast'); });
    $(menu).find("#storageSquareUpgradeStorageCapacity").hide().unbind().bind("tap", function (ev) { $('#storageSquareMenu').hide('fast'); });
    $(menu).find("#storageSquareUpgradeProcessingCapacity").hide().unbind().bind("tap", function (ev) { $('#storageSquareMenu').hide('fast'); });

    var squareState = $(sq).data("driller-state");
    if (squareState === SquareStateCode.Available) {
        $(menu).find("#storageSquareBuyLand").show().bind("tap", function (ev) { buyLand(sq); });
    } else if (squareState === SquareStateCode.Owned) {
        $(menu).find("#storageSquareBuildRefinery").show().bind("tap", function (ev) { buildRefinery(sq); });
    } else if (squareState === SquareStateCode.Built) {
        $(menu).find("#storageSquareUpgradeStorageCapacity").show().bind("tap", function (ev) { upgradeRefineryStorageCapacity(sq); });
        $(menu).find("#storageSquareUpgradeProcessingCapacity").show().bind("tap", function (ev) { upgradeRefineryProcessingCapacity(sq); });
    }

    positionAndOpenMenu(menu, sq);
}

function openDrillableSquareMenu(sq, event) {
    $('#marketSquareMenu').hide('fast');
    $('#storageSquareMenu').hide('fast');
    $('#pumpableSquareMenu').hide('fast');

    var menu = $('#drillableSquareMenu');

    $(menu).find("#drillableSquareBuyLand").hide().unbind().bind("tap", function (ev) { $('#drillableSquareMenu').hide('fast'); });
    $(menu).find("#drillableSquareBuildDrill").hide().unbind().bind("tap", function (ev) { $('#drillableSquareMenu').hide('fast'); });
    $(menu).find("#drillableSquareDrill").hide().unbind().bind("tap", function (ev) { $('#drillableSquareMenu').hide('fast'); });

    var squareState = $(sq).data("driller-state");
    if (squareState === SquareStateCode.Available) {
        $(menu).find("#drillableSquareBuyLand").show().bind("tap", function (ev) { buyLand(sq); });
    } else if (squareState === SquareStateCode.Owned) {
        $(menu).find("#drillableSquareBuildDrill").show().bind("tap", function (ev) { buildDrill(sq); });
    } else if (squareState === SquareStateCode.Built) {
        $(menu).find("#drillableSquareDrill").show().bind("tap", function (ev) { oneDrill(sq); });
    }

    positionAndOpenMenu($('#drillableSquareMenu'), sq);
}

function openPumpableSquareMenu(sq, event) {
    $('#marketSquareMenu').hide('fast');
    $('#storageSquareMenu').hide('fast');
    $('#drillableSquareMenu').hide('fast');

    var menu = $('#pumpableSquareMenu');

    $(menu).find("#pumpableSquareBuildPump").hide().unbind().bind("tap", function (ev) { $('#pumpableSquareMenu').hide('fast'); });
    $(menu).find("#pumpableSquareStartPumping").hide().unbind().bind("tap", function (ev) { $('#pumpableSquareMenu').hide('fast'); });
    $(menu).find("#pumpableSquareUpgradePumpCapacity").hide().unbind().bind("tap", function (ev) { $('#pumpableSquareMenu').hide('fast'); });

    var squareState = $(sq).data("driller-state");
    if (squareState === SquareStateCode.Available) {
        $(menu).find("#pumpableSquareBuildPump").show().bind("tap", function (ev) { buyLand(sq); });
    } else if (squareState === SquareStateCode.Owned) {
        $(menu).find("#pumpableSquareStartPumping").show().bind("tap", function (ev) { buildDrill(sq); });
    } else if (squareState === SquareStateCode.Built) {
        $(menu).find("#pumpableSquareUpgradePumpCapacity").show().bind("tap", function (ev) { oneDrill(sq); });
    }

    positionAndOpenMenu($('#pumpableSquareMenu'), sq);
}

function openDrillableOrPumpableSquareMenu(sq, event) {

    var squareType = $(sq).data('driller-type');
    if (squareType === SquareTypeCode.Drillable) {
        openDrillableSquareMenu(sq, event);
    } else if (squareType === SquareTypeCode.Pumpable) {
        openPumpableSquareMenu(sq, event);
    }
}

function setupGamePlayEvents(board) {
    $.event.special.tap.emitTapOnTaphold = false;

    /* market */
    $(board).find("#marketSquare_0").bind("tap", function (event) { openMarketSquareMenu(this, event); });
    $(board).find("#marketSquare_1").bind("tap", function (event) { openMarketSquareMenu(this, event); });
    $(board).find("#marketSquare_2").bind("tap", function (event) { openMarketSquareMenu(this, event); });
    $(board).find("#marketSquare_3").bind("tap", function (event) { openMarketSquareMenu(this, event); });

    $(board).find("#marketSquare_0").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#marketSquare_1").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#marketSquare_2").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#marketSquare_3").bind("taphold", function (event) { showInfo(this, event); });

    /* storage */
    $(board).find("#storageSquare_0").bind("tap", function (event) { openStorageSquareMenu(this, event); });
    $(board).find("#storageSquare_1").bind("tap", function (event) { openStorageSquareMenu(this, event); });
    $(board).find("#storageSquare_2").bind("tap", function (event) { openStorageSquareMenu(this, event); });

    $(board).find("#storageSquare_0").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#storageSquare_1").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#storageSquare_2").bind("taphold", function (event) { showInfo(this, event); });

    /* drillable */
    $(board).find("#drillableSquare_0").bind("tap", function (event) { openDrillableOrPumpableSquareMenu(this, event); });
    $(board).find("#drillableSquare_1").bind("tap", function (event) { openDrillableOrPumpableSquareMenu(this, event); });
    $(board).find("#drillableSquare_2").bind("tap", function (event) { openDrillableOrPumpableSquareMenu(this, event); });
    $(board).find("#drillableSquare_3").bind("tap", function (event) { openDrillableOrPumpableSquareMenu(this, event); });

    $(board).find("#drillableSquare_0").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#drillableSquare_1").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#drillableSquare_2").bind("taphold", function (event) { showInfo(this, event); });
    $(board).find("#drillableSquare_3").bind("taphold", function (event) { showInfo(this, event); });
}

function startGame() {
    setupGamePlayEvents($('#board'));

    var timeLeft = 4 * 60;
    if ($('#board').data('driller-game-state') !== GameStateCode.Started) {
        $('#board').data('driller-game-state', GameStateCode.Started);
        $('#timerDisplay').text(timeLeft + ' s');

        var timer = setInterval(function () {
            timeLeft -= 1;
            $('#timerDisplay').text(timeLeft + ' s');
            if (timeLeft <= 0) {
                clearInterval(timer);
                $('#timerDisplay').text('Game Over!');
                $('#board').data('driller-game-state', GameStateCode.GameOver);
            }
        }, 1000);
    } else {
        $('#startGame').text('Already started');
    }
}
