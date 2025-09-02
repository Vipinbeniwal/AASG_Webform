<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="view-customer-request-detail.aspx.cs" Inherits="AASGWeb.Modules.Xp_Master.view_customer_request_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page content -->
    <div id="page-content">
        <!-- Dashboard 2 Header -->
        <div class="content-header">
            <ul class="nav-horizontal text-center">
                <li class="active">
                    <a href="javascript:void(0)"><i class="fa fa-home"></i>Home</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="gi gi-charts"></i>Create Bill</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="gi gi-briefcase"></i>Production</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="gi gi-video_hd"></i>Returns</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="gi gi-music"></i>SaleOrders</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="fa fa-cubes"></i>Accounts</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="fa fa-pencil"></i>Challans</a>
                </li>
                <li>
                    <a href="javascript:void(0)"><i class="fa fa-cogs"></i>Settings</a>
                </li>
            </ul>
        </div>
        <!-- END Dashboard 2 Header -->

        <!-- Quick Stats -->
        <%--<div class="row text-center">
            <div class="col-sm-6 col-lg-3">
                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Total</strong> Clerk</h4>
                    </div>
                    <div class="widget-extra-full"><span class="h2 animation-expandOpen">3</span></div>
                </a>
            </div>
            <div class="col-sm-6 col-lg-3">
                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Total</strong> BPO</h4>
                    </div>
                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">120</span></div>
                </a>
            </div>
            <div class="col-sm-6 col-lg-3">
                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Total</strong> Head</h4>
                    </div>
                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">22</span></div>
                </a>
            </div>
            <div class="col-sm-6 col-lg-3">
                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Total</strong> Manager</h4>
                    </div>
                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">2</span></div>
                </a>
            </div>
        </div>--%>
        <!-- END Quick Stats -->

       <!-- Products Block -->
                        <div class="block">
                            <!-- Products Title -->
                            <div class="block-title">
                                <h2><i class="fa fa-shopping-cart"></i> <strong>Items Details</strong></h2>
                            </div>
                            <!-- END Products Title -->

                            <!-- Products Content -->
                            <div class="table-responsive">
                                <table class="table table-bordered table-vcenter">
                                    <thead>
                                        <tr>
                                            <th class="text-center" style="width: 100px;">ID</th>
                                            <th>Brand </th>
                                            <th class="text-center">Item Id </th>
                                            <th class="text-center">Item Name</th>
                                            <th class="text-center">QTY</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="text-center"><a href="#"><strong>100</strong></a></td>
                                            <td><a href="#">HP</a></td>
                                            <td class="text-center">1</td>
                                            <td class="text-center">KeyBoard</td>
                                            <td class="text-center"><strong>10</strong></td>
                                            
                                        </tr>
                                         <tr>
                                            <td class="text-center"><a href="#"><strong>100</strong></a></td>
                                            <td><a href="#">HP</a></td>
                                             <td class="text-center">2</td>
                                            <td class="text-center">Mouse</td>
                                            <td class="text-center"><strong>10</strong></td>
                                            
                                        </tr>
                                         <tr>
                                            <td class="text-center"><a href="#"><strong>100</strong></a></td>
                                            <td><a href="#">HP</a></td>
                                             <td class="text-center">3</td>
                                            <td class="text-center">Laptop</td>
                                            <td class="text-center"><strong>10</strong></td>
                                            
                                        </tr>
                                       
                                        <tr>
                                            <td colspan="4" class="text-right text-uppercase"><strong>Total Item:</strong></td>
                                            <td class="text-center"><strong>30</strong></td>
                                        </tr>
                                        
                                        
                                    </tbody>
                                </table>
                            </div>
                            <!-- END Products Content -->
                        </div>
                        <!-- END Products Block -->

    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
