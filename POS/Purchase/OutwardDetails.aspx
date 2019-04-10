<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutwardDetails.aspx.cs" Inherits="POS.Purchase.OutwardDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewOutward"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowOutwardList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewOutward"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditOutward"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SaveOutward"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeleteOutward"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="PrintOutward"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterOutward"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportOutward"><i class="fa fa-cog fa-fw"></i>Export</a>

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

            <div class="page-header text-center">
                <h3>Outward Details</h3>
            </div>

            <!-- Edit Mode -->

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div id="EditMode">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Outward Details</h4>
                            </div>

                            <div class="panel-body">

                                    <input type="hidden" id="OutwardId" disabled="disabled" />

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="FinancialYear">Financial Year</label>
                                            <select id="FinancialYear" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="Company">Company</label>
                                            <select id="Company" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="Branch">Branch</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>
                                    
                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                                <label for="OutwardNo">Outward No.</label>                                        
                                                <input type="text" id="OutwardNo" class="form-control" />                                            
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="OutwardDate">Outward Date</label>                                        
                                            <div class="input-group date input-group-sm" id="OutwardDatePicker">
                                                <input type="text" id="OutwardDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="PkgSlipNo">Pkg Slip No.</label>
                                            <select id="PkgSlipNo" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="TypeOfTransfer">Type of Transfer</label>
                                            <input type="text" id="TypeOfTransfer" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="FromToLocation">From - To Location</label>
                                            <input type="text" id="FromToLocation" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="ReferenceNo">Reference No.</label>
                                            <input type="text" id="ReferenceNo" class="form-control" disabled="disabled" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="Transporter">Transporter</label>
                                            <select id="Transporter" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="VehicleNo">Vehicle No.</label>
                                            <input type="text" id="VehicleNo" class="form-control" />
                                        </div>
                                    </div>

                                </div>

                        </div>

                        <div class="panel panel-carmine">
                            <div class="panel-heading panel-heading-carmine">
                                <h3 class="panel-title">Outward Goods Details</h3>
                            </div>

                            <div class="panel-body">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="OutwardGoodsList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Pkg Slip No.</th>
                                                    <th>Pkg Slip Date</th>                                
                                                    <th>Item Name</th>
                                                    <th>Pkg Slip Qty</th>
                                                    <th>Unit Code</th>
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

            <!-- ./ Edit Mode -->

            <!-- View Mode -->

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div id="ViewMode">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine clearfix">
                                <h3 class="panel-title">Outward Details</h3>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">

                                        <table id="OutwardList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Action</th>
                                                    <th>Outward No.</th>
                                                    <th>Outward Date</th>
                                                    <th>Bale No.</th>
                                                    <th>From Location</th>
                                                    <th>Transporter</th>
                                                    <th>Vehicle No.</th>
                                                    <th>Total Pkg Slip Qty</th>
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

            <!-- ./ View Mode -->


        </div>

    </div>





    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/purchase/outward-details.js"></script>

</asp:Content>
