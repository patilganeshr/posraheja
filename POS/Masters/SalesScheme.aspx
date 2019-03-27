<%@ Page Title="Sales Schemes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesScheme.aspx.cs" Inherits="POS.Masters.SalesScheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="st-content">

        <div class="container-fluid">

            <div class="row">
                <div class="action-toolbar">
                    <a href="#" id="AddNewScheme"><i class="fa fa-plus fa-fw"></i>Add New</a>
                    <a href="#" id="ShowSchemeList"><i class="fa fa-list fa-fw"></i>Show List</a>
                    <a href="#" id="ViewScheme"><i class="fa fa-eye fa-fw"></i>View</a>
                    <a href="#" id="EditScheme"><i class="fa fa-edit fa-fw"></i>Edit</a>
                    <a href="#" id="SaveScheme"><i class="fa fa-save fa-fw"></i>Save</a>
                    <a href="#" id="DeleteScheme"><i class="fa fa-remove fa-fw"></i>Delete</a>
                    <a href="#" id="PrintScheme"><i class="fa fa-print fa-fw"></i>Print</a>
                    <a href="#" id="FilterScheme"><i class="fa fa-filter fa-fw"></i>Filter</a>
                    <a href="#" id="ExportSchemeList"><i class="fa fa-cog fa-fw"></i>Export</a>
                </div>
            </div>

            <div class="page-header text-center">
                <h3>Sales Scheme</h3>
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

                        <div class="panel panel-carmine" id="SearchPanel" style="display: none;">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Search Scheme</h4>
                            </div>

                            <div class="panel-body">

                                <input type="hidden" id="SalesSchemeId" value="0" />

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Financial Year</label>
                                        <select id="SearchByFinancialYear" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Vendor</label>
                                        <select id="SearchByVendor" class="form-control"></select>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                    <div class="form-group form-group-sm">
                                        <label>Search By Purchase Bill No.</label>
                                        <div class="input-group input-group-sm">
                                            <input type="text" id="SearchByPurchaseBillNo" class="form-control" />
                                            <span class="input-group-addon" id="SearchByPurchaseBillNoButton">
                                                <i class="fa fa-search"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Scheme Details</h4>
                            </div>

                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Company Name</label>
                                            <select id="CompanyName" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Branch Name</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Brand</label>
                                            <select id="Brand" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Item Category</label>
                                            <select id="ItemCategory" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Item</label>
                                            <select id="Item" class="form-control"></select>
                                        </div>
                                    </div>


                                </div>

                                <div class="row">

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">

                                        <div class="form-group form-group-md">
                                            <label>Discount Percentage</label>
                                            <input type="text" class="form-control" id="DiscountPercentage" />
                                        </div>

                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Discount Amount</label>
                                            <input type="text" class="form-control" id="DiscountAmount" />
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Max Discount Amount</label>
                                            <input type="text" class="form-control" id="MaxDiscountAmount" />
                                        </div>
                                    </div>


                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Sale Start Date</label>
                                            <div class="input-group date input-group-md" id="SaleStartDateDatePicker">
                                                <input type="text" id="SaleStartDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label>Sale End Date</label>
                                            <div class="input-group date input-group-md" id="SaleEndDateDatePicker">
                                                <input type="text" id="SaleEndDate" class="form-control" />
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


                </div>

            </div>

            <!-- EditMode -->

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-carmine">

                            
                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Purchase Order</h4>
                            </div>

                            <div class="panel-body">
                                    
                                    <div class="table-responsive">

                                        <table id="SalesSchemesList" class="table table-condensed table-fixed">
                                        <thead>
                                            <tr>
                                                <th class="col-sm-1 text-center">Action</th>
                                                <th class="col-sm-1 text-center">Brand Name</th>
                                                <th class="col-sm-1 text-center">Item Category</th>
                                                <th class="col-sm-2 text-center">Item Name</th>
                                                <th class="col-sm-1 text-center">Disc. Percent</th>                                                
                                                <th class="col-sm-1 text-center">Disc. Amount</th>
                                                <th class="col-sm-1 text-center">Max Disc. Amt</th>
                                                <th class="col-sm-1 text-center">Start Date</th>
                                                <th class="col-sm-1 text-center">End Date</th>                                                
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

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/masters/sales-scheme.js"></script>

</asp:Content>
