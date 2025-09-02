<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="add-customer-request.aspx.cs" Inherits="AASGWeb.Modules.Xp_Master.add_customer_request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">


        $(document).ready(function () {

        
<%--
             $('#<%=txtTotalPaid.ClientID %>').keyup("change", function () {
                //Get DropDownlist selected item index
                 _totalPaidAmount = $(this).val();
                alert(_totalPaidAmount);
                

            });--%>

        });
    </script>

   <style>

       .btn-xs, .btn-group-xs>.btn {
    padding: 0px 5px;
    font-size: 8px !important;
    line-height: 1.6;
    border-radius: 3px;
}

 .table thead tr th
    {
    padding:5px 0;
    }
 .table tbody tr td
 {
      padding:3px 0;
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
        <ul class="breadcrumb breadcrumb-top">
            <li>Forms</li>
            <li><a href="#">General</a></li>
        </ul>
        <!-- END Forms General Header -->

        <!-- Normal Form Block -->
        <div class="block full">
            <!-- Normal Form Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                <%--    <a href="#" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Purchases </a>--%>
                </div>
                <h2><strong>Customer Request</strong>  Master</h2>
            </div>
            <!-- END Normal Form Title -->

            <!-- Normal Form Content -->

            

            <div class="row">
                
                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password"> Select Item <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlItemList" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Item ..">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Item Brand <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" placeholder="Enter Quantity"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Item Quantity <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtItemQuantity" runat="server" CssClass="form-control" placeholder="Enter Quantity"></asp:TextBox>

                    </div>
                </div>
               

            </div>

            <div class="row">

                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:LinkButton ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CssClass="btn btn-sm btn-primary">Add Item </asp:LinkButton>

                    </div>
                </div>

            </div>


            <div class="row">
                <div class="col-md-12">
                    <asp:Repeater ID="rptrPurchaseItems" runat="server" Visible="false" OnItemCommand="rptrPurchaseItems_ItemCommand" OnItemDataBound="rptrPurchaseItems_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                       
                                        <th class="text-center visible-lg">Item ID</th>
                                        <th class="text-center visible-lg">Item Name</th>
                                        <th class="text-center hidden-xs">Item Quantity</th>
                                       
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>    </td>


                                
                                 <td class="visible-lg text-center">
                                    <asp:Label ID="lblItemId" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblItemName" Text='<%#Eval("purchase_item_name")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="hidden-xs text-center">
                                    <asp:Label ID="lblItemQuantity" Text='<%#Eval("purchase_item_quantity")%>' runat="server"></asp:Label>
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
                    <asp:HiddenField ID="hdfditemId" runat="server" />
                </div>

            </div>

          

            <div class="row">

                <div class="col-md-12">
                    <div class="form-group">
                        <label for="example-nf-password">Remarks </label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Enter Remarks"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset"  />
                        <asp:LinkButton ID="btnUpdate" runat="server" Text="Update Purchase" Visible="false" OnClick="btnUpdate_Click" CssClass="btn btn-sm btn-success">Update Purchase</asp:LinkButton>
                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Add Purchase" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-primary">Add Purchase</asp:LinkButton>

                    </div>
                </div>


            </div>

            <!-- END Normal Form Content -->
        </div>
        <!-- END Normal Form Block -->




        <!-- END All Role Block -->
    </div>
    <!-- END Page Content -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
