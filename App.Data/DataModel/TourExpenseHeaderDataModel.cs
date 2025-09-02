using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class TourExpenseHeaderDL : ITourExpenseHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<TourExpenseHeader> queryable;

        public IQueryable<TourExpenseHeader> GetAll()
        {
            queryable = context.TourExpenseHeaders;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.TourExpenseHeaders.Where(x => x.tour_master_id == Id);
            return queryable;
        }

        public IQueryable<TourExpenseHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public TourExpenseHeader Create(TourExpenseHeader TourExpenseHeaderEntity, string loggedInUser)
        {
            if (validate(TourExpenseHeaderEntity))
            {
                try
                {
                   
                    TourExpenseHeaderEntity.modified_on = DateTime.Now;
                    TourExpenseHeaderEntity.created_on = DateTime.Now;
                    TourExpenseHeaderEntity.created_by = 0;
                    TourExpenseHeaderEntity.modified_by = 0;
                    TourExpenseHeaderEntity.user_ip = "";
                    TourExpenseHeaderEntity.is_active = true;
                   
                    TourExpenseHeaderEntity = context.TourExpenseHeaders.Add(TourExpenseHeaderEntity);
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
            return TourExpenseHeaderEntity;
        }

        public TourExpenseHeader Update(TourExpenseHeader TourExpenseHeaderEntity, string loggedInUser)
        {
            TourExpenseHeader objTourExpenseHeader = null;
            if (validate(TourExpenseHeaderEntity))
            {
                try
                {
                   
                    objTourExpenseHeader = context.TourExpenseHeaders.Where(x=>x.tour_master_id == TourExpenseHeaderEntity.tour_master_id).FirstOrDefault();

                    context.Entry(objTourExpenseHeader).CurrentValues.SetValues(TourExpenseHeaderEntity);

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
            return objTourExpenseHeader;
        }

        public bool Delete(TourExpenseHeader TourExpenseHeaderEntity, string loggedInUser)
        {
            if (validate(TourExpenseHeaderEntity))
            {
                try
                {
                    TourExpenseHeader _TourExpenseHeader = context.TourExpenseHeaders.First(x => x.tour_master_id == TourExpenseHeaderEntity.tour_master_id);
                    context.TourExpenseHeaders.Remove(_TourExpenseHeader);
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

        public bool validate(TourExpenseHeader TourExpenseHeaderEntity)
        {
            if (TourExpenseHeaderEntity != null)
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
