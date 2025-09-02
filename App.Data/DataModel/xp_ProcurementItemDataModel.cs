using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class xp_ProcurementItemDL : Ixp_ProcurementItem, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<xp_ProcurementItem> queryable;

        public IQueryable<xp_ProcurementItem> GetAll()
        {
            queryable = context.xp_ProcurementItem;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.xp_ProcurementItem.Where(x => x.xp_procurement_header_id == Id);
            return queryable;
        }

        public IQueryable<xp_ProcurementItem> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public xp_ProcurementItem Create(xp_ProcurementItem xp_ProcurementItemEntity, string loggedInUser)
        {
            if (validate(xp_ProcurementItemEntity))
            {
                try
                {
                   
                    xp_ProcurementItemEntity.modified_on = DateTime.Now;
                    xp_ProcurementItemEntity.created_on = DateTime.Now;
                    xp_ProcurementItemEntity.created_by = 0;
                    xp_ProcurementItemEntity.modified_by = 0;
                    xp_ProcurementItemEntity.user_ip = "";
                    xp_ProcurementItemEntity.is_active = true;
                   
                    xp_ProcurementItemEntity = context.xp_ProcurementItem.Add(xp_ProcurementItemEntity);
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
            return xp_ProcurementItemEntity;
        }

        public xp_ProcurementItem Update(xp_ProcurementItem xp_ProcurementItemEntity, string loggedInUser)
        {
            xp_ProcurementItem objxp_ProcurementItem = null;
            if (validate(xp_ProcurementItemEntity))
            {
                try
                {
                    objxp_ProcurementItem = context.xp_ProcurementItem.Find(xp_ProcurementItemEntity.xp_procurement_header_id);

                    context.Entry(objxp_ProcurementItem).CurrentValues.SetValues(xp_ProcurementItemEntity);

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
            return objxp_ProcurementItem;
        }

        public bool Delete(xp_ProcurementItem xp_ProcurementItemEntity, string loggedInUser)
        {
            if (validate(xp_ProcurementItemEntity))
            {
                try
                {
                    xp_ProcurementItem _xp_ProcurementItem = context.xp_ProcurementItem.First(x => x.xp_procurement_header_id == xp_ProcurementItemEntity.xp_procurement_header_id);
                    context.xp_ProcurementItem.Remove(_xp_ProcurementItem);
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

        public bool validate(xp_ProcurementItem xp_ProcurementItemEntity)
        {
            if (xp_ProcurementItemEntity != null)
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
