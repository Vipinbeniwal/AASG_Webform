<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="challan.aspx.cs" Inherits="AASGWeb.Modules.Billing.challan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Page content -->
                <div id="page-content">
                    <!-- Dashboard 2 Header -->
                    <div class="content-header">
                        <ul class="nav-horizontal text-center">
                            <li class="active">
                                <a href="/home"><i class="fa fa-home"></i>Home</a>
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
                                <a href="/manage-sale-orders"><i class="gi gi-charts"></i>SaleOrders</a>
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
                      
                        <ul class="breadcrumb breadcrumb-top">
                            <li>Billing</li>
                            <li><a href="/add-return">Challan</a></li>
                        </ul>
                        <!-- END Forms General Header -->
                       <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                  <%--  <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                </div>
                <h2><strong>Manage</strong> Sale Orders</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->
            <asp:Repeater ID="rptrSaleOrder" runat="server" OnItemCommand="rptrSaleOrder_ItemCommand" OnItemDataBound="rptrSaleOrder_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                 <th class="text-center" style="width: 50px;">ID</th>
                                <th class="text-center ">Order ID</th>
                                <th class="text-center ">Party Name</th>
                                <th class="text-center ">Items Quan.</th>
                                <th class="text-center ">Total Amount</th>
                                <th class="text-center ">Date</th>
                                <th class="text-center ">Order By (Staff)</th>
                                <th>Order Status</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                       
                        <td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>

                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblSaleOrderId" Text='<%#Eval("sale_header_id")%>' runat="server"></asp:Label>
                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblPartyName" Text='<%#Eval("party_name")%>' runat="server"></asp:Label>
                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblTotalItems" Text='<%#Eval("total_items")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lbltotalAmount" Text='<%#Eval("total_amount")%>' runat="server"></asp:Label>

                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblDate" Text='<%#Eval("sale_item_date","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblMadeBy" Text='<%#Eval("made_by")%>' runat="server"></asp:Label>

                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblOrderStatus" Text='<%#Eval("order_status")%>' runat="server"></asp:Label>


                        </td>


                        <%-- <td class="text-center">
                            <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                            <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                            <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>

                        </td>--%>
                        <td class=" text-center  btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to Loading slip" data-original-title="Basic tooltp"><i class="fa fa-file-text"></i></asp:LinkButton>
                            <asp:LinkButton ID="btnChallan" runat="server" CommandName="challan" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to challan" data-original-title="Basic tooltp"><i class="hi hi-plus"></i></asp:LinkButton>
                            <%-- <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>--%>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hdfdSaleOrderId" runat="server" />

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
