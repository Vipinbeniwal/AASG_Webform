<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="manage-tour-expense.aspx.cs" Inherits="AASGWeb.Modules.Admin.manage_tour_expense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Page content -->
                <div id="page-content">
                    <!-- Dashboard 2 Header -->
                    <div class="content-header">
                        <ul class="nav-horizontal text-center">
                            <li class="active">
                                <a href="javascript:void(0)"><i class="fa fa-home"></i> Home</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-charts"></i> Create Bill</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-briefcase"></i> Production</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-video_hd"></i> Returns</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="gi gi-music"></i> SaleOrders</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cubes"></i> Accounts</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-pencil"></i> Challans</a>
                            </li>
                            <li>
                                <a href="javascript:void(0)"><i class="fa fa-cogs"></i> Settings</a>
                            </li>
                        </ul>
                    </div>
                    <!-- END Dashboard 2 Header -->
                     
                        <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                 <%--   <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                                </div>
                                <h2><strong>All</strong> Expense Tours</h2>
                            </div>
                            <!-- END All Orders Title -->
                              <asp:HiddenField ID="hdnId" runat="server" />
                              <!-- All Orders Content -->
                            <div class="table-responsive">

                            <asp:Repeater ID="rptrTotalTourExpense" runat="server" OnItemCommand="rptrTotalTourExpense_ItemCommand" OnItemDataBound="rptrTotalTourExpense_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                
                                <th class="text-center">ID</th>
                                <th class="text-center">Request Date</th>
                                 <th class="text-center">Employee Name</th>
                                <th class="text-center">Tour Name</th>
                                <th class="text-center">Food Exp</th> 
                                <th class="text-center">Hotel Exp</th>
                                <th class="text-center">Conveyance Exp</th>
                                <th class="text-center">Misc Exp</th>
                                 <th class="text-center">Total Exp</th>
                              
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                       
                        <td class="text-center">
                            <asp:Label ID="lblTourExpenseHeaderId" Text='<%#Eval("tour_expense_header_id")%>' runat="server"></asp:Label>
                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblStartDate" Text='<%# DataBinder.Eval(Container.DataItem, "created_on","{0:d}")%>' runat="server"></asp:Label>
                        </td>
                         <td class="text-center">
                            <asp:Label ID="Label1" Text='<%#Eval("tour_name")%>' runat="server"></asp:Label>
                        </td>
                         <td class="text-center">
                            <asp:Label ID="lblTourName" Text='<%#Eval("tour_name")%>' runat="server"></asp:Label>
                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpenseFood" Text='<%#Eval("expense_food_total")%>' runat="server"></asp:Label>

                        </td>
                          <td class="text-center">
                            <asp:Label ID="lblTotalExpenseHotel" Text='<%#Eval("expense_hotel_total")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpenseConveyance" Text='<%#Eval("expense_conveyance_total")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpenseMisc" Text='<%#Eval("expense_misc_total")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpense" Text='<%#Eval("expense_total")%>' runat="server"></asp:Label>

                        </td>
                       
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>         
                </FooterTemplate>
            </asp:Repeater>
                            <asp:HiddenField ID="hdfdPurchaseItemId" runat="server" />

                            </div>
            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
