

var SharpiTech = {};

SharpiTech.PurchaseDailyActivity = (function () {

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
        DOM.reportParameters = document.getElementById('ReportParameters');
        DOM.reportFilters = document.getElementById('ReportFilters');
        DOM.reportCriteria1 = document.getElementById('ReportCriteria1');
        DOM.reportCriteria2 = document.getElementById('ReportCriteria2');
        DOM.reportCriteriaList = document.getElementById('ReportCriteriaList');
        DOM.addCriteria = document.getElementById('AddCriteria');
        DOM.generateReport = document.getElementById('GenerateReport');
        DOM.reportDataList = document.getElementById('ReportDataList');
        DOM.printReport = document.getElementById('PrintReport');
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

    $("select").on("change", function (event) {

        setFocusOnSelect(event);

    });

    function setFocusOnSelect(e) {
        setTimeout(function () {
            e.currentTarget.focus();
        }, 200);
    }

    function bindEvents() {

        DOM.addCriteria.addEventListener('click', addReportCriteria);

        DOM.generateReport.addEventListener('click', generateReport);

        DOM.printReport.addEventListener('click', printReport);

        DOM.exportReport.addEventListener('click', exportReport);

    }

    function loadFilterOptions() {

        var option = "";

        option += "<option value='-1'>Choose Filter</option>";
        option += "<option value='1'>Equal to</option>";
        option += "<option value='2'>Greater than or equal to</option>";
        option += "<option value='3'>Less than or equal to</option>";
        option += "<option value='4'>Contains</option>";
        option += "<option value='5'>Does not equal to</option>";
        option += "<option value='6'>Between</option>";

        DOM.reportFilters.innerHTML = option;

        shared.setSelectValue(DOM.reportFilters, "Purchase Bill Date", null);
        shared.setSelect2ControlsText(DOM.reportFilters);

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
            'UnitCode',
            'MinDiscountAmount',
            'MaxDiscountAmount',
            'SalesBillFromDate',
            'SalesBillToDate',
            'PurchaseBillId',
            'FromDate',
            'ToDate',
            'UserId'
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

    function bindReportParameters() {

        getTableHeaderCaption();

        var data = "";

        //data = "<ul class='list-group checked-list-box'>";

        for (var e = 0; e < TableHeaderCaptions.length; e++) {

            var value = TableHeaderCaptions[e];

            var parameterName = value.replace(/\s+/g, "");

            //data += "<li class='list-group-item'> <label class='label-tick'> <input type='checkbox' id=" + e + " class='label-checkbox' data-filter-option=" + parameterName + " /> <span class='label-text'></span> </label>" + TableHeaderCaptions[e] + "</li>";

            data += "<option value='" + parameterName + "'>" + TableHeaderCaptions[e] + "</option>";
        }

        DOM.reportParameters.innerHTML = data;

        //addEventsToListItem();
    }

    function addReportCriteria() {

        var table = DOM.reportCriteriaList;

        var tableBody = table.tBodies[0];

        var tableRow = shared.createElement('TR');

        var data = "";
        var parameterName = null;
        var parameterValue = null;
        var criteria1 = null;
        var criteria2 = null;
        var selectedIndex = 0;

        selectedIndex = parseInt(DOM.reportParameters.selectedIndex);
        parameterName = DOM.reportParameters.options[selectedIndex].text;
        parameterValue = DOM.reportParameters.options[selectedIndex].value;
        criteria1 = DOM.reportCriteria1.value;
        criteria2 = DOM.reportCriteria2.value;

        tableRow.setAttribute('data-parameter-value', parameterValue);

        data += "<td>" + parameterName + "</td>";
        data += "<td>Equal To</td>";
        if (criteria2 === "") {
            data += "<td>" + criteria1 + "</td>";
        }
        else {
            data += "<td>" + criteria1 + " and " + criteria2 + "</td>";
        }
        data += "<td><button type='button' id='" + parameterValue + "' class='btn btn-sm btn-danger'><i class='fa fa-remove'></i></button></td>";

        tableRow.innerHTML = data;

        tableBody.appendChild(tableRow);

        addEventsToTableElements();
    }

    function addEventsToTableElements() {

        var table = DOM.reportCriteriaList;

        var tableBody = table.tBodies[0];

        var buttons = tableBody.querySelectorAll('button[type="button"]');

        if (buttons.length) {

            for (var b = 0; b < buttons.length; b++) {

                buttons[b].onclick = function (e) {
                    removeItem(e);
                };
            }
        }
    }

    function removeItem(e) {

        var tableBody = DOM.reportCriteriaList.tBodies[0];

        var tableRow = null;

        if (e.target.nodeName.toLowerCase() === "i") {
            tableRow = e.target.parentElement.parentElement.parentElement;
        }
        else {
            tableRow = e.target.parentElement.parentElement;
        }

        if (tableRow !== null || tableRow !== undefined) {

            tableBody.removeChild(tableRow);
        }

        DOM.reportParameters.focus();
    }

    function addReportFilterToTable() {

        var table = DOM.reportFilters;

        var tableBody = table.tBodies[0];


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

        loadFilterOptions();

        var currentDate = new Date();

        DOM.reportCriteria1.value = moment(currentDate).format("DD/MMM/YYYY");
        DOM.reportCriteria2.value = moment(currentDate).format("DD/MMM/YYYY");

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

            bindReportParameters();

            var tableHeader = createTableHeader(ReportData, excludeListOfTableHeaders);

            var tableBody = createTableBody(ReportData, excludeListOfTableHeaders);

            DOM.reportDataList.appendChild(tableHeader);

            DOM.reportDataList.appendChild(tableBody);
        }
    }

    function getReportData() {

        shared.showLoader(DOM.loader);

        var reportParameter = {};

        reportParameter = {
            FromDate: DOM.reportCriteria1.value,
            ToDate: DOM.reportCriteria2.value,
            UserId: null            
        };

        try {

            var table = DOM.reportCriteriaList;

            var tableBody = table.tBodies[0];

            var tableRows = tableBody.children;

            if (tableRows.length) {

                for (var tr = 0; tr < tableRows.length; tr++) {

                    var parameterName = tableRows[tr].children[0].textContent;
                    var parameterValue = tableRows[tr].getAttribute('data-parameter-value');
                    var criteriaValue = tableRows[tr].children[2].textContent;
                    var criteriaIndex = criteriaValue.toLowerCase().indexOf('and');
                    
                    if (parameterValue.toLowerCase() === "PurchaseBillDate") {
                        reportParameter["FromDate"] = criteriaValue.substring(0, criteriaIndex - 1);
                        reportParameter["ToDate"] = criteriaValue.substring(criteriaIndex + 4);
                    }
                    else {
                         reportParameter[parameterValue] = criteriaValue;
                    }
                }            
            }

            var postData = JSON.stringify(reportParameter);

            var url = "GetPurchaseBillsDetails";

            shared.sendRequest(SERVICE_PATH + url, "POST", true, "JSON", postData, function (response) {

                shared.showLoader(DOM.loader);

                if (response.status === 200) {

                    if (response.responseText !== undefined) {

                        var res = JSON.parse(response.responseText);

                        if (res !== undefined) {

                            if (res.length > 0) {

                                ReportData = res;

                                bindReportData();
                            }
                            else {
                                swal("Error", "No Records Found.", "error");
                            }
                        }
                        else {
                            swal("Error", "No Records Found.", "error");
                        }
                    }

                    shared.hideLoader(DOM.loader);
                }
                else {
                    swal("Error", "Error while fetching the records.", "error");
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
        tab = DOM.reportDataList; // id of table

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
        applyPlugins();
        bindEvents();
        loadData();
    }

    return {
        init: init
    };

}());


SharpiTech.PurchaseDailyActivity.init();
