<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="manage-procurement.aspx.cs" Inherits="AASGWeb.Modules.Xp_Master.manage_procurement" %>
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
        <div class="row text-center">
            <div class="col-sm-6 col-lg-3">
                <a href="#" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Purchase </strong>All Today</h4>
                    </div>
                    <div class="widget-extra-full">
                        <span class="h2 animation-expandOpen">
                            <asp:Label ID="lblTodayPurchaseOrders" runat="server" Text="0"></asp:Label>
                        </span>
                    </div>
                </a>
            </div>
            <div class="col-sm-6 col-lg-3">
                <a href="#" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Purchase </strong>This Month</h4>
                    </div>
                    <div class="widget-extra-full">
                        <span class="h2 animation-expandOpen">
                            <asp:Label ID="lblCurrentMonthPurchaseOrders" runat="server" Text="0"></asp:Label>

                        </span>
                    </div>
                </a>
            </div>
            <div class="col-sm-6 col-lg-3">
                <a href="#" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Purchase </strong>Last Month</h4>
                    </div>
                    <div class="widget-extra-full">
                        <span class="h2 animation-expandOpen">
                            <asp:Label ID="lblLastMonthPurchaseOrder" runat="server" Text="0"></asp:Label>
                        </span>
                    </div>
                </a>
            </div>
            <div class="col-sm-6 col-lg-3">
                <a href="#" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Purchase </strong>This Year</h4>
                    </div>
                    <div class="widget-extra-full">
                        <span class="h2 animation-expandOpen">
                            <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                        </span>
                    </div>
                </a>
            </div>
        </div>
        <!-- END Quick Stats -->

        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                  <%--  <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                </div>
                <h2><strong>All</strong> Orders</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->
            <asp:Repeater ID="rptrPurchaseOrder" runat="server" OnItemCommand="rptrPurchaseOrder_ItemCommand" OnItemDataBound="rptrPurchaseOrder_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 100px;">ID</th>
                                <th class="text-center visible-lg">Party Name</th>
                                <th class="text-center hidden-xs">Item Quan.</th>
                                <th class="text-center hidden-xs">Total Amount</th>
                                <th class="text-center hidden-xs">Paid Amount</th>
                                <th class="text-center hidden-xs">Pending Amount</th>
                                <th class="text-center hidden-xs">Discount</th>
                                <th class="text-center hidden-xs">Date</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="text-center"><a href="/view-purchase-order-bill"><strong>AASG/ZZ/<%# Container.ItemIndex + 1 %></strong></a>    </td>

                        <td class="visible-lg text-center">
                            <asp:Label ID="lblSupplierName" Text='<%#Eval("supplier_name")%>' runat="server"> </asp:Label>
                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblItemQuantity" Text='<%#Eval("purchase_items_quantity")%>' runat="server"></asp:Label>
                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblItemTotalAmount" Text='<%#Eval("purchase_items_total_amount")%>' runat="server"></asp:Label>

                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblPayAmount" Text='<%#Eval("purchase_items_pay_amount")%>' runat="server"></asp:Label>

                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblPendingAmount" Text='<%#Eval("purchase_items_pending_amount")%>' runat="server"></asp:Label>

                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblDiscount" Text='<%#Eval("purchase_item_discount")%>' runat="server"></asp:Label>

                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblPurchaseDate" Text='<%#Eval("purchase_item_date","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>

                        </td>

                       
                       
                        <td class=" text-center btn-group btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("xp_procurement_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                            <asp:LinkButton ID="btnSendEmail" runat="server" CommandName="send" CommandArgument='<%# Eval("xp_procurement_header_id")%>' CssClass="btn btn-xs btn-primary text-center" data-toggle="tooltip" data-placement="bottom" title="Click to Send Email" data-original-title="Basic tooltp"><i class="gi gi-envelope"></i></asp:LinkButton>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hdfdProcurementItemId" runat="server" />

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
