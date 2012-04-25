if (!RISINGTIDE) {
    var RISINGTIDE = {};
}

if (!RISINGTIDE.createPaymentSetup) {
    RISINGTIDE.createPaymentSetup = function (firstPaymentTextBoxId) {
        $("#FirstPayment").datepicker();
    }
}

if (!RISINGTIDE.pageSetupCommon) {
    RISINGTIDE.pageSetupCommon = function () {
        $(":button").button();
        $(":submit").button();
        return;
    };
}

