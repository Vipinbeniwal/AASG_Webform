<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="add-packaging.aspx.cs" Inherits="AASGWeb.Modules.Production.add_packaging" %>

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

        <!-- END Forms General Header -->


        <div class="row">

            <div class="col-md-12">

                <!-- Normal Form Block -->
                <div class="block full">
                    <!-- Normal Form Title -->
                    <div class="block-title">
                        <div class="block-options pull-right">
                            <%-- <a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default toggle-bordered enable-tooltip" data-toggle="button" title="Toggles .form-bordered class">No Borders</a>--%>
                        </div>
                        <h2><strong>All Packaging</strong> Item List</h2>
                    </div>
                    <!-- END Normal Form Title -->

                    
 <!-- All Orders Content -->
                            <div class="table-responsive">
                           <%--<table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">Batch ID</th>
                                        <th class="text-center">Item Name</th>
                                        <th class="text-center ">Total Pcs </th>
                                        <th class="text-center">OK Pcs</th>
                                        <th class="text-center">Reject</th>
                                        <th class="text-center">Break</th>  
                                        <th class="text-center">Balance</th>
                                        <th class="text-center">Date</th>
                                        <th class="text-center">OP Name</th>  
                                        <th class="text-center">Priority</th>  
                                        
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/ZZ/100</strong></a></td>
                                        <td class="text-center"><a href="#">Alto | Clear</a></td>
                                        <td class="text-center"><strong>47</strong></td>
                                        <td class="text-center"><strong>47</strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        
                                        <td class="text-center"><strong>10-01-2022</strong></td>
                                        <td class="text-center"><strong>Parkash</strong></td>
                                        <td class="text-center">
                                            <label class="label label-danger">high</label>

                                        </td>
                                        
                                    </tr>
                                     <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/ZZ/101</strong></a></td>
                                        <td class="text-center"><a href="#">Alto 800 | Clear</a></td>
                                        <td class="text-center"><strong>73</strong></td>
                                        <td class="text-center"><strong>73</strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        
                                        <td class="text-center"><strong>10-01-2022</strong></td>
                                        <td class="text-center"><strong>Parkash</strong></td>
                                       <td class="text-center">
                                            <label class="label label-danger">high</label>

                                        </td>
                                       
                                    </tr>
                                     <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/ZZ/102</strong></a></td>
                                        <td class="text-center"><a href="#">Alto 800 | Green</a></td>
                                        <td class="text-center"><strong>76</strong></td>
                                        <td class="text-center"><strong>76</strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong>10-01-2022</strong></td>
                                        <td class="text-center"><strong>Mohit</strong></td>
                                       
                                        <td class="text-center">
                                            <label class="label label-primary">low</label>

                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/ZZ/104</strong></a></td>
                                        <td class="text-center"><a href="#">Car 800 | Clear</a></td>
                                        <td class="text-center"><strong>58</strong></td>
                                        <td class="text-center"><strong>58</strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong>11-01-2022</strong></td>
                                        <td class="text-center"><strong>Parkash</strong></td>
                                       
                                       <td class="text-center">
                                            <label class="label label-success">medium</label>

                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="text-center"><a href="#"><strong>AASG/ZZ/105</strong></a></td>
                                        <td class="text-center"><a href="#">Ertiga | Clear</a></td>
                                        <td class="text-center"><strong>83</strong></td>
                                        <td class="text-center"><strong>77</strong></td>
                                        <td class="text-center"><strong>6</strong></td>
                                        <td class="text-center"><strong></strong></td>
                                        
                                        <td class="text-center"><strong></strong></td>
                                        <td class="text-center"><strong>11-01-2022</strong></td>
                                        <td class="text-center"><strong>Mohit</strong></td>
                                       
                                        <td class="text-center">
                                            <label class="label label-success">medium</label>

                                        </td>
                                    </tr>
                               
                                  
                                </tbody>
                            </table>--%>

                                <%--Add Dynamic Repeater Start--%>

                                <asp:Repeater ID="rptrProductionItemBreakageOkRejectDetail" runat="server" OnItemCommand="rptrProductionItemBreakageOkRejectDetail_ItemCommand" OnItemDataBound="rptrProductionItemBreakageOkRejectDetail_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="example-datatable" class="table table-bordered table-striped table-vcenter">
                                            <thead>
                                                <tr>
                                                    <th class="text-center" style="width: 100px;">Batch ID</th>
                                                    <th class="text-center">Item Name</th>
                                                    <th class="text-center ">Total Pcs </th>
                                                    <th class="text-center">OK Pcs</th>
                                                    <th class="text-center">Reject</th>
                                                    <th class="text-center">Break</th>
                                                    <th class="text-center">Raw Balance</th>
                                                    <th class="text-center">Date</th>
                                                    <th class="text-center">OP Name</th>
                                                    <th class="text-center">Priority</th>
                                                    <th class="text-center">Action</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <%-- <td class="text-center"><a href="#"><strong>AASG/<%# Container.ItemIndex + 1 %></strong></a></td>--%>

                                            <td class=" text-center">
                                                <asp:Label ID="lblProductionBatchNumber" Text='<%#Eval("batch_number")%>' runat="server" CssClass="text-primary"></asp:Label>
                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblProductionItemName" Text='<%#Eval("item_name_with_glasscolor")%>' runat="server" CssClass="text-primary"></asp:Label>
                                            </td>

                                            <td class=" text-center">
                                                <asp:Label ID="lblTotalProductionPcs" Text='<%#Eval("total_pcs")%>' runat="server"></asp:Label>
                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblTotalOkPcs" Text='<%#Eval("ok_pcs")%>' runat="server" CssClass="text-success"></asp:Label>
                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblTotalRejectPcs" Text='<%#Eval("Total_reject")%>' runat="server" CssClass="text-warning"></asp:Label>

                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblTotalBreakPcs" Text='<%#Eval("total_break")%>' runat="server" CssClass="text-danger"></asp:Label>

                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblRawBalance" Text='<%#Eval("raw_balance")%>' runat="server"></asp:Label>

                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblProductiondate" Text='<%#Eval("Productiondate","{0: dd/MM/yyyy}")%>' runat="server"></asp:Label>

                                            </td>
                                            <td class=" text-center">
                                                <asp:Label ID="lblOperatorName" Text='<%#Eval("operator_name")%>' runat="server"></asp:Label>

                                            </td>

                                            <td class=" text-center">
                                                <%--<asp:Label ID="lblPriority"  runat="server"></asp:Label>--%>
                                                <label class="label label-danger">high</label>
                                            </td>

                                            <td class=" text-center  btn-group-xs ">
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="edit" CommandArgument='<%# Eval("production_id")%>' CssClass="btn btn-default text-center" data-toggle="tooltip" data-placement="bottom" title="Click to edit" data-original-title="Basic tooltp"><i class="fa fa-eye"></i></asp:LinkButton>

                                            </td>

                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>         
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:HiddenField ID="hdfdProductionItemMasterId" runat="server" />

                                <%--Add Dynamic Repeater End--%>
                            </div>
                            <!-- END All Orders Content -->


                 
                </div>
                <!-- END Normal Form Block -->


            </div>
        </div>


    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
