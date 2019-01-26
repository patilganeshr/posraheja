<%@ Page Title="Item Rate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemRate.aspx.cs" Inherits="POS.Masters.ItemRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMaster" runat="server">

    <div class="action-toolbar">

        <a href="#" id="AddNewItemRate"><i class="fa fa-plus fa-fw"></i>New</a>
        <a href="#" id="ShowItemRateList"><i class="fa fa-list fa-fw"></i>List</a>
        <a href="#" id="ViewItemRate"><i class="fa fa-eye fa-fw"></i>View</a>
        <a href="#" id="EditItemRate"><i class="fa fa-edit fa-fw"></i>Edit</a>
        <a href="#" id="SaveItemRate"><i class="fa fa-save fa-fw"></i>Save</a>
        <a href="#" id="DeleteItemRate"><i class="fa fa-remove fa-fw"></i>Delete</a>
        <a href="#" id="PrintItemRateList"><i class="fa fa-print fa-fw"></i>Print</a>
        <a href="#" id="FilterItemRateList"><i class="fa fa-filter fa-fw"></i>Filter</a>
        <a href="#" id="ExportItemRateList"><i class="fa fa-cog fa-fw"></i>Export</a>

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
                <h3>Item Rate</h3>
            </div>

            <!-- START OF EDIT MODE -->

            <div id="EditMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-info">

                            <div class="panel-heading">
                                <h4 class="panel-title">Item Rate</h4>
                            </div>

                            <div class="panel-body">

                                <div class="row">

                                    <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12">

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                            <div class="form-group form-group-sm">
                                                <label>Item Name</label>
                                                <input type="hidden" id="ItemRateId" class="form-control" />
                                                <select id="ItemName" class="form-control"></select>
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <span class="help-text">Enter % sign for Discount in Percentage for e.g. 5% or 10%</span>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Effective From Date</label>
                                                <div class="input-group input-group-sm date" id="EffectiveFromDatePicker">
                                                    <input type="text" id="EffectiveFromDate" class="form-control" />
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Purchase Rate</label>
                                                <input type="text" id="PurchaseRate" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Discount / RD</label>
                                                <input type="text" id="Discount" class="form-control" />                                                
                                            </div>
                                        </div>

                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Rate (PR - Disc./RD)</label>
                                                <input type="text" id="RateAfterDiscount" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Transport Cost</label>
                                                <input type="text" id="TransportCost" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Labour Cost</label>
                                                <input type="text" id="LabourCost" class="form-control" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Goods Cost</label>
                                                <input type="text" id="GoodsCost" class="form-control" readonly="readonly" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>GST Rate</label>
                                                <input type="text" id="GSTRate" class="form-control" readonly="readonly" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>GST Amount</label>
                                                <input type="text" id="GSTAmount" class="form-control" readonly="readonly" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label>Total Cost</label>
                                                <input type="text" id="TotalItemRate" class="form-control" readonly="readonly" />
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group form-group-sm">
                                                <label for="IsSellAtNetRate">Is Sell at Net Rate</label>
                                                <label class="label-tick">
                                                    <input type="radio" id="SellAtNetRate" class="label-radio" name="IsSellAtNetRate" value="Yes" />
                                                    <span class="label-text">Yes</span>
                                                </label>
                                                <label class="label-tick">
                                                    <input type="radio" id="DontSellAtNetRate" class="label-radio" name="IsSellAtNetRate" checked="checked" value="No" />
                                                    <span class="label-text">No</span>
                                                </label>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">

                                        <div class="table-responsive">
                                            <p class="help-text">Make the Rate or Amount Zero to enable the input box if it is grey.</p>
                                            <table id="CustomerCategoryRateList" class="table table-condensed">
                                                <thead>
                                                    <tr>
                                                        <th>Sr</th>
                                                        <th>Customer Category</th>
                                                        <th>Rate (%)</th>
                                                        <th>Rate (Flat)</th>
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


            <!-- START OF VIEW MODE -->

            <div id="ViewMode">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="panel panel-info">

                            <div class="panel-heading">

                                <h4 class="panel-title">Item Rate</h4>
                                
                            </div>

                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table id="ItemRateList" class="table table-condensed">
                                        <thead>
                                            <tr>
                                                <th class="text-center">Action</th>
                                                <th>Sr</th>
                                                <th>Item Name</th>
                                                <th>Item Size</th>
                                                <th>Purchase Rate</th>
                                                <th>Transport Cost</th>
                                                <th>Labour Cost</th>
                                                <th>Total Item Rate</th>
                                                <th>Is Sell At Net Rate</th>
                                                <th>Effective From Date</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                </div>

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

    <!-- CONTAINER END -->

    <script type="text/javascript" src="../content/scripts/app/shared/default.js"></script>
    <script type="text/javascript" src="../content/scripts/app/Masters/item-rate.js"></script>

</asp:Content>
