<%@ Page Title="Voucher Sync with Tally" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherSync.aspx.cs" Inherits="POS.Accounts.VoucherSync" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">

            <div class="row">
                <div class="action-toolbar">
                    <a href="#" id="SyncWithTally"><i class="fa fa-save fa-fw"></i>Sync With Tally</a>
                </div>
            </div>

            <div class="page-header">
                <h3>Voucher Sync</h3>
            </div>

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

            <div class="row">

                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                    <div class="panel panel-carmine">

                        <div class="panel-heading panel-heading-carmine">
                            <h4 class="panel-title">Voucher Sync Details</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Voucher Type</label>
                                            <select id="VoucherType" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                        <label for="TransferType">Voucher Sync Option</label>
                                        <div class="form-group form-group-sm">
                                            <label class="label-tick">
                                                <input type="radio" id="FromToVoucherPeriod" class="label-radio" name="VoucherSync" checked="checked" value="FromToPeriod" />
                                                <span class="label-text">From - To Period</span>
                                            </label>
                                            <label class="label-tick">
                                                <input type="radio" id="FromToVoucherNo" class="label-radio" name="VoucherSync" value="FromToVoucherNo" />
                                                <span class="label-text">From - To Bill No.</span>
                                            </label>
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                </div>

                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                    <div class="panel panel-carmine" id="FromToPeriod">
                        <div class="panel-heading panel-heading-carmine">
                            <h4 class="panel-title">From To Period</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
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

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
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

                                </div>

                            </div>

                        </div>

                    </div>

                    <div class="panel panel-carmine hide" id="FromToBillNo">

                        <div class="panel-heading panel-heading-carmine">
                            <h4 class="panel-title">From To Bill No.</h4>
                        </div>

                        <div class="panel-body">

                            <div class="row">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Fin Year</label>
                                            <select id="FinancialYear" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>From Bill No.</label>
                                            <input type="text" id="FromBillNo" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>To Bill No.</label>
                                            <input type="text" id="ToBillNo" class="form-control" />
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

    <!-- .container -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/accounts/voucher-sync.js"></script>

</asp:Content>
