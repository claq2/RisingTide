(function () {
    if (typeof RISINGTIDE === "undefined" || RISINGTIDE === null) {
        RISINGTIDE = {};
    }

    if (RISINGTIDE.createPaymentSetup == null) {
        RISINGTIDE.createPaymentSetup = function () {
            $("#DueDate").datepicker();
            $("#PayOnDate").datepicker();
            return;
        };
    }

    if (RISINGTIDE.editPaymentSetup == null) {
        RISINGTIDE.editPaymentSetup = function () {
            $("#DueDate").datepicker();
            $("#PayOnDate").datepicker();
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
