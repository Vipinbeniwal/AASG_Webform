<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="view-stock-ledger-order-details.aspx.cs" Inherits="AASGWeb.Modules.GRN.view_stock_ledger_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
        <!-- eCommerce Order View Header -->
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
        <!-- END eCommerce Order View Header -->

       
        <!-- Addresses -->
        <div class="row">
            <div class="col-sm-6">
                <!-- Billing Address Block -->
                <div class="block">
                    <!-- Billing Address Title -->
                    <div class="block-title">
                        <h2><i class="fa fa-building-o"></i><strong>Billing</strong> Address</h2>
                    </div>
                    <!-- END Billing Address Title -->

                    <!-- Billing Address Content -->
                    <h4><strong> Nijomee Technologies</strong></h4>
                    <address>
                        Ashoka Plaza<br>
                        Rohtak<br>
                        Haryana, 124001<br>
                        <br>
                        <i class="fa fa-phone"></i> 8199818181<br>
                        <i class="fa fa-envelope-o"></i><a href="javascript:void(0)"> Deepaksaini307@gmail.com</a>
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
                        <h2><i class="fa fa-building-o"></i><strong>Shipping</strong> Address</h2>
                    </div>
                    <!-- END Shipping Address Title -->

                    <!-- Shipping Address Content -->
                    <h4><strong>Nijomee Technologies</strong></h4>
                    <address>
                        Ashoka Plaza<br>
                        Rohtak<br>
                        Haryana, 124001<br>
                        <br>
                        <i class="fa fa-phone"></i> 8199818181<br>
                        <i class="fa fa-envelope-o"></i><a href="javascript:void(0)"> Deepaksaini307@gmail.com</a>
                    </address>
                    <!-- END Shipping Address Content -->
                </div>
                <!-- END Shipping Address Block -->
            </div>
        </div>
        <!-- END Addresses -->

        <!-- Products Block -->
        <div class="block">
            <!-- Products Title -->
            <div class="block-title">
                <h2><i class="fa fa-shopping-cart"></i><strong>Items Details</strong></h2>
            </div>
            <!-- END Products Title -->

            <!-- Products Content -->
            <div class="table-responsive">
              

                <asp:Repeater ID="rptrStockLedgerOrderDetails" runat="server" OnItemCommand="rptrStockLedgerOrderDetails_ItemCommand" OnItemDataBound="rptrStockLedgerOrderDetails_ItemDataBound">
                    <HeaderTemplate>
                        <table id="ecom-orders" class="table table-bordered table-vcenter">
                            <thead>
                                <tr>
                                    <th class="text-center" style="width: 100px;">ID</th>
                                    <th>Item Name</th>
                                    <th class="text-center" style="width: 10%;">Item Quantity</th>
                                    <th class="text-right" style="width: 10%;">Item Received</th>
                                    <th class="text-right">Remarks</th>

                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="text-center">
                                <asp:Label ID="lblItemId" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                            </td>

                            <td>
                                <asp:Label ID="lblItemName" Text='<%#Eval("purchase_item_name")%>' runat="server"> </asp:Label>
                            </td>
                            <td class="text-center">
                                <asp:Label ID="lblItemQuantity" Text='<%#Eval("purchase_item_quantity")%>' runat="server"></asp:Label>
                            </td>
                            <td class="text-right">
                                <asp:Label ID="lblreceivedItem" Text='<%#Eval("purchase_item_received_quantity")%>' runat="server"></asp:Label>

                            </td>
                            <td class="text-right">
                                <asp:Label ID="lblItemRemarks" Text='<%#Eval("purchase_item_remarks")%>' runat="server"></asp:Label>

                            </td>



                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td colspan="2" class="text-right text-uppercase"><strong>Total Items:</strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblTotalItemQuantity" runat="server"></asp:Label>

                            </strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblTotalRecieveQuantity" runat="server"></asp:Label>

                            </strong></td>
                        </tr>
                        

                        </table>         
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hdfdPurchaseNumber" runat="server" />

            </div>
            <!-- END Products Content -->
        </div>
        <!-- END Products Block -->


        <!-- Log Block -->
       <%-- <div class="block">
            <!-- Log Title -->
            <div class="block-title">
                <h2><i class="fa fa-file-text-o"></i><strong>Log</strong> Messages</h2>
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
                            <td class="text-success"><i class="fa fa-fw fa-check"></i><strong>Order Completed</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <span class="label label-primary">Order</span>
                            </td>
                            <td class="text-center">October 17, 2014 - 10:15</td>
                            <td><a href="javascript:void(0)">Support</a></td>
                            <td class="text-info"><i class="fa fa-fw fa-info-circle"></i><strong>Preparing Order</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <span class="label label-success">Payment</span>
                            </td>
                            <td class="text-center">October 16, 2014 - 17:15</td>
                            <td><a href="javascript:void(0)">Harry Burke</a></td>
                            <td class="text-success"><i class="fa fa-fw fa-check"></i><strong>Payment Completed</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <span class="label label-danger">Email</span>
                            </td>
                            <td class="text-center">October 16, 2014 - 09:10</td>
                            <td><a href="javascript:void(0)">Support</a></td>
                            <td class="text-danger"><i class="fa fa-fw fa-exclamation-triangle"></i><strong>Missing payment details. Email was sent and awaiting for payment before processing</strong></td>
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
            </div>--%>
            <!-- END Log Content -->
        </div>
        <!-- END Log Block -->
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
