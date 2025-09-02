using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class TourMasterDL : ITourMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<TourMaster> queryable;

        public IQueryable<TourMaster> GetAll()
        {
            queryable = context.TourMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.TourMasters.Where(x => x.tour_master_id == Id);
            return queryable;
        }

        public IQueryable<TourMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public TourMaster Create(TourMaster TourMasterEntity, string loggedInUser)
        {
            if (validate(TourMasterEntity))
            {
                try
                {
                   
                    TourMasterEntity.modified_on = DateTime.Now;
                    TourMasterEntity.created_on = DateTime.Now;
                    TourMasterEntity.created_by = 0;
                    TourMasterEntity.modified_by = 0;
                    TourMasterEntity.user_ip = "";
                    TourMasterEntity.is_active = true;
                   
                    TourMasterEntity = context.TourMasters.Add(TourMasterEntity);
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
            return TourMasterEntity;
        }

        public TourMaster Update(TourMaster TourMasterEntity, string loggedInUser)
        {
            TourMaster objTourMaster = null;
            if (validate(TourMasterEntity))
            {
                try
                {
                    objTourMaster = context.TourMasters.Find(TourMasterEntity.tour_master_id);

                    context.Entry(objTourMaster).CurrentValues.SetValues(TourMasterEntity);

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
            return objTourMaster;
        }

        public bool Delete(TourMaster TourMasterEntity, string loggedInUser)
        {
            if (validate(TourMasterEntity))
            {
                try
                {
                    TourMaster _TourMaster = context.TourMasters.First(x => x.tour_master_id == TourMasterEntity.tour_master_id);
                    context.TourMasters.Remove(_TourMaster);
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

        public bool validate(TourMaster TourMasterEntity)
        {
            if (TourMasterEntity != null)
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
