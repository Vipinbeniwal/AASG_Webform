<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="item-complete-detail.aspx.cs" Inherits="AASGWeb.Modules.Production.item_complete_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>
        .table-responsive {
    overflow-x: hidden !important;
    min-height: 0.01%;
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

        <div class="row">
            <div class="col-md-12">
                <!-- Log Block -->
                <div class="block">
                    <!-- Log Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                     <asp:LinkButton ID="btnItemProductionActivity" runat="server" CssClass="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="tooltip" data-placement="bottom" title="Production Activity" data-original-title="Basic tooltp" Text="Production Activity" OnClick="btnItemProductionActivity_Click" ></asp:LinkButton>

                </div>
                        <h2><i class="fa fa-file-text-o"></i><strong> Item</strong> Status</h2>
                       <asp:Label ID="lblItemFullDetail" runat="server" ></asp:Label>



                    </div>
                    <!-- END Log Title -->

                    <!-- Log Content -->
                    <%--<div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table id="ecom-orders" class="table table-bordered table-vcenter">
                                    <thead>
                                        <tr>
                                            <th class="text-center">Department</th>
                                            <th class="text-center">Item Details</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Cutting  </label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label class="text-success"><i class="fa fa-fw fa-check"></i></label>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span>15-Jan-2022 10:20 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>07:40 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">117  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span>15-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">114  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">3  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">Supervisor  </span>
                                                    </div>



                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Grinding  </label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label class="text-success"><i class="fa fa-fw fa-check"></i></label>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span>16-Jan-2022 10:00 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>08:00 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">114  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span>16-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">112  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">2  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">Supervisor  </span>
                                                    </div>



                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Hole  </label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label class="text-primary"><i class="fa fa-refresh fa-spin"></i></label>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span>17-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>08:30 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">112  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">1  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span>17-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">0  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">Supervisor  </span>
                                                    </div>



                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Washing  </label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label class="text-danger"><i class="fa fa-ellipsis-h"></i></label>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span>18-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>08:30 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span> 18-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">0  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">Supervisor  </span>
                                                    </div>



                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Paint  </label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 text-center">
                                                    <label class="text-danger"><i class="fa fa-ellipsis-h"></i></label>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span>19-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>08:30 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span>19-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">0  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">Supervisor  </span>
                                                    </div>



                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">DFG Print </label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 text-center">
                                                    <label class="text-danger"><i class="fa fa-ellipsis-h"></i></label>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span> 20-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>08:30 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span> 20-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">0  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">Supervisor  </span>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Tempring </label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 text-center">
                                                    <label class="text-danger"><i class="fa fa-ellipsis-h"></i></label>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span> 21-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>08:30 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">111  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span> 21-Jan-2022 05:30 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">101  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">10  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">In-charge  </span>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Packing </label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 text-center">
                                                    <label class="text-danger"><i class="fa fa-ellipsis-h"></i></label>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span> 22-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>09:00 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">101  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span> 22-Jan-2022 06:00 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">101  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">0  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">In-charge  </span>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <label for=" ">Store </label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 text-center">
                                                    <label class="text-danger"><i class="fa fa-ellipsis-h"></i></label>
                                                </div>
                                            </td>
                                            <td>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        <span> 22-Jan-2022 09:30 AM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        <span>09:00 Hrs</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        <span class="label label-primary">101  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        <span for="" class="label label-warning">0  </span>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        <span> 22-Jan-2022 06:00 PM</span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        <span for="" class="label label-success">101  </span>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                        <span for="" class="label label-danger">0  </span>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <span for="">In-charge  </span>
                                                    </div>
                                                </div>

                                            </td>
                                        </tr>


                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>--%>


                    <div class="table-responsive">

                        <asp:HiddenField ID="hdnItemMasterId" runat="server" />
                        <asp:HiddenField ID="hdnBatchNumber" runat="server" />
                        <asp:HiddenField ID="hdnfProductionId" runat="server" />

                        <asp:Repeater ID="rptrManageItemProcess" runat="server" OnItemCommand="rptrManageItemProcess_ItemCommand"  OnItemDataBound="rptrManageItemProcess_ItemDataBound">
                            <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                        <tr>
                                            <th class="text-center">Department</th>
                                            <th class="text-center">Item Details</th>
                                        </tr>
                                    </thead>
                                 </HeaderTemplate>
                             <ItemTemplate>
                                <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <%--<label for=" ">Cutting  </label>--%>
                                                        <asp:Label ID="NameofProcess" runat="server" Text='<%#Eval("department")%>'></asp:Label>
                                                        <asp:Label ID="lblItemMasterId" runat="server" Text='<%#Eval("item_master_id")%>' Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 text-center">
                                                        <%--<label class="text-success"><i class="fa fa-fw fa-check"></i></label>--%>
                                                        
                                                        <asp:Label ID="ProcessStatusClass" runat="server" CssClass=""></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">Start Time - </label>
                                                        
                                                        <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartingDate","{0:dd/MM/yyyy HH:mm}")%>'></asp:Label>  <%-- "{0:d}"--%>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Total Time - </label>
                                                        
                                                        <asp:Label ID="lblTotalTime" runat="server" ></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Received - </label>
                                                        
                                                        <asp:Label ID="lblReceived" runat="server" Text='<%#Eval("total_received")%>' CssClass="label label-primary" ></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Rejected - </label>
                                                        
                                                        <asp:Label ID="lblRejected" runat="server" Text='<%#Eval("total_reject")%>' CssClass="label label-warning"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="">End Time - </label>
                                                        
                                                        <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("EndingDate","{0:dd/MM/yyyy HH:mm}")%>'></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Transfered - </label>
                                                        
                                                        <asp:Label ID="lblTransfered" runat="server" Text='<%#Eval("total_pcs_transferred")%>' CssClass="label label-success"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Breakage - </label>
                                                  
                                                        <asp:Label ID="lblBreakage" runat="server" Text='<%#Eval("total_broken")%>' CssClass="label label-danger"></asp:Label>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <label for="">Signature - </label>
                                                        <asp:Label ID="lblSignatueId" runat="server" Text='<%#Eval("signature")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblSignature" runat="server" ></asp:Label>
                                                    </div>

                                                </div>
                                                <div class="row">

                                                    <div class="col-md-3">
                                                        <label for="">Breakage Reason - </label>
                                                        
                                                        <asp:Label ID="lblBreakageReasons" runat="server" Text='<%#Eval("breakage_reason")%>'></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Average Cost - </label>
                                                        
                                                        <asp:Label ID="lblItemAverageCost" runat="server" Text='<%#Eval("item_average_hours_cost")%>' CssClass="label label-primary"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Raw Balance - </label>
                                                        
                                                        <asp:Label ID="lblRawBalance" runat="server" Text='<%#Eval("raw_balance")%>' CssClass="label label-success"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <label for="">Reject Reason - </label>
                                                        
                                                        <asp:Label ID="lblRejectReason" runat="server" Text='<%#Eval("reject_reason")%>'></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">

                                                    <div class="col-md-12">
                                                        <label for="">Remarks - </label>
                                                        
                                                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("remarks")%>'></asp:Label>
                                                    </div>
                                                  
                                                </div>

                                            </td>
                                        </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>         
                            </FooterTemplate>
                        </asp:Repeater>
                             <asp:HiddenField ID="hdfdpartyId" runat="server" />

                         </div>


                    <!-- END Log Content -->
                </div>
                <!-- END Log Block -->
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
