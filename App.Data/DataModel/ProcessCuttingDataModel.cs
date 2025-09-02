using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessCuttingDL : IProcessCutting, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessCutting> queryable;

        public IQueryable<ProcessCutting> GetAll()
        {
            queryable = context.ProcessCuttings;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessCuttings.Where(x => x.process_cutting_id == Id);
            return queryable;
        }

        public IQueryable<ProcessCutting> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessCutting Create(ProcessCutting ProcessCuttingEntity, string loggedInUser)
        {
            if (validate(ProcessCuttingEntity))
            {
                try
                {
                   
                    ProcessCuttingEntity.modified_on = DateTime.Now;
                    ProcessCuttingEntity.created_on = DateTime.Now;
                    ProcessCuttingEntity.created_by = 0;
                    ProcessCuttingEntity.modified_by = 0;
                    ProcessCuttingEntity.user_ip = "";
                    ProcessCuttingEntity.is_active = true;
                   
                    ProcessCuttingEntity = context.ProcessCuttings.Add(ProcessCuttingEntity);
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
            return ProcessCuttingEntity;
        }

        public ProcessCutting Update(ProcessCutting ProcessCuttingEntity, string loggedInUser)
        {
            ProcessCutting objProcessCutting = null;
            if (validate(ProcessCuttingEntity))
            {
                try
                {
                    objProcessCutting = context.ProcessCuttings.Find(ProcessCuttingEntity.process_cutting_id);

                    context.Entry(objProcessCutting).CurrentValues.SetValues(ProcessCuttingEntity);

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
            return objProcessCutting;
        }

        public bool Delete(ProcessCutting ProcessCuttingEntity, string loggedInUser)
        {
            if (validate(ProcessCuttingEntity))
            {
                try
                {
                    ProcessCutting _ProcessCutting = context.ProcessCuttings.First(x => x.process_cutting_id == ProcessCuttingEntity.process_cutting_id);
                    context.ProcessCuttings.Remove(_ProcessCutting);
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

        public bool validate(ProcessCutting ProcessCuttingEntity)
        {
            if (ProcessCuttingEntity != null)
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
