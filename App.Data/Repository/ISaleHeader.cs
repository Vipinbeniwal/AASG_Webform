using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface ISaleHeader
    {
        IQueryable<SaleHeader> GetAll();
        IQueryable<vwSaleHeaderPartyDetail> GetAllSaleHeaderWithPartyDetails();
        IQueryable<vwSaleOrderDashboardData> GetAllSaleHeaderDashboardData();

        IQueryable GetbyId(int Id);

        IQueryable<SaleHeader> GetByName(string Term);

        SaleHeader Create(SaleHeader entity, string loggedInUser);

        SaleHeader Update(SaleHeader entity, string loggedInUser);

        bool Delete(SaleHeader entity, string loggedInUser);

        bool validate(SaleHeader entity);

        string GetLatestOrderNumber();
    }
}
