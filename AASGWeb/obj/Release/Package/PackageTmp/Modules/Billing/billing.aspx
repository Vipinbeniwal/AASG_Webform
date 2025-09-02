<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="billing.aspx.cs" Inherits="AASGWeb.Modules.Billing.billing" %>
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
                            <li>Billing</li>
                            <li><a href="/add-return">Add Billing</a></li>
                        </ul>
                        <!-- END Forms General Header -->
                        <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                        <div class="block-options pull-right">
                                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Excel Export</a>
                                        </div>
                                        <h2><strong>Add</strong> Billing</h2>
                                    </div>
                           
                            <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                       
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-user"></i></span>
                                                <input type="text" id="example-username" name="example-username" class="form-control" placeholder="Username">
                                            </div>
                                        </div>
                                        </div>
                                         <div class="col-md-4">
                                             <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                                                <input type="email" id="example-email" name="example-email" class="form-control" placeholder="Email">
                                            </div>
                                        </div>
                                        </div>
                                         <div class="col-md-4">
                                             <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                                <input type="password" id="example-password" name="example-password" class="form-control" placeholder="Password">
                                            </div>
                                        </div>
                                        </div>
                                         
                                    </div>

                                   <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                       
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-user"></i></span>
                                                <input type="text" id="example-username1" name="example-username" class="form-control" placeholder="Username">
                                            </div>
                                        </div>
                                        </div>
                                         <div class="col-md-4">
                                             <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                                                <input type="email" id="example-email1" name="example-email" class="form-control" placeholder="Email">
                                            </div>
                                        </div>
                                        </div>
                                         <div class="col-md-4">
                                             <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                                <input type="password" id="example-password1" name="example-password" class="form-control" placeholder="Password">
                                            </div>
                                        </div>
                                        </div>
                                         
                                       

                                    </div>

                            <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                       
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-user"></i></span>
                                                <input type="text" id="example-username3" name="example-username" class="form-control" placeholder="Username">
                                            </div>
                                        </div>
                                        </div>
                                         <div class="col-md-4">
                                             <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-envelope"></i></span>
                                                <input type="email" id="example-email3" name="example-email" class="form-control" placeholder="Email">
                                            </div>
                                        </div>
                                        </div>
                                         <div class="col-md-4">
                                             <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="gi gi-asterisk"></i></span>
                                                <input type="password" id="example-password3" name="example-password" class="form-control" placeholder="Password">
                                            </div>
                                        </div>
                                        </div>
                                         
                                       

                                    </div>
                                        
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group form-actions">
                                            <button type="submit" class="btn btn-sm btn-success"><i class="fa "></i> Register</button>
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
