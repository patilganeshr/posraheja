
var SharpiTech = {};

SharpiTech.SalesOrder = (function () {

    //placeholder for cached DOM elements
    var DOM = {};

    var shared = new Shared();

    var SalesOrders = [];
    var SalesOrderItems = [];
    var GSTApplicable = "IGST";
    
    /* ---- private method ---- */
    //cache DOM elements
    function cacheDOM() {

        DOM.editMode = document.getElementById('EditMode');
        DOM.branch = document.getElementById('Branch');
        DOM.customer = document.getElementById('Customer');
        DOM.financialYear = document.getElementById('FinancialYear');
        DOM.orderNo = document.getElementById('OrderNo');
        DOM.orderDate = document.getElementById('OrderDate');
        DOM.orderDatePicker = document.getElementById('OrderDatePicker');
        DOM.addNewItem = document.getElementById('AddNewItem');
        DOM.orderItems = document.getElementById('OrderItems');
        DOM.backToSalesOrdersList = document.getElementById('BackToSalesOrdersList');
        DOM.saveSalesOrder = document.getElementById('SaveSalesOrder');
        DOM.viewMode = document.getElementById('ViewMode');        
        DOM.createNewSalesOrder = document.getElementById('CreateNewSalesOrder');
        DOM.salesOrders = document.getElementById('SalesOrders');
        DOM.orderItemModal = document.getElementById('OrderItemsModal');
        DOM.item = document.getElementById('Item');
        DOM.qtyInPcs = document.getElementById('QtyInPcs');
        DOM.qtyInMtrs = document.getElementById('QtyInMtrs');
        DOM.units = document.getElementById('Units');
        DOM.rate = document.getElementById('Rate');
        DOM.amount = document.getElementById('Amount');
        DOM.gstRate = document.getElementById('GSTRate');
        DOM.gstAmount = document.getElementById('GSTAmount');
        DOM.totalItemAmount = document.getElementById('TotalItemAmount');
        DOM.backToOrderItemsList = document.getElementById('BackToOrderItemsList');
        DOM.saveOrderItem = document.getElementById('SaveOrderItem');
        DOM.saveAndAddItem = document.getElementById('SaveAndAddNewItem');
        DOM.hiddenSrNo = document.getElementById('SrNo');
        DOM.hiddenSalesOrderItemId = document.getElementById('SalesOrderItemId');

        /* Jquery cache */
        DOM.$orderItemModal = $('#OrderItemsModal');
        DOM.$orderDatePicker = $('#OrderDatePicker');

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

        DOM.$orderDatePicker.datetimepicker({
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

        DOM.addNewItem.addEventListener('click', addNewItem);
        DOM.backToOrderItemsList.addEventListener('click', backToOrderItemsList);
        DOM.saveOrderItem.addEventListener('click', saveOrderItem);
        DOM.saveAndAddItem.addEventListener('click', saveAndAddNewItem);
        DOM.orderItems.addEventListener('click', orderItems);
        DOM.createNewSalesOrder.addEventListener('click', createNewSalesOrder);
        DOM.saveSalesOrder.addEventListener('click', saveSalesOrder);
        DOM.backToSalesOrdersList.addEventListener('click', backToSalesOrdersList);
        DOM.salesOrders.addEventListener('click', salesOrders);

        DOM.customer.onchange = function () {
            getGSTApplicable();
        }

        DOM.qtyInPcs.onkeydown = function validate(e) {
            return shared.acceptDecimalNos(e);
        };

        DOM.qtyInMtrs.onkeydown = function validate(e) {
            return shared.acceptDecimalNos(e);
        };

        DOM.rate.onkeydown = function validate(e) {
            return shared.acceptDecimalNos(e);
        };

        DOM.qtyInPcs.onblur = function () {
            calculateItemAmount();
        }

        DOM.rate.onblur = function () {
            calculateItemAmount();
        }

    }

    function createNewSalesOrder() {

        //clear the modal control inputs        
        shared.clearInputs(DOM.editMode);

        DOM.orderItems.tBodies[0].innerHTML = "";

        SalesOrders = [];
        SalesOrderItems = [];

        shared.disableControls(DOM.editMode, false);

        DOM.orderNo.setAttribute('data-sales-order-id', parseInt(0));

        DOM.orderNo.value = parseInt(0);

        var currentDate = new Date();
        
        DOM.orderDate.value = moment(currentDate).format("DD/MMM/YYYY");

        toggleModes("block", "none");

        DOM.customer.focus();
    }

    function backToSalesOrdersList() {

        getSalesOrders();

        toggleModes("none", "block");
    }

    function viewSalesOrder(currentTableRow) {

        shared.clearInputs(DOM.editMode);

        shared.disableControls(DOM.editMode, true);

        showSelectedOrderDetails(currentTableRow);
    }

    function editSalesOrder(currentTableRow) {

        shared.clearInputs(DOM.editMode);

        shared.disableControls(DOM.editMode, false);

        showSelectedGattaDetails(currentTableRow);
    }

    function deleteSalesOrder(currentTableRow) {

        var table = DOM.salesOrders;

        var tableBody = table.tBodies[0];
        
        /* temp variable */
        var salesOrderId = currentTableRow.getAttribute('data-sales-order-id');
        
        var salesOrder = {};

        salesOrder = {
            SalesOrderId: salesOrderId,
            DeletedBy: LOGGED_USER,
            DeletedByIp: IP_ADDRESS
        };

        var postData = JSON.stringify(salesOrder);
        
        shared.sendRequest(SERVICE_PATH + 'DeleteSalesOrder', "POST", true, "JSON", postData, function (response) {
            if (response.status === 200) {
                if (response.responseText === "true") {
                    tableBody.removeChild(currentTableRow);
                }
            }
        });
    }

    function salesOrders(evt) {

        var element = evt.target;

        var currentTableRow;

        if (element.nodeName === 'I') {
            currentTableRow = element.parentElement.parentElement.parentElement;
        }
        else if (element.nodeName === 'A') {
            currentTableRow = element.parentElement.parentElement;
        }

        if (element.getAttribute('data-name').trim().toUpperCase() === "VIEW") {
            viewSalesOrder(currentTableRow);
        }
        else if (element.getAttribute('data-name').trim().toUpperCase() === "EDIT") {
            editSalesOrder(currentTableRow);
        }
        else if (element.getAttribute('data-name').trim().toUpperCase() === "REMOVE") {
            deleteSalesOrder(currentTableRow);
        }
    }

    function showSelectedOrderDetails(currentTableRow) {

        var salesOrderId = parseInt(currentTableRow.getAttribute('data-sales-order-id'));

        if (salesOrders.length > 0) {

            var salesOrder = SalesOrders.filter(function (value, index, array) {
                return value.SalesOrderId === salesOrderId;
            });

            var itemsCount = salesOrder.length;

            if (itemsCount > 0) {

                DOM.orderNo.value = salesOrder[0].SalesOrderNo;
                DOM.orderNo.setAttribute('data-sales-order-id', parseInt(salesOrder[0].SalesOrderId));
                DOM.orderDate.value = salesOrder[0].SalesOrderDate;
                shared.setSelectValue(DOM.customer, null, parseInt(salesOrder[0].CustomerId));
                shared.setSelect2ControlsText(DOM.customer);                
                shared.setSelectValue(DOM.branch, null, parseInt(salesOrder[0].BranchId));
                shared.setSelect2ControlsText(DOM.branch);
            }
        }
    
        bindSalesOrderItem(salesOrderId);

        toggleModes("block", "none");
    }

    function addNewItem() {

        shared.clearInputs(DOM.orderItemModal);

        DOM.qtyInPcs.value = parseFloat(0);
        DOM.qtyInMtrs.value = parseFloat(0);
        DOM.rate.value = parseFloat(0);
        DOM.amount.value = parseFloat(0);
        DOM.gstRate.value = parseFloat(0);
        DOM.gstAmount.value = parseFloat(0);
        DOM.totalItemAmount.value = parseFloat(0);
        DOM.hiddenSrNo.value = parseInt(0);
        DOM.hiddenSalesOrderItemId.value = parseInt(0);

        //DOM.hiddenSalesOrderItemId.setAttribute('data-sales-order-item-id', parseInt(0));
        
        //show modal
        DOM.$orderItemModal.modal('show');

        //set focus
        setFocus();
    }

    function setFocus() {
        DOM.$orderItemModal.on('shown.bs.modal', function () {
            DOM.item.focus();
        });
    }

    function backToOrderItemsList() {

        DOM.$orderItemModal.modal('hide');
    }

    function bindSalesOrderItem(salesOrderId) {

        var table = DOM.orderItems;

        var tableBody = table.tBodies[0];

        tableBody.innerHTML = "";

        if (isNaN(salesOrderId)) { salesOrderId = parseInt(0); }

        if (SalesOrderItems.length > 0) {

            var salesOrderItem = SalesOrderItems.filter(function (value, index, array) {
                return value.SalesOrderId === salesOrderId;
            });

            var itemsCount = salesOrderItem.length;

            if (itemsCount > 0) {

                for (var r = 0; r < itemsCount; r++) {

                    var currentRow = document.createElement('TR');

                    data = "<tr><td>" + salesOrderItem[r].ItemName + "</td>";
                    data += "<td>" + salesOrderItem[r].SaleQtyInPcs + "</td>";
                    data += "<td>" + salesOrderItem[r].SaleQtyInMtrs + "</td>";
                    data += "<td>" + salesOrderItem[r].SaleRate + "</td>";
                    data += "<td>" + salesOrderItem[r].Amount + "</td>";
                    data += "<td>" + salesOrderItem[r].GSTRate + "</td>";
                    data += "<td>" + salesOrderItem[r].GSTAmount + "</td>";                    
                    data += "<td>" + salesOrderItem[r].TotalItemAmount + "</td>";
                    data += "<td class='text-center'>" +
                        "<a href='#' class='btn btn-info btn-xs' data-name='view' > <i class='fa fa-lg fa-eye' data-name='view'></i> view</a> " +
                        "<a href='#' class='btn btn-info btn-xs' data-name='edit'> <i class='fa fa-lg fa-edit' data-name='edit'></i> edit</a> " +
                        "<a href='#' class='btn btn-danger btn-xs' data-name='remove' > <i class='fa fa-lg fa-remove' data-name='remove'></i> delete</a> </td></tr>";

                    currentRow.setAttribute('data-sales-order-item-id', parseInt(salesOrderItem[r].SalesOrderItemId));
                    currentRow.setAttribute('data-sr-no', parseInt(salesOrderItem[r].SrNo));
                    currentRow.innerHTML = data;

                    tableBody.appendChild(currentRow);
                }
            }
        }
    }
    
    function orderItems(evt){

        var element = evt.target;

        var currentTableRow;

        if (element.nodeName === 'I') {
            currentTableRow = element.parentElement.parentElement.parentElement;
        }
        else if (element.nodeName === 'A') {
            currentTableRow = element.parentElement.parentElement;
        }

        if (element.getAttribute('data-name').trim().toUpperCase() === "VIEW") {
            viewSalesOrderItem(currentTableRow);
        }
        else if (element.getAttribute('data-name').trim().toUpperCase() === "EDIT") {
            editSalesOrderItem(currentTableRow);
        }
        else if (element.getAttribute('data-name').trim().toUpperCase() === "REMOVE") {
            deleteSalesOrderItem(currentTableRow);
        }
    }

    function viewSalesOrderItem(currentTableRow) {

        shared.clearInputs(DOM.orderItemModal);

        shared.clearTextAreas(DOM.orderItemModal);

        shared.disableControls(DOM.orderItemModal, true);

        showSelectedOrderItemDetails(currentTableRow);
    }

    function editSalesOrderItem(currentTableRow) {

        shared.clearInputs(DOM.orderItemModal);

        shared.clearTextAreas(DOM.orderItemModal);

        shared.disableControls(DOM.orderItemModal, false);

        DOM.amount.disabled = true;        
        DOM.gstAmount.disabled = true;
        DOM.gstRate.disabled = true;
        DOM.totalItemAmount.disabled = true;

        showSelectedOrderItemDetails(currentTableRow);
    }

    function deleteSalesOrderItem(currentTableRow) {

        var table = DOM.orderItems;

        var tableBody = table.tBodies[0];
        
        /* temp variable */
        var salesOrderItemId = parseInt(currentTableRow.getAttribute('data-sales-order-item-id'));
        
        var salesOrderItem = {};

        salesOrderItem = {
            SalesOrderItemId: salesOrderItemId,
            IsDeleted: true,
            DeletedBy: LOGGED_USER,
            DeletedByIp: IP_ADDRESS
        };

        var postData = JSON.stringify(salesOrderItem);
        
        shared.sendRequest(SERVICE_PATH + 'DeleteSalesOrderItem', "POST", true, "JSON", postData, function (response) {
            if (response.status === 200) {
                if (response.responseText === "true") {
                    tableBody.removeChild(currentTableRow);
                }
            }   
        });
    }

    function saveOrderItem() {

        var salesOrderItemId = parseInt(0);
        var salesOrderId = parseInt(0);
        var itemId = parseInt(0);
        var itemName = null;
        var qtyInPcs = parseFloat(0);
        var qtyInMtrs = parseFloat(0);
        var rate = parseFloat(0);
        var amount = parseFloat(0);
        var gstRate = parseFloat(0);
        var gstAmount = parseFloat(0);
        var totalItemAmount = parseFloat(0);
        var taxId = parseInt(0)
        var gstRateId = parseInt(0);
        var srNo = parseInt(0);

        salesOrderItemId = parseInt(DOM.orderNo.getAttribute('data-sales-order-item-id'));
        salesOrderId = parseInt(DOM.orderNo.getAttribute('data-sales-order-id'));
        itemId = parseInt(DOM.item.options[DOM.item.selectedIndex].value);
        itemName = DOM.item.options[DOM.item.selectedIndex].text;
        qtyInPcs = parseFloat(parseFloat(DOM.qtyInPcs.value).toFixed(2));
        qtyInMtrs = parseFloat(parseFloat(DOM.qtyInMtrs.value).toFixed(2));
        rate = parseFloat(parseFloat(DOM.rate.value).toFixed(2));
        amount = parseFloat(parseFloat(DOM.amount.value).toFixed(2));
        gstRate = parseFloat(parseFloat(DOM.gstRate.value).toFixed(2));
        gstAmount = parseFloat(parseFloat(DOM.gstAmount.value).toFixed(2));
        totalItemAmount = parseFloat(parseFloat(DOM.totalItemAmount.value).toFixed(2));
        taxId = parseInt(DOM.gstRate.getAttribute('data-tax-id'));
        gstRateId = parseInt(DOM.gstRate.getAttribute('data-gst-rate-id'));

        if (parseInt(DOM.hiddenSrNo.value) === 0) {
            srNo = getMaxSrNo(SalesOrderItems, 0);
        }
        else {
            srNo = parseInt(DOM.hiddenSrNo.value);
            salesOrderItemId = parseInt(DOM.hiddenSalesOrderItemId.value);
        }

        if (isNaN(salesOrderItemId)) { salesOrderItemId = parseInt(0); }
        if (isNaN(salesOrderId)) { salesOrderId = parseInt(0); }
        if (isNaN(itemId)) { itemId = parseInt(0); }
        
        var salesOrderItem = {};

        if (SalesOrderItems.length > 0) {

            for (var r = 0; r < SalesOrderItems.length; r++) {

                if (SalesOrderItems[r].SalesOrderItemId === salesOrderItemId
                    && SalesOrderItems[r].SrNo === srNo) {

                    SalesOrderItems[r].SalesOrderItemId = salesOrderItemId;
                    SalesOrderItems[r].SalesOrderId = salesOrderId;
                    SalesOrderItems[r].ItemId = itemId;
                    SalesOrderItems[r].ItemName = itemName;
                    SalesOrderItems[r].SaleQtyInPcs = qtyInPcs;
                    SalesOrderItems[r].SaleQtyInMtrs = qtyInMtrs;
                    SalesOrderItems[r].SaleRate = rate;
                    SalesOrderItems[r].TaxId = taxId;
                    SalesOrderItems[r].Amount = amount;
                    SalesOrderItems[r].GSTRate = gstRate;
                    SalesOrderItems[r].GSTAmount = gstAmount;
                    SalesOrderItems[r].TotalItemAmount = totalItemAmount;
                    SalesOrderItems[r].SrNo = srNo;
                    SalesOrderItems[r].GSTRateId = gstRateId;
                    SalesOrderItems[r].RateCategoryId = parseInt(1);
                    SalesOrderItems[r].IsDeleted = false;
                    SalesOrderItems[r].ModifiedBy = LOGGED_USER;
                    SalesOrderItems[r].ModifiedByIp = IP_ADDRESS;
                    break;
                }
                else {

                    salesOrderItem = {
                        SalesOrderItemId: salesOrderItemId,
                        SalesOrderId: salesOrderId,
                        ItemId: itemId,
                        ItemName: itemName,
                        SaleQtyInPcs: qtyInPcs,
                        SaleQtyInMtrs: qtyInMtrs,
                        SaleRate: rate,
                        TaxId: taxId,
                        Amount: amount,
                        GSTRate: gstRate,
                        GSTAmount: gstAmount,
                        TotalItemAmount: totalItemAmount,
                        SrNo: srNo,
                        GSTRateId: gstRateId,
                        RateCategoryId: parseInt(1),
                        IsDeleted: false
                    };

                    if (parseInt(salesOrderItemId) === parseInt(0)) {

                        salesOrderItem.CreatedBy = LOGGED_USER;
                        salesOrderItem.CreatedByIp = IP_ADDRESS;
                    }
                    else {
                        salesOrderItem.ModifiedBy = LOGGED_USER;
                        salesOrderItem.ModifiedByIp = IP_ADDRESS;
                    }

                    SalesOrderItems.push(salesOrderItem);

                    break;
                }
            }
        }
        else {

            salesOrderItem = {
                SalesOrderItemId: salesOrderItemId,
                SalesOrderId: salesOrderId,
                ItemId: itemId,
                ItemName: itemName,
                SaleQtyInPcs: qtyInPcs,
                SaleQtyInMtrs: qtyInMtrs,
                SaleRate: rate,
                TaxId: taxId,
                Amount: amount,
                GSTRate: gstRate,
                GSTAmount: gstAmount,
                TotalItemAmount: totalItemAmount,
                SrNo: srNo,
                GSTRateId: gstRateId,
                RateCategoryId: parseInt(1),
                IsDeleted: false
            };

            if (parseInt(salesOrderItemId) === parseInt(0)) {

                salesOrderItem.CreatedBy = LOGGED_USER;
                salesOrderItem.CreatedByIp = IP_ADDRESS;
            }
            else {
                salesOrderItem.ModifiedBy = LOGGED_USER;
                salesOrderItem.ModifiedByIp = IP_ADDRESS;
            }

            SalesOrderItems.push(salesOrderItem);
        }
        
        bindSalesOrderItem(salesOrderId);
    }

    function saveAndAddNewItem() {

        saveOrderItem();

        addNewItem();

        DOM.item.focus();
    }

    function showSelectedOrderItemDetails(currentTableRow) {

        if (SalesOrderItems.length > 0) {

            var salesOrderItemId = parseInt(currentTableRow.getAttribute('data-sales-order-item-id'));

            var srNo = parseInt(currentTableRow.getAttribute('data-sr-no'));

            DOM.hiddenSrNo.value = srNo;

            DOM.hiddenSalesOrderItemId.value = salesOrderItemId;

            var data = SalesOrderItems.filter(function (value, index, array) {

                if (salesOrderItemId > 0) {
                    return value.SalesOrderItemId === salesOrderItemId
                        && (value.IsDeleted === false || value.IsDeleted === null);
                }
                else {
                    return value.SrNo === parseInt(srNo)
                        && (value.IsDeleted === false || value.IsDeleted === null);
                }
            });

            if (data.length > 0) {

                shared.setSelectValue(DOM.item, null, parseInt(data[0].ItemId));
                shared.setSelect2ControlsText(DOM.item);                
                DOM.qtyInPcs.value = data[0].SaleQtyInPcs;
                DOM.qtyInMtrs.value = data[0].SaleQtyInMtrs;
                DOM.rate.value = data[0].SaleRate;
                DOM.amount.value = data[0].Amount;
                DOM.gstRate.value = data[0].GSTRate;
                DOM.gstAmount.value = data[0].GSTAmount;
                DOM.totalItemAmount.value = data[0].TotalItemAmount;
                
                DOM.$orderItemModal.modal('show');
            }
        }
    }


    function loadData() {

        var currentDate = new Date();
        
        DOM.orderDate.value = moment(currentDate).format("DD/MMM/YYYY");

        getFinancialYears();

        getBranchNames();

        getCustomers();

        getItems();

        DOM.financialYear.focus();
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

    function getFinancialYears() {

        shared.fillDropdown(SERVICE_PATH + 'GetAllWorkingPeriods', DOM.financialYear, "FinancialYear", "WorkingPeriodId", "Choose Year");
    }

    function getBranchNames() {

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetAllBranchNames', DOM.branch, "BranchName", "BranchId", "Choose Branch", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.branch, parseInt(1));
                    shared.setSelect2ControlsText(DOM.branch);
                }
            }
        });
    }

    function getCustomers() {

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetClientAddressNamesByClientTypeId/1', DOM.customer, "ClientAddressName", "ClientAddressId", "Choose Vendor", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                     shared.setSelectOptionByIndex(DOM.customer, parseInt(1));
                     shared.setSelect2ControlsText(DOM.customer);

                     getGSTApplicable();
                }
            }
        });
    }

    function getGSTApplicable() {

        var clientAddressId = parseInt(DOM.customer.options[DOM.customer.selectedIndex].value);

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

    function getItems() {
        shared.fillDropdown(SERVICE_PATH + 'GetItemsByBrandCategoryAndQuality', DOM.item, "ItemName", "ItemId", "Choose Item");
    }

    function getSalesOrders() {

        DOM.salesOrders.tBodies[0].innerHTML = "";

        SalesOrders = [];
        SalesOrderItems = [];

        shared.sendRequest(SERVICE_PATH + "GetAllSalesOrders", "GET", true, "JSON", null, function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    var _response = JSON.parse(response.responseText);

                    if (_response !== undefined) {

                        if (_response.length > 0) {
                            
                            var table = DOM.salesOrders;

                            var tableBody = table.tBodies[0];

                            for (var r = 0; r < _response.length; r++) {

                                var salesOrderItems = _response[r].SalesOrderItems;
                                                                
                                var orderItems = salesOrderItems.filter(function (value, index, array) {
                                    return value.SalesOrderId === parseInt(_response[r].SalesOrderId);
                                });

                                var salesOrder = {};

                                salesOrder = {
                                    SalesOrderId: _response[r].SalesOrderId,
                                    SalesOrderNo: _response[r].SalesOrderNo,
                                    SalesOrderDate: _response[r].SalesOrderDate,
                                    CustomerId: _response[r].CustomerId,
                                    CustomerName: _response[r].CustomerName,
                                    BranchId: _response[r].BranchId,
                                    BranchName: _response[r].BranchName,
                                    GSTApplicable: _response[r].GSTApplicable,
                                    WorkingPeriodId: _response[r].WorkingPeriodId,
                                    FinancialYear: _response[r].FinancialYear,
                                    TotalOrderQty: _response[r].TotalOrderQty,
                                    TotalOrderAmount: _response[r].TotalOrderAmount,
                                    IsDeleted: false                                    
                                };

                                SalesOrders.push(salesOrder);

                                if (orderItems.length > 0) {

                                    for (var p = 0; p < orderItems.length; p++) {

                                        var salesOrderItem = {};

                                        salesOrderItem = {
                                            SalesOrderItemId: orderItems[p].SalesOrderItemId,
                                            SalesOrderId: orderItems[p].SalesOrderId,
                                            ItemId: orderItems[p].ItemId,
                                            ItemName: orderItems[p].ItemName,
                                            SaleQtyInPcs: orderItems[p].SaleQtyInPcs,
                                            SaleQtyInMtrs: orderItems[p].SaleQtyInMtrs,
                                            SaleRate: orderItems[p].SaleRate,
                                            TaxId: orderItems[p].TaxId,
                                            Amount: orderItems[p].Amount,
                                            GSTRate: orderItems[p].GSTRate,
                                            GSTAmount: orderItems[p].GSTAmount,
                                            TotalItemAmount: orderItems[p].TotalItemAmount,
                                            IsDeleted: false
                                        };

                                        SalesOrderItems.push(salesOrderItem);
                                    }
                                }
                                
                                var currentRow = document.createElement('TR');

                                var data;

                                data = "<tr><td>" + _response[r].SalesOrderNo + "</td>";
                                data = data + "<td>" + _response[r].SalesOrderDate + "</td>";
                                data = data + "<td>" + _response[r].CustomerName + "</td>";
                                data = data + "<td>" + _response[r].TotalOrderQty + "</td>";
                                data = data + "<td>" + _response[r].TotalOrderAmount + "</td>";
                                data = data + "<td>" + _response[r].FinancialYear + "</td>";
                                data = data + "<td class='text-center'> " +
                                    "<a href='#' class='btn btn-info btn-xs'  data-name='view' > <i class='fa fa-eye'  data-name='view' ></i> View </a > " +
                                    "<a href='#' class='btn btn-info btn-xs'  data-name='edit' > <i class='fa fa-edit'  data-name='edit' ></i> Edit </a > " +
                                    "<a href='#' class='btn btn-danger btn-xs' data-name='remove' > <i class='fa fa-remove'  data-name='remove' > </i> Delete </a> </td > ";

                                currentRow.setAttribute('data-sales-order-id', _response[r].SalesOrderId);
                                currentRow.innerHTML = data;

                                tableBody.appendChild(currentRow);                                
                            }

                            toggleModes("none", "block"); 
                        }
                        else {
                            toggleModes("block", "none"); 
                        }
                    }
                }
            }
        });
    }

    function saveSalesOrder() {

        var salesOrderId = parseInt(0);
        var salesOrderNo = parseInt(0);
        var salesOrderDate = null;
        var customerId = parseInt(0);
        var branchId = parseInt(0);
        var workingPeriodId = parseInt(0);

        salesOrderId = DOM.orderNo.getAttribute('data-sales-order-id');
        salesOrderNo = parseInt(DOM.orderNo.value);
        salesOrderDate = DOM.orderDate.value;
        customerId = parseInt(DOM.customer.options[DOM.customer.selectedIndex].value);
        branchId = parseInt(DOM.branch.options[DOM.branch.selectedIndex].value);
        workingPeriodId = parseInt(DOM.financialYear.options[DOM.financialYear.selectedIndex].value);

        if (salesOrderId === null) { salesOrderId = parseInt(0); }

        if (isNaN(salesOrderId)) { salesOrderId = parseInt(0); }

        var salesOrder = {};

        salesOrder = {
            SalesOrderId: salesOrderId,
            SalesOrderNo: salesOrderNo,
            SalesOrderDate: salesOrderDate,
            CustomerId: customerId,
            BranchId: branchId,
            WorkingPeriodId: workingPeriodId,
            SalesOrderItems: SalesOrderItems,
            IsDeleted: false            
        };

        if (parseInt(salesOrderId) === parseInt(0)) {

            salesOrder.CreatedBy = LOGGED_USER;
            salesOrder.CreatedByIp = IP_ADDRESS;
        }
        else {
            salesOrder.ModifiedBy = LOGGED_USER;
            salesOrder.ModifiedByIp = IP_ADDRESS;
        }

        SalesOrders.push(salesOrder);

        var postData = JSON.stringify(SalesOrders);

        shared.sendRequest(SERVICE_PATH + "SaveSalesOrder", "POST", true, "JSON", postData, function (response) {

            var _response = JSON.parse(response.responseText);

            if (response.status === 200) {
                if (parseInt(response.responseText) > parseInt(0)) {
                    getSalesOrders();
                }
            }
            else {
                swal("error", "Unable to save the Sales Order Details. Error as " + _response.Message + " " + _response.ExceptionMessage, "error");
                handleError(_response.Message + " " + _response.ExceptionMessage);
                SalesOrders = [];
            }
        });
    }

    function toggleModes(editModeDisplay, viewModeDisplay) {

        DOM.editMode.style.display = editModeDisplay;
        DOM.viewMode.style.display = viewModeDisplay;
    }

    
    /* ---- public methods ---- */
    function init() {
        cacheDOM();
        bindEvents();
        applyPlugins();
        loadData();
        getSalesOrders();
    }

    return {
        init: init
    };

}());


SharpiTech.SalesOrder.init();
