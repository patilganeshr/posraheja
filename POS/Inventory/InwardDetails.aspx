<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InwardDetails.aspx.cs" Inherits="POS.Inventory.InwardDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../Content/css/vendor/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/css/vendor/jquery-ui/jquery-ui.theme.min.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <%--<div id="Loader" class="loader-container">
            <!--There's the container that centers it-->
            <div class="spinner-frame">
                <!--The background-->
                <div class="spinner-cover"></div>
                <!--The foreground-->
                <div class="spinner-bar"></div>
                <!--and the spinny thing-->
            </div>
        </div>--%>

    <div class="action-toolbar">

        <a href="#" id="AddNew"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="View"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="Edit"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="Save"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="Delete"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="Print"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="Filter"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="Export"><i class="fa fa-cog fa-fw"></i>Export</a>

    </div>

    <div class="st-content">

        <div class="container-fluid">

            <div class="page-header text-center">
                <h3>Inward Details</h3>
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

            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Inward Details</h4>
                            </div>

                            <div class="panel-body">

                                <div class="row">

                                    <%--<div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">--%>
                                        
                                        <input type="hidden" id="InwardId" disabled="disabled" />

                                        <div class="col-lg-1 col-md-1 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Financial Year</label>
                                                <select id="FinancialYear" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Company</label>
                                                <select id="Company" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Branch</label>
                                                <select id="Branch" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Inward No.</label>
                                                <input type="text" id="InwardNo" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Inward Date</label>
                                                <div class="input-group date input-group-sm" id="InwardDatePicker">
                                                    <input type="text" id="InwardDate" class="form-control" />
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                    <%--</div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">--%>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Inward From</label>
                                                <select id="InwardFrom" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>GRN No./Outward No./Job Work No.</label>
                                                <select id="ReferenceNo" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Reference Date</label>
                                                <input type="text" id="ReferenceDate" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Transfer Type</label>
                                                <input type="text" id="TypeOfTransfer" class="form-control" />
                                            </div>
                                        </div>

                                    <%--</div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">--%>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>From Location</label>
                                                <input type="text" id="FromLocation" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>To Location</label>
                                                <select id="ToLocation" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Transporter</label>
                                                <select id="Transporter" class="form-control"></select>
                                            </div>
                                        </div>
                                        <%--</div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">

                                        
                                    <%--</div>--%>
                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Vehicle No.</label>
                                                <input type="text" id="VehicleNo" class="form-control" />
                                            </div>
                                        </div>

                                </div>

                            </div>

                        </div>

                    </div>
                </div>

                <div class="panel panel-carmine">
                    <div class="panel-heading panel-heading-carmine">
                        <h3 class="panel-title">Inward Goods Details</h3>
                    </div>

                    <div class="panel-body">
                    
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 row">

                            <div id="JobWorkItems">
                                
                                <div id="ItemsList" class="autocompleteList"></div>

                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Item name</label>                                            
                                        <div class="input-group input-group-sm">
                                            <input type="text" class="form-control" id="ItemName" placeholder="Search Item Name" />
                                            <span class="input-group-btn">
                                                <button type="button" class="btn btn-sm btn-success" id="AddNewItem">
                                                    <i class="fa fa-fw fa-plus"> </i>
                                                </button>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="table-responsive">
                                <table id="InwardGoodsList" class="table table-condensed">
                                    <thead>
                                        <tr>
                                            <th>Action</th>
                                            <th>Sr</th>
                                            <th>Item Name</th>
                                            <th>Unit Code</th>
                                            <th>Received Qty</th>
                                            <th>Inward Qty</th>                                          
                                        </tr>
                                    </thead>
                                    <tbody></tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>

            </div>

            <div id="ViewMode">

                <!-- View Mode -->
                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine clearfix">
                                <h3 class="panel-title">Inward Details</h3>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">
                                        <table id="InwardList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Action</th>
                                                    <th>Sr No.</th>
                                                    <th>Inward No.</th>
                                                    <th>Inward Date</th>
                                                    <th>Inward From</th>
                                                    <th>Reference No.</th>
                                                    <th>From Location</th>
                                                    <th>To Location</th>
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


    <script type="text/javascript" src="../Content/scripts/vendor/jquery/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/inventory/inward-details.js"></script>

</asp:Content>
