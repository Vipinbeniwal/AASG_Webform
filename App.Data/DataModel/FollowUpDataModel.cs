using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class FollowUpDL : IFollowUp, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<FollowUp> queryable;

        public IQueryable<FollowUp> GetAll()
        {
            queryable = context.FollowUps;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.FollowUps.Where(x => x.lead_header_id == Id);
            return queryable;
        }

        public IQueryable<FollowUp> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public FollowUp Create(FollowUp FollowUpEntity, string loggedInUser)
        {
            if (validate(FollowUpEntity))
            {
                try
                {
                   
                    FollowUpEntity.modified_on = DateTime.Now;
                    FollowUpEntity.created_on = DateTime.Now;
                    FollowUpEntity.created_by = 0;
                    FollowUpEntity.modified_by = 0;
                    FollowUpEntity.user_ip = "";
                    FollowUpEntity.is_active = true;
                   
                    FollowUpEntity = context.FollowUps.Add(FollowUpEntity);
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
            return FollowUpEntity;
        }

        public FollowUp Update(FollowUp FollowUpEntity, string loggedInUser)
        {
            FollowUp objFollowUp = null;
            if (validate(FollowUpEntity))
            {
                try
                {
                    objFollowUp = context.FollowUps.Find(FollowUpEntity.lead_header_id);

                    context.Entry(objFollowUp).CurrentValues.SetValues(FollowUpEntity);

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
            return objFollowUp;
        }

        public bool Delete(FollowUp FollowUpEntity, string loggedInUser)
        {
            if (validate(FollowUpEntity))
            {
                try
                {
                    FollowUp _FollowUp = context.FollowUps.First(x => x.lead_header_id == FollowUpEntity.lead_header_id);
                    context.FollowUps.Remove(_FollowUp);
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

        public bool validate(FollowUp FollowUpEntity)
        {
            if (FollowUpEntity != null)
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
