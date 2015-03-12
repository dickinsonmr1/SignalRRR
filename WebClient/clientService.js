chatClientApp.factory('chatFactory'), function ChatFactory() {

    chat.client.broadcastMessage = function(name, message) {
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        $scope.messages.push({
            message: $sce.trustAsHtml('<li class="list-group-item"><span class="label label-info"><span class="glyphicon glyphicon-comment"></span><strong> // ' + encodedName
                + '</strong></span>&nbsp;&nbsp;' + encodedMsg + '</li>')
        });
        $scope.$apply();
    };

    chat.client.broadcastAlert = function(name) {
        $scope.messages.push({
            message: $sce.trustAsHtml('<li class="list-group-item"><span class="label label-warning"><span class="glyphicon glyphicon-warning-sign"></span><strong> // ' + name
                + '</strong></span>&nbsp;&nbsp;has sent an alert!</li>')
        });
    };

    chat.client.broadcastJoined = function(name) {
        var encodedName = $('<div />').text(name).html();
        $scope.messages.push({
            message: $sce.trustAsHtml('<li class="list-group-item"><h5><span class="label label-success"><span class="glyphicon glyphicon-plus"></span> // ' + encodedName
                + '</span>&nbsp;&nbsp;has joined.</h5></li>')
        });
        $scope.$apply();
    };

    chat.client.broadcastDisconnected = function(name) {
        $scope.messages.push({
            message: $sce.trustAsHtml('<li class="list-group-item"><h5><span class="label label-danger"><span class="glyphicon glyphicon-minus"></span> // ' + encodedName
                + '</span>&nbsp;&nbsp;has disconnected.</h5></li>')
        });
        $scope.$apply();
    };
};