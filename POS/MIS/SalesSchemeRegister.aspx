<%@ Page Title="Sales Schemes Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesSchemeRegister.aspx.cs" Inherits="POS.MIS.SalesSchemeRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

  <div class="action-toolbar">

        <a href="#" id="GenerateReport"><i class="fa fa-eye fa-fw"></i>Generate Report</a>
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
                <h3>Sales Schemes Register</h3>
            </div>

            <%--<div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Report Filter</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Report Filters</label>
                                                <select id="ReportFilterOption" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Item Name</label>
                                                <select id="Item" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
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
                                        </div>

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

            </div>--%>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <iframe id="txtArea1" style="display:none;"></iframe>

                                    <div class="table-responsive">
                                        <table id="SalesSchemeList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Brand Name</th>
                                                    <th>Item Cateogry Name</th>
                                                    <th>Item Name</th>
                                                    <th>Discount Percent</th>
                                                    <th>Discount Amount</th>
                                                    <th>Max Discount Amount</th>
                                                    <th>Sale Start Date</th>
                                                    <th>Sale End Date</th>
                                                    <th>Branch Name</th>
                                                    <th>Company Name</th>
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

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/mis/sales-scheme-register.js"></script>

</asp:Content>
