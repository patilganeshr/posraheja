<%@ Page Title="Purchase Daily Activity Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseDailyActivityReport.aspx.cs" Inherits="POS.MIS.PurchaseDailyActivityReport" %>
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
                <h3>Daily Purchase Activity Report</h3>
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

                                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">

                                        <div class="form-group form-group-md">
                                            <label>Report Parameters</label>
                                            <select id="ReportParameters" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="display: none;">

                                        <div class="form-group form-group-md">
                                            <label>Report Filters</label>
                                            <select id="ReportFilters" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">

                                        <div class="form-group form-group-md">
                                            <label>Report Criteria</label>
                                            <input type="text" id="ReportCriteria1" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">

                                        <div class="form-group form-group-md">
                                            <input type="text" id="ReportCriteria2" class="form-control" style="margin-top: 26px;" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">

                                        <div class="form-group form-group-md">
                                            <button type="button" id="AddCriteria" class="btn btn-md btn-info" style="margin-top: 26px;">Add Criteria</button>
                                        </div>
                                    </div>


                                </div>

                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <div class="table-responsive">

                                            <table id="ReportCriteriaList" class="table table-condensed">
                                                <thead>
                                                    <tr>
                                                        <th>Parameter</th>
                                                        <th>Filter</th>
                                                        <th>Value</th>
                                                        <th>Action</th>
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


            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">Daily Purchase Bills</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <iframe id="txtArea1" style="display: none;"></iframe>

                                    <div class="table-responsive">
                                        <table id="ReportDataList" class="table table-condensed">                                            
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
    <script type="text/javascript" src="../content/scripts/app/mis/purchase-daily-activity.js"></script>


</asp:Content>
