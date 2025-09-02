<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-party.aspx.cs" Inherits="AASGWeb.Modules.Admin.add_party" %>

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
            <li>Party Master</li>
            <li><a href="#">Add Party</a></li>
        </ul>
        <!-- END Forms General Header -->

        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Party </a>
                        </div>
                        <h2><strong>Party</strong> Master </h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">Party Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPartyName" runat="server" CssClass="form-control"  onkeypress="return character(event)" placeholder="Enter Party Name" Minlength="1" MaxLength="100"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Contact Person Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Contact Person" Minlength="1" MaxLength="40"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Mobile Number  <span class="text-danger">*</span> </label>
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Mobile" MaxLength="10" Minlength="10"></asp:TextBox>

                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">

                                <label for="example-nf-password">Email <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" Minlength="1" MaxLength="60"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Bill To Address</label>
                                <asp:TextBox ID="txtBillToAddress" runat="server" CssClass="form-control" placeholder="Enter Bill To Address" MaxLength="150"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Region</label>
                                <asp:TextBox ID="txtRegion" runat="server" CssClass="form-control" placeholder="Enter Region" MaxLength="10"></asp:TextBox>

                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">

                                <label for="example-nf-password">State <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="Enter State" MaxLength="20"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">City <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter City"  MaxLength="20"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">PinCode <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" placeholder="Enter Pin Code" onkeypress="return Number(event)" Minlength="4" MaxLength="6"></asp:TextBox>

                            </div>
                        </div>  

                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">GST <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtGstNumber" runat="server" CssClass="form-control"  onkeypress="return character_and_Number(event)" placeholder="Enter GST Number" Minlength="15" MaxLength="15"></asp:TextBox>
<%--                                <asp:TextBox ID="txtGstNumber" runat="server" CssClass="form-control" placeholder="Enter GST Number"></asp:TextBox>--%>

                            </div>
                        </div>
                        <%-- <div class="col-md-4">
                            <div class="form-group">
                                 <label for="example-nf-password">Distance From Origin <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtDistanceFromOrigin" runat="server" CssClass="form-control" placeholder="Distance From Origin"></asp:TextBox>
                               
                            </div>
                        </div>--%>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning" OnClick="btnReset_Click" />
                                <asp:Button ID="BtnUpdate" runat="server" Text="Update Party" class="btn btn-sm btn-success" Visible="false" OnClick="BtnUpdate_Click" />

                                <asp:Button ID="btnAddParty" runat="server" Text="Add Party" class="btn btn-sm btn-primary" OnClick="btnAddParty_Click" />

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
