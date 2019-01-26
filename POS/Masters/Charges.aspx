<%@ Page Title="Charges" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Charges.aspx.cs" Inherits="POS.Masters.Charges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">

            <div class="page-header text-center">
                <h3>Charges</h3>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12">
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

                    <div class="action-toolbar">

                        <a href="#" id="AddNew"><i class="fa fa-plus fa-fw"></i>Add New</a>
                        <a href="#" id="ShowList"><i class="fa fa-eye fa-fw"></i>Show List</a>
                        <a href="#" id="View"><i class="fa fa-eye fa-fw"></i>View</a>
                        <a href="#" id="Edit"><i class="fa fa-edit fa-fw"></i>Edit</a>
                        <a href="#" id="Save"><i class="fa fa-save fa-fw"></i>Save</a>
                        <a href="#" id="Delete"><i class="fa fa-remove fa-fw"></i>Delete</a>
                        <a href="#" id="Print"><i class="fa fa-print fa-fw"></i>Print</a>
                        <a href="#" id="Export"><i class="fa fa-cog fa-fw"></i>Export</a>

                    </div>

                </div>

                <div class="row">

                    <div id="EditMode">

                        <div class="row">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="panel panel-info">

                                    <div class="panel-heading">
                                        <h5 class="panel-title">Add New Charges</h5>
                                    </div>

                                    <div class="panel-body">

                                        <div class="form-horizontal">

                                            <div class="row">

                                                <div class="col-lg-offset-3 col-md-offset-3 col-sm-offset-2 col-xs-12">

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Charge Name</label>
                                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                                            <input type="text" id="ChargeName" class="form-control" />
                                                        </div>

                                                    </div>

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Charge Desc.</label>
                                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                                            <input type="text" id="ChargeDesc" class="form-control" />
                                                        </div>

                                                    </div>

                                                    <div class="form-group form-group-sm">
                                                        <label class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">GST Category</label>
                                                        <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                                            <select id="GSTCategory" class="form-control"></select>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </div>

                                    </div>


                                </div>
                                <!-- .panel -->

                            </div>

                        </div>

                    </div>
                    <!-- #EditMode -->

                </div>

                <div class="row">

                    <div id="ViewMode">

                        <div class="row">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                <div class="panel panel-info">

                                    <div class="panel-heading">
                                        <h4 class="panel-title">List of Charges </h4>
                                    </div>

                                    <div class="panel-body">

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                            <div class="table-responsive">
                                                <table id="ChargesList" class="table table-condensed">
                                                    <thead>
                                                        <tr>
                                                            <th>Action</th>
                                                            <th>Sr No.</th>
                                                            <th>Charge Name</th>
                                                            <th>Charge Desc.</th>
                                                            <th>GST Category Name</th>
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
                    <!-- #ViewMode -->

                </div>
                <!-- .row -->
            </div>
        </div>


    </div>
    <!-- .container -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/masters/charge.js"></script>

</asp:Content>
