using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessGrindingDL : IProcessGrinding, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessGrinding> queryable;

        public IQueryable<ProcessGrinding> GetAll()
        {
            queryable = context.ProcessGrindings;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessGrindings.Where(x => x.process_grinding_id == Id);
            return queryable;
        }

        public IQueryable<ProcessGrinding> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessGrinding Create(ProcessGrinding ProcessGrindingEntity, string loggedInUser)
        {
            if (validate(ProcessGrindingEntity))
            {
                try
                {
                   
                    ProcessGrindingEntity.modified_on = DateTime.Now;
                    ProcessGrindingEntity.created_on = DateTime.Now;
                    ProcessGrindingEntity.created_by = 0;
                    ProcessGrindingEntity.modified_by = 0;
                    ProcessGrindingEntity.user_ip = "";
                    ProcessGrindingEntity.is_active = true;
                   
                    ProcessGrindingEntity = context.ProcessGrindings.Add(ProcessGrindingEntity);
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
            return ProcessGrindingEntity;
        }

        public ProcessGrinding Update(ProcessGrinding ProcessGrindingEntity, string loggedInUser)
        {
            ProcessGrinding objProcessGrinding = null;
            if (validate(ProcessGrindingEntity))
            {
                try
                {
                    objProcessGrinding = context.ProcessGrindings.Find(ProcessGrindingEntity.process_grinding_id);

                    context.Entry(objProcessGrinding).CurrentValues.SetValues(ProcessGrindingEntity);

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
            return objProcessGrinding;
        }

        public bool Delete(ProcessGrinding ProcessGrindingEntity, string loggedInUser)
        {
            if (validate(ProcessGrindingEntity))
            {
                try
                {
                    ProcessGrinding _ProcessGrinding = context.ProcessGrindings.First(x => x.process_grinding_id == ProcessGrindingEntity.process_grinding_id);
                    context.ProcessGrindings.Remove(_ProcessGrinding);
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

        public bool validate(ProcessGrinding ProcessGrindingEntity)
        {
            if (ProcessGrindingEntity != null)
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
