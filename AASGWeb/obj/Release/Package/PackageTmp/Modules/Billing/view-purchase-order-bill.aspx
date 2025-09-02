<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view-purchase-order-bill.aspx.cs" Inherits="AASGWeb.Modules.Billing.view_purchase_order_bill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AASG</title>
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
                .img1
                {
                    text-align: center;
                }
                .img2
                {
                    display: none;
                }
                .details-box
                {
                    border-right:0;
                    padding: 0;
                }
                .container-fluid
                {
                    width: 95%;
                }
            }
        </style>   
        <!-- style css end here -->
</head>
<body>
    <form id="form1" runat="server">
       <!-- header section start here -->        
        <header class="header-body mt-2 mb-2">
            <div class="container-fluid">
                <div class="row col-md-12 col-sm-12">
                    <div class="col-md-3 img1">
                        <img src="/Content/img/auto.png" class="img-fluid" alt="AASG logo"/>
                    </div>
                    <div class="col-md-6 col-sm-6 text-center mt-4">
                        <h4>Atul Automotive Safety Glass Industries</h4>
                        <h6>Purchase Order</h6>
                    </div>
                    <div class="col-md-3 text-right img2">
                        <img src="/Content/img/auto.png" class="img-fluid" alt="AASG logo"/>
                    </div> 
                </div>
            </div>
        </header>  
        <!-- header section end here -->  

        <!-- table section start here -->

        <!-- first table start-->
       <section class="details">
            <div class="container-fluid details-row">
                <div class="row col-md-12 col-sm-12">
                    <div class="details-box col-md-2 col-sm-12">
                        <div class="details-txt">
                            Review Charge: Yes/No<br>
                            P.O No: AASG/217/21-22<br>
                            P.O Date: 06/11/2021<br>
                            Req No: 321<br>
                            Req Date: 06/11/2021<br>
                            Received Date:<br>
                            State: Himachal Pradesh<br>
                            State Code: 14
                        </div>        
                    </div>
                    <div class="details-box col-md-4 col-sm-12">
                        <div class="details-txt">
                            <b>Invoice in favour of:</b>
                        </div>
                        <div class="data1"></div>
                        <div class="details-txt">
                            <b>Atul Himachal</b>
                        </div>
                        <div class="data1"></div>
                        <div class="details-txt">
                            Atul Automotive Safety Glass Industries
                            Plot No: 163-164, VPO Bela Bathri, Distt Una, Himachal Pradesh
                            GSTN: 02AARFA0495L1Z9
                            Delivery/Coordination Phone: 0-8694-107-207
                            Email Copy to: FACTORY@AASG.IN
                        </div>
                    </div>
                    <div class="details-box col-md-4 col-sm-12">
                        <div class="details-txt">
                            <b>Supplier Detail:</b>
                        </div>
                        <div class="data1"></div>
                        <div class="details-txt">
                            Firm Name: <asp:Label ID="lblPartyName"  runat="server"> </asp:Label><br />
                            Concerned Person/Mobile: +<asp:Label ID="lblPartyPhoneNumber"  runat="server"> </asp:Label><br />
                            Address: <asp:Label ID="lblPartyAddress"  runat="server" cssClass="text-capitalize"> </asp:Label> , <asp:Label ID="lblPartyCity"  runat="server" cssClass="text-capitalize"> </asp:Label> , <asp:Label ID="lblPartyState"  runat="server" cssClass="text-capitalize"> </asp:Label><br />
                            Email : <asp:Label ID="lblPartyEmailId"  runat="server"></asp:Label><br />
                            GSTN: <asp:Label ID="lblPartyGst"  runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="details-box box-4 col-md-2 col-sm-12">
                        <div class="details-txt">
                            Supplier's Ref:<br />
                            INVOICE No:<asp:Label ID="lblInvoiceNumber"  runat="server"></asp:Label><br />
                            P.I Date: <asp:Label ID="lblDate"  runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- first table end-->

        <!-- second table start-->
        <section class="table2 mt-2 table-responsive">
            <div class="container-fluid">
                <div class="row">
                    <%--<table>
                        <tr class="text-center">
                            <th>S.No</th>
                            <th>Product HSN Code</th>
                            <th>Item & Specification</th>
                            <th>Quantity</th>
                            <th>UoM</th>
                            <th>Rate/Unit</th>
                            <th>Amount</th>
                            <th>GST%</th>
                            <th>Total Amount</th>
                        </tr>
                        <tr class="text-center">
                            <td>1</td>
                            <td>84672100</td>
                            <td class="text-left">Hammer Drill Machin, Dewait, 26mm</td>
                            <td>2</td>
                            <td>NoS</td>
                            <td>8200</td>
                            <td class="text-right">16,400.00</td>
                            <td>18</td>
                            <td class="text-right">19,352.00</td>
                        </tr>
                        <tr class="text-center">
                            <td>2</td>
                            <td>84672100</td>
                            <td class="text-left">Drill Machin, Dewait, 10mm</td>
                            <td>3</td>
                            <td>NoS</td>
                            <td>2700</td>
                            <td class="text-right">8,100.00</td>
                            <td>18</td>
                            <td class="text-right">9,558.00</td>
                        </tr>
                        <tr class="text-center">
                            <td>3</td>
                            <td>84672100</td>
                            <td class="text-left">Angle Grinder, Dewait, 4"</td>
                            <td>2</td>
                            <td>NoS</td>
                            <td>2250</td>
                            <td class="text-right">4,500.00</td>
                            <td>18</td>
                            <td class="text-right">5,310.00</td>
                        </tr>
                        <tr class="text-center">
                            <td>4</td>
                            <td>84672100</td>
                            <td class="text-left">Wooden Chisel, Caltex, 25mm</td>
                            <td>5</td>
                            <td>NoS</td>
                            <td>180</td>
                            <td class="text-right">900.00</td>
                            <td>18</td>
                            <td class="text-right">1,062.00</td>
                        </tr>
                        <tr class="text-center">
                            <td>5</td>
                            <td>84672100</td>
                            <td class="text-left">Wooden Chisel, Black Dacker, 18mm</td>
                            <td>8</td>
                            <td>NoS</td>
                            <td>190</td>
                            <td class="text-right">1,520.00</td>
                            <td>18</td>
                            <td class="text-right">1,793.60</td>
                        </tr>
                        <tr class="text-center">
                            <td>6</td>
                            <td>84672100</td>
                            <td class="text-left">Wooden Chisel, Caltex, 12mm</td>
                            <td>8</td>
                            <td>NoS</td>
                            <td>140</td>
                            <td class="text-right">1,120.00</td>
                            <td>18</td>
                            <td class="text-right">1,321.60</td>
                        </tr>
                        <tr class="text-center">
                            <td>7</td>
                            <td>84672100</td>
                            <td class="text-left">Aremature</td>
                            <td>1</td>
                            <td>NoS</td>
                            <td>1210</td>
                            <td class="text-right">1,210.00</td>
                            <td>18</td>
                            <td class="text-right">1,427.80</td>
                        </tr>
                        <tr class="text-center">
                            <td>8</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>-</td>
                            <td></td>
                            <td>-</td>
                        </tr>
                        <tr class="text-center">
                            <td>9</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>-</td>
                            <td></td>
                            <td>-</td>
                        </tr>
                        <tr class="text-center">
                            <td>10</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>-</td>
                            <td></td>
                            <td>-</td>
                        </tr>
                        <tr class="text-center">
                            <td>11</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>-</td>
                            <td></td>
                            <td>-</td>
                        </tr>
                        <tr class="text-center">
                            <td></td>
                            <td></td>
                            <td class="text-left">TOTAL VALUE</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td class="text-right">33,750.00</td>
                            <td></td>
                            <td class="text-right">39,825.00</td>
                        </tr>
                    </table>--%>

                    <asp:Repeater ID="rptrPurchaseItems" runat="server"  OnItemCommand="rptrPurchaseItems_ItemCommand" OnItemDataBound="rptrPurchaseItems_ItemDataBound">
                        <HeaderTemplate>
                            <table id="ecom-orders" class="table table-bordered  table-vcenter">
                                <thead>
                                    <tr class="text-center">
                                        <th>S.No</th>
                                        <th>Product HSN Code</th>
                                        <th>Item & Specification</th>
                                        <th>Quantity</th>
                                        <th>UoM</th>
                                        <th>Rate/Unit</th>
                                        <th>Amount</th>
                                        <th>GST%</th>
                                        <th>Total Amount</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="text-center">
                                <td ><strong><%# Container.ItemIndex + 1 %></strong> 

                                </td>


                                <td >
                                    <asp:Label ID="lblitemid" Text='<%#Eval("item_master_id")%>' runat="server"> </asp:Label>
                                </td>
                                <td class="text-left">
                                    <asp:Label ID="lblItemName" Text='<%#Eval("purchase_item_name")%>' runat="server"> </asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="lblItemQuantity" Text='<%#Eval("purchase_item_quantity")%>' runat="server"></asp:Label>
                                </td>
                                <td>NoS</td>
                            
                                <td  class="text-center">
                                    <asp:Label ID="lblItemPrice" Text='<%#Eval("purchase_item_price")%>' runat="server"></asp:Label>

                                </td>
                                <td class="text-right">
                                    <asp:Label ID="lblItemAmount"  runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblitemgst"  runat="server"></asp:Label>
                                </td>
                                <td class="text-right">
                                    <asp:Label ID="lblItemTotalAmount"  runat="server"></asp:Label>
                                </td>

                                
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>

                            <tr>
                            <td colspan="3" class="text-right text-uppercase"><strong>TOTAL VALUE:</strong></td>

                            <td colspan="4" class="text-right"><strong>
                                <asp:Label ID="lblsubTotal"  runat="server"></asp:Label>

                            </strong></td>
                            <td colspan="2" class="text-right"><strong>
                                <asp:Label ID="lblmainTotal"  runat="server"></asp:Label>

                            </strong></td>
                        </tr>

                            </table>         
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hdfdPurchaseNumber" runat="server" />

                </div>
            </div>
        </section>



        <!-- second table end-->

        <!-- third table start-->
        <section class="table3 mt-2">
            <div class="container-fluid">
                <div class="row">
                    <table>
                        <tr>
                            <th>Mode Of Transport</th>
                            <th colspan="3">On Site Delivery by Transport</th>
                        </tr>
                        <tr>
                            <td>Delivery Locator (If different from invoice Detail)</td>
                            <td>Loading<br>
                                GST%<br>
                                (Use Reverse Charge if required)<br>
                                Total
                            </td>
                            <td>0%</td>
                            <td>0</td>
                        </tr>
                    </table>
                    <table class="mt-2">
                        <tr>
                            <th colspan="4">Accounts Department</th>
                        </tr>
                        <tr>
                            <td>If Advance, mention</td>
                            <td></td>
                            <td>7 Day Credit</td>
                            <td class="text-right"><b style="border: 2px solid black !important;">
                                <asp:Label ID="lblGrandTotal"  runat="server"></asp:Label>

                                                   </b></td>
                        </tr>
                    </table>
                    <table class="mt-4">
                        <tr>
                            <th colspan="2">Plant Incharge</th>
                        </tr>
                        <tr>
                            <td rowspan="2">Quantity Check</td>
                            <td>Rate & Amount Check</td>
                        </tr>
                        <tr>
                            <td>(from PI/Previous Purchase)</td>
                        </tr>
                    </table>
                    <table class="mt-2">
                        <tr>
                            <th>Vendor Information</th>
                        </tr>
                        <tr>
                            <td><b>Terms:</b><br>
                                1. invoice should clear status detail as above<br>
                                2. Purchase Order No must be mentioned on all documents<br>
                                3. invoice should clear status detail as above<br>
                                4. Purchase Order No must be mentioned on all documents
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </section>
        <!-- third table end-->

        <!-- table section end here -->

        <!-- footer section start here -->
        <footer class="footer mt-4">
            <div class="container-fluid">
                <div class="row">
                    <div>
                        <p><b>kindly acknowledge the receipt of this purchase order and arrange to dispatch the material AASG.</b></p>

                        <p><b>For Atul Automotive Safety Glass Industries</b></p>
                        <div class="signator-box">
                        </div>
                        <h6>(Authorised Signatory)</h6>
                    </div>
                </div>
            </div>
        </footer>
        <!-- footer section end here -->
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>

<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

</html>
