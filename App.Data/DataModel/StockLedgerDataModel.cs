using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class StockLedgerDL : IStockLedger, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<StockLedger> queryable;

        public IQueryable<StockLedger> GetAll()
        {
            queryable = context.StockLedgers;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.StockLedgers.Where(x => x.stock_ledger_id == Id);
            return queryable;
        }

        public IQueryable<StockLedger> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public StockLedger Create(StockLedger StockLedgerEntity, string loggedInUser)
        {
            if (validate(StockLedgerEntity))
            {
                try
                {
                   
                    StockLedgerEntity.modified_on = DateTime.Now;
                    StockLedgerEntity.created_on = DateTime.Now;
                    StockLedgerEntity.created_by = 0;
                    StockLedgerEntity.modified_by = 0;
                    StockLedgerEntity.user_ip = "";
                    StockLedgerEntity.is_active = true;
                   
                    StockLedgerEntity = context.StockLedgers.Add(StockLedgerEntity);
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
            return StockLedgerEntity;
        }

        public StockLedger Update(StockLedger StockLedgerEntity, string loggedInUser)
        {
            StockLedger objStockLedger = null;
            if (validate(StockLedgerEntity))
            {
                try
                {
                    objStockLedger = context.StockLedgers.Find(StockLedgerEntity.stock_ledger_id);

                    context.Entry(objStockLedger).CurrentValues.SetValues(StockLedgerEntity);

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
            return objStockLedger;
        }

        public bool Delete(StockLedger StockLedgerEntity, string loggedInUser)
        {
            if (validate(StockLedgerEntity))
            {
                try
                {
                    StockLedger _StockLedger = context.StockLedgers.First(x => x.stock_ledger_id == StockLedgerEntity.stock_ledger_id);
                    context.StockLedgers.Remove(_StockLedger);
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

        public bool validate(StockLedger StockLedgerEntity)
        {
            if (StockLedgerEntity != null)
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
