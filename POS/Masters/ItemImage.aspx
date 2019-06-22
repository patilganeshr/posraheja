<%@ Page Title="Upload Item Images" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemImage.aspx.cs" Inherits="POS.Masters.ItemImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewItemImage"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowItemImage"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewItemImage"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditItemImage"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SaveItemImage"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeleteItemImage"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="FilterItemImageList"><i class="fa fa-filter fa-fw"></i>Filter</a>

    </div>

    <!-- CONTAINER START -->
    <div class="st-content">

        <div class="container-fluid">

            <div id="Loader" class="loader-container">
                <!--There's the container that centers it-->
                <div class="spinner-frame">
                    <!--The background-->
                    <div class="spinner-cover"></div>
                    <!--The foreground-->
                    <div class="spinner-bar"></div>
                    <!--and the spinny thing-->
                </div>
            </div>

            <div class="page-header text-center">
                <h3>Upload Items Photo's</h3>
            </div>

            <!-- EDIT MODE -->

            <div class="row">

                <div id="EditMode">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Item Details </h4>
                            </div>

                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-md">
                                                <label>Item Name</label>
                                                <input type="text" id="ItemName" class="form-control" autocomplete="off" />
                                            </div>

                                            <div id="ItemsList" class="autocompleteList"></div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                            <div class="form-group form-group-md">
                                                <label>Item Color</label>
                                                <select id="ItemColor" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                            <div class="form-group form-group-md">
                                                <label>Fabric Design</label>
                                                <select id="FabricDesign" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                            <div class="form-group form-group-md">
                                                <%--<input type="file" name="ItemImageUpload" id="ItemImageUpload" class="btn btn-sm btn-default" multiple />--%>
                                                <div class="media v-middle">
                                                    <div class="media-left">
                                                        <div class="icon-block width-100 bg-grey-100">
                                                            <img id="ItemLogoImage" src="#" alt="no image" width="100" height="100" style="display: none;" />
                                                            <i class="fa fa-photo text-light"></i>
                                                        </div>
                                                    </div>
                                                    <div class="media-body">
                                                        <a class="btn btn-sm btn-default pmd-btn-raised" id="UploadItemImage">
                                                            <span class="ink animate"></span>
                                                            Add Image
                                                            <i class="fa fa-upl"></i>
                                                        </a>
                                                        <input type="file" id="ItemImageUpload" name="ItemImage" class="form-control" multiple style="display: none;" />
                                                        <span id="NoOfFilesUploaded" class="help-text"></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>


                            </div>

                        </div>

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Uploaded Images</h4>
                            </div>

                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" id="SliderThumbs">
                                        </div>

                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" id="Slider"></div>
                                        <%--<div class="table-responsive" style="height: 300px; overflow: auto;">

                                        <table id="ItemImageUploadList" class="table table-condesed table-fixed">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Action</th>
                                                    <th class="text-center">Item Name</th>
                                                    <th class="text-center">Item Code</th>
                                                    <th class="text-center">Color</th>
                                                    <th class="text-center">Fabric Design</th>
                                                    <th class="text-center">Images</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>

                                    </div>--%>
                                    </div>

                                </div>

                            </div>


                        </div>

                    </div>

                </div>

                <!-- EDIT MODE -->

                <!-- View Mode -->

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <!-- VIEW MODE -->

                        <div id="ViewMode">

                            <div class="panel panel-info">

                                <div class="panel-heading">
                                    <h4 class="panel-title">List of Items</h4>
                                </div>

                            </div>

                            <div class="panel-body">
                            </div>

                        </div>

                        <!-- VIEW MODE -->

                    </div>

                </div>

                <!-- View Mode -->

            </div>

        </div>
    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/Masters/item-image.js"></script>

</asp:Content>
