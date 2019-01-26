<%@ Page Title="Address Type" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressType.aspx.cs" Inherits="POS.Masters.AddressType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">
        var LOGGED_USER = '<%=Session["USER_ID"]%>';
        var SERVICE_PATH = "<%= System.Configuration.ConfigurationManager.AppSettings["ServicePath"].ToString() %>";
        var ROOT_PATH = "<%= System.Configuration.ConfigurationManager.AppSettings["rootpath"].ToString() %>";
        var IP_ADDRESS = "<%= Request.ServerVariables["REMOTE_ADDR"] %>";
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewAddressType"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowAddressTypeList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewAddressType"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditAddressType"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SaveAddressType"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeleteAddressType"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="PrintAddressTypeList"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterAddresssTypeList"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportAddressTypeList"><i class="fa fa-cog fa-fw"></i>Export</a>

    </div>

    <div class="st-content">

        <div class="container-fluid">

            <div class="page-header">
                <h3>Address Type</h3>
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

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-default">
                            <div class="panel-header">
                                <div class="row panel-body">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <h4 class="panel-title">Address Type List</h4>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="AddressTypeList" class="table table-condesed">
                                        <thead>
                                            <tr>
                                                <th class="text-center">Action</th>
                                                <th>Sr</th>
                                                <th>Address Type</th>                                                
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="panel-footer">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Page 1 of 5</div>
                                    <div class="pull-right">
                                        <div class="col-lg-8 col-lg-8 col-sm-8 col-xs-12">
                                            <ul class="pagination pagination-sm">
                                                <li class="page-item">
                                                    <a class="page-link" href="#" tabindex="-1">Previous</a>
                                                </li>
                                                <li class="page-item"><a class="page-link" href="#">1</a></li>
                                                <li class="page-item"><a class="page-link" href="#">2</a></li>
                                                <li class="page-item"><a class="page-link" href="#">3</a></li>
                                                <li class="page-item"><a class="page-link" href="#">Next</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>

            <!-- View Mode -->
            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h3 class="panel-title"></h3>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label>Address Type</label>
                                            <input type="text" id="AddressType" class="form-control" />
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

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/Masters/address-type.js"></script>

</asp:Content>
