<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-lead.aspx.cs" Inherits="AASGWeb.Modules.Lead.manage_lead" %>
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
                     

                        <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>
                                </div>
                                <h2><strong>All</strong> Leads</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                            <div class="table-responsive">
                        <asp:Repeater ID="rptrLead" runat="server"  OnItemCommand="rptrLead_ItemCommand" OnItemDataBound="rptrLead_ItemDataBound">
                            <HeaderTemplate>
                            <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 20px;">ID</th>
                                        <th class="text-left">Client name</th>
                                        <th class="text-left">Contact Person</th>
                                        <th class="text-left">PhoneNo</th>
                                        <th class="text-left" >Date</th>
                                        <th class="text-left">Lead Remarks</th>
                                         <th class="text-left">Follow Up</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                 </HeaderTemplate>
                                <ItemTemplate>
                                <tr>
                                    <td style="text-align:center;"><%# Container.ItemIndex + 1 %> </td>
                                    <td style="text-align:left;"> <asp:Label ID="lble" Text='<%#Eval("party_name")%>' runat="server" /> </td>
                                    <td style="text-align:left;"><%# DataBinder.Eval(Container.DataItem, "party_contact_person")%> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "party_phoneno")%> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "followup_date","{0:d}")%> </td>
                                    <td><%# DataBinder.Eval(Container.DataItem, "lead_remarks")%> </td>

                                    <td class="text-center btn-group-xs  ">
                                        <asp:LinkButton ID="btnAddFollowUp" runat="server" CommandName="addfollowup" CommandArgument='<%# Eval("lead_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to Add" data-original-title="Basic tooltp"><i class="fa fa-pencil"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnViewFollowUp" runat="server" CommandName="viewfollowup" CommandArgument='<%# Eval("lead_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to View" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                    </td>
                                   <td class=" text-center btn-group btn-group-xs ">
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("lead_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                       </td>
                                </tr>
                                </ItemTemplate>
                            <FooterTemplate>
                                </table>         
                            </FooterTemplate>
                        </asp:Repeater>
                            </div>
                             <asp:HiddenField ID="hdfdLeadId" runat="server" />
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
