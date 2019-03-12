var SharpiTech = {};

SharpiTech.PurchaseOrder = (function () {

    //placeholder for cached DOM elements
    var DOM = {};

    var shared = new Shared();

    var PURCHASE_ORDER = {};
    var PURCHASE_ORDER_ITEMS = [];
    var UNIT_OF_MEASUREMENTS = [];
    var SEARCH_ITEMS_LIST = [];
    var CURRENT_FOCUS = -1;
    

    function cacheDOM() {

        DOM.loader = document.getElementById('Loader');
        DOM.financialYear = document.getElementById('FinancialYear');
        DOM.companyName = document.getElementById('CompanyName');
        DOM.branch = document.getElementById('Branch');
        DOM.purchaseOrderNo = document.getElementById('PurchaseOrderNo');
        DOM.purchaseOrderDate = document.getElementById('PurchaseOrderDate');
        DOM.purchaseOrderDateDatePicker = document.getElementById('PurchaseOrderDateDatePicker');
        DOM.vendor = document.getElementById('Vendor');
        DOM.addNewVendor = document.getElementById('AddNewVendor');
        DOM.refreshVendorList = document.getElementById('RefreshVendorList');
        DOM.paymentTerms = document.getElementById('PaymentTerms');
        DOM.NoOfDaysForPayment = document.getElementById('NoOfDaysForPayment');
        DOM.discountRate = document.getElementById('DiscountRate');
        DOM.paymentDays = document.getElementById('PaymentDays');
        DOM.expectedDeliveryDate = document.getElementById('ExpectedDeliveryDate');

        DOM.searchItemName = document.getElementById('SearchItemName');
        DOM.itemsList = document.getElementById('ItemsList');
        DOM.purchaseOrderItemsList = document.getElementById('PurchaseOrderItemsList');
        DOM.itemsTotalSummary = document.getElementById('ItemsTotalSummary');
        DOM.orderRemarks = document.getElementById('OrderRemarks');

        DOM.addNewPurchaseOrder = document.getElementById('AddNewPurchaseOrder');
        DOM.showPurchaseOrderList = document.getElementById('ShowPurchaseOrderList');
        DOM.viewPurchaseOrder = document.getElementById('ViewPurchaseOrder');
        DOM.editPurchaseOrder = document.getElementById('EditPurchaseOrder');
        DOM.savePurchaseOrder = document.getElementById('SavePurchaseOrder');
        DOM.deletePurchaseOrder = document.getElementById('DeletePurchaseOrder');
        DOM.sendMail = document.getElementById('SendMail');
        DOM.printPurchasesOrder = document.getElementById('PrintPurchasesOrder');
        
        /*cache the jquery element */
        DOM.$purchaseOrderDateDatePicker = $('#PurchaseOrderDateDatePicker');
        DOM.expectedDeliveryDateDatePicker = $('#ExpectedDeliveryDateDatePicker');

    }

    function applyPlugins() {

        $('select').select2();

        var currentDate = new Date();

        var deliveryDate = new Date() + 30;

        DOM.$purchaseOrderDatePicker.datetimepicker({
            format: 'DD/MMM/YYYY',
            defaultDate: moment(currentDate).format("DD/MMM/YYYY")
        });

        DOM.$ExpectedDeliveryDateDatePicker.datetimepicker({
            format: 'DD/MMM/YYYY',
            defaultDate: moment(deliveryDate).format("DD/MMM/YYYY")
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

        /* ---- handle errors ---- */
    function handleError(err) {
        console.log('Application Error: ' + err);
    }


    function bindEvents() {

        //DOM.searchByPurchaseBillNoButton.addEventListener('click', getPurchaseBillDetailsByPurchaseBillNo);

        DOM.addNewPurchaseOrder.addEventListener('click', addNewPurchaseOrder);
        DOM.showPurchaseOrderList.addEventListener('click', showPurchaseOrderList);
        DOM.viewPurchaseOrder.addEventListener('click', viewPurchaseOrder);
        DOM.editPurchaseOrder.addEventListener('click', editPurchaseOrder);
        DOM.savePurchaseOrder.addEventListener('click', savePurchaseOrder);
        DOM.deletePurchaseOrder.addEventListener('click', deletePurchaseOrder);
        DOM.printPurchasesOrder.addEventListener('click', printPurchasesOrder);
        DOM.sendMail.addEventListener('click', sendMail);


        DOM.companyName.onchange = function () {
            getBranchName(1);
        };

        DOM.searchItem.onchange = function () {
            getItemDetailsByItemId();
        };

    }

    function loadData() {

        getFinancialYear();
        getCompany();
        getBranchName();
        getVendor();
        getTransporter();
        getUnitOfMeasurements();
        getCharges();

        addNewPurchaseBill();
    }

    function getFinancialYear() {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetAllWorkingPeriods', DOM.financialYear, "FinancialYear", "WorkingPeriodId", "Choose Year", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.financialYear, parseInt(1));
                    shared.setSelect2ControlsText(DOM.financialYear);

                    //DOM.searchByFinancialYear.innerHTML = DOM.searchByFinancialYear.innerHTML + DOM.financialYear.innerHTML;
                }
            }
        });

        //shared.hideLoader(DOM.loader);
    }

    function getCompany() {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetAllCompanies', DOM.companyName, "CompanyName", "CompanyId", "Choose Company", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.companyName, parseInt(1));
                    shared.setSelect2ControlsText(DOM.companyName);

                    getBranchName(0);
                }
            }
        });

        //shared.hideLoader(DOM.loader);
    }

    function getBranchName(branchId) {

        shared.showLoader(DOM.loader);

        DOM.branch.options.length = 0;

        if (DOM.companyName.selectedIndex > 0) {

            var companyId = parseInt(DOM.companyName.options[DOM.companyName.selectedIndex].value);

            if (isNaN(companyId)) { companyId = parseInt(0); }

            if (companyId > 0) {

                shared.fillDropdownWithCallback(SERVICE_PATH + 'GetBranchesByCompanyId/' + companyId, DOM.branch, "BranchName", "BranchId", "Choose Branch", function (response) {

                    if (response.status === 200) {

                        if (response.responseText !== undefined) {

                            if (branchId > 0) {
                                shared.setSelectValue(DOM.branch, null, branchId);
                                shared.setSelect2ControlsText(DOM.branch);
                            }
                            else {
                                shared.setSelectOptionByIndex(DOM.branch, parseInt(1));
                                shared.setSelect2ControlsText(DOM.branch);
                            }
                        }
                    }
                });
            }
        }

        shared.hideLoader(DOM.loader);
    }

    function getVendor() {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetClientAddressNamesByClientTypeId/2', DOM.vendor, "ClientAddressName", "ClientAddressId", "Choose Vendor", function (response) {
            if (response.status === 200) {
                shared.setSelectOptionByIndex(DOM.vendor, parseInt(1));
                shared.setSelect2ControlsText(DOM.vendor);

                DOM.searchByVendor.innerHTML = DOM.searchByVendor.innerHTML + DOM.vendor.innerHTML;
            }
        });

        //shared.showLoader(DOM.loader);
    }

    function getUnitOfMeasurements() {

        shared.showLoader(DOM.loader);

        UNIT_OF_MEASUREMENTS.length = 0;

        shared.sendRequest(SERVICE_PATH + "GetAllUnitsOfMeasurement", "GET", true, "JSON", null, function (response) {

            if (response.status === 200) {

                var res = JSON.parse(response.responseText);

                UNIT_OF_MEASUREMENTS = res;
            }
        });

        shared.hideLoader(DOM.loader);
    }

    var getSelectedRows = function (element) {

        shared.showLoader(DOM.loader);

        var selectedRows = [];

        var tableBody = element.tBodies[0];

        var tableRows = tableBody.children;

        if (tableRows.length > 0) {

            for (var tr = 0; tr < tableRows.length; tr++) {

                var checkBox = tableRows[tr].querySelectorAll('.label-checkbox')[0];

                if (checkBox.checked) {

                    selectedRows.push(tableRows[tr]);
                }
            }
        }

        shared.hideLoader(DOM.loader);

        return selectedRows;
    };


    function showItemsList(e, element) {

        elementName = element;

        if (element.value === "") {
            CURRENT_FOCUS = -1;
            closeAutoCompleteList();
            return;
        }

        if (e.keyCode === 40) {
            CURRENT_FOCUS++;
            addActive(e);
        }
        else if (e.keyCode === 38) {
            CURRENT_FOCUS--;
            addActive(e);
        }
        else if (e.keyCode === 13) {
            CURRENT_FOCUS = -1;
            setItemOnEnter(element);
        }
        else {

            SEARCH_ITEMS_LIST.length = 0;

            closeAutoCompleteList();

            var item = {};

            item = {
                ItemName: DOM.searchItemName.value
            };

            var postData = JSON.stringify(item);

            shared.sendRequest(SERVICE_PATH + "SearchItem/", "POST", true, "JSON", postData, function (response) {

                shared.showLoader(DOM.loader);

                if (response.status === 200) {

                    SEARCH_ITEMS_LIST = JSON.parse(response.responseText);

                    var itemsCount = SEARCH_ITEMS_LIST.length;

                    if (itemsCount) {

                        var data = "";

                        var fragment = document.createDocumentFragment();

                        var ul = document.createElement('ul');

                        ul.classList.add('list-group');

                        for (var s = 0; s < itemsCount; s++) {

                            var li = document.createElement('li');

                            li.classList.add('list-group-item');
                            li.classList.add('clearfix');

                            li.setAttribute('id', SEARCH_ITEMS_LIST[s].ItemId);
                            li.setAttribute('data-unit-of-measurement-id', SEARCH_ITEMS_LIST[s].UnitOfMeasurementId);
                            li.setAttribute('data-unit-code', SEARCH_ITEMS_LIST[s].UnitCode);

                            li.style.cursor = "pointer";
                            li.onclick = setItem;
                            li.textContent = SEARCH_ITEMS_LIST[s].ItemName;

                            fragment.appendChild(li);

                            //data = data + "<li class='list-group-item clearfix'" +
                            //    "data-item-id=" + itemsList[s].ItemId + " data-unit-of-measurement-id=" + itemsList[s].UnitOfMeasurementId +
                            //    "style='padding:0px;'> <label class='label-tick'>" +
                            //    "<input type='checkbox' class='label-checkbox' id=Item_" + itemsList[s].ItemId + " checked='false' />" +
                            //    "<span class='label-text'></span> </label>" + itemsList[s].ItemName + "</li>";
                        }

                        ul.appendChild(fragment);

                        DOM.itemsList.appendChild(ul);

                        DOM.itemsList.style.width = element.offsetWidth + 'px';
                        DOM.itemsList.style.left = element.offsetParent.offsetLeft + 15 + 'px';

                        DOM.itemsList.classList.add('autocompleteList-active');
                        //DOM.itemsList.innerHTML = data;
                    }

                }

                shared.hideLoader(DOM.loader);

            });

        }
    }

    function addActive(e) {

        removeActive();

        var li = DOM.itemsList.querySelectorAll('li');

        var count = li.length;

        if (CURRENT_FOCUS >= count) {
            CURRENT_FOCUS = 0;
        }

        if (CURRENT_FOCUS < 0) {
            CURRENT_FOCUS = count - 1;
        }

        li[CURRENT_FOCUS].classList.add('autocompleteListItem-active');

    }

    function removeActive() {

        var li = DOM.itemsList.querySelectorAll('li');

        var count = li.length;

        if (count) {

            for (var l = 0; l < count; l++) {

                li[l].classList.remove('autocompleteListItem-active');
            }
        }

    }

    function setItem(e) {

        FLAG = "NEW ITEM";

        var element = elementName;

        element.value = e.target.textContent;

        closeAutoCompleteList();

        var itemId = e.target.id;
        var itemName = e.target.textContent;
        var unitCode = e.target.getAttribute('data-unit-code');
        var unitOfMeasurementId = e.target.getAttribute('data-unit-of-measurement-id');

        bindItemDetails(itemId, itemName, unitCode, unitOfMeasurementId);

        element.value = "";
    }

    function setItemOnEnter(element) {

        FLAG = "NEW ITEM";

        var li = DOM.itemsList.querySelectorAll('.autocompleteListItem-active');

        var count = li.length;

        if (count) {

            element.value = li[0].textContent;

            closeAutoCompleteList();
        }

        var itemId = li[0].id;
        var itemName = li[0].textContent;
        var unitCode = li[0].getAttribute('data-unit-code');
        var unitOfMeasurementId = li[0].getAttribute('data-unit-of-measurement-id');

        bindItemDetails(itemId, itemName, unitCode, unitOfMeasurementId);

        element.value = "";
    }

    function closeAutoCompleteList() {

        DOM.itemsList.classList.remove('autocompleteList-active');

        var ul = DOM.itemsList.querySelectorAll('ul');

        while (ul.firstChild) {
            ul.removeChild(ul.firstChild);
        }

        while (DOM.itemsList.firstChild) {
            DOM.itemsList.removeChild(DOM.itemsList.firstChild);
        }

    }

    function addRowsToItemsList(item) {

        var table = DOM.purchaseOrderItemsList;

        var tableBody = table.tBodies[0];

        //var tableRows = tableBody.children;

        //var rowsCount = tableBody.children.length;

        var tableRow = document.createElement('tr');
                     
        var tableCell = document.createElement('td');

        tableRow.setAttribute('data-item-id', item.ItemId);

        tableCell.innerHTML = "<input type='text' class='form-control input-md' id='ItemName_" + item.ItemId + "' />";

                data = data + "<tr data-item-id=" + item.ItemId + " >";
                data = data + "<td> <input type='text' class='form-control input-md' id='ItemName_" + item.ItemId + "' /> </td>";
                data = data + "<td> <input type='text' class='form-control input-md' id='NoOfBales_" + item.ItemId + "' /> </td>";
                data = data + "<td> <input type='text' class='form-control input-md' id='OrderQty_" + item.ItemId + "' /> </td>";
                data = data + "<td> <select class='form-control input-md' id='UoM_" + item.ItemId + "' /> </td>";
                data = data + "<td> <input type='text' class='form-control input-md' id='OrderRate_" + item.ItemId + "' /> </td>";
                data = data + "<td> <input type='text' class='form-control input-md' id='Discount_" + item.ItemId + "' /> </td>";
                data = data + "<td> <input type='text' class='form-control input-md' id='ItemTotal_" + item.ItemId  + "' /> </td>";
                data = data + "</tr>";

            

            tableBody.innerHTML = data;

    }

    var createTableRow = function () {

        return document.createElement('tr');
    };


    var createTableCell = function () {
        return document.createElement('td');
    }

    var createElement = function (typeOfElement, id, name, cssClass, dataAttributes) {

        var element = document.createElement(typeOfElement);

        element.setAttribute('id', id);
        element.setAttribute('name', name);

        if (cssClass !== null) {
            element.classList.add(cssClass);
        }

        if (dataAttributes.length) {

            for (var d = 0; d < dataAttributes.lenght; d++) {

                element.setAttribute('data-' + dataAttributes[d], dataAttributes[d][0]);
            }
        }
    };
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

SharpiTech.PurchaseOrder.init();
