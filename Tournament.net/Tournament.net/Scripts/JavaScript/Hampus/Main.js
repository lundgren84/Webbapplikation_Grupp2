
// -##- Namespace -##-
var HL = HL || {};

// -##- Divs -##-
HL.Top_Div_In_Index = $('#Top_Div_In_Index');
HL.Top_Div_In_Index.removeClass('hide'); HL.Top_Div_In_Index.hide();
HL.Spinner = $('#Spinner');
HL.Spinner.removeClass('hide'); HL.Spinner.hide();
// -##- Buttons -##-
HL.AccountOptions_btn = $('#AccountOptions_btn');
HL.AccountRegister_btn = $('#AccountRegister_btn');
HL.AccountLogin_btn = $('#AccountLogin_btn');
HL.btn_UploadImage = $('#btn_UploadImage');
HL.btn_SaveOptions = $('#btn_SaveOptions');
// -##- Forms -##-
HL.AccountOptionsForm = $('#AccountOptionsForm');
// -##- Uploads -##-
HL.imgupload = $('#imgupload');






$(document).ready(function () {
   
    // -##- Variables -##-
    HL.OpenInIndexDiv = "";

    // -##- Clicks -##-
    //Options
    HL.AccountOptions_btn.on("click", function () {
        toggleIndexTopDiv('/Account/Options', 'options');
    });

    //Register
    HL.AccountRegister_btn.on('click', function () {
        toggleIndexTopDiv('/Authentication/Register', 'Register');
    });

    //Login
    HL.AccountLogin_btn.on('click', function () {
        toggleIndexTopDiv('/Authentication/Login', 'Login');
    });
    // Save options
    HL.btn_SaveOptions.on("click", function () {
        saveAccountChanges();
    });
 

    // -##- Functions -##-

    // Select text on focus
    function select() {
        $(this).select();
    }
  
    // function to get html to top div in index
    function getHtmlToTopIndexDiv(url) {
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "GET",   // type = What I´m gonna do with the controller         
            url: url,   // url = controller/action           
            success: function (data) {    // if success, I run this function and "data" is what the action returns

                let html = data;
                HL.Top_Div_In_Index.html(html);
                HL.Spinner.toggle('300');
                HL.Top_Div_In_Index.toggle('500');
            }
        });
    }
    // function to toggle top div in index right
    function toggleIndexTopDiv(url, type) {
        if (HL.OpenInIndexDiv === type) {
            HL.OpenInIndexDiv = "";
            HL.Top_Div_In_Index.toggle('500');
        }
        else if (HL.OpenInIndexDiv === "") {
            getHtmlToTopIndexDiv(url);
            HL.OpenInIndexDiv = type;
        } else {
            HL.Top_Div_In_Index.toggle('200');
            setTimeout(function () {
                getHtmlToTopIndexDiv(url);
            }, 220);
            HL.OpenInIndexDiv = type;
        }
    }


});



// TOGGLE_SLIDER
$('#cat_icon,.panel_title').click(function () {
    if ($('#cat_icon').is(':visible')) {
        $('#cat_icon').fadeOut(function () {
            $('#categories').toggle('slide', {
                direction: 'left'
            }, 1000);
        });
    }
    else {
        $('#categories').toggle('slide', {
            direction: 'left'
        }, 1000, function () { $('#cat_icon').fadeIn(); });
    }
});

//<div id="cat_icon">Menu</div>
//<div id="categories">
//    <div CLASS="panel_title">Inner Menu</div>
//    <div CLASS="panel_item">
//        <template:UserControl id="ucCategories" src="UserControls/ProductCategories.ascx"
//        />
//    </div>
//</div>

// Här Henrik

 //html
 //<input type="botton" class="btns" ng-value="1" />
 //<input type="botton" class="btns" ng-value="2" />

 //Javascript

 //var btns = $('.btns');

 //btns.on("click",functions(){
 //var here_is_the_Value = $(this).attr('ng-value')
 //});
 