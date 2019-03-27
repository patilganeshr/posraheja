<%@ Page Title="Purchase Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="POS.Purchase.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">

            <div class="row">
                <div class="action-toolbar">
                    <a href="#" id="AddNewPurchaseOrder"><i class="fa fa-plus fa-fw"></i>Add New</a>
                    <a href="#" id="ShowPurchaseOrderList"><i class="fa fa-list fa-fw"></i>Show List</a>
                    <a href="#" id="ViewPurchaseOrder"><i class="fa fa-eye fa-fw"></i>View</a>
                    <a href="#" id="EditPurchaseOrder"><i class="fa fa-edit fa-fw"></i>Edit</a>
                    <a href="#" id="SavePurchaseOrder"><i class="fa fa-save fa-fw"></i>Save</a>
                    <a href="#" id="DeletePurchaseOrder"><i class="fa fa-remove fa-fw"></i>Delete</a>purchase-order.js
                    <a href="#" id="SendMail"><i class="fa fa-envelop fa-fw"></i>Send Mail</a>
                    <a href="#" id="PrintPurchasesOrder"><i class="fa fa-print fa-fw"></i>Print</a>
                    <a href="#" id="FilterPurchaseOrder"><i class="fa fa-filter fa-fw"></i>Filter</a>
                    <a href="#" id="ExportPurchaseOrderList"><i class="fa fa-cog fa-fw"></i>Export</a>
                </div>
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

            <div class="page-header text-center">
                <h3>Purchase Order</h3>
            </div>

            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Purchase Order Details</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-1 col-md-2 col-sm-3 col-xs-12">

                                    <div class="form-group form-group-md">
                                        <label>Fin Year</label>
                                        <select id="FinancialYear" class="form-control"></select>
                                    </div>

                                </div>

                                <div class="col-lg-4 col-md-3 col-sm-4 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Company</label>
                                        <select id="CompanyName" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Branch</label>
                                        <select id="Branch" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Purchase Order No.</label>
                                        <input type="text" class="form-control" id="PurchaseOrderNo" />
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Order Date</label>
                                        <div class="input-group date input-group-md" id="PurchaseOrderDateDatePicker">
                                            <input type="text" id="PurchaseOrderDate" class="form-control" />
                                            <span class="input-group-addon">
                                                <i class="fa fa-calendar"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Vendor</label>
                                        <div class="input-group input-group-md">
                                            <input type="text" class="form-control input-md" id="Vendor" />
                                            <span class="input-group-btn">
                                                <button type="button" id="AddNewVendor" name="NewVendor" class="btn btn-info btn-carmine">
                                                    <i class="fa fa-plus"></i>
                                                </button>
                                                <button type="button" id="RefreshVendorList" name="RefreshVendor" class="btn btn-default">
                                                    <i class="fa fa-refresh"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </div>
                                    
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="VendorList" class="autocompleteList"></div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Vendor Reference No.</label>
                                        <input type="text" class="form-control" id="VendorReferenceNo" />
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Payment Terms</label>
                                        <select id="PaymentTerms" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Days</label>
                                        <input type="text" class="form-control" id="NoOfDaysForPayment" />
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Disc. Rate</label>
                                        <input type="text" class="form-control" id="DiscountRate" />
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Disc. days</label>
                                        <input type="text" class="form-control" id="PaymentDays" />
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Expected Delivery Date</label>
                                        <div class="input-group date input-group-md" id="ExpectedDeliveryDateDatePicker">
                                            <input type="text" id="ExpectedDeliveryDate" class="form-control" />
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

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Item Details</h4>
                            </div>

                            <div class="panel-body">
                                <div class="row">
                                    <%--<div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
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
                                    </div>--%>

                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                        <div class="form-group form-group-lg">
                                            <input type="text" class="form-control" placeholder="Enter Item Name" id="SearchItemName" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-lg">
                                            <button type="button" class="btn btn-info btn-md" id="AddNewItem">Add New Item</button>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="ItemsList" class="autocompleteList"></div>
                                    </div>

                                </div>
                                
                                <div class="row">
                                    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                                        <div class="table-responsive">
                                            <table id="PurchaseOrderItemsList" class="table">
                                                <thead>
                                                    <tr>
                                                        <th class="table-rows-large">Action</th>
                                                        <th class="table-rows-large">No. of Bales</th>
                                                        <th class="table-rows-large">Item Name</th>
                                                        <th class="table-rows-large">Fabric Cut Length</th>
                                                        <th class="table-rows-large">Order Qty</th>
                                                        <th class="table-rows-large">UoM</th>
                                                        <th class="table-rows-large">Order Rate</th>
                                                        <th class="table-rows-large">Discount</th>                                                        
                                                        <th class="table-rows-large">Item Total</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <%--<tr>
                                                        <td class="table-rows-large">MIX CHADAR-L 90X100 / BED SHEET / SKR</td>
                                                        <td class="table-rows-large">2.00</td>
                                                        <td class="table-rows-large">PCS</td>
                                                        <td class="table-rows-large">200.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">400</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="table-rows-large">HARLEY  90X100 / BLANKETS / ROSE PETEL</td>
                                                        <td class="table-rows-large">13.00</td>
                                                        <td class="table-rows-large">PCS</td>
                                                        <td class="table-rows-large">575.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">7475</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="table-rows-large">800 GM FLANO BKT 90X100 / BLANKETS / FLANO</td>
                                                        <td class="table-rows-large">6.00</td>
                                                        <td class="table-rows-large">PCS</td>
                                                        <td class="table-rows-large">500.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">3000</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="table-rows-large">CEMRA SOFI NAPKIN 16X24 / NAPKINS / SOFI</td>
                                                        <td class="table-rows-large">24.00</td>
                                                        <td class="table-rows-large">PCS</td>
                                                        <td class="table-rows-large">90.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">2160</td>
                                                    </tr>--%>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-lg">
                                            <div id="ItemsTotalSummary">
                                                <ul class="list-group">
                                                    <li class="list-group-item list-group-item-large">
                                                        <span class="badge">0</span>
                                                        Subtotal
                                                    </li>
                                                    <li class="list-group-item list-group-item-large">
                                                        <span class="badge">0</span>
                                                        GST
                                                    </li>
                                                    <li class="list-group-item list-group-item-large">
                                                        <span class="badge">0</span>
                                                        Total
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>


                        </div>

                    </div>

                    <%--<div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                  
                    <div class="panel panel-carmine">
                
                        <div class="panel-body row">
                        
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-md">
                                                    <label>Mode of Payment</label>
                                                    <select id="ModeOfPayment" class="form-control">
                                                        <option value="Cash" selected="selected">Cash</option>
                                                        <option value="Cheque">Cheque</option>
                                                        <option value="Credit Card">Credit Card</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="row">
                                                    <div id="CashMode" class="panel hide-panel">
                                                        <div class="panel-body">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="form-group form-group-sm">
                                                                    <label>Cash Amount</label>
                                                                    <input type="text" id="CashAmount" class="form-control" />
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
                    --%>
                </div>

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="form-group form-group-md">
                                        <label>Remarks</label>
                                        <textarea id="OrderRemarks" class="form-control" rows="10"></textarea>
                                    </div>

                                </div>


                            </div>
                        </div>

                    </div>

                </div>

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-body">

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                                    <div class="form-group form-group-md">
                                        <label>Upload Document</label>
                                        <input type="file" id="UploadDocument" class="form-control" />
                                    </div>

                                </div>

                            </div>
                        </div>

                    </div>

                </div>

                
            </div>

            <!-- /EditMode -->

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            
                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Purchase Order</h4>
                            </div>

                            <div class="action-toolbar-sub">
                            
                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <select id="FilterOption" class="form-control">
                                            <option value="-1">Please Select</option>
                                            <option value="1">Todays Orders</option>
                                            <option value="2">Search By Vendor</option>
                                            <option value="3">Search By Period</option>
                                            <option value="4">Search By Vendor Ref. No.</option>
                                            <option value="5">Search By Vendor and Period</option>
                                        </select>
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <select id="FilterYear" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="SearchByFilterVendor" class="form-control input-sm" placeholder="Type vendor name first 3 letters"/>
                                    </div>
                                </div>
                                
                                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="SearchByFromDate" class="form-control input-sm" placeholder="Enter date e.g. 01/Apr/2018"/>
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <input type="text" id="SearchByToDate" class="form-control input-sm" placeholder="Enter date e.g. 30/Apr/2018" />
                                    </div>
                                </div>

                            </div>

                            <div class="panel-body">

                                    
                                    <div class="table-responsive">

                                        <table id="PurchaseOrderList" class="table table-condensed table-fixed">
                                        <thead>
                                            <tr>
                                                <th class="col-sm-1 text-center">Action</th>
                                                <th class="col-sm-1 text-center">P.O. No.</th>
                                                <th class="col-sm-1 text-center">P.O. Date</th>
                                                <th class="col-sm-2 text-center">Vendor</th>
                                                <th class="col-sm-1 text-center">Ref. No.</th>                                                
                                                <th class="col-sm-1 text-center">Total Bales</th>
                                                <th class="col-sm-1 text-center">Total Order Qty</th>
                                                <th class="col-sm-1 text-center">UoM</th>
                                                <th class="col-sm-1 text-center">Total Amount</th>
                                                <th class="col-sm-2 text-center">Status</th>
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

        </div>

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/purchase/purchase-order.js"></script>

</asp:Content>
