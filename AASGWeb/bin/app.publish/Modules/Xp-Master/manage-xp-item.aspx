<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-xp-item.aspx.cs" Inherits="AASGWeb.Modules.Xp_Master.manage_xp_item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                     <asp:LinkButton ID="btnDownloadExcel" runat="server" CssClass="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="tooltip" data-placement="bottom" title="Download Excel Report" data-original-title="Basic tooltp" Text="Export"  OnClick="btnDownloadExcel_Click"></asp:LinkButton> </div>
                <h2><strong>All</strong> XPItems</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->
            <asp:Repeater ID="rptrManageXPItems" runat="server"  OnItemCommand="rptrManageXPItems_ItemCommand"  OnItemDataBound="rptrManageXPItems_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 100px;">ID</th>
                                <th class="text-center" style="width: 100px;">Serial No.</th>
                                <th class="text-left">Brand</th>
                                <th class="text-left">Item Name</th>
                                <th class="text-left">Quantity</th>
                                <th class="text-left">Price</th>
                                 <th class="text-left">Item Specification</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;"><%# Container.ItemIndex + 1 %>    </td>
                          <td style="text-align: left;"> <asp:Label ID="lblSerialNumber" Text='<%#Eval("item_serial_number")%>' runat="server" /> </td>
                        <td style="text-align: left;"><asp:Label ID="lblBrand" Text='<%#Eval("item_brand")%>' runat="server" /> </td>
                         <td style="text-align: left;"> <asp:Label ID="lblItemName" Text='<%#Eval("item_name")%>' runat="server" /> </td>
                         <td style="text-align: left;"> <asp:Label ID="Label1" Text='<%#Eval("item_quantity")%>' runat="server" /> </td>
                         <td style="text-align: left;"> <asp:Label ID="Label2" Text='<%#Eval("item_price")%>' runat="server" /> </td>
                        <td style="text-align: left;"> <asp:Label ID="Label3" Text='<%#Eval("item_specification")%>' runat="server" /> </td>
                        <td class="text-center">
                            <div class="btn-group btn-group-xs">
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("xp_item_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("xp_item_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <!-- END All Orders Content -->


            <asp:HiddenField ID="hdfdXPItemId" runat="server" />

        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
