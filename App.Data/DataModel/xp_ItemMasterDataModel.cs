using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class xp_ItemMasterDL : Ixp_ItemMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<xp_ItemMaster> queryable;

        public IQueryable<xp_ItemMaster> GetAll()
        {
            queryable = context.xp_ItemMaster;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.xp_ItemMaster.Where(x => x.xp_item_master_id == Id);
            return queryable;
        }

        public IQueryable<xp_ItemMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public xp_ItemMaster Create(xp_ItemMaster xp_ItemMasterEntity, string loggedInUser)
        {
            if (validate(xp_ItemMasterEntity))
            {
                try
                {
                   
                    xp_ItemMasterEntity.modified_on = DateTime.Now;
                    xp_ItemMasterEntity.created_on = DateTime.Now;
                    xp_ItemMasterEntity.created_by = 0;
                    xp_ItemMasterEntity.modified_by = 0;
                    xp_ItemMasterEntity.user_ip = "";
                    xp_ItemMasterEntity.is_active = true;
                   
                    xp_ItemMasterEntity = context.xp_ItemMaster.Add(xp_ItemMasterEntity);
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
            return xp_ItemMasterEntity;
        }

        public xp_ItemMaster Update(xp_ItemMaster xp_ItemMasterEntity, string loggedInUser)
        {
            xp_ItemMaster objxp_ItemMaster = null;
            if (validate(xp_ItemMasterEntity))
            {
                try
                {
                    objxp_ItemMaster = context.xp_ItemMaster.Find(xp_ItemMasterEntity.xp_item_master_id);

                    context.Entry(objxp_ItemMaster).CurrentValues.SetValues(xp_ItemMasterEntity);

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
            return objxp_ItemMaster;
        }

        public bool Delete(xp_ItemMaster xp_ItemMasterEntity, string loggedInUser)
        {
            if (validate(xp_ItemMasterEntity))
            {
                try
                {
                    xp_ItemMaster _xp_ItemMaster = context.xp_ItemMaster.First(x => x.xp_item_master_id == xp_ItemMasterEntity.xp_item_master_id);
                    context.xp_ItemMaster.Remove(_xp_ItemMaster);
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

        public bool validate(xp_ItemMaster xp_ItemMasterEntity)
        {
            if (xp_ItemMasterEntity != null)
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
