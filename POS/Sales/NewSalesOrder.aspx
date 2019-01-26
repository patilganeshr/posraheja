<%@ Page Title="Sales Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewSalesOrder.aspx.cs" Inherits="POS.Sales.NewSalesOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content" style="top:87px;">

        <div class="container-fluid">

            <%--<div id="Loader" class="loader-container">
                <!--There's the container that centers it-->
                <div class="spinner-frame">
                    <!--The background-->
                    <div class="spinner-cover"></div>
                    <!--The foreground-->
                    <div class="spinner-bar"></div>
                    <!--and the spinny thing-->
                </div>
            </div>--%>

            <div class="page-header text-center">
                <h3>Sales Order</h3>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-carmine">

                        <div class="panel-body">

                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">

                        <div class="form-group form-group-md">
                            <label>Customer Name</label>
                            <input type="text" id="Customer" class="form-control" />
                        </div>
                    
                        <div class="form-group form-group-md">
                            <label>Address</label>
                            <textarea id="CustomerAddress" class="form-control" rows="4"></textarea>
                        </div>

                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <div class="form-group form-group-md">
                            <label>Email</label>
                            <input type="text" class="form-control" id="Email"/>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <div class="form-group form-group-md">
                            <label>Contact No.</label>
                            <input type="text" class="form-control" id="ContactNo" />
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

                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">

                    <div class="panel panel-carmine">

                            <div class="panel-body">
                        
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-lg">
                                            <input type="text" class="form-control" placeholder="Scan Barcode or Enter Item Name" id="ScanItem" />
                                    </div>
                                </div>

                            </div>


                </div>

                </div>

                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">

                    <div class="panel panel-carmine">

                            <div class="panel-body">
                        
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="PurchaseBillItemsList" class="table">
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

                            </div>


                </div>

                </div>

                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                    <div class="panel panel-carmine">
                
                        <div class="panel-body row">
                        
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="form-group form-group-lg">
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

                    <div class="panel panel-carmine">

                        <div class="panel-body">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="form-group form-group-md">
                                    <label>Remarks</label>
                                    <textarea id="Remarks" class="form-control" rows="10"></textarea>
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
                        <button type="button" class="btn btn-lg btn-primary">Save Order</button>
                            <button type="button" class="btn btn-lg btn-info">Send Mail</button>
                        
                        </div>

                        </div>

                </div>


            </div>

        </div>

    </div>

</asp:Content>
