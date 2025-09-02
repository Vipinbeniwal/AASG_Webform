using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class PurchaseItemDL : IPurchaseItem, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<PurchaseItem> queryable;

        public IQueryable<PurchaseItem> GetAll()
        {
            queryable = context.PurchaseItems;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.PurchaseItems.Where(x => x.purchase_header_id == Id);
            return queryable;
        }

        public IQueryable<PurchaseItem> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public PurchaseItem Create(PurchaseItem PurchaseItemEntity, string loggedInUser)
        {
            if (validate(PurchaseItemEntity))
            {
                try
                {
                   
                    PurchaseItemEntity.modified_on = DateTime.Now;
                    PurchaseItemEntity.created_on = DateTime.Now;
                    PurchaseItemEntity.created_by = 0;
                    PurchaseItemEntity.modified_by = 0;
                    PurchaseItemEntity.user_ip = "";
                    PurchaseItemEntity.is_active = true;
                   
                    PurchaseItemEntity = context.PurchaseItems.Add(PurchaseItemEntity);
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
            return PurchaseItemEntity;
        }

        public PurchaseItem Update(PurchaseItem PurchaseItemEntity, string loggedInUser)
        {
            PurchaseItem objPurchaseItem = null;
            if (validate(PurchaseItemEntity))
            {
                try
                {
                    objPurchaseItem = context.PurchaseItems.Find(PurchaseItemEntity.purchase_header_id);

                    context.Entry(objPurchaseItem).CurrentValues.SetValues(PurchaseItemEntity);

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
            return objPurchaseItem;
        }

        public bool Delete(PurchaseItem PurchaseItemEntity, string loggedInUser)
        {
            if (validate(PurchaseItemEntity))
            {
                try
                {
                    PurchaseItem _PurchaseItem = context.PurchaseItems.First(x => x.purchase_header_id == PurchaseItemEntity.purchase_header_id);
                    context.PurchaseItems.Remove(_PurchaseItem);
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

        public bool validate(PurchaseItem PurchaseItemEntity)
        {
            if (PurchaseItemEntity != null)
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
