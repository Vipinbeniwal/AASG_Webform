<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-challan.aspx.cs" Inherits="AASGWeb.Modules.Billing.add_challan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>

 .table thead tr th
    {
    padding:5px 0;
    }
 .table tbody tr td
 {
      padding:3px 0;
 }
   </style>

    
    <style>
        .btn-margin
        {
            margin-top:24px;
        }
        @media (max-width:991px)
        {
             .btn-margin
            {
                margin-top:4px;
                margin-bottom:4px;
                float:right;
            }   
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
                          <%--  <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All GRN Details </a>--%>
                        </div>
                        <h2><strong>Add</strong>  Challan</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <asp:HiddenField ID="hdfdPartyMasterId" runat="server" />
                    <asp:HiddenField ID="hdfdLoadingMasterId" runat="server" />
                   

                    <%--<div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">PO Number <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPoNumber" runat="server" CssClass="form-control" onkeypress="return Number(event)" MinLength="1" MaxLength="6" placeholder="Enter PO Number"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4 ">
                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" OnClientClick="return validateGRNSearchinfo();" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-success btn-margin">Search</asp:LinkButton>
                        </div>



                    </div>--%>

                    <div class="row" runat="server" id="divPartyDetail_first" visible="false">
                         <div class="col-lg-8">
                    <!-- Billing Address Block -->
                    <div class="block">
                        <!-- Billing Address Title -->
                        <div class="block-title">
                            <h2>Party Details</h2>
                        </div>
                        <!-- END Billing Address Title -->

                        <!-- Billing Address Content -->
                        <div class="row">
                            <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">Party Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPartyName" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Party Name"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Mobile</label>
                                <asp:TextBox ID="txtMobile" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Mobile"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Party Address</label>
                                <asp:TextBox ID="txtPartyAddress" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Party Address"></asp:TextBox>

                            </div>
                        </div>

                         <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Vehicle Number <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtVehicleNumber" runat="server"  CssClass="form-control" placeholder="Enter Vehicle Number"></asp:TextBox>

                            </div>
                        </div>

                         <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Driver Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDriverName" runat="server"  CssClass="form-control" placeholder="Enter Driver Name"></asp:TextBox>

                            </div>
                        </div>

                         <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">Delivery Boy <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDeliveryBoy" runat="server" CssClass="form-control" placeholder="Enter Delivery Boy"></asp:TextBox>

                            </div>
                        </div>
                        </div>
                        
                          </div>
                     </div>

                         <div class="col-lg-4">
                    <!-- Billing Address Block -->
                    <div class="block">
                        <!-- Billing Address Title -->
                        <div class="block-title">
                            <h2>Generated Challan Details</h2>
                        </div>
                        <div class="row">

                            <div class="col-md-12">

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Repeater ID="rptrChallanHeaderList" runat="server" OnItemCommand="rptrChallanHeaderList_ItemCommand" OnItemDataBound="rptrChallanHeaderList_ItemDataBound">
                                            <HeaderTemplate>
                                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center">Sr.No</th>
                                                            <th class="text-center">Order Number</th>
                                                           <%-- <th class="text-center">Gst %</th>--%>
                                                            <th class="text-center">Action</th>

                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>

                                                    <td class="text-center">
                                                        <a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:Label ID="lblOrderNumber" Text='<%#Eval("order_number")%>' runat="server"> </asp:Label>

                                                        <asp:Label ID="lblGst"  runat="server" Visible="false"> </asp:Label>
                                                        <asp:Label ID="lblTotalBillAmount" Text='<%#Eval("total_amount_billed")%>' Visible="false" runat="server"> </asp:Label>
                                                        <asp:Label ID="lblGstAmount" Text='<%#Eval("gst_amount")%>' Visible="false" runat="server"> </asp:Label>
                                                    </td>
                                                    <%--<td class="text-center">
                                                    
                                                    </td>--%>
                                                      
                                                    <td class="text-center">
                                                        <asp:LinkButton ID="btnViewChallan" runat="server" CommandName="view" CommandArgument='<%# Eval("challan_header_id")%>' Visible="true" CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to View Challan" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                                    </td>


                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </table>         
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:HiddenField ID="hdnFDraftMasterId" runat="server" />
                                    </div>

                                </div>

                            </div>


                        </div>

                        </div>

                             </div>

                    </div>

                    <!-- Text Field or Dropdown for Add Dis in (%), Gst in (%), Bill in (%)  Start -->

                                    <asp:DropDownList ID="ddlItemWiseGst" runat="server" CssClass="select-chosen" Visible ="false" AutoPostBack="false" data-placeholder="Choose a gst ..">
                                          <asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
                                           <asp:ListItem Value="0">0 %</asp:ListItem>
                                           <asp:ListItem Value="18">18 %</asp:ListItem>
                                           <asp:ListItem Value="28">28 %</asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:TextBox ID="txtItemWiseDiscount" runat="server" Visible="false"  CssClass="form-control" placeholder="Enter discount in %"></asp:TextBox>
                            
                                     <asp:DropDownList ID="ddlItemWiseBill" runat="server" CssClass="select-chosen" Visible="false" AutoPostBack="false" data-placeholder="Choose a bill ..">
                                          <asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
                                           <asp:ListItem Value="0">0 %</asp:ListItem>
                                           <asp:ListItem Value="10">10 %</asp:ListItem>
                                           <asp:ListItem Value="20">20 %</asp:ListItem>
                                           <asp:ListItem Value="30">30 %</asp:ListItem>
                                           <asp:ListItem Value="40">40 %</asp:ListItem>
                                           <asp:ListItem Value="50">50 %</asp:ListItem>
                                           <asp:ListItem Value="60">60 %</asp:ListItem>
                                           <asp:ListItem Value="70">70 %</asp:ListItem>
                                           <asp:ListItem Value="80">80 %</asp:ListItem>
                                           <asp:ListItem Value="90">90 %</asp:ListItem>
                                           <asp:ListItem Value="100">100 %</asp:ListItem>
                                    </asp:DropDownList>

                    <!-- Text Field or Dropdown for Add Dis in (%), Gst in (%), Bill in (%)  End -->


                    <div class="row" runat="server" id="divSaleItemList" visible="false">
                         <div class="col-lg-12">
                    <!-- Billing Address Block -->
                    <div class="block">
                        <!-- Billing Address Title -->
                        <div class="block-title">
                            <h2>Item List</h2>
                        </div>
                         <div class="row">

                            <div class="col-md-12">

                                <div class="row">
                        <div class="col-md-12">
                            <asp:Repeater ID="rptrSaleOrderItemsList" runat="server" OnItemCommand="rptrSaleOrderItemsList_ItemCommand" OnItemDataBound="rptrSaleOrderItemsList_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <%--<th class="text-center ">Select</th>--%>
                                                <th class="text-center ">Item Type ID</th>
                                                <th class="text-center ">Item Type Name</th>
                                                <th class="text-center ">Item ID</th>
                                                <th class="text-center ">Item Name</th>
                                                <th class="text-center ">Item GST</th>
                                                <th class="text-center ">Disc. in %</th>
                                                <th class="text-center ">Bill. in %</th>
                                                <th class="text-center ">Actual Quantity</th>
                                                <th class="text-center ">Item Weight</th>
                                                <th class="text-center ">Item Price</th>
                                                <th class="text-center ">Net Rate</th>
                                                <th class="text-center " style="width: 20%;">Loading Quantity</th>
                                                <%--<th class="text-center">Remarks</th>--%>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                             <asp:CheckBox ID="chkChallanItem" runat="server" AutoPostBack="True" CssClass="btn btn-default text-center" Visible="false" OnCheckedChanged="chkChallanItem_CheckedChanged"/>
                                       
                                        <td class="text-center">
                                           <asp:Label ID="lblSaleItemTypeId" Text='<%#Eval("sale_item_type_id")%>' runat="server"> </asp:Label>
                                       </td>
                                       <td class="text-center">
                                            <asp:Label ID="lblSaleItemTypeName" Text='<%#Eval("sale_item_type_title")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemGstPercentage" Text='<%#Eval("item_gst_percentage")%>'  runat="server"> </asp:Label> %
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemWiseDiscountInPercentage" Text='<%#Eval("item_discount_percentage")%>'  runat="server"> </asp:Label> %
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemWiseBillingInPercentage" Text='<%#Eval("item_bill_percentage")%>'  runat="server"> </asp:Label> %
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblActualQuantity" Text='<%#Eval("sale_item_quantity")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemWeight" Text='<%#Eval("item_weight")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                    <asp:Label ID="lblSaleItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>
                                            <asp:Label ID="lblSaleItemPrice2" Visible="false" Text='<%#Eval("sale_item_price_2")%>' runat="server"></asp:Label>

                                      </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblSaleItemNetRate" Text='<%#Eval("sale_item_net_price")%>' runat="server"></asp:Label>

                                </td>
                                        <td class=" text-center">
                                            <asp:TextBox ID="txtSendQuantity" runat="server" CssClass="form-control text-center" Text='<%#Eval("sale_item_quantity")%>' onkeypress="return Number(event)" placeholder="0" onkeyup="return calculate(this);"></asp:TextBox>
                                        </td>
                                        <%--<td class=" text-center">
                                            <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" placeholder="Enter remarks"></asp:TextBox>
                                        </td>--%>

                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="7" class="text-right text-uppercase"><strong>Total Items:</strong></td>
                                        <td class="text-center"><strong>
                                           
                                            <asp:Label ID="lblTotalActualQuantity" runat="server"></asp:Label>
                                        </strong></td>
                                        <td class="text-center"><strong>
                                            
                                             <asp:Label ID="lblTotalItemWeight" runat="server"></asp:Label>

                                        </strong></td>
                                    </tr>

                                    </table>         
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="hdfditemId" runat="server" />
                            <asp:HiddenField ID="hdfdSaleOrderNumber" runat="server" />
                            <asp:HiddenField ID="hdfdSaleHeaderId" runat="server" />
                        </div>
                                    </div>
                                </div>
                             </div>
                        </div>
                             </div>
                    </div>

                      <div class="row" id="divFirstRepeaterActionButton" runat="server">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="btnResetConfirm" CssClass="btn btn-sm btn-warning" type="reset"  runat="server" Text="Reset"  OnClick="btnResetConfirm_Click" />
                        <asp:LinkButton ID="btnConfirmAndSubmit" runat="server" Text="Confirm & Proceed" Visible="true" OnClick="btnConfirmAndSubmit_Click" CssClass="btn btn-sm btn-primary">Confirm & Proceed</asp:LinkButton>
                        <asp:LinkButton ID="btnAddMultipleGSTTable" runat="server" Text="Add Multiple GST" Visible="false" OnClick="btnAddMultipleGSTTable_Click" CssClass="btn btn-sm btn-primary">Add Multiple</asp:LinkButton>

                    </div>
                </div>

            </div>

                    <div class="row" runat="server" id="divSaleItemwithGSt28Percentage" visible="false">
                        <div class="col-md-12">
                            <asp:Repeater ID="rptrSaleOrderItemGst28Percentage" runat="server" OnItemCommand="rptrSaleOrderItemGst28Percentage_ItemCommand" OnItemDataBound="rptrSaleOrderItemGst28Percentage_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <th class="text-center ">Item Type ID</th>
                                                <th class="text-center ">Item Type Name</th>
                                                <th class="text-center ">Item ID</th>
                                                <th class="text-center ">Item Name</th>
                                                <th class="text-center ">Item GST</th>
                                                <th class="text-center ">Actual Quantity</th>
                                                <th class="text-center ">Item Weight</th>
                                                <th class="text-center ">Item Price</th>
                                                <th class="text-center ">Net Rate</th>
                                                <th class="text-center " style="width: 20%;">Loading Quantity</th>
                                                <%--<th class="text-center">Remarks</th>--%>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center">
                                    <asp:Label ID="lblSaleItemTypeId" Text='<%#Eval("sale_item_type_id")%>' runat="server"> </asp:Label>
                                </td>
                                 <td class="text-center">
                                    <asp:Label ID="lblSaleItemTypeName" Text='<%#Eval("sale_item_type_title")%>' runat="server"> </asp:Label>
                                </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemGstPercentage"  runat="server"> </asp:Label> %
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblActualQuantity" Text='<%#Eval("sale_item_quantity")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemWeight" Text='<%#Eval("item_weight")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                    <asp:Label ID="lblSaleItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>
                                            <asp:Label ID="lblSaleItemPrice2" Visible="false" Text='<%#Eval("sale_item_price_2")%>' runat="server"></asp:Label>

                                      </td>
                                <td class=" text-center">
                                    <asp:Label ID="lblSaleItemNetRate" Text='<%#Eval("sale_item_net_price")%>' runat="server"></asp:Label>

                                </td>
                                        <td class=" text-center">
                                            <asp:TextBox ID="txtSendQuantity" runat="server" CssClass="form-control text-center" onkeypress="return Number(event)" placeholder="0" onkeyup="return calculate(this);"></asp:TextBox>
                                        </td>
                                        <%--<td class=" text-center">
                                            <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" placeholder="Enter remarks"></asp:TextBox>
                                        </td>--%>

                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="5" class="text-right text-uppercase"><strong>Total Items:</strong></td>
                                        <td class="text-center"><strong>
                                           
                                            <asp:Label ID="lblTotalActualQuantity" runat="server"></asp:Label>
                                        </strong></td>
                                        <td class="text-center"><strong>
                                            
                                             <asp:Label ID="lblTotalItemWeight" runat="server"></asp:Label>

                                        </strong></td>
                                    </tr>

                                    </table>         
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="hdfdItemIdBy28Percenatge" runat="server" />
                            <asp:HiddenField ID="hdfdSaleOrderNumberBy28Percenatge" runat="server" />
                            <asp:HiddenField ID="hdfdSaleHeaderIdBy28Percentage" runat="server" />
                        </div>

                    </div>

                     <div class="row" id="divSecondRepeaterActionButton" visible="false" runat="server">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="btnResetGst28Percentage" CssClass="btn btn-sm btn-warning" type="reset"  runat="server" Text="Reset"  OnClick="btnResetGst28Percentage_Click" />
                        <asp:LinkButton ID="btnConfirmAndSubmitGst28Percentage" runat="server" Text="Confirm & Proceed" OnClick="btnConfirmAndSubmitGst28Percentage_Click" CssClass="btn btn-sm btn-primary">Confirm & Proceed</asp:LinkButton>

                    </div>
                </div>

            </div>

                    <!--- Selected Challan Item List in Repeater Start -->

                    <div class="row" runat="server" id="divFinalChallanItemList" visible="false">
                         <div class="col-lg-12">
                    <!-- Billing Address Block -->
                    <div class="block">
                        <!-- Billing Address Title -->
                        <div class="block-title">
                            <h2>Challan Item List</h2>
                        </div>
                         <div class="row">

                            <div class="col-md-12">

                                <div class="row">
                        <div class="col-md-12">
                            <asp:Repeater ID="rptrchallanItemList" runat="server" OnItemCommand="rptrchallanItemList_ItemCommand" OnItemDataBound="rptrchallanItemList_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <th class="text-center ">Item Type ID</th>
                                                <th class="text-center ">Item Type Name</th>
                                                <th class="text-center ">Item ID</th>
                                                <th class="text-center ">Item Name</th>
                                                 <th class="text-center ">Item Weight</th>
                                                <th class="text-center ">Item GST</th>
                                                <th class="text-center ">Actual Qty</th>
                                                <th class="text-center " >Loading Qty</th>
                                                <th class="text-center ">Item Price</th>
                                                <th class="text-center ">Net Rate</th>
                                                <th class="text-center ">Discount(%)</th>
                                                <th class="text-center ">Bill @(%)</th>
                                                <th class="text-center ">Dis. Amt</th>
                                                <th class="text-center ">Amount</th>
                                                <th class="text-center ">B.Rate</th>
                                                <th class="text-center ">B.Amount</th>
                                                
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center">
                                           <asp:Label ID="lblSaleItemTypeId" Text='<%#Eval("sale_item_type_id")%>' runat="server"> </asp:Label>
                                       </td>
                                       <td class="text-center">
                                            <asp:Label ID="lblSaleItemTypeName" Text='<%#Eval("sale_item_type_title")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                                        </td>
                                         <td class=" text-center">
                                            <asp:Label ID="lblItemWeight" Text='<%#Eval("item_weight")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblItemGstPercentage" Text='<%#Eval("item_gst_percentage")%>'  runat="server"> </asp:Label> %
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblActualQuantity" Text='<%#Eval("sale_item_quantity")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblLoadingQuantity" Text='<%#Eval("sale_item_quantity_actual_load")%>' runat="server"></asp:Label>
                                        </td>
                                       
                                        <td class=" text-center">
                                            <asp:Label ID="lblSaleItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>
                                            <asp:Label ID="lblSaleItemPrice2" Visible="false" Text='<%#Eval("sale_item_price_2")%>' runat="server"></asp:Label>

                                      </td>
                                      <td class=" text-center">
                                            <asp:Label ID="lblSaleItemNetRate" Text='<%#Eval("sale_item_net_price")%>' runat="server"></asp:Label>
                                      </td>

                                        <td class=" text-center">
                                            <asp:Label ID="lblDiscountInPercentage" Text='<%#Eval("item_discount_percentage")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemWiseBillPercentage" Text='<%#Eval("item_bill_percentage")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemDiscountAmount" Text='<%#Eval("item_discount_amount")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemWiseAmount" Text='<%#Eval("item_amount")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemBillingRate" Text='<%#Eval("item_bill_rate")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class=" text-center">
                                            <asp:Label ID="lblItemBillAmount" Text='<%#Eval("item_bill_amount")%>' runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="4" class="text-right text-uppercase"><strong>Total:</strong></td>
                                        <td class="text-center"><strong>
                                             <asp:Label ID="lblTotalItemWeight" runat="server"></asp:Label>
                                        </strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        <td class="text-center" ><strong>
                                           
                                            <asp:Label ID="lblTotalActualQuantity" runat="server"></asp:Label>
                                        </strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        
                                        <td class="text-center" ><strong>
                                             <asp:Label ID="lblTotalItemAmount" runat="server"></asp:Label>
                                        </strong></td>
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        
                                        <td class="text-center" ><strong>
                                             <asp:Label ID="lblTotalBillAmount" runat="server"></asp:Label>
                                        </strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="13" class="text-right text-uppercase"><strong>GST:</strong></td>
                                        <td class="text-center"><strong>
                                             <asp:Label ID="lblTotalGstAmount" runat="server"></asp:Label>
                                        </strong></td>
                                       
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        
                                        <td class="text-center" ><strong>
                                             <asp:Label ID="lblBillingGSTAmount" runat="server"></asp:Label>
                                        </strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="13" class="text-right text-uppercase"><strong>Total Amount:</strong></td>
                                        <td class="text-center"><strong>
                                             <asp:Label ID="lblChallanTotalAmount" runat="server"></asp:Label>
                                        </strong></td>
                                       
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        
                                        <td class="text-center" ><strong>
                                            
                                        </strong></td>
                                    </tr>
                                     <tr>
                                        <td colspan="13" class="text-right text-uppercase"><strong>Bill Amount:</strong></td>
                                        <td class="text-center"><strong>
                                             <asp:Label ID="lblChallanBillAmount" runat="server"></asp:Label>
                                        </strong></td>
                                       
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        
                                        <td class="text-center" ><strong>
                                            
                                        </strong></td>
                                    </tr>
                                     <tr>
                                        <td colspan="13" class="text-right text-uppercase"><strong>Cash Amount:</strong></td>
                                        <td class="text-center"><strong>
                                             <asp:Label ID="lblChallanCashAmount" runat="server"></asp:Label>
                                        </strong></td>
                                       
                                        <td class="text-right text-uppercase"><strong></strong></td>
                                        
                                        <td class="text-center" ><strong>
                                            
                                        </strong></td>
                                    </tr>
                                    </table>         
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                           
                        </div>
                                    </div>
                                </div>
                             </div>
                        </div>
                             </div>
                    </div>

                    <!--- Selected Challan Item List in Repeater End -->


                     <div class="row" id="divDiscountandPercentage" runat="server">
                <div class="col-md-2">
                    <div class="form-group">

                        <label for="example-nf-password">Tough Discount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtToughDiscount" runat="server" CssClass="form-control" placeholder="Enter Tough Discount" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtToughDiscount_TextChanged" MaxLength="5" MinLength="0"></asp:TextBox>
                        <label for="size" style="float: right"><i class="fa fa-rupee"></i>: <asp:Label ID="lblToughDiscountAmount"   runat="server"> </asp:Label></label>
                        
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Billing Percentage <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtToughBillingPercentage" runat="server" CssClass="form-control" placeholder="Enter Billing Percentage" AutoPostBack="true" onkeypress="return isNumberKey(event)" OnTextChanged="txtToughBillingPercentage_TextChanged" MaxLength="5" MinLength="0"></asp:TextBox>
                        <label for="size" style="float: right"><i class="fa fa-rupee"></i>: <asp:Label ID="lblToughBillingPercentageAmount"   runat="server"> </asp:Label></label>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">LAMI Discount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtLamiDiscount" runat="server" CssClass="form-control" placeholder="Enter LAMI Discount"></asp:TextBox>
                        <label for="size" style="float: right"><i class="fa fa-rupee"></i>: <asp:Label ID="lblLamiDiscountAmount"   runat="server"> </asp:Label></label>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Billing Percentage <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtLamiBillingPercentage" runat="server" CssClass="form-control" placeholder="Enter Billing Percentage"></asp:TextBox>
                        <label for="size" style="float: right"><i class="fa fa-rupee"></i>: <asp:Label ID="lblLamiBillingPercentageAmount"   runat="server"> </asp:Label></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Net Rate Billing Percentage <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtNetRateBillingPercentage" runat="server" CssClass="form-control" placeholder="Enter Net Rate Billing Percentage" AutoPostBack="true" onkeypress="return Number(event)" OnTextChanged="txtNetRateBillingPercentage_TextChanged" MaxLength="5" MinLength="0"></asp:TextBox>
                       <label for="size" style="float: right"><i class="fa fa-rupee"></i>: <asp:Label ID="lblnetRateBillingPercentageAmount"   runat="server"> </asp:Label></label>
                    </div>
                </div>

            </div>

                     <div class="row" id="divTotalAmountCashBill" runat="server">
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

                   


                    <div class="row" runat="server" id="divActionButtons" visible="false">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" OnClick="BtnReset_Click" Text="Reset"  />
                                
                                <asp:LinkButton ID="btnSubmit" runat="server" Text="Add Purchase"  OnClick="btnSubmit_Click"  CssClass="btn btn-sm btn-primary">Add Challan</asp:LinkButton>

                            </div>
                        </div>


                    </div>

                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>
        <!-- END All Role Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



</asp:Content>
