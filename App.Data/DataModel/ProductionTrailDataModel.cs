using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProductionTrailDL : IProductionTrail, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProductionTrail> queryable;

        public IQueryable<ProductionTrail> GetAll()
        {
            queryable = context.ProductionTrails;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProductionTrails.Where(x => x.production_trail_id == Id);
            return queryable;
        }

        public IQueryable<ProductionTrail> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProductionTrail Create(ProductionTrail ProductionTrailEntity, string loggedInUser)
        {
            if (validate(ProductionTrailEntity))
            {
                try
                {
                    ProductionTrailEntity.modified_on = DateTime.Now;
                    ProductionTrailEntity.created_on = DateTime.Now;
                    ProductionTrailEntity.created_by = 0;
                    ProductionTrailEntity.modified_by = 0;
                    ProductionTrailEntity.user_ip = "";
                    ProductionTrailEntity.is_active = true;
                    ProductionTrailEntity = context.ProductionTrails.Add(ProductionTrailEntity);
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
            return ProductionTrailEntity;

           
        }

        public ProductionTrail Update(ProductionTrail ProductionTrailEntity, string loggedInUser)
        {
            ProductionTrail objProductionTrail = null;
            if (validate(ProductionTrailEntity))
            {
                objProductionTrail = context.ProductionTrails.Find(ProductionTrailEntity.production_trail_id);

                context.Entry(objProductionTrail).CurrentValues.SetValues(ProductionTrailEntity);

                context.SaveChanges();
            }
            return objProductionTrail;
        }

        public bool Delete(ProductionTrail ProductionTrailEntity, string loggedInUser)
        {
            if (validate(ProductionTrailEntity))
            {
                try
                {
                    ProductionTrail _ProductionTrail = context.ProductionTrails.First(x => x.production_trail_id == ProductionTrailEntity.production_trail_id);
                    context.ProductionTrails.Remove(_ProductionTrail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(ProductionTrail ProductionTrailEntity)
        {
            if (ProductionTrailEntity != null)
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
