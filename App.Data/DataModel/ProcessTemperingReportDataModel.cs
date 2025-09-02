using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ProcessTemperingReportDL : IProcessTemperingReport, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ProcessTemperingReport> queryable;

        public IQueryable<ProcessTemperingReport> GetAll()
        {
            queryable = context.ProcessTemperingReports;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ProcessTemperingReports.Where(x => x.process_tempering_report_id == Id);
            return queryable;
        }

        public IQueryable<ProcessTemperingReport> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ProcessTemperingReport Create(ProcessTemperingReport ProcessTemperingReportEntity, string loggedInUser)
        {
            if (validate(ProcessTemperingReportEntity))
            {
                try
                {
                   
                    ProcessTemperingReportEntity.modified_on = DateTime.Now;
                    ProcessTemperingReportEntity.created_on = DateTime.Now;
                    ProcessTemperingReportEntity.created_by = 0;
                    ProcessTemperingReportEntity.modified_by = 0;
                    ProcessTemperingReportEntity.user_ip = "";
                    ProcessTemperingReportEntity.is_active = true;
                   
                    ProcessTemperingReportEntity = context.ProcessTemperingReports.Add(ProcessTemperingReportEntity);
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
            return ProcessTemperingReportEntity;
        }

        public ProcessTemperingReport Update(ProcessTemperingReport ProcessTemperingReportEntity, string loggedInUser)
        {
            ProcessTemperingReport objProcessTemperingReport = null;
            if (validate(ProcessTemperingReportEntity))
            {
                try
                {
                    ProcessTemperingReportEntity.modified_on = DateTime.Now;
                    ProcessTemperingReportEntity.created_on = DateTime.Now;
                    ProcessTemperingReportEntity.created_by = 0;
                    ProcessTemperingReportEntity.modified_by = 0;
                   
                    ProcessTemperingReportEntity.is_active = true;

                    objProcessTemperingReport = context.ProcessTemperingReports.Find(ProcessTemperingReportEntity.process_tempering_report_id);

                    context.Entry(objProcessTemperingReport).CurrentValues.SetValues(ProcessTemperingReportEntity);

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
            return objProcessTemperingReport;
        }


        public ProcessTemperingReport UpdateByProcessTemperingId(ProcessTemperingReport ProcessTemperingReportEntity, string loggedInUser)
        {
            ProcessTemperingReport objProcessTemperingReport = null;
            if (validate(ProcessTemperingReportEntity))
            {
                try
                {
                    objProcessTemperingReport = context.ProcessTemperingReports.Find(ProcessTemperingReportEntity.process_tempering_id);

                    context.Entry(objProcessTemperingReport).CurrentValues.SetValues(ProcessTemperingReportEntity);

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
            return objProcessTemperingReport;
        }


        public bool Delete(ProcessTemperingReport ProcessTemperingReportEntity, string loggedInUser)
        {
            if (validate(ProcessTemperingReportEntity))
            {
                try
                {
                    ProcessTemperingReport _ProcessTemperingReport = context.ProcessTemperingReports.First(x => x.process_tempering_report_id == ProcessTemperingReportEntity.process_tempering_report_id);
                    context.ProcessTemperingReports.Remove(_ProcessTemperingReport);
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

        public bool validate(ProcessTemperingReport ProcessTemperingReportEntity)
        {
            if (ProcessTemperingReportEntity != null)
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
