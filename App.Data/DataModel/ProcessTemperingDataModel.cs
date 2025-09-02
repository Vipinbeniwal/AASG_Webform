using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessTemperingDL : IProcessTempering, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessTempering> queryable;

        public IQueryable<ProcessTempering> GetAll()
        {
            queryable = context.ProcessTemperings;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessTemperings.Where(x => x.process_tempering_id == Id);
            return queryable;
        }

        public IQueryable<ProcessTempering> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessTempering Create(ProcessTempering ProcessTemperingEntity, string loggedInUser)
        {
            if (validate(ProcessTemperingEntity))
            {
                try
                {
                   
                    ProcessTemperingEntity.modified_on = DateTime.Now;
                    ProcessTemperingEntity.created_on = DateTime.Now;
                    ProcessTemperingEntity.created_by = 0;
                    ProcessTemperingEntity.modified_by = 0;
                    ProcessTemperingEntity.user_ip = "";
                    ProcessTemperingEntity.is_active = true;
                   
                    ProcessTemperingEntity = context.ProcessTemperings.Add(ProcessTemperingEntity);
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
            return ProcessTemperingEntity;
        }

        public ProcessTempering Update(ProcessTempering ProcessTemperingEntity, string loggedInUser)
        {
            ProcessTempering objProcessTempering = null;
            if (validate(ProcessTemperingEntity))
            {
                try
                {
                    objProcessTempering = context.ProcessTemperings.Find(ProcessTemperingEntity.process_tempering_id);

                    context.Entry(objProcessTempering).CurrentValues.SetValues(ProcessTemperingEntity);

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
            return objProcessTempering;
        }

        public bool Delete(ProcessTempering ProcessTemperingEntity, string loggedInUser)
        {
            if (validate(ProcessTemperingEntity))
            {
                try
                {
                    ProcessTempering _ProcessTempering = context.ProcessTemperings.First(x => x.process_tempering_id == ProcessTemperingEntity.process_tempering_id);
                    context.ProcessTemperings.Remove(_ProcessTempering);
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

        public bool validate(ProcessTempering ProcessTemperingEntity)
        {
            if (ProcessTemperingEntity != null)
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
