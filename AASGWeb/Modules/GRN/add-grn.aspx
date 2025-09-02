<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-grn.aspx.cs" Inherits="AASGWeb.Modules.GRN.add_grn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
      <script type="text/javascript">


        $(document).ready(function () {
            
         
          });
        //  function calculate(th) {
        //       alert('Start 1');
        //      var bid = this.id; // button ID 
        //      var trid = $(this).closest('tr').attr('id'); // table row ID 

        //      alert(trid);
        //    //  $("#ContentPlaceHolder1_txtReceivedQuantity").keypress(function (obj) {
        //    //      alert('Start');
        //    //      //Get the selected radiobutton value
        //    //      var type = $(this).text();
        //    //      alert(type);
        //    //    //check if value selected is equal to Yes
        //    //   $(this).closest(".container").find(".txtReceivedQuantity").prop("disabled", false);
        //    //    //if (type == "Yes") {
        //    //    //    //find the textbox control based on selected radiobutton control
        //    //    //    //Use the props to enable and disable the textbox control
                   
        //    //    //}
        //    //    //else
        //    //    //    $(this).closest(".container").find(".txtbox").prop("disabled", true);
        //    //});

        //      //var allOtherTextBoxes = $("input[id*='txtReceivedQuantity']");
        //      //alert(allOtherTextBoxes);
        //      //var bid = $(this).closest('td').find('form-control');
        //      //alert(bid);
             
        //      //var bid3 = $(this).closest('td').find('form-control');
        //      //alert(bid3);
             
               
        //}
    </script>
  

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
                        <h2><strong>GRN</strong>  Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <asp:HiddenField ID="hdfdPoNumber" runat="server" />
                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">PO Number <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPoNumber" runat="server" CssClass="form-control" onkeypress="return Number(event)" MinLength="1" MaxLength="6" placeholder="Enter PO Number"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4 ">
                            <asp:LinkButton ID="btnSearch" runat="server" Text="Search" OnClientClick="return validateGRNSearchinfo();" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-success btn-margin">Search</asp:LinkButton>
                        </div>



                    </div>

                    <div class="row" runat="server" id="divSupplierDetail_first" visible="false">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">Supplier Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtSupplierName" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Supplier Name"></asp:TextBox>

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
                                <label for="example-nf-password">Supplier Address</label>
                                <asp:TextBox ID="txtSupplierAddress" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Supplier Address"></asp:TextBox>

                            </div>
                        </div>

                    </div>

                    <div class="row" runat="server" id="divSupplierDetail_second" visible="false">

                        <div class="col-md-4">
                            <div class="form-group">

                                <label for="example-nf-password">Email <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtEmail" runat="server" Enabled="false" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-password">GST <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtGst" runat="server" CssClass="form-control" Enabled="false" placeholder="Enter GST Number"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">

                                <label for="example-nf-password">Invoice Number <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="form-control" onkeypress="return character_and_Number(event)"  placeholder="Enter Invoice Number"></asp:TextBox>

                            </div>
                        </div>
                    </div>

                    <div class="row" runat="server" id="divPurchaseItemList" visible="false">
                        <div class="col-md-12">
                            <asp:Repeater ID="rptrPurchaseOrderItemsList" runat="server" OnItemCommand="rptrPurchaseOrderItemsList_ItemCommand" OnItemDataBound="rptrPurchaseOrderItemsList_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>

                                                <th class="text-center visible-lg">Item ID</th>
                                                <th class="text-center visible-lg">Item Name</th>
                                                <th class="text-center hidden-xs">Actual Quantity</th>
                                                <th class="text-center hidden-xs">Item Quantity</th>
                                                <th class="text-center hidden-xs" style="width: 20%;">Received Quantity</th>
                                                <th class="text-center">Remarks</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>

                                        <td class="visible-lg text-center">
                                            <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="visible-lg text-center">
                                            <asp:Label ID="lblItemName" Text='<%#Eval("purchase_item_name")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="hidden-xs text-center">
                                            <asp:Label ID="lblActualQuantity" Text='<%#Eval("purchase_item_quantity")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="hidden-xs text-center">
                                            <asp:Label ID="lblItemQuantity" Text='<%#Eval("purchase_item_quantity")%>' runat="server"></asp:Label>
                                        </td>

                                        <td class="hidden-xs text-center">
                                            <asp:TextBox ID="txtReceivedQuantity" runat="server" CssClass="form-control text-center" onkeypress="return Number(event)" placeholder="0" onkeyup="return calculate(this);"></asp:TextBox>
                                        </td>
                                        <td class="hidden-xs text-center">
                                            <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" placeholder="Enter remarks"></asp:TextBox>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="2" class="text-right text-uppercase"><strong>Total Items:</strong></td>
                                        <td class="text-center"><strong>
                                           
                                            <asp:Label ID="lblTotalActualQuantity" runat="server"></asp:Label>
                                        </strong></td>
                                        <td class="text-center"><strong>
                                            
                                             <asp:Label ID="lblTotalItemQuantity" runat="server"></asp:Label>

                                        </strong></td>
                                    </tr>

                                    </table>         
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="hdfditemId" runat="server" />
                        </div>

                    </div>


                    <div class="row" runat="server" id="divActionButtons" visible="false">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Update Purchase" Visible="false" OnClick="btnUpdate_Click" CssClass="btn btn-sm btn-success">Update Ledger</asp:LinkButton>
                                <asp:LinkButton ID="btnSubmit" runat="server" Text="Add Purchase" OnClientClick="return validateGRNSubmitinfo();" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-primary">Add Ledger</asp:LinkButton>

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
