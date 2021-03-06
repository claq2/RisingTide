﻿(function () {
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

    if (RISINGTIDE.upcomingPaymentsSetup == null) {
        RISINGTIDE.upcomingPaymentsSetup = function () {
            $("#StartDate").datepicker({ dateFormat: "m/d/yy" });
//            $("#StartDate").datepicker('setDate', new Date());
            return;
        };
    }
}).call(this);
