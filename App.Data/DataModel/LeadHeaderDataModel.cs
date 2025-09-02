using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class LeadHeaderDL : ILeadHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<LeadHeader> queryable;

        public IQueryable<LeadHeader> GetAll()
        {
            queryable = context.LeadHeaders;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.LeadHeaders.Where(x => x.lead_header_id == Id);
            return queryable;
        }

        public IQueryable<LeadHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public LeadHeader Create(LeadHeader LeadHeaderEntity, string loggedInUser)
        {
            if (validate(LeadHeaderEntity))
            {
                try
                {
                   
                    LeadHeaderEntity.modified_on = DateTime.Now;
                    LeadHeaderEntity.created_on = DateTime.Now;
                    LeadHeaderEntity.created_by = 0;
                    LeadHeaderEntity.modified_by = 0;
                    LeadHeaderEntity.user_ip = "";
                    LeadHeaderEntity.is_active = true;
                   
                    LeadHeaderEntity = context.LeadHeaders.Add(LeadHeaderEntity);
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
            return LeadHeaderEntity;
        }

        public LeadHeader Update(LeadHeader LeadHeaderEntity, string loggedInUser)
        {
            LeadHeader objLeadHeader = null;
            if (validate(LeadHeaderEntity))
            {
                try
                {
                    objLeadHeader = context.LeadHeaders.Find(LeadHeaderEntity.lead_header_id);

                    context.Entry(objLeadHeader).CurrentValues.SetValues(LeadHeaderEntity);

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
            return objLeadHeader;
        }

        public bool Delete(LeadHeader LeadHeaderEntity, string loggedInUser)
        {
            if (validate(LeadHeaderEntity))
            {
                try
                {
                    LeadHeader _LeadHeader = context.LeadHeaders.First(x => x.lead_header_id == LeadHeaderEntity.lead_header_id);
                    context.LeadHeaders.Remove(_LeadHeader);
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

        public bool validate(LeadHeader LeadHeaderEntity)
        {
            if (LeadHeaderEntity != null)
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
