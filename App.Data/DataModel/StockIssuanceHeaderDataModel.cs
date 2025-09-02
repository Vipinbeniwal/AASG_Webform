using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class StockIssuanceHeaderDL : IStockIssuanceHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<StockIssuanceHeader> queryable;

        public IQueryable<StockIssuanceHeader> GetAll()
        {
            queryable = context.StockIssuanceHeaders;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.StockIssuanceHeaders.Where(x => x.stock_issuance_header_id == Id);
            return queryable;
        }

        public IQueryable<StockIssuanceHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public StockIssuanceHeader Create(StockIssuanceHeader StockIssuanceHeaderEntity, string loggedInUser)
        {
            if (validate(StockIssuanceHeaderEntity))
            {
                try
                {

                    StockIssuanceHeaderEntity.modified_on = DateTime.Now;
                    StockIssuanceHeaderEntity.created_on = DateTime.Now;
                    StockIssuanceHeaderEntity.created_by = 0;
                    StockIssuanceHeaderEntity.modified_by = 0;
                    StockIssuanceHeaderEntity.user_ip = "";
                    StockIssuanceHeaderEntity.is_active = true;

                    StockIssuanceHeaderEntity = context.StockIssuanceHeaders.Add(StockIssuanceHeaderEntity);
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
            return StockIssuanceHeaderEntity;
        }

        public StockIssuanceHeader Update(StockIssuanceHeader StockIssuanceHeaderEntity, string loggedInUser)
        {
            StockIssuanceHeader objStockIssuanceHeader = null;
            if (validate(StockIssuanceHeaderEntity))
            {
                try
                {
                    objStockIssuanceHeader = context.StockIssuanceHeaders.Find(StockIssuanceHeaderEntity.stock_issuance_header_id);

                    context.Entry(objStockIssuanceHeader).CurrentValues.SetValues(StockIssuanceHeaderEntity);

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
            return objStockIssuanceHeader;
        }

        public bool Delete(StockIssuanceHeader StockIssuanceHeaderEntity, string loggedInUser)
        {
            if (validate(StockIssuanceHeaderEntity))
            {
                try
                {
                    StockIssuanceHeader _StockIssuanceHeader = context.StockIssuanceHeaders.First(x => x.stock_issuance_header_id == StockIssuanceHeaderEntity.stock_issuance_header_id);
                    context.StockIssuanceHeaders.Remove(_StockIssuanceHeader);
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

        public bool validate(StockIssuanceHeader StockIssuanceHeaderEntity)
        {
            if (StockIssuanceHeaderEntity != null)
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
