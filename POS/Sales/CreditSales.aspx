<%@ Page Title="Credit Sales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreditSales.aspx.cs" Inherits="POS.Sales.CreditSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="page-header">
        Credit Sales    
    </div>

    <div class="container">

        <!-- START OF EDIT MODE -->

        <div id="EditMode">
            
            <div class="row">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <!-- START OF CASH SALES DETAILS -->

                <div class="panel panel-info">

                    <div class="panel-heading">
                        <h4 class="panel-title">Credit Sale</h4>
                    </div>

                    <div class="panel-body">

                        <div class="row">

                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Customer</label>
                                        <div class="input-group input-group-sm">
                                            <select id="Customer" class="form-control"></select>
                                            <span class="input-group-btn">
                                                <button type="button" id="AddNewCustomer" class="btn btn-info">
                                                    <i class="fa fa-plus"></i> </button>
                                                <button type="button" id="RefreshCustomerList" class="btn btn-default">
                                                    <i class="fa fa-refresh"></i> </button>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Salesman</label>
                                        <select id="Salesman" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <label for="IsTaxInclusive">Is Tax Inclusive</label>
                                    <div class="form-group">
                                        <label class="lable-tick">
                                            <input type="radio" id="TaxInclusive" class="label-radio" name="IsTaxInclusive" checked="checked" value="Yes" />
                                            <span class="label-text">Yes</span>
                                        </label>
                                        <label class="lable-tick">
                                            <input type="radio" id="TaxExclusive" class="label-radio" name="IsTaxInclusive" value="No" />
                                            <span class="label-text">No</span>
                                        </label>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Sales Order No.</label>
                                        <select id="SalesOrderNo" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Sales Order Date</label>
                                        <input type="text" id="SalesOrderDate" class="form-control" />
                                    </div>
                                </div>

                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Financial Year</label>
                                        <select id="FinancialYear" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Branch</label>
                                        <select id="Branch" class="form-control"></select>
                                    </div>
                                </div>
                                
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Bill No.</label>
                                        <input type="text" id="BillNo" class="form-control" />
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Bill Date</label>
                                        <div class="input-group input-group-sm date" id="BillDatePicker">
                                            <input type="text" id="BillDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>

                </div>

                <div class="panel panel-info">

                    <div class="panel-heading">

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <h4 class="panel-title panel-title-align-middle">Cash Sale Items</h4>

                                <div class="pull-right">
                                    <button type="button" id="AddNewCreditSaleItem" class="btn btn-info btn-xs">
                                        <i class="fa fa-plus"></i> Add Item
                                    </button>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="panel-body">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <div class="table-responsive">
                                <table id="CreditSaleItems" class="table table-condensed">
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

                    <div class="panel-footer">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="pull-right">
                            <button type="button" id="BackToCreditSaleList" class="btn btn-default btn-xs">Back to List</button>
                            <button type="button" id="SaveCreditSale" class="btn btn-primary btn-xs">Save Credit Sales</button>
                        </div>
                            </div>
                        </div>
                    </div>

                </div>

                
            </div>

            </div>
                
        </div>

        <!-- END OF CASH SALES DETAILS -->

        <!-- modal open -->

        <div id="CreditSaleItemModal" class="modal fade">

            <div class="modal-dialog modal-medium">

                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Credit Sale Items</h4>
                    </div>

                    <div class="modal-body">

                        <div class="row">

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <input type="hidden" id="SrNo" />
                                    <input type="hidden" id="SalesBillItemId" />

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Item Name</label>
                                            <select id="ItemName" class="form-control input-sm"></select>
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
                                            <input type="text" id="SaleRate" class="form-control" />
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
                        <button type="button" id="BackToCreditSaleItemList" class="btn btn-default btn-sm" data-dismiss="modal">Back to List</button>
                        <button type="button" id="SaveCreditSaleItem" class="btn btn-primary btn-sm" data-dismiss="modal">Save and Close</button>
                        <button type="button" id="SaveAndAddNewItem" class="btn btn-primary btn-sm">Save and Add New Item</button>
                    </div>

                </div>

            </div>

        </div>

        <!-- modal close -->

        <div id="ViewMode">

            <!-- START OF CASH SALES DETAILS -->

                <div class="panel panel-info">

                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-lg-12 col-md-2 col-sm-12 col-xs-12">
                                <h4 class="panel-title panel-title-align-middle">Credit Sales</h4>

                                <div class="pull-right">
                                    <button type="button" id="CreateNewCreditSale" class="btn btn-info btn-xs"><i class="fa fa-plus"></i> Create New </button>
                                    <button type="button" id="RefreshCreditSale" class="btn btn-default btn-xs"><i class="fa fa-refresh"></i> Refresh </button>
                                    <button type="button" id="Filter" class="btn btn-default btn-xs"><i class="fa fa-filter"></i> Filter </button>                                    
                                </div>

                            </div>
                        </div>
                        
                    </div>

                    <div class="panel-body">

                        <div class="row">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="table-responsive">
                                    <table id="CreditSales" class="table table-condensed">
                                        <thead>
                                            <tr>
                                                <th>Bill No.</th>
                                                <th>Bill Date</th>
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

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/sales/credit-sales.js"></script>


</asp:Content>
