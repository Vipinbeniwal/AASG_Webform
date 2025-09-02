<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-sale-order.aspx.cs" Inherits="AASGWeb.Modules.Billing.add_sale_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .btn-xs, .btn-group-xs > .btn {
            padding: 0px 5px;
            font-size: 8px !important;
            line-height: 1.6;
            border-radius: 3px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        <ul class="breadcrumb breadcrumb-top">
            <li>Sale Order</li>
            <li><a href="/add-return">Add Sale Order</a></li>
        </ul>



        <!-- END Forms General Header -->
        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                   <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Excel Export</a>--%>
                </div>
                <h2><strong>Add</strong> Sale Order</h2>
                 <asp:HiddenField ID="HdnfSaleHeaderId" runat="server" />
                <asp:LinkButton ID="btnAddParty" runat="server" Text="Add New Party"  CssClass="btn-primary" style="padding: 4px;border-radius: 12px;" OnClick="btnAddParty_Click"> </asp:LinkButton>
            </div>

            <div class="row">
               
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-email">Order By (Customer) <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlPartyName" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Party..">
                            <asp:ListItem></asp:ListItem>

                        </asp:DropDownList>
                    </div>

                </div>
                
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-email">Price Type <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlPriceType" runat="server" CssClass="select-chosen" OnSelectedIndexChanged="ddlPriceType_SelectedIndexChanged" AutoPostBack="true" data-placeholder="Choose a Price Type..">
                            <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                            <asp:ListItem Value="10G">10G</asp:ListItem>
                            <asp:ListItem Value="11G">11G</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="col-md-2">
                    <div class="form-group">

                        <label for="example-nf-password">Select Item Type <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlItemTypeList" runat="server" CssClass="select-chosen" AutoPostBack="true" OnSelectedIndexChanged="ddlItemTypeList_SelectedIndexChanged" data-placeholder="Choose a Item type ..">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Fixed Discount in % <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtFixedDiscountinPercentage" runat="server" CssClass="form-control" placeholder="Enter Discount in % " onkeypress="return isNumberKey(event)" MaxLength="3" ></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Fixed Billing in % <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtFixedBillingInPercentage" runat="server" CssClass="form-control" placeholder="Enter Billing in % " onkeypress="return isNumberKey(event)" MaxLength="3"></asp:TextBox>

                    </div>
                </div>

            </div>
            <div class="row">

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Select Item <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlItemList" runat="server" CssClass="select-chosen" AutoPostBack="true" OnSelectedIndexChanged="ddlItemList_SelectedIndexChanged" data-placeholder="Choose a Item ..">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>

                        <label for="size" style="float: right">
                            GST <i class=" fa fa-percent"></i>:
                            <asp:Label ID="lblItemWiseGstinPercentage" runat="server" Visible="true"></asp:Label></label>
                        <asp:Label ID="lblItemWiseWeight" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblItemWisePrice2" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="row">

                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="example-nf-password">Item MRP <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtItemWisePrice" runat="server" CssClass="form-control" placeholder="Enter Price " Enabled="false"></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="example-nf-password">Discount in % <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtItemWiseDiscountInPercentage" runat="server" CssClass="form-control" placeholder="Enter Discount in % "  AutoPostBack="true" OnTextChanged="txtItemWiseDiscountInPercentage_TextChanged" MaxLength="3"></asp:TextBox>
                                <asp:Label ID="lblItemWisePrice" runat="server" Visible="false"> </asp:Label>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="example-nf-password">Billing in % <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtItemWiseBillingInPercentage" runat="server" CssClass="form-control" placeholder="Enter Billing in %" AutoPostBack="true" OnTextChanged="txtItemWiseBillingInPercentage_TextChanged" onkeypress="return Number(event)" MaxLength="3"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="example-nf-password">Required Quantity <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtItemQuantity" runat="server" CssClass="form-control" placeholder="Enter Quantity" onkeypress="return Number(event)" AutoPostBack="false" OnTextChanged="txtItemQuantity_TextChanged" MaxLength="3"></asp:TextBox>


                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="example-nf-password">Discounted Value <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDiscountedValue" runat="server" CssClass="form-control" Enabled="false" placeholder="Enter Quantity" onkeypress="return Number(event)"></asp:TextBox>


                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="example-nf-password">Final Amount <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtFinalItemAmount" runat="server" CssClass="form-control" placeholder="Enter Amount" onkeypress="return Number(event)" Enabled="false"></asp:TextBox>
                                <asp:TextBox ID="txtNetRate" runat="server" CssClass="form-control" placeholder="Enter Price" Visible="false" onkeypress="return Number(event)"></asp:TextBox>

                            </div>
                        </div>
                    </div>


                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:LinkButton ID="btnResetPartyDetails" runat="server" Text="Reset" OnClick="btnResetPartyDetails_Click" CssClass="btn btn-sm btn-warning">Reset </asp:LinkButton>
                        <asp:LinkButton ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-sm btn-primary">Add Item </asp:LinkButton>

                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:Repeater ID="rptrItems" runat="server" Visible="false" OnItemCommand="rptrItems_ItemCommand" OnItemDataBound="rptrItems_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <%--<th class="text-center" style="width: 50px;">ID</th>--%>
                                        <th class="text-center ">Item Type ID</th>
                                        <th class="text-center ">Item Type Name</th>
                                        <th class="text-center ">Item ID</th>
                                        <th class="text-center ">Item Name</th>
                                        <th class="text-center ">Item Quantity</th>
                                        <%--<th class="text-center ">Item Weight</th>--%>
                                        <th class="text-center ">GST</th>
                                        <th class="text-center ">Item Price</th>
                                        <th class="text-center ">Net Rate</th>
                                        <th class="text-center ">Disc. %</th>
                                         <th class="text-center ">Bill %</th>
                                        <th class="text-center ">Disc. Amt</th>
                                        <%--price-(price/100*Discount Percentage)--%>
                                        <th class="text-center ">Amount</th>
                                        <th class="text-center ">Final Amount</th>
                                        <%--Qty*Discounted Amount--%>
                                       
                                       <%-- <th class="text-center ">B.Rate</th>--%>
                                        <%-- DIscount Ampount / 100 * Billing Percentage--%>
                                        <%--<th class="text-center ">B.Amount</th>--%>
                                        <%-- Billing rate * Quantity--%>

                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <%--<td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>    </td>--%>

                                <td class="text-center">
                                    <asp:Label ID="lblSaleItemTypeId" Text='<%#Eval("sale_item_type_id")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="lblSaleItemTypeName" Text='<%#Eval("sale_item_type_title")%>' runat="server"> </asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblItemMasterId" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblSaleItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblSaleItemQuantity" Text='<%#Eval("sale_item_quantity")%>' runat="server"></asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblItemGst" Text='<%#Eval("item_gst_percentage")%>' runat="server"></asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblSaleItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>

                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblSaleItemNetRate" Text='<%#Eval("sale_item_net_price")%>' runat="server"></asp:Label>

                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblItemDiscountPercentage" Text='<%#Eval("item_discount_percentage")%>' runat="server"></asp:Label>
                                </td>
                                 <td class=" text-center">
                                    <asp:Label ID="lblItemBillingPercenatge" Text='<%#Eval("item_bill_percentage")%>' runat="server"></asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblItemDiscountAmount" Text='<%#Eval("item_discount_amount")%>' runat="server"></asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblItemTotalAmountQtyWise" Text='<%#Eval("item_amount")%>' runat="server"></asp:Label>
                                </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblItemWiseFinalAmount" Text='<%#Eval("item_final_amount")%>' runat="server"></asp:Label>
                                    
                                    <asp:Label ID="lblItemBillingRate" Text='<%#Eval("item_bill_rate")%>' Visible="false" runat="server"></asp:Label>
                                    <asp:Label ID="lblItemBilledAmount" Text='<%#Eval("item_bill_amount")%>' Visible="false" runat="server"></asp:Label>
                                </td>
                               
                                <%--<td class=" text-center">
                                    
                                </td>
                                <td class=" text-center">
                                    
                                </td>--%>


                                <td class=" text-center">
                                    <div class="btn-group btn-group-xs">
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("item_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td colspan="4" class="text-right text-uppercase"><strong>Total:</strong></td>
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblTotalActualQuantity" runat="server"></asp:Label>
                                </strong></td>
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblTotalItemWeight" runat="server"></asp:Label>
                                </strong></td>
                               
                                
                                <td class="text-right text-uppercase"><strong></strong></td>
                                <td class="text-right text-uppercase"><strong></strong></td>
                                <td class="text-right text-uppercase"><strong></strong></td>
                                <td class="text-right text-uppercase"><strong></strong></td>
                                 <td class="text-right text-uppercase"><strong></strong></td>
                                
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblTotalItemAmount" runat="server"></asp:Label>
                                </strong></td>
                               
                                 <td class="text-right text-uppercase"><strong></strong></td>
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblTotalBillAmount" Visible="false" runat="server"></asp:Label>
                                </strong></td>
                                
                            </tr>
                            <tr>
                                <td colspan="11" class="text-right text-uppercase"><strong>GST:</strong></td>
                                
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblTotalGstAmount" runat="server"></asp:Label>
                                </strong></td>

                                <td class="text-right text-uppercase"><strong></strong></td>
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblBillingGSTAmount" Visible="false" runat="server"></asp:Label>
                                </strong></td>
                               
                            </tr>
                            <tr>
                                <td colspan="11" class="text-right text-uppercase"><strong>Total Amount:</strong></td>
                               
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblSaleTotalAmount" runat="server"></asp:Label>
                                </strong></td>

                                <td class="text-right text-uppercase"><strong></strong></td>

                                <td class="text-center"><strong></strong></td>
                               
                            </tr>
                            <tr>
                                <td colspan="11" class="text-right text-uppercase"><strong>Bill Amount:</strong></td>
                                
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblSaleBillAmount" runat="server"></asp:Label>
                                </strong></td>

                                <td class="text-right text-uppercase"><strong></strong></td>

                                <td class="text-center"><strong></strong></td>
                               
                            </tr>
                            <tr>
                                <td colspan="11" class="text-right text-uppercase"><strong>Cash Amount:</strong></td>
                                
                                <td class="text-center"><strong>
                                    <asp:Label ID="lblSaleCashAmount" runat="server"></asp:Label>
                                </strong></td>

                                <td class="text-right text-uppercase"><strong></strong></td>
                                <td class="text-center"><strong></strong></td>
                               
                            </tr>

                            </table>         
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hdfditemId" runat="server" />
                </div>

            </div>

            <asp:Button ID="btnResetConfirm" CssClass="btn btn-sm btn-warning" type="reset" Visible="false" runat="server" Text="Reset" OnClick="btnResetConfirm_Click" />
             <asp:LinkButton ID="btnConfirmAndSubmit" runat="server" Text="Confirm & Proceed" Visible="false" OnClick="btnConfirmAndSubmit_Click" CssClass="btn btn-sm btn-primary">Confirm & Proceed</asp:LinkButton>


            <div class="row" id="divToughBillingLamiDiscount" runat="server" visible="false">
                <div class="col-md-2">
                    <div class="form-group">

                        <label for="example-nf-password">Tough Discount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtToughDiscount" runat="server" CssClass="form-control" placeholder="Enter Tough Discount" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtToughDiscount_TextChanged" MaxLength="5" MinLength="0"></asp:TextBox>
                        <label for="size" style="float: right">
                            <i class="fa fa-rupee"></i>:
                            <asp:Label ID="lblToughDiscountAmount" runat="server"> </asp:Label></label>

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Billing Percentage <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtToughBillingPercentage" runat="server" CssClass="form-control" placeholder="Enter Billing Percentage" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtToughBillingPercentage_TextChanged" MaxLength="5" MinLength="0"></asp:TextBox>
                        <label for="size" style="float: right">
                            <i class="fa fa-rupee"></i>:
                            <asp:Label ID="lblToughBillingPercentageAmount" runat="server"> </asp:Label></label>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">LAMI Discount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtLamiDiscount" runat="server" CssClass="form-control" placeholder="Enter LAMI Discount"></asp:TextBox>
                        <label for="size" style="float: right">
                            <i class="fa fa-rupee"></i>:
                            <asp:Label ID="lblLamiDiscountAmount" runat="server"> </asp:Label></label>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Billing Percentage <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtLamiBillingPercentage" runat="server" CssClass="form-control" placeholder="Enter Billing Percentage"></asp:TextBox>
                        <label for="size" style="float: right">
                            <i class="fa fa-rupee"></i>:
                            <asp:Label ID="lblLamiBillingPercentageAmount" runat="server"> </asp:Label></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Net Rate Billing Percentage <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtNetRateBillingPercentage" runat="server" CssClass="form-control" placeholder="Enter Net Rate Billing Percentage" AutoPostBack="true" onkeypress="return Number(event)" OnTextChanged="txtNetRateBillingPercentage_TextChanged" MaxLength="5" MinLength="0"></asp:TextBox>
                        <label for="size" style="float: right">
                            <i class="fa fa-rupee"></i>:
                            <asp:Label ID="lblnetRateBillingPercentageAmount" runat="server"> </asp:Label></label>
                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Total Amount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Total Amount"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Bill Amount<span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtBillAmount" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Bill Amount"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Total Cash <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtTotalCash" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Total Cash"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="example-nf-password">Order Remarks <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Enter Some order remarks here limited to maximum of 250 characters" MaxLength="250"></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                        <asp:LinkButton ID="btnSubmitOrder" runat="server" Text="Save Order" OnClick="btnSubmitOrder_Click" Visible="true" CssClass="btn btn-sm btn-primary">Save Order</asp:LinkButton>
                        <asp:LinkButton ID="btnUpdateOrder" runat="server" Text="Save Order" OnClick="btnUpdateOrder_Click" Visible="false" CssClass="btn btn-sm btn-primary">Save Order</asp:LinkButton>
                    </div>
                </div>
            </div>

            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
