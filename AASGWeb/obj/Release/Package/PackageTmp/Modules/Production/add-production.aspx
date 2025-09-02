<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="add-production.aspx.cs" Inherits="AASGWeb.Modules.Production.add_production" %>

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

        <!-- END Forms General Header -->


        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong>Add</strong>Production Item Report</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <asp:HiddenField ID="hdnProductionId" runat="server" />

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="brand">Report Date </label>
                                <asp:TextBox ID="txtReportDate" runat="server" CssClass="form-control input-datepicker-close" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">

                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="model">HTF Shift (From)</label>
                                        <input type="text" id="example-if-from" name="example-if-text" class="form-control" placeholder="From" value="" />

                                    </div>
                                    <div class="col-md-6">
                                        <label for="model">HTF Shift (To) </label>
                                        <input type="text" id="example-if-to" name="example-if-text" class="form-control" placeholder="To" value="" />

                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="description">Plant Number</label>
                                <asp:TextBox ID="txtPlantName" runat="server" CssClass="form-control"></asp:TextBox>
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
                                <asp:TextBox ID="txtBatchNumber" runat="server" CssClass="form-control"></asp:TextBox>
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


                                                <asp:TextBox ID="txtItemName" runat="server" class="form-control" placeholder="" Text="Penjuin w/5"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Quantity (In Pcs) <span class="text-danger">*</span></label>

                                                <asp:TextBox ID="txtQuantityInPcs" runat="server" class="form-control" placeholder="" Text="122"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Production Target (Pcs)</label>
                                                <asp:TextBox ID="txtProductionTargetInPcs" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                                <%--<input type="email" id="example-if-productiontargetinpcs" name="example-if-text" class="form-control" placeholder="" value="" />--%>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Production Target (%) </label>
                                                <%--<input type="email" id="example-if-productiontargetinpercentage" name="example-if-text" class="form-control" placeholder="" value="" />--%>
                                                <asp:TextBox ID="txtProductionTargetInPercentage" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="brand">Operator Name </label>
                                                <input type="text" id="example-if-operator" name="example-if-text" class="form-control" placeholder="" value="Pardeep" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Line Incharge <span class="text-danger">*</span></label>
                                                <input type="text" id="example-if-linincharge" name="example-if-text" class="form-control" placeholder="" value="Mahesh" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Helper 1</label>
                                                <input type="text" id="example-if-helper1" name="example-if-text" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Helper 2</label>
                                                <input type="text" id="example-if-helper2" name="example-if-text" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="brand">Helper 3</label>
                                                <input type="text" id="example-if-helper3" name="example-if-text" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="model">Helper 4 <span class="text-danger">*</span></label>
                                                <input type="text" id="example-if-helper4" name="example-if-text" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Helper 5</label>
                                                <input type="text" id="example-if-helper5" name="example-if-text" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="description">Supervisor</label>
                                                <input type="text" id="example-if-supervisor" name="example-if-text" class="form-control" placeholder="" value="" />

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
                                                            <input type="text" id="example-if-heating" name="example-if-text" class="form-control" placeholder="" value="08:30 AM" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Furnace Meter</label>
                                                            <input type="text" id="example-if-furnace-meter" name="example-if-text" class="form-control" placeholder="" value="531.2" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Big Blower</label>
                                                            <input type="text" id="example-if-big-blower1" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Small Blower Finish</label>
                                                            <input type="text" id="example-if-small-blower" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="row">

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Production Start</label>
                                                            <asp:TextBox ID="txtProductionStartTime" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                                            <%--<input type="text" id="example-if-productionstart" name="example-if-text" class="form-control" placeholder="" value="11:00 AM" />--%>

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Furnace Meter</label>
                                                            <input type="text" id="example-if-furnace-meter2" name="example-if-text" class="form-control" placeholder="" value="531.2" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Big Blower</label>
                                                            <input type="text" id="example-if-big-blower2" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Small Blower Finish</label>
                                                            <input type="text" id="example-if-small-blowe2" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Production Finish</label>
                                                            <%--<input type="text" id="example-if-pcscutfromsheet" name="example-if-text" class="form-control" placeholder="" value="04:15 PM" />--%>
                                                        <asp:TextBox ID="txtProductionEndTime" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="size">Furnace Meter</label>
                                                            <input type="text" id="example-if-furnace-meter3" name="example-if-text" class="form-control" placeholder="" value="537.7" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Big Blower</label>
                                                            <input type="text" id="example-if-big-blower3" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Small Blower Finish</label>
                                                            <input type="text" id="example-if-small-blowe3" name="example-if-text" class="form-control" placeholder="" value="" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="actualsqm">Total </label>
                                                            <input type="text" id="example-if-total" name="example-if-text" class="form-control" placeholder="" value="1024" />
                                                        </div>
                                                    </div>
                                                </div>


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


                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                    <thead>
                                                        <tr>

                                                            <th class="text-center ">Hour</th>
                                                            <th class="text-center ">OK(A)</th>
                                                            <th class="text-center ">Breakage(B)</th>
                                                            <th class="text-center ">Recheck(C)</th>
                                                            <th class="text-center " style="width:50px">OK(A)</th>
                                                            <th class="text-center " style="width:50px">Broken(B)</th>
                                                            <th class="text-center " style="width:50px">Recheck(C)</th>
                                                            

                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>0-1</strong></a></td>
                                                            <td class=" text-center">
                                                               <label class="checkbox-inline" for="example-inline-checkbox1">
                                                    <input type="checkbox" id="example-inline-checkbox1" name="example-inline-checkbox1" value="option1"> 1
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox2">
                                                    <input type="checkbox" id="example-inline-checkbox2" name="example-inline-checkbox2" value="option2"> 2
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox3">
                                                    <input type="checkbox" id="example-inline-checkbox3" name="example-inline-checkbox3" value="option3"> 3
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox4">
                                                    <input type="checkbox" id="example-inline-checkbox4" name="example-inline-checkbox4" value="option4"> 4
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox5">
                                                    <input type="checkbox" id="example-inline-checkbox5" name="example-inline-checkbox5" value="option5"> 5
                                                </label>
                                                            </td>
                                                            <td class=" text-center">
                                                               <label class="checkbox-inline" for="example-inline-checkbox6">
                                                    <input type="checkbox" id="example-inline-checkbox6" name="example-inline-checkbox6" value="option6"> 6
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox7">
                                                    <input type="checkbox" id="example-inline-checkbox7" name="example-inline-checkbox7" value="option7"> 7
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox8">
                                                    <input type="checkbox" id="example-inline-checkbox8" name="example-inline-checkbox8" value="option8"> 8
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox9">
                                                    <input type="checkbox" id="example-inline-checkbox9" name="example-inline-checkbox9" value="option9"> 9
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox10">
                                                    <input type="checkbox" id="example-inline-checkbox10" name="example-inline-checkbox10" value="option10"> 10
                                                </label>
                                                            </td>
                                                            <td class=" text-center">
                                                               <label class="checkbox-inline" for="example-inline-checkbox11">
                                                    <input type="checkbox" id="example-inline-checkbox11" name="example-inline-checkbox11" value="option11"> 11
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox12">
                                                    <input type="checkbox" id="example-inline-checkbox12" name="example-inline-checkbox12" value="option12"> 12
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox13">
                                                    <input type="checkbox" id="example-inline-checkbox13" name="example-inline-checkbox13" value="option13"> 13
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox14">
                                                    <input type="checkbox" id="example-inline-checkbox14" name="example-inline-checkbox14" value="option14"> 14
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox5">
                                                    <input type="checkbox" id="example-inline-checkbox15" name="example-inline-checkbox15" value="option15"> 15
                                                </label>
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="30" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            


                                                        </tr>


                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>1-2</strong></a></td>
                                                             <td class=" text-center">
                                                               <label class="checkbox-inline" for="example-inline-checkbox1">
                                                    <input type="checkbox" id="example-inline-checkbox1" name="example-inline-checkbox1" value="option1"> 1
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox2">
                                                    <input type="checkbox" id="example-inline-checkbox2" name="example-inline-checkbox2" value="option2"> 2
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox3">
                                                    <input type="checkbox" id="example-inline-checkbox3" name="example-inline-checkbox3" value="option3"> 3
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox4">
                                                    <input type="checkbox" id="example-inline-checkbox4" name="example-inline-checkbox4" value="option4"> 4
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox5">
                                                    <input type="checkbox" id="example-inline-checkbox5" name="example-inline-checkbox5" value="option5"> 5
                                                </label>
                                                            </td>
                                                            <td class=" text-center">
                                                               <label class="checkbox-inline" for="example-inline-checkbox6">
                                                    <input type="checkbox" id="example-inline-checkbox6" name="example-inline-checkbox6" value="option6"> 6
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox7">
                                                    <input type="checkbox" id="example-inline-checkbox7" name="example-inline-checkbox7" value="option7"> 7
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox8">
                                                    <input type="checkbox" id="example-inline-checkbox8" name="example-inline-checkbox8" value="option8"> 8
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox9">
                                                    <input type="checkbox" id="example-inline-checkbox9" name="example-inline-checkbox9" value="option9"> 9
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox10">
                                                    <input type="checkbox" id="example-inline-checkbox10" name="example-inline-checkbox10" value="option10"> 10
                                                </label>
                                                            </td>
                                                            <td class=" text-center">
                                                               <label class="checkbox-inline" for="example-inline-checkbox11">
                                                    <input type="checkbox" id="example-inline-checkbox11" name="example-inline-checkbox11" value="option11"> 11
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox12">
                                                    <input type="checkbox" id="example-inline-checkbox12" name="example-inline-checkbox12" value="option12"> 12
                                                </label>
                                                <label class="checkbox-inline" for="example-inline-checkbox13">
                                                    <input type="checkbox" id="example-inline-checkbox13" name="example-inline-checkbox13" value="option13"> 13
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox14">
                                                    <input type="checkbox" id="example-inline-checkbox14" name="example-inline-checkbox14" value="option14"> 14
                                                </label>
                                                                <label class="checkbox-inline" for="example-inline-checkbox5">
                                                    <input type="checkbox" id="example-inline-checkbox15" name="example-inline-checkbox15" value="option15"> 15
                                                </label>
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="30" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                           


                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>2-3</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="30" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="30" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            


                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>3-4</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="29" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="1" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            


                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>4-5</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            


                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>5-6</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            

                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>6-7</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            

                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>7-8</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                          


                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>8-9</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            


                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>9-10</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            

                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>10-11</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                           

                                                        </tr>
                                                        <tr>
                                                            <td class="text-center"><a href="#"><strong>11-12</strong></a></td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-recheck" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">
                                                                <input type="text" id="example-if-ok" name="example-if-text" class="form-control text-center" placeholder="" value="" />
                                                            </td>
                                                            <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                             <td class=" text-center">

                                                                <input type="text" id="example-if-breakage" name="example-if-text" class="form-control text-center" placeholder="" value="" />

                                                            </td>
                                                           

                                                        </tr>

                                                    </tbody>


                                                </table>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Total OK</label>
                                                <input type="text" id="example-if-totalok" name="example-if-text" class="form-control" placeholder="" value="121" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Total Breakage</label>
                                                <input type="text" id="example-if-totalbreakage" name="example-if-text" class="form-control" placeholder="" value="1" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="actualsqm">Total Rechek</label>
                                                <input type="text" id="example-if-totalrecheck" name="example-if-text" class="form-control" placeholder="" value="" />
                                            </div>
                                        </div>


                                    </div>
                                    <div class="row">

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">Average/Hours</label>
                                                <input type="text" id="example-if-hours" name="example-if-text" class="form-control" placeholder="" value="23.23" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="size">(D) Raw Balance</label>
                                                <input type="text" id="example-if-rawbalance" name="example-if-text" class="form-control" placeholder="" value="" />

                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="actualsqm">Total (A+B+C+D)</label>
                                                <input type="text" id="example-if-totalabcd" name="example-if-text" class="form-control" placeholder="" value="122" />
                                            </div>
                                        </div>


                                    </div>


                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label for="size">Select</label>
                                               <select id="example-department2" name="example-chosen" class="select-chosen" data-placeholder="" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Scratch">Scratch</option>
                                                            <option value="Chipping">Chipping</option>
                                                            <option value="Paint Issue">Paint Issue</option>

                                                        </select>
                                            </div>
                                        </div>
                                        <div class="col-md-9">
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
                                                <asp:LinkButton ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-primary" href="/production/add-packaging"> Submit</asp:LinkButton>
                                            </div>
                                        </div>

                                    </div>



                                </div>
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
