<%@ Page Title="Goods Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GoodsReceipt.aspx.cs" Inherits="POS.Purchase.GoodsReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">
            
            <div class="page-header">
                <h3>Goods Receipt</h3>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12">
                
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

                <div class="row">
                    <div class="action-toolbar">
                        <a href="#" id="AddNewGoodsReceipt"><i class="fa fa-plus fa-fw"></i>Add New</a>
                        <a href="#" id="ShowGoodsReceiptList"><i class="fa fa-eye fa-fw"></i>Show List</a>
                        <a href="#" id="ViewGoodsReceipt"><i class="fa fa-eye fa-fw"></i>View</a>
                        <a href="#" id="EditGoodsReceipt"><i class="fa fa-edit fa-fw"></i>Edit</a>
                        <a href="#" id="SaveGoodsReceipt"><i class="fa fa-save fa-fw"></i>Save</a>
                        <a href="#" id="DeleteGoodsReceipt"><i class="fa fa-remove fa-fw"></i>Delete</a>
                        <a href="#" id="PrintGoodsReceipt"><i class="fa fa-print fa-fw"></i>Print</a>
                        <a href="#" id="ExportGoodsReceiptList"><i class="fa fa-cog fa-fw"></i>Export</a>
                    </div>
                </div>

            <!-- START OF EDIT MODE -->


            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <!-- START OF GOODS RECEIPT DETAILS -->

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Goods Receipt Details</h4>
                            </div>

                            <div class="panel-body panel-body-custom-height">

                                <div class="row">

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Vendor</label>
                                                <select id="Vendor" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Purchase Bill No.</label>
                                                <select id="PurchaseBillNo" class="form-control"></select>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Financial Year</label>
                                                <select id="FinancialYear" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Branch Name</label>
                                                <select id="Branch" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Goods Receipt No.</label>
                                                <input type="text" id="GoodsReceiptNo" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Goods Receipt Date</label>
                                                <div class="input-group date input-group-sm" id="GoodsReceiptDatePicker">
                                                    <input type="text" id="GoodsReceiptDate" class="form-control" />
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Location</label>
                                                <select id="Location" class="form-control"></select>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <div class="row">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <div class="panel-body">
                                            <div class="panel panel-info">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title">Receipt Item Details</h4>
                                                </div>

                                                <div class="table-responsive">                                                    
                                                    <table id="GoodsReceiptItemsList" class="table table-condesed">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">Action</th>
                                                                <th>Sr</th>
                                                                <th>Bale No.</th>
                                                                <th>LR No.</th>
                                                                <th>Item Name</th>
                                                                <th>Unit Code</th>
                                                                <th>Purchase Qty</th>
                                                                <th>Received Qty</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>                            
                        </div>

                        <!-- END OF GOODS RECEIPT DETAILS -->

                    </div>

                </div>

            </div>

            <!-- END OF EDIT MODE -->

            <!-- START OF VIEW MODE -->

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h4 class="panel-title">Receipt Items</h4>
                            </div>

                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="GoodsReceiptList" class="table table-condensed">
                                        <thead>
                                            <tr>
                                                <th class="text-center">Action</th>
                                                <th class="text-center">Sr</th>
                                                <th>Vendor Name</th>
                                                <th class="text-center">Purchase Bill No.</th>
                                                <th class="text-center">Goods Receipt No.</th>
                                                <th class="text-center">Goods Receipt Date</th>
                                                <th class="text-right">Total Qty (Pcs)</th>
                                                <th class="text-center">Unit Code</th>
                                                <th>Location</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Page 1 of 5</div>
                            <div class="col-lg-8 col-lg-8 col-sm-8 col-xs-12">
                                <ul class="pagination pagination-sm pull-right">
                                    <li class="page-item">
                                        <a class="page-link" href="#" tabindex="-1">Previous</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>

                </div>

            </div>


            <!-- END OF VIEW MODE -->

        </div>

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/purchase/goods-receipt.js"></script>

</asp:Content>
