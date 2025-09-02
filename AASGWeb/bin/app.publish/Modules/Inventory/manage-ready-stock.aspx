<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="manage-ready-stock.aspx.cs" Inherits="AASGWeb.Modules.Inventory.manage_ready_stock" %>
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
                    <%--    <div class="row text-center">
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light"><strong>Pending</strong> Orders</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 animation-expandOpen">3</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Orders</strong> Today</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">120</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Orders</strong> This Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">3.200</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Orders</strong> Last Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">2.850</span></div>
                                </a>
                            </div>
                        </div>--%>
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
                            <div class="table-responsive">
                          <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="visible-lg">Product</th>
                                        <th class="text-center visible-lg">Raw Material</th>
                                        <th class="text-right hidden-xs">Units</th>
                                        <th class="hidden-xs text-center">Manufacture Date</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/100</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Apple Banana Shake</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Apple</a></td>
                                        <td class="text-right hidden-xs"><strong>10</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                    <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/101</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Apple Banana Shake</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Banana</a></td>
                                        <td class="text-right hidden-xs"><strong>12</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>

                                      <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/102</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Mango Shake</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Mango</a></td>
                                        <td class="text-right hidden-xs"><strong>7</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                    <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/103</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Mango Carrot Shake</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Carrot</a></td>
                                        <td class="text-right hidden-xs"><strong>8</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/104</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Just Mango</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Mango</a></td>
                                        <td class="text-right hidden-xs"><strong>5</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                   <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/105</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Just Carrot(L)</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Carrot</a></td>
                                        <td class="text-right hidden-xs"><strong>10</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/106</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Mango Carrot(S)</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Carrot</a></td>
                                        <td class="text-right hidden-xs"><strong>4</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                   <tr>
                                        <td class="text-center"><a href="page_ecom_order_view.html"><strong>AASG/RStock/107</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Just Carrot</a></td>
                                        <td class="text-center visible-lg"><a href="javascript:void(0)">Carrot</a></td>
                                        <td class="text-right hidden-xs"><strong>7</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                           
                            </div>
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
