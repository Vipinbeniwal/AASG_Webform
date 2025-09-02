using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class sp_StockLedgerDetail_ResultDL : Isp_StockLedgerDetail_Result, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<sp_StockLedgerDetail_Result> queryable;

        public IQueryable<sp_StockLedgerDetail_Result> GetAll()
        {
            queryable = context.sp_StockLedgerDetail().AsQueryable();
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<sp_StockLedgerDetail_Result> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public sp_StockLedgerDetail_Result Create(sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public sp_StockLedgerDetail_Result Update(sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool validate(sp_StockLedgerDetail_Result sp_StockLedgerDetail_ResultEntity)
        {
            if (sp_StockLedgerDetail_ResultEntity != null)
            {
                return true;
            }
            else
                return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }

                disposed = true;
            }
        }


    }
}
