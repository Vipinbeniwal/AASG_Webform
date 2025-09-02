using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessHoleDL : IProcessHole, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessHole> queryable;

        public IQueryable<ProcessHole> GetAll()
        {
            queryable = context.ProcessHoles;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessHoles.Where(x => x.process_hole_id == Id);
            return queryable;
        }

        public IQueryable<ProcessHole> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessHole Create(ProcessHole ProcessHoleEntity, string loggedInUser)
        {
            if (validate(ProcessHoleEntity))
            {
                try
                {
                   
                    ProcessHoleEntity.modified_on = DateTime.Now;
                    ProcessHoleEntity.created_on = DateTime.Now;
                    ProcessHoleEntity.created_by = 0;
                    ProcessHoleEntity.modified_by = 0;
                    ProcessHoleEntity.user_ip = "";
                    ProcessHoleEntity.is_active = true;
                   
                    ProcessHoleEntity = context.ProcessHoles.Add(ProcessHoleEntity);
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
            return ProcessHoleEntity;
        }

        public ProcessHole Update(ProcessHole ProcessHoleEntity, string loggedInUser)
        {
            ProcessHole objProcessHole = null;
            if (validate(ProcessHoleEntity))
            {
                try
                {
                    objProcessHole = context.ProcessHoles.Find(ProcessHoleEntity.process_hole_id);

                    context.Entry(objProcessHole).CurrentValues.SetValues(ProcessHoleEntity);

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
            return objProcessHole;
        }

        public bool Delete(ProcessHole ProcessHoleEntity, string loggedInUser)
        {
            if (validate(ProcessHoleEntity))
            {
                try
                {
                    ProcessHole _ProcessHole = context.ProcessHoles.First(x => x.process_hole_id == ProcessHoleEntity.process_hole_id);
                    context.ProcessHoles.Remove(_ProcessHole);
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

        public bool validate(ProcessHole ProcessHoleEntity)
        {
            if (ProcessHoleEntity != null)
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
