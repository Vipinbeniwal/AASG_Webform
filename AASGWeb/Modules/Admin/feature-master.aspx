<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="feature-master.aspx.cs" Inherits="AASGWeb.Modules.Admin.feature_master" %>
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
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Menu Master </a>
                        </div>
                        <h2><strong>Feature</strong>  Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                         <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Feature Name <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtFeatureName" runat="server" CssClass="form-control" placeholder="Enter Feature Name"></asp:TextBox>

                                </div>

                            </div>
                         <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Description <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtFeatureDescription" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control" placeholder="Enter Feature Description"></asp:TextBox>

                                </div>

                            </div>  
                        
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:left">
                                 <button type="submit" class="btn btn-sm btn-primary">Add Menu</button>
                                   <button type="reset" class="btn btn-sm btn-warning">Reset</button>

                            </div>
                        </div>


                    </div>

                      <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>
                                </div>
                                <h2><strong>All</strong>Features</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                           <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center visible-lg">Feature Name</th>
                                        <th class="text-right">Description</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/FId/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">Item Master</a></td>
                                        <td class="text-right"> Add, update and delete item </td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/FId/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">Item Master</a></td>
                                        <td class="text-right"> Add, update and delete item </td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                   <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/FId/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">Item Master</a></td>
                                        <td class="text-right"> Add, update and delete item </td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/FId/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">Item Master</a></td>
                                        <td class="text-right"> Add, update and delete item </td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                  
                                </tbody>
                            </table>
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->


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
