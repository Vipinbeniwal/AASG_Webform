using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ChallanHeaderDL : IChallanHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ChallanHeader> queryable;

        public IQueryable<ChallanHeader> GetAll()
        {
            queryable = context.ChallanHeaders;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ChallanHeaders.Where(x => x.challan_header_id == Id);
            return queryable;
        }

        /// <summary>
        /// This Method is Used to Check Ordernumber Already in ChallanHeaders Table  yes or Not
        /// </summary>
        /// <param name="Id">Order Number</param>
        /// <returns></returns>
        public IQueryable GetbyOrderNumber(string Id)
        {
            queryable = context.ChallanHeaders.Where(x => x.order_number == Id);
            return queryable;
        }

        public IQueryable<ChallanHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ChallanHeader Create(ChallanHeader ChallanHeaderEntity, string loggedInUser)
        {
            if (validate(ChallanHeaderEntity))
            {
                try
                {
                    ChallanHeaderEntity.modified_on = DateTime.Now;
                    ChallanHeaderEntity.created_on = DateTime.Now;
                    //ChallanHeaderEntity.created_by = 0;
                    //ChallanHeaderEntity.modified_by = 0;
                    ChallanHeaderEntity.user_ip = "";
                    ChallanHeaderEntity.is_active = true;
                    ChallanHeaderEntity = context.ChallanHeaders.Add(ChallanHeaderEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return ChallanHeaderEntity;
        }

        public ChallanHeader Update(ChallanHeader ChallanHeaderEntity, string loggedInUser)
        {
            ChallanHeader objChallanHeader = null;
            if (validate(ChallanHeaderEntity))
            {
                objChallanHeader = context.ChallanHeaders.Find(ChallanHeaderEntity.challan_header_id);

                context.Entry(objChallanHeader).CurrentValues.SetValues(ChallanHeaderEntity);

                context.SaveChanges();
            }
            return objChallanHeader;
        }

        public bool Delete(ChallanHeader ChallanHeaderEntity, string loggedInUser)
        {
            if (validate(ChallanHeaderEntity))
            {
                try
                {
                    ChallanHeader _ChallanHeader = context.ChallanHeaders.First(x => x.challan_header_id == ChallanHeaderEntity.challan_header_id);
                    context.ChallanHeaders.Remove(_ChallanHeader);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(ChallanHeader ChallanHeaderEntity)
        {
            if (ChallanHeaderEntity != null)
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
