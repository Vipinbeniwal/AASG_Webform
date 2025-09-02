<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-party.aspx.cs" Inherits="AASGWeb.Modules.Admin.manage_party" %>
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
                        <%--<div class="row text-center">
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light"><strong>Total</strong> Party</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 animation-expandOpen">3</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Active</strong> Party</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">120</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Deactive</strong> This Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">3.200</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Last Month</strong> Party</h4>
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
                                     <asp:LinkButton ID="btnDownloadExcel" runat="server" CssClass="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="tooltip" data-placement="bottom" title="Download Excel Report" data-original-title="Basic tooltp" Text="Export"  OnClick="ExportToExcel"></asp:LinkButton>
                                        <asp:LinkButton ID="btnDownloadFile" runat="server" CssClass="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="tooltip" data-placement="bottom" title="Download Excel Report" data-original-title="Basic tooltp" Text="Sample"  OnClick="DownloadFile"></asp:LinkButton>
                                        <%--<a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class" >Download Excel </a>--%>
                                </div>
                                <h2><strong>All</strong> Party</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                         <div class="table-responsive">

                        <asp:Repeater ID="rptrManageParty" runat="server" OnItemCommand="rptrManageParty_ItemCommand"  OnItemDataBound="rptrManageParty_ItemDataBound">
                            <HeaderTemplate>
                            <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-left" style="width: 20px;">ID</th>
                                        <th class="text-left">Party Name</th> 
                                        <th class="text-left">Email</th>
                                            <th class="text-left">GST</th>
                                        <th class="text-left" style="width: 200px;" >Bill To Address</th>
                                        <th class="text-left" style="width: 100px;">Region</th>
                                        <th>Status</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                 </HeaderTemplate>
                             <ItemTemplate>
                                <tr>
                                    <td style="text-align:left;"><%# Container.ItemIndex + 1 %>    </td>
                                    <td style="text-align:left;"><asp:Label ID="lblBrand" Text='<%#Eval("party_name")%>' CssClass="text-primary" runat="server" /><br />
                                        <%# DataBinder.Eval(Container.DataItem, "party_phoneno")%> 
                                    </td>
                                     <td style="text-align:left;"><%# DataBinder.Eval(Container.DataItem, "party_email")%> </td>
                                       <td><%# DataBinder.Eval(Container.DataItem, "party_gst")%>   </td>
                                     <td><%# DataBinder.Eval(Container.DataItem, "party_address")%>   </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "party_region")%>   </td>
                                 <%--   <td> <asp:Label ID="lblStatus" Text='<%# Eval("is_active").ToString()=="True" ? "Active":"Deactive"%>' runat="server" /></td>--%>

                               <%--     <td>
                                        <asp:LinkButton ID="btnRun" runat="server" CommandName="run" ToolTip="Mark Running" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-sm btn-primary" Visible="false">Mark Running </asp:LinkButton>
                                       <asp:Label ID="lblStatus" Text='<%#Eval("IsRunning")%>' runat="server" Visible="false" />
                                        <asp:LinkButton ID="btnBook" runat="server" CommandName="book" ToolTip="click to Book" CommandArgument='<%# Eval("Id") %>' CssClass="text-primary text-center"><i class="fa fa-plus"></i> </asp:LinkButton>
                                    </td>--%>
                                     <td class="text-center">
                                        <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                                        <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("party_master_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                                        <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("party_master_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>
                                    </td>

                                     <td class=" text-center btn-group btn-group-xs ">
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("party_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("party_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>         
                            </FooterTemplate>
                        </asp:Repeater>
                             <asp:HiddenField ID="hdfdpartyId" runat="server" />

                         </div>
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
