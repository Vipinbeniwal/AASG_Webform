<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="raise-stock-requirement.aspx.cs" Inherits="AASGWeb.Modules.Inventory.raise_stock_requirement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-margin {
            margin-top: 24px;
        }

        @media (max-width:991px) {
            .btn-margin {
                margin-top: 4px;
                margin-bottom: 4px;
                float: right;
            }
        }
    </style>
    <%-- <script src="../../Content/js/vendor/jquery.min.js"></script>--%>
    <%--  <script src="../../Content/js/vendor/jquery-ui.js"></script>
    <script type="text/javascript">
        // alert('good')
        $(document).ready(function () {
            alert('too good')
            var itemmasterDetail;
           
            $("#ContentPlaceHolder1_txtItemBatchNo").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "raise-stock-requirement.aspx/GetItemBatchNoDetails",
                        data: JSON.stringify({ "ItemBatchNo": "" + $("#ContentPlaceHolder1_txtItemBatchNo").val() + "" }),
                        dataType: "json",
                        success: function (data) {
                            alert($('#ContentPlaceHolder1_txtItemBatchNo').val())
                            var ParsedObject = $.parseJSON(data.d);
                            for (var i = 0; i < data.d.length; i++) {
                                alert(data.d[0].brand)
                            }
                            
                            response($.map(ParsedObject, function (item) {
                                return {
                                   // alert(item)
                                    label: item.item_master_id,
                                    value: item.item_master_id,
                                    itemmasterDetail: item.item_master_id,
                                    //alert(itemmasterDetail)
                                        };
                            }))
                           // alert(data.d)
                        },
                        error: function (result) {
                            $("#ContentPlaceHolder1_txtItemBatchNo").css('border-color', 'red');
                        }
                    });
                },
                //minLength: 3,
                //select: function (event, ui) {
                //    var str = ui.item.itemmasterDetail;
                //    alert(str)

                    //var arrayclient = str.split("_");
                    //var Brand = arrayclient[0];
                    //$("#ContentPlaceHolder1_txtBrand").val(Brand);
                //    var ClientUserId = arrayclient[0];
                //    var ClientId = arrayclient[2];
                //    $("#ContentPlaceHolder1_hdnClientUserId").val(ClientUserId);
                //    $("#ContentPlaceHolder1_hdnClientId").val(ClientId);
                //    $("#ContentPlaceHolder1_txtClientMaster").css('border-color', 'green');
               // }
            });

        });
    </script>--%>
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
            <li>Stock Issuance</li>
            <li><a href="/add-return">Raise Stock Requirement</a></li>
        </ul>
        <!-- END Forms General Header -->
        <!-- All Orders Block -->
        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Excel Export</a>
                </div>
                <h2><strong>Raise</strong> Stock Requirement</h2>
            </div>
            <asp:HiddenField ID="hdfdItemMasterId" runat="server" />
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="description">Batch No</label>
                        <asp:TextBox ID="txtItemBatchNo" runat="server" CssClass="form-control" placeholder="Enter BatchNo"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4 ">
                    <asp:LinkButton ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-sm btn-success btn-margin">Search</asp:LinkButton>
                </div>
            </div>
            <div class="row">

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-email">Select Employee <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Employee ..">
                            <asp:ListItem></asp:ListItem>


                        </asp:DropDownList>

                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Select Item Type <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlItemTypeList" runat="server" CssClass="select-chosen" AutoPostBack="true" OnSelectedIndexChanged="ddlItemTypeList_SelectedIndexChanged" data-placeholder="Choose a Item type ..">
                            <asp:ListItem></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Select Item <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlItemList" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Item ..">
                            <asp:ListItem></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                </div>





            </div>
            <div class="row">

                <div class="col-md-4">
                    <div class="form-group">
                        <label for="description">Brand</label>
                        <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" placeholder="Enter Brand"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Require Item Quantity <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtItemQuantity" runat="server" CssClass="form-control" placeholder="Enter Item Quantity"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Item Price </label>
                        <asp:TextBox ID="txtItemPrice" runat="server" CssClass="form-control" placeholder="Enter Price"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Require Date <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtRequireDate" runat="server" CssClass="form-control input-datepicker-close" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="btnAddItem" CssClass="btn btn-sm btn-info" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                    <asp:Repeater ID="rptrBatchItems" runat="server" Visible="false" OnItemCommand="rptrBatchItems_ItemCommand" OnItemDataBound="rptrBatchItems_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center visible-lg">Item ID</th>
                                        <th class="text-center visible-lg">Brand</th>
                                        <th class="text-center visible-lg">Model</th>
                                        <th class="text-center visible-lg">Item Name</th>
                                        <th class="text-center hidden-xs">Item Quantity</th>
                                        <th class="text-center hidden-xs">Item Price</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>    </td>


                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblBrand" Text='<%#Eval("brand")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblModel" Text='<%#Eval("model")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblItemType" Text='<%#Eval("item_type_name")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="hidden-xs text-center">
                                    <asp:Label ID="lblItemQuantity" Text='<%#Eval("item_quantity")%>' runat="server"></asp:Label>
                                </td>
                                <td class="hidden-xs text-center">
                                    <asp:Label ID="lblItemPrice" Text='<%#Eval("item_price")%>' runat="server"></asp:Label>

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
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="example-nf-password">Remarks <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" placeholder="Enter Remarks"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="btnAddItemRequire" CssClass="btn btn-sm btn-info" runat="server" Text="Add Require" OnClick="btnAddItemRequire_Click" />
                    </div>
                </div>
            </div>
            <%-- <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                 <button type="submit" class="btn btn-sm btn-primary"> Add Require</button>

                            </div>
                        </div>


                    </div> --%>


            <!-- END All Orders Content -->
        </div>
        <!-- END All Orders Block -->
    </div>
    <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
