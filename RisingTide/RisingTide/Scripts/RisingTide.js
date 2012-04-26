(function () {
    if (typeof RISINGTIDE === "undefined" || RISINGTIDE === null) {
        RISINGTIDE = {};
    }

    if (RISINGTIDE.createPaymentSetup == null) {
        RISINGTIDE.createPaymentSetup = function () {
            $("#FirstPayment").datepicker();
            return;
        };
    }

    if (RISINGTIDE.pageSetupCommon == null) {
        RISINGTIDE.pageSetupCommon = function () {
            $(":button").button();
            $(":submit").button();
            return;
        };
    }
}).call(this);
