using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessStoreDL : IProcessStore, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessStore> queryable;

        public IQueryable<ProcessStore> GetAll()
        {
            queryable = context.ProcessStores;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessStores.Where(x => x.process_store_id == Id);
            return queryable;
        }

        public IQueryable<ProcessStore> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessStore Create(ProcessStore ProcessStoreEntity, string loggedInUser)
        {
            if (validate(ProcessStoreEntity))
            {
                try
                {
                   
                    ProcessStoreEntity.modified_on = DateTime.Now;
                    ProcessStoreEntity.created_on = DateTime.Now;
                    ProcessStoreEntity.created_by = 0;
                    ProcessStoreEntity.modified_by = 0;
                    ProcessStoreEntity.user_ip = "";
                    ProcessStoreEntity.is_active = true;
                   
                    ProcessStoreEntity = context.ProcessStores.Add(ProcessStoreEntity);
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
            return ProcessStoreEntity;
        }

        public ProcessStore Update(ProcessStore ProcessStoreEntity, string loggedInUser)
        {
            ProcessStore objProcessStore = null;
            if (validate(ProcessStoreEntity))
            {
                try
                {
                    objProcessStore = context.ProcessStores.Find(ProcessStoreEntity.process_store_id);

                    context.Entry(objProcessStore).CurrentValues.SetValues(ProcessStoreEntity);

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
            return objProcessStore;
        }

        public bool Delete(ProcessStore ProcessStoreEntity, string loggedInUser)
        {
            if (validate(ProcessStoreEntity))
            {
                try
                {
                    ProcessStore _ProcessStore = context.ProcessStores.First(x => x.process_store_id == ProcessStoreEntity.process_store_id);
                    context.ProcessStores.Remove(_ProcessStore);
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

        public bool validate(ProcessStore ProcessStoreEntity)
        {
            if (ProcessStoreEntity != null)
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
