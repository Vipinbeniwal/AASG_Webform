<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-tour-grade.aspx.cs" Inherits="AASGWeb.Modules.Admin.add_tour_grade" %>

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
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Approve Tour </a>
                        </div>
                        <h2><strong>Tour Grade </strong>Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Grade Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtGradeName" runat="server" CssClass="form-control" placeholder="Enter Grade Name"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Per Day Transport <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtTransportAllowance" runat="server" CssClass="form-control" placeholder="Transport Allowance" Text="0.0"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Per Day Food<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtFoodAllowance" runat="server" CssClass="form-control" placeholder="Food Allowance" Text="0.0"></asp:TextBox>
                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Per Day Hotel <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtHotelAllowance" runat="server" CssClass="form-control" placeholder="Hotel Allowance" Text="0.0"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Per Day Misc <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtMiscAllowance" runat="server" CssClass="form-control" placeholder="Hotel Allowance" Text="0.0"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning" OnClick="btnReset_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update Tour Grade" Visible="false" class="btn btn-sm btn-success" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnAddTourGrade" runat="server" Text="Add Tour Grade" class="btn btn-sm btn-primary" OnClick="btnAddTourGrade_Click" />

                            </div>
                        </div>
                    </div>


                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>
        <!-- END All Role Block -->
        <div class="row">
            <div class="col-md-12">
                <div class="block full">
                    <!-- All Orders Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>
                        </div>
                        <h2><strong>All</strong> DropdownMaster Types</h2>
                    </div>
                    <!-- END All Orders Title -->


                    <asp:Repeater ID="rptrTourGradeType" runat="server" OnItemCommand="rptrTourGradeType_ItemCommand" OnItemDataBound="rptrTourGradeType_ItemDataBound">
                        <HeaderTemplate>
                            <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr class="bg-primary">
                                        <th class="design" style="width: 20px;">ID</th>
                                        <th class="design">Grade Name</th>
                                        <th class="design">Per Day Transport</th>
                                        <th class="design">Per Day Food</th>
                                        <th class="design">Per Day Hotel</th>
                                        <th class="design">Per Day Misc</th>
                                        <th class="text-left">Action</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex + 1 %>    </td>
                                <td style="text-align: left;">
                                    <asp:Label ID="lblGradeName" Text='<%#Eval("tourgrade_name")%>' runat="server" />
                                </td>
                                <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "tourgrade_perday_transport")%> </td>
                                <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "tourgrade_perday_food")%> </td>
                                <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "tourgrade_perday_hotel")%> </td>
                                <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "tourgrade_perday_misc")%> </td>
                                <td class="text-center">
                                    <div class="btn-group btn-group-xs">
                                        <%--<a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>--%>

                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("tourgrade_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-pencil"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("tourgrade_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>

                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>         
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hdfTourGradeMasterId" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
