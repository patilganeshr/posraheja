<%@ Page Title="Sales By Value in Sales Period" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaleByValueInSalesPeriod.aspx.cs" Inherits="POS.MIS.SaleByValueInSalesPeriod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

        <div class="action-toolbar">

        <%--<a href="#" id="GenerateReport"><i class="fa fa-eye fa-fw"></i>Generate Report</a>--%>
        <a href="#" id="PrintReport"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterReport"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportReport"><i class="fa fa-cog fa-fw"></i>Export</a>

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

            <div class="page-header">
                <h3>BRANDWISE - ITEMCATEGORYWISE - ITEMWISE - SALESMANWISE - SALESBILLDATEWISE - SALEVALUE  REPORT</h3>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Report Filters</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Report Filter Options</label>
                                                <div id="ReportFilterOptions" class="well" style="max-height:300px; overflow: auto;">                                                    
                                                </div>
                                            </div>
                                        </div>

                                        
                                        <%--<div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Item Category</label>
                                                <select id="ItemCategory" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Item</label>
                                                <select id="Item" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Salesman</label>
                                                <select id="Salesman" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>From Date</label>
                                                        <div class="input-group date input-group-md" id="FromBillDateDatePicker">
                                                            <input type="text" id="FromBillDate" class="form-control" />
                                                            <span class="input-group-addon">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                       </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                                    <div class="form-group form-group-sm">
                                                        <label>To Date</label>
                                                        <div class="input-group date input-group-md" id="ToBillDateDatePicker">
                                                            <input type="text" id="ToBillDate" class="form-control" />
                                                            <span class="input-group-addon">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                        </div>
                                                    </div>
                                       </div>--%>

                                    </div>

                                    <div class="col-lg-8 col-md-8 col-sm-6 col-xs-12">

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                            <div class="table-responsive">

                                                <table id="ReportFilters" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                            <th>Filter</th>
                                                            <th>Operators</th>
                                                            <th>Value</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody></tbody>
                                                </table>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

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
                            <h4 class="panel-title">Sale In Sales Period</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <iframe id="txtArea1" style="display:none;"></iframe>

                                    <div class="table-responsive">
                                        <table id="ReportDataList" class="table table-condensed">
                                            <%--<thead>
                                                <tr>
                                                    <th>Item Name</th>
                                                    <th>Stock Qty</th>
                                                    <th>Unit Code</th>
                                                    <th>Purchase Cost</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>--%>
                                        </table>
                                        <%--<table id="StockReport" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Item Name</th>
                                                    <th>Item Quality</th>
                                                    <th>Brand Name</th>
                                                    <th>Item Category Name</th>
                                                    <th>Vendor Name</th>
                                                    <th>Qty In Pcs</th>
                                                    <th>Qty In Mtrs</th>
                                                    <th>Location Name</th>
                                                    <th>Category A</th>
                                                    <th>Category C</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>--%>
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/mis/sale-value-report-in-sale-period.js"></script>

</asp:Content>
