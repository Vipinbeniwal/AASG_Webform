using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessDfgPrintDL : IProcessDfgPrint, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessDfgPrint> queryable;

        public IQueryable<ProcessDfgPrint> GetAll()
        {
            queryable = context.ProcessDfgPrints;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessDfgPrints.Where(x => x.process_dfg_print_id == Id);
            return queryable;
        }

        public IQueryable<ProcessDfgPrint> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessDfgPrint Create(ProcessDfgPrint ProcessDfgPrintEntity, string loggedInUser)
        {
            if (validate(ProcessDfgPrintEntity))
            {
                try
                {
                   
                    ProcessDfgPrintEntity.modified_on = DateTime.Now;
                    ProcessDfgPrintEntity.created_on = DateTime.Now;
                    ProcessDfgPrintEntity.created_by = 0;
                    ProcessDfgPrintEntity.modified_by = 0;
                    ProcessDfgPrintEntity.user_ip = "";
                    ProcessDfgPrintEntity.is_active = true;
                   
                    ProcessDfgPrintEntity = context.ProcessDfgPrints.Add(ProcessDfgPrintEntity);
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
            return ProcessDfgPrintEntity;
        }

        public ProcessDfgPrint Update(ProcessDfgPrint ProcessDfgPrintEntity, string loggedInUser)
        {
            ProcessDfgPrint objProcessDfgPrint = null;
            if (validate(ProcessDfgPrintEntity))
            {
                try
                {
                    objProcessDfgPrint = context.ProcessDfgPrints.Find(ProcessDfgPrintEntity.process_dfg_print_id);

                    context.Entry(objProcessDfgPrint).CurrentValues.SetValues(ProcessDfgPrintEntity);

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
            return objProcessDfgPrint;
        }

        public bool Delete(ProcessDfgPrint ProcessDfgPrintEntity, string loggedInUser)
        {
            if (validate(ProcessDfgPrintEntity))
            {
                try
                {
                    ProcessDfgPrint _ProcessDfgPrint = context.ProcessDfgPrints.First(x => x.process_dfg_print_id == ProcessDfgPrintEntity.process_dfg_print_id);
                    context.ProcessDfgPrints.Remove(_ProcessDfgPrint);
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

        public bool validate(ProcessDfgPrint ProcessDfgPrintEntity)
        {
            if (ProcessDfgPrintEntity != null)
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
