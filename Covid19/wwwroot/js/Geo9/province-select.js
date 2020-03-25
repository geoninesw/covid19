(function ($) {

    var LUT_AREA_DATA = null;
    var ProvSelectClass = function (provSelector, ampSelector, tamSelector, createCompleteCallback) {
        this.provSelector = provSelector;
        this.ampSelector = ampSelector;
        this.tamSelector = tamSelector;
        this.createCompleteCallback = createCompleteCallback;

        //control
        this.provControl = null;
        this.ampControl = null;
        this.tamControl = null;

        //variable
        this._isInitial = false;

        this.init();
    };

    ProvSelectClass.prototype.init = function () {
        var me = this;

        me.provControl = $(this.provSelector).select2({ allowClear: true, placeholder: "จังหวัด" })
        me.ampControl = $(this.ampSelector).select2({ allowClear: true, placeholder: "อำเภอ" });
        me.tamControl = $(this.tamSelector).select2({ allowClear: true, placeholder: "ตำบล" });

        /*start : แก้เรื่อง clear แล้วเปิด select list*/
        me.provControl.on("select2:unselecting", function (e) {
            $(this).select2("val", "");
            e.preventDefault();
        });

        me.ampControl.on("select2:unselecting", function (e) {
            $(this).select2("val", "");
            e.preventDefault();
        });

        me.tamControl.on("select2:unselecting", function (e) {
            $(this).select2("val", "");
            e.preventDefault();
        });
        /*end : แก้เรื่อง clear แล้วเปิด select list*/

        me.provControl.prop("disabled", true);
        me.ampControl.prop("disabled", true);
        me.tamControl.prop("disabled", true);

        $.get($.fn.ProvSelect.Default.LutAreaPath, function (response) {
            LUT_AREA_DATA = response;
            me.initControl();
        });
    };

    ProvSelectClass.prototype.initControl = function () {

        this.initControlEvent();
        this.initControlData();

        if ($.isFunction(this.createCompleteCallback)) {
            this.createCompleteCallback();
        }

        this._isInitial = true;
    };

    ProvSelectClass.prototype.initControlEvent = function () {
        var me = this;

        me.provControl.change(function () {
            me.showAmp();
        });
        me.ampControl.change(function () {
            me.showTam();
        });
    };

    ProvSelectClass.prototype.initControlData = function () {
        var me = this;

        me.showProv();
        me.showAmp();
        me.showTam();

        me.provControl.prop("disabled", false);
        me.ampControl.prop("disabled", false);
        me.tamControl.prop("disabled", false);
    };

    ProvSelectClass.prototype.showProv = function () {
        //filter data in BU control
        var me = this, data = LUT_AREA_DATA;
        me.provControl.empty();
        me.provControl.append('<option></option>');
        $.each(data, function (i, ele) {
            me.provControl.append($('<option>').text(ele.PROV_NAMT).attr('value', ele.PROV_CODE));
        });
    };

    ProvSelectClass.prototype.showAmp = function () {
        //filter data in branch control
        var me = this, data = LUT_AREA_DATA;

        var provCode = me.provControl.val();

        me.ampControl.empty();
        me.ampControl.append('<option></option>');
        me.ampControl.select2("val", "");

        if (provCode) {
            var dataProv = $.grep(data, function (ele) { return ele.PROV_CODE === provCode });
            $.each(dataProv[0].amps, function (i, ele) {
                me.ampControl.append($('<option>').text(ele.AMP_NAMT).attr('value', ele.AMP_CODE));
            });
        }
    };

    ProvSelectClass.prototype.showTam = function () {
        //filter data in dept control
        var me = this, data = LUT_AREA_DATA;

        var provCode = me.provControl.val();
        var ampCode = me.ampControl.val();

        me.tamControl.empty();
        me.tamControl.append('<option></option>');
        me.tamControl.select2("val", "");

        if (provCode && ampCode) {
            var dataProv = $.grep(data, function (ele) { return ele.PROV_CODE === provCode });
            var dataAmp = $.grep(dataProv[0].amps, function (ele) { return ele.AMP_CODE === ampCode });

            $.each(dataAmp[0].tams, function (i, ele) {
                me.tamControl.append($('<option>').text(ele.TAM_NAMT).attr('value', ele.TAM_CODE));
            });
        }
    };

    ProvSelectClass.prototype.reset = function () {
        if (this._isInitial) {
            //data ของ option ที่ถูก select
            this.provControl.select2("val", "");
            this.ampControl.select2("val", "");
            this.tamControl.select2("val", "");
        }
    };

    $.fn.ProvSelect = function (provSelector, ampSelector, tamSelector, createCompleteCallback) {
        return new ProvSelectClass(provSelector, ampSelector, tamSelector, createCompleteCallback);
    };

    $.fn.ProvSelect.Default = { basePath: '../' };

}(jQuery));