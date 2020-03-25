(function (factory) {
    if (typeof define === "function" && define.amd) {
        define(["jquery", "../jquery.validate"], factory);
    } else {
        factory(jQuery);
    }
}(function ($) {

    /*
     * Translated default messages for the jQuery validation plugin.
     * Locale: TH (Thai; ไทย)
     */
    $.extend($.validator.messages, {
        required: "โปรดระบุ",
        remote: "โปรดแก้ไขให้ถูกต้อง",
        email: "โปรดระบุที่อยู่อีเมลที่ถูกต้อง",
        url: "โปรดระบุ URL ที่ถูกต้อง",
        date: "โปรดระบุวันที่ ที่ถูกต้อง",
        dateISO: "โปรดระบุวันที่ ที่ถูกต้อง (ระบบ ISO).",
        number: "โปรดระบุทศนิยมที่ถูกต้อง",
        digits: "โปรดระบุจำนวนเต็มที่ถูกต้อง",
        creditcard: "โปรดระบุรหัสบัตรเครดิตที่ถูกต้อง",
        equalTo: "โปรดระบุค่าเดิมอีกครั้ง",
        extension: "โปรดเลือกไฟล์ที่มีไฟล์นามสกุลตามที่กำหนด",
        accept: "โปรดเลือกไฟล์ที่มีไฟล์นามสกุลตามที่กำหนด",
        maxlength: $.validator.format("โปรดระบุค่าที่ยาวไม่เกิน {0} อักขระ"),
        minlength: $.validator.format("โปรดระบุค่าที่ไม่น้อยกว่า {0} อักขระ"),
        rangelength: $.validator.format("โปรดระบุค่าความยาวระหว่าง {0} ถึง {1} อักขระ"),
        range: $.validator.format("โปรดระบุค่าระหว่าง {0} และ {1}"),
        max: $.validator.format("โปรดระบุค่าน้อยกว่าหรือเท่ากับ {0}"),
        min: $.validator.format("โปรดระบุค่ามากกว่าหรือเท่ากับ {0}"),

        //custom validator
        dateFormat: $.validator.format("โปรดระบุวันที่ในรูปแบบ dd/mm/yyyy"),
        monthFormat: $.validator.format("โปรดระบุเดือนในรูปแบบ mm/yyyy"),
        yearMin: $.validator.format("กรุณาระบุช่วงปีให้ถูกต้อง"),
        yearMax: $.validator.format("กรุณาระบุช่วงปีให้ถูกต้อง"),
        dateMin: $.validator.format("กรุณาระบุช่วงวันให้ถูกต้อง"),
        dateMax: $.validator.format("กรุณาระบุช่วงวันให้ถูกต้อง"),
        dateMins: $.validator.format("กรุณาระบุช่วงวันให้ถูกต้อง"),
        monthMax: $.validator.format("กรุณาระบุช่วงเดือนให้ถูกต้อง"),
        monthMin: $.validator.format("กรุณาระบุช่วงเดือนให้ถูกต้อง"),
        regx: $.validator.format("กรุณาระบุรูปแบบข้อมูลให้ถูกต้อง")
    });

}));