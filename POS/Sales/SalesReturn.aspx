<%@ Page Title="Sales Return" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesReturn.aspx.cs" Inherits="POS.Sales.SalesReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">

        .autocomplete {
            /*the container must be positioned relative:*/
            position: absolute;
            display: inline-block;
        }

        .autocomplete-items {
            position: absolute;
            border: 1px solid #d4d4d4;
            border-bottom: none;
            border-top: none;
            z-index: 99;
            /*position the autocomplete items to be the same width as the container:*/
            top: 100%;
            left: 0;
            right: 0;
            overflow: scroll;
        }

            .autocomplete-items div {
                padding: 10px;
                cursor: pointer;
                background-color: #fff;
                border-bottom: 1px solid #d4d4d4;
            }

                .autocomplete-items div:hover {
                    /*when hovering an item:*/
                    background-color: #e9e9e9;
                }

        .autocomplete-active {
            /*when navigating through the items using the arrow keys:*/
            background-color: DodgerBlue !important;
            color: #ffffff;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">

            <div class="page-header">
                <h3>Sales Return</h3>
            </div>

            <div class="row">
                    <div class="action-toolbar">
                        <a href="#" id="AddNewSalesReturnBill"><i class="fa fa-plus fa-fw"></i>Add New</a>
                        <a href="#" id="ShowSalesReturnList"><i class="fa fa-list fa-fw"></i>Show List</a>
                        <a href="#" id="ViewSalesReturnBill"><i class="fa fa-eye fa-fw"></i>View</a>
                        <a href="#" id="EditSalesReturnBill"><i class="fa fa-edit fa-fw"></i>Edit</a>
                        <a href="#" id="SaveSalesReturnBill"><i class="fa fa-save fa-fw"></i>Save</a>
                        <a href="#" id="DeleteSalesReturnBill"><i class="fa fa-remove fa-fw"></i>Delete</a>
                        <a href="#" id="PrintSalesReturnBill"><i class="fa fa-print fa-fw"></i>Print</a>
                        <a href="#" id="FilterSalesReturnBill"><i class="fa fa-filter fa-fw"></i>Filter</a>
                        <a href="#" id="ExportSalesReturnBillList"><i class="fa fa-cog fa-fw"></i>Export</a>
                    </div>
                </div>

            <div class="row">

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

                <!-- START OF EDIT MODE -->

                <div id="EditMode">

                    <div class="row">

                        <div class="panel-body">
                            
                            <!-- Return Bill Details Start -->

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="panel panel-info">

                                    <div class="panel-heading">
                                        <h4 class="panel-title">Sales Return Bill Details</h4>
                                    </div>

                                    <div class="panel-body">

                                        <div class="row">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                                <input type="hidden" id="SalesReturnBillId" value="0" />

                                                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Fin Year</label>
                                                        <select id="FinancialYear" class="form-control"></select>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Company Name</label>
                                                        <select id="CompanyName" class="form-control"></select>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Branch</label>
                                                        <select id="Branch" class="form-control"></select>
                                                    </div>
                                                </div>
                                                
                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Type of Sale</label>
                                                        <select id="TypeOfSale" class="form-control"></select>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Consignee</label>
                                                        <select id="ConsigneeName" class="form-control"></select>
                                                    </div>
                                                </div>
                                                
                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                    <label for="IsSalesReturnBillNoAuto">Is Sales Return Bill No. Auto</label>
                                                    <div class="form-group form-group-sm">
                                                        <label class="label-tick">
                                                            <input type="radio" id="SalesReturnBillNoAuto" class="label-radio" name="IsSalesReturnBillNoAuto" checked="checked" value="Yes" />
                                                            <span class="label-text">Yes</span>
                                                        </label>
                                                        <label class="label-tick">
                                                            <input type="radio" id="SalesReturnBillNoManual" class="label-radio" name="IsSalesReturnBillNoAuto" value="No" />
                                                            <span class="label-text">No</span>
                                                        </label>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Sales Return Bill No.</label>
                                                        <input type="text" id="SalesReturnBillNo" class="form-control" />
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Return Date</label>
                                                        <div class="input-group date input-group-sm" id="SalesReturnBillDatePicker">
                                                            <input type="text" id="SalesReturnBillDate" class="form-control" />
                                                            <span class="input-group-addon">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>Remarks</label>
                                                        <input type="text" id="SalesReturnBillRemarks" class="form-control" />
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                            
                                                

                                            </div>

                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                
                                                
                                                
                                                
                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </div>

                            <!-- Bill Details End -->

                            
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="panel panel-info">
                                    <div class="panel-heading">                                        
                                        <div class="pull-right">
                                            <h3 class="panel-title text-deep-orange-A200">Total Bill Rs. <span id="TotalBillAmount"></span></h3>
                                        </div>

                                        <h4 class="panel-title">Bill Items</h4>
                                    </div>

                                    <div class="row panel-body">

<%--                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            
                                        </div>--%>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="table-responsive">
                                                <table id="SalesReturnBillItemsList" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center col-md-1">Action</th>
                                                            <th class="text-center col-md-2">Item Name</th>
                                                            <th class="text-center col-md-1">Barcode</th>
                                                            <th class="text-center col-md-1">HSN Code</th>
                                                            <th class="text-center col-md-1">Unit Code</th>
                                                            <th class="text-center col-md-1">GST Incl/Excl</th>
                                                            <th class="text-center col-md-1">Return Qty</th>
                                                            <th class="text-center col-md-1">Sale Rate</th>
                                                            <th class="text-center col-md-1">Type of Discount</th>
                                                            <th class="text-center col-md-1">Discount Rate</th>
                                                            <th class="text-center col-md-1">Total Item Amount</th>
                                                            <th class="text-center col-md-2">Item Remarks</th>
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

                            <!-- GST Breakup Section -->
                            
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                <div class="panel panel-info">
                                    <div class="panel-heading">
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
                       
                            <!-- GST Breakup Section -->
                            
                            <!-- Bill Adjustment Section -->
                            
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">Sales Bills</h4>
                                    </div>

                                    <div class="panel-body" style="max-height: 300px; overflow: auto;">

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <ul id="SalesBillsList" class="list-group checked-list-box">
                                                </ul>
                                            </div>
                                        </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

            <!-- EDIT MODE -->

            <!-- VIEW MODE -->

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <!-- START OF SALES RETURN DETAILS -->

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Sales Return</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">
                                        <table id="SalesReturnBillList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Action</th>
                                                    <th>Company Name</th>
                                                    <th>Branch Name</th>
                                                    <th>Sale Type</th>
                                                    <th>Sales Return Bill No.</th>
                                                    <th>Sales Return Bill Date</th>
                                                    <th>Sales Bill No.</th>
                                                    <th>Customer Name</th>
                                                    <th>Consignee Name</th>
                                                    <th>Total Return Qty</th>
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

                    </div>

                </div>

            </div>

            <!-- VIEW MODE -->
        </div>

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/sales/sales-return.js"></script>

</asp:Content>
