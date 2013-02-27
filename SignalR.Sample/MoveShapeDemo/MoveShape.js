/// <reference path="../Scripts/jquery-1.8.3.js" />
/// <reference path="../Scripts/jquery-ui-1.10.0.js" />
/// <reference path="../Scripts/jquery.signalR-1.0.0.js" />

$(function () {
    var hub = $.connection.moveShape,
        $shape = $('#shape');

    $.extend(hub.client, {
        shapeMoved: function(x, y) {
            $shape.css({ left: x, top: y });
        }
    });

    $.connection.hub.start().done(function() {
        $shape.draggable({
            drag: function() {
                hub.server.moveShape(this.offsetLeft, this.offsetTop || 0);
            }
        });
    });
});