<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="challan-slip.aspx.cs" Inherits="AASGWeb.Modules.Billing.challan_slip" %>

<!DOCTYPE html>

<html xmlns="">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1" />
    <title>AASG | Challan Slip</title>

    <style>
        html {
            font-size: 20px;
        }

        @media screen and (max-width: 480px) {
            html {
                font-size: 14px;
            }
        }

        @media print {
            .btnprint, #btnprint {
                display: none;
            }

            .gj-bill .gj-bill-body .gj-bill-img.gj-bill-zig-zag {
                page-break-before: always;
            }

            html {
                font-size: 15px;
            }
        }

        body {
            height: auto;
            width: 100%;
            padding: 0;
            margin: 0;
        }

            body * {
                font-family: Roboto, sans-serif;
            }

        tr td {
            padding-bottom: 5px;
        }

        .gj {
            background: none;
            height: 5px;
            position: relative;
            overflow: hidden;
        }

            .gj .header-bg {
                height: 100%;
                width: 100%;
                padding-top: 90px;
                background: url(none) 0% 0% / 100% no-repeat;
            }

        .gj-bill {
            margin: 0 auto;
            width: 100%;
            max-width: 600px;
            position: relative;
            height: auto;
            min-height: 90vh;
            opacity: 1;
           /* background: #55AF04;*/
            background: #1bbae1;
        }

            .gj-bill .gj-bill-body {
                position: relative;
            }

                .gj-bill .gj-bill-body .gj-bill-img {
                    width: 94%;
                    margin: 0 3%;
                    background: #fff;
                    position: relative;
                    text-align: center;
                    min-height: 100px;
                    padding-top: 1%;
                    border-radius: 10px;
                    padding-top: 1px;
                    padding-bottom: -5px;
                }

                    .gj-bill .gj-bill-body .gj-bill-img h2 {
                        margin: 8% 0 0% 0;
                    }

                    .gj-bill .gj-bill-body .gj-bill-img h4 {
                        margin: 4% 0 3% 0;
                    }

                    .gj-bill .gj-bill-body .gj-bill-img h6 {
                        margin: 4% 0;
                    }

                    .gj-bill .gj-bill-body .gj-bill-img p {
                        font-size: 0.65rem;
                        margin: 2% 0;
                    }

                    .gj-bill .gj-bill-body .gj-bill-img.gj-bill-zig-zag {
                        margin-bottom: 42px;
                    }

                        .gj-bill .gj-bill-body .gj-bill-img.gj-bill-zig-zag:before {
                            content: "";
                            position: absolute;
                            bottom: -18px;
                            background-repeat: no-repeat;
                            background-image: url('../img/zig_zag.png');
                            width: 100%;
                            height: 20px;
                            display: block;
                        }

        .gj-dotline {
            height: 2px;
            background: linear-gradient(90deg, rgb(112, 112, 112) 50%, rgb(255, 255, 255) 0px) 0% 0% / 7px 1px;
            margin: 10px 0px;
        }

        .gj-table {
            border-collapse: collapse;
            width: 100%;
            border-spacing: 10px;
            font-size: 0.65rem;
            font-family: DINPro-Medium, sans-serif;
        }

            .gj-table.gj-table-services {
                text-align: left;
                font-family: DINPro-Medium, sans-serif;
            }

        .tr-1 td {
            padding-bottom: 10px;
            font-family: DINPro-Medium, sans-serif;
        }

        .gj-table-price tr td:first-child {
            text-align: left;
        }

        .gj-table-price tr td:last-child {
            text-align: right;
            right: -30px;
        }

        .button {
            text-align: center !important;
        }

        .button1 {
            text-align: left !important;
            color: white !important;
            margin-left: 10px;
            text-decoration: none;
            padding: 4px;
            font-size: 0.9rem;
        }

            .button1 a {
                color: white !important;
                text-decoration: none;
            }

        .btnprint {
            background-color: #fff;
           /* color: #6DB916;*/
            color: #1bbae1;
            padding: 6px 10px;
            border: 1px solid #fff;
            border-radius: 5px;
            font-weight: bold
        }

            .btnprint:hover {
                background-color: #1bbae163;
                /*border-color: #6DB916;*/
                border-color: #1bbae1;
                color: #fff;
                padding: 6px 10px;
                border: 1px solid;
                border-radius: 5px;
                font-weight: bold
            }
    </style>
    <script lang="javascript" type="text/javascript">

        function PrintContent() {
            var printContents = document.getElementById('body').innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }
        function PrintContent1() {
            var DocumentContainer = document.getElementById('pnlInvoice');
            var WindowObject = window.open('', "TrackData",
                "width=1000,height=1000,top=250,left=345,toolbars=no,scrollbars=no,status=no,resizable=yes");
            WindowObject.document.write(DocumentContainer.innerHTML);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlInvoice" runat="server">

             <div id="body">
                <div class="gj-bill gj-bg">
                   
                    <div class="gj-bill-body gj-body">

                        <div style="position: relative;">
                            <asp:HiddenField ID="hdfdSaleOrderId" runat="server" />
                            <%--<div aria-hidden="false" class="gj-bill-static" style="height: auto;"></div>--%>
                            <div style="">
                                <asp:Repeater ID="rptrOrder" runat="server" OnItemDataBound="rptrOrder_ItemDataBound">
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="gj-bill-img gj-bill-zig-zag">
                                            <div style="padding: 0px 16px;">
                                                <h2 class="">
                                                    <asp:Label ID="lblPartyName" runat="server" Text='<%#Eval("party_name")%>'></asp:Label>
                                                </h2>
                                                <p >
                                                    <asp:Label ID="lblStoreAddress" runat="server" Text='<%#Eval("party_address")%>'></asp:Label>
                                                </p>
                                               <hr />
                                                <table class="gj-table">
                                                    <tbody>
                                                        <tr>
                                                            <td style="text-align: left;">Contact Person Name</td>
                                                            <td style="text-align: right;">
                                                                <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("party_contact_person")%>'></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left;">Party Phone</td>
                                                            <td style="text-align: right;">
                                                            <asp:Label ID="lblUserPhone" runat="server" Text='<%#Eval("party_phoneno")%>'> </asp:Label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                                <div class="gj-dotline"></div>
                                                <table class="gj-table">
                                                    <tbody>
                                                        <asp:Label ID="lblsaleid" runat="server" Text='<%#Eval("sale_header_id")%>' Visible="false"></asp:Label>
                                                        <tr>
                                                            <td style="text-align: left;">Bill No:-   
                                                    <asp:Label ID="lblOrderId" runat="server" Text='<%#Eval("order_number")%>'></asp:Label></td>
                                                            <td style="text-align: right;">Order Date:
                                                    <asp:Label ID="lblOrderDate" runat="server" Text='<%#Eval("created_on","{0:dd MMM,yyy}")%>'></asp:Label></td>
                                                        </tr>
                                                       <%-- <tr>
                                                            <td style="text-align: left;">Time:
                                                    <asp:Label ID="lblDeliveryTime" runat="server" Text='<%#Eval("delivery_time")%>'></asp:Label></td>
                                                            <td style="text-align: right;">Delivery Date:
                                                    <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("delivery_date","{0:dd MMM,yyy}")%>'></asp:Label></td>
                                                        </tr>--%>
                                                    </tbody>
                                                </table>

                                                <div class="gj-dotline"></div>

                                                <asp:Repeater ID="rptItem" runat="server" OnItemDataBound="rptItem_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table id="" class="gj-table gj-table-services">
                                                            <thead>
                                                                <tr class="bg-success">
                                                                    <th>S.N.</th>
                                                                    <th>Item Name</th>
                                                                    <th style="width:40px">Qty </th>
                                                                    <th style="width:50px">Weight </th>
                                                                </tr>
                                                            </thead>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex + 1 %>    </td>
                                                            <td>
                                                                <asp:Label ID="lblItemMasterId" Text='<%#Eval("item_master_id")%>' runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblItemName" Text='<%#Eval("sale_item_name")%>' runat="server"></asp:Label>
                                                            </td>

                                                           <%-- <td>₹<asp:Label ID="lblitemPrice" Text='<%#Eval("sale_item_price")%>' runat="server"> </asp:Label>
                                                                <asp:Label ID="lblSaleItemNetPrice" Text='<%#Eval("sale_item_net_price")%>' runat="server" Visible="false"> </asp:Label>
                                                            </td>--%>
                                                            <td>
                                                                <asp:Label ID="lblItemQuantity" Text='<%#Eval("sale_item_quantity")%>' runat="server"> </asp:Label> 

                                                            </td>
                                                            <td>
                                                                 <asp:Label ID="lblTotalItemWeight" Text='<%#Eval("item_weight")%>' runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>         
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <div class="gj-dotline"></div>
                                                <table class="gj-table gj-table-price">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="2" style="text-align:right"><b>Total</b></td>
                                                            <td style="text-align:right; width: 60px;">
                                                                <b><asp:Label ID="lblTotalItem" runat="server"></asp:Label></b>

                                                            </td>

                                                            <td style="text-align: center;width: 70px;">
                                                               <b> <asp:Label ID="lbltotalWeight" runat="server"></asp:Label></b>

                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                                <div class="gj-dotline"></div>
                                               <%-- <div class="gj-text">
                                                    <h4>In Words</h4>
                                                    <p>
                                                        <asp:Label ID="lblwords" runat="server"></asp:Label>
                                                    </p>
                                                    <p>Thank You,Have A Nice Day!</p>
                                                </div>--%>
                                            </div>
                                            <br />
                                        </div>

                            <br />
                                    </ItemTemplate>

                                </asp:Repeater>
                            </div>
                            <div class="button">
                                <%--<a id="btnprint" href="/challan" title="Print Invoice" class="btn btn-success btn-next pull-right" onclick="printDiv()">
                                <i class="fa fa-arrow-left mr-1 "></i>Back</a>--%>
                               <a href="/challan"><i class="fa fa-arrow-left mr-1 "></i><input type="button" class="btnprint"  value="Back" /></a> 
                                <input type="button" class="btnprint" onclick="PrintContent()" value="Print Slip" />
                                
                                <%--  <a id="btnprint" href="#" title="Print Invoice" class="btn btn-success btn-next pull-right" onclick="printDiv()">
                                    <i class="mdi mdi-printer mr-1 "></i>Print Invoice</a>--%>
                                
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>
        <div>
        </div>
    </form>
</body>
</html>
