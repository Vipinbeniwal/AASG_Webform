using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class LoadingMasterDL : ILoadingMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<LoadingMaster> queryable;

        public IQueryable<LoadingMaster> GetAll()
        {
            queryable = context.LoadingMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.LoadingMasters.Where(x => x.loading_master_id == Id);
            return queryable;
        }


        /// <summary>
        /// This Method is Used to Check Ordernumber Already in LoadingMaster Table  yes or Not
        /// </summary>
        /// <param name="Id">Order Number</param>
        /// <returns></returns>
        public IQueryable GetbyOrderNumber(string Id)
        {
            queryable = context.LoadingMasters.Where(x => x.order_number == Id);
            return queryable;
        }

        

        public IQueryable<LoadingMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public LoadingMaster Create(LoadingMaster LoadingMasterEntity, string loggedInUser)
        {
            if (validate(LoadingMasterEntity))
            {
                try
                {
                    LoadingMasterEntity.modified_on = DateTime.Now;
                    LoadingMasterEntity.created_on = DateTime.Now;
                    LoadingMasterEntity.created_by = 0;
                    LoadingMasterEntity.modified_by = 0;
                    LoadingMasterEntity.user_ip = "";
                    LoadingMasterEntity.is_active = true;
                    LoadingMasterEntity = context.LoadingMasters.Add(LoadingMasterEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return LoadingMasterEntity;
        }

        public LoadingMaster Update(LoadingMaster LoadingMasterEntity, string loggedInUser)
        {
            LoadingMaster objLoadingMaster = null;
            if (validate(LoadingMasterEntity))
            {
                objLoadingMaster = context.LoadingMasters.Find(LoadingMasterEntity.loading_master_id);

                context.Entry(objLoadingMaster).CurrentValues.SetValues(LoadingMasterEntity);

                context.SaveChanges();
            }
            return objLoadingMaster;
        }

        public bool Delete(LoadingMaster LoadingMasterEntity, string loggedInUser)
        {
            if (validate(LoadingMasterEntity))
            {
                try
                {
                    LoadingMaster _LoadingMaster = context.LoadingMasters.First(x => x.loading_master_id == LoadingMasterEntity.loading_master_id);
                    context.LoadingMasters.Remove(_LoadingMaster);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(LoadingMaster LoadingMasterEntity)
        {
            if (LoadingMasterEntity != null)
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
