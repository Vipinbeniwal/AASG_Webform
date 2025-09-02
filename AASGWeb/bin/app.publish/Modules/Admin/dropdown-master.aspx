<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="dropdown-master.aspx.cs" Inherits="AASGWeb.Modules.Admin.dropdown_master" %>

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
                        </div>
                        <h2><strong>Dropdown</strong> Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                     <asp:HiddenField ID="hdnfDropDownTypeId" runat="server" />
                    <div class="row">

                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="example-nf-email">DropdownType <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlDropdownType" runat="server" CssClass="select-chosen" AutoPostBack="false">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Designation">Designation</asp:ListItem>
                                    <asp:ListItem Value="Item Type">Item Type</asp:ListItem>
                                    <asp:ListItem Value="Connection Type">Connection Type</asp:ListItem>
                                    <asp:ListItem Value="DoorClip Type">DoorClip Type</asp:ListItem>
                                    <asp:ListItem Value="Project">Project</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Dropdown Item Name<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDropdownItemName" runat="server" CssClass="form-control"  onkeypress="return character_and_Number(event)" placeholder="Enter Dropdown Item Name"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="example-nf-email">Dropdown Item Alias<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDropdownItemAlias" runat="server" CssClass="form-control"  onkeypress="return character_and_Number(event)" placeholder="Enter Dropdown Item Alias"></asp:TextBox>

                            </div>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                <asp:Button ID="btnUpdateDropdownType" runat="server" Text="Update DropdownType" OnClientClick="return validateDropDowninfo();" class="btn btn-sm btn-success" Visible="false" OnClick="btnUpdateDropdownType_Click" />
                                <asp:LinkButton ID="btnAddDropdownType" runat="server" Text="Add DropdownType" OnClientClick="return validateDropDowninfo();" OnClick="btnAddDropdownType_Click" CssClass="btn btn-primary min-width-100">Submit</asp:LinkButton>
                                <%--<button type="button" class="btn btn-sm btn-primary" >Add DropdownType</button>--%>
                            </div>
                        </div>


                    </div>

                    <!-- END Normal Form Content -->
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>


        <div class="block full">
            <!-- All Orders Title -->
            <div class="block-title">
                <div class="block-options pull-right">
                 
                </div>
                <h2><strong>All</strong> DropdownMaster Types</h2>
            </div>
            <!-- END All Orders Title -->

            <div class="table-responsive">
                <asp:Repeater ID="rptrDropdownType" runat="server" OnItemCommand="rptrDropdownType_ItemCommand" OnItemDataBound="rptrDropdownType_ItemDataBound">
                    <HeaderTemplate>
                        <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                            <thead>
                                <tr class="bg-primary">
                                    <th class="design" style="width: 20px;">ID</th>
                                    <th class="design">Dropdown Id</th>
                                    <th class="design">DropdownType</th>
                                    <th class="design">Dropdown Item Name</th>
                                    <th class="design">Dropdown Item Alias</th>
                                    <th class="design">Status</th>
                                    <th class="text-left">Action</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %>    </td>
                            <td style="text-align: left;">
                                <asp:Label ID="ddlDropdownMasterId" Text='<%#Eval("dropdown_master_id")%>' runat="server" /><br />
                                <%-- ( <%# DataBinder.Eval(Container.DataItem, "FromTime")%>  )--%>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblDropdownType" Text='<%#Eval("dropdown_type")%>' runat="server" /><br />
                                <%-- ( <%# DataBinder.Eval(Container.DataItem, "FromTime")%>  )--%>
                            </td>
                            <td style="text-align: left;"><%# DataBinder.Eval(Container.DataItem, "dropdown_item_name")%> </td>
                            <td><%# DataBinder.Eval(Container.DataItem, "dropdown_Item_alias")%>

                                <%--     <td>
                                        <asp:LinkButton ID="btnRun" runat="server" CommandName="run" ToolTip="Mark Running" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-sm btn-primary" Visible="false">Mark Running </asp:LinkButton>
                                       <asp:Label ID="lblStatus" Text='<%#Eval("IsRunning")%>' runat="server" Visible="false" />
                                        <asp:LinkButton ID="btnBook" runat="server" CommandName="book" ToolTip="click to Book" CommandArgument='<%# Eval("Id") %>' CssClass="text-primary text-center"><i class="fa fa-plus"></i> </asp:LinkButton>
                                    </td>--%>
                                <td class="text-center">
                                        <asp:Label ID="lblIsActive" Text='<%#Eval("is_active")%>' runat="server" Visible="false" />
                                        <asp:LinkButton ID="btnstatusactive" runat="server" CommandName="active" CommandArgument='<%# Eval("dropdown_master_id")%>' CssClass="label label-success" data-toggle="tooltip" data-placement="bottom" title="Click to Deactivate" data-original-title="Basic tooltp">Active</asp:LinkButton>
                                        <asp:LinkButton ID="btnstatusdeactive" runat="server" CommandName="active" CommandArgument='<%# Eval("dropdown_master_id")%>' CssClass="label label-danger" data-toggle="tooltip" data-placement="bottom" title="Click to Activate" data-original-title="Basic tooltp">Deactive</asp:LinkButton>
                                    </td>
                            <td class="text-center">
                                <div class="btn-group btn-group-xs">
                                   <%-- <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>--%>
                                     <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("dropdown_master_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>

                                    <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
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
    <!-- END Page Content -->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
