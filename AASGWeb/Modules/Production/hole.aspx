<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="hole.aspx.cs" Inherits="AASGWeb.Modules.Production.hole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
         function scrollToLocation(Location) {
             $('html, body').animate({
                 scrollTop: ($("" + Location + "").offset().top - 10)
             }, 1000);
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
        <ul class="breadcrumb breadcrumb-top">
            <li>Forms</li>
            <li><a href="#">General</a></li>
        </ul>
        <!-- END Forms General Header -->

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
                                                            <option value="Hole" selected>Hole</option>
                                                            
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

                                                            <option value="Hole">Hole</option>

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

        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <span data-toggle="tooltip" title="Add Pending" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" onclick="$('#modal-pending-item').modal('show');">Add Pending</span>
                            <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong></strong>Hole Department</h2>
                    </div>
                    <!-- END Normal Form Title -->
                    <asp:HiddenField ID="hdnItemId" runat="server" />
                    <!-- Normal Form Content -->
                 

                    <div class="row">


                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="size">Received</label>
                                <%--<input type="text" id="example-if-received" name="example-if-email" class="form-control" placeholder="" value="102" />--%>
                                <asp:TextBox ID="txtreceived" runat="server" CssClass="form-control" placeholder="" Text="0"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="size">Breakage</label>
                                
                                  <asp:TextBox ID="txtbreakage" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="" MaxLength="3" OnTextChanged="txtbreakage_TextChanged"></asp:TextBox>
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
                                                <asp:TextBox ID="txtBreakagePcsNumber" runat="server" Text='<%#Eval("PcsNo")%>' CssClass="form-control text-center" MaxLength="3"></asp:TextBox>
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
                                                <asp:TextBox ID="txtRejectPcsNumber" runat="server" Text='<%#Eval("PcsNo")%>' CssClass="form-control text-center" MaxLength="3"></asp:TextBox>
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
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" Rows="2" TextMode="MultiLine" placeholder="" MaxLength="250"></asp:TextBox> </div>

                            </div>
                         </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                               
                                 <asp:Button ID="btnResetData" runat="server" Text="Reset" class="btn btn-sm btn-warning" Visible="false" />
                                <%--<asp:Button ID="btnUpdate" runat="server" Text="Submit" class="btn btn-sm btn-success" Visible="true" OnClick="btnUpdate_Click" />--%>

                                 <asp:LinkButton ID="btnUpdateData" runat="server" Text="Submit" Visible="true" OnClick="btnUpdateData_Click" CssClass="btn btn-sm btn-primary">Submit</asp:LinkButton>


                            </div>
                        </div>

                    </div>

                </div>
            </div>


        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
