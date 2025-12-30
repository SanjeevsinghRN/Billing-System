/* ======================= Global Variables starts====================================*/
var headerHeight = $(".navbar-header").height();
var backBtnDisabledPages = ["Appointment.aspx", "AppointmentConfirmPage.aspx", "ChangePasswordPage.aspx", "ConsumerHomePage.aspx",
    "CustomerSupport.aspx", "FAQPage.aspx", "HowToUse.aspx", "NotificationDetails.aspx", "RateUs.aspx",
    "ReminderHistoryPage.aspx", "ServiceFeedback.aspx", "VitalDashBoardPage.aspx"
];
var isScrolling;
/* ======================= Global Variables ends====================================*/
// Listen for scroll events
window.addEventListener('scroll', function (event) {

    // Clear our timeout throughout the scroll
    window.clearTimeout(isScrolling);

    // Set a timeout to run after scrolling ends
    isScrolling = setTimeout(function () {

        // Run the callback
        if ($(".liMenuItem").is(':visible')) {
            $(".navbar-toggle").click();
        }

        $("#divLiteralMobile").hide();
        window.clearTimeout(isScrolling);
    }, 66);

}, false);
$(document).ready(function () {
    setHeaderFieldsPosition();
    $(".navbar-toggle").on('click', function () {
        $("#divLiteralMobile").show();
    });
    $("#divLiteralMobile").on('click', function () {
        $(".navbar-toggle").click();
        $("#divLiteralMobile").hide();
    });
    $(".backBtnIcon").on('click', function () {
        $("[id$='btnBack']").click();
    });
    window.history.pushState(null, "", window.location.href);
    window.onpopstate = function () {
        window.history.pushState(null, "", window.location.href);
    };
});

function setContentHeight(selector, height) {
    $("#" + selector).height(($(window).height() - 51) - Number(height));
};// Setting height of content page by id of parent

$(window).resize(function () {
    if (this.resizeTO) clearTimeout(this.resizeTO);
    this.resizeTO = setTimeout(function () {
        $(this).trigger('resizeEnd');
    }, 100);
});
$(window).bind('resizeEnd', function () {
    setContainerDimension();
    setHeaderFieldsPosition();
});

function setHeaderFieldsPosition() {
    var backBtnDisabled;
    if (document.location.href.includes('?')) {
        if (document.location.href.split('?') != null) {
           
            backBtnDisabled = backBtnDisabledPages.indexOf(document.location.href.split('?')[0].match(/[^\/]+$/)[0]);
        }
        else {
            backBtnDisabled = -1;
           
        }
    }
    else {
        if (document.location.href.match(/[^\/]+$/) != null) {
            backBtnDisabled = backBtnDisabledPages.indexOf(document.location.href.match(/[^\/]+$/)[0]);
            
        }
        else {
            backBtnDisabled = -1;
           
        }
    }
    if (backBtnDisabled > -1) $(".backBtnIcon").hide();//------------------- disabling back button--------------------
    var menuIconPosLeft =  Number($(".navbar-toggle").outerWidth()) + $(".navbar-toggle").offset().left;
    var isMobileView = $(".navbar-toggle").is(':visible');
    $("#divLiteralMobile").hide();
    $(".liMenuItem li[isMobile='0']").removeClass("DN");//------------showing desktop menu items-----------------
    $(".liMenuItem li[isMobile='1']").addClass("DN");//------------hiding mobile menu items-----------------
    $(".desktopView").removeClass("mobileMenu OA");
    $(".menu-control").removeClass("menuList");
    $(".limobileAdjust").removeClass("w100p");

    if (isMobileView) {

        $(".liMenuItem li[isMobile='0']").addClass("DN"); //------------hiding desktop menu items-----------------
        $(".liMenuItem li[isMobile='1']").removeClass("DN"); //------------showing mobile menu items-----------------
        $(".desktopView").addClass("mobileMenu OA");
        $(".menu-control").addClass("menuList");
        $(".limobileAdjust").addClass("w100p");

        $(".navbar-collapse").css({ 'margin-left': 0 });
        $(".menu-control").removeClass("DN");

        // -------------- calculating width of title bar after subtracting other visible header controls----------------
        var width = 0;
        var menuItems = ["btnMapList", "btnFilterMaster", "btnCall"];
        $.each(menuItems, function (index, val) {
            $("." + val).is(':visible') == true ? width += (Number($("." + val).outerWidth()) + Number(parseFloat($("." + val).css("marginLeft")) + parseFloat($("." + val).css("marginRight")))) : 0;
        }); // if width>0 then any filter button is visible----------------------------

       // $(".menu-list").width($(".navbar-header").width())
        $(".menu-list").css({ 'margin-left': menuIconPosLeft });
        if ($(".locationIcon").is(':visible')) {
            if ($("#lblTitle").text() != "") {
                $(".liLocationContainer").width('65%');
                $(".NameTextColor").width('35%');
                $(".liLocationContainer").removeClass("text-center").addClass("text-left");
                $(".NameTextColor").removeClass("DN")
            }
            else if ($("#lblTitle").text() == "") {
                $(".NameTextColor").addClass("DN");
                $(".liLocationContainer").addClass("text-center").removeClass("text-left");
                $(".liLocationContainer").width($(".menu-list").width());
            }
        }
        else {
            if ($("#lblTitle").text() != "" && width > 0) {
                $(".NameTextColor").css({ 'width': $(".menu-list").width() - Number($(".liLocationContainer").width()) });
            }
        }

    }
    else {
        $(".menu-control").removeClass("DN");
    }
}

function ToFixedDecimal(obj, size) {
    if (obj.value != "")
        obj.value = Number(obj.value).toFixed(size);
}
function getSelectionStart(o) {
    if (o.createTextRange) {
        var r = document.selection.createRange().duplicate();
        r.moveEnd("character", o.value.length);
        if (r.text == "") {
            return o.value.length;
        }
        else {
            return o.value.lastIndexOf(r.text);
        }
    }
    else {
        return o.selectionStart;
    }
}
function numericKeypress(e, obj, isDecimal, isNegative, precision, scale) {
    // get decimal character and determine if negatives are allowed
    // set decimal point
    var decimal = (isDecimal === false) ? "" : ".";
    // allow negatives
    var negative = (isNegative === true) ? true : false;
    // get the key that was pressed
    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
    // allow enter/return key (only when in an input box)
    if (key == 13 && $(obj).nodeName.toLowerCase() == "input") {
        return true;
    }
    else if (key == 13) {
        return false;
    }
    var allow = false;
    // allow Ctrl+A
    if ((e.ctrlKey && key == 97 /* firefox */) || (e.ctrlKey && key == 65) /* opera */) { return true; }
    // allow Ctrl+X (cut)
    if ((e.ctrlKey && key == 120 /* firefox */) || (e.ctrlKey && key == 88) /* opera */) { return true; }
    // allow Ctrl+C (copy)
    if ((e.ctrlKey && key == 99 /* firefox */) || (e.ctrlKey && key == 67) /* opera */) { return true; }
    // allow Ctrl+Z (undo)
    if ((e.ctrlKey && key == 122 /* firefox */) || (e.ctrlKey && key == 90) /* opera */) { return true; }
    // allow or deny Ctrl+V (paste), Shift+Ins
    if ((e.ctrlKey && key == 118 /* firefox */) || (e.ctrlKey && key == 86) /* opera */ ||
	  (e.shiftKey && key == 45)) { return true; }
    // if a number was not pressed
    if (key < 48 || key > 57) {
        var value = $(obj).val();
        /* '-' only allowed at start and if negative numbers allowed */
        if (value.indexOf("-") !== 0 && negative && key == 45 && (value.length === 0 || parseInt(getSelectionStart($(obj)), 10) === 0)) { return true; }
        /* only one decimal separator allowed */
        if (decimal && key == decimal.charCodeAt(0) && value.indexOf(decimal) != -1) {
            allow = false;
        }
        // check for other keys that have special purposes
        if (
			key != 8 /* backspace */ &&
			key != 9 /* tab */ &&
			key != 13 /* enter */ &&
			key != 35 /* end */ &&
			key != 36 /* home */ &&
			key != 37 /* left */ &&
			key != 39 /* right */ &&
			key != 46 /* del */
		) {
            allow = false;
        }
        else {
            // for detecting special keys (listed above)
            // IE does not support 'charCode' and ignores them in keypress anyway
            //if (typeof e.charCode != "undefined") {
            //    // special keys have 'keyCode' and 'which' the same (e.g. backspace)
            //    if (e.keyCode == e.which && e.which !== 0) {
            //        allow = true;
            //        // . and delete share the same code, don't allow . (will be set to true later if it is the decimal point)
            //        //if(e.which == 46) { allow = false; }
            //    }
            //        // or keyCode != 0 and 'charCode'/'which' = 0
            //    else if (e.keyCode !== 0 && e.charCode === 0 && e.which === 0) {
            //        allow = true;
            //    }
            //}
        }
        // if key pressed is the decimal and it is not already in the field
        if (decimal && key == decimal.charCodeAt(0)) {
            if (value.indexOf(decimal) == -1) {
                allow = true;
            }
        }
    }
        //if a number key was pressed.
    else {
        // If scale >= 0, make sure there's only <scale> characters
        // after the decimal point.
        if (parseInt(scale) >= 0) {
            var decimalPosition = $(obj).val().indexOf(decimal);
            //If there is a decimal.
            if (decimalPosition >= 0) {
                decimalsQuantity = $(obj).val().length - decimalPosition - 1;
                //If the cursor is after the decimal.
                if (getSelectionStart(obj) > decimalPosition)
                    allow = decimalsQuantity < parseInt(scale);
                else {
                    integersQuantity = ($(obj).val().length - 1) - decimalsQuantity;
                    //If precision > 0, integers and decimals quantity should not be greater than precision
                    if (integersQuantity < (parseInt(precision) - parseInt(scale)))
                        allow = true;
                    else
                        allow = false;
                }
            }
                //If there is no decimal
            else {
                if (parseInt(precision) > 0)
                    allow = $(obj).val().replace(decimal, "").length < parseInt(precision) - parseInt(scale);
                else
                    allow = true;
            }
        }
        else
            // If precision > 0, make sure there's not more digits than precision
            if (parseInt(precision) > 0)
                allow = $(obj).val().replace(decimal, "").length < parseInt(precision);
            else
                allow = true;
    }
    return allow;
}