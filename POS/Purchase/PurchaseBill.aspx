<%@ Page Title="Purchase Bill" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseBill.aspx.cs" Inherits="POS.Purchase.PurchaseBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">

            <div class="row">
                <div class="action-toolbar">
                    <a href="#" id="AddNewPurchaseBill"><i class="fa fa-plus fa-fw"></i>Add New</a>
                    <a href="#" id="ShowPurchaseBillList"><i class="fa fa-list fa-fw"></i>Show List</a>
                    <a href="#" id="ViewPurchaseBill"><i class="fa fa-eye fa-fw"></i>View</a>
                    <a href="#" id="EditPurchaseBill"><i class="fa fa-edit fa-fw"></i>Edit</a>
                    <a href="#" id="SavePurchaseBill"><i class="fa fa-save fa-fw"></i>Save</a>
                    <a href="#" id="DeletePurchaseBill"><i class="fa fa-remove fa-fw"></i>Delete</a>
                    <a href="#" id="PrintPurchasesBill"><i class="fa fa-print fa-fw"></i>Print</a>
                    <a href="#" id="FilterPurchaseBill"><i class="fa fa-filter fa-fw"></i>Filter</a>
                    <a href="#" id="ExportPurchaseillList"><i class="fa fa-cog fa-fw"></i>Export</a>
                </div>
            </div>

            <div class="page-header text-center">
                <h3>Purchase Bill</h3>
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

                        <div class="panel panel-carmine" id="SearchPanel">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Search Purchase Bill</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Financial Year</label>
                                        <select id="SearchByFinancialYear" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Vendor</label>
                                        <select id="SearchByVendor" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Search By Purchase Bill No.</label>
                                        <div class="input-group input-group-sm">
                                            <input type="text" id="SearchByPurchaseBillNo" class="form-control" />
                                            <span class="input-group-addon" id="SearchByPurchaseBillNoButton">
                                                <i class="fa fa-search"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Purchase Bill Details </h4>
                            </div>

                            <div class="panel-body">

                                <input type="hidden" id="PurchaseBillId" value="0" />

                                <div class="row">

                                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Financial Year</label>
                                            <select id="FinancialYear" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Company Name</label>
                                            <select id="CompanyName" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Branch Name</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Vendor</label>
                                            <select id="Vendor" class="form-control"></select>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Purchase Bill No.</label>
                                            <input type="text" id="PurchaseBillNo" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Purchase Bill Date</label>
                                            <div class="input-group date input-group-sm" id="PurchaseBillDatePicker">
                                                <input type="text" id="PurchaseBillDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Transporter</label>
                                            <select id="Transporter" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Challan No.</label>
                                            <input type="text" id="ChallanNo" class="form-control" />
                                        </div>
                                    </div>

                                </div>

                                <div class="row">

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <label for="IsTaxInclusive">Is Tax Inclusive</label>
                                        <div class="form-group form-group-sm">
                                            <label class="lable-tick">
                                                <input type="radio" id="TaxInclusive" class="label-radio" name="IsTaxInclusive" value="Yes" />
                                                <span class="label-text">Yes</span>
                                            </label>
                                            <label class="lable-tick">
                                                <input type="radio" id="TaxExclusive" class="label-radio" name="IsTaxInclusive" checked="checked" value="No" />
                                                <span class="label-text">No</span>
                                            </label>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <label for="IsTaxRoundOff">Is Tax Round Off</label>
                                        <div class="form-group form-group-sm">
                                            <label class="lable-tick">
                                                <input type="radio" id="TaxRoundOffYes" class="label-radio" name="IsTaxRoundOff" value="Yes" />
                                                <span class="label-text">Yes</span>
                                            </label>
                                            <label class="lable-tick">
                                                <input type="radio" id="TaxRoundOffNo" class="label-radio" name="IsTaxRoundOff" checked="checked" value="No" />
                                                <span class="label-text">No</span>
                                            </label>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <label for="IsCompositionBill">Is Composition Bill</label>
                                        <div class="form-group form-group-sm">
                                            <label class="lable-tick">
                                                <input type="radio" id="CompositionBillYes" class="label-radio" name="IsCompositionBill" value="Yes" />
                                                <span class="label-text">Yes</span>
                                            </label>
                                            <label class="lable-tick">
                                                <input type="radio" id="CompositionBillNo" class="label-radio" name="IsCompositionBill" checked="checked" value="No" />
                                                <span class="label-text">No</span>
                                            </label>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <label for="IsSample">Is Sample</label>
                                        <div class="form-group form-group-sm">
                                            <label class="lable-tick">
                                                <input type="radio" id="SampleYes" class="label-radio" name="IsSample" value="Yes" />
                                                <span class="label-text">Yes</span>
                                            </label>
                                            <label class="lable-tick">
                                                <input type="radio" id="SampleNo" class="label-radio" name="IsSample" checked="checked" value="No" />
                                                <span class="label-text">No</span>
                                            </label>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Total GST Amount as per Vendor Bill</label>
                                            <input type="text" id="TotalGSTAmountAsPerVendorBill" class="form-control" />
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                </div>

                            </div>
                            <!-- / .panel-body -->
                        </div>

                    </div>

                </div>
                <!-- / .row -->

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div id="PurchaseBillItem">

                            <div class="panel panel-carmine">

                                <div class="panel-heading panel-heading-carmine">
                                    <h4 class="panel-title">Bill Items</h4>
                                </div>

                                <div class="panel-body">


                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Search Item</label>
                                            <input type="text" id="SearchItem" class="form-control" />
                                        </div>

                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="pull-right">
                                            <h3 class="text-deep-orange-A200">Total Bill Rs. <span id="TotalBillAmount"></span></h3>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="table-responsive table-space">

                                            <table id="PurchaseBillItemList" class="table table-condensed">
                                                <thead>
                                                    <tr>
                                                        <th class="text-center">Action</th>
                                                        <th class="text-center">Bale No.</th>
                                                        <th class="text-center">LR No.</th>
                                                        <th class="text-center">HSN Code</th>
                                                        <th class="text-center">Item Name</th>
                                                        <th class="text-center">Unit Code</th>
                                                        <th class="text-center">Purchase Qty</th>
                                                        <th class="text-center">Purchase Rate</th>
                                                        <th class="text-center">Type of Discount</th>
                                                        <th class="text-center">Discount Rate</th>
                                                        <th class="text-center">Taxable Value</th>
                                                        <th class="text-center">GST Rate</th>
                                                        <th class="text-center">GST Amount</th>
                                                        <th class="text-center">GST Amount as per bill</th>
                                                        <th class="text-center">Adjusted Amount</th>
                                                        <th class="text-center">Total Amount</th>
                                                    </tr>
                                                </thead>
                                                <tbody></tbody>
                                                <tfoot></tfoot>
                                            </table>

                                        </div>
                                    </div>


                                </div>
                                <!-- / .panel-body -->

                            </div>
                            <!-- /. panel -->

                        </div>



                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                        <div class="panel panel-info" style="display: none;">
                            <div class="panel-heading">
                                <h4 class="panel-title">GST Breakup</h4>
                            </div>

                            <div class="panel-body">

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

                <!-- Additional Bill Charges Section Start -->

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

                                    <input type="hidden" id="PurchaseBillChargeSrNo" />
                                    <input type="hidden" id="PurchaseBillChargeId" />

                                    <div class="col-lg-3 col-md-3 col-sm-5 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Charge Name</label>
                                            <select id="BillChargeName" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Charge Amount</label>
                                            <input type="text" id="BillChargeAmount" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <label for="IsTaxInclusive">Is Tax Inclusive</label>
                                        <div class="form-group form-group-sm">
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
                                        <div class="form-group form-group-sm">
                                            <label>GST Rate</label>
                                            <input type="text" id="BillChargeGSTRate" class="form-control" disabled="disabled" />
                                        </div>
                                    </div>

                                    <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>GST Amount</label>
                                            <input type="text" id="BillChargeGSTAmount" class="form-control" disabled="disabled" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Total Charge Amount</label>
                                            <input type="text" id="BillChargeTotalAmount" class="form-control" disabled="disabled" />
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <!-- Additional Bill Charges Section End -->

            </div>

            <!--/ EditMode -->

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Purchase Bills</h4>
                            </div>

                            <div class="action-toolbar-sub">

                                <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                    <div class="form-group form-group-sm">
                                            <div class="input-group date input-group-sm" id="FromDateDatePicker">
                                                <input type="text" id="FromDate" class="form-control" placeholder="From Date">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <div class="form-group form-group-sm">
                                            <div class="input-group date input-group-sm" id="ToDateDatePicker">
                                                <input type="text" id="ToDate" class="form-control" placeholder="To Date">
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="SearchByVendor" class="form-control input-sm" placeholder="Type vendor name first 3 letters" />
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="SearchByPurchaseBillNo" class="form-control input-sm" placeholder="Enter Purchase Bill No." />
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="SearchByItem" class="form-control input-sm" placeholder="Enter Item Name" />
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="NoOfRecordsPerPage" class="form-control input-sm" placeholder="no. of records per page e.g. 10/20/30" />
                                    </div>
                                </div>

                            </div>

                            <div class="panel-body">

                                <div class="table-responsive">

                                    <table id="PurchaseBillList" class="table table-condensed table-fixed">
                                        <thead>
                                            <tr>
                                                <th class="col-xs-1 text-center">Action</th>
                                                <th class="col-xs-1 text-center">Sr No.</th>
                                                <th class="col-xs-3 text-center">Vendor Name</th>
                                                <th class="col-xs-1 text-center">Bill No.</th>
                                                <th class="col-xs-2 text-center">Bill Date</th>
                                                <th class="col-xs-1 text-center">Total Qty</th>
                                                <th class="col-xs-1 text-center">UoM</th>
                                                <th class="col-xs-2 text-center">Total Amount</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>

                                </div>


                            </div>

                        </div>

                        <!-- / panel -->

                    </div>

                </div>
                <!-- / .row -->

            </div>

            <!-- / ViewMode -->

        </div>

    </div>

    <script type="text/javascript" src="../Content/scripts/vendor/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/purchase/purchase-bill.js"></script>

</asp:Content>
