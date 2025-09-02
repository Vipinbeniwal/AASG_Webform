using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessPaintDL : IProcessPaint, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessPaint> queryable;

        public IQueryable<ProcessPaint> GetAll()
        {
            queryable = context.ProcessPaints;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessPaints.Where(x => x.process_paint_id == Id);
            return queryable;
        }

        public IQueryable<ProcessPaint> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessPaint Create(ProcessPaint ProcessPaintEntity, string loggedInUser)
        {
            if (validate(ProcessPaintEntity))
            {
                try
                {
                   
                    ProcessPaintEntity.modified_on = DateTime.Now;
                    ProcessPaintEntity.created_on = DateTime.Now;
                    ProcessPaintEntity.created_by = 0;
                    ProcessPaintEntity.modified_by = 0;
                    ProcessPaintEntity.user_ip = "";
                    ProcessPaintEntity.is_active = true;
                   
                    ProcessPaintEntity = context.ProcessPaints.Add(ProcessPaintEntity);
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
            return ProcessPaintEntity;
        }

        public ProcessPaint Update(ProcessPaint ProcessPaintEntity, string loggedInUser)
        {
            ProcessPaint objProcessPaint = null;
            if (validate(ProcessPaintEntity))
            {
                try
                {
                    objProcessPaint = context.ProcessPaints.Find(ProcessPaintEntity.process_paint_id);

                    context.Entry(objProcessPaint).CurrentValues.SetValues(ProcessPaintEntity);

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
            return objProcessPaint;
        }

        public bool Delete(ProcessPaint ProcessPaintEntity, string loggedInUser)
        {
            if (validate(ProcessPaintEntity))
            {
                try
                {
                    ProcessPaint _ProcessPaint = context.ProcessPaints.First(x => x.process_paint_id == ProcessPaintEntity.process_paint_id);
                    context.ProcessPaints.Remove(_ProcessPaint);
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

        public bool validate(ProcessPaint ProcessPaintEntity)
        {
            if (ProcessPaintEntity != null)
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
