using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class StockIssuanceItemDL : IStockIssuanceItem, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<StockIssuanceItem> queryable;

        public IQueryable<StockIssuanceItem> GetAll()
        {
            queryable = context.StockIssuanceItems;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.StockIssuanceItems.Where(x => x.stock_issuance_header_id == Id);
            return queryable;
        }

        public IQueryable<StockIssuanceItem> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public StockIssuanceItem Create(StockIssuanceItem StockIssuanceItemEntity, string loggedInUser)
        {
            if (validate(StockIssuanceItemEntity))
            {
                try
                {

                    StockIssuanceItemEntity.modified_on = DateTime.Now;
                    StockIssuanceItemEntity.created_on = DateTime.Now;
                    StockIssuanceItemEntity.created_by = 0;
                    StockIssuanceItemEntity.modified_by = 0;
                    StockIssuanceItemEntity.user_ip = "";
                    StockIssuanceItemEntity.is_active = true;

                    StockIssuanceItemEntity = context.StockIssuanceItems.Add(StockIssuanceItemEntity);
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
            return StockIssuanceItemEntity;
        }

        public StockIssuanceItem Update(StockIssuanceItem StockIssuanceItemEntity, string loggedInUser)
        {
            StockIssuanceItem objStockIssuanceItem = null;
            if (validate(StockIssuanceItemEntity))
            {
                try
                {
                    objStockIssuanceItem = context.StockIssuanceItems.Find(StockIssuanceItemEntity.stock_issuance_header_id);

                    context.Entry(objStockIssuanceItem).CurrentValues.SetValues(StockIssuanceItemEntity);

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
            return objStockIssuanceItem;
        }

        public bool Delete(StockIssuanceItem StockIssuanceItemEntity, string loggedInUser)
        {
            if (validate(StockIssuanceItemEntity))
            {
                try
                {
                    StockIssuanceItem _StockIssuanceItem = context.StockIssuanceItems.First(x => x.stock_issuance_header_id == StockIssuanceItemEntity.stock_issuance_header_id);
                    context.StockIssuanceItems.Remove(_StockIssuanceItem);
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

        public bool validate(StockIssuanceItem StockIssuanceItemEntity)
        {
            if (StockIssuanceItemEntity != null)
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
