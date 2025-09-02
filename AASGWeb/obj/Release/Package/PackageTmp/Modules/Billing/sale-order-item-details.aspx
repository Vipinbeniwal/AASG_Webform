<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="sale-order-item-details.aspx.cs" Inherits="AASGWeb.Modules.Billing.sale_order_item_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">


       <%-- $(document).ready(function () {

            $("#ContentPlaceHolder1_divRejectPannel").hide();
            $('#<%=ddlOrderStatus.ClientID %>').on("change", function () {
                //Get DropDownlist selected item index
                var selectedIndex = $(this).find("option:selected").index();
                //Get DropDownlist selected item value
                var selectedValue = $(this).find("option:selected").val();
                //Get DropDownlist selected item text

                var selectedText = $(this).find("option:selected").text();
                if ($(this).find("option:selected").text() == "rejected") {
                   
                    $("#ContentPlaceHolder1_divRejectPannel").show();
                }
                else {
                    
                    $("#ContentPlaceHolder1_divRejectPannel").hide();
                }

            });
        });--%>
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-content">
        <!-- eCommerce Order View Header -->
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
        <!-- END eCommerce Order View Header -->

        <!-- Addresses -->
        <div class="row">
            <div class="col-sm-6">
                <!-- Billing Address Block -->
                <div class="block">
                    <!-- Billing Address Title -->
                    <div class="block-title">
                        <h2><i class="fa fa-building-o"></i><strong> Billing</strong> Address</h2>
                    </div>
                    <!-- END Billing Address Title -->

                    <!-- Billing Address Content -->
                    <h4><strong>
                        <asp:Label ID="lblPartyName" runat="server"> </asp:Label></strong></h4>
                    <address>
                        <asp:Label ID="lblPartyAddress" runat="server"> </asp:Label><br>
                        <asp:Label ID="lblPartyCity" runat="server"> </asp:Label><br>
                        <asp:Label ID="lblPartyState" runat="server"> </asp:Label><br>
                        <br>
                        <i class="fa fa-phone"></i>
                        <asp:Label ID="lblPartyPhoneNumber" runat="server"> </asp:Label><br>
                        <i class="fa fa-envelope-o"></i><a href="#">
                            <asp:Label ID="lblPartyEmailId" runat="server"></asp:Label></a>
                    </address>
                    <!-- END Billing Address Content -->
                </div>
                <!-- END Billing Address Block -->
            </div>
            <div class="col-sm-6">
                <!-- Shipping Address Block -->
                <div class="block">
                    <!-- Shipping Address Title -->
                    <div class="block-title">
                        <h2><i class="fa fa-building-o"></i><strong> Shipping</strong> Address</h2>
                    </div>
                    <!-- END Shipping Address Title -->

                    <!-- Shipping Address Content -->
                    <h4><strong>
                        <asp:Label ID="lblshippingPartyName" runat="server"> </asp:Label></strong></h4>
                    <address>
                        <asp:Label ID="lblShippiAddress" runat="server"> </asp:Label><br>
                        <asp:Label ID="lblshippingcity" runat="server"> </asp:Label><br>
                        <asp:Label ID="lblshippingState" runat="server"> </asp:Label><br>
                        <br>
                        <i class="fa fa-phone"></i>
                        <asp:Label ID="lblshippingPhonenumber" runat="server"> </asp:Label><br>
                        <i class="fa fa-envelope-o"></i><a href="#">
                            <asp:Label ID="lblshippingEMailid" runat="server"></asp:Label></a>
                    </address>
                    <!-- END Shipping Address Content -->
                </div>
                <!-- END Shipping Address Block -->
            </div>
        </div>
        <!-- END Addresses -->

        <!-- Products Block -->
        <div class="block">
            <!-- Products Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                    <strong>Order Number : </strong>
                    <asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                </div>
                <h2><i class="fa fa-shopping-cart"></i><strong>Items Details</strong></h2>
            </div>
            <!-- END Products Title -->

            <!-- Products Content -->
            <div class="table-responsive">

                <asp:Repeater ID="rptrSaleOrderItemDetails" runat="server" OnItemCommand="rptrSaleOrderItemDetails_ItemCommand" OnItemDataBound="rptrSaleOrderItemDetails_ItemDataBound">
                    <HeaderTemplate>
                        <table id="ecom-orders" class="table table-bordered table-vcenter">
                            <thead>
                                <tr>
                                    <th class="text-center" style="width: 6%;">Item ID</th>
                                    <th>Item Name</th>
                                    <th style="width: 6%;">Item Type</th>
                                    <th class="text-center" style="width: 14%;">Item Quantity</th>
                                    <th class="text-right" style="width: 14%;">Item MRP (
                                        <asp:Label ID="lblPriceList" runat="server"> </asp:Label>
                                        )</th>
                                    <th class="text-right" style="width: 14%;">Amount</th>
                                    <th class="text-right" style="width: 20%;">Total Amount</th>

                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="text-center">
                                <asp:Label ID="lblItemId" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                            </td>

                            <td class="">
                                <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                            </td>
                            <td class="">
                                <asp:Label ID="lblItemTypetitle" Text='<%#Eval("sale_item_type_title")%>' runat="server"> </asp:Label>
                            </td>

                            <td class="text-center">
                                <asp:Label ID="lblItemQuantity" Text='<%#Eval("sale_item_quantity")%>' runat="server"></asp:Label>
                            </td>
                            <td class="text-right">
                                <asp:Label ID="lblItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>

                            </td>
                            <td class="text-right">
                                <asp:Label ID="lblItemNetPrice" Text='<%#Eval("sale_item_net_price")%>' runat="server"></asp:Label>

                            </td>
                            <td class="text-right">
                                <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>

                            </td>



                        </tr>


                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <td colspan="3" class="text-right text-uppercase"><strong>Total Items:</strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblTotalItemQuantity" runat="server"></asp:Label>

                            </strong></td>
                            <td class="text-right"><strong>
                                <asp:Label ID="lblItemTotalPrice" Visible="false" runat="server"></asp:Label>

                            </strong></td>
                            <td class="text-right"><strong>
                                <asp:Label ID="lblItemNetPrice" runat="server"></asp:Label>

                            </strong></td>
                            <td class="text-right"><strong>
                                <asp:Label ID="lblTotalallPrice" runat="server"></asp:Label>

                            </strong></td>

                        </tr>
                        <%-- <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong> HTF Discount:</strong></td>
                            
                            <td class="text-right">
                                <strong>
                                <asp:Label ID="lblHtfDiscount" runat="server"></asp:Label>

                            </strong>

                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="3" class="text-right text-uppercase"><strong>Net Rate Billing Percentage :</strong></td>
                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblNetRateBillingParcentage" runat="server"></asp:Label>
                                    %
                                </strong>

                            </td>

                            <td colspan="2" class="text-right text-uppercase">
                                <strong>Tough Discount @ 
                                    <asp:Label ID="lblToughDiscountPercentage" runat="server"></asp:Label>
                                    %
                                </strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblToughBillingAmount" runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="text-right text-uppercase"><strong>Net Rate Billing Amount :</strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblNetRateBillingAmount" runat="server"></asp:Label>

                                </strong>

                            </td>

                            <td colspan="2" class="text-right text-uppercase">
                                <strong>Lami Discount @
                                     <asp:Label ID="lblLamiDiscountPercentage" runat="server"></asp:Label>
                                    %
                                </strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblLamiBillingAmount" runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>


                        <tr>
                            <td colspan="3" class="text-right text-uppercase"><strong>Total Net Rate Amount :</strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblTotalNetRateAmount" runat="server"></asp:Label>

                                </strong>

                            </td>

                            <td colspan="2" class="text-right text-uppercase"><strong>Billable Amount :</strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblTotalBilledAmount" runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>Cash :</strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="LblTotalCash" runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>GST Amount :</strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblGstAmount" runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>

                        <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>Grand Total Amount:</strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblGrandTotalAmount" runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>
                        <tr >
                            <td colspan="6" class="text-right text-uppercase"><strong></strong></td>

                            <td class="text-right">
                                <strong>
                                    <asp:Label ID="lblTotalAmount" Visible="false"  runat="server"></asp:Label>

                                </strong>

                            </td>
                        </tr>

                        </table>         
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hdfdPurchaseNumber" runat="server" />
                <asp:HiddenField ID="hdfdSaleOrderId" runat="server" />
            </div>
            <!-- END Products Content -->
        </div>
        <!-- END Products Block -->

        <!--- Approved Start -->

        <%--<div class="block" id="divRejectPannelHeader" runat="server" visible="false">

            <div class="row">
                <div class="col-md-3">

                    <div class="form-group">

                        <label for="example-nf-password">Select  Order Status <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlOrderStatus" runat="server" CssClass="select-chosen" data-placeholder="Choose a Order Status.." AutoPostBack="false">
                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                            <asp:ListItem Value="approved">approved</asp:ListItem>
                            <asp:ListItem Value="rejected">rejected</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                </div>

                <div class="col-md-9" runat="server" id="divRejectPannel">

                    <div class="form-group">

                        <label for="example-nf-email">Rejection Remarks <span class="text-danger"></span></label>
                        <asp:TextBox ID="txtRejectionRemarks" runat="server" CssClass="form-control" placeholder="Enter Rejection Remarks"></asp:TextBox>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">

                        <asp:LinkButton ID="btnUpdateStatus" runat="server" Visible="false" Text="Update Status" OnClick="btnUpdateStatus_Click" CssClass="btn btn-sm btn-primary">Update Status</asp:LinkButton>

                    </div>
                </div>


            </div>


        </div>--%>


        <!---- End Approved --->


        <!-- Log Block -->

        <!-- END Log Block -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
