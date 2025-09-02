using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class PartyMasterDL : IPartyMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<PartyMaster> queryable;

        public IQueryable<PartyMaster> GetAll()
        {
            queryable = context.PartyMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.PartyMasters.Where(x => x.party_master_id == Id);
            return queryable;
        }

        public IQueryable<PartyMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public PartyMaster Create(PartyMaster PartyMasterEntity, string loggedInUser)
        {
            if (validate(PartyMasterEntity))
            {
                try
                {
                   
                    PartyMasterEntity.modified_on = DateTime.Now;
                    PartyMasterEntity.created_on = DateTime.Now;
                    PartyMasterEntity.created_by = 0;
                    PartyMasterEntity.modified_by = 0;
                    PartyMasterEntity.user_ip = "";
                    PartyMasterEntity.is_active = true;
                   
                    PartyMasterEntity = context.PartyMasters.Add(PartyMasterEntity);
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
            return PartyMasterEntity;
        }

        public PartyMaster Update(PartyMaster PartyMasterEntity, string loggedInUser)
        {
            PartyMaster objPartyMaster = null;
            if (validate(PartyMasterEntity))
            {
                try
                {
                    objPartyMaster = context.PartyMasters.Find(PartyMasterEntity.party_master_id);

                    context.Entry(objPartyMaster).CurrentValues.SetValues(PartyMasterEntity);

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
            return objPartyMaster;
        }

        public bool Delete(PartyMaster PartyMasterEntity, string loggedInUser)
        {
            if (validate(PartyMasterEntity))
            {
                try
                {
                    PartyMaster _PartyMaster = context.PartyMasters.First(x => x.party_master_id == PartyMasterEntity.party_master_id);
                    context.PartyMasters.Remove(_PartyMaster);
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

        public bool validate(PartyMaster PartyMasterEntity)
        {
            if (PartyMasterEntity != null)
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
