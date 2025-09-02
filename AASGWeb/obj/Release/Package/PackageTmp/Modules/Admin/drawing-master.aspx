<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="drawing-master.aspx.cs" Inherits="AASGWeb.Modules.Admin.drawing_master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#ContentPlaceHolder1_imagePreview').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

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

                <asp:HiddenField ID="hdfdrawingMasterId" runat="server" />
                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                         <%--   <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Roles </a>--%>
                        </div>
                        <h2><strong>Add</strong> Drawing Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <div class="row">
                        <div class="col-md-9">
                            <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtDrawingName">Drawing Name<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDrawingName" runat="server" CssClass="form-control" placeholder="Enter Role Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtDrawingType">Drawing Type<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDrawingType" runat="server" CssClass="form-control" placeholder="Enter Role Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txtDrawingAlias">Drawing Alias</label>
                                <asp:TextBox ID="txtDrawingAlias" runat="server" CssClass="form-control" placeholder="Enter Role Name"></asp:TextBox>
                            </div>
                        </div>

                             <div class="col-md-12">
                            <div class="form-group">
                                <label for="txtDrawingDescription">Drawing Description<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtDrawingDescription" runat="server" CssClass="form-control" placeholder="Enter Role Name"></asp:TextBox>
                            </div>
                        </div>

                            <div class="col-md-12">
                            <div class="form-group">
                                <label for="ddlItemName">Select Items<span class="text-danger">*</span></label>
                                <asp:ListBox ID="ddlItemName" runat="server" CssClass="select-chosen select2 " placeholder="Select Items " SelectionMode="Multiple">
                                      <asp:ListItem></asp:ListItem>
                                 </asp:ListBox>
                            </div>
                        </div>




                        </div>
                        
                        <div class="col-md-3">
                            <div class="block full ">
                                <!-- Upload Picture -->
                                <div class="block-title">
                                    <h2><i class="fa fa-image"></i> Picture  <strong></strong></h2>
                                </div>
                                <div class="dz-default dz-message">
                                    <asp:Image ID="imagePreview" runat="server" ImageUrl="/Content/img/default-image.jpg" Width="100%" Height="160px" alt="Person Picture" />
                                </div>

                                <asp:FileUpload ID="fuUploadedFile" runat="server" Style="border: 1px solid #dbe1e8; width: 100%; border-radius: 3px; padding: 3px; margin-top: 10px" CssClass="form-control-file profile-picture" onchange="ShowImagePreview(this);" />

                                <!-- END Upload Picture -->
                            </div>

                        </div>
                       
                    </div>
                   
                    

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float: right">
                                <asp:LinkButton ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-sm btn-warning" OnClick="btnReset_Click" >Reset</asp:LinkButton>
                                <asp:LinkButton ID="btnUpdateItems" runat="server" Visible="false" Text="Update Drawing"  CssClass="btn btn-sm btn-success" OnClick="btnUpdateItems_Click">Update Drawing</asp:LinkButton>
                                <asp:LinkButton ID="btnAddSelectedItems" runat="server" Text="Add Drawing"  OnClick="btnAddSelectedItems_Click" CssClass="btn btn-sm btn-primary">Add Drawing</asp:LinkButton>

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
