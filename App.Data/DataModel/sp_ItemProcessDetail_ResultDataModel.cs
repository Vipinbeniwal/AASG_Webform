using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class sp_ItemProcessDetail_ResultDL : Isp_ItemProcessDetail_Result, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<sp_ItemProcessDetail_Result> queryable;

        public IQueryable<sp_ItemProcessDetail_Result> GetAll(string batch_number,string ItemMasterId)
        {
            queryable = context.sp_ItemProcessDetail(batch_number,ItemMasterId).AsQueryable();
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<sp_ItemProcessDetail_Result> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public sp_ItemProcessDetail_Result Create(sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public sp_ItemProcessDetail_Result Update(sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool validate(sp_ItemProcessDetail_Result sp_ItemProcessDetail_ResultEntity)
        {
            if (sp_ItemProcessDetail_ResultEntity != null)
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
