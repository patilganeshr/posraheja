<%@ Page Title="Department" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="POS.Masters.Department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript">
        var LOGGED_USER = '<%=Session["USER_ID"]%>';
        var SERVICE_PATH = "<%= System.Configuration.ConfigurationManager.AppSettings["ServicePath"].ToString() %>";
        var ROOT_PATH = "<%= System.Configuration.ConfigurationManager.AppSettings["rootpath"].ToString() %>";
        var IP_ADDRESS = "<%= Request.ServerVariables["REMOTE_ADDR"] %>";
    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="page-header">
        <h3>Department</h3>
    </div>

    <div class="container">

        <div class="row">

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="panel panel-default">
                    <div class="panel-header">
                        <div class="row panel-body">
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <h4 class="panel-title"></h4>
                                </div>
                                <div class="pull-right">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <button type="button" id="CreateNew" class="btn btn-primary btn-xs">
                                            <i class="fa fa-plus"></i> Create New</button>
                                    </div>
                                </div>
                         
                        </div>
                    </div>
                    <div class="panel-body">
                        <table id="ShowDepartments" class="table table-condesed table-bordered">
                            <thead>
                                <tr>
                                    <th>Sr</th>
                                    <th>Department</th>
                                    <th class="text-center">Action</th>
                                </tr>
                            </thead>
                            <tbody>                                
                            </tbody>
                        </table>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">Page 1 of 5</div>
                            <div class="col-lg-8 col-lg-8 col-sm-8 col-xs-12">
                                <ul class="pagination pagination-sm pull-right">
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

        <!-- modal open -->

        <div id="DepartmentModal" class="modal fade">

            <div class="modal-dialog">

                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Department</h4>
                    </div>

                    <div class="modal-body">
                        <div class="row">
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

                                        <div class="form-group form-group-md">
                                            <label>Department</label>
                                            <input type="text" id="Department" class="form-control input-md" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                    <div class="modal-footer">
                        <button type="button" id="BackToView" class="btn btn-default btn-sm" data-dismiss="modal">Back</button>
                        <button type="button" id="SaveDepartment" class="btn btn-primary btn-sm" data-dismiss="modal">Create Department</button>
                    </div>

                </div>

            </div>

        </div>

        <!-- modal close -->

    </div>

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/Masters/department.js"></script>

</asp:Content>
