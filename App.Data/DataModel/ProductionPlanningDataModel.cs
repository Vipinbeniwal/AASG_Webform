using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProductionPlanningDL : IProductionPlanning, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProductionPlanning> queryable;
        
        public IQueryable<ProductionPlanning> GetAll()
        {
            queryable = context.ProductionPlannings;
            return queryable;
        }
        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProductionPlannings.Where(x => x.production_planning_id == Id);
            return queryable;
        }

       

        public IQueryable<ProductionPlanning> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProductionPlanning Create(ProductionPlanning ProductionPlanningEntity, string loggedInUser)
        {
            if (validate(ProductionPlanningEntity))
            {
                try
                {
                    ProductionPlanningEntity.modified_on = DateTime.Now;
                    ProductionPlanningEntity.created_on = DateTime.Now;
                    ProductionPlanningEntity.created_by = 0;
                    ProductionPlanningEntity.modified_by = 0;
                    ProductionPlanningEntity.user_ip = "";
                    ProductionPlanningEntity.is_active = true;

                    ProductionPlanningEntity = context.ProductionPlannings.Add(ProductionPlanningEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return ProductionPlanningEntity;
        }

        public ProductionPlanning Update(ProductionPlanning ProductionPlanningEntity, string loggedInUser)
        {
            ProductionPlanning objProductionPlanning = null;
            if (validate(ProductionPlanningEntity))
            {
                objProductionPlanning = context.ProductionPlannings.Find(ProductionPlanningEntity.production_planning_id);

                context.Entry(objProductionPlanning).CurrentValues.SetValues(ProductionPlanningEntity);

                context.SaveChanges();
            }
            return objProductionPlanning;
        }

        public bool Delete(ProductionPlanning ProductionPlanningEntity, string loggedInUser)
        {
            if (validate(ProductionPlanningEntity))
            {
                try
                {
                    ProductionPlanning _ProductionPlanning = context.ProductionPlannings.First(x => x.production_planning_id == ProductionPlanningEntity.production_planning_id);
                    context.ProductionPlannings.Remove(_ProductionPlanning);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(ProductionPlanning ProductionPlanningEntity)
        {
            if (ProductionPlanningEntity != null)
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
