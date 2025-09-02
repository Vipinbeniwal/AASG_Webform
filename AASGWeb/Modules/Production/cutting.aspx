<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="cutting.aspx.cs" Inherits="AASGWeb.Modules.Production.cutting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
     <script type="text/javascript">
         function scrollToLocation(Location) {
             $('html, body').animate({
                 scrollTop: ($("" + Location + "").offset().top - 10)
             }, 1500);
         }
     </script>

    <style>
        .btn-xs, .btn-group-xs > .btn {
            padding: 0px 5px;
            font-size: 8px !important;
            line-height: 1.6;
            border-radius: 3px;
        }

        .table thead tr th {
            padding: 5px 0;
        }

        .table tbody tr td {
            padding: 3px 0;
        }
    </style>
    <%--function showbrokenrptr() {
            if ($('#txtbroken').val().length == 1) {
                if ($('#txtbroken').val() == "0") {

                    
                }
                else {
                    /*alert('done');*/
                }
                
                return false;
            } else {
                $('#txtbroken').focus();

            }
            return true;
        }--%>
       

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
        <%--<ul class="breadcrumb breadcrumb-top">
            <li>Forms</li>
            <li><a href="#">General</a></li>
        </ul>--%>
        <!-- END Forms General Header -->
        <asp:HiddenField ID="hdnItemId" runat="server" />
        <div id="modal-content">

            <!-- User Settings, modal which opens from Settings link (found in top right user menu) and the Cog link (found in sidebar user info) -->
            <div id="modal-pending-item" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header text-center">
                            <h2 class="modal-title"><i class="fa fa-th-list"></i>Pending Item Master</h2>
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
                                                <h2><strong>Add</strong> Pending Item Quantity</h2>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Department </label>
                                                        <select id="example-department2" name="example-chosen" class="select-chosen" data-placeholder="Choose a Department" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Cutting" selected>Cutting</option>
                                                            
                                                        </select>

                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Pending Quantity </label>
                                                        <input type="email" id="example-if-amount" name="example-if-email" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Current Quantity</label>
                                                        <input type="email" id="example-if-refrence" name="example-if-email" class="form-control" placeholder="" value="102">
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Total </label>
                                                        <input type="email" id="example-if-total" name="example-if-email" class="form-control" placeholder="">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions text-right">
                                                        <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">Close</button>
                                                        <button type="submit" class="btn btn-sm btn-primary">Submit</button>

                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>

                                </div>


                            </div>
                        </div>
                        <!-- END Modal Body -->
                    </div>
                </div>
            </div>
            <!-- END User Settings -->

            <div id="modal-item-broken" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- Modal Header -->
                        <div class="modal-header text-center">
                            <h2 class="modal-title"><i class="fa fa-th-list"></i>Broken Item Master</h2>
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
                                                <h2><strong>Add</strong>  Broken Item</h2>
                                            </div>

                                            <div class="row">

                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Department </label>
                                                        <select id="example-department" name="example-chosen" class="select-chosen" data-placeholder="Department" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->

                                                            <option value="Cutting">Cutting</option>

                                                        </select>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Pcs Number </label>
                                                        <select id="example-pcsnumber" name="example-chosen" class="select-chosen" data-placeholder="Pcs Number" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Pcs 1">Pcs 1</option>
                                                            <option value="Pcs 2">Pcs 2</option>
                                                            <option value="Pcs 3">Pcs 3</option>
                                                            <option value="Pcs 4">Pcs 4</option>
                                                            <option value="Pcs 5">Pcs 5</option>


                                                        </select>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Select Type </label>
                                                        <select id="example-type" name="example-chosen" class="select-chosen" data-placeholder="Choose a Type" style="width: 250px;">
                                                            <option></option>
                                                            <!-- Required for data-placeholder attribute to work with Chosen plugin -->
                                                            <option value="Broken">Broken</option>
                                                            <option value="Reject">Reject</option>

                                                        </select>

                                                    </div>
                                                </div>

                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="example-nf-email">Reason </label>
                                                        <input type="email" id="example-if-remarks" name="example-if-email" class="form-control" placeholder="">
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group form-actions text-right">
                                                        <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">Close</button>
                                                        <button type="submit" class="btn btn-sm btn-primary">Submit</button>

                                                    </div>
                                                </div>

                                            </div>

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

        <!-- Customer Addresses Block -->
        <div class="block">
            <!-- Customer Addresses Title -->
            <div class="block-title">
                <h2><%--<i class="fa fa-building-o"></i>--%><strong>Cutting </strong> Department</h2>
            </div>
            <!-- END Customer Addresses Title -->

            <!-- Customer Addresses Content -->
            <div class="row" hidden="hidden">
                <div class="col-lg-3">
                    <!-- Billing Address Block -->
                    <div class="block">
                        <!-- Billing Address Title -->
                        <div class="block-title">
                            <h2>Item Details</h2>
                        </div>
                        <!-- END Billing Address Title -->

                        <!-- Billing Address Content -->

                        <div class="row" >
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="brand">Item Name <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtItemName" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="model">Thickness <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtthickness" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="description">Item Height</label>
                                    <asp:TextBox ID="txtItemsheetSize" runat="server" class="form-control" placeholder="" Text="" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtItemHeight" runat="server" class="form-control" onkeypress="return Number(event)" MaxLength="5" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="description">Item Width</label>
                                    <asp:TextBox ID="txtItemWidth" runat="server" class="form-control" onkeypress="return Number(event)" MaxLength="5" placeholder=""></asp:TextBox>
                                </div>
                            </div>


                        </div>

                        <!-- END Billing Address Content -->
                    </div>
                    <!-- END Billing Address Block -->
                </div>
                <div class="col-lg-3" hidden="hidden">
                    <!-- Billing Address Block -->
                    <div class="block">
                        <!-- Billing Address Title -->
                        <div class="block-title">
                            <h2>Sheets Details</h2>
                        </div>
                        <!-- END Billing Address Title -->

                        <!-- Billing Address Content -->

                        <div class="row">


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="description">Sheet Height</label>
                                    <asp:TextBox ID="txtSheetSize" runat="server" class="form-control" Visible="false" placeholder="" Text=""></asp:TextBox>
                                    <asp:TextBox ID="txtSheetHeight" runat="server" class="form-control" onkeypress="return Number(event)" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Sheets Width</label>
                                    <asp:TextBox ID="txtSheetWidth" runat="server" class="form-control" onkeypress="return Number(event)" placeholder=""></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Sheets Issued</label>
                                    <asp:TextBox ID="txtSheetIssued" runat="server" class="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="" OnTextChanged="txtSheetIssued_TextChanged"></asp:TextBox>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Sheets Received</label>
                                    <asp:TextBox ID="txtSheetReceived" runat="server" class="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder=""></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">

                                    <label for="size">Target Pcs/Sheet</label>
                                    <asp:TextBox ID="txtSheetIssuedTargetPcs" runat="server" class="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="" OnTextChanged="txtSheetIssuedTargetPcs_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="actualsqm">Actual Pcs</label>
                                    <asp:TextBox ID="txtSheetIssuedActualPcs" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <!-- END Billing Address Content -->
                    </div>
                    <!-- END Billing Address Block -->
                </div>
                <div class="col-lg-3" hidden="hidden">
                    <!-- Shipping Address Block -->
                    <div class="block">
                        <!-- Shipping Address Title -->
                        <div class="block-title">
                            <h2>Broken Sheet Details</h2>
                        </div>
                        <!-- END Shipping Address Title -->

                        <!-- Shipping Address Content -->
                        <div class="row">

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="size">Broken sheets in crate</label>
                                    <asp:TextBox ID="txtBrokenSheetInCreate" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Total Sheets in Crate</label>
                                    <asp:TextBox ID="txtNoofSheet" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="actualsqm">Pcs Cut From sheet</label>
                                    <asp:TextBox ID="txtPcsCutFromSheet" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="actualsqm">Left Draft Size</label>
                                    <asp:TextBox ID="txtLeftOverSize" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="actualsqm">Height</label>
                                    <asp:TextBox ID="txtleftOverDraftHeight" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="actualsqm">Width</label>
                                    <asp:TextBox ID="txtleftOverDraftWidth" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <!-- END Shipping Address Content -->
                    </div>
                    <!-- END Shipping Address Block -->
                </div>
                <div class="col-lg-3" hidden="hidden">
                    <!-- Shipping Address Block -->
                    <div class="block">
                        <!-- Shipping Address Title -->
                        <div class="block-title">
                            <h2>Reject Sheet Details</h2>
                        </div>
                        <!-- END Shipping Address Title -->

                        <!-- Shipping Address Content -->
                        <div class="row">

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="size">Pcs. From Rejection</label>
                                    <asp:TextBox ID="txtPcsFromRejection" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" AutoPostBack="true" OnTextChanged="txtPcsFromRejection_TextChanged" MaxLength="3" minLength="0" Text=""></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="actualsqm">Actual Pcs</label>
                                    <asp:TextBox ID="txtActualPcsFromRejection" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <!-- END Shipping Address Content -->
                    </div>
                    <!-- END Shipping Address Block -->
                </div>
            </div>
            <div class="row" hidden="hidden">
                <div class="col-lg-6">
                    <!-- Shipping Address Block -->
                    <div class="block">
                        <!-- Shipping Address Title -->
                        <div class="block-title">
                            <h2>Issued Draft Sheet Details</h2>
                        </div>
                        <!-- END Shipping Address Title -->

                        <!-- Shipping Address Content -->
                        <div class="row">

                            <div class="col-md-12">

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Repeater ID="rptrDraftList" runat="server" OnItemCommand="rptrDraftList_ItemCommand" OnItemDataBound="rptrDraftList_ItemDataBound">
                                            <HeaderTemplate>
                                                <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center">Draft H/W</th>
                                                            <th class="text-center">Draft Issued Quantity</th>
                                                            <th class="text-center">Target Pcs/Draft</th>
                                                            <th class="text-center">Draft Actual Pcs</th>

                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>

                                                    <td class="text-center">
                                                         <asp:Label ID="lblDisplayItemNameforDraftInCutting"  runat="server" Visible="true"> </asp:Label>
                                                        <asp:Label ID="lblOnFloorItemName" Text='<%#Eval("items_name")%>' runat="server"> </asp:Label>
                                                    </td>

                                                    <td class="text-center">
                                                        <asp:Label ID="lblOnFloorSheetIssue" Text='<%#Eval("broken_sheet_quantity")%>' runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:Label ID="lblOnFloorQuantityPerSheet" Text='<%#Eval("per_broken_sheet_quantity")%>' runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-center">
                                                        <asp:Label ID="lblOnFloorItemPcsTotalExpected" Text='<%#Eval("per_broken_sheet_quantity_expected")%>' runat="server"></asp:Label>
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
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Target Pcs/Draft</label>
                                    <asp:TextBox ID="txtDraftTargetPcs" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" AutoPostBack="true" OnTextChanged="txtDraftTargetPcs_TextChanged" Text="" MaxLength="3" minLength="0"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="actualsqm">Draft Actual Pcs</label>
                                    <asp:TextBox ID="txtDraftActualPcs" runat="server" class="form-control" placeholder="" Text=""></asp:TextBox>

                                </div>
                            </div>

                        </div>

                       




                        <!-- END Shipping Address Content -->
                    </div>
                    <!-- END Shipping Address Block -->
                </div>
                <div class="col-lg-6">
                    <!-- Shipping Address Block -->
                    <div class="block">
                        <!-- Shipping Address Title -->
                        <div class="block-title">
                            <h2>Kept On The Floor Items Details</h2>
                        </div>
                        <!-- END Shipping Address Title -->

                        <!-- Shipping Address Content -->
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Kept on Floor</label>
                                    <asp:TextBox ID="txtKeptOnFloorItemStatus" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                    <asp:TextBox ID="txtKeptOnFloorItemMasterId" runat="server" class="form-control" Visible="false" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Kept On Floor Quantity</label>
                                    <asp:TextBox ID="txtKeptOnFloorPcsQuantity" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Kept On Floor Received</label>
                                    <asp:TextBox ID="txtKeptOnFloorPcsReceived" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="" AutoPostBack="true" OnTextChanged="txtKeptOnFloorPcsReceived_TextChanged" Text="" MaxLength="3" minLength="0"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="size">Total Pcs Transferred</label>
                                    <asp:TextBox ID="txtTotalPcsTransferred" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                </div>
                            </div>


                        </div>
                        <!-- END Shipping Address Content -->
                    </div>
                    <!-- END Shipping Address Block -->
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: left">
                        <asp:LinkButton ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-sm btn-warning">Reset</asp:LinkButton>
                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-primary">Get All Item Details</asp:LinkButton>

                    </div>
                </div>
            </div>
            <!-- END Customer Addresses Content -->

             <div class="row">


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="size">Received</label>
                                <asp:TextBox ID="txtreceived" runat="server" CssClass="form-control" placeholder="" Text=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="size">Breakage</label>
                                <asp:TextBox ID="txtbreakage" runat="server" CssClass="form-control"  onkeypress="return Number(event)" AutoPostBack="true" MaxLength="3" placeholder="" OnTextChanged="txtbreakage_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="size">Reject</label>
                                 <asp:TextBox ID="txtReject" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="" MaxLength="3" OnTextChanged="txtReject_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="actualsqm">Transferred</label>
                               <asp:TextBox ID="txtFinalTransferred" runat="server" CssClass="form-control" placeholder=""></asp:TextBox> </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="description">Signature</label>
                                
                                <asp:DropDownList ID="ddlSignature" runat="server" class="form-control">
                                    <asp:ListItem Value="1" Selected="True">Supervisor</asp:ListItem>
                                    <asp:ListItem Value="2">In-charge</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                     <!-- Breakage/Reject Repeater Start -->

                    <div class="row">
                        <div class="col-md-6">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptrBreakagePcsItemList" runat="server" Visible="false" OnItemCommand="rptrBreakagePcsItemList_ItemCommand" OnItemDataBound="rptrBreakagePcsItemList_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                            <thead>
                                                <tr>
                                                    <th class="text-center" style="width: 150px;">Pcs No</th>
                                                    <th class="text-center">Broken Reason</th>
                                                    
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>

                                            <td class=" text-center">
                                                <asp:Label ID="lblBreakagePcsNo" Text='<%#Eval("PcsNo")%>' runat="server"> </asp:Label>
                                                <asp:TextBox ID="txtBreakagePcsNumber" runat="server" Text='<%#Eval("PcsNo")%>' CssClass="form-control text-center" MaxLength="3"  ></asp:TextBox>
                                            </td>

                                            <td class=" text-center">
                                                
                                                <asp:Label ID="lblBreakageReason" Text='<%#Eval("Reason")%>' runat="server" Visible="false"> </asp:Label>
                                                <asp:DropDownList ID="ddlBreakageReason" runat="server" class="form-control">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="Scratch" Text="Scratch"></asp:ListItem>
                                                    <asp:ListItem Value="Chipping" Text="Chipping"></asp:ListItem>
                                                    <asp:ListItem Value="Paint Issue" Text="Paint Issue"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>         
                                    </FooterTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptrRejectPcsItemList" runat="server" Visible="false" OnItemCommand="rptrRejectPcsItemList_ItemCommand" OnItemDataBound="rptrRejectPcsItemList_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                            <thead>
                                                <tr>
                                                    <th class="text-center" style="width: 150px;">Pcs No</th>
                                                    <th class="text-center">Reject Reason</th>
                                                    
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>

                                            <td class=" text-center">
                                                <asp:Label ID="lblRejectPcsNo" Text='<%#Eval("PcsNo")%>' runat="server"> </asp:Label>
                                                <asp:TextBox ID="txtRejectPcsNumber" runat="server" Text='<%#Eval("PcsNo")%>'  CssClass="form-control text-center" MaxLength="3" ></asp:TextBox>
                                            </td>

                                            <td class=" text-center">
                                                <asp:Label ID="lblRejectReason" Text='<%#Eval("Reason")%>' runat="server" Visible="false"> </asp:Label>
                                                <asp:DropDownList ID="ddlRejectReason" runat="server" class="form-control">
                                                   <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="Scratch" Text="Scratch"></asp:ListItem>
                                                    <asp:ListItem Value="Chipping" Text="Chipping"></asp:ListItem>
                                                    <asp:ListItem Value="Paint Issue" Text="Paint Issue"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>         
                                    </FooterTemplate>
                                </asp:Repeater>

                            </div>
                        </div>

                    </div>

                    <!--- Breakage/Reject Repeater End -->

                     <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="description">Remarks</label>
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder=""  Rows="2" TextMode="MultiLine" ></asp:TextBox> </div>

                            </div>
                         </div>


                    
                      <div class="row" runat="server" id="divOnFloorOtherItemList" visible="false">
                        <div class="col-md-12">
                            <asp:Repeater ID="rptrOnFloorOtherItemsList" runat="server" OnItemCommand="rptrOnFloorOtherItemsList_ItemCommand" OnItemDataBound="rptrOnFloorOtherItemsList_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>

                                                <th class="text-center">Item ID</th>
                                                <th class="text-center">Item Name</th>
                                                <th class="text-center">Sheet Issue</th>
                                                <th class="text-center">Qty Per Sheet</th>
                                                <th class="text-center">Total Expected</th>
                                                <th class="text-center" style="width: 10%;">Total Produce</th>
                                                <th class="text-center" style="width: 40%;">Remark</th>
                                                <th class="text-center">Action</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>

                                        <td class="text-center">
                                            <asp:Label ID="lblOnFloorItemMasterId" Text='<%#Eval("on_floor_item_master_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblOnFlooritemsid" Text='<%#Eval("on_floor_items_master_id")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblOnFloorItemName" Text='<%#Eval("items_name")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblOnFloorSheetIssue" Text='<%#Eval("broken_sheet_quantity")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblOnFloorQuantityPerSheet" Text='<%#Eval("per_broken_sheet_quantity")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblOnFloorItemPcsTotalExpected" Text='<%#Eval("per_broken_sheet_quantity_expected")%>' runat="server"></asp:Label>
                                        </td>

                                        <td class="text-center">
                                            <asp:Label ID="lblOnFloorItemPcsProduce" Text='<%#Eval("items_pcs_quantity")%>' runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtOnFloorItemPcsProduce" runat="server" CssClass="form-control text-center" Text='<%#Eval("items_pcs_quantity")%>'  onkeypress="return Number(event)" placeholder="0"  MaxLength="3" minLength="0"></asp:TextBox>
                                        </td>
                                        <td class="text-center">
                                             <asp:Label ID="lblOnFloorItemRemark" Text='<%#Eval("remarks")%>' runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtOnFloorItemRemark" runat="server" CssClass="form-control text-center" onkeypress="return character_and_Number(event)" placeholder="Enter Remark" MaxLength="100" ></asp:TextBox>
                                        </td>

                                        <td class="text-center btn-group-sm">
                                            <asp:Label ID="lblOnFloorItemPcsStatus"  runat="server" Visible="false" CssClass="form-control text-center" Text="Updated"></asp:Label>
                                            <asp:LinkButton ID="btnUpdateOnFloorItemPcs" runat="server" CommandName="update" CommandArgument='<%# Eval("on_floor_item_master_id")%>' Visible="true" CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to Update" data-original-title="Basic tooltp">Update</asp:LinkButton>
                                        </td>
                                       
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    
                                    </table>         
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="hdfdOnFlooritemId" runat="server" />
                        </div>

                    </div>



                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <%--<button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                <button type="submit" class="btn btn-sm btn-primary">Submit</button>--%>

                                <asp:Button ID="btnResetData" runat="server" Text="Reset" class="btn btn-sm btn-warning" Visible="false" OnClick="btnResetData_Click"  />
                                <%--<asp:Button ID="btnUpdate" runat="server" Text="Submit" class="btn btn-sm btn-success" Visible="true" OnClick="btnUpdate_Click" />--%>

                                 <asp:LinkButton ID="btnUpdateData" runat="server" Text="Submit" Visible="true" OnClick="btnUpdateData_Click" CssClass="btn btn-sm btn-primary">Submit</asp:LinkButton>



                            </div>
                        </div>

                    </div>

        </div>
        <!-- END Customer Addresses Block -->

        
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
