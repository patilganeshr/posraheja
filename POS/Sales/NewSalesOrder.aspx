<%@ Page Title="Sales Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewSalesOrder.aspx.cs" Inherits="POS.Sales.NewSalesOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content" style="top: 87px;">

        <div class="container-fluid">

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
                <h3>Sales Order</h3>
            </div>

            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Sales Order Details</h4>
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
                                        <label>Sales Order No.</label>
                                        <input type="text" class="form-control" id="SalesOrderNo" />
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Order Date</label>
                                        <div class="input-group date input-group-md" id="SalesOrderDatePicker">
                                            <input type="text" id="SalesOrderDate" class="form-control" />
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
                                <h4 class="panel-title">Customer Details</h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                                    <div class="form-group form-group-md">
                                        <label>Customer Name</label>
                                        <input type="text" id="CustomerName" class="form-control" />
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="CustomerList" class="autocompleteList"></div>
                                    </div>

                                    <div class="form-group form-group-md">
                                        <label>Address</label>
                                        <textarea id="CustomerAddress" class="form-control" rows="4"></textarea>
                                    </div>

                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Email</label>
                                        <input type="text" class="form-control" id="CustomerEmail" />
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>Contact No.</label>
                                        <input type="text" class="form-control" id="CustomerContactNo" />
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-md">
                                        <label>GST No.</label>
                                        <input type="text" class="form-control" id="CustomerGSTNo" />
                                    </div>
                                </div>

                                <%--<div class="form-group form-group-lg">
                            <label>Customer</label>
                            <div class="input-group input-group-lg">
                                <input type="text" class="form-control input-lg" id="CustomerName" />
                                <span class="input-group-btn">
                                    <button type="button" id="AddNewCustomer" name="NewCustomer" class="btn btn-info btn-carmine">
                                        <i class="fa fa-plus"></i>
                                    </button>
                                    <button type="button" id="RefreshCustomerList" name="RefreshCustomer" class="btn btn-default">
                                        <i class="fa fa-refresh"></i>
                                    </button>
                                </span>
                            </div>
                        </div>--%>
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
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
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

                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                        <div class="form-group form-group-lg">
                                            <input type="text" class="form-control" placeholder="Scan Barcode or Enter Item Name" id="ScanItem" />
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div id="ItemList" class="autocompleteList"></div>
                                    </div>

                                </div>
                                
                                <div class="row">
                                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                        <div class="table-responsive">
                                            <table id="SalesOrderItemsList" class="table">
                                                <thead>
                                                    <tr>
                                                        <th class="table-rows-large">Item Name</th>
                                                        <th class="table-rows-large">Sale Qty</th>
                                                        <th class="table-rows-large">Rate</th>
                                                        <th class="table-rows-large">Discount</th>
                                                        <th class="table-rows-large">Item Total</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td class="table-rows-large">MIX CHADAR-L 90X100 / BED SHEET / SKR</td>
                                                        <td class="table-rows-large">2.00</td>
                                                        <td class="table-rows-large">200.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">400</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="table-rows-large">HARLEY  90X100 / BLANKETS / ROSE PETEL</td>
                                                        <td class="table-rows-large">13.00</td>
                                                        <td class="table-rows-large">575.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">7475</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="table-rows-large">800 GM FLANO BKT 90X100 / BLANKETS / FLANO</td>
                                                        <td class="table-rows-large">6.00</td>
                                                        <td class="table-rows-large">500.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">3000</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="table-rows-large">CEMRA SOFI NAPKIN 16X24 / NAPKINS / SOFI</td>
                                                        <td class="table-rows-large">24.00</td>
                                                        <td class="table-rows-large">90.00</td>
                                                        <td class="table-rows-large">0</td>
                                                        <td class="table-rows-large">2160</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                        <div class="form-group form-group-lg">
                                            <div id="ItemsTotalSummary">
                                                <ul class="list-group">
                                                    <li class="list-group-item list-group-item-large">
                                                        <span class="badge">14</span>
                                                        Subtotal
                                                    </li>
                                                    <li class="list-group-item list-group-item-large">
                                                        <span class="badge">14</span>
                                                        GST
                                                    </li>
                                                    <li class="list-group-item list-group-item-large">
                                                        <span class="badge">14</span>
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

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="pull-right">
                            <div class="form-group">
                                <button type="button" class="btn btn-lg btn-primary" id="SaveSalesOrder">Save Order</button>
                                <button type="button" class="btn btn-lg btn-info" id="SendMail">Send Mail</button>

                            </div>

                        </div>

                    </div>


                </div>

            </div>

        </div>

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/sales/sales-order.js"></script>

</asp:Content>
