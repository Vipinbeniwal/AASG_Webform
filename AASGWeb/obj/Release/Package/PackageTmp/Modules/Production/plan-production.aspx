<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="plan-production.aspx.cs" Inherits="AASGWeb.Modules.Production.plan_production" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>AASG Admin</title>

    <%--<meta name="description" content="ProUI is a Responsive Bootstrap Admin Template created by pixelcave and published on Themeforest.">
    <meta name="author" content="pixelcave">--%>
    <meta name="robots" content="noindex, nofollow" />
    <meta name="viewport" content="width=device-width,initial-scale=1.0,user-scalable=0" />

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="/Content/img/favicon.png" />
    <!-- END Icons -->
    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css" />
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="/Content/css/plugins.css" />

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="/Content/css/main.css" />

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="/Content/css/themes.css" />
    <!-- END Stylesheets -->
    <script src="/Content/js/vendor/modernizr.min.js"></script>
    <!-- jQuery, Bootstrap.js, jQuery plugins and Custom JS code -->
    <script src="/Content/js/vendor/jquery.min.js"></script>
    <script src="/Content/js/vendor/bootstrap.min.js"></script>
    <script src="/Content/js/plugins.js"></script>
    <script src="/Content/js/app.js"></script>

    <script src="/Custom/toast.js"></script>
    <script src="/Custom/Validate.js"></script>
    <script src="/Content/js/pages/tablesDatatables.js"></script>

    <style>
        .btn-xs, .btn-group-xs > .btn {
            padding: 0px 5px;
            font-size: 8px !important;
            line-height: 1.6;
            border-radius: 3px;
        }

        .btn-sm, .btn-group-sm > .btn {
            padding: 5px 6px !important;
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
        }

        .table thead tr th {
            padding: 5px 0;
        }

        .table tbody tr td {
            padding: 3px 0;
        }

        .zoom-in-out-box {
            background: #6ad2eb;
            border-color: #1bbae1;
            color: #ffffff;
            text-align: center;
            box-shadow: 0 0 0 rgba(252, 6, 10, 0.863);
            animation: pulse 2s infinite;
            border-radius: 0.25em;
            padding: 1px 4px;
        }

        .drawingimage {
            width: 50px;
            height: 50px;
        }

        .CuttingDrawingimage {
            width: 700px;
            height: 700px;
        }

        .drawingimage:hover {
            width: 700px;
            height: 500px;
            margin-bottom: 50px;
        }

        .SelectedDrawing {
            font-size: 20px;
        }

        .ErrorMessageFont {
            font-size: 16px;
        }

        @media screen and (min-width: 991px) {
            .modal-lg {
                width: 80%;
            }
        }
    </style>

    <script>
        function showBrokenCratetModal() {
            $("#modal-crate-item").modal('show');

        }
        function showItemAcknowledgeModal() {
            $("#modal-create-item-acknowledge").modal('show');

        }

        function showItemAcknowledgeNewModal() {
            $("#modal-crate-acknowledge").modal('show');

        }


    </script>
     <script type="text/javascript">
         //function isNumberKey(txt, evt) {
         //    var charCode = (evt.which) ? evt.which : evt.keyCode;
         //    if (charCode == 46) {
         //        //Check if the text already contains the . character
         //        if (txt.value.indexOf('.') === -1) {
         //            return true;
         //        } else {
         //            return false;
         //        }
         //    } else {
         //        if (charCode > 31 &&
         //            (charCode < 48 || charCode > 57))
         //            return false;
         //    }
         //    return true;
         //}

         $(document).ready(function () {

             // Disable Some Text Fileds 


             $("#ddlLeftoverStatus_chosen").attr('disabled', true);



             // DropDown Diamond Yes or No Code 
             $('#<%=ddlLeftoverStatus.ClientID %>').on("change", function () {

                 if ($(this).find("option:selected").text() == "Yes") {

                     $("#ddlLeftoverStatus_chosen").removeAttr('disabled');
                     $("#txtLeftOverSizeHeight").removeAttr('disabled');
                     $("#txtLeftOverSizeWidthfromAcknowledge").removeAttr('disabled');
                     $("#txtNoofDraftSheetLeft").removeAttr('disabled');
                 }
                 else {

                     $("#ddlLeftoverStatus_chosen").attr('disabled', true);
                     $("#txtLeftOverSizeHeight").attr('disabled', true);
                     $("#txtLeftOverSizeWidthfromAcknowledge").attr('disabled', true);
                     $("#txtNoofDraftSheetLeft").attr('disabled', true);
                 }

             });


             // DropDown Diamond Yes or No Code for Cutting Time
             $('#<%=ddlDraftfromBreakageSheet.ClientID %>').on("change", function () {

                 if ($(this).find("option:selected").text() == "Yes") {

                     $("#ddlDraftfromBreakageSheet_chosen").removeAttr('disabled');
                     $("#txtLeftOverSizeLength").removeAttr('disabled');
                     $("#txtNoOfDraftSheetleftCuttingStart").removeAttr('disabled');
                     $("#txtLeftOverSizeWidth").removeAttr('disabled');

                 }
                 else {

                     $("#ddlDraftfromBreakageSheet_chosen").attr('disabled', true);
                     $("#txtLeftOverSizeLength").attr('disabled', true);
                     $("#txtNoOfDraftSheetleftCuttingStart").attr('disabled', true);
                     $("#txtLeftOverSizeWidth").attr('disabled', true);
                 }

             });



             // Enable remove After Bind Value from routings if Yes or No



             if ($('#<%=ddlLeftoverStatus.ClientID %>').find("option:selected").text() == "Yes") {
                 $("#txtLeftOverSizeHeight").removeAttr('disabled');
                 $("#txtLeftOverSizeWidthfromAcknowledge").removeAttr('disabled');
                 $("#txtNoofDraftSheetLeft").removeAttr('disabled');
             }
             else {
                 $("#txtLeftOverSizeHeight").attr('disabled', true);
                 $("#txtLeftOverSizeWidthfromAcknowledge").attr('disabled', true);
                 $("#txtNoofDraftSheetLeft").attr('disabled', true);
             }


             if ($('#<%=ddlDraftfromBreakageSheet.ClientID %>').find("option:selected").text() == "Yes") {
                 $("#txtLeftOverSizeLength").removeAttr('disabled');
                 $("#txtNoOfDraftSheetleftCuttingStart").removeAttr('disabled');
                 $("#txtLeftOverSizeWidth").removeAttr('disabled');
             }
             else {
                 $("#txtLeftOverSizeLength").attr('disabled', true);
                 $("#txtNoOfDraftSheetleftCuttingStart").attr('disabled', true);
                 $("#txtLeftOverSizeWidth").attr('disabled', true);
             }



         });
     </script>


</head>
<body>
    <form id="form1" runat="server">
        <!-- Page content -->
        <div id="page-content">
            <!-- Dashboard 2 Header -->
            <div class="content-header">
                <ul class="nav-horizontal text-center">
                    <li class="active">
                        <a href="/home"><i class="fa fa-arrow-circle-left"></i>Back</a>
                    </li>
                    <li class="">
                        <a href="/home"><i class="fa fa-home"></i>Home</a>
                    </li>
                    <li>
                        <a href="#"><i class="gi gi-charts"></i>Create Bill</a>
                    </li>
                    <li>
                        <a href="#"><i class="gi gi-briefcase"></i>Production</a>
                    </li>
                    <li>
                        <a href="#"><i class="gi gi-video_hd"></i>Returns</a>
                    </li>
                    <li>
                        <a href="/manage-sale-orders"><i class="gi gi-charts"></i>SaleOrders</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-cubes"></i>Accounts</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-pencil"></i>Challans</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-cogs"></i>Settings</a>
                    </li>
                </ul>
            </div>
            <!-- END Dashboard 2 Header -->
            <!-- END Dashboard 2 Header -->

            <div id="modal-content">

                <!-- User Settings, modal which opens from Settings link (found in top right user menu) and the Cog link (found in sidebar user info) -->
                <div id="modal-crate-item" class="modal fade" tabindex="0" role="dialog" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header text-center">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h2 class="modal-title"><i class="fa fa-th-list"></i>Cutting Department</h2>
                            </div>
                            <!-- END Modal Header -->

                            <!-- Modal Body -->
                            <asp:HiddenField ID="hdnProductionId" runat="server" />

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
                                                    
                                                    <h2><strong>Add</strong> Sheet Details</h2>
                                                </div>

                                                <div class="row">
                                                        <div class="col-md-6">

                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">Item Name</label>
                                                                    <asp:TextBox ID="txtCuttingItemNameWithColor" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">Thickness</label>
                                                                    <asp:TextBox ID="txtCuttingItemThickness" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">No of Sheets Issued</label>
                                                                    <asp:TextBox ID="txtNoofSheet" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text="" MaxLength="3"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                              <asp:ScriptManager ID="scriptmanagerforNoofSheet" runat="server">
                                    </asp:ScriptManager>
                                                             
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email"> OK Sheets Received In Crate</label>
                                                                    <asp:TextBox ID="txtSheetReceivedInCrate" runat="server" class="form-control" MaxLength="3" onkeypress="return Number(event)" AutoPostBack="true" OnTextChanged="txtSheetReceivedInCrate_TextChanged" placeholder="" Text=""></asp:TextBox>
                                                                </div>
                                                            </div>

                                                               

                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">Broken Sheets In Crate </label>
                                                                    <asp:TextBox ID="txtBrokenSheetInCreate" runat="server" class="form-control" onkeypress="return Number(event)" MaxLength="3" placeholder="" Text="" AutoPostBack="true" OnTextChanged="txtBrokenSheetInCreate_TextChanged"></asp:TextBox>

                                                                </div>
                                                            </div>

                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">Pcs Cut From Sheet</label>
                                                                    <asp:TextBox ID="txtPcsCutFromSheet" runat="server" class="form-control" onkeypress="return Number(event)" MaxLength="3" placeholder="" Text=""></asp:TextBox>

                                                                </div>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <div class="form-group" id="divDraftLeftOverStatus" runat="server">
                                                                    <label for="any Left Over">Any Left Over</label>
                                                                    <asp:DropDownList ID="ddlDraftfromBreakageSheet" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                                                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">

                                                                    <label for="example-nf-email">Left over Draft Length</label>
                                                                    <asp:TextBox ID="txtLeftOverSizeLength" runat="server" class="form-control" onkeypress="return isNumberKey(event)" placeholder="" Text="" MaxLength="4"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">Left over Draft Width</label>
                                                                    <asp:TextBox ID="txtLeftOverSizeWidth" runat="server" class="form-control" onkeypress="return isNumberKey(event)" placeholder="" Text="" MaxLength="4"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group">
                                                                    <label for="example-nf-email">No of Draft Sheet</label>
                                                                    <asp:TextBox ID="txtNoOfDraftSheetleftCuttingStart" runat="server" class="form-control" onkeypress="return isNumberKey(event)" placeholder="" Text="" MaxLength="3"></asp:TextBox>

                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-9">
                                                                    <div class="form-group">
                                                                        <asp:Label ID="lblCuttingConfirmError" runat="server" Visible="false" CssClass="text-danger" Style="float: left; margin-top: 5px; margin-right:10px; font-size:16px"> </asp:Label>
                                                                    </div>
                                                                    
                                                                </div>
                                                                <div class="col-md-3">
                                                                <div class="form-group form-actions" style="float: right";>
                                                                   <asp:LinkButton ID="BtnReset" runat="server" Text="Reset" OnClick="BtnReset_Click" CssClass="btn btn-default form-actions" Style="float: left; margin-top: 5px; margin-right:10px;">Reset </asp:LinkButton>
                                                                  <asp:LinkButton ID="btnAddBrokenCrate" runat="server" OnClientClick="return validateBrokenCrateinfo();" OnClick="btnAddBrokenCrate_Click" CssClass="btn btn-primary form-actions" Style="float: right; margin-top: 5px;">Add</asp:LinkButton>

                                                                </div>

                                                            </div>
                                                            </div>
                                                            

                                                            <div class="row" runat="server" id="divOnFloorOtherItemList" visible="true">
                                                                <div class="col-md-12">
                                                                    <asp:Repeater ID="rptrOnFloorOtherItemsList" runat="server" OnItemCommand="rptrOnFloorOtherItemsList_ItemCommand" OnItemDataBound="rptrOnFloorOtherItemsList_ItemDataBound">
                                                                        <HeaderTemplate>
                                                                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th class="text-center">Item Name</th>
                                                                                        <th class="text-center">Type</th>
                                                                                        <th class="text-center">Sheet Issue</th>
                                                                                        <th class="text-center">Qty Per Sheet</th>
                                                                                        <th class="text-center">Total Expected</th>
                                                                                       
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
                                                                                    <asp:Label ID="lblOnFloorItemType" Text='<%#Eval("items_type")%>' runat="server"> </asp:Label>
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
                                                                    <asp:HiddenField ID="hdfdOnFlooritemId" runat="server" />
                                                                </div>

                                                            </div>

                                                        </div>

                                                        <div class="col-md-6">
                                                        <div class="form-group text-center">

                                                            <asp:Image ID="lblCuttingDrawingImageUrl" runat="server" CssClass="img-fluid CuttingDrawingimage" alt="Drawing Image" />

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

                <div id="modal-create-item-acknowledge" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header text-center">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h2 class="modal-title"><i class="fa fa-th-list"></i>Cutting Department</h2>
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
                                                    <h2><strong>Add</strong> Item Sheet Details</h2>
                                                </div>

                                                <%--<div class="row">

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

                                            </div>--%>
                                                <div class="row">
                                                    <div class="col-md-10">
                                                        <!-- All Orders Block -->
                                                        <div class="block full">
                                                            <!-- All Orders Title -->
                                                            <div class="block-title">
                                                                <div class="block-options pull-right">
                                                                    <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                                                                </div>
                                                                <h2><strong>All</strong> Drawing List</h2>
                                                            </div>
                                                            <!-- END All Orders Title -->

                                                            <!-- All Orders Content -->

                                                            <!-- END All Orders Content -->
                                                        </div>
                                                        <!-- END All Orders Block -->
                                                    </div>

                                                    <div class="col-md-2">



                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label for="example-nf-email">Thickness</label>
                                                              <%--  <asp:TextBox ID="txtThickenss" runat="server" class="form-control" onkeypress="return character_and_Number(event)" placeholder="" Text=""></asp:TextBox>--%>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label for="example-nf-email">Sheet Height </label>
                                                                <asp:TextBox ID="txtSheetHeightoold" runat="server" class="form-control" onkeypress="return isNumberKey(event)" placeholder="" Text=""></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label for="example-nf-email">Sheet Width </label>
                                                                <asp:TextBox ID="txtSheetWidthold" runat="server" class="form-control" onkeypress="return isNumberKey(event)" placeholder="" Text=""></asp:TextBox>


                                                            </div>
                                                        </div>

                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label for="example-nf-email">No of sheets Issue </label>
                                                                <asp:TextBox ID="txtNoOfSheetIssuedByAcknowledge" runat="server" class="form-control" onkeypress="return Number(event)" placeholder="" Text=""></asp:TextBox>

                                                            </div>
                                                        </div>

                                                        <%--                                                        Filed Cut from This Place--%>
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


                <div id="modal-crate-acknowledge" class="modal fade" tabindex="0" role="dialog" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <!-- Modal Header -->
                            <div class="modal-header text-center">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h2 class="modal-title"><i class="fa fa-th-list"></i>Acknowledge Department</h2>
                            </div>
                            <!-- END Modal Header -->
                            <asp:HiddenField ID="hdnfAcknowledgeProductionId" runat="server" />
                            <asp:HiddenField ID="hdnfAcknowledgeProductionItemMasterId" runat="server" />
                            <asp:HiddenField ID="hdnfAcknowledgePlantName" runat="server" />

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
                                                        <strong class="text-primary">Ready Pcs On Floor : </strong>
                                                        <asp:Label ID="lblKeptonFloorPcs" runat="server" CssClass="btn btn-success"></asp:Label>
                                                        <asp:Label ID="lblKeptonFloorItemMasterId" runat="server" Visible="false" ></asp:Label>
                                                    </div>
                                                    <h2><strong>Add</strong> Acknowledge Details</h2>
                                                </div>

                                                <div class="row">

                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="example-nf-password">Item Name <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Item Name"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="example-nf-password">Thickness <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtThickness" runat="server" CssClass="form-control" onkeypress="return character_and_Number(event)" placeholder="Thickness"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="example-nf-password">Sheet Height <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtSheetHeight" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Sheet Height" MaxLength="5" minLength="3"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="example-nf-password">Sheet Width <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtSheetWidth" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Sheet Width" MaxLength="5" minLength="3"></asp:TextBox>

                                                        </div>
                                                    </div>

                                                   



                                                    <%-- <div class="row">

                                                        <div class="col-md-12">
                                                            <div class="form-group form-actions" style="float: right">
                                                                
                                                            </div>
                                                        </div>

                                                    </div>--%>

                                                   
                                                    
                                                </div>
                                                <div class="row">
                                                  
                                                     <asp:UpdatePanel ID="updatepannelforNoofSheet" runat="server">
                                        <ContentTemplate>
                                                     <div class="col-md-3">
                                                        <div class="form-group">
                                                            <label for="example-nf-password">No of Sheet Issue <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txtNoofSheetIssue" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" placeholder="No of Sheet Issue" OnTextChanged="txtNoofSheetIssue_TextChanged" MaxLength="3" minLength="1" ></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                           <label for="example-nf-password">Qty Per Sheet<span class="text-danger">*</span></label>
                                                             <asp:TextBox ID="txtQuantityPerSheet" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" OnTextChanged="txtQuantityPerSheet_TextChanged" placeholder="Qty Per Sheet" MaxLength="3" minLength="1"></asp:TextBox>

                                                        </div>
                                                    </div>
                                            <div class="col-md-3">
                                                        <div class="form-group">
                                                           <label for="example-nf-password">Total Exp <span class="text-danger">*</span></label>
                                                            <asp:TextBox ID="txttotalExpectation" runat="server" CssClass="form-control"  onkeypress="return Number(event)" placeholder="Total Exp"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    
                                             </ContentTemplate>

                                    </asp:UpdatePanel>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <div class="row">
                                                                <div class="col-md-12">

                                                                    <asp:LinkButton ID="btnAddItem" runat="server" Text="Add" Visible="true" OnClientClick="return validateAcknwoledgeinfo();" OnClick="btnAddItem_Click" CssClass="btn btn-primary form-actions" Style="margin-top: 22px;">Add</asp:LinkButton>
                                                                    <asp:LinkButton ID="btnShowMoreItemField" runat="server" Text="Add More" Visible="false" OnClick="btnShowMoreItemField_Click" CssClass="btn btn-primary form-actions" Style="margin-top: 22px;">Add More</asp:LinkButton>

                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>

                                                </div>

                                                 <div class="row" id="divMoreItemAdd" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label for="Type">Select Type</label>
                                                                <asp:DropDownList ID="ddlItemTypeforSearch" runat="server" CssClass="select-chosen" AutoPostBack="true" OnSelectedIndexChanged="ddlItemTypeforSearch_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                    <asp:ListItem Value="Item">Item</asp:ListItem>
                                                                    <asp:ListItem Value="Draft">Draft</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">

                                                                <label for="example-nf-password">Select Item <span class="text-danger">*</span></label>
                                                                <asp:DropDownList ID="ddlItemList" runat="server" CssClass="select-chosen" AutoPostBack="true" data-placeholder="Choose a Item .." OnSelectedIndexChanged="ddlItemList_SelectedIndexChanged">
                                                                    <asp:ListItem></asp:ListItem>

                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                     
                                                     <asp:UpdatePanel ID="UpdatePanelforAddMore" runat="server">
                                        <ContentTemplate>
                                                        <div class="col-md-4">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label for="example-nf-password">No of Draft Sheet <span class="text-danger">*</span></label>
                                                                        <asp:TextBox ID="txtNoofDraftSheetavialable" runat="server" CssClass="form-control"  onkeypress="return Number(event)" AutoPostBack="true" OnTextChanged="txtNoofDraftSheetavialable_TextChanged" placeholder="" MaxLength="3" minLength="1"></asp:TextBox>
                                                                        <asp:TextBox ID="txtDraftItemSQM" runat="server" CssClass="form-control"  Enabled="false" Visible="false" placeholder="" ></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <label for="example-nf-password">Qty Per Sheet <span class="text-danger">*</span></label>
                                                                        <asp:TextBox ID="txtItemQuantityPerSheetfromOther" runat="server" CssClass="form-control" onkeypress="return Number(event)" AutoPostBack="true" OnTextChanged="txtItemQuantityPerSheetfromOther_TextChanged" placeholder="Enter Qty Per Sheet" MaxLength="3" minLength="1"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label for="example-nf-password">Total Exp <span class="text-danger">*</span></label>
                                                                <asp:TextBox ID="txtTotalExpectationfromOther" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Total Exp"></asp:TextBox>

                                                            </div>
                                                        </div>

                                            </ContentTemplate>

                                    </asp:UpdatePanel>

                                                     <div class="col-md-1">
                                                            <div class="form-group">
                                                                <div class="row">
                                                                    <div class="col-md-12">
                                                                       <asp:LinkButton ID="btnAddMoreItem" runat="server" Text="Add" CssClass="btn btn-primary form-actions" OnClientClick="return validateOtherItemAndDraftinfo();" OnClick="btnAddMoreItem_Click" Style="margin-top:22px">Add</asp:LinkButton>

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
                                                                                    <th class="text-center">Item Type</th>
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
                                                                                <asp:Label ID="lblDisplayItemNameforDraft"  runat="server" Visible="true"> </asp:Label>
                                                                                <asp:Label ID="lblItemName" Text='<%#Eval("item_name")%>' runat="server"> </asp:Label>
                                                                                 
                                                                            </td>
                                                                             <td class="text-center">
                                                                                <asp:Label ID="lblItemType" Text='<%#Eval("item_type")%>' runat="server"> </asp:Label>
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
                                                            <asp:HiddenField ID="hdfdOtheritemId" runat="server" />
                                                        </div>

                                                    </div>


                                                    <div class="col-md-12">
                                                        <!-- All Orders Block -->
                                                        <div class="block full">
                                                            <!-- All Orders Title -->
                                                            <div class="block-title">
                                                                <div class="block-options pull-right">
                                                                    <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                                                                </div>
                                                                <h2><strong>All</strong> Drawing List</h2>
                                                            </div>
                                                            <!-- END All Orders Title -->

                                                            <!-- All Orders Content -->
                                                            <div class="table-responsive">
                                                                <asp:Repeater ID="rptrDrawingItemList" runat="server" OnItemCommand="rptrDrawingItemList_ItemCommand" OnItemDataBound="rptrDrawingItemList_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th class="text-center" style="width: 30px;">ID</th>
                                                                                    <th class="text-center" style="width: 100px;">Image</th>
                                                                                    <th class="text-center" style="width: 100px;">Name</th>
                                                                                    <th class="text-center" style="width: 100px;">Type</th>
                                                                                    <th class="text-center" style="width: 100px;">Alias</th>
                                                                                    <th class="text-center" style="width: 100px;">Status</th>
                                                                                    <th class="text-center">Description</th>

                                                                                </tr>
                                                                            </thead>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>

                                                                            <td class=" text-center">

                                                                                <asp:LinkButton ID="lnkBtnDrawingMasterId" runat="server" Text='<%#Eval("drawing_master_id")%>' CommandName="select" CommandArgument='<%# Eval("drawing_master_id")%>' Visible="true" CssClass="" data-toggle="tooltip" data-placement="bottom" title="" data-original-title=""></asp:LinkButton>
                                                                            </td>
                                                                            <td class=" text-center" style="width: 50px; height: 50px">
                                                                                <asp:Label ID="lblpic" Text='<%#Eval("drawing_image")%>' Visible="false" runat="server"></asp:Label>
                                                                                <asp:Image ID="lblDrawingImageUrl" runat="server" ImageUrl='<%#Eval("drawing_image")%>' CssClass="drawingimage" alt="Drawing Image" />
                                                                               <%-- <a runat="server" id="anchorDrawingImage" data-toggle="lightbox-image">
                                                                                  <asp:Image ID="lblDrawingImageUrl" runat="server" ImageUrl='<%#Eval("drawing_image")%>' CssClass="img-responsive center-block" Style="height: 50px; width: 50px;" alt="Drawing Image" />
                                                                                  </a>--%>
                                                                                 
                                                                            </td>
                                                                           
                                                                            <td class=" text-center">
                                                                                <asp:Label ID="lblDrawingName" Text='<%#Eval("drawing_name")%>' runat="server"> </asp:Label>
                                                                            </td>
                                                                            <td class=" text-center">
                                                                                <asp:Label ID="lblDrawingType" Text='<%#Eval("drawing_type")%>' runat="server"> </asp:Label>
                                                                            </td>
                                                                            <td class=" text-center">
                                                                                <asp:Label ID="lblDrawingAlias" Text='<%#Eval("drawing_alias")%>' runat="server"> </asp:Label>
                                                                            </td>
                                                                             <td class="text-center">
                                                                                <asp:Label ID="lblIsSelectStatus" Text='<%#Eval("drawing_master_id")%>' runat="server" Visible="false" />
                                                                                
                                                                                 <asp:Label ID="lblStatusClass" runat="server" CssClass="text-success" Visible="false"><i class="fa fa-fw fa-check" style="font-size:30px"></i></asp:Label>
                                                                                <asp:LinkButton ID="btnstatusunselected" runat="server" CommandName="select" CommandArgument='<%# Eval("drawing_master_id")%>' Visible="true" CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Select" data-original-title="Basic tooltp">Unselected</asp:LinkButton>

                                                                            </td>
                                                                            <td class=" text-center">
                                                                                <asp:Label ID="lblDrawingDescription" Text='<%#Eval("drawing_description")%>' runat="server"> </asp:Label>
                                                                            </td>


                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </table>         
                                                                    </FooterTemplate>
                                                                </asp:Repeater>

                                                            </div>
                                                            <!-- END All Orders Content -->
                                                        </div>
                                                        <!-- END All Orders Block -->
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label for="any Left Over">Any Left Over</label>
                                                                <asp:DropDownList ID="ddlLeftoverStatus" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label for="any Left Over">Draft Height</label>
                                                                <asp:TextBox ID="txtLeftOverSizeHeight" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Height" MaxLength="4" ></asp:TextBox>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label for="any Left Over">Draft Width</label>
                                                                <asp:TextBox ID="txtLeftOverSizeWidthfromAcknowledge" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Height" MaxLength="4"></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="form-group">
                                                                <label for="any Left Over">No of Draft</label>
                                                                <asp:TextBox ID="txtNoofDraftSheetLeft" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter No of Draft" MaxLength="4" ></asp:TextBox>

                                                            </div>

                                                        </div>
                                                        <div class="col-md-4" id="divselectedDrawing" runat="server" visible="false">
                                                            <div class="form-group">
                                                                <asp:Label ID="lblSelectedDrawingName" runat="server" CssClass="text-success SelectedDrawing"> </asp:Label>
                                                                <asp:Label ID="lblSelectedDrawingId" Visible="false" runat="server"> </asp:Label>
                                                                <asp:Label ID="lblErrorMessage" runat="server" Visible="false" CssClass="text-danger ErrorMessageFont"> </asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                   
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                        <label for="">Remarks</label>
                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" onkeypress="return character_and_Number(event)" placeholder="Enter Remarks" MaxLength="250"></asp:TextBox>

                                                    </div>
                                                    </div>
                                                    
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                        <div class="form-group form-actions text-right" style="margin-top: 12px;">
                                                            <%-- <a data-toggle="modal" href="#modal-crate-item" class="btn btn-primary">Launch modal</a>--%>
                                                            <asp:LinkButton ID="lnkBtnResetAcknowledge" runat="server" Text="Reset" OnClick="lnkBtnResetAcknowledge_Click" CssClass="btn btn-default">Reset </asp:LinkButton>
                                                            <asp:LinkButton ID="lnkBtnAddAcknowledge" runat="server" OnClientClick="return validateAcknwoledgeinfo();" OnClick="lnkBtnAddAcknowledge_Click" CssClass="btn btn-primary">Add</asp:LinkButton>

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


            <!-- END Forms General Header -->
            <div class="block full">
                <!-- All Orders Title -->
                <div class="block-title">
                    <div class="block-options pull-right">
                        <%--<select class="form-control" style="margin-top:3px">
                           <option value="All">All</option>
                           <option value="Plant 1">Plant 1</option>
                            <option value="Plant 2">Plant 2</option>
                            <option value="Plant 3">Plant 3</option>
                            <option value="Plant 4">Plant 4</option>
                                </select>--%>

                        <asp:DropDownList ID="ddlSearchByPlant" runat="server" CssClass="form-control" Style="margin-top: 3px" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchByPlant_SelectedIndexChanged">
                            <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                            <asp:ListItem Value="1">Plant 1</asp:ListItem>
                            <asp:ListItem Value="2">Plant 2</asp:ListItem>
                            <asp:ListItem Value="3">Plant 3</asp:ListItem>
                            <asp:ListItem Value="4">Plant 4</asp:ListItem>
                            <asp:ListItem Value="5">Plant 5</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <h2><strong>Procced To Production</strong> </h2>
                </div>
                
                <!-- END All Role Block -->

                <!-- Repeater Start -->

                <div class="row" runat="server" id="divPlanProduction">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:Repeater ID="rptrProductionDetail" runat="server" OnItemCommand="rptrProductionDetail_ItemCommand" OnItemDataBound="rptrProductionDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                        <thead>
                                            <tr>
                                                <th class="text-center" style="width: 30px;">S No</th>
                                                <th class="text-center ">Work-Order No</th>
                                                 <%--<th class="text-center " style="width: 150px;">Party Names</th>--%>
                                                <%--<th class="text-center ">Item Master Id</th>--%>
                                                <th class="text-center ">Model</th>
                                                <th class="text-center ">Item Type</th>
                                                <th class="text-center ">Glass Color</th>
                                                <th class="text-center ">Production. Qty</th>
                                                <th class="text-center ">Plant</th>
                                                <th class="text-center ">Current Status</th>
                                                <th class="text-center ">Started On</th>
                                                <th class="text-center ">Cutting</th>
                                                <th class="text-center ">Grinding</th>
                                                <th class="text-center ">WashingOne</th>
                                                <th class="text-center ">Hole</th>
                                                <th class="text-center ">Washing</th>
                                                <th class="text-center ">Paint</th>
                                                <th class="text-center ">DFG</th>
                                                <th class="text-center ">Tempring</th>
                                                <th class="text-center ">Packing</th>
                                                <th class="text-center ">Store</th>
                                                <th class="text-center " style="width: 50px">Shift</th>
                                                <th class="text-center " style="width: 100px">Planed Date</th>
                                                <th class="text-center " style="width: 120px">Action</th>


                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong><%# Container.ItemIndex + 1 %></strong></a></td>
                                            <td class="text-center">
                                                <a href="#">
                                              <strong style="word-wrap: break-word;text-transform: uppercase;"> 
                                                  <asp:Label ID="lblBatchNumber" Text='<%#Eval("batch_number")%>' data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp" runat="server"> </asp:Label>
                                                  </strong>
                                                </a>

                                            </td>
                                        <%--<td class="text-center"><a href="#">
                                            <strong style="word-wrap: break-word;text-transform: uppercase;">
                                            <asp:Label ID="lblPartyNames"  runat="server" > </asp:Label>
                                           </strong></a>

                                        </td>--%>
                                        
                                        <td class="text-center">
                                             <asp:Label ID="lblItemMasterId" Text='<%#Eval("item_master_id")%>' Visible="false" runat="server"> </asp:Label>
                                            
                                            <asp:Label ID="lblPartyMasterId" Text='<%#Eval("party_master_id")%>' Visible="false" runat="server"> </asp:Label>
                                            <asp:Label ID="lblModel" Text='<%#Eval("item_model")%>' runat="server"> </asp:Label>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="LblItemtypeName" Text='<%#Eval("item_type_name")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblGlassColor" Text='<%#Eval("item_glass_color")%>' runat="server"> </asp:Label>
                                        </td>

                                        <td class="text-center">
                                            <asp:Label ID="lblProductionQuantity" Text='<%#Eval("production_quantity")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:DropDownList ID="ddlPlant" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPlant_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Plant 1</asp:ListItem>
                                                <asp:ListItem Value="2">Plant 2</asp:ListItem>
                                                <asp:ListItem Value="3">Plant 3</asp:ListItem>
                                                <asp:ListItem Value="4">Plant 4</asp:ListItem>
                                                <asp:ListItem Value="5">Plant 5</asp:ListItem>
                                                <%--<asp:ListItem Value="Plant 1">Plant 1</asp:ListItem>
                                                <asp:ListItem Value="Plant 2">Plant 2</asp:ListItem>
                                                <asp:ListItem Value="Plant 3">Plant 3</asp:ListItem>
                                                <asp:ListItem Value="Plant 4">Plant 4</asp:ListItem>--%>
                                            </asp:DropDownList>

                                            <asp:Label ID="lblProductionPlant" Text='<%#Eval("production_plant")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblCurrentStatus" Text='<%#Eval("production_status")%>' runat="server"></asp:Label>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblStartedOn" Text='<%#Eval("started_on","{0: dd MMM yyyy}")%>' runat="server"></asp:Label>
                                        </td>
                                        <td class="text-center">

                                            <asp:Label ID="lblCuttingId" Text='<%#Eval("cutting_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderCutting" Text='<%#Eval("is_under_cutting")%>' Visible="false" runat="server"></asp:Label>
                                            
                                            <asp:LinkButton ID="btnCuttingQuantity" runat="server" CommandName="cutting" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("cutting_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblCuttingStatus" runat="server" Visible="false" Text="--" CssClass=""></asp:Label>
                                            
                                            <asp:LinkButton ID="btnTransferFromCutting" runat="server" CommandName="transferbycutting" CommandArgument='<%# Eval("production_id")%>' Visible="false"  CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblGrindingId" Text='<%#Eval("grinding_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderGrinding" Text='<%#Eval("is_under_grinding")%>' Visible="false" runat="server"></asp:Label>
                                           
                                            <asp:LinkButton ID="btnGrindingQuantity" runat="server" CommandName="grinding" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("grinding_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblGrindingStatus" runat="server" Visible="false" Text="--" CssClass=""></asp:Label>

                                            <asp:LinkButton ID="btnTransferFromgrinding" runat="server" CommandName="transferbygrinding" CommandArgument='<%# Eval("production_id")%>' Visible="false"  CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblWashingOneId" Text='<%#Eval("washing_one_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderWashingOne" Text='<%#Eval("is_under_washing_one")%>' Visible="false" runat="server"></asp:Label>
                                           
                                            <asp:LinkButton ID="btnWashingOneQuantity" runat="server" CommandName="washingone" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("washing_one_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblWashingOneStatus" runat="server" Visible="false" Text="--" CssClass=""></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromWashingOne" runat="server" CommandName="transferbywashingone" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblHoleId" Text='<%#Eval("hole_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderHole" Text='<%#Eval("is_under_hole")%>' Visible="false" runat="server"></asp:Label>
                                           
                                            <asp:LinkButton ID="btnHoleQuantity" runat="server" CommandName="hole" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("hole_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblHoleStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromHole" runat="server" CommandName="transferbyhole" CommandArgument='<%# Eval("production_id")%>' Visible="false"  CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblWashingId" Text='<%#Eval("washing_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderWashing" Text='<%#Eval("is_under_washing")%>' Visible="false" runat="server"></asp:Label>
                                            
                                            <asp:LinkButton ID="btnWashingQuantity" runat="server" CommandName="washing" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("washing_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblWashingStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromWashing" runat="server" CommandName="transferbywashing" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPaintId" Text='<%#Eval("paint_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderPaint" Text='<%#Eval("is_under_paint")%>' Visible="false" runat="server"></asp:Label>
                                           
                                            <asp:LinkButton ID="btnPaintQuantity" runat="server" CommandName="paint" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("paint_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblPaintStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                             <asp:LinkButton ID="btnTransferFromPaint" runat="server" CommandName="transferbypaint" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>


                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblDfgPrintId" Text='<%#Eval("dfg_print_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderDfgPrint" Text='<%#Eval("is_under_dfg_print")%>' Visible="false" runat="server"></asp:Label>
                                            
                                            <asp:LinkButton ID="btnDfgPrintQuantity" runat="server" CommandName="dfgprint" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("dfg_print_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblDfgPrintStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromDfgPrint" runat="server" CommandName="transferbydfgprint" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblTemperingId" Text='<%#Eval("tempering_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderTempering" Text='<%#Eval("is_under_tempering")%>' Visible="false" runat="server"></asp:Label>
                                            
                                            <asp:LinkButton ID="btnTemperingQuantity" runat="server" CommandName="tempering" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("tempering_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblTemperingStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromTempering" runat="server" CommandName="transferbytempring" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblPackingId" Text='<%#Eval("packing_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderPacking" Text='<%#Eval("is_under_packing")%>' Visible="false" runat="server"></asp:Label>
                                           
                                            <asp:LinkButton ID="btnPackingQuantity" runat="server" CommandName="packing" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("packing_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblPackingStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromPacking" runat="server" CommandName="transferbypacking" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>

                                        </td>
                                        <td class="text-center">
                                            <asp:Label ID="lblStoreId" Text='<%#Eval("store_id")%>' runat="server" Visible="false"> </asp:Label>
                                            <asp:Label ID="lblIsUnderStore" Text='<%#Eval("is_under_store")%>' Visible="false" runat="server"></asp:Label>
                                           
                                            <asp:LinkButton ID="btnStoreQuantity" runat="server" CommandName="store" CommandArgument='<%# Eval("production_id")%>' Text='<%#Eval("store_quantity")%>' Visible="false" CssClass=" text-primary"></asp:LinkButton>
                                            <asp:Label ID="lblStoreStatus" runat="server" CssClass="" Visible="false" Text="--"></asp:Label>
                                            <asp:LinkButton ID="btnTransferFromUnderStore" runat="server" CommandName="transferbyunderstore" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Transfer On Floor" data-original-title="Basic tooltp"><i class="gi gi-transfer"></i></asp:LinkButton>


                                        </td>

                                       <td class="text-center">
                                            <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                                <asp:ListItem Value="Day">D</asp:ListItem>
                                                <asp:ListItem Value="Night">N</asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:Label ID="lblShiftName" Text='<%#Eval("production_shift")%>' runat="server"> </asp:Label>

                                        </td>
                                      <td class="text-center">
                                            <asp:TextBox ID="txtPlannedDate" runat="server" CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy" OnTextChanged="txtPlannedDate_TextChanged"></asp:TextBox>
                                            <asp:Label ID="lblPlannedDate" Text='<%#Eval("planned_date","{0: dd MMM yyyy}")%>' runat="server"> </asp:Label>
                                        </td>
                                        <td class="text-center btn-group-sm">
                                            <asp:Label ID="lblProductionStatus" Text='<%#Eval("production_status")%>' runat="server" Visible="false" />
                                            <asp:LinkButton ID="btnAcknowledge" runat="server" CommandName="active" CommandArgument='<%# Eval("production_id")%>' CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to Start Production" data-original-title="Basic tooltp">Acknowledge</asp:LinkButton>
                                            <asp:LinkButton ID="btnViewStatus" runat="server" CommandName="viewstatus" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-default text-center btn-group-xs" data-toggle="tooltip" data-placement="bottom" title="Click to View Status" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnHold" runat="server" CommandName="hold" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-default text-center btn-group-xs" data-toggle="tooltip" data-placement="bottom" title="Click to Hold/Unhold" data-original-title="Basic tooltp"><i class=""></i></asp:LinkButton>
                                            <asp:LinkButton ID="btnStart" runat="server" CommandName="start" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to Start" data-original-title="Basic tooltp">Start</asp:LinkButton>
                                            <asp:LinkButton ID="btnSubmit" runat="server" CommandName="submit" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to Submit" data-original-title="Basic tooltp">Submit</asp:LinkButton>
                                            <asp:LinkButton ID="btnView" runat="server" CommandName="view" CommandArgument='<%# Eval("production_id")%>' Visible="false" CssClass="btn btn-sm btn-primary" data-toggle="tooltip" data-placement="bottom" title="Click to View" data-original-title="Basic tooltp">View</asp:LinkButton>

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

                </div>

                <!-- Repeater End --->


            </div>
            <!-- Manage Tour Start -->

            <!-- End Manage Tour -->

        </div>
        <!-- END Page Content -->
    </form>
</body>
</html>
