<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="option-one.aspx.cs" Inherits="AASGWeb.Modules.Production.option_one" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Party name <span class="text-danger">*</span></label>
                                <input type="email" id="example-if-Mileage" name="example-if-email" class="form-control" placeholder="Enter Vendor Name">
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">City Name <span class="text-danger">*</span></label>
                                <input type="email" id="example-if-Currency" name="example-if-email" class="form-control" placeholder="Enter City Name">
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Hotel Name <span class="text-danger">*</span></label>
                                <input type="email" id="example-if-hotel" name="example-if-email" class="form-control" placeholder="Enter Hotel Name">
                            </div>

                        </div>


                    </div>
                    <div class="row">

                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Check In<span class="text-danger">*</span></label>
                                <input type="email" id="example-if-fromDate" name="example-if-email" class="form-control input-datepicker-close" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy">
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Check Out <span class="text-danger">*</span></label>
                                <input type="email" id="example-if-toDate" name="example-if-email" class="form-control input-datepicker-close" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy">
                            </div>

                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">Room <span class="text-danger">*</span></label>
                                <input type="email" id="example-if-room" name="example-if-email" class="form-control" placeholder="Enter Hotel Name">
                            </div>

                        </div>

                    </div>
                    <div class="row">

                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">OC<span class="text-danger">*</span></label>
                                <input type="email" id="example-if-oc" name="example-if-email" class="form-control" placeholder="0">
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">PC <span class="text-danger">*</span></label>
                                <input type="email" id="example-if-pc" name="example-if-email" class="form-control" placeholder="0">
                            </div>

                        </div>

                        <div class="col-md-3">
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <button type="submit" class="btn btn-sm btn-primary">Add</button>
                            </div>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                    <thead>
                                        <tr>
                                            <th class="text-center" style="width: 100px;">ID</th>
                                            <th class="text-center ">Party Id</th>
                                            <th class="text-center ">Party Name</th>
                                           
                                            <th class="text-center">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="text-center"><a href="#"><strong>1</strong></a></td>
                                            <td class=""><a href="javascript:void(0)">100</a></td>
                                            <td class=""><a href="javascript:void(0)">Raj Verma</a></td>
                                           

                                            <td class="text-center">
                                                <div class="btn-group btn-group-xs">

                                                    <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center"><a href="#"><strong>1</strong></a></td>
                                            <td class=""><a href="javascript:void(0)">101</a></td>
                                            <td class=""><a href="javascript:void(0)">Ajit Singh</a></td>
                                           

                                            <td class="text-center">
                                                <div class="btn-group btn-group-xs">

                                                    <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                                </div>
                                            </td>
                                        </tr>

                                    </tbody>


                                </table>
                            </div>
                        </div>

                    </div>


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
