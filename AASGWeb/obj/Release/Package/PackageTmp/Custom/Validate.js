





//function validateSubmission() {

//    $(".form-control").removeClass("mustFill");


//    $('input[type=text].required').each(function () {

//        if ($(this).val() == "") {
//            $(this).addClass("mustFill");
//        }
//    })

//    $('.select2.required').each(function () {
      
//        var id = $(this).attr('id') + "_chosen";
//        if ($(this).val() == "Select") {
//            $('#' + id).css({ "border": "1px solid red", "margin-bottom": "0px" });
//    }
//    })
//    $('.chosen-container.chosen-container-single').each(function () {

//        var id = $(this).attr('id') + "_chosen";
//        if ($(this).val() == "Select") {
//            $('#' + id).css({ "border": "1px solid red", "margin-bottom": "0px" });
//        }
//    })
    
//    //$('textarea.required').each(function () {

//    //    if ($(this).val() == "") {
//    //        $(this).addClass("mustFill");
//    //    }
//    //})
//    //$('select.required').each(function () {

//    //    if ($(this).val() == "") {
//    //        $(this).addClass("mustFill");
//    //    }
//    //})
//    //$('input[type=file].required').each(function () {

//    //    if ($(this).val() == "") {
//    //        $(this).addClass("mustFill");
//    //    }
//    //})

//    //$('html,body').animate({ scrollTop: $('input[type=file].required').eq(0).offset().top - 100 });


//    if ($('input[type=text].required').length > 0) {
//        $('html,body').animate({ scrollTop: $('input[type=text].mustFill').eq(0).offset().top - 100 });
//        return false;
//    }
//    return true;

//}

function Number(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '48') && (keyEntry <= '57')))
        return true;
    else {
        return false;
    }
}

function character(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45' || keyEntry == '44')
        return true;
    else {
        return false;
    }
}

function character_and_Number(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '8') || (keyEntry == '32') || (keyEntry == '45') || (keyEntry == '95') || (keyEntry == '46') || ((keyEntry >= '48') && (keyEntry <= '57')))
        return true;
    else {
        return false;
    }
}

function DateValidation(e) {
    isIE = document.all ? 1 : 0
    keyEntry = !isIE ? e.which : event.keyCode;
    if (((keyEntry >= '48') && (keyEntry <= '57') && keyEntry == '47'))
        return true;
    else {
        return false;
    }
}

function isNumberKey(txt, evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode == 46) {
        //Check if the text already contains the . character
        if (txt.value.indexOf('.') === -1) {
            return true;
        } else {
            return false;
        }
    } else {
        if (charCode > 31 &&
            (charCode < 48 || charCode > 57))
            return false;
    }
    return true;
}
//$(document).ready(function () {
//    // allow only  Alphabets A-Z a-z _ and space
//    function Number(e) {
//        isIE = document.all ? 1 : 0
//        keyEntry = !isIE ? e.which : event.keyCode;
//        if (((keyEntry >= '48') && (keyEntry <= '57')))
//            return true;
//        else {
//            return false;
//        }
//    }
//});


function validateDropDowninfo() {

    if ($('#ContentPlaceHolder1_ddlDropdownType').val() == "Select") {
        $('#ContentPlaceHolder1_ddlDropdownType').focus();
        $('#ContentPlaceHolder1_ddlDropdownType').addClass("is-invalid");
        return false;
    } else { $('#ContentPlaceHolder1_ddlDropdownType').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtDropdownItemName').val().length < 1) {
        $('#ContentPlaceHolder1_txtDropdownItemName').focus();
        $('#ContentPlaceHolder1_txtDropdownItemName').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtDropdownItemName').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtDropdownItemAlias').val().length < 1) {
        $('#ContentPlaceHolder1_txtDropdownItemAlias').focus();
        $('#ContentPlaceHolder1_txtDropdownItemAlias').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtDropdownItemAlias').removeClass("is-invalid"); }

   
    return true;
}



function validateStaffinfo() {

    if ($('#ContentPlaceHolder1_txtEmployeeName').val().length < 3 || $('#ContentPlaceHolder1_txtEmployeeName').val().length > 15) {
        $('#ContentPlaceHolder1_txtEmployeeName').focus();
        $('#ContentPlaceHolder1_txtEmployeeName').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtEmployeeName').removeClass("is-invalid"); }

 
    if ($('#ContentPlaceHolder1_txtEmail').val().length < 1 || $('#ContentPlaceHolder1_txtEmail').val().length > 30) {
        $('#ContentPlaceHolder1_txtEmail').focus();
        $('#ContentPlaceHolder1_txtEmail').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtEmail').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtMobile').val().length < 10 || $('#ContentPlaceHolder1_txtMobile').val().length > 10) {
        $('#ContentPlaceHolder1_txtMobile').focus();
        $('#ContentPlaceHolder1_txtMobile').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtMobile').removeClass("is-invalid"); }

    return true;
}

// Supplier Method Start//
function validateSupplierinfo() {

    if ($('#ContentPlaceHolder1_txtSupplierName').val().length < 3 || $('#ContentPlaceHolder1_txtSupplierName').val().length > 15) {
        $('#ContentPlaceHolder1_txtSupplierName').focus();
        $('#ContentPlaceHolder1_txtSupplierName').addClass("is-invalid");
        return false;
    } else { $('#ContentPlaceHolder1_txtSupplierName').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtContactPerson').val().length < 3 || $('#ContentPlaceHolder1_txtContactPerson').val().length > 15) {
        $('#ContentPlaceHolder1_txtContactPerson').focus();
        $('#ContentPlaceHolder1_txtContactPerson').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtContactPerson').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtMobile').val().length < 10 || $('#ContentPlaceHolder1_txtMobile').val().length > 10) {
        $('#ContentPlaceHolder1_txtMobile').focus();
        $('#ContentPlaceHolder1_txtMobile').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtMobile').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtShipToAddress').val().length < 1) {
        $('#ContentPlaceHolder1_txtShipToAddress').focus();
        $('#ContentPlaceHolder1_txtShipToAddress').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtShipToAddress').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtState').val().length < 1) {
        $('#ContentPlaceHolder1_txtState').focus();
        $('#ContentPlaceHolder1_txtState').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtState').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtCity').val().length < 1) {
        $('#ContentPlaceHolder1_txtCity').focus();
        $('#ContentPlaceHolder1_txtCity').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtCity').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtPinCode').val().length < 1) {
        $('#ContentPlaceHolder1_txtPinCode').focus();
        $('#ContentPlaceHolder1_txtPinCode').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtPinCode').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtGstNumber').val().length < 1) {
        $('#ContentPlaceHolder1_txtGstNumber').focus();
        $('#ContentPlaceHolder1_txtGstNumber').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtGstNumber').removeClass("is-invalid"); }


    return true;
}

// Supplier Method End//

//Start Broken Sheet Crate //

function validateBrokenCrateinfo() {


    if ($('#txtBrokenSheetInCreate').val().length < 1 || $('#txtBrokenSheetInCreate').val().length > 3) {
        $('#txtBrokenSheetInCreate').focus();
        $('#txtBrokenSheetInCreate').addClass("is-invalid");
        return false;
    }
    else { $('#txtBrokenSheetInCreate').removeClass("is-invalid"); }

    if ($('#txtNoofSheet').val().length < 1 || $('#txtNoofSheet').val().length > 3) {
        $('#txtNoofSheet').focus();
        $('#txtNoofSheet').addClass("is-invalid");
        return false;
    }
    else { $('#txtNoofSheet').removeClass("is-invalid"); }

    if ($('#txtPcsCutFromSheet').val().length < 1 || $('#txtPcsCutFromSheet').val().length > 3) {
        $('#txtPcsCutFromSheet').focus();
        $('#txtPcsCutFromSheet').addClass("is-invalid");
        return false;
    }
    else { $('#txtPcsCutFromSheet').removeClass("is-invalid"); }

    //if ($('#txtLeftOverSizeLength').val().length < 0 || $('#txtLeftOverSizeLength').val().length > 5) {
    //    $('#txtLeftOverSizeLength').focus();
    //    $('#txtLeftOverSizeLength').addClass("is-invalid");
    //    return false;
    //}
    //else { $('#txtLeftOverSizeLength').removeClass("is-invalid"); }

    //if ($('#txtLeftOverSizeWidth').val().length < 0 || $('#txtLeftOverSizeWidth').val().length > 5) {
    //    $('#txtLeftOverSizeWidth').focus();
    //    $('#txtLeftOverSizeWidth').addClass("is-invalid");
    //    return false;
    //}
    //else { $('#txtLeftOverSizeWidth').removeClass("is-invalid"); }

    return true;
}


//End Broken Sheet Crate//

//Select Drawing for Plan Start//

function validateAcknwoledgeinfo() {


    if ($('#txtThickness').val().length < 1 || $('#txtThickness').val().length > 3) {
        $('#txtThickness').focus();
        $('#txtThickness').addClass("is-invalid");
        return false;
    }
    else { $('#txtThickness').removeClass("is-invalid"); }

    if ($('#txtSheetHeight').val().length < 1 || $('#txtSheetHeight').val().length > 5) {
        $('#txtSheetHeight').focus();
        $('#txtSheetHeight').addClass("is-invalid");
        return false;
    }
    else { $('#txtSheetHeight').removeClass("is-invalid"); }

    if ($('#txtSheetWidth').val().length < 1 || $('#txtSheetWidth').val().length > 5) {
        $('#txtSheetWidth').focus();
        $('#txtSheetWidth').addClass("is-invalid");
        return false;
    }
    else { $('#txtSheetWidth').removeClass("is-invalid"); }


    if ($('#txtNoofSheetIssue').val().length < 1 || $('#txtNoofSheetIssue').val().length > 5) {
        $('#txtNoofSheetIssue').focus();
        $('#txtNoofSheetIssue').addClass("is-invalid");
        return false;
    }
    else { $('#txtNoofSheetIssue').removeClass("is-invalid"); }

    if ($('#txtQuantityPerSheet').val().length < 1 || $('#txtQuantityPerSheet').val().length > 3) {
        $('#txtQuantityPerSheet').focus();
        $('#txtQuantityPerSheet').addClass("is-invalid");
        return false;
    }
    else { $('#txtQuantityPerSheet').removeClass("is-invalid"); }

    if ($('#txttotalExpectation').val().length < 1 || $('#txttotalExpectation').val().length > 3) {
        $('#txttotalExpectation').focus();
        $('#txttotalExpectation').addClass("is-invalid");
        return false;
    }
    else { $('#txttotalExpectation').removeClass("is-invalid"); }

    return true;
}


function validateOtherItemAndDraftinfo() {


    if ($('#txtNoofSheetIssue').val().length < 1 || $('#txtNoofSheetIssue').val().length > 5) {
        $('#txtNoofSheetIssue').focus();
        $('#txtNoofSheetIssue').addClass("is-invalid");
        return false;
    }
    else { $('#txtNoofSheetIssue').removeClass("is-invalid"); }

    if ($('#txtItemQuantityPerSheetfromOther').val().length < 1 || $('#txtItemQuantityPerSheetfromOther').val().length > 3) {
        $('#txtItemQuantityPerSheetfromOther').focus();
        $('#txtItemQuantityPerSheetfromOther').addClass("is-invalid");
        return false;
    }
    else { $('#txtItemQuantityPerSheetfromOther').removeClass("is-invalid"); }

    if ($('#txtTotalExpectationfromOther').val().length < 1 || $('#txtTotalExpectationfromOther').val().length > 3) {
        $('#txtTotalExpectationfromOther').focus();
        $('#txtTotalExpectationfromOther').addClass("is-invalid");
        return false;
    }
    else { $('#txtTotalExpectationfromOther').removeClass("is-invalid"); }

    return true;
}



//Select Drawing for Plan End



function validateLogininfo() {

    if ($('#user').val().length < 1) {
        $('#user').focus();
        $('#user').addClass("is-invalid");
        return false;
    } else { $('#user').removeClass("is-invalid"); }


    if ($('#password').val().length < 1) {
        $('#password').focus();
        $('#password').addClass("is-invalid");
        return false;
    }
    else { $('#password').removeClass("is-invalid"); }


    return true;
}



// Lead Method Start//
function validateLeadinfo() {

    if ($('#ContentPlaceHolder1_ddlPartyName').val() == "Select") {
        $('#ContentPlaceHolder1_ddlPartyName').focus();
        $('#ContentPlaceHolder1_ddlPartyName').addClass("is-invalid");
        return false;
    } else { $('#ContentPlaceHolder1_ddlPartyName').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtContactPerson').val().length < 3 || $('#ContentPlaceHolder1_txtContactPerson').val().length > 15) {
        $('#ContentPlaceHolder1_txtContactPerson').focus();
        $('#ContentPlaceHolder1_txtContactPerson').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtContactPerson').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtMobile').val().length < 10 || $('#ContentPlaceHolder1_txtMobile').val().length > 10) {
        $('#ContentPlaceHolder1_txtMobile').focus();
        $('#ContentPlaceHolder1_txtMobile').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtMobile').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtFollowUpDate').val().length < 1 ) {
        $('#ContentPlaceHolder1_txtFollowUpDate').focus();
        $('#ContentPlaceHolder1_txtFollowUpDate').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtFollowUpDate').removeClass("is-invalid"); }

   
    return true;
}

function validateFollowupinfo() {

    if ($('#ContentPlaceHolder1_ddlPartyName').val() == "Select") {
        $('#ContentPlaceHolder1_ddlPartyName').focus();
        $('#ContentPlaceHolder1_ddlPartyName').addClass("is-invalid");
        return false;
    } else { $('#ContentPlaceHolder1_ddlPartyName').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtFollowUpDate').val().length < 1) {
        $('#ContentPlaceHolder1_txtFollowUpDate').focus();
        $('#ContentPlaceHolder1_txtFollowUpDate').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtFollowUpDate').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtNextFollowUpDate').val().length < 1) {
        $('#ContentPlaceHolder1_txtNextFollowUpDate').focus();
        $('#ContentPlaceHolder1_txtNextFollowUpDate').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtNextFollowUpDate').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtSpecialRemarks').val().length < 1) {
        $('#ContentPlaceHolder1_txtSpecialRemarks').focus();
        $('#ContentPlaceHolder1_txtSpecialRemarks').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtSpecialRemarks').removeClass("is-invalid"); }


    return true;
}

// Lead Method End//

//GRN Validation Method Start//
function validateGRNSearchinfo() {

    
    if ($('#ContentPlaceHolder1_txtPoNumber').val().length < 1 || $('#ContentPlaceHolder1_txtPoNumber').val().length > 6) {
        $('#ContentPlaceHolder1_txtPoNumber').focus();
        $('#ContentPlaceHolder1_txtPoNumber').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtPoNumber').removeClass("is-invalid"); }

    return true;
}
function validateGRNSubmitinfo() {


    if ($('#ContentPlaceHolder1_txtSupplierName').val().length < 1 ) {
        $('#ContentPlaceHolder1_txtSupplierName').focus();
        $('#ContentPlaceHolder1_txtSupplierName').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtSupplierName').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtMobile').val().length < 10 || $('#ContentPlaceHolder1_txtMobile').val().length > 10) {
        $('#ContentPlaceHolder1_txtMobile').focus();
        $('#ContentPlaceHolder1_txtMobile').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtMobile').removeClass("is-invalid"); }

    if ($('#ContentPlaceHolder1_txtInvoiceNumber').val().length < 1 || $('#ContentPlaceHolder1_txtPoNumber').val().length > 15) {
        $('#ContentPlaceHolder1_txtInvoiceNumber').focus();
        $('#ContentPlaceHolder1_txtInvoiceNumber').addClass("is-invalid");
        return false;
    }
    else { $('#ContentPlaceHolder1_txtInvoiceNumber').removeClass("is-invalid"); }

    //if ($('#ContentPlaceHolder1_rptrPurchaseOrderItemsList_txtReceivedQuantity').val().length < 1 || $('#ContentPlaceHolder1_rptrPurchaseOrderItemsList_txtReceivedQuantity').val().length > 4) {
    //    $('#ContentPlaceHolder1_rptrPurchaseOrderItemsList_txtReceivedQuantity').focus();
    //    $('#ContentPlaceHolder1_rptrPurchaseOrderItemsList_txtReceivedQuantity').addClass("is-invalid");
    //    return false;
    //}
    //else { $('#ContentPlaceHolder1_rptrPurchaseOrderItemsList_txtReceivedQuantity').removeClass("is-invalid"); }



    return true;
}

//GRN Validation Method Stop//


//return (!((event.keyCode >= 65) && event.keyCode != 32) || (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode >= 96 && event.keyCode <= 105));"





