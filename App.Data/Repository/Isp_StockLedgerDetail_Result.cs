using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public interface Isp_StockLedgerDetail_Result
    {
        IQueryable<sp_StockLedgerDetail_Result> GetAll();

        IQueryable GetbyId(int Id);

        IQueryable<sp_StockLedgerDetail_Result> GetByName(string Term);

        sp_StockLedgerDetail_Result Create(sp_StockLedgerDetail_Result entity, string loggedInUser);

        sp_StockLedgerDetail_Result Update(sp_StockLedgerDetail_Result entity, string loggedInUser);

        bool Delete(sp_StockLedgerDetail_Result entity, string loggedInUser);

        bool validate(sp_StockLedgerDetail_Result entity);
    }
}
