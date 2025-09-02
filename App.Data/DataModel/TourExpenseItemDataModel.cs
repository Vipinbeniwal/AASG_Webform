using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class TourExpenseItemDL : ITourExpenseItem, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<TourExpenseItem> queryable;

        public IQueryable<TourExpenseItem> GetAll()
        {
            queryable = context.TourExpenseItems;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.TourExpenseItems.Where(x => x.tour_master_id == Id);
            return queryable;
        }

        public IQueryable<TourExpenseItem> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public TourExpenseItem Create(TourExpenseItem TourExpenseItemEntity, string loggedInUser)
        {
            if (validate(TourExpenseItemEntity))
            {
                try
                {
                   
                    TourExpenseItemEntity.modified_on = DateTime.Now;
                    TourExpenseItemEntity.created_on = DateTime.Now;
                    TourExpenseItemEntity.created_by = 0;
                    TourExpenseItemEntity.modified_by = 0;
                    TourExpenseItemEntity.user_ip = "";
                    TourExpenseItemEntity.is_active = true;
                   
                    TourExpenseItemEntity = context.TourExpenseItems.Add(TourExpenseItemEntity);
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
            return TourExpenseItemEntity;
        }

        public TourExpenseItem Update(TourExpenseItem TourExpenseItemEntity, string loggedInUser)
        {
            TourExpenseItem objTourExpenseItem = null;
            if (validate(TourExpenseItemEntity))
            {
                try
                {
                    objTourExpenseItem = context.TourExpenseItems.Find(TourExpenseItemEntity.tour_master_id);

                    context.Entry(objTourExpenseItem).CurrentValues.SetValues(TourExpenseItemEntity);

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
            return objTourExpenseItem;
        }

        public bool Delete(TourExpenseItem TourExpenseItemEntity, string loggedInUser)
        {
            if (validate(TourExpenseItemEntity))
            {
                try
                {
                    TourExpenseItem _TourExpenseItem = context.TourExpenseItems.First(x => x.tour_master_id == TourExpenseItemEntity.tour_master_id);
                    context.TourExpenseItems.Remove(_TourExpenseItem);
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

        public bool validate(TourExpenseItem TourExpenseItemEntity)
        {
            if (TourExpenseItemEntity != null)
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
