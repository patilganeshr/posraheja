

var SharpiTech = {};

SharpiTech.SaleInSalesPeriod = (function () {

    //placeholder for cached DOM elements
    var DOM = {};

    var shared = new Shared();

    var ReportData = [];
    var TableHeaderCaptions = [];
    var ReportFilterOptions = [];

    /* ---- private method ---- */
    //cache DOM elements
    function cacheDOM() {

        DOM.loader = document.getElementById('Loader');
        DOM.reportFilterOptions = document.getElementById('ReportFilterOptions');
        DOM.reportFilters = document.getElementById('ReportFilters');
        DOM.generateReport = document.getElementById('GenerateReport');
        DOM.reportDataList = document.getElementById('ReportDataList');
        DOM.printReport =  document.getElementById('PrintReport');        
        DOM.exportReport = document.getElementById('ExportReport');
        
    }

    /* ---- handle errors ---- */
    function handleError(err) {
        console.log('Application Error: ' + err);
    }

    /* ---- render ---- */
    function render() {


    }

    function applyPlugins() {

        $('select').select2();

        var currentDate = new Date();

        //DOM.$fromBillDateDatePicker.datetimepicker({
        //    format: 'DD/MMM/YYYY',
        //    defaultDate: moment(currentDate).format("DD/MMM/YYYY")
        //});

        //DOM.$toBillDateDatePicker.datetimepicker({
        //    format: 'DD/MMM/YYYY',
        //    defaultDate: moment(currentDate).format("DD/MMM/YYYY")
        //});

    }

    function bindEvents() {

        DOM.generateReport.addEventListener('click', generateReport);

        DOM.printReport.addEventListener('click', printReport);

        DOM.exportReport.addEventListener('click', exportReport);

    }

    var getExcludeListOfTableHeaders = function() {

        var excludeListOfTableHeaders = [
            'SalesmanId',
            'CompanyId',
            'BranchId',
            'MonthId',
            'SaleTypeId',
            'BrandId',
            'ItemCategoryId',
            'ItemQualityId',
            'ItemId',
            'GoodsReceiptItemId',
            'UnitOfMeasurementId',
            'SalesmanId',
            'SaleQty',
            'UnitCode'
        ];

        return excludeListOfTableHeaders;

    };

    var getTableHeaderCaption = function () {

        TableHeaderCaptions.length = 0;

        var excludeListOfTableHeaders = getExcludeListOfTableHeaders();

        if (ReportData.length) {

            for (var prop in ReportData[0]) {

                var excludeList = excludeListOfTableHeaders.filter(function (value, index, array) {
                    return value.toLowerCase() === prop.toLowerCase();
                });

                if (excludeList.length === 0) {

                    var caption = "";

                    for (var cl = 0; cl < prop.length; cl++) {

                        if (prop.charAt(cl) === prop.charAt(cl).toUpperCase()) {

                            if (cl === 0) {
                                caption += prop.charAt(0);
                            }
                            else {
                                caption += " " + prop.charAt(cl);
                            }

                        }
                        else {
                            caption += prop.charAt(cl);
                        }
                    }

                    TableHeaderCaptions.push(caption);
                    ReportFilterOptions.push(prop);
                }
            }
        }

        return TableHeaderCaptions;
    };

    function bindReportFilterOptions() {

        getTableHeaderCaption();

        var data = "";

        data = "<ul class='list-group checked-list-box'>";
            
        for (var e = 0; e < TableHeaderCaptions.length; e++) {

            var value = TableHeaderCaptions[e];

            var filterOption = value.replace(/\s+/g, "");

            data += "<li class='list-group-item'> <label class='label-tick'> <input type='checkbox' id=" + e + " class='label-checkbox' data-filter-option=" + filterOption + " /> <span class='label-text'></span> </label>" + TableHeaderCaptions[e] + "</li>";

        }

        DOM.reportFilterOptions.innerHTML = data;
        
    }

    
    var createTableHeader = function (data, excludeListOfTableHeaderCaption) {

        var tableHeader = document.createElement('thead');

        tableHeader.innerHTML = "";

        var tableHeaderRow = document.createElement('tr');

        if (TableHeaderCaptions.length) {

            for (var c = 0; c < TableHeaderCaptions.length; c++) {

                var tableHeaderCaption = document.createElement('th');

                tableHeaderCaption.innerText = TableHeaderCaptions[c];

                tableHeaderRow.appendChild(tableHeaderCaption);
            }
        }

        tableHeader.appendChild(tableHeaderRow);

        return tableHeader;
    };

    var createTableBody = function (data, excludeListOfTableHeaderCaption) {

        var tableBody = document.createElement('tbody');

        tableBody.innerHTML = "";

        if (data.length) {

            for (var d = 0; d < data.length; d++) {

                var tableBodyRow = document.createElement('tr');

                for (var prop in data[d]) {

                    var excludeList = excludeListOfTableHeaderCaption.filter(function (value, index, array) {
                        return value.toLowerCase() === prop.toLowerCase();
                    });

                    if (excludeList.length === 0) {

                        var tableDetails = document.createElement('td');

                        tableDetails.innerText = data[d][prop];

                        tableBodyRow.appendChild(tableDetails);
                    }
                }

                tableBody.appendChild(tableBodyRow);

            }
        }

        return tableBody;
    };

    function loadData() {

        shared.showLoader(DOM.loader);

        generateReport();

        shared.hideLoader(DOM.loader);
    }
    
    function generateReport() {

        shared.showLoader(DOM.loader);

        ReportData.length = 0;

        getReportData();

        shared.hideLoader(DOM.loader);
    }

    
    function bindReportData() {

        // Check the Stock Report Data has values
        if (ReportData.length > 0) {

            if (DOM.reportDataList.hasChildNodes('thead')) {
                if (DOM.reportDataList.tHead !== null) {
                    DOM.reportDataList.tHead.remove();
                }
            }

            if (DOM.reportDataList.hasChildNodes('tbody')) {
                if (DOM.reportDataList.tBodies.length ) {
                    DOM.reportDataList.tBodies[0].remove();
                }
            }

            var excludeListOfTableHeaders = getExcludeListOfTableHeaders();

            bindReportFilterOptions();

            var tableHeader = createTableHeader(ReportData, excludeListOfTableHeaders);

            var tableBody = createTableBody(ReportData, excludeListOfTableHeaders);

            DOM.reportDataList.appendChild(tableHeader);

            DOM.reportDataList.appendChild(tableBody);
        }
    }

    function getReportData() {

        shared.showLoader(DOM.loader);

        try {

            //var reportParameters = {
            //    SalesmanId: parseInt(DOM.salesman.options[DOM.salesman.selectedIndex].value),
            //    FromBillDate: DOM.fromBillDate.value,
            //    ToBillDate: DOM.toBillDate.value
            //};

            //var postData = JSON.stringify(reportParameters);

            var url = "GetSalesByValueReportInSalePeriod";

            shared.sendRequest(SERVICE_PATH + url, "GET", true, "JSON", null, function (response) {

                shared.showLoader(DOM.loader);

                if (response.status === 200) {

                    if (response.responseText !== undefined) {

                        var res = JSON.parse(response.responseText);

                        if (res !== undefined) {

                            if (res.length > 0) {

                                ReportData = res;

                                bindReportData();
                            }
                        }
                    }

                    shared.hideLoader(DOM.loader);
                }

                shared.hideLoader(DOM.loader);

            });

        }
        catch (e) {
            handleError("Error in application" + e.message);
        }
        finally {

            shared.hideLoader(DOM.loader);
        }
    }

    function printReport() {

    }

    function exportReport() {

        fnExcelReport();
    }

    function fnExcelReport() {
        var tab_text = "<table border='2px'><tr bgcolor='#87AFC6'>";
        var textRange; var j = 0;
        tab = DOM.salesmanwiseSaleQtyReport; // id of table

        for (j = 0; j < tab.rows.length; j++) {
            tab_text = tab_text + tab.rows[j].innerHTML + "</tr>";
            //tab_text=tab_text+"</tr>";
        }

        tab_text = tab_text + "</table>";
        tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");//remove if u want links in your table
        tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
        tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params

        var ua = window.navigator.userAgent;
        var msie = ua.indexOf("MSIE ");

        if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
        {
            txtArea1.document.open("txt/html", "replace");
            txtArea1.document.write(tab_text);
            txtArea1.document.close();
            txtArea1.focus();
            sa = txtArea1.document.execCommand("SaveAs", true, "Test.xls");
        }
        else                 //other browser not tested on IE 11
            sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));

        return sa;
    }

    /* ---- public methods ---- */
    function init() {
        cacheDOM();
        bindEvents();
        loadData();
    }

    return {
        init: init
    };

}());


SharpiTech.SaleInSalesPeriod.init();
