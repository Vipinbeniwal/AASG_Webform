using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessWashingOneDL : IProcessWashingOne, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessWashingOne> queryable;

        public IQueryable<ProcessWashingOne> GetAll()
        {
            queryable = context.ProcessWashingOnes;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessWashingOnes.Where(x => x.process_washing_one_id == Id);
            return queryable;
        }

        public IQueryable<ProcessWashingOne> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessWashingOne Create(ProcessWashingOne ProcessWashingOneEntity, string loggedInUser)
        {
            if (validate(ProcessWashingOneEntity))
            {
                try
                {
                   
                    ProcessWashingOneEntity.modified_on = DateTime.Now;
                    ProcessWashingOneEntity.created_on = DateTime.Now;
                    ProcessWashingOneEntity.created_by = 0;
                    ProcessWashingOneEntity.modified_by = 0;
                    ProcessWashingOneEntity.user_ip = "";
                    ProcessWashingOneEntity.is_active = true;
                   
                    ProcessWashingOneEntity = context.ProcessWashingOnes.Add(ProcessWashingOneEntity);
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
            return ProcessWashingOneEntity;
        }

        public ProcessWashingOne Update(ProcessWashingOne ProcessWashingOneEntity, string loggedInUser)
        {
            ProcessWashingOne objProcessWashingOne = null;
            if (validate(ProcessWashingOneEntity))
            {
                try
                {
                    objProcessWashingOne = context.ProcessWashingOnes.Find(ProcessWashingOneEntity.process_washing_one_id);

                    context.Entry(objProcessWashingOne).CurrentValues.SetValues(ProcessWashingOneEntity);

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
            return objProcessWashingOne;
        }

        public bool Delete(ProcessWashingOne ProcessWashingOneEntity, string loggedInUser)
        {
            if (validate(ProcessWashingOneEntity))
            {
                try
                {
                    ProcessWashingOne _ProcessWashingOne = context.ProcessWashingOnes.First(x => x.process_washing_one_id == ProcessWashingOneEntity.process_washing_one_id);
                    context.ProcessWashingOnes.Remove(_ProcessWashingOne);
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

        public bool validate(ProcessWashingOne ProcessWashingOneEntity)
        {
            if (ProcessWashingOneEntity != null)
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
