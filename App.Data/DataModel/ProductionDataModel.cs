using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProductionDL : IProduction, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<Production> queryable;
        IQueryable<Production> queryable2;

        public IQueryable<Production> GetAll()
        {
            queryable = context.Productions;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.Productions.Where(x => x.production_id == Id);
            return queryable;
        }

        public IQueryable GetProductionDetailsbyItemMasterId(int Id)
        {
            queryable2 = context.Productions.Where(x => x.item_master_id == Id && x.production_status != "complete" && x.production_status != "hold");
            return queryable2;
        }
        public IQueryable<Production> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public Production Create(Production ProductionEntity, string loggedInUser)
        {
            if (validate(ProductionEntity))
            {
                try
                {
                   
                    ProductionEntity.modified_on = DateTime.Now;
                    ProductionEntity.created_on = DateTime.Now;
                    ProductionEntity.created_by = 0;
                    ProductionEntity.modified_by = 0;
                    ProductionEntity.user_ip = "";
                    ProductionEntity.is_active = true;
                   
                    ProductionEntity = context.Productions.Add(ProductionEntity);
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
            return ProductionEntity;
        }

        public Production Update(Production ProductionEntity, string loggedInUser)
        {
            Production objProduction = null;
            if (validate(ProductionEntity))
            {
                try
                {
                    objProduction = context.Productions.Find(ProductionEntity.production_id);

                    context.Entry(objProduction).CurrentValues.SetValues(ProductionEntity);

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
            return objProduction;
        }

        public bool Delete(Production ProductionEntity, string loggedInUser)
        {
            if (validate(ProductionEntity))
            {
                try
                {
                    Production _Production = context.Productions.First(x => x.production_id == ProductionEntity.production_id);
                    context.Productions.Remove(_Production);
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

        public bool validate(Production ProductionEntity)
        {
            if (ProductionEntity != null)
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
