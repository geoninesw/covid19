(function ($) {

    var LUT_AREA_DATA = null;
    var ProvSelectClass = function (provSelector, ampSelector, createCompleteCallback) {
        this.provSelector = provSelector;
        this.ampSelector = ampSelector;
        this.createCompleteCallback = createCompleteCallback;

        //control
        this.provControl = null;
        this.ampControl = null;

        //variable
        this._isInitial = false;

        this.init();
    };

    ProvSelectClass.prototype.init = function () {
        var me = this;

        me.provControl = $(this.provSelector).select2({ allowClear: true, placeholder: "จังหวัด" })
        me.ampControl = $(this.ampSelector).select2({ allowClear: true, placeholder: "อำเภอ" });
        
        /*start : แก้เรื่อง clear แล้วเปิด select list*/
        //me.provControl.on("select2:unselecting", function (e) {
        //    $(this).select2("val", "");
        //    e.preventDefault();
        //});

        //me.ampControl.on("select2:unselecting", function (e) {
        //    $(this).select2("val", "");
        //    e.preventDefault();
        //});

        /*end : แก้เรื่อง clear แล้วเปิด select list*/

        me.provControl.prop("disabled", true);
        me.ampControl.prop("disabled", true);

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
    };

    ProvSelectClass.prototype.initControlData = function () {
        var me = this;

        me.showProv();
        me.showAmp();

        me.provControl.prop("disabled", false);
        me.ampControl.prop("disabled", false);
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
            console.log(dataProv);
            $.each(dataProv[0].amps, function (i, ele) {
                me.ampControl.append($('<option>').text(ele.AMP_NAMT).attr('value', ele.ID));
            });
        }
    };


    ProvSelectClass.prototype.reset = function () {
        if (this._isInitial) {
            //data ของ option ที่ถูก select
            this.provControl.select2("val", "");
            this.ampControl.select2("val", "");
        }
    };

    $.fn.ProvSelect = function (provSelector, ampSelector, createCompleteCallback) {
        return new ProvSelectClass(provSelector, ampSelector, createCompleteCallback);
    };

    $.fn.ProvSelect.Default = { basePath: '../' };

}(jQuery));