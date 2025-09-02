<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="add-employee.aspx.cs" Inherits="AASGWeb.Modules.Admin.add_employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        //Image Pancard Upload Preview  
        function ShowPanCardImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#ContentPlaceHolder1_PancardImagePreview').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }


        //Image Upload Preview  
        function ShowAadharFrontImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#ContentPlaceHolder1_AadharFrontImagePreview').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }


        //Image Upload Preview  
        function ShowAadharBackImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#ContentPlaceHolder1_AadharBackImagePreview').prop('src', e.target.result);
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
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">All Employees </a>
                        </div>
                        <h2><strong>Employee</strong>  Master</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <div id="faq1" class="panel-group">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q1">General Detail Form</a></h4>
                            </div>
                            <div id="faq1_q1" class="panel-collapse collapse in">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="example-nf-email">Employee Id <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="form-control" placeholder="Enter Employee Id"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Employee Name <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" onkeypress="return character_and_Number(event)" placeholder="Enter Employee Name"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Email Id <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>

                                            </div>

                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Mobile <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Mobile" MaxLength="10" Minlength="10"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">

                                                <label for="example-nf-password">Designation <span class="text-danger">*</span></label>
                                                <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose a Designation..">
                                                    <asp:ListItem></asp:ListItem>
                                                    <%-- <asp:ListItem Value="1">Designation</asp:ListItem>
                                                    <asp:ListItem Value="2">Item Type</asp:ListItem>--%>
                                                </asp:DropDownList>

                                            </div>

                                        </div>
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Joinning Date <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtJoinningDate" runat="server" CssClass="form-control input-datepicker-close" onkeypress="return DateValidation(event)" data-date-format="dd/mm/yyyy" placeholder="dd/mm/yyyy"></asp:TextBox>

                                            </div>

                                        </div>


                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Grade<span class="text-danger">*</span></label>
                                                <%--  <asp:TextBox ID="txtGrade" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlGrade" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose Grade..">
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>

                                        </div>
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="ddlUserRole">Role<span class="text-danger">*</span></label>
                                                <%--  <asp:TextBox ID="txtGrade" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlUserRole" runat="server" CssClass="select-chosen" AutoPostBack="false" data-placeholder="Choose Role..">
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>

                                        </div>

                                    </div>


                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-actions" style="float: right">
                                                <asp:Button ID="BtnResetGeneralForm" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnResetGeneralForm_Click" />
                                                <asp:LinkButton ID="btnUpdateGeneralForm" runat="server" Text="Update and Next" OnClientClick="return validateStaffinfo();" Visible="false" OnClick="btnUpdateGeneralForm_Click" CssClass="btn btn-sm btn-success">Update and Next</asp:LinkButton>
                                                <asp:LinkButton ID="btnSubmitGeneralForm" runat="server" Text="Save and Next" OnClientClick="return validateStaffinfo();" OnClick="btnSubmitGeneralForm_Click" CssClass="btn btn-sm btn-primary">Save and Next</asp:LinkButton>

                                            </div>
                                        </div>


                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q2">Address Detail Form</a></h4>
                            </div>
                            <div id="faq1_q2" class="panel-collapse collapse">
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-md-12">

                                            <div class="form-group">
                                                <label for="example-nf-email">Current Address <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtCurrentAddress" runat="server" CssClass="form-control" placeholder="Enter Current Address"></asp:TextBox>

                                            </div>

                                        </div>



                                    </div>
                                    <div class="row">

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Current City <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtCurrentCity" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Current City"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Current State <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtCurrentState" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Current State"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Current Pincode <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtCurrentPincode" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Current Pincode"></asp:TextBox>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">

                                            <div class="form-group">
                                                <label for="example-nf-email">Permanent Address <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" placeholder="Enter Permanent Address"></asp:TextBox>

                                            </div>

                                        </div>



                                    </div>
                                    <div class="row">

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Permanent City <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPermanentCity" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Permanent City"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Permanent State <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPermanentState" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Permanent State"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Permanent Pincode <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPermanentPincode" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Permanent Pincode"></asp:TextBox>

                                            </div>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-actions" style="float: right">
                                                <asp:Button ID="BtnResetAddressForm" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnResetAddressForm_Click" />
                                                <asp:LinkButton ID="btnUpdateAddressForm" runat="server" Text="Update and Next" Visible="false" OnClick="btnUpdateAddressForm_Click" CssClass="btn btn-sm btn-success">Update and Next</asp:LinkButton>
                                                <asp:LinkButton ID="btnSubmitAddressForm" runat="server" Text="Save and Next" OnClick="btnSubmitAddressForm_Click" CssClass="btn btn-sm btn-primary">Save and Next</asp:LinkButton>

                                            </div>
                                        </div>


                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-angle-right"></i><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq1" href="#faq1_q3">Bank/Other Document Details Form</a></h4>
                            </div>
                            <div id="faq1_q3" class="panel-collapse collapse">
                                <div class="panel-body">

                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Bank Name <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control" onkeypress="return character(event)" placeholder="Enter Bank Name"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">Account Number <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtBankAccountNumber" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter Account Number"></asp:TextBox>

                                            </div>

                                        </div>

                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">IFSC Code <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtIfscCode" runat="server" CssClass="form-control" onkeypress="return character_and_Number(event)" placeholder="Enter IFSC Code"></asp:TextBox>

                                            </div>

                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">PanCard Number <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPancardNumber" runat="server" CssClass="form-control" onkeypress="return character_and_Number(event)" placeholder="Enter PanCard Number"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="col-md-4">

                                            <div class="form-group">
                                                <label for="example-nf-email">AadharCard Number <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtAadharNumber" runat="server" CssClass="form-control" onkeypress="return Number(event)" placeholder="Enter PanCard Number"></asp:TextBox>

                                            </div>

                                        </div>




                                    </div>

                                    <div class="row">

                                        <div class="col-md-4">
                                            <div class="block full hidden-xs">
                                                <!-- Upload Title -->
                                                <div class="block-title">
                                                    <h2><i class="fa fa-cloud-upload"></i>Pancard Image <strong>Preview</strong></h2>
                                                </div>
                                                <!-- END Upload Title -->
                                                <!-- Upload Content -->
                                                <div class="dz-default dz-message">
                                                    <asp:Image ID="PancardImagePreview" runat="server" ImageUrl="/Content/img/default-image.jpg" Width="100%" Height="180px" />
                                                </div>
                                                <asp:FileUpload ID="fuUploadedFilePanCard" runat="server" CssClass="form-control" onchange="ShowPanCardImagePreview(this);" />
                                                <!-- END Upload Content -->
                                            </div>

                                        </div>



                                        <div class="col-md-4">
                                            <div class="block full hidden-xs">
                                                <!-- Upload Title -->
                                                <div class="block-title">
                                                    <h2><i class="fa fa-cloud-upload"></i>AadharCard Front Image <strong>Preview</strong></h2>
                                                </div>
                                                <!-- END Upload Title -->
                                                <!-- Upload Content -->
                                                <div class="dz-default dz-message">
                                                    <asp:Image ID="AadharFrontImagePreview" runat="server" ImageUrl="/Content/img/default-image.jpg" Width="100%" Height="180px" />
                                                </div>
                                                <asp:FileUpload ID="fuUploadedFileAadharFront" runat="server" CssClass="form-control" onchange="ShowAadharFrontImagePreview(this);" />
                                                <!-- END Upload Content -->
                                            </div>

                                        </div>

                                        <div class="col-md-4">
                                            <div class="block full hidden-xs">
                                                <!-- Upload Title -->
                                                <div class="block-title">
                                                    <h2><i class="fa fa-cloud-upload"></i>AadharCard Back Image <strong>Preview</strong></h2>
                                                </div>
                                                <!-- END Upload Title -->
                                                <!-- Upload Content -->
                                                <div class="dz-default dz-message">
                                                    <asp:Image ID="AadharBackImagePreview" runat="server" ImageUrl="/Content/img/default-image.jpg" Width="100%" Height="180px" />
                                                </div>
                                                <asp:FileUpload ID="fuUploadedFileAadharBack" runat="server" CssClass="form-control" onchange="ShowAadharBackImagePreview(this);" />
                                                <!-- END Upload Content -->
                                            </div>

                                        </div>


                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group form-actions" style="float: right">
                                                <asp:Button ID="BtnResetDocumentForm" CssClass="btn btn-sm btn-warning" type="reset" runat="server" Text="Reset" OnClick="BtnResetDocumentForm_Click" />
                                                <asp:LinkButton ID="btnUpdateDocumentForm" runat="server" Text="Update and Next" Visible="false" OnClick="btnUpdateDocumentForm_Click" CssClass="btn btn-sm btn-success">Update and Next</asp:LinkButton>
                                                <asp:LinkButton ID="btnSubmitDocumentForm" runat="server" Text="Save and Next" OnClick="btnSubmitDocumentForm_Click" CssClass="btn btn-sm btn-primary">Save and Next</asp:LinkButton>

                                            </div>
                                        </div>


                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                    <%--<div class="col-md-3">
                        <div class="block full hidden-xs">
                                    <!-- Upload Title -->
                                    <div class="block-title">
                                        <h2><i class="fa fa-cloud-upload"></i> Image <strong>Preview</strong></h2>
                                    </div>
                                    <!-- END Upload Title -->
                                    <!-- Upload Content -->
                                  <div class="dz-default dz-message">
                                    <asp:Image ID="imagePreview" runat="server" ImageUrl="/assets/default-image.jpg" Width="100%" Height="180px" />
                                    </div>
                                        <asp:FileUpload ID="fuUploadedFile" runat="server" CssClass="form-control" onchange="ShowImagePreview(this);" />
                                    <!-- END Upload Content -->
                                </div>
                       
                        </div>--%>


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
