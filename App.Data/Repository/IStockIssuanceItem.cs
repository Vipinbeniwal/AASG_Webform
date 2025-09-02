using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IStockIssuanceItem
    {
        IQueryable<StockIssuanceItem> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<StockIssuanceItem> GetByName(string Term);

        StockIssuanceItem Create(StockIssuanceItem entity, string loggedInUser);

        StockIssuanceItem Update(StockIssuanceItem entity, string loggedInUser);

        bool Delete(StockIssuanceItem entity, string loggedInUser);

        bool validate(StockIssuanceItem entity);
    }
}
