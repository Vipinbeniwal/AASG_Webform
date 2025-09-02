<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-time-sheet.aspx.cs" Inherits="AASGWeb.Modules.Admin.add_time_sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                <h2><strong>Time Sheet</strong>  Master</h2>
            </div>
            <!-- END Normal Form Title -->

            <!-- Normal Form Content -->

            <div class="row">
               
                 <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-password">Select Project <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="select-chosen" AutoPostBack="false"  data-placeholder="Choose a Project Name ..">
                            <asp:ListItem></asp:ListItem>
                           
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">

                        <label for="example-nf-email"> Date <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="form-control input-datepicker" data-date-format="mm-dd-yyyy" placeholder="mm-dd-yyyy"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="example-nf-password">Hours <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txthours" runat="server" CssClass="form-control" placeholder="Enter Quantity"></asp:TextBox>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="example-nf-password">Remarks <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" placeholder="Enter Price"></asp:TextBox>

                    </div>
                </div>

            </div>

            <div class="row">

                <div class="col-md-12">
                    <div class="form-group form-actions" style="float: right">
                        <asp:LinkButton ID="btnTimeChildList" runat="server" Text="Add Item" OnClick="btnTimeChildList_Click" CssClass="btn btn-sm btn-primary">Add Item </asp:LinkButton>

                    </div>
                </div>

            </div>


            <div class="row">
                <div class="col-md-12">
                    <asp:Repeater ID="rptrTimeSheetChildItems" runat="server" Visible="false" OnItemCommand="rptrTimeSheetChildItems_ItemCommand" OnItemDataBound="rptrTimeSheetChildItems_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center visible-lg">Project ID</th>
                                        <th class="text-center visible-lg">Project Name</th>
                                        <th class="text-center visible-lg">Date</th>
                                        <th class="text-center visible-lg">Hour</th>
                                        <th class="text-center hidden-xs">Remarks</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a>    </td>


                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblProjectId" Text='<%#Eval("project_id")%>' runat="server"> </asp:Label>
                                </td>
                                 <td class="visible-lg text-center">
                                    <asp:Label ID="lblProjectName" Text='<%#Eval("project_name")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="visible-lg text-center">
                                    <asp:Label ID="lblDate" Text='<%#Eval("date","{0: dd/MM/yyyy}")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="hidden-xs text-center">
                                    <asp:Label ID="lblHours" Text='<%#Eval("hours")%>' runat="server"></asp:Label>
                                </td>
                                <td class="hidden-xs text-center">
                                    <asp:Label ID="lblRemarks" Text='<%#Eval("Remarks")%>' runat="server"></asp:Label>

                                </td>

                                <td class=" text-center">
                                    <div class="btn-group btn-group-xs">
                                        <asp:LinkButton ID="btndelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("project_id")%>' CssClass="btn btn-xs btn-danger text-center" data-toggle="tooltip" data-placement="bottom" title="Click to delete" data-original-title="Basic tooltp"><i class="fa fa-times"></i></asp:LinkButton>
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
                    <div class="form-group form-actions" style="float: right">
                        <asp:Button ID="BtnReset" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                        
                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Add Time Sheet" OnClick="btnSubmit_Click" CssClass="btn btn-sm btn-primary">Add Time Sheet</asp:LinkButton>

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
