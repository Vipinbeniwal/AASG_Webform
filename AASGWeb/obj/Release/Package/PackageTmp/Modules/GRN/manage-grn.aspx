<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-grn.aspx.cs" Inherits="AASGWeb.Modules.GRN.manage_grn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Page content -->
                <div id="page-content">
                    <!-- Dashboard 2 Header -->
                    <div class="content-header">
                        <ul class="nav-horizontal text-center">
                            <li class="active">
                                <a href="javascript:void(0)"><i class="fa fa-home"></i> Home</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-charts"></i> Create Bill</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-briefcase"></i> Production</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-video_hd"></i> Returns</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-music"></i> SaleOrders</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cubes"></i> Accounts</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-pencil"></i> Challans</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cogs"></i> Settings</a>
                            </li>
                        </ul>
                    </div>
                    <!-- END Dashboard 2 Header -->
                     
                        <!-- Quick Stats -->
                        <%--<div class="row text-center">
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light"><strong>Pending</strong> GRN</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 animation-expandOpen">3</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Orders</strong> Today</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">120</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Orders</strong> This Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">3.200</span></div>
                                </a>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <a href="javascript:void(0)" class="widget widget-hover-effect2">
                                    <div class="widget-extra themed-background-dark">
                                        <h4 class="widget-content-light"><strong>Orders</strong> Last Month</h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 themed-color-dark animation-expandOpen">2.850</span></div>
                                </a>
                            </div>
                        </div>--%>
                        <!-- END Quick Stats -->

                        <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                
                                </div>
                                <h2><strong>All</strong> Orders</h2>
                            </div>
                            <!-- END All Orders Title -->

                              <!-- All Orders Content -->
                            <div class="table-responsive">
                            <asp:Repeater ID="rptrStockLedger" runat="server" OnItemCommand="rptrStockLedger_ItemCommand" OnItemDataBound="rptrStockLedger_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                <th class="text-center" style="width: 50px;">ID</th>
                                <th class="text-center ">PO Number</th>
                                <th class="text-center ">Invoice Number</th>
                                <th class="text-center ">Item Quantity</th>
                                <th class="text-center ">Received Quantity</th>
                                <th class="text-center ">Date</th>
                                <th>Status</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        
                        <td class="text-center"><a href="#"><strong>AASG/ZZ/<%# Container.ItemIndex + 1 %></strong></a>    </td>

                        <td class=" text-center">
                            <asp:Label ID="lblPoNumber" Text='<%#Eval("purchase_header_id")%>' runat="server"></asp:Label>
                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblInvoiceNumber" Text='<%#Eval("purchase_invoice_number")%>' runat="server"></asp:Label>
                        </td>

                          <td class=" text-center">
                            <asp:Label ID="lblPurchaseQuantity" Text='<%#Eval("purchase_item_quantity")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblReceivedQuantity" Text='<%#Eval("purchase_item_received_quantity")%>' runat="server"></asp:Label>

                        </td>
                        <td class=" text-center">
                            <asp:Label ID="lblPurchaseRemarks" Text='<%#Eval("created_on","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                            <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("purchase_header_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                            <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("purchase_header_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>

                        </td>
                        <td class=" text-center btn-group-xs ">
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("purchase_header_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                            <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("purchase_header_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hdfdPurchaseItemId" runat="server" />
                            </div>
            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
