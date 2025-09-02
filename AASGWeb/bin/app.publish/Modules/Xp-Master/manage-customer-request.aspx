<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="manage-customer-request.aspx.cs" Inherits="AASGWeb.Modules.Xp_Master.manage_customer_request" %>
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

        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>
                </div>
                <h2><strong>All</strong> Customers Request Details</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->

                 <!-- All Orders Content -->
                          <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="visible-lg">Customer Name</th>
                                        <th class="hidden-xs text-center">Item Quantity</th>
                                        <th class="hidden-xs text-center">Date</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>100</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Deepak</a></td>
                                        <td class="text-center hidden-xs"><strong>30</strong></td>
                                        <td class="hidden-xs text-center">25/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="/view_customer-request-details" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="#" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               <tr>
                                        <td class="text-center"><a href="#"><strong>101</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Ashok</a></td>
                                       
                                        <td class="text-center hidden-xs"><strong>10</strong></td>
                                        <td class="hidden-xs text-center">18/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="/view_customer-request-details" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="#" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>102</strong></a></td>
                                        <td class="visible-lg"><a href="javascript:void(0)">Joginder</a></td>
                                        <td class="text-center hidden-xs"><strong>10</strong></td>
                                        <td class="hidden-xs text-center">20/12/2014</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="/view_customer-request-details" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="#" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                            <!-- END All Orders Content -->

            <%--<asp:Repeater ID="rptrManageTimeSheet" runat="server" OnItemCommand="rptrManageTimeSheet_ItemCommand" OnItemDataBound="rptrManageTimeSheet_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 100px;">SR.No</th>
                                 <th class="text-center" >Employee Name</th>
                                <th class="text-center visible-lg">Total Hours </th>
                                <th class="text-center hidden-xs">Date</th>
                                <th>Status</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="text-center"><a href="#"><strong><%# Container.ItemIndex + 1 %></strong></a>    </td>

                        <td class="visible-lg text-center">
                            <asp:Label ID="lblStaffName" Text='<%#Eval("staff_name")%>' runat="server"> </asp:Label>
                        </td>
                        <td class="visible-lg text-center">
                            <asp:Label ID="lblhours" Text='<%#Eval("total_hours")%>' runat="server"> </asp:Label>
                        </td>
                        
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lbldate" Text='<%#Eval("created_on","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>
                        </td>
                       
                        <td class="text-center">
                            <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                            <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("time_sheet_header_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                            <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("time_sheet_header_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>

                        </td>
                        <td class=" text-center  btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("time_sheet_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                            <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("time_sheet_header_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>--%>
            <asp:HiddenField ID="hdfdTimeSheetHeaderId" runat="server" />

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
