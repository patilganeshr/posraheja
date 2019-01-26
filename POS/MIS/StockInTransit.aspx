<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StockInTransit.aspx.cs" Inherits="POS.MIS.StockInTransit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

        <div class="st-content">

        
            <div class="action-toolbar">

                <a href="#" id="PrintStockInTransitDetails"><i class="fa fa-print fa-fw"></i>Print</a>        
                <a href="#" id="ExportStockInTransitDetails"><i class="fa fa-cog fa-fw"></i>Export</a>

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
                <h3>Stock In Transit</h3>
            </div>

<div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Report</h4>
                        </div>

                        <div class="panel-body">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <iframe id="ReportArea" style="display:none;"></iframe>

                                    <div class="table-responsive">
                                        
                                        <table id="StockInTransitList" class="table table-condensed">   
                                            <thead>
                                                <tr>                                                    
                                                    <th>Vendor Name</th>
                                                    <th>Item Name</th>
                                                    <th>Purchase Bill No.</th>
                                                    <th>Purchase Bill Date</th>                                                    
                                                    <th>Transporter Name</th>
                                                    <th>LR No.</th>                                                    
                                                    <th>Purchase Qty</th>
                                                    <th>Unit Code</th>
                                                    <th>Purchase Rate</th>
                                                    <th>Total Amount</th>
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
    <script type="text/javascript" src="../content/scripts/app/mis/stock-in-transit.js"></script>

</asp:Content>
