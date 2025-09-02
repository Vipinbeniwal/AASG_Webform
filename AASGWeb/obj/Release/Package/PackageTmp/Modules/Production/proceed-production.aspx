<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="proceed-production.aspx.cs" Inherits="AASGWeb.Modules.Production.proceed_production" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-xs, .btn-group-xs > .btn {
            padding: 0px 5px;
            font-size: 8px !important;
            line-height: 1.6;
            border-radius: 3px;
        }

        .table thead tr th {
            padding: 5px 0;
        }

        .table tbody tr td {
            padding: 3px 0;
        }
    </style>
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
                        <h2><strong>Add</strong> Production</h2>
                        <label class="label label-success">[Weight: 1123.10 Kg] </label>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->


                    <!--- Plant 1 Start --->
                    <div class="block full">
                        <!-- All Orders Title -->
                        <div class="block-title">
                            <div class="block-options pull-right">
                                <%-- <a href="#" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                            </div>
                            <h2><strong>Plant</strong>One</h2>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <th class="text-center" style="width: 100px;">S No</th>
                                                <th class="text-center ">Model</th>
                                                <th class="text-center ">Item Name</th>
                                                <th class="text-center ">Production. Qty</th>
                                                <th class="text-center ">Current Status</th>
                                                <th class="text-center ">Cutting</th>
                                                <th class="text-center ">Hole</th>
                                                <th class="text-center ">Washing</th>
                                                <th class="text-center ">Paint</th>
                                                <th class="text-center ">DFG</th>
                                                <th class="text-center ">Start Date</th>
                                                <th class="text-center " style="width: 70px">Shift</th>
                                                <th class="text-center ">Action</th>


                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>1</strong></a></td>
                                                <td class="text-center"><a href="/production/item-process">Alto</a></td>
                                                <td class="text-center">Front Door</td>
                                                <td class="text-center">30</td>
                                                <td class="text-center">
                                                    <label class="label label-danger">Proccessing</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                 <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>
                                               <td class="text-center">
                                                    <button type="submit" class="btn btn-sm btn-primary">Start</button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>2</strong></a></td>
                                                <td class="text-center"><a href="/production/item-process">Toyota</a></td>
                                                <td class="text-center">Wind Screen</td>
                                                <td class="text-center">30</td>
                                                <td class="text-center">
                                                    <label class="label label-success">done</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-danger">Proccessing</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                 <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>
                                                <td class="text-center">
                                                    <button type="submit" class="btn btn-sm btn-primary">Start</button>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>2</strong></a></td>
                                                <td class="text-center"><a href="/production/item-process">Maruti</a></td>
                                                <td class="text-center">Wind Screen</td>
                                                <td class="text-center">40</td>
                                                <td class="text-center">
                                                    <label class="label label-success">done</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-success">done</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-success">done</label>
                                                </td>
                                                <td class="text-center">
                                                    <label class="label label-danger">Proccessing</label>
                                                </td>
                                                 <td class="text-center">
                                                    <label class="label label-warning">Pending</label>
                                                </td>
                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>
                                                <td class="text-center">
                                                    <button type="submit" class="btn btn-sm btn-primary">Start</button>
                                                </td>

                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                        </div>
                        <!-- END All Role Block -->
                    </div>

                    <!-- Plant 1 End -->

                    <!-- Plant 2 Start -->

                    <div class="block full">
                        <!-- All Orders Title -->
                        <div class="block-title">
                            <div class="block-options pull-right">
                                <%-- <a href="#" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                            </div>
                            <h2><strong>Plant</strong>Two</h2>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table id="ecom-orders3" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <th class="text-center" style="width: 100px;">S No</th>
                                                <th class="text-center ">Model</th>
                                                <th class="text-center ">Item Name</th>
                                                <th class="text-center ">Production. Qty</th>
                                                <th class="text-center ">Start Date</th>
                                                <th class="text-center " style="width: 70px">Shift</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>1</strong></a></td>
                                                <td class="text-center"><a href="/production/item-process">Alto</a></td>
                                                <td class="text-center">Front Door</td>
                                                <td class="text-center">30</td>
                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>2</strong></a></td>

                                                <td class="text-center"><a href="/production/item-process">Toyota</a></td>
                                                <td class="text-center">Wind Screen</td>
                                                <td class="text-center">40</td>
                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>

                                            </tr>

                                        </tbody>


                                    </table>
                                </div>
                            </div>

                        </div>
                        <!-- END All Role Block -->
                    </div>


                    <!--- Plant 2 End -->

                    <!-- Plant 3 Start -->

                    <div class="block full">
                        <!-- All Orders Title -->
                        <div class="block-title">
                            <div class="block-options pull-right">
                                <%-- <a href="#" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                            </div>
                            <h2><strong>Plant</strong>Three</h2>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table id="ecom-orders4" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <th class="text-center" style="width: 100px;">S No</th>
                                                <th class="text-center ">Model</th>
                                                <th class="text-center ">Item Name</th>
                                                <th class="text-center ">Production. Qty</th>
                                                <th class="text-center ">Start Date</th>
                                                <th class="text-center " style="width: 70px">Shift</th>


                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>1</strong></a></td>
                                                <td class="text-center"><a href="/production/item-process">Alto</a></td>
                                                <td class="text-center">Front Door</td>
                                                <td class="text-center">25</td>
                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="text-center"><a href="#"><strong>2</strong></a></td>
                                                <td class="text-center"><a href="/production/item-process">Alto</a></td>

                                                <td class="text-center">Front Door</td>
                                                <td class="text-center">22</td>

                                                <td class="text-center">30-12-2021</td>

                                                <td>
                                                    <select class="form-control">
                                                        <option value="D">D</option>
                                                        <option value="N">N</option>
                                                    </select>
                                                </td>

                                            </tr>

                                        </tbody>


                                    </table>
                                </div>
                            </div>

                        </div>
                        <!-- END All Role Block -->
                    </div>


                    <!--- Plant 3 End -->


                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <%--<asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning" OnClick="btnReset_Click" />
                                  <asp:Button ID="btnAddTour" runat="server" Text="Add Tour" class="btn btn-sm btn-primary" OnClick="btnAddTour_Click" />
                                --%>
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                <button type="submit" class="btn btn-sm btn-primary">Submit</button>

                            </div>
                        </div>
                    </div>


                    <!-- END Normal Form Content -->

                    <!-- END Normal Form Block -->


                </div>

            </div>
        </div>
        <!-- END All Role Block -->

        <!-- Manage Tour Start -->

        <!-- End Manage Tour -->

    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
