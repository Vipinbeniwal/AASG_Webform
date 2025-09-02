<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="view-tour.aspx.cs" Inherits="AASGWeb.Modules.Admin.view_tour" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
                        <!-- eCommerce Order View Header -->
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
                        <!-- END eCommerce Order View Header -->

                        <!-- Order Status -->
                        <div class="row text-center">
                            <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"><strong>Tour Name</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen">
                                        <asp:Label ID="lblTourName" runat="server" Text="Rohtak To Delhi"></asp:Label></span></div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"> <strong>Grade</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen"><asp:Label ID="lblGrade" runat="server" Text="Grade A"></asp:Label></span></div>
                                </div>
                            </div>
                             <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"> <strong>Employee Name</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen"><asp:Label ID="lblStaffName" runat="server" Text="Joginder"></asp:Label></span></div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"> <strong>Days</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen"><asp:Label ID="lblTourDays" runat="server" Text="2"></asp:Label></span></div>
                                </div>
                            </div>
                        </div>
                        <!-- END Order Status -->

                         <!-- Addresses -->
                        <%--<div class="row">
                            <div class="col-sm-6">
                                <!-- Billing Address Block -->
                                <div class="block">
                                    <!-- Billing Address Title -->
                                    <div class="block-title">
                                        <h2><i class="fa fa-building-o"></i> <strong>Billing</strong> Address</h2>
                                    </div>
                                    <!-- END Billing Address Title -->

                                    <!-- Billing Address Content -->
                                    <h4><strong>Jonathan Taylor</strong></h4>
                                    <address>
                                        Sunset Str 620<br>
                                        Melbourne<br>
                                        Australia, 21-842<br><br>
                                        <i class="fa fa-phone"></i> (999) 852-11111<br>
                                        <i class="fa fa-envelope-o"></i> <a href="javascript:void(0)">johnathan.taylor@example.com</a>
                                    </address>
                                    <!-- END Billing Address Content -->
                                </div>
                                <!-- END Billing Address Block -->
                            </div>
                            <div class="col-sm-6">
                                <!-- Shipping Address Block -->
                                <div class="block">
                                    <!-- Shipping Address Title -->
                                    <div class="block-title">
                                        <h2><i class="fa fa-building-o"></i> <strong>Shipping</strong> Address</h2>
                                    </div>
                                    <!-- END Shipping Address Title -->

                                    <!-- Shipping Address Content -->
                                    <h4><strong>Harry Burke</strong></h4>
                                    <address>
                                        Sunset Str 598<br>
                                        Melbourne<br>
                                        Australia, 21-852<br><br>
                                        <i class="fa fa-phone"></i> (999) 852-22222<br>
                                        <i class="fa fa-envelope-o"></i> <a href="javascript:void(0)">harry.burke@example.com</a>
                                    </address>
                                    <!-- END Shipping Address Content -->
                                </div>
                                <!-- END Shipping Address Block -->
                            </div>
                        </div>--%>
                        <!-- END Addresses -->

                        <!-- Products Block -->
                        <div class="block">
                            <!-- Products Title -->
                            <div class="block-title">
                                <h2><i class="fa fa-shopping-cart"></i> <strong>Expenses</strong></h2>
                            </div>
                            <!-- END Products Title -->

                            <!-- Products Content -->
                            <div class="table-responsive">
                                <table class="table table-bordered table-vcenter">
                                    <thead>
                                        <tr>
                                            <th class="text-center" style="width: 100px;">ID</th>
                                            <th>Date</th>
                                            <th class="text-center">Expense Type</th>
                                            <th class="text-center">Expense Amount</th>
                                            <%--<th class="text-right" style="width: 10%;">UNIT COST</th>
                                            <th class="text-right" style="width: 10%;">PRICE</th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="text-center"><a href="page_ecom_product_edit.html"><strong>1</strong></a></td>
                                            <td><a href="page_ecom_product_edit.html"></a>02/12/2021</td>
                                            <td class="text-center"><strong>720</strong></td>
                                            <td class="text-center"><strong>1</strong></td>
                                           <%-- <td class="text-right"><strong>$399,00</strong></td>
                                            <td class="text-right"><strong>$399,00</strong></td>--%>
                                        </tr>
                                        <tr>
                                            <td class="text-center"><a href="page_ecom_product_edit.html"><strong>1</strong></a></td>
                                            <td><a href="page_ecom_product_edit.html"></a>03/12/2021</td>
                                            <td class="text-center"><strong>368</strong></td>
                                            <td class="text-center"><strong>1</strong></td>
                                            <%--<td class="text-right"><strong>$59,00</strong></td>
                                            <td class="text-right"><strong>$59,00</strong></td>--%>
                                        </tr>

                                        <tr>
                                            <td colspan="3" class="text-right"><strong>Total Expense:</strong></td>
                                            <td class="text-center"><strong>$975,00</strong></td>
                                        </tr>
                                       
                                    </tbody>
                                </table>
                            </div>
                            <!-- END Products Content -->
                        </div>
                        <!-- END Products Block -->

                       

                        <!-- Log Block -->
                        <%--<div class="block">
                            <!-- Log Title -->
                            <div class="block-title">
                                <h2><i class="fa fa-file-text-o"></i> <strong>Log</strong> Messages</h2>
                            </div>
                            <!-- END Log Title -->

                            <!-- Log Content -->
                            <div class="table-responsive">
                                <table class="table table-bordered table-vcenter">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Order</span>
                                            </td>
                                            <td class="text-center">October 17, 2014 - 12:00</td>
                                            <td><a href="javascript:void(0)">Support</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Order Completed</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Order</span>
                                            </td>
                                            <td class="text-center">October 17, 2014 - 10:15</td>
                                            <td><a href="javascript:void(0)">Support</a></td>
                                            <td class="text-info"><i class="fa fa-fw fa-info-circle"></i> <strong>Preparing Order</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Payment</span>
                                            </td>
                                            <td class="text-center">October 16, 2014 - 17:15</td>
                                            <td><a href="javascript:void(0)">Harry Burke</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Payment Completed</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-danger">Email</span>
                                            </td>
                                            <td class="text-center">October 16, 2014 - 09:10</td>
                                            <td><a href="javascript:void(0)">Support</a></td>
                                            <td class="text-danger"><i class="fa fa-fw fa-exclamation-triangle"></i> <strong>Missing payment details. Email was sent and awaiting for payment before processing</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Order</span>
                                            </td>
                                            <td class="text-center">October 15, 2014 - 12:26</td>
                                            <td><a href="javascript:void(0)">Support</a></td>
                                            <td><strong>All products are available</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Order</span>
                                            </td>
                                            <td class="text-center">October 15, 2014 - 12:15</td>
                                            <td><a href="javascript:void(0)">Harry Burke</a></td>
                                            <td><strong>Order Submitted</strong></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!-- END Log Content -->
                        </div>--%>
                        <!-- END Log Block -->
                    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
