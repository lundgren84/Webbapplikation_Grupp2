
var App = angular.module("App", []);

var factory = {};
App.factory("usersFactory", function () {
        var users = [
           { name: 'John', phone: '555-1212', age: 10 },
           { name: 'Mary', phone: '555-9876', age: 19 },
           { name: 'Mike', phone: '555-4321', age: 21 },
           { name: 'Adam', phone: '555-5678', age: 35 },
           { name: 'Julie', phone: '555-8765', age: 29 }
        ];
     
        factory.getUsers = function () {
            return users;
        }
    return factory;
});
alert("Efter Users");
var controllers = {};

controllers.usersController = function ($scope, usersFactory) {
    $scope.users = usersFactory.getUsers();

}

App.controller(controllers);

//controllers.HighscoreController = ('ExampleController', ['$scope', function ($scope) {
//    alert("efter myApp");
//    var friends = [
//      { name: 'John', phone: '555-1212', age: 10 },
//      { name: 'Mary', phone: '555-9876', age: 19 },
//      { name: 'Mike', phone: '555-4321', age: 21 },
//      { name: 'Adam', phone: '555-5678', age: 35 },
//      { name: 'Julie', phone: '555-8765', age: 29 }
//    ];
//    alert("efter friends");
//    $scope.propertyName = 'age';
//    $scope.reverse = true;
//    $scope.friends = friends;

//    $scope.sortBy = function (propertyName) {
//        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
//        $scope.propertyName = propertyName;
//    };
//}]);



//angular.module('orderByScore', [])
//.controller('Controller', ['$scope', function ($scope) {
//    var contenders = [
//      { avatar: 'John', username: '555-1212', score: 10 },
//      { avatar: 'Mary', username: '555-9876', score: 19 },
//      { avatar: 'Mike', username: '555-4321', score: 21 },
//      { avatar: 'Adam', username: '555-5678', score: 35 },
//      { avatar: 'Juli', username: '555-8765', score: 29 }
//    ];

//    $scope.propertyName = 'score';
//    $scope.reverse = true;
//    $scope.contenders = conteders;

//    $scope.sortBy = function (propertyName) {
//        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
//        $scope.propertyName = propertyName;
//    };
//}]);

//var App = angular.module("App", []);

//App.factory("studentsFactory", function () {
//    var students = [{ name: 'Bartil', course: 'utbildning2', active: false },
//    { name: 'Rune', course: 'utbildning1', active: true },
//    { name: 'Torkel', course: 'utbildning3', active: true },
//    { name: 'Stina', course: 'utbildning4', active: true },
//    { name: 'Gunlög', course: 'utbildning5', active: false },
//    { name: 'Bårje', course: 'utbildning6', active: true }];

//    var factory = {};

//    factory.getStudents = function () {
//        return students;
//    }

//    factory.AddStudentToArray = function (student) {

//        var dfd = $.Deferred();

//        var flag = true;
//        for (var i = 0; i < students.length; i++) {

//            var studentx = students[i]
//            if (studentx.name === student.name) {
//                flag = false;
//                alert("Jodå" + student.name + flag);
//            }
//        }

//        if (flag = false) {
//            dfd.reject();
//        }
//        else {
//            students.push(student);
//            dfd.resolve();

//        }
//        return dfd.promise();


//    }
//    return factory;

//});

//App.factory("coursesFactory"), function () {
//    var courses = [{ name: 'utbildning1' },
//    { name: 'utbildning2' },
//    { name: 'utbildning3' },
//    { name: 'utbildning4' },
//    { name: 'utbildning5' },
//    { name: 'utbildning6' }];

//    var factory = {};
//    factory.getCourses = function () {
//        return courses;
//    }
//    factory.AddCourseToArray = function (course) {
//        courses.push(course);
//    }
//    return factory;
//};

//var controllers = {};

//controllers.studentsController = function ($scope, studentsFactory) {
//    $scope.students = studentsFactory.getStudents();

//    $scope.AddStudent = function () {
//        studentsFactory.AddStudentToArray({ name: $scope.newStudentName, course: $scope.newStudentCourse })
//        document.getElementById("viewList").className = "NotHidden";

//    }
//    $scope.ShowStudents = function () {
//        document.getElementById("viewList").className = "NotHidden";
//    }
//}


//controllers.coursesController = function ($scope, coursesFactory) {
//    $scope.coursess = coursessFactory.getCourses();

//    $scope.AddCourse = function () {
//        coursesFactory.AddCourseToArray({ name: $scope.newCourseName })
//    }
//}
//App.controller(controllers);