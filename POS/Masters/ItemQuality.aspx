<%@ Page Title="Item Quality" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemQuality.aspx.cs" Inherits="POS.Masters.ItemQuality" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewItemQuality"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowItemQualityList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewItemQuality"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditItemQuality"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SaveItemQuality"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeleteItemQuality"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="PrintItemQuality"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterItemQuality"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportItemQualityList"><i class="fa fa-cog fa-fw"></i>Export</a>

    </div>

    <div class="st-content">

        <div class="container-fluid">

            <div class="page-header">
                <h3>Item Quality</h3>
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

                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h4 class="panel-title">List of Item Quality</h4>
                            </div>

                            <div class="panel-body">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="ItemQualityList" class="table table-condesed">
                                            <thead>
                                                <tr>
                                                    <th class="col-xs-2">Action</th>
                                                    <th class="col-xs-2">Sr</th>
                                                    <th class="col-xs-3">Item Quality</th>                                                    
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
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

            </div>

            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Edit Item Quality</h4>
                            </div>
                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">

                                        <div class="form-group form-group-sm">
                                            <label>Item Quality</label>
                                            <input type="text" id="ItemQuality" class="form-control" />
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
    <script type="text/javascript" src="../content/scripts/app/Masters/item-quality.js"></script>

</asp:Content>
