var SharpiTech = {};

SharpiTech.Barcode = (function () {

        //placeholder for cached DOM elements
    var DOM = {};

    var shared = new Shared();

    var _barcodes = [];
    var _inwardNos = [];
    var _items = [];
    var _currentFocus;

    /* ---- private method ---- */

    //cache DOM elements
    function _cacheDOM() {

        DOM.editMode = document.getElementById('EditMode');
        DOM.byInwardNo = document.getElementById('ByInwardNo');
        DOM.byItem = document.getElementById('ByItem');
        DOM.vendorName = document.getElementById('VendorName');
        DOM.inwardNo = document.getElementById('InwardNo');
        DOM.itemName = document.getElementById('ItemName');
        DOM.barcodeSize = document.getElementById('BarcodeSize');
        DOM.noOfLabels = document.getElementById('NoOfLabels');
        DOM.labelStartNo = document.getElementById('LabelStartNo');
        DOM.itemsList = document.getElementById('ItemsList');
        DOM.barcodeItemsList = document.getElementById('BarcodeItemsList');

        DOM.printBarcode = document.getElementById('PrintBarcode');
        DOM.saveBarcodeDetails = document.getElementById('SaveBarcodeDetails');

    }

    function applyPlugins() {

        $('select').select2();
                
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

    /* ---- render ---- */
    function render() {


    }

    function bindEvents() {

        DOM.printBarcode.addEventListener('click', printBarcode);
        DOM.saveBarcodeDetails.addEventListener('click', saveBarcodeDetails);

        DOM.noOfLabels.onkeydown = function validate(e) {
            return shared.acceptOnlyNumbers(e);
        };

        DOM.vendorName.onchange = function () {
            getItems();
        }


        DOM.inwardNo.onkeyup = function (e) {

            showAutoComplete(e);
        }
    }

    function loadData() {

        shared.clearInputs(DOM.editMode);

        _barcodes = [];
        
        DOM.vendorName.focus();

        getVendors();

        getItems();
        
    }

    function getVendors() {

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetVendors', DOM.vendorName, "VendorName", "VendorId", "Choose Vendor", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.vendorName, parseInt(1));
                    shared.setSelect2ControlsText(DOM.vendorName);

                    //getItems();
                }
            }
        });
    }

    function getItemsByInwardId(inwardId) {

        shared.sendRequest(SERVICE_PATH + "GetItemsByInwardId/" + inwardId, "Get", true, "JSON", null, function (response) {            

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    _items = JSON.parse(response.responseText);

                    bindBarcodeItems();
                }
            }
        });
    }

    function showAutoComplete(e) {
                
        if (e.target.value === "") {
            _currentFocus = -1;
            shared.closeAutoCompleteList(DOM.itemsList);
            return;
        }

        if (e.keyCode === 40) {
            _currentFocus++;
            addActive();
        }
        else if (e.keyCode === 38) {
            _currentFocus--;
            addActive();
        }
        else if (e.keyCode === 13) {
            _currentFocus = -1;
            setItemOnEnter();
        }
        else {

            if (_currentFocus === undefined) { _currentFocus = -1; }
            
            shared.showItemsList(e, DOM.itemsList, SERVICE_PATH + 'SearchInwardNo/' + DOM.inwardNo.value, function (response) {

                if (response) {

                    DOM.itemsList.appendChild(response);

                    var li = DOM.itemsList.querySelectorAll('li');

                    for (l = 0; l < li.length; l++) {
                        li[l].onclick = setItem;
                    }

                    DOM.itemsList.style.width = DOM.inwardNo.offsetWidth + 'px';
                        
                    DOM.itemsList.classList.add('autocompleteList-active');                        
                }

            });
        }
    }

    
    function addActive() {

        removeActive();

        var li = DOM.itemsList.querySelectorAll('li');

        var count = li.length;

        if (_currentFocus >= count) {
            _currentFocus = 0;
        }

        if (_currentFocus < 0) {
            _currentFocus = count - 1;
        }

        li[_currentFocus].classList.add('autocompleteListItem-active');

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

        DOM.inwardNo.value = e.target.textContent;

        shared.closeAutoCompleteList(DOM.itemsList);

        getItemsByInwardId(e.target.id);

        DOM.inwardNo.value = "";
    }

    function setItemOnEnter() {

        FLAG = "NEW ITEM";

        var li = DOM.itemsList.querySelectorAll('.autocompleteListItem-active');

        var count = li.length;

        if (count) {

            DOM.inwardNo.value = li[0].textContent;

            shared.closeAutoCompleteList(DOM.itemsList);
        }

        var inwardId = li[0].id;
        
        getItemsByInwardId(inwardId);

        DOM.inwardNo.value = "";
    }

    function bindBarcodeItems() {

        var inwardGoodsId = 0;
        var goodsReceiptItemId = 0;
        var itemId = 0;
        var itemName = 0;
        var noOfLabels = 0;
        var labelStartNo = 0;
        var prevNoOfLabels = 0;
        var prevLabelStartNo = 0;
        var vendorId = 0;
        var locationType = "store";

        var table = DOM.barcodeItemsList;

        var tableBody = table.tBodies[0];

        var tableRows = tableBody.children;

        var rowsCount = tableBody.children.length;

        tableBody.innerHTML = "";

        var data = "";
                        
        if (_items.length) {

            for (var i = 0; i < _items.length; i++) {

                inwardGoodsId = _items[i].InwardGoodsId;
                goodsReceiptItemId = _items[i].GoodsReceiptItemId;
                itemId = _items[i].ItemId;
                itemName = _items[i].ItemName;
                noOfLabels = _items[i].NoOfLabels;
                vendorId = _items[i].VendorId;
                locationType = _items[i].LocationType;

                if (i === 0) {

                    labelStartNo = 0;
                    prevNoOfLabels = noOfLabels;
                    prevLabelStartNo = 0;
                }
                else {

                    labelStartNo =  prevNoOfLabels + prevLabelStartNo;
                    prevNoOfLabels = noOfLabels;
                    prevLabelStartNo = labelStartNo;
                }

                data += "<tr data-inward-goods-id=" + inwardGoodsId + " data-goods-receipt-item-id=" + goodsReceiptItemId + " data-item-id=" + itemId + " data-vendor-id=" + vendorId + " data-location-type=" + locationType + ">";
                data += "<td>" +
                        "<button type='button' id=RemoveItem'" + inwardGoodsId + "' class='btn btn-xs btn-danger btn-round' >" +
                        "<span class='fa fa-fw fa-remove'></span> </button>" + "</td >";
                data += "<td>" + itemName + "</td>";
                data += "<td> <input type='text' id=NoOfLabels" + inwardGoodsId + " class='form-control input-sm' value=" + noOfLabels + " /></td>";
                data += "<td> <input type='text' id=LabelStartNo" + inwardGoodsId + " class='form-control input-sm' value=" + labelStartNo + " /></td>";
                data += "</tr>";

            }

            tableBody.innerHTML = data;

            var buttons = tableBody.querySelectorAll('button');
            var inputs = tableBody.querySelectorAll('input[type="text"]');

            if (buttons.length) {

                for (var b = 0; b < buttons.length; b++) {
                    buttons[b].onclick = removeItem;
                }
            }

            if (inputs.length) {

                for (var j = 0; j < inputs.length; j++) {
                    inputs[j].onkeydown = function validate(e) {
                        return shared.acceptOnlyNumbers(e);
                    };
                }
            }
        }
    }

    //function getItems() {

    //    DOM.itemName.options.length = 0;

    //    var dataAttributes = 'ItemId|ItemCode|VendorCode|VendorId';

    //    shared.fillDropdownWithDataAttributesAndCallback(SERVICE_PATH + 'GetItemsFromGoodsReceipt', DOM.itemName, "ItemName", "GoodsReceiptItemId", "Choose Item", dataAttributes, function (response) {
    //        if (response.status === 200) {
    //            if (response.responseText !== undefined) {
    //                shared.setSelectOptionByIndex(DOM.itemName, 1);
    //                shared.setSelect2ControlsText(DOM.itemName);
    //            }
    //        }
    //        else {
    //            swal("Error!!!", "Error in the application " + response.responseText, "error");
    //        }
    //    });
    //}

    function getItems() {
            
        DOM.itemName.options.length = 0;

        var dataAttributes = 'ItemId|ItemCode|VendorCode|VendorId';

        shared.fillDropdownWithDataAttributesAndCallback(SERVICE_PATH + 'GetItemsFromInwardOutward', DOM.itemName, "ItemName", "GoodsReceiptItemId", "Choose Item", dataAttributes, function (response) {
            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.itemName, 1);
                    shared.setSelect2ControlsText(DOM.itemName);

                    shared.setSelectValue(DOM.vendorName, null, parseInt(DOM.itemName.options[DOM.itemName.selectedIndex].getAttribute('data-vendorid')));
                    shared.setSelect2ControlsText(DOM.vendorName);                   

                }
            }
            else {
                swal("Error!!!", "Error in the application " + response.responseText, "error");
            }
        });
    }

    function validateData() {

        var isValid = true;

        if (DOM.byItem.checked) {
            if (DOM.vendorName.selectedIndex === -1) {
                DOM.vendorName.focus();
                isValid = false;
                swal("Error", "Please select the Vendor Name.", "error");
            }
            else if (DOM.itemName.value === "") {
                DOM.itemName.focus();
                isValid = false;
                swal("Error", "Please select the Item Name.", "error");
            }
            else if (DOM.noOfLabels.value === "") {
                DOM.noOfLabels.focus();
                isValid = false;
                swal("Error", "Please enter the No. of Labels to print.", "error");
            }
            else if (parseInt(DOM.noOfLabels.value) <= parseInt(0)) {
                DOM.noOfLabels.focus();
                isValid = false;
                swal("Error", "No. of Labels value should be greater than zero.", "error");
            }

        }

        return isValid;
    }

    function saveBarcodeDetails() {

        if (validateData()) {

            /* temp variable */
            var vendorId = parseInt(0);
            var itemId = parseInt(0);
            var noOfLabels = parseInt(0);
            var labelStartNo = parseInt(0);
            var goodsReceiptItemId = parseInt(0);
            var inwardGoodsId = 0;
            var printLabelContinue = false;
            var locationType = "store";

            _barcodes = [];

            var barcode = {};

            if (DOM.byItem.checked) {

                vendorId = parseInt(DOM.itemName.options[DOM.itemName.selectedIndex].getAttribute('data-vendorid'));
                itemId = parseInt(DOM.itemName.options[DOM.itemName.selectedIndex].getAttribute('data-itemid'));
                noOfLabels = parseInt(DOM.noOfLabels.value);
                labelStartNo = parseInt(DOM.labelStartNo.value);
                goodsReceiptItemId = parseInt(DOM.itemName.options[DOM.itemName.selectedIndex].value);
                inwardGoodsId = 0; // parseInt(DOM.itemName.options[DOM.itemName.selectedIndex].value);
                printLabelContinue = false;

                if (isNaN(vendorId)) { vendorId = parseInt(0); }
                if (isNaN(itemId)) { itemId = parseInt(0); }
                if (isNaN(labelStartNo)) { labelStartNo = parseInt(0); }
                if (isNaN(goodsReceiptItemId)) { goodsReceiptItemId = parseInt(0); }



                barcode = {
                    VendorId: vendorId,
                    ItemId: itemId,
                    NoOfLabels: noOfLabels,
                    LabelStartNo: labelStartNo,
                    GoodsReceiptItemId: goodsReceiptItemId,
                    PrintLabelContinue: printLabelContinue
                };

                _barcodes.push(barcode);
            }
            else {

                var tableBody = DOM.barcodeItemsList.tBodies[0];

                var tableRows = tableBody.children;

                if (tableRows.length) {

                    for (var r = 0; r < tableRows.length; r++) {

                        vendorId = parseInt(tableRows[r].getAttribute('data-vendor-id'));
                        itemId = parseInt(tableRows[r].getAttribute('data-item-id'));
                        noOfLabels = parseInt(tableRows[r].children[2].children[0].value);
                        labelStartNo = parseInt(tableRows[r].children[3].children[0].value);
                        goodsReceiptItemId = parseInt(tableRows[r].getAttribute('data-goods-receipt-item-id'));
                        locationType = tableRows[r].getAttribute('data-location-type');
                        if (locationType === "karagir") {
                            inwardGoodsId = parseInt(tableRows[r].getAttribute('data-inward-goods-id'));
                        }
                        printLabelContinue = true;

                        if (r === 0) {

                            if (labelStartNo > 0) {
                                printLabelContinue = false;
                            }
                            else {
                                printLabelContinue = true;
                            }
                        }

                        if (isNaN(vendorId)) { vendorId = parseInt(0); }
                        if (isNaN(itemId)) { itemId = parseInt(0); }
                        if (isNaN(labelStartNo)) { labelStartNo = parseInt(0); }
                        if (isNaN(goodsReceiptItemId)) { goodsReceiptItemId = parseInt(0); }

                        barcode = {
                            VendorId: vendorId,
                            ItemId: itemId,
                            NoOfLabels: noOfLabels,
                            LabelStartNo: labelStartNo,
                            GoodsReceiptItemId: goodsReceiptItemId,
                            PrintLabelContinue: printLabelContinue,
                            InwardGoodsId: inwardGoodsId
                        };

                        _barcodes.push(barcode);
                    }
                }


            }
            
            if (_barcodes.length) {

                var postData = JSON.stringify(_barcodes);

                shared.sendRequest(SERVICE_PATH + "SaveBarcodeDetails", "POST", true, "JSON", postData, function (response) {

                    var _response = JSON.parse(response.responseText);

                    if (response.status === 200) {
                        if (parseInt(response.responseText) > parseInt(0)) {
                            printBarcode();
                        }
                    }
                    else {
                        swal("error", "Unable to save the Barcode Details due to some error.", "error");
                        handleError(_response.Message + " " + _response.ExceptionMessage);
                        _barcodes = [];
                    }
                });
            }
        }
    }
        
    function printBarcode() {

        var barcodeSize = "large";

        if (DOM.barcodeSize.selectedIndex === 1) {
            barcodeSize = "small";
        }
        else {
            barcodeSize = "large";
        }

        shared.sendRequest(SERVICE_PATH + "PrintBarcode/" + barcodeSize , "GET", true, "JSON", null, function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    var _response = JSON.parse(response.responseText);

                    if (_response !== undefined) {

                        if (_response.length > 0) {

                            window.open(location.origin + "/POS/ApplicationFiles/Barcode/Barcode.pdf", "_blank");
                        }
                    }
                }
            }
        });
    }

    
    /* ---- public methods ---- */
    function init() {
        _cacheDOM();
        applyPlugins();
        bindEvents();
        loadData();    
    }

    return {
        init: init
    };

}());


SharpiTech.Barcode.init();
