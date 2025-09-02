using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class sp_tourdetail_ResultDL : Isp_tourdetail_Result, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<sp_tourdetail_Result> queryable;

        public IQueryable<sp_tourdetail_Result> GetAll(int tour_master_id,int staff_master_id,string FromDate, string ToDate)
        {
            queryable = context.sp_tourdetail(tour_master_id, staff_master_id, FromDate, ToDate).AsQueryable();
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<sp_tourdetail_Result> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public sp_tourdetail_Result Create(sp_tourdetail_Result sp_tourdetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public sp_tourdetail_Result Update(sp_tourdetail_Result sp_tourdetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(sp_tourdetail_Result sp_tourdetail_ResultEntity, string loggedInUser)
        {
            throw new NotImplementedException();
        }

        public bool validate(sp_tourdetail_Result sp_tourdetail_ResultEntity)
        {
            if (sp_tourdetail_ResultEntity != null)
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
