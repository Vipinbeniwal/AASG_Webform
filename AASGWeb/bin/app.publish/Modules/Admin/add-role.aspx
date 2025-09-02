<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-role.aspx.cs" Inherits="AASGWeb.Modules.Admin.add_role" %>

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

                <asp:HiddenField ID="hdfdroleId" runat="server" />
                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Roles </a>
                        </div>
                        <h2><strong>Add</strong> Role Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtRoleName">Role Name<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control" placeholder="Enter Role Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Select Menus<span class="text-danger">*</span></label>
                               <%-- <asp:ListBox ID="ddlAssignedMenu" runat="server" CssClass="select-chosen select2"  SelectionMode="Multiple" AutoPostBack="true" data-placeholder="Choose Features..">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Text="Item" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Party" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Supplier" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Stock" Value="4"></asp:ListItem>
                                </asp:ListBox>--%>
                                 <asp:ListBox ID="ddlAssignedMenu" runat="server" CssClass="select-chosen select2 " placeholder="Select Menu Items" SelectionMode="Multiple">
                                      <asp:ListItem></asp:ListItem>
                                 </asp:ListBox>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-sm btn-warning" OnClick="btnReset_Click">Reset</asp:LinkButton>
                                <asp:LinkButton ID="btnUpdateRole" runat="server" Visible="false" Text="Update Role" OnClick="btnUpdateRole_Click" CssClass="btn btn-sm btn-success">Update Role</asp:LinkButton>
                                <asp:LinkButton ID="btnAddRole" runat="server" Text="Add Role" OnClick="btnAddRole_Click" CssClass="btn btn-sm btn-primary">Add Role</asp:LinkButton>

                            </div>
                        </div>
                    </div>



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
