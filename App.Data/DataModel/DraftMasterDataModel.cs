using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class DraftMasterDL : IDraftMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<DraftMaster> queryable;

        public IQueryable<DraftMaster> GetAll()
        {
            queryable = context.DraftMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.DraftMasters.Where(x => x.draft_master_id == Id);
            return queryable;
        }

        public IQueryable<DraftMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public DraftMaster Create(DraftMaster DraftMasterEntity, string loggedInUser)
        {
            if (validate(DraftMasterEntity))
            {
                try
                {
                   
                    DraftMasterEntity.modified_on = DateTime.Now;
                    DraftMasterEntity.created_on = DateTime.Now;
                    DraftMasterEntity.created_by = 0;
                    DraftMasterEntity.modified_by = 0;
                    DraftMasterEntity.user_ip = "";
                    DraftMasterEntity.is_active = true;
                   
                    DraftMasterEntity = context.DraftMasters.Add(DraftMasterEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                   
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            string error = "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;

                        }
                    }


                }
            }
            return DraftMasterEntity;
        }

        public DraftMaster Update(DraftMaster DraftMasterEntity, string loggedInUser)
        {
            DraftMaster objDraftMaster = null;
            if (validate(DraftMasterEntity))
            {
                try
                {
                    objDraftMaster = context.DraftMasters.Find(DraftMasterEntity.draft_master_id);

                    context.Entry(objDraftMaster).CurrentValues.SetValues(DraftMasterEntity);

                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {

                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            string error = "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;

                        }
                    }


                }

            }
            return objDraftMaster;
        }

        public bool Delete(DraftMaster DraftMasterEntity, string loggedInUser)
        {
            if (validate(DraftMasterEntity))
            {
                try
                {
                    DraftMaster _DraftMaster = context.DraftMasters.First(x => x.draft_master_id == DraftMasterEntity.draft_master_id);
                    context.DraftMasters.Remove(_DraftMaster);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {

                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            string error = "Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage;

                        }
                    }


                }
            }
            return true;
        }

        public bool validate(DraftMaster DraftMasterEntity)
        {
            if (DraftMasterEntity != null)
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
