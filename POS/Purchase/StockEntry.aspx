<%@ Page Title="Stock Entry" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockEntry.aspx.cs" Inherits="POS.Purchase.StockEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

        <div class="st-content">

        <div class="container-fluid">

    <div class="page-header">
        <h3>Stock Entry</h3>
    </div>

        <!-- START OF EDIT MODE -->

        <div id="EditMode">

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <!-- START OF STOCK ENTRY DETAILS -->

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">OLD STOCK DETAILS</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                    <input type="hidden" id="StockId" />

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Vendor</label>
                                            <select id="Vendor" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Item Name</label>
                                            <select id="Item" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Stock Date</label>
                                            <div class="input-group date input-group-sm" id="StockDatePicker">
                                                <input type="text" id="StockDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Bale No.</label>
                                            <input type="text" id="BaleNo" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Lot No.</label>
                                            <input type="text" id="LotNo" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Purchase Rate</label>
                                            <input type="text" id="PurchaseRate" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Qty (Pcs)</label>
                                            <input type="text" id="ReceivedQtyInPcs" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Qty (Mtrs)</label>
                                            <input type="text" id="ReceivedQtyInMtrs" class="form-control" />
                                        </div>
                                    </div>


                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Goods Storage Location</label>
                                            <select id="Location" class="form-control"></select>
                                        </div>
                                    </div>


                                </div>

                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Financial Year</label>
                                            <select id="FinancialYear" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Branch Name</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                        <div class="panel-footer">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="pull-right">
                                        <button type="button" id="BackToStockList" class="btn btn-default btn-xs">Back to List</button>
                                        <button type="button" id="SaveAndAddNewStockDetails" class="btn btn-primary btn-xs">Save And Add New</button>
                                        <button type="button" id="SaveStockDetails" class="btn btn-primary btn-xs">Save Stock Details</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <!-- END OF STOCK DETAILS -->

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

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                         
                                    <h4 class="panel-title panel-title-align-middle">Old Stock Details</h4>

                                    <div class="pull-right">
                                        
                                        <button type="button" id="AddNewStockItem" class="btn btn-info btn-xs">
                                            <i class="fa fa-plus"></i> Add New
                                        </button>
                                        <button type="button" id="RefreshStockItem" class="btn btn-default btn-xs">
                                            <i class="fa fa-refresh"></i> Refresh
                                        </button>

                                    </div>

                                </div>                                
                                
                            </div>

                        </div>

                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="StockItemList" class="table table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Sr</th>
                                            <th>Lot No.</th>
                                            <th>Stock Date</th>
                                            <th>Item Name</th>
                                            <th>Item Size</th>
                                            <th>Vendor Name</th>
                                            <th>Bale No.</th>
                                            <th>Qty (Pcs)</th>
                                            <th>Qty (Mtrs)</th>                                            
                                            <th>Purchase Rate</th>                                            
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

            </div>

    </div> <!-- ./container -->

    <!-- END OF VIEW MODE -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/purchase/stock-details.js"></script>

</asp:Content>
