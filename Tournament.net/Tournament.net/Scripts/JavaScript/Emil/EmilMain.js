var EF = EF || {};

EF.btnGetUser.on("click", function () {
    CheckLogin();
});

EF.btnGetUser = $('#btnGetUser');

$(document).ready(function () {

    EF.btnGetUser.on('click', function () {
        console.log("click");

    });
})
//EF.btnGetUser.on('click', function () {
//   ('/Authentication/Login', 'checklogin');
//});

