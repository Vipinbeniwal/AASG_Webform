using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class SaleItemDL : ISaleItem, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<SaleItem> queryable;

        public IQueryable<SaleItem> GetAll()
        {
            queryable = context.SaleItems;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.SaleItems.Where(x => x.sale_header_id == Id);
            return queryable;
        }

        public IQueryable<SaleItem> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public SaleItem Create(SaleItem SaleItemEntity, string loggedInUser)
        {
            if (validate(SaleItemEntity))
            {
                try
                {
                   
                    SaleItemEntity.modified_on = DateTime.Now;
                    SaleItemEntity.created_on = DateTime.Now;
                    SaleItemEntity.created_by = 0;
                    SaleItemEntity.modified_by = 0;
                    SaleItemEntity.user_ip = "";
                    SaleItemEntity.is_active = true;
                   
                    SaleItemEntity = context.SaleItems.Add(SaleItemEntity);
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
            return SaleItemEntity;
        }

        public SaleItem Update(SaleItem SaleItemEntity, string loggedInUser)
        {
            SaleItem objSaleItem = null;
            if (validate(SaleItemEntity))
            {
                try
                {
                    objSaleItem = context.SaleItems.Find(SaleItemEntity.sale_header_id);

                    context.Entry(objSaleItem).CurrentValues.SetValues(SaleItemEntity);

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
            return objSaleItem;
        }

        public bool Delete(SaleItem SaleItemEntity, string loggedInUser)
        {
            if (validate(SaleItemEntity))
            {
                try
                {
                    using (DBEntities _dbEntities = new DBEntities())
                    {
                        if (SaleItemEntity.sale_header_id > 0)
                        {
                            //_dbEntities.Database.ExecuteSqlCommand("delete from saleheader where sale_header_id=" + SaleItemEntity.sale_header_id);


                            _dbEntities.Database.ExecuteSqlCommand("delete from saleitem where sale_header_id=" + SaleItemEntity.sale_header_id);
                            _dbEntities.SaveChanges();
                        }

                    }
                    //SaleItem _SaleItem = context.SaleItems.First(x => x.sale_header_id == SaleItemEntity.sale_header_id);
                    //context.SaleItems.Remove(_SaleItem);
                    //context.SaveChanges();
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

        public bool validate(SaleItem SaleItemEntity)
        {
            if (SaleItemEntity != null)
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
