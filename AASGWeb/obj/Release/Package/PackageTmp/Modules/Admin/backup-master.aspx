<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="backup-master.aspx.cs" Inherits="AASGWeb.Modules.Admin.backup_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .MySuccess {
            color: green;
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
        <!-- END Dashboard 2 Header -->
        <!-- END Dashboard 2 Header -->
        <ul class="breadcrumb breadcrumb-top">
            <li>Feature Master</li>
            <li><a href="#">Create Backup</a></li>
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
                        <h2><strong>Backup </strong>Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <h2>Create Backup</h2>

                                <asp:LinkButton ID="btnBackup" runat="server" class="btn btn-primary" OnClick="btnBackup_Click"> Create Backup </asp:LinkButton><br />

                                <asp:Label ID="lblMessage" runat="server" CssClass="lead MySuccess"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <h2>Download Backup</h2>
                                <a href="../../assets/dbbackup/aasgweb.zip" runat="server" download="db-Backup">Click to downlaod Zip</a>
                            </div>
                            
                        </div>
                        <div class="col-md-4">
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
