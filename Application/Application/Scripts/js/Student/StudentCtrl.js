app.service('StudentService', ['$http', function ($http) {
    var self = this;

    var urlBase = '/Student/';

    self.Get = function () {
        return $http.get(urlBase + 'Student');
    };

    self.Save = function (tmpsudent) {
        return $http.post(urlBase + 'Save', { student: tmpsudent });
    }
    self.Delete = function (id) {
        return $http.get(urlBase + 'Delete/?id=' +id);
    }
}]);

app.controller('StudentController', ['StudentService', '$scope', function (StudentService, $scope) {

    var self = this;
    $scope.Students = [];
    $scope.Student = {};
    self.current;
    self.edit = false;

    function GetStudents() {
        StudentService.Get().success(function (data) {
            $scope.Students = data;
        }).error(function (data) {

        });
    };
    GetStudents();

    $scope.Edit = function (index) {
        self.edit = true;
        self.current = index;
        //angular.copy($scope.Students[index], current);
        angular.copy( $scope.Students[index],$scope.Student);

    }

    $scope.Delete = function (index) {
        var id = $scope.Students[index].ID;
        console.log(id);
        StudentService.Delete(id).success(function (data) {
            $scope.Students.splice(index);
            alert("Success");


        }).error(function (error) {


        });
    }

    $scope.Save = function () {

        StudentService.Save($scope.Student).success(function (data) {

            alert("Success");
            if (self.edit) {
                $scope.Students[self.current] = $scope.Student;
            }
            else {
                $scope.Student.ID = data.OperationId;
                $scope.Students.push($scope.Student);
            }
            $scope.Reset();

        }).error(function (error) {


        });

    }
    $scope.Reset = function () {

        $scope.Student = {};

    }


}]);