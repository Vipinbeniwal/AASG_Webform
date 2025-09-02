<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="acknowledge.aspx.cs" Inherits="AASGWeb.Modules.Production.acknowledge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
       <%-- <!-- END Dashboard 2 Header -->
        <ul class="breadcrumb breadcrumb-top">
            <li>Forms</li>
            <li><a href="#">General</a></li>
        </ul>
        <!-- END Forms General Header -->--%>

        <!-- Normal Form Block -->
        <div class="block full">
            <!-- Normal Form Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                <%--    <a href="#" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Purchases </a>--%>
                </div>
                <h2><strong>Acknowledge</strong>  Master</h2>
            </div>
            <!-- END Normal Form Title -->

            <!-- Normal Form Content -->
            <asp:HiddenField ID="hdnfAcknowledgeProductionId" runat="server" />
                            <asp:HiddenField ID="hdnfAcknowledgePlantName" runat="server" />


            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Item Name <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Item Name"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Thickness <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtThickness" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Thickness"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Sheet Height <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtSheetHeight" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Sheet Height"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">Sheet Width <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtSheetWidth" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Sheet Width"></asp:TextBox>

                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <label for="example-nf-password">No of Sheet Issue <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtNoofSheetIssue" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="No of Sheet Issue"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-1">
                    <div class="form-group">
                        <label for="example-nf-password">Qty Per Sheet<span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtQuantityPerSheet" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Qty Per Sheet"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-1">
                    <div class="form-group">
                        <label for="example-nf-password">Total Exp <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txttotalExpectation" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Total Exp"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">

                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:LinkButton ID="btnAddItem" runat="server" Text="Add" Visible="true"  OnClick="btnAddItem_Click" CssClass="btn btn-sm btn-primary">Add</asp:LinkButton>
                        <asp:LinkButton ID="btnShowMoreItemField" runat="server" Text="Add More" Visible="false" OnClick="btnShowMoreItemField_Click" CssClass="btn btn-sm btn-primary">Add More</asp:LinkButton>

                    </div>
                </div>

            </div>

            <div class="row" id="divMoreItemAdd" runat="server" visible="false">
                
                <div class="col-md-3">
                    <div class="form-group">

                        <label for="example-nf-password"> Select Item <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlItemList" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Item ..">
                            <asp:ListItem></asp:ListItem>
                            

                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <label for="example-nf-password">Qty Per Sheet <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtItemQuantityPerSheetfromMore" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Qty Per Sheet"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="example-nf-password">Total Exp <span class="text-danger">*</span></label>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TextBox ID="txtTotalExpectationfromMore" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Total Exp"></asp:TextBox>

                            </div>

                            <div class="col-md-6">
                                <asp:LinkButton ID="btnAddMoreItem" runat="server" Text="Add" CssClass="btn btn-sm btn-primary form-actions" Style="float: right; margin-top: 5px;">Add</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>

            </div>


            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                    <asp:Repeater ID="rptrAcknowledgeItemsList" runat="server" Visible="false" OnItemCommand="rptrAcknowledgeItemsList_ItemCommand" OnItemDataBound="rptrAcknowledgeItemsList_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center">Item ID</th>
                                        <th class="text-center">Item Name</th>
                                        <th class="text-center">Qty Per Sheet</th>
                                        <th class="text-center">Total Exp</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><a href="#"><strong><%# Container.ItemIndex + 1 %></strong></a>    </td>


                              
                                 <td class="text-center">
                                    <asp:Label ID="lblItemMasterId" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="lblItemName" Text='<%#Eval("item_name")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="lblItemQuantity" Text='<%#Eval("item_quantity_per_sheet")%>' runat="server"></asp:Label>
                                </td>
                                <td class="text-center">
                                    <asp:Label ID="lblItemPrice" Text='<%#Eval("item_pcs_total_expectation")%>' runat="server"></asp:Label>

                                </td>

                                <td class=" text-center">
                                    <div class="btn-group btn-group-xs">
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("item_master_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>         
                        </FooterTemplate>
                    </asp:Repeater>
                    </div>
                    <asp:HiddenField ID="hdfditemId" runat="server" />
                </div>

            </div>

           <%-- <div class="row">
                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password">Total Amount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txttotalAmount" runat="server" Enabled="false" CssClass="form-control" placeholder="Total Amount"></asp:TextBox>

                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password">Total Paid Amount </label>
                        <asp:TextBox ID="txtTotalPaid" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Paid Amount" AutoPostBack="True"  OnTextChanged="txtTotalPaid_TextChanged"> </asp:TextBox>

                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password">Total Pending Amount <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtPendingAmount" runat="server" Enabled="false" CssClass="form-control" placeholder="Pending Amount"></asp:TextBox>

                    </div>
                </div>



            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password">Discount in (%) </label>
                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" placeholder="Enter Discount"></asp:TextBox>

                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Payment By </label>
                        <asp:DropDownList ID="ddlPaymentBy" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a PaymentBy..">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                            <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                            <asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
                            <asp:ListItem Value="Account Transfer">Account Transfer</asp:ListItem>
                            <asp:ListItem Value="Demand Draft Card">Demand Draft Card</asp:ListItem>
                            <asp:ListItem Value="Paytm">Paytm</asp:ListItem>
                            <asp:ListItem Value="Google Pay">Google Pay</asp:ListItem>
                            <asp:ListItem Value="Bhim UPI">Bhim UPI</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Reference No </label>
                        <asp:TextBox ID="txtReffrenceNo" runat="server" CssClass="form-control" placeholder="Enter Reference Number"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">

                <div class="col-md-12">
                    <div class="form-group">
                        <label for="example-nf-password">Remarks </label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Enter Remarks"></asp:TextBox>

                    </div>
                </div>

            </div>--%>

            <%--<div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                        <asp:LinkButton ID="btnUpdate" runat="server" Text="Update Purchase" Visible="false" OnClick="btnUpdate_Click" CssClass="btn btn-sm btn-success">Update Purchase</asp:LinkButton>
                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Add Purchase" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-primary">Add Purchase</asp:LinkButton>

                    </div>
                </div>


            </div>--%>

            <!-- END Normal Form Content -->
        </div>
        <!-- END Normal Form Block -->




        <!-- END All Role Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
