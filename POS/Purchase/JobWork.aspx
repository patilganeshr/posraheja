<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobWork.aspx.cs" Inherits="POS.Purchase.JobWork" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewJobWork"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowJobWorkList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewJobWork"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditJobWork"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SaveJobWork"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeleteJobWork"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="PrintJobWork"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterJobWork"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportJobWork"><i class="fa fa-cog fa-fw"></i>Export</a>

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
                <h3>Job Work Details</h3>
            </div>

            <!-- Edit Mode -->

            <div class="row">

                    <div id="EditMode">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                            <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine">
                                <h4 class="panel-title">Job Work Details</h4>
                            </div>

                            <div class="panel-body">

                                    <input type="hidden" id="JobWorkId" disabled="disabled" />

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="FinancialYear">Financial Year</label>
                                            <select id="FinancialYear" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="Company">Company</label>
                                            <select id="Company" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="Branch">Branch</label>
                                            <select id="Branch" class="form-control"></select>
                                        </div>
                                    </div>
                                    
                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                                <label for="JobWorkNo">Job Work No.</label>                                        
                                                <input type="text" id="JobWorkNo" class="form-control" />                                            
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="JobWorkDate">Job Work Date</label>                                        
                                            <div class="input-group date input-group-md" id="JobWorkDatePicker">
                                                <input type="text" id="JobWorkDate" class="form-control" />
                                                <span class="input-group-addon">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="PurchaseBillNo">Purchase Bill No.</label>
                                            <select id="PurchaseBillNo" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="Karagir">Karagir</label>
                                            <select id="Karagir" class="form-control"></select>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="KaragirBillNo">Karagir Bill No.</label>
                                            <input type="text" id="KaragirBillNo" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                                        <div class="form-group form-group-md">
                                            <label for="KaragirLocation">Location</label>
                                            <input type="text" id="KaragirLocation" class="form-control" />
                                        </div>
                                    </div>                                    
                                    
                                </div>

                        </div>

                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        
                            <div class="panel panel-carmine">
                            
                                <div class="panel-heading panel-heading-carmine">
                                    <h3 class="panel-title">Purchase Bill Items Details</h3>
                                </div>

                                <div class="panel-body">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="PurchaseBillItemsList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Item Name</th>
                                                    <th>Purchase Qty</th>                                
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

                        <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                            
                            <div class="panel panel-carmine">
                                
                                <div class="panel-heading panel-heading-carmine">
                                <h3 class="panel-title">Job Work Items Details</h3>
                            </div>

                                <div class="panel-body">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="JobWorkItemsList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Item Name</th>
                                                    <th>Inward Qty</th>                                
                                                    <th>Unit Code</th>
                                                    <th>Cut Mtrs</th>
                                                    <th>Mtrs Used</th>
                                                    <th>Rate</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                            <tfoot>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            </div>

                        </div>

                        <!-- JOB WORK ITEM MTR ADJUSTMENT -->
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        
                            <div class="panel panel-carmine">
                            
                                <div class="panel-heading panel-heading-carmine">
                                    <h3 class="panel-title">Mtr Adjustment Details</h3>
                                </div>

                                <div class="panel-body">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="JobWorkItemsMtrAdjustmentList" class="table table-condensed">
                                            <thead>
                                                <tr> 
                                                    <th>Reference No.</th>
                                                    <th>Pkg Qty</th>
                                                    <th>Balance Mtrs</th>
                                                    <th>Adjusted Mtrs</th>                                                    
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                                
                            </div>

                        </div>

                        <!-- JOB WORK ITEM MTR ADJUSTMENT -->
                    
                </div>

            </div>

            <!-- ./ Edit Mode -->

            <!-- View Mode -->

            <div class="row">

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                    <div id="ViewMode">

                        <div class="panel panel-carmine">

                            <div class="panel-heading panel-heading-carmine clearfix">
                                <h3 class="panel-title">Job Work Details</h3>
                            </div>

                            <div class="panel-body">

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                    <div class="table-responsive">

                                        <table id="JobWorkList" class="table table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Action</th>
                                                    <th>Job Work No.</th>
                                                    <th>Job Work Date</th>
                                                    <th>Purchase Bill No.</th>
                                                    <th>Purchase Qty</th>
                                                    <th>Karagir Name</th>
                                                    <th>Pkg Qty</th>
                                                    <th>Inward Qty</th>
                                                    <th>Adjusted Mtrs</th>
                                                    <th>Karagir Location</th>
                                                    <th>Fin Year</th>
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
    <script type="text/javascript" src="../content/scripts/app/purchase/job-work.js"></script>

</asp:Content>
