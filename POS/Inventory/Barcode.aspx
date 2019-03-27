<%@ Page Title="Barcode Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Barcode.aspx.cs" Inherits="POS.Inventory.Barcode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

        <div class="st-content">

        <div class="container-fluid">

        <div class="page-header text-center">
            <h3>Barcode Details</h3>
        </div>

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

        <div id="EditMode">

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Generate Barcode</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                        <label for="GenerateBarcode">Generate Barcode</label>
                                        <div class="form-group form-group-sm">
                                            <label class="label-tick">
                                                <input type="radio" id="ByInwardNo" class="label-radio" name="GenerateBarcode" checked="checked" value="Yes" />
                                                <span class="label-text">By Inward No.</span>
                                            </label>
                                            <label class="label-tick">
                                                <input type="radio" id="ByItem" class="label-radio" name="GenerateBarcode" value="No" />
                                                <span class="label-text">By Item</span>
                                            </label>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Barcode Size</label>
                                            <select id="BarcodeSize" class="form-control input-sm">
                                                <option value="-1">Choose Barcode Size</option>
                                                <option value="1">Small Size 1X4</option>
                                                <option value="2">Large Size 1X3</option>
                                            </select>
                                        </div>
                                    </div>


                                </div>

                                
                                    

                                <div class="col-lg-6 col-md-6 colsm-12 col-xs-12">
                                
                                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Inward No.</label>
                                            <input type="text" id="InwardNo" class="form-control input-sm" />

                                            <div id="InwardNosList" class="autocompleteList"></div>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="table-responsive">
                                        <table id="BarcodeItemsList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Action</th>
                                                    <th class="text-center">Item Name</th>
                                                    <th class="text-center">No. Of Labels</th>
                                                    <th class="text-center">Label Start No.</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                          
                                        </table>
                                    </div>
                                    </div>

                                </div>

                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Vendor Name</label>
                                            <select id="VendorName" class="form-control input-sm"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Item Name</label>
                                            <select id="ItemName" class="form-control input-sm"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>No. of Labels</label>
                                            <input type="text" id="NoOfLabels" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Label Start No.</label>
                                            <input type="text" id="LabelStartNo" class="form-control" />
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="pull-right">
                                        <button type="button" id="PrintBarcode" class="btn btn-default btn-xs small-font">Print Barcode</button>
                                        <button type="button" id="SaveBarcodeDetails" class="btn btn-primary btn-xs small-font">Save Barcode Details</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

        </div>

            </div>

    </div>
    <!-- .container end -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/Inventory/barcode.js"></script>
    
</asp:Content>
