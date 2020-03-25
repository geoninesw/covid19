/*!
 * jQuery Validation Plugin v1.13.1
 *
 * http://jqueryvalidation.org/
 *
 * Copyright (c) 2014 Jörn Zaefferer
 * Released under the MIT license
 */
(function (factory) {
    if (typeof define === "function" && define.amd) {
        define(["jquery", "./jquery.validate"], factory);
    } else {
        factory(jQuery);
    }
}(function ($) {
    $.validator.setDefaults({
        unhighlight: function (element, errorClass, validClass) {
            $(element).next('span').find('.select2-selection').removeClass('has-error');
            $(element).closest('.input-group').removeClass('has-error');
            $(element).removeClass('error');
        },
        highlight: function (element, errorClass, validClass) {
            $(element).next('span').find('.select2-selection').addClass('has-error');
            $(element).closest('.input-group').addClass('has-error');
            $(element).addClass('error');
        },
        errorPlacement: function (error, element) {
            var elementType = element.prop('type');
            var errorContainer = element.parent().find(".error-container");

            if ($(element).hasClass("upload")) {
                var pnl = $(element).parent().parent().parent().siblings(".upload-error");
                error.insertAfter(pnl);
            }
            else if (element.hasClass("select2-hidden-accessible")) {
                //$(element).next('span').find('.select2-selection').addClass('has-error');
                error.insertAfter($(element).next());
            } else if ($(element).hasClass("pwd")) {
                error.insertAfter(element.parent().siblings(".error-container"));
            }
            else if (errorContainer.length > 0) {
                $(errorContainer[0]).append(error);
            }
            else if (element.parent('.input-group').length) {
                $(element).parent().parent().append(error);
            }
            else if (elementType === 'checkbox') {
                //error.insertAfter(element.parent());
                $(element).parent().parent().parent().append(error);
            }
            else if (elementType === 'radio') {
                $(element).parent().parent().parent().parent().append(error);
            }
            else {
                error.insertAfter(element);
            }
        }
    });

    $.validator.addMethod(
             "dateFormat",
             function (value, element) {
                 // put your own logic here, this is just a (crappy) example
                 //console.log("value", value);
                 if (value.length > 0) {
                     return value.match(/^\d\d\/\d\d\/\d\d\d\d$/);

                 }
                 else {
                     return true;
                 }
             }
         );

    $.validator.addMethod("dateMin", function (value, element, param) {
        try {
            var maxDate = param.maxDate;
            if (value.length > 0 && $(maxDate).val().length > 0) {
                var arrMinDate = value.split('/');
                var arrMaxDate = $(maxDate).val().split('/');

                if (arrMinDate.length == 3 && arrMaxDate.length == 3) {
                    var dMin = new Date(parseInt(arrMinDate[2]) - 543, parseInt(arrMinDate[1]) - 1, parseInt(arrMinDate[0]));
                    var dMax = new Date(parseInt(arrMaxDate[2]) - 543, parseInt(arrMaxDate[1]) - 1, parseInt(arrMaxDate[0]));

                    if (dMax.getTime() >= dMin.getTime()) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
        catch (ex) {
            return true;
        }
        return true;
    });

    $.validator.addMethod("dateMax", function (value, element, param) {
        try {
            var minDate = param.minDate;
            if (value.length > 0 && $(minDate).val().length > 0) {
                var arrMinDate = $(minDate).val().split('/');
                var arrMaxDate = value.split('/');

                if (arrMinDate.length == 3 && arrMaxDate.length == 3) {
                    var dMin = new Date(parseInt(arrMinDate[2]) - 543, parseInt(arrMinDate[1]) - 1, parseInt(arrMinDate[0]));
                    var dMax = new Date(parseInt(arrMaxDate[2]) - 543, parseInt(arrMaxDate[1]) - 1, parseInt(arrMaxDate[0]));
                    if (dMax.getTime() >= dMin.getTime()) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
        catch (ex) {
            return true;
        }

        return true;
    });

    $.validator.addMethod("dateMins", function (value, element, param) {
        try {
            var valid = true;
            $.each(param.maxDate, function (i, val) {
                var maxDate = val;
                if (value.length > 0 && $(maxDate).val().length > 0) {
                    var inputDt = value.split('/');
                    var maxDt = $(maxDate).val().split('/');

                    if (inputDt.length == 3 && maxDt.length == 3) {
                        var dInput = new Date(parseInt(inputDt[2]) - 543, parseInt(inputDt[1]) - 1, parseInt(inputDt[0]));
                        var dMax = new Date(parseInt(maxDt[2]) - 543, parseInt(maxDt[1]) - 1, parseInt(maxDt[0]));

                        if (dInput.getTime() >= dMax.getTime()) {
                            valid = true;
                        }
                        else {
                            valid = false;
                            return valid;
                        }
                    }
                    else {
                        valid = true;
                    }
                } else {
                    valid = true;
                }
            });
            return this.optional(element) || valid;
        }
        catch (ex) {
            return true;
        }
    });

    $.validator.addMethod('filesize', function (value, element, param) {
        return this.optional(element) || (element.files[0].size <= param)
    });

    $.validator.addMethod("regx", function (value, element, regexpr) {
        return regexpr.test(value);
    });
}));