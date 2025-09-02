<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-returns.aspx.cs" Inherits="AASGWeb.Modules.Billing.manage_returns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Page content -->
                <div id="page-content">
                    <!-- Dashboard 2 Header -->
                  <div class="content-header">
                        <ul class="nav-horizontal text-center">
                            <li class="active">
                                <a href="javascript:void(0)"><i class="fa fa-home"></i> Home</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-charts"></i> Create Bill</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-briefcase"></i> Production</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-video_hd"></i> Returns</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-music"></i> SaleOrders</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cubes"></i> Accounts</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-pencil"></i> Challans</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cogs"></i> Settings</a>
                            </li>
                        </ul>
                    </div>
                    <!-- END Dashboard 2 Header -->
                     <!-- Quick Stats -->
                        <div class="row text-center">
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light"><strong>Return</strong> Total</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 animation-expandOpen">500</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Return</strong> Today</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">3</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Return</strong> This Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">300</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Return</strong> Last Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">140</span></div>
                                </a>
                            </div>
                        </div>
                        <!-- END Quick Stats -->

                        <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>
                                </div>
                                <h2><strong>All</strong> Orders</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                           <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center visible-lg">Return From</th>
                                        <th class="text-right hidden-xs">Contact Person</th>
                                         <th class="text-right hidden-xs">Slot Number</th>
                                        <th class="text-right hidden-xs">Item Name</th>
                                        <th class="text-right hidden-xs">Item Quantity</th>
                                        <th class="text-right hidden-xs">Return Reason</th>
                                        <th class="text-right hidden-xs">Date</th>
                                        <th>Status</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/ZZ/100</strong></a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Nijomee Technologies Pvt. Ltd</a></td>
                                         <td class="visible-lg"><a href="javascript:void(0)">Ryan Hopkins</a></td>
                                        <td class="hidden-xs text-center"><strong>AASG-6789</strong></td>
                                        <td class="hidden-xs text-center">Laptop</td>
                                        <td class="hidden-xs text-center">10</td>
                                        <td class="hidden-xs text-center">Damage</td>
                                        <td class="hidden-xs text-center">22-Nov-2021</td>
                                        <td><span class="label label-success">Return</span></td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                   <tr>
                                         <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/ZZ/101</strong></a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Nijomee Technologies Pvt. Ltd</a></td>
                                         <td class="visible-lg"><a href="javascript:void(0)">Ryan Hopkins</a></td>
                                        <td class="hidden-xs text-center"><strong>AASG-6789</strong></td>
                                        <td class="hidden-xs text-center">Laptop</td>
                                        <td class="hidden-xs text-center">10</td>
                                        <td class="hidden-xs text-center">Damage</td>
                                        <td class="hidden-xs text-center">22-Nov-2021</td>
                                        <td><span class="label label-success">Return</span></td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>

                                      <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/ZZ/103</strong></a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Nijomee Technologies Pvt. Ltd</a></td>
                                         <td class="visible-lg"><a href="javascript:void(0)">Ryan Hopkins</a></td>
                                        <td class="hidden-xs text-center"><strong>AASG-6789</strong></td>
                                        <td class="hidden-xs text-center">Laptop</td>
                                        <td class="hidden-xs text-center">10</td>
                                        <td class="hidden-xs text-center">Not Working</td>
                                        <td class="hidden-xs text-center">22-Nov-2021</td>
                                        <td><span class="label label-success">Return</span></td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                   <tr>
                                         <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/ZZ/104</strong></a></td>
                                       <td class="text-center visible-lg"><a href="javascript:void(0)">Nijomee Technologies Pvt. Ltd</a></td>
                                         <td class="visible-lg"><a href="javascript:void(0)">Ryan Hopkins</a></td>
                                        <td class="hidden-xs text-center"><strong>AASG-6789</strong></td>
                                        <td class="hidden-xs text-center">Laptop</td>
                                        <td class="hidden-xs text-center">10</td>
                                        <td class="hidden-xs text-center">Damage</td>
                                        <td class="hidden-xs text-center">22-Nov-2021</td>
                                        <td><span class="label label-success">Return</span></td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/ZZ/105</strong></a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Nijomee Technologies Pvt. Ltd</a></td>
                                         <td class="visible-lg"><a href="javascript:void(0)">Ryan Hopkins</a></td>
                                        <td class="hidden-xs text-center"><strong>AASG-6789</strong></td>
                                        <td class="hidden-xs text-center">Laptop</td>
                                        <td class="hidden-xs text-center">10</td>
                                        <td class="hidden-xs text-center">Damage</td>
                                        <td class="hidden-xs text-center">22-Nov-2021</td>
                                        <td><span class="label label-success">Return</span></td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                </tbody>
                            </table>
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
