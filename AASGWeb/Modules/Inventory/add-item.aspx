<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-item.aspx.cs" Inherits="AASGWeb.Modules.Inventory.add_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            $("#ContentPlaceHolder1_txtNumberOfHole").attr('disabled', true);
            $("#ContentPlaceHolder1_txtDiameter").attr('disabled', true);
            $("#ContentPlaceHolder1_txtNormalPaintQTYGM").attr('disabled', true);
            $("#ContentPlaceHolder1_txtNormalPaintInRs").attr('disabled', true);
            $("#ContentPlaceHolder1_txtBlackPaintQTYGM").attr('disabled', true);
            $("#ContentPlaceHolder1_txtBlackPaintInRs").attr('disabled', true);
            //$("#ContentPlaceHolder1_txtThinner").attr('disabled', true);
            $("#ContentPlaceHolder1_txtDFGPaintQTYGM").attr('disabled', true);
            $("#ContentPlaceHolder1_txtDFGPaintInRs").attr('disabled', true);
            $("#ContentPlaceHolder1_txtThinnerPaintQTYGM").attr('disabled', true);
            $("#ContentPlaceHolder1_txtThinnerPaintInRs").attr('disabled', true);
            $("#ContentPlaceHolder1_ddlDoorClipType_chosen").attr('disabled', true);
            $("#ContentPlaceHolder1_txtDoorClipRate").attr('disabled', true);

            $("#ContentPlaceHolder1_ddlDiamondYesNo_chosen").attr('disabled', true);
            $("#ContentPlaceHolder1_txtDiamondInRs").attr('disabled', true);
            $("#ContentPlaceHolder1_ddlPolishYesNo_chosen").attr('disabled', true);
            $("#ContentPlaceHolder1_txtPolishInRs").attr('disabled', true);

            $("#ContentPlaceHolder1_ddlPackingPolythinYesNo_chosen").attr('disabled', true);
            $("#ContentPlaceHolder1_txtPackingPolythinInRs").attr('disabled', true);
            $("#ContentPlaceHolder1_ddlPackingPaperYesNo_chosen").attr('disabled', true);
            $("#ContentPlaceHolder1_txtPackingPaperQuantityInRs").attr('disabled', true);

            // DropDown Packing Polythin Yes or No Code 
            $('#<%=ddlPackingPolythinYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {

                    $("#ContentPlaceHolder1_ddlPackingPolythinYesNo_chosen").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtPackingPolythinInRs").removeAttr('disabled');
                }
                else {

                    $("#ContentPlaceHolder1_ddlPackingPolythinYesNo_chosen").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtPackingPolythinInRs").attr('disabled', true);
                }

            });
            // DropDown Packing Paper Yes or No Code 
            $('#<%=ddlPackingPaperYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {

                    $("#ContentPlaceHolder1_ddlPackingPaperYesNo_chosen").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtPackingPaperQuantityInRs").removeAttr('disabled');
                }
                else {

                    $("#ContentPlaceHolder1_ddlPackingPaperYesNo_chosen").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtPackingPaperQuantityInRs").attr('disabled', true);
                }

            });


            // DropDown Diamond Yes or No Code 
            $('#<%=ddlDiamondYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {

                    $("#ContentPlaceHolder1_ddlDiamondYesNo_chosen").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtDiamondInRs").removeAttr('disabled');
                }
                else {

                    $("#ContentPlaceHolder1_ddlDiamondYesNo_chosen").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtDiamondInRs").attr('disabled', true);
                }

            });

            // DropDown Polish Yes or No Code 
            $('#<%=ddlPolishYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {

                    $("#ContentPlaceHolder1_ddlPolishYesNo_chosen").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtPolishInRs").removeAttr('disabled');
                }
                else {

                    $("#ContentPlaceHolder1_ddlPolishYesNo_chosen").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtPolishInRs").attr('disabled', true);
                }

            });

            // DropDown Hole Yes or No Code
            $('#<%=ddlHoleYesNo.ClientID %>').on("change", function () {
                //Get DropDownlist selected item index
                var selectedIndex = $(this).find("option:selected").index();
                //Get DropDownlist selected item value
                var selectedValue = $(this).find("option:selected").val();
                //Get DropDownlist selected item text

                var selectedText = $(this).find("option:selected").text();
                if ($(this).find("option:selected").text() == "Yes") {
                    $("#ContentPlaceHolder1_txtNumberOfHole").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtDiameter").removeAttr('disabled');
                }
                else {

                    $("#ContentPlaceHolder1_txtNumberOfHole").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtDiameter").attr('disabled', true);
                }

            });


            // DropDown Normal Paint Yes or No Code
            $('#<%=ddlNormalPaintYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {
                    $("#ContentPlaceHolder1_txtNormalPaintQTYGM").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtNormalPaintInRs").removeAttr('disabled');
                }
                else {

                    $("#ContentPlaceHolder1_txtNormalPaintQTYGM").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtNormalPaintInRs").attr('disabled', true);
                }

            });

            // DropDown Black Paint Yes or No Code
            $('#<%=ddlBlackPaintYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {
                    $("#ContentPlaceHolder1_txtBlackPaintQTYGM").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtBlackPaintInRs").removeAttr('disabled');
                    //$("#ContentPlaceHolder1_txtThinner").removeAttr('disabled');

                }
                else {

                    $("#ContentPlaceHolder1_txtBlackPaintQTYGM").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtBlackPaintInRs").attr('disabled', true);
                    //$("#ContentPlaceHolder1_txtThinner").attr('disabled', true);
                }

            });

            // DropDown DFG Paint Yes or No Code 
            $('#<%=ddlDFGPaintYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {
                    $("#ContentPlaceHolder1_txtDFGPaintQTYGM").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtDFGPaintInRs").removeAttr('disabled');
                }
                else {
                    $("#ContentPlaceHolder1_txtDFGPaintQTYGM").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtDFGPaintInRs").attr('disabled', true);
                }

            });

            // DropDown Thinner Paint Yes or No Code 
            $('#<%=ddlThinnerPaintYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {
                    $("#ContentPlaceHolder1_txtThinnerPaintQTYGM").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtThinnerPaintInRs").removeAttr('disabled');

                }
                else {
                    $("#ContentPlaceHolder1_txtThinnerPaintQTYGM").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtThinnerPaintInRs").attr('disabled', true);
                }

            });

            // DropDown Door Clip Yes or No Code 
            $('#<%=ddlDoorClipYesNo.ClientID %>').on("change", function () {

                if ($(this).find("option:selected").text() == "Yes") {

                    $("#ContentPlaceHolder1_ddlDoorClipType_chosen").removeAttr('disabled');
                    $("#ContentPlaceHolder1_txtDoorClipRate").removeAttr('disabled');

                }
                else {

                    $("#ContentPlaceHolder1_ddlDoorClipType_chosen").attr('disabled', true);
                    $("#ContentPlaceHolder1_txtDoorClipRate").attr('disabled', true);
                }

            });


            // Enable remove After Bind Value from routings if Yes or No

            if ($('#<%=ddlPackingPolythinYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtPackingPolythinInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlPackingPaperYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtPackingPaperQuantityInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlDiamondYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtDiamondInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlPolishYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtPolishInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlHoleYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtNumberOfHole").removeAttr('disabled');
                $("#ContentPlaceHolder1_txtDiameter").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlNormalPaintYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtNormalPaintQTYGM").removeAttr('disabled');
                $("#ContentPlaceHolder1_txtNormalPaintInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlBlackPaintYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtBlackPaintQTYGM").removeAttr('disabled');
                $("#ContentPlaceHolder1_txtBlackPaintInRs").removeAttr('disabled');
                //$("#ContentPlaceHolder1_txtThinner").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlDFGPaintYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtDFGPaintQTYGM").removeAttr('disabled');
                $("#ContentPlaceHolder1_txtDFGPaintInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlThinnerPaintYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtThinnerPaintQTYGM").removeAttr('disabled');
                $("#ContentPlaceHolder1_txtThinnerPaintInRs").removeAttr('disabled');
            }
            else { }

            if ($('#<%=ddlDoorClipYesNo.ClientID %>').find("option:selected").text() == "Yes") {
                $("#ContentPlaceHolder1_txtDoorClipRate").removeAttr('disabled');
            }
            else { }

        });
    </script>

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

        <asp:HiddenField ID="hdnfItemId" runat="server" />
        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong>Add</strong> Item Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="brand">Brand Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtBrand" runat="server" class="form-control" placeholder="Brand"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="model">Model Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtModel" runat="server" class="form-control" placeholder="Model"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="description">Item Type</label>
                                <%--<asp:DropDownList ID="ddlItemType" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="Wind Screen">Wind Screen</asp:ListItem>
                                    <asp:ListItem Value="Front Door">Front Door</asp:ListItem>
                                    <asp:ListItem Value="Glass Door">Glass Door</asp:ListItem>
                                </asp:DropDownList>--%>
                                <asp:TextBox ID="txtItemType" runat="server" class="form-control" placeholder="Enter Item Type"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="glasscolor">Glass Color</label>
                                <asp:TextBox ID="txtGlassColor" runat="server" class="form-control" placeholder="Glass Color"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="size">Size</label>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtItemHeight" runat="server" class="form-control" placeholder="Item Height" onkeypress="return Number(event)" ></asp:TextBox>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtItemWidth" runat="server" class="form-control" placeholder="Item Width" onkeypress="return Number(event)" ></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="thicness">Thickness</label>
                                <asp:TextBox ID="txtThickness" runat="server" class="form-control" placeholder="Thickness"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="actualsqm">Actual SQM</label>
                                <asp:TextBox ID="txtActualSQM" runat="server" class="form-control" placeholder="Actual SQM" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="actualsqm">Used SQM</label>
                                <asp:TextBox ID="txtUsedSQM" runat="server" class="form-control" placeholder="Used SQM" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="perimeter">Perimeter</label>
                                <asp:TextBox ID="txtPerimeter" runat="server" class="form-control" placeholder="Perimeter" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="plant">Plant</label>
                                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="HTF 1">HTF 1</asp:ListItem>
                                    <asp:ListItem Value="VTF 1">VTF 1</asp:ListItem>
                                    <asp:ListItem Value="VTF 2">VTF 2</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="plant">Plant</label>
                                <asp:DropDownList ID="ddlPlantNumber" runat="server" CssClass="select-chosen">
                                    <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Plant 1</asp:ListItem>
                                    <asp:ListItem Value="2">Plant 2</asp:ListItem>
                                    <asp:ListItem Value="3">Plant 3</asp:ListItem>
                                    <asp:ListItem Value="4">Plant 4</asp:ListItem>
                                    <asp:ListItem Value="5">Plant 5</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>




                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="plant">Diamond</label>
                                <asp:DropDownList ID="ddlDiamondYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="diamondinrs">Diamond(In RS)</label>
                                <asp:TextBox ID="txtDiamondInRs" runat="server" class="form-control" placeholder="Diamond In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="plant">RG</label>
                                <asp:DropDownList ID="ddlRGYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtRGInRs">RG(In RS)</label>
                                <asp:TextBox ID="txtRGInRs" runat="server" class="form-control" placeholder="RG In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="plant">Washing_One</label>
                                <asp:DropDownList ID="ddlWashingOneYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="plant">Hole</label>
                                <asp:DropDownList ID="ddlHoleYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="noofhole">No of Hole </label>
                                <asp:TextBox ID="txtNumberOfHole" runat="server" class="form-control" placeholder="Number Of Hole" onkeypress="return Number(event)" ></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="diameter">Diameter</label>
                                <asp:TextBox ID="txtDiameter" runat="server" class="form-control" placeholder="Diameter"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="plant">Washing_two</label>
                                <asp:DropDownList ID="ddlWashingTwoYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">                                
                                <div class="row">
                                    <div class="col-md-4">
                                         <label for="plant">Normal Paint</label>
                                        <asp:DropDownList ID="ddlNormalPaintYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                            <asp:ListItem Selected="True">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <label for="normalpaintqtygm">QTY(GM)</label>
                                        <asp:TextBox ID="txtNormalPaintQTYGM" runat="server" class="form-control" placeholder="QTY(GM)" onkeypress="return isNumberKey(this, event);" ></asp:TextBox>
                                    </div>
                                     <div class="col-md-4">
                                        <label for="txtNormalPaintInRs">In RS</label>
                                    <asp:TextBox ID="txtNormalPaintInRs" runat="server" class="form-control" placeholder="Normal Paint In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <div class="form-group">                                
                                <div class="row">
                                    <div class="col-md-4">
                                        <label for="plant">Black Paint</label>
                                    <asp:DropDownList ID="ddlBlackPaintYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                       <label for="blackpaintqtygm">QTY(GM)</label>
                                    <asp:TextBox ID="txtBlackPaintQTYGM" runat="server" class="form-control" placeholder="QTY(GM)" onkeypress="return isNumberKey(this, event);" ></asp:TextBox>

                                    </div>
                                     <div class="col-md-4">
                                        <label for="txtBlackPaintInRs">In RS</label>
                                    <asp:TextBox ID="txtBlackPaintInRs" runat="server" class="form-control" placeholder="Black Paint In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">                                
                                <div class="row">
                                    <div class="col-md-4">
                                        <label for="plant">DFG Paint</label>
                                    <asp:DropDownList ID="ddlDFGPaintYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                       <label for="dfgpaintqtygm">QTY(GM)</label>
                                    <asp:TextBox ID="txtDFGPaintQTYGM" runat="server" class="form-control" placeholder="QTY(GM)" onkeypress="return isNumberKey(this, event);" ></asp:TextBox>

                                    </div>
                                     <div class="col-md-4">
                                        <label for="txtDFGPaintInRs">In RS</label>
                                    <asp:TextBox ID="txtDFGPaintInRs" runat="server" class="form-control" placeholder="DFG Paint In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                                <div class="form-group">
                                    <label for="thinnerpaint">Thinner</label>
                                    <asp:DropDownList ID="ddlThinnerPaintYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        <div class="col-md-3">
                            <div class="form-group">                                
                                <div class="row">
                                    <div class="col-md-6">
                                        <label for="txtThinnerPaintQTYGM">QTY(GM)</label>
                                        <asp:TextBox ID="txtThinnerPaintQTYGM" runat="server" class="form-control" placeholder="QTY(GM)" onkeypress="return isNumberKey(this, event);" ></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="txtThinnerPaintInRs">In RS</label>
                                        <asp:TextBox ID="txtThinnerPaintInRs" runat="server" class="form-control" placeholder="Thinner Paint In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="thicness">Pre processing breakage level</label>
                                <asp:TextBox ID="txtPreProcessingBreakageLevel" runat="server" class="form-control" placeholder="Enter Pre-Processing Breakage Level" onkeypress="return Number(event)" ></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="thicness">Processing breakage level</label>
                                <asp:TextBox ID="txtProcessingBreakageLevel" runat="server" class="form-control" placeholder="Enter Processing Breakage Level" onkeypress="return Number(event)" ></asp:TextBox>

                            </div>
                        </div>
                        

                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="thinn">Polish</label>
                                <asp:DropDownList ID="ddlPolishYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtPolishInRs">Polish(In RS)</label>
                                <asp:TextBox ID="txtPolishInRs" runat="server" class="form-control" placeholder="Polish In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="plant">Connector Type</label>
                                <asp:DropDownList ID="ddlConnectorType" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="connectorinrs">Connector In Rs</label>
                                <asp:TextBox ID="txtConnectorInRs" runat="server" class="form-control" placeholder="Connector In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>


                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="plant">Door Clip</label>
                                <asp:DropDownList ID="ddlDoorClipYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="plant">Door Clip Type</label>
                                <asp:DropDownList ID="ddlDoorClipType" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtDoorClipRate">Rate</label>
                                <asp:TextBox ID="txtDoorClipRate" runat="server" class="form-control" placeholder="Door Clip Rate" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="ddlPackingPolythinYesNo">Packing</label>
                                <asp:DropDownList ID="ddlPackingPolythinYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtPackingPolythinInRs">Packinng Polythin(In RS)</label>
                                <asp:TextBox ID="txtPackingPolythinInRs" runat="server" class="form-control" placeholder="Packing Polythin In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="ddlPackingPaperYesNo">Packing Paper</label>
                                <asp:DropDownList ID="ddlPackingPaperYesNo" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtPackingPaperQuantity">Packing Paper Quantity</label>
                                <asp:TextBox ID="txtPackingPaperQuantityInRs" runat="server" class="form-control" placeholder="Packing Paper Quantity In Rs" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="stockmaxlevel">Stock Level</label>
                                <asp:TextBox ID="txtStockMaxLevel" runat="server" class="form-control" placeholder="Max Stock Level" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="itemweight">Item Weight</label>
                                <asp:TextBox ID="txtItemWeight" runat="server" class="form-control" placeholder="Item Weight" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="pricelist">Price List</label>
                                <asp:TextBox ID="txtPrice" runat="server" class="form-control" placeholder=" Enter Item Price" onkeypress="return isNumberKey(this, event);"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="pricelist">Price List 2</label>
                                <asp:TextBox ID="txtprice2" runat="server" class="form-control" placeholder="Enter Item Price 2" onkeypress="return isNumberKey(this, event);"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="ddlPriceType">Price Type</label>
                                <asp:DropDownList ID="ddlPriceType" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtMMSQM">MM SQM</label>
                                <asp:TextBox ID="txtMMSQM" runat="server" class="form-control" placeholder="Enter MM SQM"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtFirstDop">First Dop</label>
                                <asp:TextBox ID="txtFirstDop" runat="server" class="form-control" placeholder="Enter First Dop"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtLastDop">Last Dop</label>
                                <asp:TextBox ID="txtLastDop" runat="server" class="form-control" placeholder="Enter Last Dop"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="ddlSegment">Segment</label>
                                <asp:DropDownList ID="ddlSegment" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="Bus">Bus</asp:ListItem>
                                    <asp:ListItem Value="CAR">CAR</asp:ListItem>
                                    <asp:ListItem Value="EM">EM</asp:ListItem>
                                    <asp:ListItem Value="ER">ER</asp:ListItem>
                                    <asp:ListItem Value="HCV">HCV</asp:ListItem>
                                    <asp:ListItem Value="LCP">LCP</asp:ListItem>
                                    <asp:ListItem Value="LCV">LCV</asp:ListItem>
                                    <asp:ListItem Value="LPV">LPV</asp:ListItem>
                                    <asp:ListItem Value="MCV">MCV</asp:ListItem>
                                    <asp:ListItem Value="Mini Bus">Mini Bus</asp:ListItem>
                                    <asp:ListItem Value="MPV">MPV</asp:ListItem>
                                    <asp:ListItem Value="School Bus">School Bus</asp:ListItem>
                                    <asp:ListItem Value="TW">TW</asp:ListItem>
                                    <asp:ListItem Value="Twin">Twin</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="ddlCategory">Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem Value="Back Screen">Back Screen</asp:ListItem>
                                    <asp:ListItem Value="Butterfly">Butterfly</asp:ListItem>
                                    <asp:ListItem Value="Door">Door</asp:ListItem>
                                    <asp:ListItem Value="Quarter">Quarter</asp:ListItem>
                                    <asp:ListItem Value="Sliding">Sliding</asp:ListItem>
                                    <asp:ListItem Value="Windscreen">Windscreen</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtPriority">Priority</label>
                                <asp:TextBox ID="txtPriority" runat="server" class="form-control" placeholder="Enter Priority" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtClearFocus">Clear_Foucs</label>
                                <asp:TextBox ID="txtClearFocus" runat="server" class="form-control" placeholder="Enter Clear Focus"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtMaxStockLevelApr20">Max Stock Level Apr-20</label>
                                <asp:TextBox ID="txtMaxStockLevelApr20" runat="server" class="form-control" placeholder="Enter Max Stock Level Apr-20" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtMaxStockLevelMay21">Max Stock Level May-21</label>
                                <asp:TextBox ID="txtMaxStockLevelMay21" runat="server" class="form-control" placeholder="Enter Max Stock Level May-21" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtMaxStockLevelJan21">Max Stock Level Jan-21</label>
                                <asp:TextBox ID="txtMaxStockLevelJan21" runat="server" class="form-control" placeholder="Enter Max Stock Level Jan-21" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtQ12021">Q1_2021</label>
                                <asp:TextBox ID="txtQ12021" runat="server" class="form-control" placeholder="Enter Q1_2021" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtQ22021">Q2_2021</label>
                                <asp:TextBox ID="txtQ22021" runat="server" class="form-control" placeholder="Enter Q2_2021" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtQ32021">Q3_2021</label>
                                <asp:TextBox ID="txtQ32021" runat="server" class="form-control" placeholder="Enter Q3_2021" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtQ42021">Q4_2021</label>
                                <asp:TextBox ID="txtQ42021" runat="server" class="form-control" placeholder="Enter Q4_2021" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtPreProcessing">Pre Processing</label>
                                <asp:TextBox ID="txtPreProcessing" runat="server" class="form-control" placeholder="Enter Pre Processing" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtDuringProcessing">During Processing</label>
                                <asp:TextBox ID="txtDuringProcessing" runat="server" class="form-control" placeholder="Enter During Processing" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtFactoryReadyStock">Factory Ready Stock</label>
                                <asp:TextBox ID="txtFactoryReadyStock" runat="server" class="form-control" placeholder="Enter Factory Ready Stock" onkeypress="return Number(event)" ></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:Button ID="BtnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning" OnClick="BtnReset_Click" />
                                <asp:LinkButton ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" CssClass="btn btn-sm btn-success">Update</asp:LinkButton>
                                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" class="btn btn-sm btn-primary" OnClick="btnAddItem_Click" />

                            </div>
                        </div>

                    </div>


                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>


    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
