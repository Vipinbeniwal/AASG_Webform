using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IPurchaseHeader
    {
        IQueryable<PurchaseHeader> GetAll();
        IQueryable<vwPurchaseHeaderSupplierDetail> GetAllPurchaseHeaderSupplierDetails();
        IQueryable<vwPurchaseOrderDashboardData> GetAllPurchaseHeaderDashboardData(); 

        IQueryable GetbyId(int Id);

        IQueryable<PurchaseHeader> GetByName(string Term);

        PurchaseHeader Create(PurchaseHeader entity, string loggedInUser);

        PurchaseHeader Update(PurchaseHeader entity, string loggedInUser);

        bool Delete(PurchaseHeader entity, string loggedInUser);

        bool validate(PurchaseHeader entity);
    }
}
