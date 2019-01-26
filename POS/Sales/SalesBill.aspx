<%@ Page Title="Cash Sales" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesBill.aspx.cs" Inherits="POS.Sales.SalesBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">


    <div class="st-content">

        <div class="container-fluid">

            <div class="page-header">
                <h3>Cash Sales</h3>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <%--<div id="Loader">

                </div>--%>
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
                        <a href="#" id="AddNewSalesBill"><i class="fa fa-plus fa-fw"></i>Add New</a>
                        <a href="#" id="ShowSalesBillList"><i class="fa fa-list fa-fw"></i>Show List</a>
                        <a href="#" id="ViewSalesBill"><i class="fa fa-eye fa-fw"></i>View</a>
                        <a href="#" id="EditSalesBill"><i class="fa fa-edit fa-fw"></i>Edit</a>
                        <a href="#" id="SaveSalesBill"><i class="fa fa-save fa-fw"></i>Save</a>
                        <a href="#" id="CancelSalesBill" style="display: none;"><i class="fa fa-times fa-fw"></i>Cancel</a>
                        <a href="#" id="DeleteSalesBill"><i class="fa fa-remove fa-fw"></i>Delete</a>
                        <a href="#" id="PrintSalesBill"><i class="fa fa-print fa-fw"></i>Print</a>
                        <a href="#" id="FilterSalesBill"><i class="fa fa-filter fa-fw"></i>Filter</a>
                        <a href="#" id="ExportSalesBillList"><i class="fa fa-cog fa-fw"></i>Export</a>
                        <a href="#" id="ShowItemRate"><i class="fa fa-cog fa-fw"></i>ShowItemRate</a>
                    </div>
                </div>

                <!-- START OF EDIT MODE -->

                <div id="EditMode">

                    <div class="row">

                        <div class="panel panel-carmine" id="SearchPanel">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Search Sales Bill</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Financial Year</label>
                                        <select id="SearchByFinancialYear" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Sale Type</label>
                                        <select id="SearchBySaleType" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Search By Sales Bill No.</label>
                                        <div class="input-group input-group-md">
                                            <input type="text" id="SearchBySalesBillNo" class="form-control" />
                                            <span class="input-group-addon" id="SearchBySalesBillNoButton" style="cursor: pointer;">
                                                <i class="fa fa-search"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Bill Details Start -->

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Bill Details</h4>
                            </div>

                            <div class="panel-body">

                                <div class="row">

                                    <input type="hidden" id="SalesBillId" value="0" />

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Fin Year</label>
                                            <select id="FinancialYear" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Company Name</label>
                                            <select id="CompanyName" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Branch</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Billing Location</label>
                                            <select id="BillingLocation" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Type of Sale</label>
                                            <select id="TypeOfSale" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <label for="IsBillNoAuto">Is Bill No. Auto</label>
                                        <div class="form-group form-group-md">
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

                                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Bill No.</label>
                                            <input type="text" id="BillNo" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Bill Date</label>
                                            <div class="input-group date input-group-md" id="BillDatePicker">
                                                <input type="text" id="BillDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Salesman</label>
                                            <select id="Salesman" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-32 col-xs-12">
                                        <label for="IsTaxInclusive">Is Tax Inclusive</label>
                                        <div class="form-group form-group-md">
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

                        <!-- Bill Details End -->

                        <div class="panel panel-carmine">
                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Bill Items</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-6 col-md-6 col-sm-8 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Scan Barcode Or Search Item</label>
                                            <input type="text" id="ScanBarcode" class="form-control input-md" />
                                        </div>
                                    </div>
                                    <div class="pull-right">
                                        <h3 class="text-deep-orange-A200">Total Bill Rs. <span id="TotalBillAmount"></span></h3>
                                    </div>
                                </div>

                                <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                    
                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">                                                
                                            <div class="form-group form-group-md">
                                                <button type="button" id="DeleteBillItem" class="btn btn-sm btn-danger">Remove Item</button>
                                            </div>
                                        </div>
                                    </div>--%>

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="SalesBillItemsList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Action</th>
                                                    <th class="text-center">Barcode</th>
                                                    <th class="text-center">HSN Code</th>
                                                    <th class="text-center">Item Name</th>
                                                    <th class="text-center">Unit Code</th>
                                                    <th class="text-center">Sale Qty</th>
                                                    <th class="text-center">Rate</th>
                                                    <th class="text-center">Type of Discount</th>
                                                    <th class="text-center">Discount Rate</th>
                                                    <th class="text-center">Taxable Value</th>
                                                    <th class="text-center">GST Rate</th>
                                                    <th class="text-center">GST Amount</th>
                                                    <th class="text-center">Total Item Amount</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                            <tfoot></tfoot>
                                        </table>
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none;">

                        <div class="panel panel-carmine" style="display: none;">
                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">GST Breakup</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="GSTBreakup" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <%--<th class="text-center">Item Name</th>--%>
                                                    <th class="text-center">HSN Code</th>
                                                    <th class="text-center">Taxable Value</th>
                                                    <th class="text-center">GST Rate</th>
                                                    <th class="text-center">SGST</th>
                                                    <th class="text-center">CGST</th>
                                                    <th class="text-center">IGST</th>
                                                    <th class="text-center">Total GST Amount</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                            <tfoot></tfoot>
                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                        <!-- CUSTOMER AND CONSIGNEE DETAILS -->

                    <div class="row">
                        
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                            <div class="panel panel-carmine">
                                <div class="panel-heading panel-heading-carmine">
                                    <h4 class="panel-title">Customer Details</h4>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-md">
                                                <label>Customer</label>
                                                <div class="input-group input-group-md">
                                                    <input type="text" class="form-control input-md" id="CustomerName" />
                                                    <span class="input-group-btn">
                                                        <button type="button" id="AddNewCustomer" name="NewCustomer" class="btn btn-info btn-carmine">
                                                            <i class="fa fa-plus"></i>
                                                        </button>
                                                        <button type="button" id="RefreshCustomerList" name="RefreshCustomer" class="btn btn-default">
                                                            <i class="fa fa-refresh"></i>
                                                        </button>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-md">
                                                <label>Consignee</label>
                                                <div class="input-group input-group-md">
                                                    <input type="text" class="form-control input-md" id="ConsigneeName" />
                                                    <span class="input-group-btn">
                                                        <button type="button" id="AddNewConsignee" name="NewConsignee" class="btn btn-info">
                                                            <i class="fa fa-plus"></i>
                                                        </button>
                                                        <button type="button" id="RefreshConsigneeList" name="RefreshConsignee" class="btn btn-default">
                                                            <i class="fa fa-refresh"></i>
                                                        </button>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- CUSTOMER AND CONSIGNEE DETAILS -->

                        <!-- Payment Details Start -->

                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">

                            <div class="panel panel-carmine">
                                <div class="panel-heading panel-heading-carmine">
                                    <h4 class="panel-title">Payment Details</h4>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                            <input type="hidden" id="SalesBillPaymentId" />

                                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Payment Settlement</label>
                                                    <select id="PaymentSettlement" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Mode of Payment</label>
                                                    <select id="ModeOfPayment" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div id="CashMode" class="panel hide-panel">
                                                        <div class="panel-body">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Cash Amount</label>
                                                                    <input type="text" id="CashAmount" class="form-control" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div id="CreditCardMode" class="panel hide-panel">
                                                        <div class="panel-body">
                                                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Credit Card No.</label>
                                                                    <input type="text" id="CreditCardNo" class="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Credit Card Amount</label>
                                                                    <input type="text" id="CreditCardAmount" class="form-control" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div id="ChequeMode" class="panel hide-panel">
                                                        <div class="panel-body">

                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Cheque No.</label>
                                                                    <input type="text" id="ChequeNo" class="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Cheque Date</label>
                                                                    <input type="text" id="ChequeDate" class="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Bank Name</label>
                                                                    <input type="text" id="ChequeDrawnOn" class="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Cheque Amount</label>
                                                                    <input type="text" id="ChequeAmount" class="form-control" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div id="NetBankingMode" class="panel hide-panel">
                                                        <div class="panel-body">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Net Banking Reference No.</label>
                                                                    <input type="text" id="NetBankingReferenceNo" class="form-control" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                                <div class="form-group form-group-md">
                                                                    <label>Net Banking Amount</label>
                                                                    <input type="text" id="NetBankingAmount" class="form-control" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Payment Remarks</label>
                                                    <textarea id="PaymentRemarks" class="form-control" rows="3"></textarea>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </div>

                        </div>

                        <!-- Payment Details End -->

                        <!-- Delivery Details Start -->

                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">

                            <div class="panel panel-carmine">
                                <div class="panel-heading panel-heading-carmine">
                                    <h4 class="panel-title">Delivery Details</h4>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                            <input type="hidden" id="SalesBillDeliveryId" />

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <label for="IsDeliveryPending">Is Delivery Pending</label>
                                                <div class="form-group form-group-md">
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

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Delivery Date</label>
                                                    <div class="input-group date input-group-md" id="DeliveryDatePicker">
                                                        <input type="text" id="DeliveryDate" class="form-control" />
                                                        <span class="input-group-addon">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Delivery To</label>
                                                    <input type="text" id="DeliveryTo" class="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Delivery Address</label>
                                                    <textarea id="DeliveryAddress" class="form-control" rows="2"></textarea>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Transporter</label>
                                                    <div class="input-group input-group-md">
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
                                                <div class="form-group form-group-md">
                                                    <label>LR No.</label>
                                                    <input type="text" id="LRNo" class="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>LR Date</label>
                                                    <div class="input-group date input-group-md" id="LRDatePicker">
                                                        <input type="text" id="LRDate" class="form-control" />
                                                        <span class="input-group-addon">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Remarks</label>
                                                    <textarea id="DeliveryRemarks" class="form-control" rows="2"></textarea>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <!-- Delivery Details End -->

                    </div>

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

                    <!-- Additional Bill Charges Section Start -->
                    
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <div class="panel panel-carmine">
                                <div class="panel-heading panel-heading-carmine">
                                    <h4 class="panel-title">Additional Charges</h4>
                                </div>
                                <div class="action-toolbar-sub">
                                    <div class="pull-right">
                                        <a href="#" id="AddNewBillCharge"><i class="fa fa-plus fa-fw"></i>New</a>
                                        <a href="#" id="ShowBillChargesList"><i class="fa fa-list fa-fw"></i>List</a>
                                        <a href="#" id="EditBillCharge"><i class="fa fa-edit fa-fw"></i>Edit</a>
                                        <a href="#" id="SaveBillCharge"><i class="fa fa-save fa-fw"></i>Save</a>
                                        <a href="#" id="SaveAndAddNewBillCharge"><i class="fa fa-plus-square fa-fw"></i>Save And Add New</a>
                                        <a href="#" id="DeleteBillCharge"><i class="fa fa-remove fa-fw"></i>Delete</a>
                                    </div>
                                </div>

                                <div class="panel-body">
                                    <div id="BillChargesViewMode">
                                        <div class="row">
                                            <div class="table-responsive">
                                                <table id="BillChargesList" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center">Action</th>
                                                            <th class="text-center">Charge Name</th>
                                                            <th class="text-center">Charge Amount</th>
                                                            <th class="text-center">GST Rate</th>
                                                            <th class="text-center">GST Amount</th>
                                                            <th class="text-center">Total Charge Amount</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody></tbody>
                                                    <tfoot></tfoot>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div id="BillChargesEditMode">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                <input type="hidden" id="SalesBillChargeSrNo" />
                                                <input type="hidden" id="SalesBillChargeId" />

                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                    <div class="form-group form-group-md">
                                                        <label>Charge Name</label>
                                                        <select id="BillChargeName" class="form-control"></select>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-md">
                                                        <label>Charge Amount</label>
                                                        <input type="text" id="BillChargeAmount" class="form-control" />
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-32 col-xs-12">
                                                    <label for="IsTaxInclusive">Is Tax Inclusive</label>
                                                    <div class="form-group form-group-md">
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

                                                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-md">
                                                        <label>GST Rate</label>
                                                        <input type="text" id="BillChargeGSTRate" class="form-control" disabled="disabled" />
                                                    </div>
                                                </div>

                                                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-md">
                                                        <label>GST Amount</label>
                                                        <input type="text" id="BillChargeGSTAmount" class="form-control" disabled="disabled" />
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-md">
                                                        <label>Total Charge Amount</label>
                                                        <input type="text" id="BillChargeTotalAmount" class="form-control" disabled="disabled" />
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    
                    <!-- Additional Bill Charges Section End -->

                    <!-- Search Item Rates Modal Start -->

                        <div id="SearchItemRate" class="modal fade in" tabindex="-1" role="dialog">

                            <div class="modal-dialog">
                            
                                <div class="modal-content">
                                
                                    <div class="modal-header">
                                        <h4 class="modal-title">Search Item Rate</h4>
                                    </div>

                                    <div class="modal-body modal-body-scroll">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div class="form-group form-group-md">
                                                        <label>Search Item</label>
                                                        <input type="text" id="SearchItemForItemRate" class="form-control" />
                                                    </div>
                                                </div>

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div id="ItemsList" class="autocompleteList"></div>
                                                </div>

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                    <div class="table-responsive">
                                                        <table id="ItemRateList" class="table table-condensed">
                                                            <thead>
                                                                <tr>
                                                                    <th>Item Name</th>
                                                                    <th>Wholesale Rate</th>
                                                                    <th>Retail Rate</th>
                                                                    <th>Rate Effective From Date</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody></tbody>
                                                        </table>
                                                    </div>

                                                </div>


                                            </div>
                                        </div>

                                    </div>
                             
                                    <div class="modal-footer">
                                        <button class="btn btn-default btn-sm" data-dismiss="modal" aria-hidden="true" id="CloseSearchItemRate" type="button">Close</button>
                                    </div>

                                </div>
                            </div>
                        </div>

                    <!-- Search Item Rates Modal End-->

                    <!-- Show Item Rates History Modal Start -->

                        <div id="ItemRateHistoryModal" class="modal fade in" tabindex="-1" role="dialog">

                            <div class="modal-dialog">
                            
                                <div class="modal-content">
                                
                                    <div class="modal-header">
                                        <h4 class="modal-title">Item Rate History</h4>
                                    </div>

                                    <div class="modal-body modal-body-scroll">

                                        <div class="row">
                                        
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            
                                                <div class="table-responsive">
                                                        <table id="ItemRateHistoryList" class="table table-condensed">
                                                            <thead>
                                                                <tr>
                                                                    <th>Customer Name</th>
                                                                    <th>Sales Bill No.</th>
                                                                    <th>Sales Bill Date</th>
                                                                    <th>Sale Rate</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody></tbody>
                                                        </table>
                                                    </div>
                                                
                                            </div>
                                        </div>

                                    </div>
                             
                                    <div class="modal-footer">
                                        <button class="btn btn-default btn-sm" data-dismiss="modal" aria-hidden="true" id="CloseItemRateHistoryModal" type="button">Close</button>
                                    </div>

                                </div>
                            </div>
                        </div>

                    <!-- Show Item Rate History Modal End-->

                </div>

                </div>

                <!-- EditMode -->

                <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <!-- START OF CASH SALES DETAILS -->

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Cash Sales</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">
                                        <table id="SalesBillList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Action</th>
                                                    <th>Company Name</th>
                                                    <th>Branch Name</th>
                                                    <th>Bill No.</th>
                                                    <th>Bill Date</th>
                                                    <th>Customer</th>
                                                    <th>Consignee</th>
                                                    <th>Total Qty</th>
                                                    <th>Total Amount</th>
                                                    <th>Year</th>
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

                <!-- ViewMode -->

            </div>

            </div>

        </div>

    </div>
    <!-- .container -->

    <script type="text/javascript" src="../Content/scripts/vendor/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/sales/sales-bill.js"></script>

</asp:Content>
