<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="item-summary.aspx.cs" Inherits="AASGWeb.Modules.Production.item_summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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

        
        <!-- Log Block -->
                        <div class="block">
                            <!-- Log Title -->
                            <div class="block-title">
                                <h2><i class="fa fa-file-text-o"></i> <strong>Item</strong> Status Summary</h2>
                                <asp:Label ID="lblItemName" CssClass="label label-primary" Text="Maruti Wind Screen" runat="server" />
                                
                            </div>
                            <!-- END Log Title -->

                            <!-- Log Content -->
                            <%--<div class="table-responsive">
                                <table class="table table-bordered table-vcenter">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Store</span>
                                            </td>
                                            <td class="text-center">October 24, 2014 - 16:00</td>
                                            <td><a href="#">Kunal</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Item Updated to the Store with Total Pcs-117, Rejected-0</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Store</span>
                                            </td>
                                            <td class="text-center">October 24, 2014 - 12:15</td>
                                            <td><a href="#">Kunal</a></td>
                                            <td class=""><i class=""></i> <strong>Item Recieved to the Store with Total Pcs-117, Rejected-0</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Packing</span>
                                            </td>
                                            <td class="text-center">October 24, 2014 - 12:00</td>
                                            <td><a href="#">Shyam</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Packing Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Packing</span>
                                            </td>
                                            <td class="text-center">October 24, 2014 - 10:15</td>
                                            <td><a href="#">Shyam</a></td>
                                            <td class=""><i class=""></i> <strong>Packing Started with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Tempring</span>
                                            </td>
                                            <td class="text-center">October 23, 2014 - 12:00</td>
                                            <td><a href="#">Rohan</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Tempring Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Tempring</span>
                                            </td>
                                            <td class="text-center">October 23, 2014 - 10:15</td>
                                            <td><a href="#">Rohan</a></td>
                                            <td class=""><i class=""></i> <strong>Tempring Started with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">DFG</span>
                                            </td>
                                            <td class="text-center">October 22, 2014 - 12:00</td>
                                            <td><a href="#">Mridhul</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>DFG Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">DFG</span>
                                            </td>
                                            <td class="text-center">October 22, 2014 - 10:15</td>
                                            <td><a href="#">Mridhul</a></td>
                                            <td class=""><i class=""></i> <strong>DFG Started with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-default">Paint</span>
                                            </td>
                                            <td class="text-center">October 21, 2014 - 12:00</td>
                                            <td><a href="#">Karan</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Paint Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-default">Paint</span>
                                            </td>
                                            <td class="text-center">October 21, 2014 - 10:15</td>
                                            <td><a href="#">Karan</a></td>
                                            <td class=""><i class=""></i> <strong>Paint Started with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-default">Washing</span>
                                            </td>
                                            <td class="text-center">October 20, 2014 - 12:00</td>
                                            <td><a href="#">Ashok</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Washing Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-default">Washing</span>
                                            </td>
                                            <td class="text-center">October 20, 2014 - 10:15</td>
                                            <td><a href="#">Ashok</a></td>
                                            <td class=""><i class=""></i> <strong>Washing Started with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-warning">Hole</span>
                                            </td>
                                            <td class="text-center">October 17, 2014 - 12:00</td>
                                            <td><a href="#">Harish</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Hole Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-warning">Hole</span>
                                            </td>
                                            <td class="text-center">October 17, 2014 - 10:15</td>
                                            <td><a href="#">Harish</a></td>
                                            <td class=""><i class=""></i> <strong>Hole Started with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Grinding</span>
                                            </td>
                                            <td class="text-center">October 16, 2014 - 17:15</td>
                                            <td><a href="#">Deepak</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i> <strong>Grinding Submitted with Total Pcs-117, Rejected-0, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-success">Grinding</span>
                                            </td>
                                            <td class="text-center">October 16, 2014 - 09:10</td>
                                            <td><a href="#">Deepak</a></td>
                                            <td class=""><i class=""></i> <strong>Grinding Started</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Cutting</span>
                                            </td>
                                            <td class="text-center">October 15, 2014 - 12:26</td>
                                            <td><a href="#">Joginder</a></td>
                                            <td class="text-success"><i class="fa fa-fw fa-check"></i><strong>Cutting Submitted with Total Pcs-120, Rejected-3, Total Transfer-117</strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="label label-primary">Cutting</span>
                                            </td>
                                            <td class="text-center">October 15, 2014 - 12:15</td>
                                            <td><a href="#">Joginder</a></td>
                                            <td><strong>Cutting Started</strong></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>--%>


                        <div class="table-responsive">
                        <asp:HiddenField ID="hdnId" runat="server" />
                        <asp:Repeater ID="rptrProductionItemSummary" runat="server" OnItemDataBound="rptrProductionItemSummary_ItemDataBound">
                            <HeaderTemplate>
                            <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <%--<thead>
                                    <tr>
                                        
                                        <th class="text-left">Process Name</th> 
                                        <th class="text-left">Date</th>
                                        <th class="text-left">User Name</th>
                                        <th class="text-left">activity</th>
                                    </tr>
                                </thead>--%>
                                 </HeaderTemplate>
                             <ItemTemplate>
                                <tr>
                                   <%-- <td style="text-align:left;"><%# Container.ItemIndex + 1 %>    </td>--%>
                                    <td style="text-align:left;" ><asp:Label ID="lblProcessName" Text='<%#Eval("process_name")%>' CssClass="label label-primary" runat="server" /></td>
                                    <td style="text-align:left;"><asp:Label ID="lbUserName" Text='<%#Eval("created_on","{0:dd MMM yyyy hh:mm:ss tt}")%>'  runat="server" /></td>
                                    <td style="text-align:left;"><asp:Label ID="Label1" Text='<%#Eval("user_name")%>' CssClass="text-primary" runat="server" /></td>
                                    <td style="text-align:left;"><asp:Label ID="lblActivity" Text='<%#Eval("activity")%>' CssClass="text-primary" runat="server" /></td> 
                                    <%--<td style="text-align:left;"><%# DataBinder.Eval(Container.DataItem, "user_name")%> </td>--%>
                                      
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>         
                            </FooterTemplate>
                        </asp:Repeater>
                             <asp:HiddenField ID="hdfdpartyId" runat="server" />

                         </div>

                            <!-- END Log Content -->
                        </div>
                        <!-- END Log Block -->
        
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
