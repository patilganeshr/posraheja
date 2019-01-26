<%@ Page Title="Stock Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockAsOnDate.aspx.cs" Inherits="POS.MIS.StockAsOnDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="GenerateStockReport"><i class="fa fa-eye fa-fw"></i>Generate Report</a>
        <a href="#" id="PrintStockReport"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterStockReport"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportStockReport"><i class="fa fa-cog fa-fw"></i>Export</a>

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
                <h3>Stock as on Date</h3>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Stock Report</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <iframe id="txtArea1" style="display:none;"></iframe>

                                    <div class="table-responsive">
                                        <table id="StockReport" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Item Name</th>
                                                    <th>Stock Qty</th>
                                                    <th>Unit Code</th>
                                                    <th>Purchase Cost</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
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
    <script type="text/javascript" src="../content/scripts/app/mis/stock-as-on-date.js"></script>

</asp:Content>
