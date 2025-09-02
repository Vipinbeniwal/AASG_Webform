<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" ValidateRequest="true" EnableEventValidation="false" CodeBehind="add-tour.aspx.cs" Inherits="AASGWeb.Modules.Admin.add_tour" %>
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
                        </div>
                        <h2><strong>Tour</strong>  Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                         <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Tour Name <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtTourName" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Tour Name"></asp:TextBox>

                                </div>

                            </div>
                        <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Start Date <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtStartDate" runat="server"  CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>

                                </div>

                            </div>
                        <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">End Date <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy" OnTextChanged="txtEndDate_TextChanged"></asp:TextBox>

                                </div>

                            </div>
                    </div>

                    <div class="row">
                         <div class="col-md-4">
                                <div class="form-group">
                                    <label for="example-nf-email">Employee Name <span class="text-danger">*</span></label>
                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="select-chosen" onkeypress="return character(event)" AutoPostBack="false" data-placeholder="Choose a Employee..">
                                       <%-- <asp:ListItem Selected="True" Value="0" Text="Select"></asp:ListItem>--%>
                                    </asp:DropDownList>

                                </div>

                            </div>
                        <div class="col-md-8">
                                <div class="form-group">
                                    <label for="example-nf-email">Tour Agenda <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtTourAgenda" runat="server" CssClass="form-control" placeholder="Enter Tour Agenda"></asp:TextBox>


                                </div>

                            </div>
                         
                        </div>
                    <div class="row">
                        <div class="col-md-4">
                                <div class="form-group">
                                    <asp:TextBox ID="txtNumberOfDays" runat="server" CssClass="form-control" Visible="false" placeholder="Number of Days"></asp:TextBox>
                                </div>
                            </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                 <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning" OnClick="btnReset_Click" />
                                  <asp:Button ID="btnAddTour" runat="server" Text="Add Tour" class="btn btn-sm btn-primary" OnClick="btnAddTour_Click" />

                            </div>
                        </div>
                    </div>


                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>
        <!-- END All Role Block -->

        <!-- Manage Tour Start -->

         

        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                  <%--  <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                </div>
                <h2><strong>All</strong> Tour</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->

            <asp:Repeater ID="rptrTourMaster" runat="server" OnItemCommand="rptrTourMaster_ItemCommand" OnItemDataBound="rptrTourMaster_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 100px;">ID</th>
                                <th class="text-center visible-lg">Tour Name</th>
                                <th class="text-center">Tour Start Date</th>
                                <th class="text-center" >Tour End Date</th>
                                <th class="text-center ">Tour Agenda</th>
                                <th class="text-center">Status</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="text-center"><a href="#"><strong><%# Container.ItemIndex + 1 %></strong></a>    </td>

                        <td class="visible-lg text-center">
                            <asp:Label ID="lnltourName" Text='<%#Eval("tour_name")%>' runat="server"> </asp:Label>
                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblSyartDate" Text='<%#Eval("start_date","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>
                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblEndDate" Text='<%#Eval("end_date","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>

                        </td>
                        <td class="visible-lg text-center">
                            <asp:Label ID="lblAgenda" Text='<%#Eval("tour_agenda")%>' runat="server"> </asp:Label>
                        </td>

                        <td class="text-center">
                            <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                            <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("tour_master_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                            <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("tour_master_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>

                        </td>
                        <td class=" text-center  btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("tour_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-pencil"></i></asp:LinkButton>
                            <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("tour_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hdfdTourId" runat="server" />

            <!-- END All Orders Content -->
        </div>

        <!-- End Manage Tour -->

    </div>
    <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
