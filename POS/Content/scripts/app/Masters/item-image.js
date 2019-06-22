
var SharpiTech = {};

SharpiTech.ItemImage = (function () {

    //placeholder for cached DOM elements
    var DOM = {};

    var shared = new Shared();

    var CURRENT_FOCUS = -1;
    var SEARCH_ITEMS_LIST = [];
    var ItemImages = [];

    /* ---- private method ---- */
    //cache DOM elements
    function cacheDOM() {

        DOM.addNewItemImage = document.getElementById('AddNewItemImage');
        DOM.showItemImage = document.getElementById('ShowItemImage');
        DOM.viewItemImage = document.getElementById('ViewItemImage');
        DOM.editItemImage = document.getElementById('EditItemImage');
        DOM.saveItemImage = document.getElementById('SaveItemImage');
        DOM.deleteItemImage = document.getElementById('DeleteItemImage');
        DOM.filterItemImageList = document.getElementById('FilterItemImageList');

        DOM.loader = document.getElementById('Loader');

        DOM.editMode = document.getElementById('EditMode');
        DOM.itemName = document.getElementById('ItemName');
        DOM.itemsList = document.getElementById('ItemsList');
        DOM.itemColor = document.getElementById('ItemColor');
        DOM.fabricDesign = document.getElementById('FabricDesign');
        DOM.itemImageUpload = document.getElementById('ItemImageUpload');
        DOM.uploadItemImage = document.getElementById('UploadItemImage');

        DOM.viewMode = document.getElementById('ViewMode');
        DOM.itemImageUploadList = document.getElementById('ItemImageUploadList');
        DOM.sliderThumbs = document.getElementById('SliderThumbs');
        DOM.slider = document.getElementById('Slider');

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

        DOM.addNewItemImage.addEventListener('click', addNewItemImage);
        DOM.showItemImage.addEventListener('click', showItemImage);
        DOM.viewItemImage.addEventListener('click', viewItemImage);
        DOM.editItemImage.addEventListener('click', editItemImage);
        DOM.saveItemImage.addEventListener('click', saveItemImage);
        DOM.deleteItemImage.addEventListener('click', deleteItemImage);

        DOM.uploadItemImage.onclick = function (e) {

            //var event = new Event('onclick');
            //DOM.itemImageUpload.addEventListener('onclick', openFileUploadControl);
            //DOM.itemImageUpload.dispatchEvent(event);
            openFileUploadControl();
            e.preventDefault();
        }

        DOM.itemName.onkeyup = function (e) {
            //getKey(e.keyCode);

            if (CURRENT_FOCUS === undefined) { CURRENT_FOCUS = -1; }
            //if (e.keyCode === 8 || e.keyCode === 127) {
            //    DOM.itemName.value = "";                
            //}
            //setTimeout(function () {
            showItemsList(e);
            //showItemsList(e);
            //}, 1000);            

        };


    }

    function loadData() {

        getColorsName();

        addNewItemImage();

        //getFabricDesign();
    }

    function getColorsName() {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetAllColorsName', DOM.itemColor, "ColorName", "ColorId", "Choose Color", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.itemColor, parseInt(0));
                    shared.setSelect2ControlsText(DOM.itemColor);
                }
            }
        });

        shared.hideLoader(DOM.loader);
    }

    function getFabricDesign() {

        shared.showLoader(DOM.loader);

        shared.fillDropdownWithCallback(SERVICE_PATH + 'GetFabricDesign', DOM.fabricDesign, "DesignName", "DesignId", "Choose Design", function (response) {

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    shared.setSelectOptionByIndex(DOM.fabricDesign, parseInt(1));
                    shared.setSelect2ControlsText(DOM.fabricDesign);
                }
            }
        });

        shared.hideLoader(DOM.loader);
    }

    function openFileUploadControl() {

        DOM.itemImageUpload.click();
    }

    var getSelectedRows = function () {

        var selectedRows = [];

        var tableBody = DOM.itemImageUploadList.tBodies[0];

        var tableRows = tableBody.children;

        if (tableRows.length > 0) {

            for (var tr = 0; tr < tableRows.length; tr++) {

                var checkBox = tableRows[tr].querySelectorAll('.label-checkbox')[0];

                if (checkBox.checked) {

                    selectedRows.push(tableRows[tr]);
                }
            }
        }

        return selectedRows;
    };

    function showItemsList(e) {

        if (e.keyCode === 13) {
            e.preventDefault();
            CURRENT_FOCUS = -1;
            showItemNameOnEnterKey(e);
            return;
        }

        var dataAttributes = ['Item-Id', 'Item-Name'];

        var parameters = {};

        parameters = {

            Event: e,
            CurrentFocus: CURRENT_FOCUS,
            PostDataKeyValue: postMessage,
            ElementToBeAppend: DOM.itemsList,
            DataAttributes: dataAttributes,
            PostParamObject: "ItemName",
            URL: SERVICE_PATH + "SearchItem/",
            DisplayName: "ItemName"
        };

        shared.showAutoCompleteItemsList(parameters, function (response) {

            if (response !== undefined) {

                if (response >= 0) {

                    CURRENT_FOCUS = response;
                }
                else {

                    CURRENT_FOCUS = -1;


                    SEARCH_ITEMS_LIST = response;

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
                            li.setAttribute('data-item-code', SEARCH_ITEMS_LIST[s].ItemCode);
                            
                            li.style.cursor = "pointer";
                            li.onclick = showItemNameOnSelection;
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

                        DOM.itemsList.style.width = DOM.itemName.offsetWidth + 'px';
                        DOM.itemsList.style.left = DOM.itemName.parentElement.offsetLeft + 15 + 'px';
                        //DOM.itemsList.style.top = DOM.itemName.parentElement.offsetTop + 52 + 'px';

                        DOM.itemsList.classList.add('autocompleteList-active');
                        //DOM.itemsList.innerHTML = data;
                    }

                }
            }

            shared.hideLoader(DOM.loader);

        });

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

    function showItemNameOnSelection(e) {

        FLAG = "NEW ITEM";

        setItemName(e);

    }

    function showItemNameOnEnterKey() {

        FLAG = "NEW ITEM";

        var li = DOM.itemsList.querySelectorAll('.autocompleteListItem-active');

        var count = li.length;

        if (count) {

            setItemName(li[0]);
        }

    }

    function setItemName(e) {

        shared.closeAutoCompleteList(DOM.itemsList);

        var itemId = 0;
        var itemName = "";
        var itemCode = "";

        if (e.nodeName === undefined) {
            itemId = e.target.id;
            itemName = e.target.textContent;
            itemCode = e.target.getAttribute('data-item-code');
        }
        else {
            itemId = e.id;
            itemName = e.textContent;
            itemCode = e.getAttribute('data-item-code');
        }

        DOM.itemName.value = itemName;
        DOM.itemName.setAttribute('data-item-id', itemId);
        DOM.itemName.setAttribute('data-item-code', itemCode);

        DOM.itemName.focus();

        showItemImage();
    }

    function addNewItemImage() {

        shared.clearInputs(DOM.editMode);
        shared.clearTables(DOM.editMode);

        ItemImages.length = 0;

        shared.disableControls(DOM.editMode, false);

        DOM.itemName.setAttribute('data-item-id', parseInt(0));

        shared.showPanel(DOM.editMode);
        shared.hidePanel(DOM.viewMode);

        DOM.itemName.focus();
    }

    function viewItemImage() {

        shared.showLoader(DOM.loader);

        shared.clearInputs(DOM.editMode);
        shared.clearSelect(DOM.editMode);
        shared.disableControls(DOM.editMode, true);

        var selectedRows = getSelectedRows();

        if (selectedRows.length > 0) {

            if (selectedRows.length > 1) {
                swal('Warning', "Please select only one record to View or Edit the Records.", "warning");
                return false;
            }
            else {

                var currentTableRow = selectedRows[0];

                var itemImageId = parseInt(currentTableRow.getAttribute('data-item-image-id'));

                bindItemImageDetails(itemImageId);
            }
        }
        else {
            swal("error", "No row selected.", "error");
        }

        shared.hideLoader(DOM.loader);
    }

    function editItemImage() {

        shared.showLoader(DOM.loader);

        shared.clearInputs(DOM.editMode);
        shared.clearSelect(DOM.editMode);
        shared.disableControls(DOM.editMode, false);

        var selectedRows = getSelectedRows();

        if (selectedRows.length > 0) {

            if (selectedRows.length > 1) {
                swal('Warning', "Please select only one record to Edit the Records.", "warning");
                return false;
            }
            else {

                var currentTableRow = selectedRows[0];

                var itemImageId = parseInt(currentTableRow.getAttribute('data-item-image-id'));

                showItemImageDetails(itemImageId);
            }
        }
        else {
            swal("error", "No row selected.", "error");
        }

        shared.hideLoader(DOM.loader);

        // Focus
        DOM.itemName.focus();
    }

    function deleteItemImage() {

        shared.showLoader(DOM.loader);

        try {

            var tableBody = DOM.itemImageUploadList.tBodies[0];

            var selectedRows = getSelectedRows();

            if (selectedRows.length > 0) {

                swal({
                    title: "Are you sure",
                    text: "Are you sure you want to delete this record?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "Yes, delete it!",
                    cancelButtonText: "No, cancel pls",
                    closeOnConfirm: false,
                    closeOnCancel: true,
                },
                    function (isConfirm) {

                        if (isConfirm) {

                            for (var r = 0; r < selectedRows.length; r++) {

                                var data = [];

                                var itemImage = {};

                                itemImage = {
                                    ItemImageId: parseInt(selectedRows[r].getAttribute('data-item-image-id')),
                                    IsDeleted: true,
                                    DeletedBy: parseInt(LOGGED_USER),
                                    DeletedByIP: IP_ADDRESS
                                };

                                data.push(itemImage);

                                var postData = JSON.stringify(data);

                                shared.sendRequest(SERVICE_PATH + 'SaveItemImage', "POST", true, "JSON", postData, function (response) {

                                    if (response.status === 200) {

                                        if (parseInt(response.responseText) > 0) {

                                            swal({
                                                title: "Success",
                                                text: "Item Image deleted successfully.",
                                                type: "success"
                                            }, function () {
                                                ItemImages.length = 0;
                                            });
                                        }
                                    }
                                    else {
                                        swal({
                                            title: "Error",
                                            text: "Unable to delete records due to an error." + response.responseText,
                                            type: "error"
                                        });
                                    }

                                    shared.hideLoader(DOM.loader);

                                });
                            }
                        }
                    }
                );
            }
            else {
                swal("error", "No row selected.", "error");
            }
        }
        catch (e) {
            handleError(e.message);
        }
        finally {

            shared.hideLoader(DOM.loader);
        }

    }

    //function setFocus() {
    //    DOM.$pkgSlipItemModal.on('shown.bs.modal', function () {
    //        DOM.itemName.focus();
    //    });
    //}

    function unselectItemImage() {

        var tableBody = DOM.itemImageUploadList.tBodies[0];

        var checkBoxes = tableBody.querySelectorAll('.label-checkbox');

        if (checkBoxes.length > 0) {

            for (var c = 0; c < checkBoxes.length; c++) {

                checkBoxes[c].checked = false;
            }
        }
    }

    //function bindItemImageDetails() {

    //    var tableBody = DOM.itemImageUploadList.tBodies[0];

    //    tableBody.innerHTML = "";

    //    // Check the inward details has values
    //    if (ItemImages.length > 0) {

    //        var data = "";

    //        for (var r = 0; r < ItemImages.length; r++) {

    //            data = data + "<tr data-item-image-id=" + parseInt(ItemImages[r].ItemImageId) + ">";
    //            data = data + "<td><label class='label-tick'> <input type='checkbox' id='" + ItemImages[r].ItemImageId+ "' class='label-checkbox' name='SelectItemRate' /> <span class='label-text'></span> </label>" + "</td>";
    //            data = data + "<td>" + ItemImages[r].ItemName + "</td>";
    //            data = data + "<td>" + ItemImages[r].ItemCode + "</td>";
    //            data = data + "<td>" + ItemImages[r].ItemColor + "</td>";
    //            data = data + "<td>" + ItemImages[r].FabricDesign + "</td>";
    //            data = data + "<td>" + ItemImages[r].ItemImageName + "</td>";
    //            data = data + "</tr>";

    //        }

    //        tableBody.innerHTML = data;

    //        // Show panels
    //        shared.showPanel(DOM.editMode);
    //        shared.hidePanel(DOM.viewMode);

    //    }
    //}

    function bindItemImageDetails() {

        //Clear the div with image thumbnails and images
        DOM.sliderThumbs.innerHTML = "";
        DOM.slider.innerHTML = "";

        
        // Check the inward details has values
        if (ItemImages.length > 0) {

            var data = "";

            var ul = document.createElement('ul');

            for (var r = 0; r < ItemImages.length; r++) {

                data = data + "<li class='col-sm-3'> <a class='thumbnail' id='carousel-selector-'" + r + "'> <img src= '../" + ItemImages[r].ItemImagePath + ItemImages[r].ItemImageName + "' style='height:100px; width:250px;'> </a> </li>";

            }

            // Bind slider thumbs data
            ul.innerHTML = data;

            DOM.sliderThumbs.appendChild(ul);

            //// Show panels
            //shared.showPanel(DOM.editMode);
            //shared.hidePanel(DOM.viewMode);

        }

    }

    function showItemImageDetails(itemImageId) {

        if (ItemImages.length > 0) {

            DOM.itemName.setAttribute('data-item-image-id') = itemImageId;

            var data = ItemImages.filter(function (value, index, array) {

                return value.itemImageId === itemImageId;

            });

            if (data.length > 0) {

                shared.setSelectValue(DOM.itemColor, null, parseInt(data[0].ItemColor));
                shared.setSelect2ControlsText(DOM.itemColor);

                shared.showPanel(DOM.editMode);
                shared.hidePanel(DOM.viewMode);

                DOM.itemName.focus();
            }
        }
    }

    function showItemImage() {

        shared.showLoader(DOM.loader);

        ItemImages.length = 0;

        var itemId = DOM.itemName.getAttribute('data-item-id');

        shared.sendRequest(SERVICE_PATH + "GetItemImagesByItemId/" + itemId, "GET", true, "JSON", null, function (response) {

            shared.showLoader(DOM.loader);

            if (response.status === 200) {

                if (response.responseText !== undefined) {

                    var res = JSON.parse(response.responseText);

                    if (res !== undefined) {

                        if (res.length > 0) {

                            ItemImages = res;

                            bindItemImageDetails();
                        }
                    }
                }
            }

            shared.hideLoader(DOM.loader);

        });
    }

    function saveItemImage() {

        ItemImages.length = 0;

        var files = null;
        var uploadedFiles = null;
        var itemId = 0;
        var filePath = "UploadedFiles/ItemImages/";
        var itemCode = null;

        itemId = DOM.itemName.getAttribute('data-item-id');
        itemCode = DOM.itemName.getAttribute('data-item-code');
        colorId = DOM.itemColor.options[DOM.itemColor.selectedIndex].value;
        designId = 0; //DOM.fabricDesign.options[DOM.fabricDesign.selectedIndex].value;

        filePath += itemCode + "/";

        if (colorId > 0) {
            filePath += colorId;
        }


        if (isNaN(itemId)) { itemId = parseInt(0); }

        //DOM.uploadedFiles.innerHTML = "";

        var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;

        //DOM.uploadedFiles;
        files = DOM.itemImageUpload.files;

        for (var p = 0; p < files.length; p++) {

            if (regex.test(files[p].name.toLowerCase()) === false) {
                swal("Warning", "Please select the valid file name. Only .jpg / .jpeg / .gif / .png / .bmp file types are supported.", "warning");
                DOM.itemPictureUploader.focus();
                return false;
            }
            else if ((files[p].size / 1024 / 1024) > 50) {
                swal("Warning", "Image size should not be more than 50 MB.", "warning");
                return false;
            }
            else {

                var colorId = 0;
                var fabricDesignId = 0;

                colorId = parseInt(DOM.itemColor.options[DOM.itemColor.selectedIndex].value);
                fabricDesignId = 0;

                var itemPicture = {};

                itemImage = {
                    ItemImageId: 0,
                    ItemId: itemId,
                    ColorId: colorId,
                    DesignId: fabricDesignId,
                    ItemImageName: files[p].name.split(' ').join('_'),
                    ItemImagePath: filePath,
                    CreatedBy: parseInt(LOGGED_USER),
                    CreatedByIP: IP_ADDRESS
                };

                ItemImages.push(itemImage);

            }
        }

        if (ItemImages.length) {

            var span = document.getElementById('NoOfFilesUploaded');

            span.innerText = "No. of Files Uploaded " + ItemImages.length;

            var postData = JSON.stringify(ItemImages);

            shared.sendRequest(SERVICE_PATH + 'SaveItemImage', "POST", true, "JSON", postData, function (response) {

                if (response.status === 200) {

                    if (parseInt(response.responseText) > 0) {

                        swal({
                            title: "Success",
                            text: "Item Image saved successfully.",
                            type: "success"
                        }, function () {
                            uploadItemImages();

                            showItemImage();
                        });
                    }
                }
                else {
                    swal({
                        title: "Error",
                        text: "Unable to delete records due to an error." + response.responseText,
                        type: "error"
                    });
                }

                shared.hideLoader(DOM.loader);

            });

        }

        //var elements = "";

        //elements = elements + "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>";
        //elements = elements + "<div id='ProgressBar_" + p + "' class='progress-bar progress-bar-striped-active' role='progressbar' aria-valuemin='0' aria-valuemax='100' style='width:0%'</div>";
        //elements = elements + "</div>";
        //elements = elements + "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>";
        //elements = elements + "<div class='col-lg-6 col-md-6 col-sm-6 col-xs-12'>";
        //elements = elements + "<button type='button' id='Cancel_" + p + "' class='btn btn-sm btn-danger' style='display:none; line-height: 6px; height:25px;'>Cancel</button>"; 
        //elements = elements + "</div>";
        //elements = elements + "<div class='col-lg-6 col-md-6 col-sm-6 col-xs-12'>";
        //elements = elements + "<p id='Status_" + p + "' class='progress-status' style='text-align:right; margin-right:-15px; font-weight: bold; color: #fefefe'";
        //elements = elements + "</p>";
        //elements = elements + "</div>";
        //elements = elements + "</div>";
        //elements = elements + "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12'>";
        //elements = elements + "<p id='notify_" + p + "' style='text-align: right;>";
        //elements = elements + "</p>";
        //elements = elements + "</div>";

        //var progressBar = document.createElement('div');

        //progressBar.setAttribute('id', 'ProgressBar_' + p);
        //progressBar.setAttribute('class', 'progress-bar progress-bar-striped-active');
        //progressBar.setAttribute('role', 'progressbar');
        //progressBar.setAttribute('aria-valuemin', "0");
        //progressBar.setAttribute('aria-valuemax', "100");
        //progressBar.style.width = "0%";

        ////elements.appendChild(progressBar);

        //DOM.uploadedFiles.innerHTML = elements;

        //DOM.uploadedFiles.appendChild(progressBar);

        //uploadSingleFile(files[p], p);
    }

    function uploadSingleFile(file, index) {

        var fileId = index;

        var ajax = new XMLHttpRequest();

        ajax.upload.addEventListener("progress", function (e) {
            var percent = (e.loaded / e.total) * 100;

        });

    }

    function uploadItemImages() {

        var itemId = 0;
        var colorId = 0;
        var itemCode = null;
        var designId = 0;
        var filePath = "UploadedFiles/ItemImages/";

        itemId = DOM.itemName.getAttribute('data-item-id');
        colorId = DOM.itemColor.options[DOM.itemColor.selectedIndex].value;
        designId = 0; //DOM.fabricDesign.options[DOM.fabricDesign.selectedIndex].value;
        itemCode = DOM.itemName.getAttribute('data-item-code');

        filePath += itemCode + "/";

        if (colorId > 0) {
            filePath += colorId;
        }

        var files = DOM.itemImageUpload.files;

        if (files.length > 0) {

            var oFile = new FormData();

            for (var i = 0; i < files.length; i++) {
                oFile.append(files[i].name, files[i]);
                oFile.append("File_Path", filePath);
                oFile.append("Created_By", parseInt(LOGGED_USER));
                FileName = files[i].name;
            }

            $.ajax({
                url: "../Masters/FileUploader.ashx",
                type: "POST",
                contentType: false,
                processData: false,
                data: oFile,
                success: function (result) {
                    swal("success", "Document Uploaded Successfully.", "success");
                }
            });
        }
    }   
    
    /* ---- public methods ---- */
    function init() {
        cacheDOM();
        bindEvents();
        applyPlugins();
        loadData();
    }

    return {
        init: init
    };

}());


SharpiTech.ItemImage.init();

