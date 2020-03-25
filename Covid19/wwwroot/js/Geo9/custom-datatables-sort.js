
$.extend($.fn.dataTableExt.oSort, {

    //รับ format 01/12/2558 23:59:26
    "datetime-pre": function (date) { 

        date = date == null || date.length == 0 ? "" : date;

        var checkDate = date.replace(" ", "");

        if (!checkDate) {
            return 0;
        }

        var splitStr = date.split(" ");
        var dateStr = splitStr[0];
        var timeStr = splitStr[1];
        var newDateStr = dateStr.split("/")[2] + dateStr.split("/")[1] + dateStr.split("/")[0];
        var result = newDateStr + timeStr.replace(/:/g, "");
        //console.log("date ", date, " result :", result)

        return Number(result);
    },

    "datetime-asc": function (a, b) {
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },

    "datetime-desc": function (a, b) {
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    },

    //รับ format 01/12/2558
    "datethai-pre": function (date) {

        date = date == null || date.length == 0 ? "" : date;

        var checkDate = date.trim();

        if (!checkDate) {
            return 0;
        }
        var dateSplit = date.split("/");

        var newDateStr = dateSplit[2] + dateSplit[1] + dateSplit[0];
        return Number(newDateStr);
    },

    "datethai-asc": function (a, b) {
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },

    "datethai-desc": function (a, b) {
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    },

    //รับ format 01 ม.ค. 2558
    "datethaishort-pre": function (date) {

        date = date == null || date.length == 0 ? "" : date;

        var checkDate = date.trim();

        if (!checkDate) {
            return 0;
        }
        var dateSplit = date.split(" ");

        switch (dateSplit[1]) {
            case "ม.ค.":
                dateSplit[1] = "01"
                break;
            case "ก.พ.":
                dateSplit[1] = "02"
                break;
            case "มี.ค.":
                dateSplit[1] = "03"
                break;
            case "เม.ย.":
                dateSplit[1] = "04"
                break;
            case "พ.ค.":
                dateSplit[1] = "05"
                break;
            case "มิ.ย.":
                dateSplit[1] = "06"
                break;
            case "ก.ค.":
                dateSplit[1] = "07"
                break;
            case "ส.ค.":
                dateSplit[1] = "08"
                break;
            case "ก.ย.":
                dateSplit[1] = "09"
                break;
            case "ต.ค.":
                dateSplit[1] = "10"
                break;
            case "พ.ย.":
                dateSplit[1] = "11"
                break;
            case "ธ.ค.":
                dateSplit[1] = "12"
                break;
        }
        
        var newDateStr = dateSplit[2] + dateSplit[1] + dateSplit[0];
        return Number(newDateStr);
    },

    "datethaishort-asc": function (a, b) {
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },

    "datethaishort-desc": function (a, b) {
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    },

    //Complain Status - sort by id
    "compstatus-pre": function (a) {
        // Add / alter the switch statement below to match your enum list
        switch (a) {            
            case "แจ้งเรื่อง": return 1;
            case "ไม่รับเรื่อง": return 2;
            case "รับเรื่อง": return 3;
            case "แจ้งหน่วยงานสืบสวน": return 4;
            case "ฝ่ายกฏหมายพิจารณา": return 5;
            case "การสอบสวนทางวินัย": return 6;
            case "สรุปผลการดำเนินการ": return 7;
            default: return 0;
        }
    },

    "compstatus-asc": function (a, b) {
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },

    "compstatus-desc": function (a, b) {
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    },
});

//order column ด้วย field อื่นๆ ใน row
//ex. columns[{ "data": "NAME", "orderDataType": "geo9-other-column", "geo9-other-column-config-name": "NAME_ORDER", "type": "number" }]
//**แสดง field NAME แต่เวลาเทียบค่าจะใช้ field NAME_ORDER 
$.fn.dataTable.ext.order['geo9-other-column'] = function (settings, col) {

    var fieldForOrder = settings.aoColumns[col]["geo9-other-column-config-name"]

    var result = this.api().rows({ order: 'index' }).data().map(function (ele, i) {
        return ele[fieldForOrder];
    });
    return result;
};