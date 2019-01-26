<%@ Page Title="Sales Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesOrder.aspx.cs" Inherits="POS.Sales.SalesOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="page-header">
        
    </div>

    <div class="container">

        <!-- START OF EDIT MODE -->

        <div class="row">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <!-- START OF SALES ORDER DETAILS -->

                <div id="EditMode" class="panel panel-default">

                    <div class="panel-heading">
                        <h4 class="panel-title">Sales Order</h4>
                    </div>

                    <div class="panel-body panel-body-custom-height">

                        <div class="row">

                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Financial Year</label>
                                        <select id="FinancialYear" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-6 col-md-6 col-sm-8 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Branch</label>
                                        <select id="Branch" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Customer</label>
                                        <select id="Customer" class="form-control"></select>
                                    </div>
                                </div>
                                
                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Order No.</label>
                                        <input type="text" id="OrderNo" class="form-control" />
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Order Date</label>
                                        <div class="input-group input-group-sm date" id="OrderDatePicker">
                                            <input type="text" id="OrderDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div class="row panel-body">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="panel panel-info panel-no-border">
                                    <div class="panel-heading">
                                        <div class="pull-right">
                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <button type="button" id="AddNewItem" class="btn btn-primary btn-xs">
                                                    <i class="fa fa-plus"></i> Add New Item
                                                </button>
                                            </div>
                                        </div>
                                        <h3 class="panel-title">Sales Order Items</h3>
                                    </div>

                                    <div class="row panel-body">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="table-responsive">
                                                <table id="OrderItems" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                            <th>Item Name</th>
                                                            <th>Qty (pcs)</th>
                                                            <th>Qty (mtrs)</th>
                                                            <th>Rate</th>
                                                            <th>Amount</th>
                                                            <th>GST Rate</th>
                                                            <th>GST Amount</th>
                                                            <th>Total Item Amount</th>
                                                            <th>Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody></tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            
                        </div>

                    </div>

                    <div class="panel-footer">
                        <div class="pull-right">
                            <button type="button" id="BackToSalesOrdersList" class="btn btn-default btn-xs">Back to List</button>
                            <button type="button" id="SaveSalesOrder" class="btn btn-primary btn-xs">Save Sales Order</button>
                        </div>
                    </div>

                </div>

                <!-- END IF SALES ORDER DETAILS -->

                <!-- START OF SALES ORDER DETAILS -->

                <div id="ViewMode" class="panel panel-default">

                    <div class="panel-heading">
                        <div class="panel-body">
                            <div class="pull-right">
                                <button type="button" id="CreateNewSalesOrder" class="btn btn-info btn-sm"><i class="fa fa-plus"></i> Create New</button>
                                <button type="button" id="Filter" class="btn btn-default btn-sm"><i class="fa fa-filter"></i> Filter</button>
                                <button type="button" id="ExportToExcel" class="btn btn-default btn-sm"><i class="fa fa-file-excel-o"></i> Export</button>

                            </div>
                        </div>

                        <h4 class="panel-title">Sales Order</h4>
                    </div>

                    <div class="panel-body panel-body-custom-height">

                        <div class="row">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="table-responsive">
                                    <table id="SalesOrders" class="table table-condensed">
                                        <thead>
                                            <tr>
                                                <th>Order No.</th>
                                                <th>Order Date</th>
                                                <th>Customer</th>
                                                <th>Total Qty</th>
                                                <th>Total Amount</th>
                                                <th>Year</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                </div>

                            </div>

                        </div>

                    </div>

                </div>

                <!-- END OF SALES ORDER DETAILS -->

            </div>

        </div>

        <!-- modal open -->

        <div id="OrderItemsModal" class="modal fade">

            <div class="modal-dialog modal-medium">

                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Order Items</h4>
                    </div>

                    <div class="modal-body">
                        <div class="row">

                            <div class="panel-body">

                                <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">

                                    <input type="hidden" id="SrNo" />
                                    <input type="hidden" id="SalesOrderItemId" />

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Item Name</label>
                                            <select id="Item" class="form-control input-sm"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Qty (pcs)</label>
                                            <input type="text" id="QtyInPcs" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Qty (mtrs)</label>
                                            <input type="text" id="QtyInMtrs" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Rate</label>
                                            <input type="text" id="Rate" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Amount</label>
                                            <input type="text" id="Amount" class="form-control" disabled="disabled" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>GST Rate</label>
                                            <input type="text" id="GSTRate" class="form-control" disabled="disabled"/>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>GST Amount</label>
                                            <input type="text" id="GSTAmount" class="form-control" disabled="disabled"/>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Total Item Amount</label>
                                            <input type="text" id="TotalItemAmount" class="form-control" disabled="disabled"/>
                                        </div>
                                    </div>
                                    
                                </div>

                            </div>

                        </div>

                    </div>

                    <div class="modal-footer">
                        <button type="button" id="BackToOrderItemsList" class="btn btn-default btn-sm" data-dismiss="modal">Back to List</button>
                        <button type="button" id="SaveOrderItem" class="btn btn-primary btn-sm" data-dismiss="modal">Save and Close</button>
                        <button type="button" id="SaveAndAddNewItem" class="btn btn-primary btn-sm">Save and Add New Item</button>
                    </div>

                </div>

            </div>

        </div>

        <!-- modal close -->


    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/sales/sales-order.js"></script>


</asp:Content>
