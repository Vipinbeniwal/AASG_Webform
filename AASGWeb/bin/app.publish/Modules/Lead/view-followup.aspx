<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="view-followup.aspx.cs" Inherits="AASGWeb.Modules.Lead.view_followup" %>
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
                            <div class="col-sm-4 col-lg-4">
                                <div class="widget">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light "> <strong>Party Name</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h4 text-primary animation-expandOpen text-uppercase"><asp:Label ID="lblPartyName" runat="server" Text="Joginder"></asp:Label></span></div>
                                </div>
                               
                            </div>
                            <div class="col-sm-4 col-lg-4">
                                <div class="widget">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light"> <strong>Follow Up Date</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h4 text-primary animation-expandOpen"><asp:Label ID="lblleadFollowUpDate" runat="server" Text="Follow-Up-Date"></asp:Label></span></div>
                                </div>
                            </div>
                            <div class="col-sm-4 col-lg-4">
                                <div class="widget">
                                    <div class="widget-extra themed-background">
                                        <h4 class="widget-content-light"> <strong>Follow Up Text</strong></h4>
                                    </div>
                                    <div class="widget-extra-full"><span class="h4 text-primary animation-expandOpen"><asp:Label ID="lblleadFollowUpText" runat="server" Text="Follow-Up-Text"></asp:Label></span></div>
                                </div>
                            </div>
                             
                        </div>
        <!-- END Order Status -->
         <asp:HiddenField ID="hdnId" runat="server" />
        <!-- Products Block -->
        <div class="block">
            <!-- Products Title -->
            <div class="block-title">
                <h2><i class="fa fa-shopping-cart"></i><strong>FollowUp Details</strong></h2>
            </div>
            <!-- END Products Title -->

            <!-- Products Content -->
            
                
            <div class="table-responsive">
                 <asp:Repeater ID="rptrFollowUpDetail" runat="server" OnItemCommand="rptrFollowUpDetail_ItemCommand" OnItemDataBound="rptrFollowUpDetail_ItemDataBound">
                <HeaderTemplate>
                    <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                        <thead>
                            <tr>
                                
                                <th class="text-center visible-lg">ID</th>
                                <th class="text-center hidden-xs">Follow Up Date</th>
                                <th class="text-center hidden-xs">Follow Up Text</th>
                                <th class="text-center hidden-xs">Follow Up Next Date</th>
                               <th class="text-center hidden-xs">Special Remarks</th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align:center;"><%# Container.ItemIndex + 1 %>    </td>
                       
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblFollowUpDate" Text='<%#Eval("followup_date","{0:d}")%>' runat="server"></asp:Label>
                        </td>
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblFollowUpText" Text='<%# DataBinder.Eval(Container.DataItem, "followup_text","{0:d}")%>' runat="server"></asp:Label>
                        </td> 
                        <td class="hidden-xs text-center">
                            <asp:Label ID="lblFollowUpNextDate" Text='<%#Eval("next_followup_date","{0:d}")%>' runat="server"></asp:Label>

                        </td>
                          <td class="hidden-xs text-center">
                            <asp:Label ID="lblSpecialRemarks" Text='<%#Eval("special_remarks")%>' runat="server"></asp:Label>

                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </table>         
                    </FooterTemplate>
            </asp:Repeater>
            </div>
               
                <asp:HiddenField ID="hdfdPurchaseNumber" runat="server" />

           
            <!-- END Products Content -->
           

        </div>
        <!-- END Products Block -->


    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
