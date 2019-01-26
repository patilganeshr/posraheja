<%@ Page Title="Local Client" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="LocalClient.aspx.cs" Inherits="POS.PopUps.LocalClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div>

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
                <h3>Client Details</h3>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <!-- EDIT MODE -->

                    <div id="EditMode">

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Client Details </h4>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <input type="hidden" id="ClientId" />

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Mobile No.</label>
                                            <input type="text" id="MobileNo" class="form-control input-sm" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Email Id</label>
                                            <input type="text" id="EmailAddress" class="form-control input-sm" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Client Name</label>
                                            <input type="text" id="ClientName" class="form-control input-sm" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>State</label>
                                            <select id="State" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>City</label>
                                            <select id="City" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Area</label>
                                            <input type="text" id="Area" class="form-control input-sm" />
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                    <div class="panel-footer clearfix">
                        <div class="pull-right">
                            <button type="button" id="SaveClient" class="btn btn-primary btn-sm">Save Customer</button>
                        </div>
                    </div>
                </div>

            </div>

            <!-- EDIT MODE -->
        </div>

    </div>

    <!-- .container end -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/pop-ups/local-client.js"></script>

</asp:Content>
