$.extend({
    clientID: function (id) {
        return $("[id$='" + id + "']");
    }
});
function ordinal_suffix_of(i) {
    var j = i % 10,
        k = i % 100;
    if (j == 1 && k != 11) {
        return i + "st";
    }
    if (j == 2 && k != 12) {
        return i + "nd";
    }
    if (j == 3 && k != 13) {
        return i + "rd";
    }
    return i + "th";
}
function formatDateDD_MMM(val) {
    var date = toDate(val);
    var day = date.getDate();
    var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
   return ordinal_suffix_of(day) + " " + monthNames[date.getMonth()];
}
function toDate(dateStr) {
    var parts = dateStr.split("/");
    return new Date(parts[2], parts[1] - 1, parts[0]);
}
function isValidDate(dateString) {
    // First check for the pattern
    if (!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString))
        return false;

    // Parse the date parts to integers
    var parts = dateString.split("/");
    var day = parseInt(parts[0], 10);
    var month = parseInt(parts[1], 10);
    var year = parseInt(parts[2], 10);

    // Check the ranges of month and year
    if (year < 1000 || year > 3000 || month == 0 || month > 12)
        return false;

    var monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    // Adjust for leap years
    if (year % 400 == 0 || (year % 100 != 0 && year % 4 == 0))
        monthLength[1] = 29;

    // Check the range of the day
    return day > 0 && day <= monthLength[month - 1];
};

function validatePAN(Obj, title) {
    if (Obj == null) Obj = window.event.srcElement;
    if (Obj.value != "") {
        ObjVal = Obj.value;
        var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
        //var code = /([C,P,H,F,A,T,B,L,J,G])/;
        var code = /([C,P,H,F,A,T,B,L,J,G,c,p,h,f,a,t,b,l,j,g])/;
        var code_chk = ObjVal.substring(3, 4);
        if (ObjVal.search(panPat) == -1) {
            //alert("Invalid Pan No");
            //    $("#" + Obj.id).css('border-bottom', '.5px solid red');
            bootbox.alert({ title: title, message: 'Please enter the valid PAN number' });
           // Obj.value = "";
         //   Obj.focus();
            return false;
        }
       // if (code.test(code_chk) == false) {
            // alert("Invaild PAN Card No.");
         //   Obj.value = "";
            //    $("#" + Obj.id).css('border-bottom', '.5px solid red');
       //     bootbox.alert({ title: 'CMCHIS', message: 'Please enter the valid PAN number' });
          //  return false;
       // }
        Obj.value = Obj.value.toUpperCase()
       // $("#" + Obj.id).css('border-bottom', '.5px solid green')
    }
}