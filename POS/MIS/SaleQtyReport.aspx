<%@ Page Title="Sale Qty Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaleQtyReport.aspx.cs" Inherits="POS.MIS.SaleQtyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="GenerateSaleQtyReport"><i class="fa fa-eye fa-fw"></i>Generate Report</a>
        <a href="#" id="PrintSaleQtyReport"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterSaleQtyReport"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportSaleQtyReport"><i class="fa fa-cog fa-fw"></i>Export</a>

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
                <h3>Sale Qty Report</h3>
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
    
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12" style="display:none;">
                                            <div class="form-group form-group-sm">
                                                <label>Report Filters</label>
                                                <select id="ReportFilterOption" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Company</label>
                                                <div id="Company"></div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Branch</label>
                                                <div id="Branch"></div>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Month</label>
                                                <div id="Month"></div>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>SalesType</label>
                                                <div id ="SalesType"></div>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Unit Code</label>
                                                <div id="UnitCode"></div>
                                            </div>
                                        </div>

                                        <%--<div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Item Category</label>
                                                <select id="ItemCategory" class="form-control"></select>
                                            </div>
                                        </div>--%>

                                        <%--<div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Item Category</label>
                                                <select id="ItemCategory" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Location</label>
                                                <select id="Location" class="form-control"></select>
                                            </div>
                                        </div>--%>

                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display:none;">

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

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Sale Report</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <iframe id="txtArea1" style="display:none;"></iframe>

                                    <div class="table-responsive">
                                    
                                        <div id="PivotTable"></div>

                                    </div>

                                    <div class="table-responsive">
                                        <table id="SaleQtyReport" class="table table-condensed">
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
    <script type="text/javascript" src="../content/scripts/app/mis/sale-qty-report.js"></script>

</asp:Content>
