using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class StaffMasterDL : IStaffMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<StaffMaster> queryable;

        public IQueryable<StaffMaster> GetAll()
        {
            queryable = context.StaffMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.StaffMasters.Where(x => x.staff_master_id == Id);
            return queryable;
        }

        public IQueryable<StaffMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public StaffMaster Create(StaffMaster StaffMasterEntity, string loggedInUser)
        {
            if (validate(StaffMasterEntity))
            {
                try
                {
                   
                    StaffMasterEntity.modified_on = DateTime.Now;
                    StaffMasterEntity.created_on = DateTime.Now;
                    StaffMasterEntity.created_by = 0;
                    StaffMasterEntity.modified_by = 0;
                    StaffMasterEntity.user_ip = "";
                    StaffMasterEntity.is_active = true;
                   
                    StaffMasterEntity = context.StaffMasters.Add(StaffMasterEntity);
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
            return StaffMasterEntity;
        }

        public StaffMaster Update(StaffMaster StaffMasterEntity, string loggedInUser)
        {
            StaffMaster objStaffMaster = null;
            if (validate(StaffMasterEntity))
            {
                try
                {
                    objStaffMaster = context.StaffMasters.Find(StaffMasterEntity.staff_master_id);

                    context.Entry(objStaffMaster).CurrentValues.SetValues(StaffMasterEntity);

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
            return objStaffMaster;
        }

        public bool Delete(StaffMaster StaffMasterEntity, string loggedInUser)
        {
            if (validate(StaffMasterEntity))
            {
                try
                {
                    StaffMaster _StaffMaster = context.StaffMasters.First(x => x.staff_master_id == StaffMasterEntity.staff_master_id);
                    context.StaffMasters.Remove(_StaffMaster);
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

        public bool validate(StaffMaster StaffMasterEntity)
        {
            if (StaffMasterEntity != null)
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
