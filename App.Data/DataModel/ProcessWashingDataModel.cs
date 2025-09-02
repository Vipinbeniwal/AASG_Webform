using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessWashingDL : IProcessWashing, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessWashing> queryable;

        public IQueryable<ProcessWashing> GetAll()
        {
            queryable = context.ProcessWashings;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessWashings.Where(x => x.process_washing_id == Id);
            return queryable;
        }

        public IQueryable<ProcessWashing> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessWashing Create(ProcessWashing ProcessWashingEntity, string loggedInUser)
        {
            if (validate(ProcessWashingEntity))
            {
                try
                {
                   
                    ProcessWashingEntity.modified_on = DateTime.Now;
                    ProcessWashingEntity.created_on = DateTime.Now;
                    ProcessWashingEntity.created_by = 0;
                    ProcessWashingEntity.modified_by = 0;
                    ProcessWashingEntity.user_ip = "";
                    ProcessWashingEntity.is_active = true;
                   
                    ProcessWashingEntity = context.ProcessWashings.Add(ProcessWashingEntity);
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
            return ProcessWashingEntity;
        }

        public ProcessWashing Update(ProcessWashing ProcessWashingEntity, string loggedInUser)
        {
            ProcessWashing objProcessWashing = null;
            if (validate(ProcessWashingEntity))
            {
                try
                {
                    objProcessWashing = context.ProcessWashings.Find(ProcessWashingEntity.process_washing_id);

                    context.Entry(objProcessWashing).CurrentValues.SetValues(ProcessWashingEntity);

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
            return objProcessWashing;
        }

        public bool Delete(ProcessWashing ProcessWashingEntity, string loggedInUser)
        {
            if (validate(ProcessWashingEntity))
            {
                try
                {
                    ProcessWashing _ProcessWashing = context.ProcessWashings.First(x => x.process_washing_id == ProcessWashingEntity.process_washing_id);
                    context.ProcessWashings.Remove(_ProcessWashing);
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

        public bool validate(ProcessWashing ProcessWashingEntity)
        {
            if (ProcessWashingEntity != null)
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
