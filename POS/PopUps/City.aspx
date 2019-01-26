<%@ Page Title="City Details" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true" CodeBehind="City.aspx.cs" Inherits="POS.PopUps.City" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">
   <!-- CONTAINER START -->

    <div class="container">

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
            <h3>City Details</h3>
        </div>

        <div class="row">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <!-- EDIT MODE -->

                <div id="EditMode">

                    <div class="panel panel-info">

                        <div class="panel-heading">
                            <h4 class="panel-title">City Details </h4>
                        </div>

                        <div class="panel-body">

                            <div class="form-horizontal">

                                <div class="row">
                                                        
                                    <input type="hidden" id="CityId" />

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-lg-4 col-md-4 col-sm-4 col-xs-12">State</label>
                                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                    <select id="State" class="form-control"></select>
                                                </div>
                                            </div>
                                            <div class="form-group form-group-sm">
                                                <label class="control-label col-lg-4 col-md-4 col-sm-4 col-xs-12">City Name</label>
                                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                    <input type="text" id="CityName" class="form-control input-sm" />
                                                </div>
                                            </div>
                                        </div>

                                </div>

                            </div>

                        </div>

                        <div class="panel-footer clearfix">
                            <div class="pull-right">
                                <button type="button" id="SaveCity" class="btn btn-primary btn-sm">Save City</button>
                            </div>
                        </div>
                    </div>

                </div>

                <!-- EDIT MODE -->
            </div>

        </div>

    </div>
    <!-- .container end -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/pop-ups/city.js"></script>

</asp:Content>
