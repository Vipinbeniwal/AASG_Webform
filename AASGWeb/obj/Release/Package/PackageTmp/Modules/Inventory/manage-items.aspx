<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="manage-items.aspx.cs" Inherits="AASGWeb.Modules.Inventory.manage_items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function showOrderDetailsModal() {
            $("#modal-create-order-details").modal('show');

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

        <div id="modal-content">

            <!-- User Settings, modal which opens from Settings link (found in top right user menu) and the Cog link (found in sidebar user info) -->

            <!-- END User Settings -->

            <div id="modal-create-order-details" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header text-center">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h2 class="modal-title"><i class="fa fa-industry"></i> Production Item Master </h2>
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
                                                <h2><strong>Production</strong> Item Details</h2>
                                            </div>

                                            <div class="row">

                                                
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Brand <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" placeholder=" brand"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Model <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" placeholder=" model"></asp:TextBox>

                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Item Type <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtItemType" runat="server" CssClass="form-control" placeholder="Enter item type"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Glass Color <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtGlassColor" runat="server" CssClass="form-control" placeholder="Enter glass color"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Factory Stock <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtFactoryStock" runat="server" CssClass="form-control" placeholder="Enter factory stock"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Stock Max Level <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtStockMaxLevel" runat="server" CssClass="form-control" placeholder="Enter stock Max Level"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-password">Production Quantity <span class="text-danger">*</span></label>
                                                        <asp:TextBox ID="txtProductionQuantity" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter production quantity" MinLength="0" MaxLength="3"></asp:TextBox>
                                                    </div>
                                                </div>



                                            </div>

                                            <div class="row" id="divError" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions" style="float: right">
                                                        <asp:Label runat="server" ID="lblErrroMessage" CssClass="text-danger"></asp:Label>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions" style="float: right">
                                                        <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" OnClick="BtnReset_Click" Text="Reset"  />
                                                        
                                                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Process To Production" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-primary">Process To Production</asp:LinkButton>

                                                    </div>
                                                </div>


                                            </div>


                                            <%--<div class="row">
                                                    <div class="col-md-12">
                                                        <!-- All Orders Block -->
                                                        <div class="block full">
                                                            <!-- All Orders Title -->
                                                            <div class="block-title">
                                                                <div class="block-options pull-right">
                                                                   
                                                                </div>
                                                                <h2><strong>Billing</strong> Details</h2>
                                                            </div>
                                                            <!-- END All Orders Title -->

                                                            <!-- All Orders Content -->
                                                            <div class="row">
                                                                
                                                      <!-- Repeater Table -->
                                                                 <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center ">Item ID</th>
                                        <th class="text-center ">Item Name</th>
                                        <th class="text-center ">Item Quantity</th>
                                        <th class="text-center ">Item Price</th>
                                       
                                    </tr>
                                </thead>
                        
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><a href="#"><strong>AASG 1</strong></a>    </td>

                                
                                <td class=" text-center">
                                    TATA | BOLT | Backscreen | Green
                                </td>
                                <td class=" text-center">
                                    1370.00
                                </td>
                                <td class=" text-center">
                                    822.00 x 15
                                </td>
                                <td class=" text-center">
                                   12330.00

                                </td>

                                
                            </tr>
                        </ItemTemplate>
                        
                            </table>         
                       


                                                      
                                                  
                                                            </div>
                                                            
                                                            <!-- END All Orders Content -->
                                                        </div>
                                                        <!-- END All Orders Block -->
                                                    </div>

                                                    


                                                </div>--%>
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



        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                    <asp:LinkButton ID="btnDownloadExcel" runat="server" CssClass="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="tooltip" data-placement="bottom" title="Download Excel Report" data-original-title="Basic tooltp" Text="Export" OnClick="btnDownloadExcel_Click"></asp:LinkButton>

                </div>
                <h2><strong>All</strong> Items</h2>
            </div>
            <!-- END All Orders Title -->

            <!-- All Orders Content -->
            <div class="table-responsive">
                <asp:Repeater ID="rptrManageItems" runat="server" OnItemCommand="rptrManageItems_ItemCommand" OnItemDataBound="rptrManageItems_ItemDataBound">
                    <HeaderTemplate>
                        <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                            <thead>
                                <tr>
                                    <th class="text-center" style="width: 50px;">ID</th>
                                    <th class="text-left">Brand</th>
                                    <th class="text-left">Model</th>
                                    <th class="text-left">Description</th>
                                    <th class="text-center">Size</th>
                                    <th class="text-center">Actual SQM</th>
                                    <th class="text-center">Thicness</th>
                                    <th class="text-center">Perimeter</th>
                                    <th class="text-center">Ready Stock</th>
                                    <th class="text-center">Priority</th>
                                    <th class="text-center">Action</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center;"><%# Container.ItemIndex + 1 %>    </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblBrand" Text='<%#Eval("brand")%>' runat="server" /><br />
                                <%-- ( <%# DataBinder.Eval(Container.DataItem, "FromTime")%>  )--%>
                            </td>
                            <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "model")%> </td>
                            <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "item_type_name")%> | <%# DataBinder.Eval(Container.DataItem, "glass_color")%> </td>
                            <td style="text-align: center;"><%# DataBinder.Eval(Container.DataItem, "item_height")%> * <%# DataBinder.Eval(Container.DataItem, "item_width")%> </td>
                            <td style="text-align: center;"><%# DataBinder.Eval(Container.DataItem, "actual_sqm")%>   </td>
                            <td style="text-align: center;"><%# DataBinder.Eval(Container.DataItem, "thickness")%>   </td>
                            <td style="text-align: center;"><%# DataBinder.Eval(Container.DataItem, "perimeter")%>   </td>
                            <td style="text-align: center;"><%# DataBinder.Eval(Container.DataItem, "factory_ready_stock")%>   </td>
                            <td style="text-align: center;"><%# DataBinder.Eval(Container.DataItem, "priority")%>   </td>

                            <%--     <td>
                                        <asp:LinkButton ID="btnRun" runat="server" CommandName="run" ToolTip="Mark Running" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-sm btn-primary" Visible="false">Mark Running </asp:LinkButton>
                                       <asp:Label ID="lblStatus" Text='<%#Eval("IsRunning")%>' runat="server" Visible="false" />
                                        <asp:LinkButton ID="btnBook" runat="server" CommandName="book" ToolTip="click to Book" CommandArgument='<%# Eval("Id") %>' CssClass="text-primary text-center"><i class="fa fa-plus"></i> </asp:LinkButton>fa fa-industry
                                    </td>--%>
                            <td class="text-center">
                                <div class="btn-group btn-group-xs">
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("item_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnProduction" runat="server" CommandName="production" CommandArgument='<%# Eval("item_master_id")%>' CssClass="btn btn-xs btn-primary text-center" data-toggle="tooltip" data-placement="bottom" title="Click to production" data-original-title="Basic tooltp"><i class="fa fa-industry"></i></asp:LinkButton>
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
            <!-- END All Orders Content -->


            <asp:HiddenField ID="hdfdItemId" runat="server" />

        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
