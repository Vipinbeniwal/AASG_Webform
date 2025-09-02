<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="plant-wise-items.aspx.cs" Inherits="AASGWeb.Modules.Production.plant_wise_items" %>
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

       
        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                  
                </div>
                <h2><strong>Plant Wise</strong> Items List</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-email">Select Plant <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlPlantWise" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Plant">
                            
                            <asp:ListItem Value="PlantOne">PlantOne</asp:ListItem>
                            <asp:ListItem Value="PlantTwo">PlantTwo</asp:ListItem>
                            <asp:ListItem Value="PlantThree">PlantThree</asp:ListItem>

                        </asp:DropDownList>
                    </div>

                </div>
            </div>

                 <!-- All Orders Content -->
                          <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center"> Name</th>
                                        <th class="text-center">Grinding</th>
                                        <th class="text-center">Hole</th>
                                        <th class="text-center">Washing</th>
                                        <th class="text-center">Painting</th>
                                        <th class="text-center">DFG Print</th>
                                        <th class="text-center">Date</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>100</strong></a></td>
                                        <td class="text-center"><a href="#">Front Door</a></td>
                                        <td class="text-center">
                                             <label class="label label-success">done</label>
                                        </td>
                                        <td class="text-center">
                                            <label class="label label-success">done</label>

                                        </td>
                                        <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                         <td class="text-center">
                                            <label class="label label-default">Not Required</label>

                                        </td>
                                         <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                        <td class="text-center">05/01/2022</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="/production/cutting" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                
                                            </div>
                                        </td>
                                    </tr>
                               <tr>
                                        <td class="text-center"><a href="#"><strong>101</strong></a></td>
                                        <td class="text-center"><a href="#">Wind Screen</a></td>
                                        <td class="text-center">
                                            <label class="label label-success">done</label>

                                        </td>
                                        <td class="text-center">
                                            <label class="label label-success">done</label>

                                        </td>
                                        <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                         <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                         <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                        <td class="text-center">09/01/2022</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="/production/cutting" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                
                                                </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>102</strong></a></td>
                                        <td class="text-center"><a href="#">Front Door</a></td>
                                        <td class="text-center">
                                            <label class="label label-success">done</label>

                                        </td>
                                        <td class="text-center">
                                            <label class="label label-success">done</label>

                                        </td>
                                        <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                         <td class="text-center">
                                            <label class="label label-default">Not Required</label>

                                        </td>
                                         <td class="text-center">
                                            <label class="label label-danger">pending</label>

                                        </td>
                                        <td class="text-center">10/01/2022</td>
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="/production/cutting" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                
                                            </div>
                                        </td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                            <!-- END All Orders Content -->

         
            <asp:HiddenField ID="hdfdTimeSheetHeaderId" runat="server" />

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
