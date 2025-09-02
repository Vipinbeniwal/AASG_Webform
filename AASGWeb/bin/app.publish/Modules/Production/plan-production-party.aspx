<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="plan-production-party.aspx.cs" Inherits="AASGWeb.Modules.Production.plan_production_party" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>AASG Admin</title>

    <%--<meta name="description" content="ProUI is a Responsive Bootstrap Admin Template created by pixelcave and published on Themeforest.">
    <meta name="author" content="pixelcave">--%>
    <meta name="robots" content="noindex, nofollow"/>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,user-scalable=0"/>

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="/Content/img/favicon.png"/>
    <!-- END Icons -->
    <!-- Stylesheets -->
    <!-- Bootstrap is included in its original form, unaltered -->
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css"/>
    <!-- Related styles of various icon packs and plugins -->
    <link rel="stylesheet" href="/Content/css/plugins.css"/>

    <!-- The main stylesheet of this template. All Bootstrap overwrites are defined in here -->
    <link rel="stylesheet" href="/Content/css/main.css"/>

    <!-- Include a specific file here from css/themes/ folder to alter the default theme of the template -->
    <!-- The themes stylesheet of this template (for using specific theme color in individual elements - must included last) -->
    <link rel="stylesheet" href="/Content/css/themes.css"/>
    <!-- END Stylesheets -->
    <script src="/Content/js/vendor/modernizr.min.js"></script>
    <!-- jQuery, Bootstrap.js, jQuery plugins and Custom JS code -->
    <script src="/Content/js/vendor/jquery.min.js"></script>
    <script src="/Content/js/vendor/bootstrap.min.js"></script>
    <script src="/Content/js/plugins.js"></script>
    <script src="/Content/js/app.js"></script>

    <script src="/Custom/toast.js"></script>
    <script src="/Custom/Validate.js"></script>
    <script src="/Content/js/pages/tablesDatatables.js"></script>

     <style>
        .btn-xs, .btn-group-xs > .btn {
            padding: 0px 5px;
            font-size: 8px !important;
            line-height: 1.6;
            border-radius: 3px;
        }

        .table thead tr th {
            padding: 5px 0;
        }

        .table tbody tr td {
            padding: 3px 0;
        }
    </style>

    <script type="text/javascript">


        function showProductionQuantityAlert() {
            $(document).ready(function () {
                /* Grawl Notifications with Bootstrap-growl plugin, check out more examples at http://ifightcrime.github.io/bootstrap-growl/ */

                var growlType = $(this).data('growl');

                $.bootstrapGrowl('<h4>Warning!</h4> <p><b>Please Fill Production Quantity !</b></p>', {
                    type: 'warning',
                    delay: 2500,
                    allow_dismiss: true
                }, 2000);

                $(this).prop('disabled', true);
            });

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Page content -->
        <div id="page-content">
            <!-- Dashboard 2 Header -->
            <div class="content-header">
                <ul class="nav-horizontal text-center">
                    <li class="active">
                        <a href="/home"><i class="fa fa-arrow-circle-left"></i>Back</a>
                    </li>
                    <li class="">
                        <a href="/home"><i class="fa fa-home"></i>Home</a>
                    </li>
                    <li>
                        <a href="#"><i class="gi gi-charts"></i>Create Bill</a>
                    </li>
                    <li>
                        <a href="#"><i class="gi gi-briefcase"></i>Production</a>
                    </li>
                    <li>
                        <a href="#"><i class="gi gi-video_hd"></i>Returns</a>
                    </li>
                    <li>
                        <a href="/manage-sale-orders"><i class="gi gi-charts"></i>SaleOrders</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-cubes"></i>Accounts</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-pencil"></i>Challans</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-cogs"></i>Settings</a>
                    </li>
                </ul>
            </div>
            <!-- END Dashboard 2 Header -->
            <!-- END Dashboard 2 Header -->

            <!-- END Forms General Header -->
            <div class="block full">
                <!-- All Orders Title -->
                <div class="block-title">
                    <div class="block-options pull-right">
                        <%-- <a href="#" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                    </div>
                    <h2><strong>Plan Production</strong> Party Wise </h2>
                </div>
                <asp:HiddenField ID="hdnSaleOrderIds" runat="server" />
                <asp:HiddenField ID="hdnfPartyMasterIds" runat="server" />
                <%--<asp:HiddenField ID="hdnfSaleOrderId" runat="server" />--%>
                <%--<div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table id="ecom-orders" class="table table-bordered table-striped table-vcenter">
                                <thead>
                                    <tr>
                                        <th class="text-center" style="width: 100px;">S No</th>
                                        <th class="text-center ">Model</th>
                                        <th class="text-center ">Item</th>
                                        <th class="text-center ">Type</th>
                                        <th class="text-center ">Nijomee</th>
                                        <th class="text-center ">Birla Ji</th>
                                        <th class="text-center ">Gaurav Sons</th>
                                        <th class="text-center ">Total</th>
                                        <th class="text-center ">All Comp. Order</th>
                                        <th class="text-center ">Factory Stock.</th>
                                        <th class="text-center ">Shortage</th>
                                        <th class="text-center ">Max. Level</th>
                                        <th class="text-center " style="width: 100px">Production Qty</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>1</strong></a></td>
                                        <td class="text-center"><a href="#">Alto</a></td>
                                        <td class="text-center">Front Door</td>
                                        <td class="text-center">Green Glass</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">6</td>
                                        <td class="text-center">0</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">30</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">20</td>
                                         <td class="text-center">30</td>
                                        <td>
                                            <input type="email" id="example-if-req" name="example-if-email" class="form-control" placeholder="" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>2</strong></a></td>
                                        <td class="text-center"><a href="#">Maruti</a></td>
                                        <td class="text-center">WindScreen</td>
                                        <td class="text-center">Clear</td>
                                        <td class="text-center">2</td>
                                        <td class="text-center">9</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">4</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">12</td>
                                        <td class="text-center">22</td>
                                        <td class="text-center">22</td>
                                        <td>
                                            <input type="email" id="example-if-req2" name="example-if-email" class="form-control" placeholder="" />
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="text-center"><a href="#"><strong>3</strong></a></td>
                                        <td class="text-center"><a href="#">Swift Old</a></td>
                                        <td class="text-center">Wind Screen</td>
                                        <td class="text-center">Clear</td>
                                        <td class="text-center">0</td>
                                        <td class="text-center">0</td>
                                        <td class="text-center">4</td>
                                        <td class="text-center">15</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">10</td>
                                        <td class="text-center">20</td>
                                        <td class="text-center">20</td>
                                        <td>
                                            <input type="email" id="example-if-req3" name="example-if-email" class="form-control" placeholder="" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>--%>


                <div class="table-responsive" style=" text-align:center">
                <asp:GridView ID="grdPlanProductions" runat="server" AutoGenerateColumns="true" CssClass="table table-vcenter table-striped table-hover"  UseAccessibleHeader="true" >
                    <Columns>
                         <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                         <asp:CheckBox ID="chkSelectedItem" runat="server" AutoPostBack="True" Checked="false" CssClass="btn btn-default text-center text-center"/>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Production_Quantity">
                        <ItemTemplate >
                        <asp:TextBox ID="txtProductQuantity" runat="server" onkeypress="return Number(event)" Text="0" MaxLength="3"></asp:TextBox>
                        </ItemTemplate>
                        </asp:TemplateField>
                       
                       <%-- <asp:TemplateField>
                        <ItemTemplate>
                        <asp:Button ID="btnTest" runat="server" Text="Demo Button" />
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                </asp:GridView>

            </div>

                <!-- END All Role Block -->

                <div class="row">
                    <div class="col-md-12" style="margin-top: 10px">
                        <div class="form-group form-actions" style="float: right">

                            <%--<button type="submit" Class="btn btn-sm btn-primary" ><a href="/production/plan-productions-detail" >Procced To Production</a></button>--%>
                            <asp:LinkButton ID="btnProceedToProduction" runat="server" Text="Procced To Production" CssClass="btn btn-sm btn-primary" OnClick="btnProceedToProduction_Click" Visible="true"></asp:LinkButton>
                            <%--<a href="/production/plan-productions-detail" Class="btn btn-sm btn-primary">Procced To Production</a>--%>
                        </div>
                    </div>


                </div>

            </div>
            <!-- Manage Tour Start -->

            <!-- End Manage Tour -->

        </div>
        <!-- END Page Content -->
    </form>
</body>
</html>
