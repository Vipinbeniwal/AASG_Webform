<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="view-tour-expense.aspx.cs" Inherits="AASGWeb.Modules.Admin.view_tour_expense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-content">
        <!-- eCommerce Order View Header -->
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
        <!-- END eCommerce Order View Header -->
        
        <!-- Order Status -->
         <div class="row text-center">
                            <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light "> <strong>Employee Name</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen text-uppercase"><asp:Label ID="lblStaffName" runat="server" Text="Joginder"></asp:Label></span></div>
                                </div>
                               
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"> <strong>Grade</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen"><asp:Label ID="lblGrade" runat="server" Text="Grade A"></asp:Label></span></div>
                                </div>
                            </div>
                             <div class="col-sm-6 col-lg-3">
                                 <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"><strong>Tour Name</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen">
                                        <asp:Label ID="lblTourName" runat="server" Text="Rohtak To Delhi"></asp:Label></span></div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-lg-3">
                                <div class="widget">
                                    <div class="widget-extra themed-background-success">
                                        <h4 class="widget-content-light"> <strong>Days</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h2 text-success animation-expandOpen"><asp:Label ID="lblTourDays" runat="server" Text="2"></asp:Label></span></div>
                                </div>
                            </div>
                        </div>
        <!-- END Order Status -->
         <asp:HiddenField ID="hdnId" runat="server" />
        <!-- Products Block -->
        <div class="block">
            <!-- Products Title -->
            <div class="block-title">
                <h2><i class="fa fa-shopping-cart"></i><strong>Expense Details</strong></h2>
            </div>
            <!-- END Products Title -->

            <!-- Products Content -->
            <div class="table-responsive">
                

                <asp:Repeater ID="rptrTotalTourExpenseDetail" runat="server" OnItemCommand="rptrTotalTourExpenseDetail_ItemCommand" OnItemDataBound="rptrTotalTourExpenseDetail_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                
                                <th class="text-center">ID</th>
                                <th class="text-center">Dated</th>
                                <%--<th class="text-center">Tour Name</th>--%>
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
                            <asp:Label ID="lblTourExpenseHeaderId" Text='<%#Eval("tour_expense_item_id")%>' runat="server"></asp:Label>
                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblStartDate" Text='<%# DataBinder.Eval(Container.DataItem, "expense_date","{0:d}")%>' runat="server"></asp:Label>
                        </td>
                         <%--<td class="text-center">
                            <asp:Label ID="lblTourName" Text='<%#Eval("tour_name")%>' runat="server"></asp:Label>
                        </td>--%>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpenseFood" Text='<%#Eval("expense_food")%>' runat="server"></asp:Label>

                        </td>
                          <td class="text-center">
                            <asp:Label ID="lblTotalExpenseHotel" Text='<%#Eval("expense_hotel")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpenseConveyance" Text='<%#Eval("expense_conveyance")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpenseMisc" Text='<%#Eval("expense_misc")%>' runat="server"></asp:Label>

                        </td>
                        <td class="text-center">
                            <asp:Label ID="lblTotalExpense" Text='<%#Eval("expense_total_item")%>' runat="server"></asp:Label>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        <tr>
                            <td colspan="2" class="text-right text-uppercase"><strong>Total:</strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblTotalFoodPrice" runat="server" Text="0"></asp:Label>
                            </strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblTotalHotelPrice" runat="server" Text="0"></asp:Label>

                            </strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblTotalConveyancePrice" runat="server" Text="0"></asp:Label>

                            </strong></td>
                             <td class="text-center"><strong>
                                <asp:Label ID="lblTotalMiscPrice" runat="server" Text="0"></asp:Label>

                            </strong></td>
                             <td class="text-center"><strong>
                                <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>

                            </strong></td>
                             
                        </tr>
                        
                    <tr>
                            <td colspan="2" class="text-right text-uppercase"><strong><span class="text-success"><asp:Label ID="lblTourGradeName" runat="server" Text="0"></asp:Label></span> wise Approvals :</strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblApprovedFoodExp" runat="server" Text="0"></asp:Label>
                            </strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblApprovedHotelExp" runat="server" Text="0"></asp:Label>

                            </strong></td>
                            <td class="text-center"><strong>
                                <asp:Label ID="lblApprovedConveyanceExp" runat="server" Text="0"></asp:Label>

                            </strong></td>
                             <td class="text-center"><strong>
                                <asp:Label ID="lblApprovedMiscExp" runat="server" Text="0"></asp:Label>

                            </strong></td>
                             <td class="text-center"><strong>
                                <asp:Label ID="lblApprovedExp" runat="server" Text="0"></asp:Label>
                            </strong></td> 
                        </tr>
                        </table>         
                    </FooterTemplate>
            </asp:Repeater>
                <asp:HiddenField ID="hdfdPurchaseNumber" runat="server" />

            </div>
            <!-- END Products Content -->
             <div class="row form-group">
                    <div class="col-md-2">
                            <%--<div class="form-group">--%>
                                <label for="example-nf-email">Approved Amount <span class="text-danger">*</span></label>
                               
                            <%--</div>--%>
                    </div>
                 <div class="col-md-2">
                      <asp:TextBox ID="txtApprovedAmount" runat="server" CssClass="form-control" placeholder="Approved Amount" Text="0.0"></asp:TextBox>
                 </div>
                  <div class="col-md-2">
                      <asp:Button ID="btnApprovedAmount" runat="server" Text="Tour Amount Approved" CssClass="btn btn-success" OnClick="btnApprovedAmount_Click"/>
                 </div>
             </div>

        </div>
        <!-- END Products Block -->


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
