<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="manage-time-sheet-employee-detail.aspx.cs" Inherits="AASGWeb.Modules.Admin.manage_time_sheet_employee_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-content">
        <!-- eCommerce Order View Header -->
        <div class="content-header">
           <ul class="nav-horizontal text-center">
                <li class="active">
                    <a href="/home"><i class="fa fa-home"></i>Home</a>
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
                    <a href="/manage-sale-orders"><i class="fa fa-rupee"></i>SaleOrders</a>
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

       
        <!-- Addresses -->
        
        <!-- END Addresses -->

        <!-- Products Block -->
        <div class="block">
            <!-- Products Title -->
            <div class="block-title">
                <h2><i class="fa fa-shopping-cart"></i><strong> Hours Details</strong></h2>
            </div>
            <!-- END Products Title -->

            <!-- Products Content -->
            <div class="table-responsive">
                <div class="table-responsive">
                

                <asp:Repeater ID="rptrTimeSheetDetailEmployee" runat="server" OnItemCommand="rptrTimeSheetDetailEmployee_ItemCommand" OnItemDataBound="rptrTimeSheetDetailEmployee_ItemDataBound">
                    <HeaderTemplate>
                        <table id="ecom-orders" class="table table-bordered table-vcenter">
                            <thead>
                                <tr>
                                    <th class="text-center" style="width: 20px;">ID</th>
                                    <th class="text-left">Project Name</th>
                                    <th class="text-center" style="width: 20%;">Date</th>
                                    <th class="text-center" style="width: 30%;">Hour</th>
                                    <th class="text-left" >Remarks</th>
                                   

                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                             <td class="text-center"><a href="#"><strong><%# Container.ItemIndex + 1 %></strong></a>   

                             </td>


                            <td class="text-left " >
                                <asp:Label ID="lblProjectName" Text='<%#Eval("project_name")%>' runat="server" CssClass="label label-success"> </asp:Label>
                            </td>

                            <td class="text-center" style="width: 20%;">
                                <asp:Label ID="lblDate" Text='<%#Eval("time_sheet_date","{0: dd/MM/yyyy}")%>' runat="server"> </asp:Label>
                            </td>
                            <td class="text-center" style="width: 30%;">
                                <asp:Label ID="lblhours" Text='<%#Eval("hours")%>' runat="server"></asp:Label>
                            </td>
                            <td class="text-left">
                                <asp:Label ID="lblRemarks" Text='<%#Eval("remarks")%>' runat="server"></asp:Label>

                            </td>
                            

                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>         
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hdfdTimeSheetHeaderId" runat="server" />

            </div>

               

            </div>
            <!-- END Products Content -->
        </div>
        <!-- END Products Block -->


        <!-- Log Block -->
       
            <!-- END Log Content -->
        </div>
        <!-- END Log Block -->

    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
