using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace AASGWeb
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region Login
            routes.MapPageRoute("Login", "login", "~/Login.aspx", false);
            #endregion

            #region Modules/Acoount
            routes.MapPageRoute("PendingExpense", "pending-expense", "~/Modules/Account/pending-expense.aspx", false);

            #endregion

            #region Modules/Admin

            #region  Employee Master
            routes.MapPageRoute("AddEmployee", "add-employee", "~/Modules/Admin/add-employee.aspx", false);
            routes.MapPageRoute("AddEmployeeid", "add-employee/{id}", "~/Modules/Admin/add-employee.aspx", false);
            routes.MapPageRoute("ManageEmployee", "manage-employee", "~/Modules/Admin/manage-employee.aspx", false);

            #endregion

            #region  Menu Master
            routes.MapPageRoute("Add Menu Master", "add-menu-master", "~/Modules/Admin/add-menu-master.aspx", false);
            #endregion

            #region  Party Master

            routes.MapPageRoute("AddParty", "add-party", "~/Modules/Admin/add-party.aspx", false);
            routes.MapPageRoute("AddPartyid", "add-party/{id}", "~/Modules/Admin/add-party.aspx", false);
            routes.MapPageRoute("ManageParty", "manage-party", "~/Modules/Admin/manage-party.aspx", false);


            #endregion

            #region Role Master

            routes.MapPageRoute("AddRole", "add-role", "~/Modules/Admin/add-role.aspx", false);
            routes.MapPageRoute("UpdateRoleByid", "add-role/{id}", "~/Modules/Admin/add-role.aspx", false);
            routes.MapPageRoute("ManageRole", "manage-role", "~/Modules/Admin/manage-role.aspx", false);

            #endregion

            #region Time Sheet Master

            routes.MapPageRoute("AddTimeSheet", "add-time-sheet", "~/Modules/Admin/add-xp-item.aspx", false);
            routes.MapPageRoute("ManageTimeSheet", "manage-time-sheet", "~/Modules/Admin/manage-time-sheet.aspx", false);
            routes.MapPageRoute("ViewTimeSheetDetail", "view_time-sheet-employee-details/{id}", "~/Modules/Admin/manage-time-sheet-employee-detail.aspx", false);

            #endregion

            #region Tour Master

            routes.MapPageRoute("AddTour", "add-tour", "~/Modules/Admin/add-tour.aspx", false);
            routes.MapPageRoute("AddTourGrade", "add-tour-grade", "~/Modules/Admin/add-tour-grade.aspx", false);
            routes.MapPageRoute("ManageTour", "manage-tour", "~/Modules/Admin/manage-tour.aspx", false);
            routes.MapPageRoute("ViewTourExpense", "view-tour-expense/{id}", "~/Modules/Admin/view-tour-expense.aspx", false);

            #endregion



            #region Feature Master

            routes.MapPageRoute("BackupMaster", "backup", "~/Modules/Admin/backup-master.aspx", false);
            routes.MapPageRoute("DrawingMaster", "drawing-master", "~/Modules/Admin/drawing-master.aspx", false);
            routes.MapPageRoute("UpdateDrawingMasterid", "drawing-master/{id}", "~/Modules/Admin/drawing-master.aspx", false);
            routes.MapPageRoute("ManageDrawingMaster", "manage-drawing-master", "~/Modules/Admin/manage-drawing-master.aspx", false);
            routes.MapPageRoute("DropdownMaster", "dropdown-master", "~/Modules/Admin/dropdown-master.aspx", false);

            routes.MapPageRoute("AddFeature", "feature-master", "~/Modules/Admin/feature-master.aspx", false);
            #endregion

            // View Order
            routes.MapPageRoute("ManageViewOrder", "view-order", "~/Modules/Admin/view-order.aspx", false);



            #endregion

            #region Modules/Billing

            #region Purchase Master
            routes.MapPageRoute("AddPurchase", "add-purchase", "~/Modules/Billing/add-purchase.aspx", false);
            routes.MapPageRoute("ManagePurchase", "manage-purchase", "~/Modules/Billing/manage-purchase.aspx", false);
            routes.MapPageRoute("ManagePurchaseBill", "view-purchase-order-bill/{id}", "~/Modules/Billing/view-purchase-order-bill.aspx", false);

            #endregion

            #region Return Master
            
            routes.MapPageRoute("AddReturn", "add-return", "~/Modules/Billing/add-return.aspx", false);
            routes.MapPageRoute("ManageReturn", "manage-returns", "~/Modules/Billing/manage-returns.aspx", false);
            #endregion

            #region Sale Order Master
            routes.MapPageRoute("AddSaleOrder", "add-sale-order", "~/Modules/Billing/add-sale-order.aspx", false);
            routes.MapPageRoute("AddSaleOrderById", "add-sale-order/{id}", "~/Modules/Billing/add-sale-order.aspx", false);
            routes.MapPageRoute("ManageSaleOrders", "manage-sale-orders", "~/Modules/Billing/manage-sale-orders.aspx", false);
            routes.MapPageRoute("ViewSaleItemDetails", "sale-order-item-details/{id}", "~/Modules/Billing/sale-order-item-details.aspx", false);
            routes.MapPageRoute("ViewChallan", "challan-details/{id}", "~/Modules/Billing/challan-slip.aspx", false);
           // routes.MapPageRoute("ViewChallanPrint", "challan-print/{id}", "~/Modules/Billing/challan-details-print.aspx", false);
            routes.MapPageRoute("ViewChallanPrint", "challan-print/{id}/{challanid}", "~/Modules/Billing/challan-details-print.aspx", false);



            #endregion

            #region Billing
            routes.MapPageRoute("AddChallan", "add-challan/{id}/{loadingid}", "~/Modules/Billing/add-challan.aspx", false);
            routes.MapPageRoute("Billing", "billing", "~/Modules/Billing/billing.aspx", false);
            routes.MapPageRoute("Challan", "challan", "~/Modules/Billing/challan.aspx", false);
            routes.MapPageRoute("LoadingSlips", "loading-slips", "~/Modules/Billing/loading-slips.aspx", false);
            routes.MapPageRoute("RootPlan", "root-plan", "~/Modules/Billing/root-plan.aspx", false);

            #endregion

            #endregion

            #region Modules/GRN

            #region GRN
            routes.MapPageRoute("AddGrn", "add-grn", "~/Modules/GRN/add-grn.aspx", false);
            routes.MapPageRoute("ManageGrn", "manage-grn", "~/Modules/GRN/manage-grn.aspx", false);

            routes.MapPageRoute("ViewGrnLedger", "view_stock-ledger-order-details/{id}", "~/Modules/GRN/view-stock-ledger-order-details.aspx", false);

            #endregion

            #endregion

            #region Modules/Home
            #region Home
            routes.MapPageRoute("Home", "home", "~/Modules/Home/home.aspx", false);

            #endregion
            #endregion
            
            #region Modules/Inventory

            #region Item Master
            routes.MapPageRoute("AddItem", "add-item", "~/Modules/Inventory/add-item.aspx", false);
            routes.MapPageRoute("AddItemid", "add-item/{id}", "~/Modules/Inventory/add-item.aspx", false);
            routes.MapPageRoute("ManageItem", "manage-items", "~/Modules/Inventory/manage-items.aspx", false);

            #endregion

            #region Stock Master
            routes.MapPageRoute("ManageRawStock", "manage-raw-stock", "~/Modules/Inventory/manage-raw-stock.aspx", false);
            routes.MapPageRoute("ManageReadyStock", "manage-ready-stock", "~/Modules/Inventory/manage-ready-stock.aspx", false);
            routes.MapPageRoute("ManageStockIssuance", "manage-stock-issuance", "~/Modules/Inventory/manage-stock-issuance.aspx", false);
            routes.MapPageRoute("RaiseStockRequirement", "raise-stock-requirement", "~/Modules/Inventory/raise-stock-requirement.aspx", false);

            #endregion


            #endregion

            #region Modules/Lead

            #region Lead Master/ Followup Master
            routes.MapPageRoute("AddLead", "add-lead", "~/Modules/Lead/add-lead.aspx", false);
            routes.MapPageRoute("ManageLead", "manage-lead", "~/Modules/Lead/manage-lead.aspx", false);
            routes.MapPageRoute("AddLeadid", "add-lead/{id}", "~/Modules/Lead/add-lead.aspx", false);
            routes.MapPageRoute("AddFollowUpid", "add-followup/{id}", "~/Modules/Lead/add-followup.aspx", false);
            routes.MapPageRoute("ViewFollowUpid", "view-followup/{id}", "~/Modules/Lead/view-followup.aspx", false);

            #endregion

            #endregion

            #region Modules/Production

            #region Production

            routes.MapPageRoute("AddAcknowledge", "production/add-acknowledge", "~/Modules/Production/acknowledge.aspx", false);
            // routes.MapPageRoute("AddAcknowledge", "production/add-acknowledge/{id}", "~/Modules/Production/acknowledge.aspx", false);
            routes.MapPageRoute("AddPackaging", "production/add-packaging", "~/Modules/Production/add-packaging.aspx", false);
            routes.MapPageRoute("AddProduction", "production/add-production", "~/Modules/Production/add-production.aspx", false);
            routes.MapPageRoute("AddCutting", "production/cutting", "~/Modules/Production/cutting.aspx", false);
            routes.MapPageRoute("AddCuttingId", "production/cutting/{id}", "~/Modules/Production/cutting.aspx", false);

            //routes.MapPageRoute("AddCuttingProcess", "production/cutting/{id}", "~/Modules/Production/cutting.aspx", false);

            routes.MapPageRoute("AddDFGPrint", "production/dfg-print/{id}", "~/Modules/Production/dfg-print.aspx", false);
            
            routes.MapPageRoute("AddGrinding", "production/grinding/{id}", "~/Modules/Production/grinding.aspx", false);
            routes.MapPageRoute("AddHole", "production/hole/{id}", "~/Modules/Production/hole.aspx", false);
            routes.MapPageRoute("ItemDetails", "production/item-complete-detail/{id}/{batchid}", "~/Modules/Production/item-complete-detail.aspx", false);
           // routes.MapPageRoute("ItemDetails", "production/item-complete-detail", "~/Modules/Production/item-complete-detail.aspx", false);
            routes.MapPageRoute("ItemProcess", "production/item-process", "~/Modules/Production/item-process.aspx", false);
           // routes.MapPageRoute("ItemSummary", "production/item-summary", "~/Modules/Production/item-summary.aspx", false);
            routes.MapPageRoute("ItemSummaryActivity", "production/item-summary/{id}/{productionid}", "~/Modules/Production/item-summary.aspx", false);
            routes.MapPageRoute("OptionOne", "option-one", "~/Modules/Production/option-one.aspx", false);
            routes.MapPageRoute("OptionTwo", "option-two", "~/Modules/Production/option-two.aspx", false);
            routes.MapPageRoute("OptionThree", "option-three", "~/Modules/Production/option-three.aspx", false);

            routes.MapPageRoute("AddPacking", "production/packing/{id}", "~/Modules/Production/packing.aspx", false);
            routes.MapPageRoute("AddPaint", "production/paint/{id}", "~/Modules/Production/paint.aspx", false);

            routes.MapPageRoute("PlanProduction", "production/plan-production", "~/Modules/Production/plan-production-party.aspx", false);

            routes.MapPageRoute("PlanProductionid", "production/plan-production/{id}/{partyid}", "~/Modules/Production/plan-production-party.aspx", false);

            //routes.MapPageRoute("PlanProductionid", "production/plan-production/{id}", "~/Modules/Production/plan-production-party.aspx", false);
            routes.MapPageRoute("PlanProductions", "production/plan-productions-detail", "~/Modules/Production/plan-production.aspx", false);
            routes.MapPageRoute("PlantWiseItem", "production/plant-wise-items", "~/Modules/Production/plant-wise-items.aspx", false);
            routes.MapPageRoute("ProceedProduction", "production/proceed-production", "~/Modules/Production/proceed-production.aspx", false);
            routes.MapPageRoute("AddStore", "production/store/{id}", "~/Modules/Production/store.aspx", false);
            routes.MapPageRoute("AddTempring", "production/tempering/{id}", "~/Modules/Production/tempring.aspx", false);
            routes.MapPageRoute("AddWashingOne", "production/washing-one/{id}", "~/Modules/Production/washing-one.aspx", false);
            routes.MapPageRoute("AddWashing", "production/washing/{id}", "~/Modules/Production/washing.aspx", false);
            
            #endregion


            #endregion

            #region Modules/QC

            #region Quality Check
            routes.MapPageRoute("ManageQuality", "manage-quality", "~/Modules/QC/manage-quality.aspx", false);

            #endregion

            #endregion

            #region Modules/Supplier

            #region Supplier Master
            routes.MapPageRoute("AddSupplier", "add-supplier", "~/Modules/Supplier/add-supplier.aspx", false);
            routes.MapPageRoute("ManageSupplier", "manage-supplier", "~/Modules/Supplier/manage-supplier.aspx", false);

            #endregion

            #endregion

            #region Modules/Xp-Master

            #region Customer Request
            routes.MapPageRoute("AddCustomerRequest", "add-customer-request", "~/Modules/Xp-Master/add-customer-request.aspx", false);
            routes.MapPageRoute("ManageCustomerRequest", "manage-customer-request", "~/Modules/Xp-Master/manage-customer-request.aspx", false);
            routes.MapPageRoute("ViewCustomerRequestDetail", "view_customer-request-details", "~/Modules/Xp-Master/view-customer-request-detail.aspx", false);

            #endregion

            #region Procurement
            routes.MapPageRoute("AddProcurement", "add-procurement", "~/Modules/Xp-Master/add-procurement.aspx", false);
            routes.MapPageRoute("ManageProcurement", "manage-procurement", "~/Modules/Xp-Master/manage-procurement.aspx", false);
            #endregion

            #region Xp-Item Master
            routes.MapPageRoute("AddXPItemMaster", "add-xp-item", "~/Modules/Xp-Master/add-xp-item.aspx", false);
            routes.MapPageRoute("AddXPItemMasterId", "add-xp-item/{id}", "~/Modules/Xp-Master/add-xp-item.aspx", false);
            routes.MapPageRoute("ManageXPItemMaster", "manage-xp-item", "~/Modules/Xp-Master/manage-xp-item.aspx", false);

            #endregion

            #region Xp-Staff-Raise-Request

            routes.MapPageRoute("AddXPItemRequest", "add-item-request", "~/Modules/Xp-Master/add-item-staff-request.aspx", false);
            routes.MapPageRoute("ManageXPItemRequest", "manage-item-request", "~/Modules/Xp-Master/manage-item-staff-request.aspx", false);

            #endregion

            #endregion
            
            routes.EnableFriendlyUrls();
        }
    }
}
