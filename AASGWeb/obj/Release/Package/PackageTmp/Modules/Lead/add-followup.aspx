<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="add-followup.aspx.cs" Inherits="AASGWeb.Modules.Lead.add_followup" %>
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
                                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Leads </a>
                                        </div>
                                        <h2><strong>FollowUp</strong>  Master</h2>
                                    </div>
                                    <!-- END Normal Form Title -->

                                    <!-- Normal Form Content -->
                        <asp:HiddenField ID="hdnId" runat="server" />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="ddlPartyName">Client Name <span class="text-danger">*</span></label>
                                  <asp:DropDownList ID="ddlPartyName" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose Party">
                                       <asp:ListItem></asp:ListItem>
                                  </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label for="txtFollowUpDate">Follow Up Date</label>
                                    <asp:TextBox ID="txtFollowUpDate" runat="server" CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                
                                <label for="txtFollowUpText">Follow Up Texts <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtFollowUpText" runat="server" CssClass="form-control" placeholder="Enter Follow-Up-Text "></asp:TextBox>
                            </div>
                        </div> 
                        <div class="col-md-3">
                            <div class="form-group">
                                
                                <label for="txtNextFollowUpDate">Follow Up New Date <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtNextFollowUpDate" runat="server" CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>
                                
                            </div>
                        </div>
                    </div>
                    <div class="row">
                       
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="txtSpecialRemarks">Special Remarks <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtSpecialRemarks" runat="server" CssClass="form-control" placeholder="Enter Remarks" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                 <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-sm btn-warning" OnClick="btnReset_Click" />
                                  <asp:Button ID="btnAddFollowUp" runat="server" Text="Add FollowUp" class="btn btn-sm btn-primary" OnClientClick="return validateFollowupinfo();" OnClick="btnAddFollowUp_Click" />
                            </div>
                        </div>
                    </div>
                            <!-- END Normal Form Content -->
                                </div>
                            <!-- END Normal Form Block -->

                               
                            </div>
                        </div>
                        <!-- END All Role Block -->
                </div>
                <!-- END Page Content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
