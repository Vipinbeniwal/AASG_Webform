<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-tour.aspx.cs" Inherits="AASGWeb.Modules.Admin.my_tour" %>
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
    <!-- END Dashboard 2 Header -->
        <ul class="breadcrumb breadcrumb-top">
            <li>Forms</li>
            <li><a href="#">General</a></li>
        </ul>
        <!-- END Forms General Header -->
    <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Assign Tour </a>
                        </div>
                        <h2><strong>Tour</strong> Allownance Approval</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                   <%-- <div class="row">
                        
                         <div class="col-md-4">
                              <div class="form-group">
                                    <label for="example-nf-email">Authorized By <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtAuthorizeName" runat="server" CssClass="form-control" placeholder="Authorized By"></asp:TextBox>

                                </div>

                            </div>
                         <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Date Submitted<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="Enter Date"></asp:TextBox>

                                </div>

                            </div>
                    
                    </div>--%>
             

                     <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                   <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                                </div>
                                <h2><strong>All</strong> Pending Approvals</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                            <div class="table-responsive">
                            <asp:Repeater ID="rptrManageTour" runat="server" OnItemCommand="rptrManageTour_ItemCommand">
                            <HeaderTemplate>
                           <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 30px;">ID</th>
                                        <th class="text-center" >Req Date</th>
                                        <th class="text-left">Tour Name</th>
                                        <th class="text-center">Employee Name</th>
                                         <th class="text-center">Start Date</th>
                                          <th class="text-center">End Date</th>
                                        <th class="text-center">Number Of Days</th>
                                         <th class="text-center" style="width: 100px;">Expense Total</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                 </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center"><%# Container.ItemIndex + 1 %>    </td>
                                     <td><%# DataBinder.Eval(Container.DataItem, "reqdate","{0:d}")%> </td> 
                                    <td style="text-align:left;">
                                        <asp:Label ID="lblDropdownType" Text='<%#Eval("tour_name")%>' runat="server" />       
                                    </td>
                                     <td class="text-center">
                                                <asp:Label ID="lblStaffName" Text='<%#Eval("staff_name")%>' runat="server" />       
                                            </td>
                                       <td><%# DataBinder.Eval(Container.DataItem, "start_date","{0:d}")%> </td>  
                                           <td><%# DataBinder.Eval(Container.DataItem, "end_date","{0:d}")%>  </td> 
                                             
                                               <td class="text-center"><%# DataBinder.Eval(Container.DataItem, "tour_numberofdays")%>   </td>
                                       <td class="text-center"><%# DataBinder.Eval(Container.DataItem, "expense_total")%>   </td>
                                     <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                               <%-- <a href="page_ecom_order_view.html" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>--%>
                                                 <asp:LinkButton ID="btnView" runat="server" CommandName="view" CommandArgument='<%# Eval("tour_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="View Tour" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                               <%-- <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>--%>
                                            </div>
                                        </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>         
                            </FooterTemplate>
                        </asp:Repeater>
                            <!-- END All Orders Content -->
                        
                        <!-- END All Orders Block -->
                            <asp:HiddenField ID="hdfdtourId" runat="server" />

                            </div>
                    </div>
                  <%--  <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                 <button type="submit" class="btn btn-sm btn-primary">Add Tour</button>

                            </div>
                        </div>


                    </div>--%>


                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>
        <!-- END All Role Block -->
    </div>
    <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
