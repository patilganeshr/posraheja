<%@ Page Title="Sales Bill Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesBillRegister.aspx.cs" Inherits="POS.MIS.SalesBillRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    
    <div class="st-content">

        
            <div class="action-toolbar">

                <a href="#" id="PrintSalesBillRegister"><i class="fa fa-print fa-fw"></i>Print</a>        
                <a href="#" id="ExportSalesBillRegister"><i class="fa fa-cog fa-fw"></i>Export</a>

            </div>


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


            <div class="page-header">
                <h3>Sales Bill Register</h3>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Report Filter</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <label for="GenerateReport">Generate Report</label>
                                                    <div class="form-group form-group-sm">
                                                        <label class="label-tick">
                                                            <input type="radio" id="ReportByFinancialYear" class="label-radio" name="GenerateReport" checked="checked" value="FinancialYear" />
                                                            <span class="label-text">By Financial Year</span>
                                                        </label>
                                                        <label class="label-tick">
                                                            <input type="radio" id="ReportByCustomer" class="label-radio" name="GenerateReport" value="Vendor" />
                                                            <span class="label-text">By Customer</span>
                                                        </label>
                                                        <label class="label-tick">
                                                            <input type="radio" id="ReportByFromToDate" class="label-radio" name="GenerateReport" value="FromToDate" />
                                                            <span class="label-text">By From - To Date</span>
                                                        </label>
                                                        <label class="label-tick">
                                                            <input type="radio" id="ReportByFinancialYearAndCustomer" class="label-radio" name="GenerateReport" value="FinYearAndVendor" />
                                                            <span class="label-text">By Financial Year and Customer</span>
                                                        </label>
                                                        <label class="label-tick">
                                                            <input type="radio" id="RepotByCustomerAndFromToDate" class="label-radio" name="GenerateReport" value="VendorAndFromToDate" />
                                                            <span class="label-text">By Customer and From - To Date</span>
                                                        </label>
                                                    </div>
                                                </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                           
                                           <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                               <div class="form-group form-group-sm">
                                                   <label>Financial Year</label>
                                                   <select id="FinancialYear" class="form-control"></select>
                                               </div>
                                           </div>

                                           <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                               <div class="form-group form-group-sm">
                                                   <label>Customer</label>
                                                   <select id="Customer" class="form-control"></select>
                                               </div>
                                           </div>

                                           <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>From Date</label>
                                                        <div class="input-group date input-group-sm" id="FromDatePicker">
                                                            <input type="text" id="FromDate" class="form-control" />
                                                            <span class="input-group-addon">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                           <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>To Date</label>
                                                        <div class="input-group date input-group-sm" id="ToDatePicker">
                                                            <input type="text" id="ToDate" class="form-control" />
                                                            <span class="input-group-addon">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label></label>
                                                <button type="button" id="GenerateReport" class="btn btn-info btn-sm">Generate Report</button>
                                            </div>
                                        </div>
                                       </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Report</h4>
                        </div>

                        <div class="panel-body">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <%--<iframe id="ReportArea" style="display:none;"></iframe>--%>
                                <iframe id="txtArea1" style="display:none;"></iframe>

                                    <div class="table-responsive">
                                        
                                        <table id="SalesBillRegisterList" class="table table-condensed">   
                                            <thead>
                                                <tr>
                                                    <th class="text-center">Sales Bill No.</th>
                                                    <th class="text-center">Sales Bill Date</th>
                                                    <th class="text-center">Customer</th>
                                                    <th class="text-center">LR No.</th>
                                                    <th class="text-center">Transporter</th>
                                                    <th class="text-right">Taxable Value</th>
                                                    <th class="text-right">GST Amount</th>
                                                    <th class="text-right">Total Amount</th>
                                                    <th class="text-right">Roun Off Amount</th>
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


    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/mis/Sales-bill-register.js"></script>

</asp:Content>
