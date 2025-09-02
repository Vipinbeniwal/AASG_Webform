<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="manage-drawing-master.aspx.cs" Inherits="AASGWeb.Modules.Admin.manage_drawing_master" %>
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
            <asp:Repeater ID="rptrDrawingList" runat="server" OnItemCommand="rptrDrawingList_ItemCommand" OnItemDataBound="rptrDrawingList_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 100px;">ID</th>
                                <th class="text-center visible-lg">Drawing Name</th>
                                <th class="text-center visible-lg">Drawing Image</th>
                                <th class="text-center hidden-xs">Drawing Type</th>
                                <th class="text-center hidden-xs">Alias</th>
                                <th class="text-center hidden-xs">Description</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="text-center"><a href="#"><strong><%# Container.ItemIndex + 1 %></strong></a>    </td>

                        <td class="visible-lg text-center">
                            <asp:Label ID="lblDrawingName" Text='<%#Eval("drawing_name")%>' runat="server"> </asp:Label>
                        </td>
                         <td class=" text-center">
                             <asp:Label ID="lblpic" Text='<%#Eval("drawing_image")%>' Visible="false" runat="server"></asp:Label>
                              <asp:Image ID="lblDrawingImageUrl" runat="server" ImageUrl='<%#Eval("drawing_image")%>' style="width:50px; height:50px;" alt="Drawing Image" />
                             </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblDrawingType" Text='<%#Eval("drawing_type")%>' runat="server"></asp:Label>
                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblDrawingAlias" Text='<%#Eval("drawing_alias")%>' runat="server"></asp:Label>

                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblDarwingDescription" Text='<%#Eval("drawing_description")%>' runat="server"></asp:Label>

                        </td>
                      
                       
                       
                        <td class=" text-center btn-group btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("drawing_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                           
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hdfdPurchaseItemId" runat="server" />

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
