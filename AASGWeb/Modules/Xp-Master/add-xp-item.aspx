<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-xp-item.aspx.cs" Inherits="AASGWeb.Modules.Xp_Master.add_xp_item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
        <!-- Forms General Header -->
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
            <li>Forms</li>
            <li><a href="#">General</a></li>
        </ul>
        <!-- END Forms General Header -->

        <asp:HiddenField ID="hdnXPItemId" runat="server" />
        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                           <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong>Add</strong>XP Item</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                         <div class="col-md-4">
                            <div class="form-group">
                                <label for="brand">Serial Number <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtSerialNumber" runat="server" class="form-control" placeholder="Serial Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="brand">Brand Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtBrand" runat="server" class="form-control" placeholder="Brand Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="model">Item Name <span class="text-danger">*</span></label>
                              
                                <asp:TextBox ID="txtItemName" runat="server" class="form-control" placeholder="Item Name"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                               <label for="model">Item Specification <span class="text-danger">*</span></label>
                              
                                <asp:TextBox ID="txtItemSpecification" runat="server" class="form-control" placeholder="Item Specification"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="actualsqm">Qunatity </label>
                                <asp:TextBox ID="txtItemQuantity" runat="server" class="form-control" Text="0" placeholder="Item Quantity"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="actualsqm">Price</label>
                                <asp:TextBox ID="txtItemPrice" runat="server" class="form-control" Text="0.0" placeholder="Price"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                 <asp:Button ID="BtnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning"  OnClick="BtnReset_Click" />
                                 <asp:Button ID="btnUpdateItem" runat="server" Text="Update Item" class="btn btn-sm btn-primary" OnClick="btnUpdateItem_Click" Visible="false" CssClass="btn btn-sm btn-success"/>
                                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" class="btn btn-sm btn-primary" OnClick="btnAddItem_Click"/>
                            </div>
                        </div>

                    </div>


                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
