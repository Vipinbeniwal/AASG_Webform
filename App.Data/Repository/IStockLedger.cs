using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IStockLedger
    {
        IQueryable<StockLedger> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<StockLedger> GetByName(string Term);

        StockLedger Create(StockLedger entity, string loggedInUser);

        StockLedger Update(StockLedger entity, string loggedInUser);

        bool Delete(StockLedger entity, string loggedInUser);

        bool validate(StockLedger entity);
    }
}
