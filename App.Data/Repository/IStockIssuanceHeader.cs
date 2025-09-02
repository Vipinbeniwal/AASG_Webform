using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IStockIssuanceHeader
    {
        IQueryable<StockIssuanceHeader> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<StockIssuanceHeader> GetByName(string Term);

        StockIssuanceHeader Create(StockIssuanceHeader entity, string loggedInUser);

        StockIssuanceHeader Update(StockIssuanceHeader entity, string loggedInUser);

        bool Delete(StockIssuanceHeader entity, string loggedInUser);

        bool validate(StockIssuanceHeader entity);
    }
}
