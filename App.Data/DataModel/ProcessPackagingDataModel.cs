using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessPackagingDL : IProcessPackaging, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessPackaging> queryable;

        public IQueryable<ProcessPackaging> GetAll()
        {
            queryable = context.ProcessPackagings;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessPackagings.Where(x => x.process_packaging_id == Id);
            return queryable;
        }

        public IQueryable<ProcessPackaging> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessPackaging Create(ProcessPackaging ProcessPackagingEntity, string loggedInUser)
        {
            if (validate(ProcessPackagingEntity))
            {
                try
                {
                   
                    ProcessPackagingEntity.modified_on = DateTime.Now;
                    ProcessPackagingEntity.created_on = DateTime.Now;
                    ProcessPackagingEntity.created_by = 0;
                    ProcessPackagingEntity.modified_by = 0;
                    ProcessPackagingEntity.user_ip = "";
                    ProcessPackagingEntity.is_active = true;
                   
                    ProcessPackagingEntity = context.ProcessPackagings.Add(ProcessPackagingEntity);
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
            return ProcessPackagingEntity;
        }

        public ProcessPackaging Update(ProcessPackaging ProcessPackagingEntity, string loggedInUser)
        {
            ProcessPackaging objProcessPackaging = null;
            if (validate(ProcessPackagingEntity))
            {
                try
                {
                    objProcessPackaging = context.ProcessPackagings.Find(ProcessPackagingEntity.process_packaging_id);

                    context.Entry(objProcessPackaging).CurrentValues.SetValues(ProcessPackagingEntity);

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
            return objProcessPackaging;
        }

        public bool Delete(ProcessPackaging ProcessPackagingEntity, string loggedInUser)
        {
            if (validate(ProcessPackagingEntity))
            {
                try
                {
                    ProcessPackaging _ProcessPackaging = context.ProcessPackagings.First(x => x.process_packaging_id == ProcessPackagingEntity.process_packaging_id);
                    context.ProcessPackagings.Remove(_ProcessPackaging);
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

        public bool validate(ProcessPackaging ProcessPackagingEntity)
        {
            if (ProcessPackagingEntity != null)
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
