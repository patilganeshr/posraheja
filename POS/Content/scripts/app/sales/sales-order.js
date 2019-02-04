
var SharpiTech = {};

SharpiTech.SalesOrder = (function () {

    //placeholder for cached DOM elements
    var DOM = {};

    var shared = new Shared();

    var SalesOrders = [];
    var SalesOrderItems = [];
    var GSTApplicable = "IGST";
    var CurrentFocus = -1;
    var ItemList = [];
    var CustomerList = [];

    /* ---- private method ---- */
    //cache DOM elements
    function cacheDOM() {

        DOM.loader = document.getElementById('Loader');
        DOM.editMode = document.getElementById('EditMode');

        DOM.financialYear = document.getElementById('FinancialYear');        
        DOM.companyName = document.getElementById('CompanyName');
        DOM.branch = document.getElementById('Branch');
        DOM.salesOrderNo = document.getElementById('SalesOrderNo');
        DOM.salesOrderDatePicker = document.getElementById('SalesOrderDatePicker');
        DOM.salesOrderDate = document.getElementById('SalesOrderDate');
        
        DOM.customerName = document.getElementById('CustomerName');
        DOM.customerAddress = document.getElementById('CustomerAddress');
        DOM.customerEmail = document.getElementById('CustomerEmail');
        DOM.customerContactNo = document.getElementById('CustomerContactNo');
        DOM.customerGSTNo = document.getElementById('CustomerGSTNo');
        DOM.customerList = document.getElementById('CustomerList');

        DOM.IsTaxInclusive = document.getElementsByName('IsTaxInclusive');
        DOM.taxInclusive = document.getElementById('TaxInclusive');
        DOM.taxExclusive = document.getElementById('TaxExclusive');
        DOM.scanItem = document.getElementById('ScanItem');
        DOM.itemList = document.getElementById('ItemList');
        DOM.salesOrderItemsList = document.getElementById('SalesOrderItemsList');
        DOM.itemsTotalSummary = document.getElementById('ItemsTotalSummary');

        DOM.orderRemarks = document.getElementById('OrderRemarks');
        DOM.uploadDocument = document.getElementById('UploadDocument');

        //DOM.orderNo = document.getElementById('OrderNo');
        //DOM.orderDate = document.getElementById('OrderDate');
        //DOM.orderDatePicker = document.getElementById('OrderDatePicker');

        DOM.saveSalesOrder = document.getElementById('SaveSalesOrder');
        DOM.sendMail = document.getElementById('SendMail');

        /* Jquery cache */
        DOM.$salesOrderDatePicker = $('#SalesOrderDatePicker');

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

        DOM.$salesOrderDatePicker.datetimepicker({
            format: 'DD/MMM/YYYY',
            defaultDate: moment(currentDate).format("DD/MMM/YYYY")
        });
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

        //DOM.saveSalesOrder.addEventListener('click', saveSalesOrder);

        DOM.customerName.onkeyup = function (e) {
            //getKey(e.keyCode);

            if (CurrentFocus === undefined) { CurrentFocus = -1; }
            //if (e.keyCode === 8 || e.keyCode === 127) {
            //    DOM.itemName.value = "";                
            //}
            //setTimeout(function () {
            getCustomerList(e);
            //}, 1000);            

        };

        DOM.companyName.onchange = function () {
            getBranchName(1);
        };

        DOM.customerName.onchange = function () {
            getGSTApplicable();
        };

        DOM.scanItem.onkeyup = function (e) {

            if (CurrentFocus === undefined) { CurrentFocus = -1; }

            getItemsList(e);
        };

        //DOM.qtyInPcs.onkeydown = function validate(e) {
        //    return shared.acceptDecimalNos(e);
        //};

        //DOM.qtyInMtrs.onkeydown = function validate(e) {
        //    return shared.acceptDecimalNos(e);
        //};

        //DOM.rate.onkeydown = function validate(e) {
        //    return shared.acceptDecimalNos(e);
        //};

        //DOM.qtyInPcs.onblur = function () {
        //    calculateItemAmount();
        //}

        //DOM.rate.onblur = function () {
        //    calculateItemAmount();
        //}

    }

    function createNewSalesOrder() {

        //clear the modal control inputs        
        shared.clearInputs(DOM.editMode);

        DOM.salesOrderItemsList.tBodies[0].innerHTML = "";

        SalesOrders.length = 0;
        SalesOrderItems.length = 0;

        shared.disableControls(DOM.editMode, false);

        DOM.salesOrderNo.setAttribute('data-sales-order-id', parseInt(0));

        DOM.salesOrderNo.value = parseInt(0);

        var currentDate = new Date();
        
        DOM.salesOrderDate.value = moment(currentDate).format("DD/MMM/YYYY");

        toggleModes("block", "none");

        DOM.customerName.focus();
    }

    function loadData() {

        createNewSalesOrder();

        getFinancialYear();

        getCompanyName();
        
    }

    function getMaxSrNo(data, maxSrNo) {

        var _maxSrNo = maxSrNo;

        if (data.length > 0) {

            for (var s = 0; s < data.length; s++) {

                if (data[s].SrNo >= _maxSrNo) {
                    _maxSrNo = data[s].SrNo;
                }
            }
        }

        return _maxSrNo += 1;
    }

    function getFinancialYear() {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetAllWorkingPeriods', DOM.financialYear, "FinancialYear", "WorkingPeriodId", "Choose Year", function (response) {

            if (response.status === 200) {

                shared.showLoader(DOM.loader);

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.financialYear, parseInt(1));
                    shared.setSelect2ControlsText(DOM.financialYear);
                }
            }

            shared.hideLoader(DOM.loader);
        });
    }

    function getCompanyName(branchId) {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetAllCompanies', DOM.companyName, "CompanyName", "CompanyId", "Choose Company", function (response) {

            if (response.status === 200) {

                shared.showLoader(DOM.loader);

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.companyName, parseInt(1));
                    shared.setSelect2ControlsText(DOM.companyName);

                    getBranchName(branchId);
                }
            }

            shared.hideLoader(DOM.loader);
        });
    }

    function getBranchName(branchId) {

        DOM.branch.options.length = 0;

        var companyId = 0;

        if (DOM.companyName.selectedIndex > 0) {
            companyId = parseInt(DOM.companyName.options[DOM.companyName.selectedIndex].value);
        }

        if (isNaN(companyId)) { companyId = parseInt(0); }

        if (companyId > 0) {

            shared.fillDropdownWithCallback(SERVICE_PATH + 'GetBranchesByCompanyId/' + companyId, DOM.branch, "BranchName", "BranchId", "Choose Branch", function (response) {

                if (response.status === 200) {

                    shared.showLoader(DOM.loader);

                    if (response.responseText !== undefined) {

                        if (branchId > 0) {
                            shared.setSelectValue(DOM.branch, null, branchId);
                            shared.setSelect2ControlsText(DOM.branch);
                        }
                        else {
                            shared.setSelectOptionByIndex(DOM.branch, parseInt(1));
                            shared.setSelect2ControlsText(DOM.branch);
                        }

                        shared.hideLoader(DOM.loader);
                    }
                }
            });
        }
    }

    function getCustomerList(e) {

        if (e.keyCode === 13) {
            CurrentFocus = -1;
            showCustomerNameOnEnterKey(e);
            return;
        }

        var dataAttributes = ['Client-Address-Id', 'Client-Address-Name'];

        var parameters = {};

        parameters = {

            Event: e,
            CurrentFocus: CurrentFocus,
            PostDataKeyValue: postMessage,
            ElementToBeAppend: DOM.customerList,
            DataAttributes: dataAttributes,
            PostParamObject: undefined,
            URL: SERVICE_PATH + "SearchClientAddressNameByClientAddressName/" + DOM.customerName.value + "/",
            DisplayName: "ClientAddressName"
        };

        shared.showAutoCompleteItemsList(parameters, function (response) {
            //e, CurrentFocus, undefined, DOM.customerList, CustomerList, , function (response) {

            if (response !== undefined) {

                if (response >= 0) {

                    CurrentFocus = response;
                }
                else {
                                        
                    CurrentFocus = -1;

                    var autoCompleteList = response;

                    var listCount = autoCompleteList.length;

                    if (listCount) {

                        var data = "";

                        var fragment = document.createDocumentFragment();

                        var ul = document.createElement('ul');

                        ul.classList.add('list-group');

                        for (var s = 0; s < listCount; s++) {

                            var li = document.createElement('li');

                            li.classList.add('list-group-item');
                            li.classList.add('clearfix');

                            li.setAttribute('id', autoCompleteList[s].ClientAddressId);

                            li.style.cursor = "pointer";
                            li.onclick = showCustomerNameOnSelection;
                            li.textContent = autoCompleteList[s].ClientAddressName;

                            fragment.appendChild(li);
                        }

                        ul.appendChild(fragment);

                        DOM.customerList.appendChild(ul);

                        DOM.customerList.style.width = e.target.offsetWidth + 'px';
                        DOM.customerList.style.left = 0;//e.target.offsetParent.offsetLeft + 15 + 'px';

                        DOM.customerList.classList.add('autocompleteList-active');
                        //DOM.itemsList.innerHTML = data;

                    }
                }
            }

        });
    }

    function showCustomerNameOnSelection(e) {

        FLAG = "NEW ITEM";

        DOM.customerName.value = e.target.textContent;
        DOM.customerName.setAttribute('data-client-address-id', e.target.id);

        shared.closeAutoCompleteList(DOM.customerList);

        DOM.customerName.focus();
    }

    function showCustomerNameOnEnterKey() {

        FLAG = "NEW ITEM";
       
        var li = DOM.customerList.querySelectorAll('.autocompleteListItem-active');

        var count = li.length;

        if (count) {

            DOM.customerName.value = li[0].textContent;

            shared.closeAutoCompleteList(DOM.customerList);
        }

        DOM.customerName.focus();
    }

    function getGSTApplicable() {

        var clientAddressId = parseInt(DOM.customerName.getAttribute('data-client-address-id'));

        if (isNaN(clientAddressId)) { clientAddressId = parseInt(0); }

        shared.sendRequest(SERVICE_PATH + "GetGSTApplicable/" + clientAddressId, "GET", true, "JSON", null, function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    var _response = JSON.parse(response.responseText);

                    if (_response.GSTName !== undefined) {

                        GSTApplicable = _response.GSTName;
                    }
                }
            }
        });
    }

    function getItemList(e) {

        if (e.keyCode === 13) {
            CurrentFocus = -1;
            setItemOnEnter();
        }
        
        shared.showAutoCompleteItemsList(e, CurrentFocus, "ItemName", DOM.itemList, ItemList, SERVICE_PATH + "SearchItem/" + DOM.scanItem.value + "/", function (response) {

            if (response !== undefined) {

                if (response >= 0) {

                    CurrentFocus = response;
                }
                else {

                    CurrentFocus = -1;

                    var autoCompleteList = response;

                    var listCount = autoCompleteList.length;

                    if (listCount) {

                        var data = "";

                        var fragment = document.createDocumentFragment();

                        var ul = document.createElement('ul');

                        ul.classList.add('list-group');

                        for (var s = 0; s < listCount; s++) {

                            var li = document.createElement('li');

                            li.classList.add('list-group-item');
                            li.classList.add('clearfix');

                            li.setAttribute('id', items[s].ItemId);
                            li.setAttribute('data-unit-of-measurement-id', items[s].UnitOfMeasurementId);
                            li.setAttribute('data-unit-code', items[s].UnitCode);

                            li.style.cursor = "pointer";
                            li.onclick = setItem;
                            li.textContent = autoCompleteList[s].ItemName;

                            fragment.appendChild(li);
                        }

                        ul.appendChild(fragment);

                        DOM.itemList.appendChild(ul);

                        DOM.itemList.style.width = e.target.offsetWidth + 'px';
                        DOM.itemList.style.left = 0;//e.target.offsetParent.offsetLeft + 15 + 'px';

                        DOM.itemList.classList.add('autocompleteList-active');
                        //DOM.itemsList.innerHTML = data;

                    }
                }
            }

        });
    }
        
    function calculateItemAmount() {

        var itemId = parseInt(DOM.item.options[DOM.item.selectedIndex].value);

        var qtyInPcs = parseFloat(0);
        var saleRate = parseFloat(0);
        var amount = parseFloat(0);
        var gstRate = parseFloat(0);
        var gstAmount = parseFloat(0);
        var totalItemAmount = parseFloat(0);

        qtyInPcs = parseFloat(DOM.qtyInPcs.value);
        saleRate = parseFloat(DOM.rate.value);
        amount = parseFloat(qtyInPcs * saleRate);

        if (qtyInPcs > 0 && saleRate > 0) {

            shared.sendRequest(SERVICE_PATH + "GetGSTRateByItemIdGSTApplicableAndSaleRate/" + itemId + "/" + GSTApplicable + "/" + saleRate, "GET", true, "JSON", null, function (response) {

                if (response.status === 200) {

                    if (response.responseText !== undefined) {

                        var _response = JSON.parse(response.responseText);

                        if (_response.Rate > 0) {

                            gstRate = _response.Rate;

                            DOM.gstRate.setAttribute('data-gst-rate-id', parseInt(_response.GSTRateId));                            
                            DOM.gstRate.setAttribute('data-tax-id', parseInt(_response.TaxId));
                            
                            DOM.gstRate.value = gstRate;

                            var gstExclAmount = parseFloat(parseFloat(parseFloat(amount * 100) / (gstRate + 100)).toFixed(2));

                            DOM.amount.value = gstExclAmount;

                            gstAmount = parseFloat(parseFloat(gstExclAmount * (gstRate / 100)).toFixed(2));
                            
                            DOM.gstAmount.value = gstAmount;

                            totalItemAmount = parseFloat(parseFloat(gstExclAmount + gstAmount).toFixed(2));

                            DOM.totalItemAmount.value = totalItemAmount;
                        }
                    }
                }
            });
        }

    }
    
    //function saveSalesOrder() {

    //    var salesOrderId = parseInt(0);
    //    var salesOrderNo = parseInt(0);
    //    var salesOrderDate = null;
    //    var customerId = parseInt(0);
    //    var branchId = parseInt(0);
    //    var workingPeriodId = parseInt(0);

    //    salesOrderId = DOM.orderNo.getAttribute('data-sales-order-id');
    //    salesOrderNo = parseInt(DOM.orderNo.value);
    //    salesOrderDate = DOM.orderDate.value;
    //    customerId = parseInt(DOM.customer.options[DOM.customer.selectedIndex].value);
    //    branchId = parseInt(DOM.branch.options[DOM.branch.selectedIndex].value);
    //    workingPeriodId = parseInt(DOM.financialYear.options[DOM.financialYear.selectedIndex].value);

    //    if (salesOrderId === null) { salesOrderId = parseInt(0); }

    //    if (isNaN(salesOrderId)) { salesOrderId = parseInt(0); }

    //    var salesOrder = {};

    //    salesOrder = {
    //        SalesOrderId: salesOrderId,
    //        SalesOrderNo: salesOrderNo,
    //        SalesOrderDate: salesOrderDate,
    //        CustomerId: customerId,
    //        BranchId: branchId,
    //        WorkingPeriodId: workingPeriodId,
    //        SalesOrderItems: SalesOrderItems,
    //        IsDeleted: false            
    //    };

    //    if (parseInt(salesOrderId) === parseInt(0)) {

    //        salesOrder.CreatedBy = LOGGED_USER;
    //        salesOrder.CreatedByIp = IP_ADDRESS;
    //    }
    //    else {
    //        salesOrder.ModifiedBy = LOGGED_USER;
    //        salesOrder.ModifiedByIp = IP_ADDRESS;
    //    }

    //    SalesOrders.push(salesOrder);

    //    var postData = JSON.stringify(SalesOrders);

    //    shared.sendRequest(SERVICE_PATH + "SaveSalesOrder", "POST", true, "JSON", postData, function (response) {

    //        var _response = JSON.parse(response.responseText);

    //        if (response.status === 200) {
    //            if (parseInt(response.responseText) > parseInt(0)) {
    //                getSalesOrders();
    //            }
    //        }
    //        else {
    //            swal("error", "Unable to save the Sales Order Details. Error as " + _response.Message + " " + _response.ExceptionMessage, "error");
    //            handleError(_response.Message + " " + _response.ExceptionMessage);
    //            SalesOrders = [];
    //        }
    //    });
    //}

    function toggleModes(editModeDisplay, viewModeDisplay) {

        DOM.editMode.style.display = editModeDisplay;
        //DOM.viewMode.style.display = viewModeDisplay;
    }

    
    /* ---- public methods ---- */
    function init() {
        cacheDOM();
        bindEvents();
        applyPlugins();
        loadData();
        //getSalesOrders();
    }

    return {
        init: init
    };

}());


SharpiTech.SalesOrder.init();
