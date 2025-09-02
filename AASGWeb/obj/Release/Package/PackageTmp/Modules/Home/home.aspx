<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="home.aspx.cs" Inherits="AASGWeb.Modules.Home.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function scrollToLocation(Location) {
            $('html, body').animate({
                scrollTop: ($("" + Location + "").offset().top - 10)
            }, 1000);
        }
    </script>
    <script type="text/javascript">


        function showPartyAlert() {
            $(document).ready(function () {
                /* Grawl Notifications with Bootstrap-growl plugin, check out more examples at http://ifightcrime.github.io/bootstrap-growl/ */

                var growlType = $(this).data('growl');

                $.bootstrapGrowl('<h4>Warning!</h4> <p><b>Please Select Party SaleOrder !</b></p>', {
                    type: 'warning',
                    delay: 2500,
                    allow_dismiss: true
                }, 2000);

                $(this).prop('disabled', true);
            });

        }

    </script>
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
                    <a href="/manage-sale-orders"><i class="fa fa-rupee"></i>SaleOrders</a>
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
        <!-- Quick Stats -->
        <div class="row text-center">

            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                            <asp:Label ID="lblTodaySaleOrders" runat="server"></asp:Label>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">
                            <i class="fa fa-rupee"></i><strong>

                                <asp:Label ID="lblOrderAmountToday" runat="server"></asp:Label>
                            </strong>
                            <br>
                            <small>Order Value Today</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                            <asp:Label ID="lblCurrentMonthSaleOrders" runat="server"></asp:Label>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">
                            <i class="fa fa-rupee"></i><strong>
                                <asp:Label ID="lblOrderAmountCurrentMonth" runat="server"></asp:Label></strong><br>
                            <small>Order Value This Month </small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                            <asp:Label ID="lblLastMonthSaleOrder" runat="server"></asp:Label>
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">
                            <i class="fa fa-rupee"></i><strong>
                                <asp:Label ID="lblOrderAmountLastMonth" runat="server"></asp:Label></strong><br>

                            <small>Order Value Last Month </small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget-simple">
                        <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                            0
                        </div>
                        <h3 class="widget-content text-right animation-pullDown">
                            <i class="fa fa-rupee"></i><strong>0</strong><br>
                            <small>Order Value Year</small>
                        </h3>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
            <%--<div class="col-sm-6 col-lg-4">
                <a href="#" class="widget widget-hover-effect2">
                    <div class="widget-extra themed-background">
                        <h4 class="widget-content-light"><strong>Sale Orders</strong> Today</h4>
                    </div>
                    <div class="widget-extra-full">
                        <span class="h2 animation-expandOpen">
                            
                        </span>
                    </div>
                </a>
            </div>--%>
        </div>
        <!-- END Quick Stats -->

        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                  <strong>Total Weight : </strong>
                    <asp:Label ID="lblPatryTotalItemsCount" Text="0 Kg" CssClass="label label-success" runat="server"></asp:Label> 
                    <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                </div>
                <h2><strong>Manage</strong> Sale Orders</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->
            <div class="table-responsive">
                 
            <asp:Repeater ID="rptrSaleOrder" runat="server" OnItemCommand="rptrSaleOrder_ItemCommand" OnItemDataBound="rptrSaleOrder_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 50px;">ID</th>
                                <th class="text-center ">Order ID</th>
                                <th class="text-center " hidden="hidden">Party ID</th>
                                <th class="text-center ">Party Name</th>
                                <th class="text-center " style="width: 50px;">Items Quan.</th>
                                <th class="text-center ">Total Weight</th>
                                <th class="text-center ">Total Amount</th>
                                <th class="text-center " style="width: 50px;">Date</th>
                                <th class="text-center ">Order By (Staff)</th>
                                <th>Order Status</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                         <td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblSaleOrderId" Text='<%#Eval("sale_header_id")%>' runat="server"></asp:Label>
                        </td>

                        <td class=" text-center" hidden="hidden">
                            <asp:Label ID="lblPartyMasterId" Text='<%#Eval("party_master_id")%>' runat="server"></asp:Label>
                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblPartyName" Text='<%#Eval("party_name")%>' runat="server"></asp:Label>
                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblTotalItems" Text='<%#Eval("total_items")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblTotalItemWeight" Text='<%#Eval("total_weight")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lbltotalAmount" Text='<%#Eval("total_amount")%>' runat="server"></asp:Label>

                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblDate" Text='<%#Eval("sale_item_date","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblMadeBy" Text='<%#Eval("made_by")%>' runat="server"></asp:Label>

                        </td>

                        <td class=" text-center">
                            <asp:Label ID="lblOrderStatus" Text='<%#Eval("order_status")%>' runat="server"></asp:Label>

                        </td>
                        <%-- <td class="text-center"> 
                            <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                            <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                            <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>

                        </td>--%>
                        <td class=" text-center  btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("sale_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                           
                            <asp:CheckBox ID="chkSaleOrder" runat="server" AutoPostBack="True" CssClass="btn btn-default text-center" OnCheckedChanged="chkSaleOrder_CheckedChanged"/>
                        </td>
                       
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hdfdSaleOrderId" runat="server" />
            </div>

            <!-- END All Orders Content -->
            <div class="row">
                <div class="col-md-12" style="margin-top:20px">
                    <div class="form-group form-actions" style="float: right">

                        <asp:LinkButton ID="btnSubmitToProduction" runat="server"  Text="Submit To Production" CssClass="btn btn-sm btn-primary"  OnClick="btnSubmitToProduction_Click" >Submit To Production</asp:LinkButton>
                        <%--<a href="/production/plan-production" Class="btn btn-sm btn-primary">Submit To Production</a>--%>
                    </div>
                </div>


            </div>

        </div>
        <!-- END All Orders Block -->


            

    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
