<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="tempring.aspx.cs" Inherits="AASGWeb.Modules.Production.tempring" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function scrollToLocation(Location) {
            $('html, body').animate({
                scrollTop: ($("" + Location + "").offset().top - 10)
            }, 1000);
        }
    </script>
    
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
        .custom-dropdown{
            display: inline-block !important;
            width:16% !important;
            font-size:12px !important ;
            padding: 1px 1px !important ;
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
        <asp:HiddenField ID="hdnItemId" runat="server" />
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
                                                            <option value="Tempring" selected>Tempring</option>

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
                                                        <input type="email" id="example-if-refrence" name="example-if-email" class="form-control" placeholder="" value="102">
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

                                                            <option value="Tempring">Tempring</option>

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
                            <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>
                            <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong></strong>Tempring Department</h2>
                    </div>
                    <!-- END Normal Form Title -->



                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="brand">Report Date </label>
                                <asp:TextBox ID="txtReportDate" runat="server" CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">

                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="model">HTF Shift (From)</label>
                                        <asp:TextBox ID="txtHtfShiftFrom" runat="server" CssClass="form-control" onkeypress="return Number(event)" MaxLength="2"></asp:TextBox>


                                    </div>
                                    <div class="col-md-6">
                                        <label for="model">HTF Shift (To) </label>
                                        <asp:TextBox ID="txtHtfShiftTo" runat="server" CssClass="form-control" onkeypress="return Number(event)" MaxLength="2"></asp:TextBox>


                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="description">Plant Number</label>
                                <asp:TextBox ID="txtPlantName" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
                                <%--<input type="text" id="example-if-plantnumber" name="example-if-text" class="form-control" placeholder="" value="Plant One" />--%>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="description">Report Shift (D/N) </label>
                                <asp:DropDownList ID="ddlProductionShift" runat="server" class="form-control">
                                    <asp:ListItem Value="Day" Selected="True">Day</asp:ListItem>
                                    <asp:ListItem Value="Night">Night</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="description">Batch Number </label>
                                <asp:TextBox ID="txtBatchNumber" runat="server" CssClass="form-control" onkeypress="return Number(event)" MaxLength="30"></asp:TextBox>
                                <%--<input type="text" id="example-if-batchnumber" name="example-if-email" class="form-control" placeholder="" value="123456" />--%>
                            </div>
                        </div>
                    </div>

                    <!-- Normal Form Content -->
                    <div id="faq1" class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q1">SECTION 1: TO BE FILED BY PRODUCTION MANAGER</a></h4>
                            </div>
                            <div id="faq1_q1" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="brand">Item Name <span class="text-danger">*</span></label>


                                                <asp:TextBox ID="txtItemName" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text=""></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Quantity (In Pcs) <span class="text-danger">*</span></label>

                                                <asp:TextBox ID="txtQuantityInPcs" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text="" MaxLength="3"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Production Target (Pcs)</label>
                                                <asp:TextBox ID="txtProductionTargetInPcs" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text="" MaxLength="3"></asp:TextBox>
                                                <%--<input type="email" id="example-if-productiontargetinpcs" name="example-if-text" class="form-control" placeholder="" value="" />--%>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Production Target (%) </label>
                                                <%--<input type="email" id="example-if-productiontargetinpercentage" name="example-if-text" class="form-control" placeholder="" value="" />--%>
                                                <asp:TextBox ID="txtProductionTargetInPercentage" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text="" MaxLength="6"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="brand">Operator Name </label>
                                                <asp:TextBox ID="txtOperatorName" runat="server" onkeypress="return character(event)" class="form-control" placeholder="" Text="" MaxLength="30"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Line Incharge <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtLineIncharge" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Helper 1 <span class="text-danger">*</span> </label>
                                                <asp:TextBox ID="txtHelperOne" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Helper 2</label>
                                                <asp:TextBox ID="txtHelperTwo" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>

                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="brand">Helper 3</label>
                                                <asp:TextBox ID="txtHelperThree" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Helper 4 </label>
                                                <asp:TextBox ID="txtHelperFour" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Helper 5</label>
                                                <asp:TextBox ID="txtHelperFive" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Supervisor</label>
                                                <asp:TextBox ID="txtSupervisor" runat="server" class="form-control" onkeypress="return character(event)" placeholder="" Text="" MaxLength="30"></asp:TextBox>

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
                                                    </div>
                                                    <h2><strong>Electrical</strong>  Parameter</h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Heating On</label>
                                                            <div class="input-group bootstrap-timepicker">
                                                                <asp:TextBox ID="txtHeatingOn" runat="server" CssClass="form-control input-timepicker24"></asp:TextBox>
                                                                <span class="input-group-btn">
                                                                    <a href="javascript:void(0)" class="btn btn-primary"><i class="fa fa-clock-o"></i></a>
                                                                </span>
                                                            </div>


                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Furnace Meter</label>
                                                            <asp:TextBox ID="txtFurnaceMeterOnHeating" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text=""  MaxLength="8"></asp:TextBox>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Big Blower</label>
                                                            <asp:TextBox ID="txtBigBlowerOnHeating" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text="" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Small Blower Finish</label>
                                                            <asp:TextBox ID="txtSmallBlowerOnHeating" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text=""  MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="row">

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Production Start</label>
                                                            <div class="input-group bootstrap-timepicker">
                                                                <asp:TextBox ID="txtProductionStartTime" runat="server" CssClass="form-control input-timepicker24"></asp:TextBox>
                                                                <span class="input-group-btn">
                                                                    <a href="javascript:void(0)" class="btn btn-primary"><i class="fa fa-clock-o"></i></a>
                                                                </span>
                                                            </div>

                                                            <%--<input type="text" id="example-if-productionstart" name="example-if-text" class="form-control" placeholder="" value="11:00 AM" />--%>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Furnace Meter</label>
                                                            <asp:TextBox ID="txtFurnaceMeterStartProduction" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text=""  MaxLength="8"></asp:TextBox>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Big Blower</label>
                                                            <asp:TextBox ID="txtBigBlowerStartProduction" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text=""  MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Small Blower</label>
                                                            <asp:TextBox ID="txtSmallBlowerStartProduction" runat="server" class="form-control" onkeypress="return isNumberKey(this, event);" placeholder="" Text=""  MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Production Finish</label>
                                                            <div class="input-group bootstrap-timepicker">
                                                                <asp:TextBox ID="txtProductionEndTime" runat="server" CssClass="form-control input-timepicker24"></asp:TextBox>
                                                                <span class="input-group-btn">
                                                                    <a href="javascript:void(0)" class="btn btn-primary"><i class="fa fa-clock-o"></i></a>
                                                                </span>
                                                            </div>
                                                            <%--<input type="text" id="example-if-pcscutfromsheet" name="example-if-text" class="form-control" placeholder="" value="04:15 PM" />--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Furnace Meter</label>
                                                            <asp:TextBox ID="txtFurnaceMeterFinishProduction" runat="server" onkeypress="return isNumberKey(this, event);" class="form-control" placeholder="" Text=""  MaxLength="8"></asp:TextBox>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Big Blower</label>
                                                            <asp:TextBox ID="txtBigBlowerFinishProduction" runat="server" onkeypress="return isNumberKey(this, event);" class="form-control" placeholder="" Text=""  MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Small Blower Finish</label>
                                                            <asp:TextBox ID="txtSmallBlowerFinishProduction" runat="server" onkeypress="return isNumberKey(this, event);" class="form-control" placeholder="" Text=""  MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                <%--<div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Total </label>
                                                            <input type="text" id="example-if-total" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                </div>--%>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q2">SECTION 2: TO BE FILED BY OPERATOR</a></h4>
                            </div>
                            <div id="faq1_q2" class="panel-collapse collapse">
                                <div class="panel-body">


                                    <asp:ScriptManager ID="scriptmanagerforrepeater" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="updatepannelforrepeater" runat="server">
                                        <ContentTemplate>

                                            <div class="row">
                                                <div class="col-md-12">

                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rptrItemPcsStatusReport" runat="server" OnItemCommand="rptrItemPcsStatusReport_ItemCommand" OnItemDataBound="rptrItemPcsStatusReport_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                                    <thead>
                                                                        <tr>

                                                                            <th class="text-center " style="width:40px;">Hour</th>
                                                                            <th class="text-center ">First</th>
                                                                            <th class="text-center ">Second</th>
                                                                            <th class="text-center ">Third</th>
                                                                            <th class="text-center ">Fourth</th>
                                                                            <th class="text-center ">Fifth</th>
                                                                            <th class="text-center ">Sixth</th>
                                                                            <th class="text-center " style="width: 25px">
                                                                                <label class="text-success"><i class="fa fa-fw fa-check"></i></label>
                                                                            </th>
                                                                            <th class="text-center " style="width: 25px">
                                                                                <label class="text-danger"><i class="fa fa-fw fa-times"></i></label>
                                                                            </th>
                                                                            <th class="text-center " style="width: 25px">
                                                                                <label class="text-danger"><i class="gi gi-bin"></i></label>
                                                                            </th>
                                                                            <%--<th class="text-center " style="width: 70px">Sig.</th>--%>
                                                                            <th class="text-center">Action</th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="text-center">
                                                                        <a href="#">
                                                                            <asp:Label ID="lblHourName" Text='<%#Eval("hour_name")%>' Visible="false" runat="server"></asp:Label>
                                                                            <asp:Label ID="lblTotalPcsTransferred" Text='<%#Eval("total_pcs_transferred")%>' Visible="false" runat="server"></asp:Label>
                                                                            <asp:LinkButton ID="lnkCheckHour" runat="server" Text='<%#Eval("hour_name")%>' CommandName="selectall" CommandArgument='<%# Eval("process_tempering_report_id")%>' Visible="true" CssClass="" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="" OnClick="lnkCheckHour_Click"></asp:LinkButton>
                                                                        </a>

                                                                    </td>

                                                                    <td class=" text-center btn-group-xs">

                                                                        <asp:Label ID="lblItemVerifyStatus" Text='<%#Eval("item_verify_status")%>' runat="server" Visible="false"></asp:Label>
                                                                        <div class="row">
                                                                             <asp:DropDownList ID="ddlPcsOne" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsOne_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwo" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwo_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsThree" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsThree_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsFour" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsFour_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsFive" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsFive_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                        </div>
                                                                       
                                                                        <asp:CheckBox ID="chkPcsOne" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsOne_CheckedChanged" />
                                                                        <asp:CheckBox ID="chkPcsTwo" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwo_CheckedChanged" />
                                                                        <asp:CheckBox ID="chkPcsThree" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsThree_CheckedChanged" />
                                                                        <asp:CheckBox ID="chkPcsfour" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsfour_CheckedChanged" />
                                                                        <asp:CheckBox ID="chkPcsFive" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsFive_CheckedChanged" />
                                                                        

                                                                    </td>

                                                                    <td class=" text-center  btn-group-xs ">

                                                                        <div class="row">
                                                                             <asp:DropDownList ID="ddlPcsSix" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsSix_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsSeven" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsSeven_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsEight" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsEight_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsNine" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsNine_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </div>
                                                                         <asp:CheckBox ID="chkPcsSix" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsSix_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsSeven" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsSeven_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsEight" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsEight_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsNine" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsNine_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTen_CheckedChanged" />
                                                                    </td>
                                                                    <td class=" text-center  btn-group-xs ">

                                                                        <div class="row">
                                                                             <asp:DropDownList ID="ddlPcsEleven" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsEleven_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwelve" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwelve_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsThirteen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsThirteen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsfourteen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsfourteen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsfiften" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsfiften_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </div>

                                                                       
                                                                            <asp:CheckBox ID="chkPcsEleven" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsEleven_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwelve" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwelve_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsThirteen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsThirteen_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsFourteen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsFourteen_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsFifteen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsFifteen_CheckedChanged" />
                                                                    </td>
                                                                    <td class=" text-center  btn-group-xs ">

                                                                        <div class="row">
                                                                             <asp:DropDownList ID="ddlPcsSixteen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsSixteen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsSeventeen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsSeventeen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsEighteen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsEighteen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsNineteen" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsNineteen_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwenty" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwenty_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </div>

                                                                        
                                                                            <asp:CheckBox ID="chkPcsSixteen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsSixteen_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsSeventeen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsSeventeen_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsEighteen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsEighteen_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsNineteen" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsNineteen_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwenty" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwenty_CheckedChanged" />
                                                                    </td>
                                                                    <td class=" text-center  btn-group-xs ">

                                                                        <div class="row">
                                                                             <asp:DropDownList ID="ddlPcsTwentyOne" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyOne_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentyTwo" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyTwo_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentyThree" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyThree_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentyFour" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyFour_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentyFive" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyFive_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </div>

                                                                       
                                                                            <asp:CheckBox ID="chkPcsTwentyOne" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyOne_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentyTwo" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyTwo_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentyThree" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyThree_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentyFour" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyFour_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentyFive" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyFive_CheckedChanged" />
                                                                    </td>
                                                                    <td class=" text-center  btn-group-xs ">
                                                                        <div class="row">
                                                                             <asp:DropDownList ID="ddlPcsTwentySix" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentySix_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentySeven" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentySeven_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentyEight" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyEight_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsTwentyNine" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsTwentyNine_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:DropDownList ID="ddlPcsThirty" runat="server" CssClass="form-control custom-dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPcsThirty_SelectedIndexChanged">
                                                                            <asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="0">B</asp:ListItem>
                                                                            <asp:ListItem Value="1">OK</asp:ListItem>
                                                                            <asp:ListItem Value="2">R</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        </div>
                                                                            <asp:CheckBox ID="chkPcsTwentySix" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentySix_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentySeven" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentySeven_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentyEight" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyEight_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsTwentyNine" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsTwentyNine_CheckedChanged" />
                                                                            <asp:CheckBox ID="chkPcsThirty" runat="server" CssClass="text-center" Visible="false" AutoPostBack="true" OnCheckedChanged="chkPcsThirty_CheckedChanged" />
                                                                    </td>

                                                                    <td class="text-center">
                                                                        <asp:Label ID="lblOkTotalPcsRepeater" CssClass="" Text='<%#Eval("ok_total_pcs_in_hours")%>' runat="server"></asp:Label>
                                                                        <%--<asp:TextBox ID="txtOkTotalPcsRepeater" runat="server" CssClass="form-control" Text="0" placeholder="0"></asp:TextBox>--%>
                                                                    </td>
                                                                    <td class="text-center">
                                                                        <asp:Label ID="lblBreakageTotalPcsRepeater" CssClass="" Text='<%#Eval("breakage_total_pcs")%>' runat="server"></asp:Label>
                                                                        <%--<asp:TextBox ID="txtBreakageTotalPcsRepeater" runat="server" CssClass="form-control" Text="0" placeholder="0"></asp:TextBox>--%>
                                                                    </td>
                                                                    <td class="text-center">
                                                                        <asp:Label ID="lblRejectTotalPcsRepeater" CssClass="" Text='<%#Eval("reject_total_pcs")%>' runat="server"></asp:Label>
                                                                        <%-- <asp:TextBox ID="txtRejectTotalPcsRepeater" runat="server" CssClass="form-control" Text="0" placeholder="0"></asp:TextBox>--%>
                                                                    </td>

                                                                    <%-- <td class="text-center">
                                                                         <asp:TextBox ID="txtSignatureRepeater" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                                                                        <asp:Label ID="lblItemCheckSignature" CssClass="" Text='<%#Eval("signature")%>' Visible="false" runat="server"></asp:Label>
                                                                        <asp:DropDownList ID="ddlItemCheckSignature" runat="server" class="form-control">
                                                                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                            <asp:ListItem Value="1" >Supervisor</asp:ListItem>
                                                                            <asp:ListItem Value="2">In-charge</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>--%>
                                                                    <td class="text-center btn-group-sm">
                                                                        <asp:Label ID="lblProcessTemperingReportId" Text='<%#Eval("process_tempering_report_id")%>' Visible="false" runat="server"></asp:Label>
                                                                        <asp:LinkButton ID="btnUpdateItemStatus" runat="server" CommandName="update" CommandArgument='<%# Eval("process_tempering_report_id")%>' Visible="true" CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to Add" data-original-title="Basic tooltp" OnClick="btnUpdateItemStatus_Click">Add</asp:LinkButton>
                                                                    </td>


                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>         
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>

                                            </div>




                                            <div class="row">

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="size">Total OK</label>
                                                        <asp:TextBox ID="txtTotalAllOkPcs" runat="server" CssClass="form-control" Text="0"  MaxLength="5"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="size">Total Breakage</label>
                                                        <asp:TextBox ID="txtTotalAllBreakagePcs" runat="server" CssClass="form-control" Text="0" MaxLength="3"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="actualsqm">Total Reject</label>
                                                        <asp:TextBox ID="txtTotalAllRejectPcs" runat="server" CssClass="form-control" Text="0" MaxLength="3"></asp:TextBox>

                                                    </div>
                                                </div>


                                            </div>
                                            <div class="row">

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="size">Average/Hours</label>
                                                        <asp:TextBox ID="txtPerPcsAverageHours" runat="server" onkeypress="return isNumberKey(this, event);" CssClass="form-control"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="size">(D) Raw Balance</label>
                                                        <asp:TextBox ID="txtItemRawBalance" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" OnTextChanged="txtItemRawBalance_TextChanged" MaxLength="3"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="actualsqm">Total (A+B+C)</label>
                                                        <asp:TextBox ID="txtTotalOkBreakReject" runat="server" CssClass="form-control" Text="0" MaxLength="3"></asp:TextBox>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="row">


                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label for="size">Received</label>
                                                        <%--<input type="text" id="example-if-received" name="example-if-email" class="form-control" placeholder="" value="102" />--%>
                                                        <asp:TextBox ID="txtreceived" runat="server" CssClass="form-control" placeholder="" Text="" MaxLength="3"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label for="size">Breakage</label>
                                                        <%--<input type="text" id="example-if-received" name="example-if-email" class="form-control" placeholder="" value="102" />--%>
                                                        <asp:TextBox ID="txtbreakage" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="" OnTextChanged="txtbreakage_TextChanged" MaxLength="3"></asp:TextBox>

                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label for="size">Reject</label>
                                                        <%--<input type="text" id="example-if-received" name="example-if-email" class="form-control" placeholder="" value="102" />--%>
                                                        <asp:TextBox ID="txtReject" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="" OnTextChanged="txtReject_TextChanged" MaxLength="3"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label for="actualsqm">Transferred</label>
                                                        <asp:TextBox ID="txtFinalTransferred" runat="server" CssClass="form-control" placeholder="" MaxLength="3"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <label for="description">Signature</label>
                                                        <asp:DropDownList ID="ddlSignature" runat="server" class="form-control">
                                                            <asp:ListItem Value="1" Selected="True">Supervisor</asp:ListItem>
                                                            <asp:ListItem Value="2">In-charge</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Breakage/Reject Repeater Start -->

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rptrBreakagePcsItemList" runat="server" Visible="false" OnItemCommand="rptrBreakagePcsItemList_ItemCommand" OnItemDataBound="rptrBreakagePcsItemList_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="text-center" style="width: 150px;">Pcs No</th>
                                                                            <th class="text-center">Broken Reason</th>

                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>

                                                                    <td class=" text-center">
                                                                        <asp:Label ID="lblBreakagePcsNo" Text='<%#Eval("PcsNo")%>' runat="server"> </asp:Label>
                                                                        <asp:TextBox ID="txtBreakagePcsNumber" runat="server" Text='<%#Eval("PcsNo")%>' CssClass="form-control text-center"></asp:TextBox>
                                                                    </td>

                                                                    <td class=" text-center">

                                                                        <asp:Label ID="lblBreakageReason" Text='<%#Eval("Reason")%>' runat="server" Visible="false"> </asp:Label>
                                                                        <asp:DropDownList ID="ddlBreakageReason" runat="server" class="form-control">
                                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                            <asp:ListItem Value="Scratch" Text="Scratch"></asp:ListItem>
                                                                            <asp:ListItem Value="Chipping" Text="Chipping"></asp:ListItem>
                                                                            <asp:ListItem Value="Paint Issue" Text="Paint Issue"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>         
                                                            </FooterTemplate>
                                                        </asp:Repeater>

                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rptrRejectPcsItemList" runat="server" Visible="false" OnItemCommand="rptrRejectPcsItemList_ItemCommand" OnItemDataBound="rptrRejectPcsItemList_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                                    <thead>
                                                                        <tr>
                                                                            <th class="text-center" style="width: 150px;">Pcs No</th>
                                                                            <th class="text-center">Reject Reason</th>

                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>

                                                                    <td class=" text-center">
                                                                        <asp:Label ID="lblRejectPcsNo" Text='<%#Eval("PcsNo")%>' runat="server"> </asp:Label>
                                                                        <asp:TextBox ID="txtRejectPcsNumber" runat="server" Text='<%#Eval("PcsNo")%>' CssClass="form-control text-center"></asp:TextBox>
                                                                    </td>

                                                                    <td class=" text-center">
                                                                        <asp:Label ID="lblRejectReason" Text='<%#Eval("Reason")%>' runat="server" Visible="false"> </asp:Label>
                                                                        <asp:DropDownList ID="ddlRejectReason" runat="server" class="form-control">
                                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                            <asp:ListItem Value="Scratch" Text="Scratch"></asp:ListItem>
                                                                            <asp:ListItem Value="Chipping" Text="Chipping"></asp:ListItem>
                                                                            <asp:ListItem Value="Paint Issue" Text="Paint Issue"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </table>         
                                                            </FooterTemplate>
                                                        </asp:Repeater>

                                                    </div>
                                                </div>

                                            </div>

                                            <!--- Breakage/Reject Repeater End -->

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="description">Remarks</label>
                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" Rows="2" TextMode="MultiLine" placeholder="" MaxLength="250"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions" style="float: right">
                                                        <%-- <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                <button type="submit" class="btn btn-sm btn-primary">Submit</button>--%>

                                                        <asp:Button ID="btnResetData" runat="server" Text="Reset" class="btn btn-sm btn-warning" Visible="false" />
                                                        <%--<asp:Button ID="btnUpdate" runat="server" Text="Submit" class="btn btn-sm btn-success" Visible="true" OnClick="btnUpdate_Click" />--%>

                                                        <asp:LinkButton ID="btnUpdateData" runat="server" Text="Submit" Visible="true" OnClick="btnUpdateData_Click" CssClass="btn btn-sm btn-primary">Submit</asp:LinkButton>


                                                    </div>
                                                </div>

                                            </div>

                                        </ContentTemplate>

                                    </asp:UpdatePanel>
                                   

                                    
                                </div>
                            </div>
                        </div>


                    </div>

                    <!-- END Normal Form Content -->
                </div>
            </div>


        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
