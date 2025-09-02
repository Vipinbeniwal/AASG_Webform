<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="add-return.aspx.cs" Inherits="AASGWeb.Modules.Billing.add_return" %>
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
                      
                        <ul class="breadcrumb breadcrumb-top">
                            <li>Returns</li>
                            <li><a href="/add-return">Add Return</a></li>
                        </ul>
                        <!-- END Forms General Header -->
                        <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                        <div class="block-options pull-right">
                                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Excel Export</a>
                                        </div>
                                        <h2><strong>Add</strong> Return</h2>
                                    </div>
                           
                              <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-email">Return From <span class="text-danger">*</span></label>
                        <select id="example-chosen" name="example-chosen" class="select-chosen" data-placeholder="Choose a Client Name..">
                            <option></option>
                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                            <option value="Nijo Tech Delhi">Nijo Tech Delhi</option>
                            <option value="Nijo Tech Mumbai">Nijo Tech Mumbai</option>
                            <option value="Nijo Tech Rohtak">Nijo Tech Rohtak</option>
                           

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

                        <label for="example-nf-password">Slot Number <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Item Name <span class="text-danger">*</span></label>
                        <select id="example-chosen3" name="example-chosen" class="select-chosen" data-placeholder="Choose a Item Name..">
                            <option></option>
                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                            <option value="Mouse">Mouse</option>
                            <option value="Keyboard">Keyboard</option>
                            <option value="Laptop">Laptop</option>

                        </select>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Item Quantity <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtItemQuantity" runat="server" CssClass="form-control" placeholder="Enter Item Quantity"></asp:TextBox>

                    </div>
                </div>

            </div>

                            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Return Reason <span class="text-danger">*</span></label>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Dispatched"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Return Date <span class="text-danger">*</span></label>
                         <input type="text" id="example-datepicker4" name="example-datepicker4" class="form-control input-datepicker" data-date-format="mm-dd-yyyy" placeholder="mm-dd-yyyy">
                     
                    </div>
                </div>
                
            </div>

            <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                 <button type="submit" class="btn btn-sm btn-primary"> Add Return</button>

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
