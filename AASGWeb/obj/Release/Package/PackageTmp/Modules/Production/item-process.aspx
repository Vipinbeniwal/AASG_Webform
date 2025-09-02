<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="item-process.aspx.cs" Inherits="AASGWeb.Modules.Production.item_process" %>

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

        <div id="modal-content">

            <!-- User Settings, modal which opens from Settings link (found in top right user menu) and the Cog link (found in sidebar user info) -->
            <div id="modal-pending-item" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header text-center">
                            <h2 class="modal-title"><i class="fa fa-th-list"></i>Pending Item Master</h2>
                        </div>
                        <!-- END Modal Header -->

                        <!-- Modal Body -->
                        <div class="modal-body">
                            <div onsubmit="return false;">

                                <div class="row">
                                    <div class="col-md-12">

                                        <!-- Normal Form Block -->
                                        <div class="block">
                                            <!-- Normal Form Title -->
                                            <div class="block-title">
                                                <div class="block-options pull-right">
                                                </div>
                                                <h2><strong>Add</strong> Pending Item Quantity</h2>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Department </label>
                                                        <select id="example-department2" name="example-chosen" class="select-chosen" data-placeholder="Choose a Department" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Cutting">Cutting</option>
                                                            <option value="Hole">Hole</option>
                                                            <option value="Washing">Washing</option>
                                                            <option value="Painting">Painting</option>
                                                            <option value="DFG Print">DFG Print</option>

                                                        </select>

                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Pending Quantity </label>
                                                        <input type="email" id="example-if-amount" name="example-if-email" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Current Quantity</label>
                                                        <input type="email" id="example-if-refrence" name="example-if-email" class="form-control" placeholder="" value="30">
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Total </label>
                                                        <input type="email" id="example-if-total" name="example-if-email" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions text-right">
                                                        <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">Close</button>
                                                        <button type="submit" class="btn btn-sm btn-primary">Submit</button>

                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                </div>


                            </div>
                        </div>
                        <!-- END Modal Body -->
                    </div>
                </div>
            </div>
            <!-- END User Settings -->

            <div id="modal-item-broken" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header text-center">
                            <h2 class="modal-title"><i class="fa fa-th-list"></i>Broken Item Master</h2>
                        </div>
                        <!-- END Modal Header -->

                        <!-- Modal Body -->
                        <div class="modal-body">
                            <div onsubmit="return false;">

                                <div class="row">
                                    <div class="col-md-12">

                                        <!-- Normal Form Block -->
                                        <div class="block">
                                            <!-- Normal Form Title -->
                                            <div class="block-title">
                                                <div class="block-options pull-right">
                                                </div>
                                                <h2><strong>Add</strong>  Broken Item</h2>
                                            </div>

                                            <div class="row">

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Department </label>
                                                        <select id="example-department" name="example-chosen" class="select-chosen" data-placeholder="Department" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Cutting">Cutting</option>
                                                            <option value="Hole">Hole</option>
                                                            <option value="Washing">Washing</option>
                                                            <option value="Painting">Painting</option>
                                                            <option value="DFG Print">DFG Print</option>



                                                        </select>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Pcs Number </label>
                                                        <select id="example-pcsnumber" name="example-chosen" class="select-chosen" data-placeholder="Pcs Number" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Pcs 1">Pcs 1</option>
                                                            <option value="Pcs 2">Pcs 2</option>
                                                            <option value="Pcs 3">Pcs 3</option>
                                                            <option value="Pcs 4">Pcs 4</option>
                                                            <option value="Pcs 5">Pcs 5</option>


                                                        </select>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Type </label>
                                                        <select id="example-type" name="example-chosen" class="select-chosen" data-placeholder="Choose a Type" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Broken">Broken</option>
                                                            <option value="Reject">Reject</option>

                                                        </select>

                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Reason </label>
                                                        <input type="email" id="example-if-remarks" name="example-if-email" class="form-control" placeholder="">
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions text-right">
                                                        <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">Close</button>
                                                        <button type="submit" class="btn btn-sm btn-primary">Submit</button>

                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                </div>


                            </div>
                        </div>
                        <!-- END Modal Body -->
                    </div>
                </div>
            </div>

        </div>

        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong></strong>Item Processing</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div id="faq1" class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q1">Item Detail</a></h4>
                            </div>
                            <div id="faq1_q1" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="brand">Item Name <span class="text-danger">*</span></label>


                                                <asp:TextBox ID="txtitemName" runat="server" class="form-control" placeholder="" Text="Ivecco w/5 clear"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Thickness <span class="text-danger">*</span></label>

                                                <asp:TextBox ID="txtthickness" runat="server" class="form-control" placeholder="" Text="5 MM"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Sheet Size</label>
                                                <input type="email" id="example-if-sheetsize" name="example-if-email" class="form-control" placeholder="" value="3660 * 2440" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Date </label>

                                                <asp:TextBox ID="txtprocessingDate" runat="server" CssClass="form-control input-datepicker-close" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>

                                            </div>
                                        </div>
                                        <%--<div class="col-md-4">
                            <div class="form-group">
                                <label for="description">Item Type</label>
                                <select class="form-control">
                                    <option value="D">D</option>
                                    <option value="N">N</option>
                                </select>
                            </div>
                        </div>--%>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="size">Broken sheets in crate</label>
                                                <input type="email" id="example-if-brokensheet" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="size">No of sheet</label>
                                                <input type="email" id="example-if-noofsheet" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">Pcs Cut From sheet</label>
                                                <input type="email" id="example-if-pcscutfromsheet" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">Left over Size</label>
                                                <input type="email" id="example-if-leftoversize" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Sheets Issued</label>
                                                <input type="email" id="example-if-sheetissued" name="example-if-email" class="form-control" placeholder="" value="34" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Target Pcs/Sheet</label>
                                                <input type="email" id="example-if-targetsheet" name="example-if-email" class="form-control" placeholder="" value="3" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="actualsqm">Actual Pcs</label>
                                                <input type="email" id="example-if-actualpcs" name="example-if-email" class="form-control" placeholder="" value="102" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Draft Size</label>
                                                <input type="email" id="example-if-draftsize" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Target Pcs/Draft</label>
                                                <input type="email" id="example-if-targetdraft" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="actualsqm">Actual Pcs</label>
                                                <input type="email" id="example-if-actualpcsdraft" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Pcs. From Rejection</label>
                                                <input type="email" id="example-if-rejectionpcs" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>


                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="actualsqm">Actual Pcs</label>
                                                <input type="email" id="example-if-actualpcsreject" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Total Pcs Transferred</label>
                                                <input type="email" id="example-if-totalpcstransfer" name="example-if-email" class="form-control" placeholder="" value="102" />

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-actions" style="float: right">
                                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                <button type="submit" class="btn btn-sm btn-primary">Submit</button>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q2">Department</a></h4>
                            </div>
                            <div id="faq1_q2" class="panel-collapse collapse">
                                <div class="panel-body">



                                    <!--- Cutting Department Start --->



                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                        <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>Cutting</strong> Department</h2>
                                                </div>
                                                <div class="row">


                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="text" id="example-if-received" name="example-if-email" class="form-control" placeholder="" value="102" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage </label>
                                                            <input type="text" id="example-if-breakage" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred" name="example-if-email" class="form-control" placeholder="" value="102" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="Supervisor">Supervisor</option>
                                                                <option value="In-charge">In-charge</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </div>




                                    <!--- Cutting Department End --->




                                    <!--- Hole Department Start --->

                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                        <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>Hole</strong> Department</h2>
                                                </div>

                                                <div class="row">


                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="text" id="example-if-received2" name="example-if-email" class="form-control" placeholder="" value="102" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">

                                                            <label for="actualsqm" onclick="$('#modal-item-broken').modal('show');">Breakage <i class=" fa fa-plus text-primary"></i></label>
                                                            <input type="text" id="example-if-breakage2" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject2" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred2" name="example-if-email" class="form-control" placeholder="" value="102" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="Supervisor">Supervisor</option>
                                                                <option value="In-charge">In-charge</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- Boken Item Detail Table for Cutting Department Start -->

                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="table-responsive">
                                                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center">Pcs No</th>
                                                                        <th class="text-center">Broken Reason</th>
                                                                        <th class="text-center">Action</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="text-center"><a href="#">Pcs 1</a></td>
                                                                        <td class="text-center">
                                                                            <span>Damage and Bad Quality</span>

                                                                        </td>
                                                                        <td class=" text-center">
                                                                            <div class="btn-group btn-group-xs">
                                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                                                            </div>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-center"><a href="#">Pcs 2</a></td>
                                                                        <td class="text-center">
                                                                            <span>Crack and Size not match</span>

                                                                        </td>
                                                                        <td class=" text-center">
                                                                            <div class="btn-group btn-group-xs">
                                                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="delete" CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                                                            </div>
                                                                        </td>

                                                                    </tr>

                                                                </tbody>
                                                            </table>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="table-responsive">
                                                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                                <thead>
                                                                    <tr>
                                                                        <th class="text-center">Pcs No</th>
                                                                        <th class="text-center">Reject Reason</th>
                                                                        <th class="text-center">Action</th>

                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="text-center"><a href="#">Pcs 1</a></td>
                                                                        <td class="text-center">
                                                                            <span>Damage and Bad Quality</span>

                                                                        </td>
                                                                        <td class=" text-center">
                                                                            <div class="btn-group btn-group-xs">
                                                                                <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                                                            </div>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td class="text-center"><a href="#">Pcs 2</a></td>
                                                                        <td class="text-center">
                                                                            <span>Crack and Size not match</span>

                                                                        </td>
                                                                        <td class=" text-center">
                                                                            <div class="btn-group btn-group-xs">
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete" CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                                                            </div>
                                                                        </td>

                                                                    </tr>


                                                                </tbody>
                                                            </table>

                                                        </div>

                                                    </div>

                                                </div>

                                                <!-- BokenItem Detail Table for Cutting Department End -->
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!--- Hole Department End --->

                                    <!--- Washing Department Start --->
                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                        <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>Washing</strong> Department</h2>
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="email" id="example-if-received-in-washing" name="example-if-email" class="form-control" placeholder="" value="102" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage</label>
                                                            <input type="email" id="example-if-breakage-in-washing" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject-in-washing" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred-in-washing" name="example-if-email" class="form-control" placeholder="" value="102" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="Supervisor">Supervisor</option>
                                                                <option value="In-charge">In-charge</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <!--- Washing Department End --->

                                    <!--- Painting Department Start --->

                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                        <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>Painting</strong> Department</h2>
                                                </div>


                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="email" id="example-if-received-in-Painting" name="example-if-email" class="form-control" placeholder="" value="" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage</label>
                                                            <input type="email" id="example-if-breakage-in-Painting" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject-in-Painting" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred-in-Painting" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="Supervisor">Supervisor</option>
                                                                <option value="In-charge">In-charge</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!--- Painting Department End --->
                                    <!--- DFG Print Department Start --->
                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                        <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>DFG Print</strong> Department</h2>
                                                </div>


                                                <div class="row">


                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="email" id="example-if-received-in-DFG-Print" name="example-if-email" class="form-control" placeholder="" value="" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage</label>
                                                            <input type="email" id="example-if-breakage-in-DFG-Print" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject-in-DFG-Print" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred-in-DFG-Print" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="Supervisor">Supervisor</option>
                                                                <option value="In-charge">In-charge</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>

                                                <!--- DFG Print Department End --->

                                            </div>
                                        </div>
                                    </div>

                                </div>


                                <!-- END Normal Form Content -->
                            </div>
                            <!-- END Normal Form Block -->


                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q3">TOTAL Pre-Processing</a></h4>
                            </div>
                            <div id="faq1_q3" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <!--- Loss  Start --->
                                    <div class="row">


                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="size">ACTUAL (LOSS)- PC</label>
                                                <input type="email" id="example-if-actuallosspc" name="example-if-email" class="form-control" placeholder="" value="102" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">ACTUAL (LOSS) - %</label>
                                                <input type="email" id="example-if-actuallosspercentage" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">TARGET (LOSS)- PC</label>
                                                <input type="email" id="example-if-targetlosspc" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">TARGET (LOSS) - %</label>
                                                <input type="email" id="example-if-targetlossparcentage" name="example-if-email" class="form-control" placeholder="" value="102" />
                                            </div>
                                        </div>

                                    </div>
                                    <!--- Loss End --->

                                    <!--- Tempring Department Start --->

                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                        <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>Tempring</strong> Department</h2>
                                                </div>

                                                <div class="row">


                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="email" id="example-if-received-in-tempring" name="example-if-email" class="form-control" placeholder="" value="102" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage</label>
                                                            <input type="email" id="example-if-breakage-in-tempring" name="example-if-email" class="form-control" placeholder="" value="19" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject-in-tempring" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Ok</label>
                                                            <input type="email" id="example-if-ok-in-tempring" name="example-if-email" class="form-control" placeholder="" value="83" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred-in-tempring" name="example-if-email" class="form-control" placeholder="" value="83" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="In-charge">In-charge</option>
                                                                <option value="Supervisor">Supervisor</option>

                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!--- Tempring Department End --->
                                    <!--- Packing Department Start --->
                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">

                                                        <span data-toggle="tooltip" title="Add Broken" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-item-broken').modal('show');">Add Broken</span>
                                                    </div>
                                                    <h2><strong>Packing</strong> Department</h2>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="email" id="example-if-received-in-Packing" name="example-if-email" class="form-control" placeholder="" value="83" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage</label>
                                                            <input type="email" id="example-if-breakage-in-Packing" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject-in-Packing" name="example-if-email" class="form-control" placeholder="" value="6" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Ok</label>
                                                            <input type="email" id="example-if-ok-in-Packing" name="example-if-email" class="form-control" placeholder="" value="77" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred-in-Packing" name="example-if-email" class="form-control" placeholder="" value="77" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="In-charge">In-charge</option>
                                                                <option value="Supervisor">Supervisor</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>
                                        </div>

                                    </div>

                                    <!--- Packing Department End --->

                                    <!--- Store Department Start --->
                                    <div class="row">
                                        <div class="col-md-12">

                                            <!-- Normal Form Block -->
                                            <div class="block">
                                                <!-- Normal Form Title -->
                                                <div class="block-title">
                                                    <div class="block-options pull-right">
                                                    </div>
                                                    <h2><strong>Store</strong> Department</h2>
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="size">Received</label>
                                                            <input type="email" id="example-if-received-in-Store" name="example-if-email" class="form-control" placeholder="" value="" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Breakage</label>
                                                            <input type="email" id="example-if-breakage-in-Store" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Reject</label>
                                                            <input type="email" id="example-if-reject-in-Store" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Ok</label>
                                                            <input type="email" id="example-if-ok-in-Store" name="example-if-email" class="form-control" placeholder="" value="83" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Transferred</label>
                                                            <input type="email" id="example-if-transferred-in-Store" name="example-if-email" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label for="description">Signature</label>
                                                            <select class="form-control">
                                                                <option value="In-charge">In-charge</option>
                                                                <option value="Supervisor">Supervisor</option>

                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group form-actions" style="float: right">
                                                            <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                            <button type="submit" class="btn btn-sm btn-primary">Next</button>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!--- Store Department End --->


                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q4">TOTAL Processing</a></h4>
                            </div>
                            <div id="faq1_q4" class="panel-collapse collapse">
                                <div class="panel-body">

                                    <!--- Loss  Start --->
                                    <div class="row">


                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="size">ACTUAL (LOSS)- PC</label>
                                                <input type="email" id="example-if-actuallosspc2" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">ACTUAL (LOSS) - %</label>
                                                <input type="email" id="example-if-actuallosspercentage2" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">TARGET (LOSS)- PC</label>
                                                <input type="email" id="example-if-targetlosspc2" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="actualsqm">TARGET (LOSS) - %</label>
                                                <input type="email" id="example-if-targetlossparcentage2" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>

                                    </div>
                                    <!--- Loss End --->

                                    <!--- Tempring Department Start --->
                                    <div class="row">


                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Previous stock in store</label>
                                                <input type="email" id="example-if-previous-stock-in-store" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="actualsqm">Total QTY in Store</label>
                                                <input type="email" id="example-if-total-qty-in-store" name="example-if-email" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="description">Signature</label>
                                                <select class="form-control">
                                                    <option value="In-charge">In-charge</option>
                                                    <option value="Supervisor">Supervisor</option>

                                                </select>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="size">Remarks</label>
                                                <input type="email" id="example-if-remarks-in-total-processing" name="example-if-email" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-actions" style="float: right">
                                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                                <asp:LinkButton ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" href="/production/add-production"> Submit</asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>

                                    <!--- Tempring Department End --->



                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
