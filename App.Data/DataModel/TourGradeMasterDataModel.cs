using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class TourGradeMasterDL : ITourGradeMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<TourGradeMaster> queryable;

        public IQueryable<TourGradeMaster> GetAll()
        {
            queryable = context.TourGradeMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.TourGradeMasters.Where(x => x.tourgrade_master_id == Id);
            return queryable;
        }

        public IQueryable<TourGradeMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public TourGradeMaster Create(TourGradeMaster TourGradeMasterEntity, string loggedInUser)
        {
            if (validate(TourGradeMasterEntity))
            {
                try
                {
                   
                    TourGradeMasterEntity.modified_on = DateTime.Now;
                    TourGradeMasterEntity.created_on = DateTime.Now;
                    TourGradeMasterEntity.created_by = 0;
                    TourGradeMasterEntity.modified_by = 0;
                    TourGradeMasterEntity.user_ip = "";
                    TourGradeMasterEntity.is_active = true;
                   
                    TourGradeMasterEntity = context.TourGradeMasters.Add(TourGradeMasterEntity);
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
            return TourGradeMasterEntity;
        }

        public TourGradeMaster Update(TourGradeMaster TourGradeMasterEntity, string loggedInUser)
        {
            TourGradeMaster objTourGradeMaster = null;
            if (validate(TourGradeMasterEntity))
            {
                try
                {
                    objTourGradeMaster = context.TourGradeMasters.Find(TourGradeMasterEntity.tourgrade_master_id);

                    context.Entry(objTourGradeMaster).CurrentValues.SetValues(TourGradeMasterEntity);

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
            return objTourGradeMaster;
        }

        public bool Delete(TourGradeMaster TourGradeMasterEntity, string loggedInUser)
        {
            if (validate(TourGradeMasterEntity))
            {
                try
                {
                    TourGradeMaster _TourGradeMaster = context.TourGradeMasters.First(x => x.tourgrade_master_id == TourGradeMasterEntity.tourgrade_master_id);
                    context.TourGradeMasters.Remove(_TourGradeMaster);
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

        public bool validate(TourGradeMaster TourGradeMasterEntity)
        {
            if (TourGradeMasterEntity != null)
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
