<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="pending-expense.aspx.cs" Inherits="AASGWeb.Modules.Account.pending_expense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

                <!-- Normal Form Block -->
                <div class="block">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">Assign Tour </a>
                        </div>
                        <h2><strong>Pending</strong> Expense </h2>
                    </div>
                    <!-- END Normal Form Title -->

                    <!-- Normal Form Content -->
                    <div class="row">
                           <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Employee Name <span class="text-danger">*</span></label>
                                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control">
                                        <asp:ListItem Selected="0"> Select</asp:ListItem>
                                        <asp:ListItem  Value="1"> Emp 1</asp:ListItem>
                                        <asp:ListItem  Value="2"> Emp 2</asp:ListItem>
                                        <asp:ListItem  Value="3"> Emp 3</asp:ListItem>
                                        <asp:ListItem  Value="4"> Emp 4</asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                            </div>
                         <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Department<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" placeholder="Enter Department"></asp:TextBox>

                                </div>

                            </div>
                        
                         <div class="col-md-4">
                              <div class="form-group">
                                    <label for="example-nf-email">Approved By <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtApprovedEmpName" runat="server" CssClass="form-control" placeholder="Approved By"></asp:TextBox>

                                </div>

                            </div>
                        
                    
                    </div>
             
                    <div class="row">
                            <div class="col-md-4">
                           
                                <div class="form-group">
                                    <label for="example-nf-email">Date Submitted<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" placeholder="Enter Date"></asp:TextBox>

                                </div>

                            </div>
                    </div>

                     <!-- All Orders Block -->
                        <div class="block full">
                            <!-- All Orders Title -->
                            <div class="block-title">
                                <div class="block-options pull-right">
                                    <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>
                                </div>
                                <h2><strong>All</strong>Expenses</h2>
                            </div>
                            <!-- END All Orders Title -->

                            <!-- All Orders Content -->
                           <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">ID</th>
                                        <th class="text-center visible-lg">Tour Name</th>
                                        <th class="text-center">Description of Expense</th>
                                        <th class="text-right">Transportation</th>
                                        <th class="text-right">Miles</th>
                                        <th class="text-right">Meals</th>
                                        <th class="text-right">Other Expense</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/Exp/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">RtkToDelhi</a></td>
                                        <td class="text-center">Tavel To Client Office</td>
                                         <td class="text-right"><strong>500</strong></td>
                                        <td class="text-right"><strong>80</strong></td>
                                         <td class="text-right"><strong>180</strong></td>
                                        <td class="text-right"><strong>100</strong></td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/Exp/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">RtkToDelhi</a></td>
                                        <td class="text-center">Lunch with Client</td>
                                         <td class="text-right"><strong>0</strong></td>
                                        <td class="text-right"><strong>100</strong></td>
                                         <td class="text-right"><strong>300</strong></td>
                                        <td class="text-right"><strong>0</strong></td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                               
                                   <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/Exp/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">RtkToDelhi</a></td>
                                        <td class="text-center">Seminar</td>
                                         <td class="text-right"><strong>0</strong></td>
                                        <td class="text-right"><strong>0</strong></td>
                                         <td class="text-right"><strong>100</strong></td>
                                        <td class="text-right"><strong>0</strong></td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/Exp/100</strong></a></td>
                                         <td class="text-center"><a href="javascript:void(0)">RtkToDelhi</a></td>
                                        <td class="text-center">Return To Address</td>
                                         <td class="text-right"><strong>420</strong></td>
                                        <td class="text-right"><strong>100</strong></td>
                                         <td class="text-right"><strong>70</strong></td>
                                        <td class="text-right"><strong>150</strong></td> 
                                        <td class="text-center">
                                            <div class="btn-group btn-group-xs">
                                                <a href="#" data-toggle="tooltip" title="View" class="btn btn-default"><i class="fa fa-eye"></i></a>
                                                <a href="javascript:void(0)" data-toggle="tooltip" title="Delete" class="btn btn-xs btn-danger"><i class="fa fa-times"></i></a>
                                            </div>
                                        </td>
                                    </tr>
                                  
                                </tbody>
                            </table>
                            <!-- END All Orders Content -->
                        </div>
                        <!-- END All Orders Block -->

                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group form-actions" style="float:right">
                                <button type="reset" class="btn btn-sm btn-warning">Reset</button>
                                 <button type="submit" class="btn btn-sm btn-primary">Submit Expenses</button>

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
