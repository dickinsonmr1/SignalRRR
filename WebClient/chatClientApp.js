var chatClientApp = angular.module("chatClientApp", []);
    
$(function() {
    $.connection.hub.url = "http://localhost:57504/signalr";
    var chat = $.connection.chatHub;
    //chatClientApp.value('chat', $.connection.chatHub);

    $.connection.hub.start().done(function() {

        bootbox.prompt("What is your name?", function (result) {
                //$scope
                $('#displayNameOld').val(result);
                $('#displayName').val(result);
                chat.server.sendJoinNotification(result);
                $('#chatBox').focus();
            });

        $('#chatBox').focus();

    }).fail(function(reason) {
        bootbox.alert("SignalR connection failed: " + reason);
    });


    //chatClientApp.directive('focusItem', function () {
    //    return {
    //        link: function (scope, element, attrs) {
    //            scope.$watch(attrs.focusItem, function () {
    //                element[0].focus();
    //            });
    //        }
    //    };
    //});
    //chatClientApp.directive('autoFocus', function ($timeout) {
    //    return {
    //        restrict: 'AC',
    //        link: function (_scope, _element) {
    //            $timeout(function () {
    //                _element[0].focus();
    //            }, 0);
    //        }
    //    };
    //});
});

chatClientApp.value('chat', $.connection.chatHub);
chatClientApp.value('displayName', $('#displayNameOld').val());


