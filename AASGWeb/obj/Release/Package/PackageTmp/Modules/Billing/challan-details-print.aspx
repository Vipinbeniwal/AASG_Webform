<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="challan-details-print.aspx.cs" Inherits="AASGWeb.Modules.Billing.challan_details_print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AASG Challan Details</title>
           <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <meta property="og:locale" content="en_US" />
        <meta property="og:type" content="website" />

        <!-- font link here -->
        <link href="https://fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,500,500i,700,700i,900&display=swap" rel="stylesheet" />

        <!-- bootstrap link here -->
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />

        <!-- style css start here -->
        <style type="text/css">
            
            .table thead th{
                border-bottom: 1px solid #000;
                border-left: 1px solid #000;
                border-right: 1px solid #000;
            }
           .table-bordered td{
               border: 1px solid #000;
           }
            .details-row
            {
                border: 1px solid #000;
            }
            .details-box
            {
                border-right: 1px solid #000;
                padding: 0;
            }
            .data1
            {
                border-bottom:1px solid #000 ;
            }
            .box-4
            {
                border: 0;
            }
            table {
              font-family: arial, sans-serif;
              border-collapse: collapse;
              width: 100%;
            }

            table, td, th {
              border: 1px solid black;
            }
            td
            {
                height: 30px;
            }
            .table3 table,
            .table3 td,
            .table3 th{
                border: 0 !important;
            }
            .table3 th
            {
                border: 0 !important;
                background: #707070;
                color: #fff;
                text-align: center;
            }
            .signator-box
            {
                height: 100px;
            }
            @media (max-width: 991px)
            {
                .header-body img
                {
                    width: 100px;
                }
               
                .details-box
                {
                    border-right:0;
                    padding: 0;
                }
                /*.container-fluid
                {
                    width: 95%;
                }*/
                 .table thead th{
                border-bottom: 1px solid #000;
                border-left: 1px solid #000;
                border-right: 1px solid #000;
            }
           .table-bordered td{
               border: 1px solid #000;
           }
                
            }@media print {
    
    .pagebreak {
        clear: both;
        page-break-after: always;
    }
 }
           
        </style>   
        <!-- style css end here -->
</head>
<body>
    <form id="form1" runat="server">
               <!-- header section start here -->        
        <header class="header-body mt-2 mb-2">
            <div class="container">
                <div class="row col-md-12 col-sm-12 myborder">
                    
                    <div class="col-md-9 col-sm-9 text-center mt-4 ">
                        
                        
                    </div>
                    <div class="col-md-3  text-center mt-4 ">
                        
                        
                    </div>
                    
                </div>
            </div>
        </header>  
        <!-- header section end here -->  

        <!-- table section start here -->

        <!-- first table start-->
       <section class="details">
           <table class="container">
                        <tr class="text-center">
                            <td colspan="3" class="pt-2">
                                <h4> <asp:Label ID="lblPartyName"  runat="server"></asp:Label> - <asp:Label ID="lblState"  runat="server"></asp:Label></h4>
                            </td>
                            <td class="pt-2">
                                <h4>DATE : <asp:Label ID="lblDate"  runat="server"></asp:Label></h4>
                            </td>
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>Name :</b></td>
                            <td class="text-left pl-2"> <asp:Label ID="lblClientname"  runat="server" class="text-left"></asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Bill No : </b> </td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblBillNumber"  runat="server"></asp:Label></td>
                            
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>Address :</b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblClientAddress"  runat="server"> </asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Vehicle No : </b></td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblVehicleNumber"  runat="server"></asp:Label></td>
                           
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>GST IN :</b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblGSTNumber"  runat="server"></asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Driver Name : </b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblDriverName"  runat="server"></asp:Label></td>
                           
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>DISC @ :</b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblDiscount"  runat="server"> </asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Delivery Boy : </b></td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblDeliveryBoy"  runat="server"></asp:Label></td>
                           
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>BILL :  </b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblBillPercentage"  runat="server"> </asp:Label> %</td>
                            <td class="text-left pl-2" style="width:120px"><b> GST : </b></td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblGstPercentage"  runat="server"></asp:Label></td>
                           
                        </tr>
                    </table>
        </section>
        <!-- first table end-->

        <!-- second table start-->
        <section class="table2  table-responsive">
            <div class="container">
                <div class="row">
                    
                    <asp:Repeater ID="rptrPurchaseItems" runat="server"  OnItemCommand="rptrPurchaseItems_ItemCommand" OnItemDataBound="rptrPurchaseItems_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered  table-vcenter">
                                <thead>
                                    <tr class="text-center">
                                        <th>S.No</th>
                                        <th>Model</th>
                                        <%--<th>Billing</th>--%>
                                        <th>Quantity</th>
                                        <th>Unit</th>
                                        <th>Price</th>
                                        <th>DISC.AMT</th>
                                        <th>Amount</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="text-center">
                                <td ><strong><%# Container.ItemIndex + 1 %></strong> 
                                </td>

                               <%-- <td >
                                    <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>--%>
                                <td class="text-left">
                                    <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                                </td>
                                <%--<td class="text-center">
                                    <asp:Label ID="lblBillingPercentage"  Text='<%#Eval("item_gst_percentage")%>' runat="server" Visible="false" ></asp:Label> %
                                    <asp:Label ID="lblNetBillingPercentage" Text='<%#Eval("item_gst_percentage")%>' runat="server" Visible="false" > </asp:Label>
                                </td>--%>
                                <td >
                                    <asp:Label ID="lblItemQuantity" Text='<%#Eval("sale_item_quantity_actual_load")%>' runat="server"></asp:Label>
                                </td> 
                                 <td  class="text-center">
                                    <asp:Label ID="lblUnit" Text='<%#Eval("item_unit")%>' runat="server"></asp:Label>

                                </td>
                                <td  class="text-center">
                                    <asp:Label ID="lblItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblSaleItemNetPrice" Text='<%#Eval("sale_item_net_price")%>' runat="server" Visible="false"> </asp:Label>
                                </td>
                                 <td class="text-right">
                                    <asp:Label ID="lblItemAmount" Text='<%#Eval("item_discount_amount")%>'  runat="server"></asp:Label>
                                </td>
                                <td class="text-right">
                                    <asp:Label ID="lblItemTotalAmount" Text='<%#Eval("item_amount")%>' runat="server"></asp:Label> 
                                    <asp:Label ID="lblItemBilledAmount" Text='<%#Eval("item_bill_amount")%>' Visible="false" runat="server"></asp:Label> 
                                    <asp:Label ID="lblItemGSTAmount" Text='<%#Eval("item_gst_amount")%>'  Visible="false" runat="server"></asp:Label> 

                                </td>
                                
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>

                            <tr>
                                <td class="text-center text-uppercase"><strong></strong></td>
                                <td class="text-center text-uppercase"><strong></strong></td>
                                <td class="text-center text-uppercase"><strong>
                                    <asp:Label ID="lblTotalItemQuantity"  runat="server"></asp:Label>
                                                                                  </strong></td>
                            <td colspan="3" class="text-right text-uppercase"><strong>TOTAL VALUE :</strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblmainTotal"  runat="server"></asp:Label>
                                 <asp:Label ID="lblsubTotal"  runat="server" Visible="false"></asp:Label>

                            </strong></td>
                        </tr>
                            <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>TOTAL GST :</strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblTotalGst"  runat="server"></asp:Label>

                            </strong></td>
                        </tr>
                            <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>BIll Amount :</strong></td>
                            
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblTotalBillableAmount" runat="server" ></asp:Label>

                            </strong></td>
                        </tr>
                            <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>Cash Amount :</strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblTotalCashAmount" runat="server" ></asp:Label>

                            </strong></td>
                        </tr>

                            </table>         
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hdfdSaleOrderNumber" runat="server" />

                </div>
            </div>
        </section>

        <!-- second table end-->

        <!-- table section end here -->

        <div class="pagebreak"> </div>
        <!--- Table Detail Heder for Second table  -->
        <section class="details">
           <table class="container">
                        <tr class="text-center">
                            <td colspan="3" class="pt-2">
                                <h4> <asp:Label ID="lblPartyName2"  runat="server"></asp:Label> - <asp:Label ID="lblState2"  runat="server"></asp:Label></h4>
                            </td>
                            <td class="pt-2">
                                <h4>DATE : <asp:Label ID="lblDate2"  runat="server"></asp:Label></h4>
                            </td>
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>Name :</b></td>
                            <td class="text-left pl-2"> <asp:Label ID="lblClientname2"  runat="server" class="text-left"></asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Bill No : </b> </td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblBillNumber2"  runat="server"></asp:Label></td>
                            
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>Address :</b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblClientAddress2"  runat="server"> </asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Vehicle No : </b></td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblVehicleNumber2"  runat="server"></asp:Label></td>
                           
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>GST IN :</b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblGSTNumber2"  runat="server"></asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Driver Name : </b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblDriverName2"  runat="server"></asp:Label></td>
                           
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>DISC @ :</b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblDiscount2"  runat="server"> </asp:Label></td>
                            <td class="text-left pl-2" style="width:120px"><b> Delivery Boy : </b></td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblDeliveryBoy2"  runat="server"></asp:Label></td>
                           
                        </tr>
                        <tr class="text-left">
                            <td style="width:100px" class="pl-2"><b>BILL :  </b></td>
                            <td class="text-left pl-2"><asp:Label ID="lblBillPercentage2"  runat="server"> </asp:Label> %</td>
                            <td class="text-left pl-2" style="width:120px"><b> GST : </b></td>
                            <td style="width:250px" class="text-left pl-2"><asp:Label ID="lblGstPercentage2"  runat="server"></asp:Label></td>
                           
                        </tr>
                    </table>
        </section>


        <!--- Table Detail Heder for Second table  -->

        <!--- Second Repeater -->
        
        <section class="table2  table-responsive">
            <div class="container">
                <div class="row">
                    
                    <asp:Repeater ID="rptrItemList2" runat="server" OnItemCommand="rptrItemList2_ItemCommand" OnItemDataBound="rptrItemList2_ItemDataBound" >
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered  table-vcenter">
                                <thead>
                                    <tr class="text-center">
                                        <th>S.No</th>
                                        <th>Model</th>
                                        <%--<th>Billing</th>--%>
                                        <th>Quantity</th>
                                        <th>Unit</th>
                                        <th>Price</th>
                                        <th>DISC.AMT</th>
                                        <th>Amount</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="text-center">
                                <td ><strong><%# Container.ItemIndex + 1 %></strong> 
                                </td>

                               <%-- <td >
                                    <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>--%>
                                <td class="text-left">
                                    <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"> </asp:Label>
                                </td>
                               <%-- <td class="text-center">
                                    <asp:Label ID="lblBillingPercentage"  Text='<%#Eval("item_gst_percentage")%>' runat="server"  Visible="false"></asp:Label> %
                                    <asp:Label ID="lblNetBillingPercentage" Text='<%#Eval("item_gst_percentage")%>' runat="server" Visible="false" > </asp:Label>
                                </td>--%>
                                <td >
                                    <asp:Label ID="lblItemQuantity" Text='<%#Eval("sale_item_quantity_actual_load")%>' runat="server"></asp:Label>
                                </td> 
                                 <td  class="text-center">
                                    <asp:Label ID="lblUnit" Text='<%#Eval("item_unit")%>' runat="server"></asp:Label>

                                </td>
                                <td  class="text-center">
                                    <asp:Label ID="lblItemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"></asp:Label>
                                    <asp:Label ID="lblSaleItemNetPrice" Text='<%#Eval("sale_item_net_price")%>' runat="server" Visible="false"> </asp:Label>
                                </td>
                                 <td class="text-right">
                                    <asp:Label ID="lblItemAmount" Text='<%#Eval("item_discount_amount")%>'  runat="server"></asp:Label>
                                </td>
                                <td class="text-right">
                                    <asp:Label ID="lblItemTotalAmount" Text='<%#Eval("item_amount")%>' runat="server"></asp:Label> 
                                    <asp:Label ID="lblItemBilledAmount" Text='<%#Eval("item_bill_amount")%>' Visible="false" runat="server"></asp:Label> 
                                    <asp:Label ID="lblItemGSTAmount" Text='<%#Eval("item_gst_amount")%>'  Visible="false" runat="server"></asp:Label> 
                                </td>
                                
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>

                            <tr>
                                <td class="text-center text-uppercase"><strong></strong></td>
                                <td class="text-center text-uppercase"><strong></strong></td>
                                <td class="text-center text-uppercase"><strong>
                                    <asp:Label ID="lblTotalItemQuantity"  runat="server"></asp:Label>
                                                                                  </strong></td>
                            <td colspan="3" class="text-right text-uppercase"><strong>TOTAL VALUE :</strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblmainTotal"  runat="server"></asp:Label>
                                 <asp:Label ID="lblsubTotal"  runat="server" Visible="false"></asp:Label>

                            </strong></td>
                        </tr>
                            <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>TOTAL GST :</strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblTotalGst"  runat="server"></asp:Label>

                            </strong></td>
                        </tr>
                            <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>BIll Amount :</strong></td>
                            
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblTotalBillableAmount" runat="server" ></asp:Label>

                            </strong></td>
                        </tr>
                            <tr>
                            <td colspan="6" class="text-right text-uppercase"><strong>Cash Amount :</strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblTotalCashAmount" runat="server" ></asp:Label>

                            </strong></td>
                        </tr>

                            </table>         
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="HiddenField1" runat="server" />

                </div>
            </div>
        </section>

        <!--- Second Repeater -->




        
    </form>
</body>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>

<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>


</html>
