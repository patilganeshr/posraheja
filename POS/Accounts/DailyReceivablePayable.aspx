<%@ Page Title="Daily Receivable Payable" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DailyReceivablePayable.aspx.cs" Inherits="POS.Accounts.DailyReceivablePayable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddDailyReceivablePayable"><i class="fa fa-plus fa-fw"></i>Add</a>
        <a href="#" id="SaveDailyReceivablePayable"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="PrintDailyReceivablePayable"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="ExportDailyReceivablePayable"><i class="fa fa-cog fa-fw"></i>Export</a>

    </div>
    
    <div class="st-content">

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
                    <h3>Daily Receivable Payable</h3>
                </div>

                <!-- START OF EDIT MODE -->

                <div id="EditMode">

                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <!-- START OF CASH SALES DETAILS -->

                            <div class="panel panel-info">

                                <div class="panel-heading">
                                    <h4 class="panel-title">Recivable/Payable Entry</h4>
                                </div>

                                <div class="panel-body">

                                    <div class="row">

                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Fin Year</label>
                                                    <select id="FinancialYear" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Company</label>
                                                    <select id="Company" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Branch</label>
                                                    <select id="Branch" class="form-control"></select>
                                                </div>
                                            </div>

                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Entry Date</label>
                                                    <div class="input-group date input-group-sm" id="EntryDatePicker">
                                                        <input type="text" id="EntryDate" class="form-control" />
                                                        <span class="input-group-addon">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Particulars</label>
                                                    <input type="text" id="Particulars" class="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Amount</label>
                                                    <input type="text" id="RecPayAmount" class="form-control" />
                                                </div>
                                            </div>

                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Receivable/Payable</label>
                                                    <select id="ReceivablePayable" class="form-control">
                                                        <option value="R">Receivable</option>
                                                        <option value="P">Payable</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="col-lg-7 col-md-7 col-sm-7 col-xs-12">
                                                <div class="form-group form-group-sm">
                                                    <label>Comments</label>
                                                    <input type="text" id="Comments" class="form-control" />
                                                </div>
                                            </div>
                                            
                                        </div>
                                        
                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                            <div class="table-responsive">
                                                <table id="DailyReceivablePayableList" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center col-lg-6 col-md-6 col-sm-6 col-xs-12">Particulars</th>
                                                            <th class="text-center col-lg-2 col-md-2 col-sm-2 col-xs-12">Receivable</th>
                                                            <th class="text-center col-lg-2 col-md-2 col-sm-2 col-xs-12">Payable</th>
                                                            <th class="text-center col-lg-2 col-md-2 col-sm-2 col-xs-12">Action</th>
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
                       
                        <!-- EditMode -->
                    </div>

                </div>

                <%--<div id="ViewMode">

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
                <!-- ViewMode -->--%>


            </div>



    </div>
    <!-- .container -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/accounts/daily-receivable-payable.js"></script>


</asp:Content>
