
<%@ Page Title="Pkg Slip" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PkgSlip.aspx.cs" Inherits="POS.Purchase.PkgSlip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewPkgSlip"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowPkgSlipList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewPkgSlip"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditPkgSlip"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SavePkgSlip"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeletePkgSlip"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="PrintPkgSlip"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterPkgSlip"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportPkgSlip"><i class="fa fa-cog fa-fw"></i>Export</a>

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
                <h3>Pkg Slip</h3>
            </div>

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div id="EditMode">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Pkg Slip Details</h4>
                            </div>

                            <div class="panel-body">

                                
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

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="Branch">Branch</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="PkgSlipNo">Pkg Slip No.</label>
                                            <input type="text" id="PkgSlipNo" class="form-control" readonly="readonly" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="PkgSlipDate">Pkg Slip Date</label>
                                            <div class="input-group date input-group-sm" id="PkgSlipDatePicker">
                                                <input type="text" id="PkgSlipDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="TypeOfTransfer">Type of Transfer</label>
                                            <select id="TypeOfTransfer" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="Vendor">Vendor</label>
                                            <select id="Vendor" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-1 col-md-1 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="PurchaseBillNo">Purchase Bill.</label>
                                            <select id="PurchaseBillNo" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="FromLocation">From Location</label>
                                            <select id="FromLocation" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="ToLocation">To Location</label>
                                            <select id="ToLocation" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="Karagir">Karagir</label>
                                            <select id="Karagir" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-sm">
                                            <label for="ReferenceNo">Ref No.</label>
                                            <input type="text" id="ReferenceNo" class="form-control" />
                                        </div>
                                    </div>

                                </div>

                        </div>

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Pkg Slip Items</h4>                                
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">

                                        <table id="PkgSlipItemsList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Bale No.</th>
                                                    <th>Item Name</th>
                                                    <th>Balance Qty</th>
                                                    <th>Pkg Qty</th>  
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

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div id="ViewMode">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Pkg Slip Details</h4>
                            </div>


                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">

                                        <table id="PkgSlipList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Action</th>
                                                    <th>Sr No.</th>
                                                    <th>Pkg Slip No.</th>
                                                    <th>Pkg Slip Date</th>
                                                    <th>From Location</th>
                                                    <th>Transfer Type</th>
                                                    <th>Vendor Name</th>
                                                    <th>Reference No.</th>
                                                    <th>Total Qty</th>                                                    
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
    <!-- / container -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/purchase/pkg-slip.js"></script>

</asp:Content>
