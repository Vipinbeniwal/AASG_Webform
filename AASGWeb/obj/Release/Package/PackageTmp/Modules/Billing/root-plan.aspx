<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="root-plan.aspx.cs" Inherits="AASGWeb.Modules.Billing.root_plan" %>

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

        <ul class="breadcrumb breadcrumb-top">
            <li>Billing</li>
            <li><a href="/add-return">Add Root-Plan</a></li>
        </ul>
        <!-- END Forms General Header -->
        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Excel Export</a>
                </div>
                <h2><strong>Add</strong> Root-Plan</h2>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-email">Root Name <span class="text-danger">*</span></label>
                        <select id="example-chosen" name="example-chosen" class="select-chosen" data-placeholder="Choose a Client Name..">
                            <option></option>
                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                            <option value="Root-1">Root-1</option>
                            <option value="Root-2">Root-2</option>
                            <option value="Root-3">Root-3</option>
                            <option value="Root-4">Root-4</option>

                        </select>
                    </div>

                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-email">Person Name <span class="text-danger">*</span></label>
                        <select id="example-chosen2" name="example-chosen" class="select-chosen" data-placeholder="Choose a Project Name..">
                            <option></option>
                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                            <option value="Ajay">Ajay</option>
                            <option value="Vijay">Vijay</option>
                            <option value="Raj">Raj</option>

                        </select>
                    </div>

                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Mobile No <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" placeholder="Enter Contact Person"></asp:TextBox>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password">Slot Name <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Dispatched From</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Dispatched From"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Dispatched Destinaton</label>
                        <asp:TextBox ID="txtGst" runat="server" CssClass="form-control" placeholder="Enter Dispatched"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                 <button type="submit" class="btn btn-sm btn-primary"> Add Root Plan</button>

                            </div>
                        </div>


                    </div>

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
