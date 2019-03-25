test.controller("testCtrl",
    function ($scope) {
        $scope.data = model;
        $scope.message = model.default;
        $scope.Add = function () {

            $scope.message = "Сайт " + $scope.name + " был добавлен.";

            $scope.data.url.push({
                name: $scope.name
            });
        }
    });