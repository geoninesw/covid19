//GeoLoading
//สำหรับแสดง loading
//static object
(function ($) {
    var GeoLoading = function () {
        this.hasInit = false;
    };

    GeoLoading.TEMPLATE = '<div id="loadingPanel" class="loading-panel"><div class="loading-panel-background"></div><div class="loading-panel-animation"></div></div>';


    GeoLoading.prototype.init = function () {
        //initial loading
        this.$domNode = $(GeoLoading.TEMPLATE);
        $("body").prepend(this.$domNode);
        this.loadingCurrentProcess = [];
        this.$loadingPanel = this.$domNode;

        //$(window).resize($.proxy(this.resize, this));
        //this.resize();

        this.hasInit = true;
        return this;
    };
    GeoLoading.prototype.resize = function () {
        try {
            console.log("GeoLoading.prototype.resize : ");
            var docHeight = $(document).height();

            var winHeight = $(window).height();
            var newHeight = docHeight > winHeight ? docHeight : winHeight;

            this.$loadingPanel.height(newHeight);
        }
        catch (error) {
            console.log("GeoLoading.prototype.resize : ", error);
        }

    };
    GeoLoading.prototype.showLoading = function (processName) {

        if (this.hasInit == false) {
            this.init();
        }

        if (processName) {
            this.loadingCurrentProcess.push(processName);
            //this.$loadingPanel.show();
            this.$loadingPanel.fadeIn("slow");
            //this.resize();
        }
        else {
            console.log("parameter processName is not null");
        }
        return this;
    };

    GeoLoading.prototype.hideLoading = function (processName) {

        if (this.hasInit == false) {
            this.init();
        }

        if (processName) {
            var index = $.inArray(processName, this.loadingCurrentProcess);
            if (index != -1) {
                this.loadingCurrentProcess.splice(index, 1);
            }

            if (this.loadingCurrentProcess.length == 0) {
                this.$loadingPanel.fadeOut("slow");
            }
        }
        else {
            console.log("parameter processName is not null");
        }
        return this;
    };



    // GeoLoading PLUGIN DEFINITION
    // =======================

    var old = $.fn.GeoLoading;

    $.fn.GeoLoading = new GeoLoading();


    // GeoLoading NO CONFLICT
    // =================

    $.fn.GeoLoading.noConflict = function () {
        $.fn.GeoLoading = old
        return this;
    };

}(jQuery));