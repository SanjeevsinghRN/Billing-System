function ToFixedDecimal(obj, size) {
    if (obj.value != "")
        obj.value = Number(obj.value).toFixed(size);
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
            if (typeof e.charCode != "undefined") {
                // special keys have 'keyCode' and 'which' the same (e.g. backspace)
                if (e.keyCode == e.which && e.which !== 0) {
                    allow = true;
                    // . and delete share the same code, don't allow . (will be set to true later if it is the decimal point)
                    //if(e.which == 46) { allow = false; }
                }
                    // or keyCode != 0 and 'charCode'/'which' = 0
                else if (e.keyCode !== 0 && e.charCode === 0 && e.which === 0) {
                    allow = true;
                }
            }
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
function ShowSmallAlert(msg) {
    $('#divAlert').html(msg);
    $('#smallAlert').modal('show');
}
function ShowLookup() {
    $('#Lookuppopup').modal('show');
}
function ShowRefLookup() {
    $('#divReferDoc').modal('show');
}
function ShowConfirmModal(msg, contrl) {
    $('#Controlid').val(contrl);   
    $('#confirmtext').html(msg);
    $('#divConfirmmodal').modal('show');
    return false;
}
function confirmvalue(ctrlvalue) {
    if(ctrlvalue=='OK')
    {
        var contrl = $('#Controlid').val();        
        $("#" + contrl).click();
    }
    if (ctrlvalue == 'CANCEL') {
        $('#divConfirmmodal').modal('hide');
        return false;
    }
}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
function CallContactNo(id) {
    alert(id);
    window.location = 'tel:' + $('[id$='+id+']').text();
}