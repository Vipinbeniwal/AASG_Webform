using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class SupplierMasterDL : ISupplierMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<SupplierMaster> queryable;

        public IQueryable<SupplierMaster> GetAll()
        {
            queryable = context.SupplierMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.SupplierMasters.Where(x => x.supplier_master_id == Id);
            return queryable;
        }

        public IQueryable<SupplierMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public SupplierMaster Create(SupplierMaster SupplierMasterEntity, string loggedInUser)
        {
            if (validate(SupplierMasterEntity))
            {
                try
                {
                   
                    SupplierMasterEntity.modified_on = DateTime.Now;
                    SupplierMasterEntity.created_on = DateTime.Now;
                    SupplierMasterEntity.created_by = 0;
                    SupplierMasterEntity.modified_by = 0;
                    SupplierMasterEntity.user_ip = "";
                    SupplierMasterEntity.is_active = true;
                   
                    SupplierMasterEntity = context.SupplierMasters.Add(SupplierMasterEntity);
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
            return SupplierMasterEntity;
        }

        public SupplierMaster Update(SupplierMaster SupplierMasterEntity, string loggedInUser)
        {
            SupplierMaster objSupplierMaster = null;
            if (validate(SupplierMasterEntity))
            {
                try
                {
                    objSupplierMaster = context.SupplierMasters.Find(SupplierMasterEntity.supplier_master_id);

                    context.Entry(objSupplierMaster).CurrentValues.SetValues(SupplierMasterEntity);

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
            return objSupplierMaster;
        }

        public bool Delete(SupplierMaster SupplierMasterEntity, string loggedInUser)
        {
            if (validate(SupplierMasterEntity))
            {
                try
                {
                    SupplierMaster _SupplierMaster = context.SupplierMasters.First(x => x.supplier_master_id == SupplierMasterEntity.supplier_master_id);
                    context.SupplierMasters.Remove(_SupplierMaster);
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

        public bool validate(SupplierMaster SupplierMasterEntity)
        {
            if (SupplierMasterEntity != null)
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
