/// <reference path="D:\EC-Utbildning\WebbabpProject\Tournament.net\Tournament.net\Views/Victory/Finalpage.cshtml" />
var RP = RP || {};

RP.Printdip_btn = $("#Printdip_btn");
RP.Maildip_btn = $("#Maildip_btn");


$(document).ready(function () {

    RP.Printdip_btn.on("click", function () {
        document.getElementById("MPButons").style.visibility = "hidden";
        alert("printar");
        window.print();
        
    });

    RP.Maildip_btn.on("click", function () {

        var AnvD = document.getElementById("EmailAdd").value;


        $.ajax({
            type: "POST",
            url: "/Victory/SendEmail", // the URL of the controller action method
            data: AnviD, // optional data -- här ska mailadresengå
            success: function (result) {
                // do something with result
               
            },
            error: function (req, status, error) {
                // do something with error   
               
            }
        });
    });



    //HB.Testdiploma.on("click", function () {
    //    alert("button has ben clicked");
    //    clickSound2.play();
    //    getHtmlToGameTypeMenuDiv('/Victory/Finalpage');
    //});





    function getHtmlToGameTypeMenuDiv(url) {
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "GET",   // type = What im gonna do with the controller         
            url: url,   // url = controller/action           
            success: function (data) {    // if success i run this function and "data" is what the action returns

                let html = data;
                HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');
                //HL.Top_Div_In_Index.toggle('500');
            }
        });
    }

})