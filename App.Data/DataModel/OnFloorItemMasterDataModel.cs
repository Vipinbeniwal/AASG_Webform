using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class OnFloorItemMasterDL : IOnFloorItemMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<OnFloorItemMaster> queryable;

        public IQueryable<OnFloorItemMaster> GetAll()
        {
            queryable = context.OnFloorItemMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.OnFloorItemMasters.Where(x => x.on_floor_item_master_id == Id);
            return queryable;
        }

        public IQueryable<OnFloorItemMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public OnFloorItemMaster Create(OnFloorItemMaster OnFloorItemMasterEntity, string loggedInUser)
        {
            if (validate(OnFloorItemMasterEntity))
            {
                try
                {
                   
                    OnFloorItemMasterEntity.modified_on = DateTime.Now;
                    OnFloorItemMasterEntity.created_on = DateTime.Now;
                    OnFloorItemMasterEntity.created_by = 0;
                    OnFloorItemMasterEntity.modified_by = 0;
                    OnFloorItemMasterEntity.user_ip = "";
                    OnFloorItemMasterEntity.is_active = true;
                   
                    OnFloorItemMasterEntity = context.OnFloorItemMasters.Add(OnFloorItemMasterEntity);
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
            return OnFloorItemMasterEntity;
        }

        public OnFloorItemMaster Update(OnFloorItemMaster OnFloorItemMasterEntity, string loggedInUser)
        {
            OnFloorItemMaster objOnFloorItemMaster = null;
            if (validate(OnFloorItemMasterEntity))
            {
                try
                {
                    objOnFloorItemMaster = context.OnFloorItemMasters.Find(OnFloorItemMasterEntity.on_floor_item_master_id);

                    context.Entry(objOnFloorItemMaster).CurrentValues.SetValues(OnFloorItemMasterEntity);

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
            return objOnFloorItemMaster;
        }

        public bool Delete(OnFloorItemMaster OnFloorItemMasterEntity, string loggedInUser)
        {
            if (validate(OnFloorItemMasterEntity))
            {
                try
                {
                    OnFloorItemMaster _OnFloorItemMaster = context.OnFloorItemMasters.First(x => x.on_floor_item_master_id == OnFloorItemMasterEntity.on_floor_item_master_id);
                    context.OnFloorItemMasters.Remove(_OnFloorItemMaster);
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

        public bool validate(OnFloorItemMaster OnFloorItemMasterEntity)
        {
            if (OnFloorItemMasterEntity != null)
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
