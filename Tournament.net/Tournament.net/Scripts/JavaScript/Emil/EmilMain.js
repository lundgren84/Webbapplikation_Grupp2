var EF = EF || {};

//EF.btnGetUser.on("click", function () {
//    CheckLogin();
//});

//EF.btnGetUser = $('#btnGetUser');

//$(document).ready(function () {

//    EF.btnGetUser.on('click', function () {
//        console.log("click");

//    });
//})
//EF.btnGetUser.on('click', function () {
//   ('/Authentication/Login', 'checklogin');
//});



(document).ready(function () {
    
    EF.classBtnGuest.on("click", function () {
        var currentDiv = $(this).closest("div");
        var newGuest = $(this).prev("Guest").val();
        var username = currentDiv.find("td:eq(0)").html();
        AddNewUserName("/Tournament/HighscoreBracket", newGuest, username);
    
    });
    function AddNewUserName(url,username) {

       
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "POST",   // type = What im gonna do with the controller    
            data: { username: username },
            url: url,   // url = controller/action 
            success: function (data) {    // if success i run this function and "data" is what the action returns

                let html = data;
                //HB.StartButtonDiv.html(html);
           

            }
        });
    }
})


