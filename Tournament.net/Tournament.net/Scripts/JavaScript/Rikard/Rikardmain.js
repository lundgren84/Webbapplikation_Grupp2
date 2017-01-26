var RP = RP || {};

RP.Printdip_btn = $("#Printdip_btn");
RP.Maildip_btn = $("#Maildip_btn");

$(document).ready(function () {

    RP.Printdip_btn.on("click", function () {
        document.getElementById("MPButons").style.visibility = "hidden";

        window.print();
        
    });

    RP.Maildip_btn.on("click", function () {
        alert("Mail");
    });

})