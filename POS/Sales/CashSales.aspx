<%@ Page Title="Cash Sales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CashSales.aspx.cs" Inherits="POS.Sales.CashSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">


    <div class="action-toolbar" style="display:none;">

        <a href="#" id="AddNew"><i class="fa fa-plus fa-fw"></i>Add New</a>
        <a href="#" id="ShowList"><i class="fa fa-list fa-fw"></i>Show List</a>
        <a href="#" id="View"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="Edit"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="Save"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="Delete"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="Print"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="Filter1"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="Export"><i class="fa fa-cog fa-fw"></i>Export</a>

    </div>


    <div class="st-content">

        <div class="container-fluid">

                <div class="page-header text-center">
                    <h3>Cash Sales</h3>
                </div>

                <!-- START OF EDIT MODE -->

                <div id="EditMode">

                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <!-- START OF CASH SALES DETAILS -->

                            <div class="panel panel-info">

                                <div class="panel-heading">
                                    <h4 class="panel-title">Bill Details</h4>
                                </div>

                                <div class="panel-body">

                                    <div class="row">

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Fin Year</label>
                                                    <select id="FinancialYear" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Branch</label>
                                                    <select id="Branch" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Type of Sale</label>
                                                    <select id="TypeOfSale" class="form-control"></select>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="IsBillNoAuto">Is Bill No. Auto</label>
                                                <div class="form-group form-group-sm">                                                    
                                                    <label class="label-tick">
                                                        <input type="radio" id="BillNoAuto" class="label-radio" name="IsBillNoAuto" checked="checked" value="Yes" />
                                                        <span class="label-text">Yes</span>
                                                    </label>
                                                    <label class="label-tick">
                                                        <input type="radio" id="BillNoManual" class="label-radio" name="IsBillNoAuto" value="No" />
                                                        <span class="label-text">No</span>
                                                    </label>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Bill No.</label>
                                                    <input type="text" id="BillNo" class="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Bill Date</label>
                                                    <div class="input-group date input-group-sm" id="BillDatePicker">
                                                        <input type="text" id="BillDate" class="form-control" />
                                                        <span class="input-group-addon">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Salesman</label>
                                                    <select id="Salesman" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <label for="IsTaxInclusive">Is Tax Inclusive</label>
                                                <div class="form-group form-group-sm">                                                    
                                                    <label class="label-tick">
                                                        <input type="radio" id="TaxInclusive" class="label-radio" name="IsTaxInclusive" checked="checked" value="Yes" />
                                                        <span class="label-text">Yes</span>
                                                    </label>
                                                    <label class="label-tick">
                                                        <input type="radio" id="TaxExclusive" class="label-radio" name="IsTaxInclusive" value="No" />
                                                        <span class="label-text">No</span>
                                                    </label>
                                                </div>
                                            </div>
                                        
                                        </div>

                                    </div>

                                </div>

                            </div>

                        </div>

                        <!-- START OF CUSTOMER DETAILS -->

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="panel panel-info">

                                    <div class="panel-heading">
                                        <h4 class="panel-title">Customer Details</h4>
                                    </div>

                                    <div class="panel-body">

                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                                        
                                                    <div class="form-group form-group-sm">
                                                        <label>Customer</label>
                                                            <div class="input-group input-group-sm">
                                                                <select id="Customer" class="form-control"></select>
                                                                <span class="input-group-btn">
                                                                    <button type="button" id="AddNewCustomer" name="NEW_CUSTOMER" class="btn btn-info">
                                                                        <i class="fa fa-plus"></i>
                                                                    </button>
                                                                    <button type="button" id="RefreshCustomerList" name="REFRESH_CUSTOMER" class="btn btn-default">
                                                                        <i class="fa fa-refresh"></i>
                                                                    </button>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="form-group form-group-sm">
                                                        <label>Address</label>
                                                            <textarea id="CustomerAddress" rows="2" class="form-control input-sm"></textarea>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="form-group form-group-sm">
                                                            <label>Consignee</label>                                                        
                                                            <div class="input-group input-group-sm">
                                                                <select id="Consignee" class="form-control"></select>
                                                                <span class="input-group-btn">
                                                                    <button type="button" id="AddNewConsignee" name="NEW_CONSIGNEE" class="btn btn-info">
                                                                        <i class="fa fa-plus"></i>
                                                                    </button>
                                                                    <button type="button" id="RefreshConsigneeList" name="REFRESH_CONSIGNEE" class="btn btn-default">
                                                                        <i class="fa fa-refresh"></i>
                                                                    </button>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="form-group form-group-sm">
                                                            <label>Address</label>                                                        
                                                            <textarea id="ConsigneeAddress" rows="2" class="form-control input-sm"></textarea>
                                                        </div>
                                                    </div>

                                                </div>

                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                        <label>Transporter</label>
                                                            <div class="input-group input-group-sm">
                                                                <select id="Transporter" class="form-control"></select>
                                                                <span class="input-group-btn">
                                                                    <button type="button" id="AddNewTransporter" name="NEW_TRANSPORTER" class="btn btn-info">
                                                                        <i class="fa fa-plus"></i>
                                                                    </button>
                                                                    <button type="button" id="RefreshTransporterList" name="REFRESH_TRANSPORTER" class="btn btn-default">
                                                                        <i class="fa fa-refresh"></i>
                                                                    </button>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>LR No.</label>                                                        
                                                            <input type="text" id="LRNo" class="form-control" />
                                                        </div>
                                                    </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>LR Date</label>                                                        
                                                            <div class="input-group date input-group-sm" id="LRDatePicker">
                                                                <input type="text" id="LRDate" class="form-control" />
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Delivery Date</label>                                                        
                                                            <div class="input-group date input-group-sm" id="DeliveryDatePicker">
                                                                <input type="text" id="DeliveryDate" class="form-control" />
                                                                <span class="input-group-addon">
                                                                    <i class="fa fa-calendar"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                        <label for="IsDeliveryPending">Is Delivery Pending</label>                                                        
                                                    <div class="form-group form-group-sm">
                                                            <label class="lable-tick">
                                                                <input type="radio" id="DeliveryPendingYes" class="label-radio" name="IsDeliveryPending" value="Yes" />
                                                                <span class="label-text">Yes</span>
                                                            </label>
                                                            <label class="lable-tick">
                                                                <input type="radio" id="DeliveryPendingNo" class="label-radio" name="IsDeliveryPending" checked="checked" value="No" />
                                                                <span class="label-text">No</span>
                                                            </label>
                                                        </div>
                                                    </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Remarks</label>                                                        
                                                            <textarea id="DeliveryRemarks" class="form-control" rows="2"></textarea>
                                                        </div>
                                                    </div>

                                        </div>
                                            </div>


                                </div>

                            </div>

                        <!-- END OF CUSTOMER DETAILS -->

                        <!-- MODAL OPEN -->

                        <div id="ClientModal" class="modal fade">

                            <div class="modal-dialog modal-medium">

                                <div class="modal-content">

                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">Client Details</h4>
                                    </div>

                                    <div class="modal-body modal-body-scroll">

                                        <div class="row">

                                            <div class="panel-body">

                                                <iframe id="ClientDetails"></iframe>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" id="CloseClientModal" class="btn btn-default btn-sm btn-rounded" data-dismiss="modal">Close</button>
                                    </div>

                                </div>

                            </div>

                        </div>

                        <!-- MODAL CLOSE -->
                                                
                        <!-- START OF DELIVERY AND PAYMENT DETAILS -->

                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="display:none;">

                                <div class="panel panel-info">

                                    <div class="panel-heading">
                                        <h4 class="panel-title">Delivery Details</h4>
                                    </div>

                                    <div class="panel-body">

                                        <div class="form-horizontal">

                                            <div class="row">

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                    
                                                </div>

                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </div>

                        <!-- END OF DELIVERY DETAILS -->

                        <!-- START OF SALES BILL ITEMS DETAILS -->

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div id="SalesBillItemsViewMode">

                                    <div class="panel panel-info">

                                        <div class="panel-heading">

                                            <div class="row">

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                    <h4 class="panel-title panel-title-align-middle">Sale Items</h4>

                                                    <div class="pull-right">
                                                        <button type="button" id="AddNewSalesBillItem" class="btn btn-info btn-xs">
                                                            <i class="fa fa-plus"></i>Add Item
                                                        </button>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="panel-body">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                <div class="table-responsive">
                                                    <table id="SalesBillItems" class="table table-condensed">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">Item Name</th>
                                                                <th class="text-center">Qty (pcs)</th>
                                                                <th class="text-center">Qty (mtrs)</th>
                                                                <th class="text-center">Rate</th>
                                                                <%--<th class="text-center">Amount</th>--%>
                                                                <th class="text-center">CD/RD</th>
                                                                <th class="text-center">After CD/RD Amt</th>
                                                                <th class="text-center">Amount Before Tax</th>
                                                                <th class="text-center">GST Rate</th>
                                                                <th class="text-center">GST Amount</th>
                                                                <th class="text-center">Total Item Amount</th>
                                                                <th class="text-center">Action</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody></tbody>
                                                        <tfoot></tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <div id="SalesBillItemsEditMode">

                                    <div class="panel panel-info">

                                        <div class="panel-heading">

                                            <h4 class="panel-title panel-title-align-middle">Add Sale Items</h4>

                                        </div>

                                        <div class="panel-body">

                                            <div class="form-horizontal">

                                                <div class="row">

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                        <input type="hidden" id="SrNo" />
                                                        <input type="hidden" id="SalesBillItemId" />

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Scan Barcode</label>
                                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                                <input type="text" id="Barcode" class="form-control input-sm" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Item Name</label>
                                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                                <input type="text" id="BarcodeItem" class="form-control input-sm" list="ItemDataList" />
                                                                <datalist id="ItemDataList"></datalist>
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm" style="display:none;">
                                                            <label class="col-lg-4 col-md-4 col-sm-1 col-xs-12 control-label"></label>
                                                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                                                                <p>Select Item from the below List if item is not barcoded or no barcode is present</p>
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm" style="display:none;">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Non-Barcoded Item Name</label>
                                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                                <select id="ItemName" class="form-control input-sm"></select>
                                                            </div>
                                                        </div>


                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Qty (pcs)</label>
                                                            <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                                <input type="text" id="QtyInPcs" class="form-control" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 control-label">Qty (mtrs)</label>
                                                            <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                                <input type="text" id="QtyInMtrs" class="form-control" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 control-label">Rate</label>
                                                            <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                                <input type="text" id="SaleRate" class="form-control" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 control-label">Type of Discount</label>
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <button type="button" id="ShowDiscount" class="btn btn-info btn-sm">Show Discount</button>
                                                                <button type="button" id="ShowTaxDetails" class="btn btn-info btn-sm">Show Tax Details</button>
                                                            </div>
                                                        </div>

                                                        <div id="DiscountDetails" class="is-not-visible">

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 control-label">Type of Discount</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <select id="TypeOfDiscount" class="form-control input-sm"></select>
                                                                </div>
                                                            </div>


                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 control-label">Cash Discount (%)</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="CashDiscountPercent" class="form-control" />
                                                                </div>
                                                            </div>


                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Cash Discount Amt</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="CashDiscountAmt" class="form-control" readonly="readonly" />
                                                                </div>
                                                            </div>


                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Rate Difference</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="RateDifference" class="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 control-label">Rate Adjustment</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <select id="RateAdjustment" class="form-control input-sm"></select>
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 control-label">Rate Adjustment Remarks</label>
                                                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                                    <input type="text" id="RateAdjustmentRemarks" class="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 control-label">Rate after CD/RD</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="RateAfterCDRD" class="form-control" disabled="disabled" />
                                                                </div>
                                                            </div>



                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 control-label">Amount (Qty X Rate)</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="Amount" class="form-control" disabled="disabled" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div id="TaxDetails" class="is-not-visible">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Amount Before Tax</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="AmountBeforeTax" class="form-control" disabled="disabled" />
                                                                </div>
                                                            </div>


                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">GST Rate</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="GSTRate" class="form-control" disabled="disabled" />
                                                                </div>
                                                            </div>


                                                            <div class="form-group form-group-sm">
                                                                <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">GST Amount</label>
                                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                    <input type="text" id="GSTAmount" class="form-control" disabled="disabled" />
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Total Item Amount</label>
                                                            <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                <input type="text" id="TotalItemAmount" class="form-control" disabled="disabled" />
                                                            </div>
                                                        </div>


                                                    </div>

                                                </div>

                                            </div>

                                        </div>

                                        <div class="panel-footer clearfix">
                                            <div class="pull-right">
                                                <button type="button" id="BackToSalesBillItemsList" class="btn btn-default btn-sm" data-dismiss="modal">Back to Bill Items</button>
                                                <button type="button" id="SaveSalesBillItem" class="btn btn-primary btn-sm" data-dismiss="modal">Save and Close</button>
                                                <button type="button" id="SaveAndAddNewItem" class="btn btn-primary btn-sm">Save and Add New Item</button>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </div>
                        
                        <!-- END OF SALES BILL ITEMS DETAILS -->

                        <!-- START OF PAYMENT DETAILS -->

                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                <div class="panel panel-info">

                                    <div class="panel-heading">
                                        <h4 class="panel-title">Payment Details</h4>
                                    </div>

                                    <div class="panel-body">

                                        <div class="form-horizontal">

                                            <div class="row">

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Payment Settlement</label>
                                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                            <select id="PaymentSettlement" class="form-control"></select>
                                                        </div>
                                                    </div>

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Mode of Payment</label>
                                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                            <select id="ModeOfPayment" class="form-control"></select>
                                                        </div>
                                                    </div>


                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Payment Reference No.</label>
                                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                            <input type="text" id="PaymentReferenceNo" class="form-control" />
                                                        </div>
                                                    </div>

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Remarks</label>
                                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                                                            <textarea id="PaymentRemarks" class="form-control" rows="3"></textarea>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </div>

                        <!-- END OF DELIVERY AND PAYMENT DETAILS -->

                        <!-- START OF BILL CHARGES DETAILS -->

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div id="BillChargesViewMode">

                                    <div class="panel panel-info">

                                        <div class="panel-heading">

                                            <div class="row">

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                    <h4 class="panel-title panel-title-align-middle">Additional Charges</h4>

                                                    <div class="pull-right">
                                                        <button type="button" id="AddNewBillCharge" class="btn btn-info btn-xs">
                                                            <i class="fa fa-plus"></i>Add Charge
                                                        </button>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="panel-body">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                <div class="table-responsive">
                                                    <table id="BillCharges" class="table table-condensed">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">Charge Name</th>
                                                                <th class="text-center">Charge Amount</th>
                                                                <th class="text-center">GST Rate</th>
                                                                <th class="text-center">GST Amount</th>
                                                                <th class="text-center">Total Charge Amount</th>
                                                                <th class="text-center">Action</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody></tbody>
                                                        <tfoot></tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                                <div id="BillChargesEditMode">

                                    <div class="panel panel-info">

                                        <div class="panel-heading">

                                            <h4 class="panel-title panel-title-align-middle">Bill Charges</h4>

                                        </div>

                                        <div class="panel-body">

                                            <div class="form-horizontal">

                                                <div class="row">

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                        <input type="hidden" id="SalesBillChargeSrNo" />
                                                        <input type="hidden" id="SalesBillChargeId" />

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Charge Name</label>
                                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                                <select id="BillChargeName" class="form-control"></select>
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Charge Amount</label>
                                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                                <input type="text" id="BillChargeAmount" class="form-control" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label" for="IsTaxInclusive">Is Tax Inclusive</label>
                                                            <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                                <label class="label-tick">
                                                                    <input type="radio" id="BillChargeTaxInclusive" class="label-radio" name="IsBillChargeTaxInclusive" checked="checked" value="Yes" />
                                                                    <span class="label-text">Yes</span>
                                                                </label>
                                                                <label class="label-tick">
                                                                    <input type="radio" id="BillChargeTaxExclusive" class="label-radio" name="IsBillChargeTaxInclusive" value="No" />
                                                                    <span class="label-text">No</span>
                                                                </label>
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">GST Rate</label>
                                                            <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                                <input type="text" id="BillChargeGSTRate" class="form-control" disabled="disabled" />
                                                            </div>
                                                        </div>


                                                        <div class="form-group form-group-sm">
                                                            <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">GST Amount</label>
                                                            <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                                <input type="text" id="BillChargeGSTAmount" class="form-control" disabled="disabled" />
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-4 col-md-4 col-sm-4 col-xs-12 control-label">Total Charge Amount</label>
                                                        <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                            <input type="text" id="BillChargeTotalAmount" class="form-control" disabled="disabled" />
                                                        </div>
                                                    </div>


                                                </div>

                                            </div>

                                        </div>

                                        <div class="panel-footer clearfix">
                                            <div class="pull-right">
                                                <button type="button" id="BackToBillChargesList" class="btn btn-default btn-sm" data-dismiss="modal">Back to Bill Charges</button>
                                                <button type="button" id="SaveBillCharges" class="btn btn-primary btn-sm" data-dismiss="modal">Save and Close</button>
                                                <button type="button" id="SaveAndAddNewBillCharge" class="btn btn-primary btn-sm">Save and Add New Charge</button>
                                            </div>
                                        </div>

                                    </div>

                                </div>

                            </div>

                        <!-- END OF BILL CHARGES DETAILS -->


                            <div class="form-group form-group-sm">
                                <label class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Remarks</label>
                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                                    <textarea id="BillRemarks" class="form-control" rows="3"></textarea>
                                </div>
                            </div>
                        
                            <div class="panel-body">
                                <div class="pull-right">
                                    <button type="button" id="BackToSalesBillsList" class="btn btn-default btn-sm">Back to List</button>
                                    <button type="button" id="SaveSalesBill" class="btn btn-primary btn-sm">Save Sales Bill</button>
                                    <button type="button" id="PrintSalesBill" class="btn btn-info btn-sm">Print Bill</button>
                                </div>
                            </div>

                        <!-- EditMode -->
                    </div>

                </div>

                <div id="ViewMode">

                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <!-- START OF CASH SALES DETAILS -->

                            <div class="panel panel-info">

                                <div class="panel-heading">
                                    <h4 class="panel-title panel-title-align-middle">Cash Sales</h4>

                                    <div class="pull-right">
                                        <button type="button" id="CreateNewSalesBill" class="btn btn-info btn-xs"><i class="fa fa-plus"></i>Create New </button>
                                        <button type="button" id="RefreshSalesBill" class="btn btn-default btn-xs"><i class="fa fa-refresh"></i>Refresh </button>
                                        <button type="button" id="Filter" class="btn btn-default btn-xs"><i class="fa fa-filter"></i>Filter </button>
                                    </div>

                                </div>

                                <div class="panel-body">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <div class="table-responsive">
                                            <table id="SalesBillsDetails" class="table table-condensed">
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

                            <!-- END OF SALES ORDER DETAILS -->

                        </div>

                    </div>

                </div>
                <!-- ViewMode -->


            </div>



    </div>
    <!-- .container -->

    <script type="text/javascript" src="../Content/scripts/vendor/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/sales/cash-sales.js"></script>


</asp:Content>
