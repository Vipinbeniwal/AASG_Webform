<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-supplier.aspx.cs" Inherits="AASGWeb.Modules.Supplier.manage_supplier" %>
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
                                <a href="javascript:void(0)"><i class="gi gi-charts"></i> Sales</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-briefcase"></i> Projects</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-video_hd"></i> Movies</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-music"></i> Music</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cubes"></i> Apps</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-pencil"></i> Profile</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cogs"></i> Settings</a>
                            </li>
                        </ul>
                    </div>
                    <!-- END Dashboard 2 Header -->
                     
                        <!-- Quick Stats -->
                        <%--<div class="row text-center">
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
                                <h2><strong>All</strong> Suppliers</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                              <asp:Repeater ID="rptrManageSupplier" runat="server" OnItemCommand="rptrManageSupplier_ItemCommand" OnItemDataBound="rptrManageSupplier_ItemDataBound"  >
                            <HeaderTemplate>
                            <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-left" style="width: 50px;">ID</th>
                                        <th class="text-left">Supplier Name</th> 
                                        <th class="text-left">Email</th>
                                            <th class="text-left">GST</th>
                                        <th class="text-left" style="width: 200px;" >Ship To Address</th>
                                        <th class="text-left" style="width: 200px;">Region</th>
                                        <th>Status</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                 </HeaderTemplate>
                             <ItemTemplate>
                                <tr>
                                    <td style="text-align:left;"><%# Container.ItemIndex + 1 %>    </td>
                                    <td style="text-align:left;"><asp:Label ID="lblBrand" Text='<%#Eval("supplier_name")%>' runat="server" /><br />
                                        <%# DataBinder.Eval(Container.DataItem, "supplier_phoneno")%> 
                                    </td>
                                     <td style="text-align:left;"><%# DataBinder.Eval(Container.DataItem, "supplier_email")%> </td>
                                       <td><%# DataBinder.Eval(Container.DataItem, "supplier_gst")%>   </td>
                                     <td><%# DataBinder.Eval(Container.DataItem, "supplier_address")%>   </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "supplier_region")%>   </td>
                                    <td> <asp:Label ID="lblStatus" Text='<%# Eval("is_active").ToString()=="True" ? "Active":"Deactive"%>' runat="server" /></td>

                               <%--     <td>
                                        <asp:LinkButton ID="btnRun" runat="server" CommandName="run" ToolTip="Mark Running" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-sm btn-primary" Visible="false">Mark Running </asp:LinkButton>
                                       <asp:Label ID="lblStatus" Text='<%#Eval("IsRunning")%>' runat="server" Visible="false" />
                                        <asp:LinkButton ID="btnBook" runat="server" CommandName="book" ToolTip="click to Book" CommandArgument='<%# Eval("Id") %>' CssClass="text-primary text-center"><i class="fa fa-plus"></i> </asp:LinkButton>
                                    </td>--%>
                                     <td class=" text-center btn-group btn-group-xs ">
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("supplier_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("supplier_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>         
                            </FooterTemplate>
                        </asp:Repeater>
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
