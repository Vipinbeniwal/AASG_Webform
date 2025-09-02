using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class xp_ProcurementHeaderDL : Ixp_ProcurementHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<xp_ProcurementHeader> queryable;
        IQueryable<vwxp_ProcurementHeaderSupplierDetail> queryable1;


        public IQueryable<xp_ProcurementHeader> GetAll()
        {
            queryable = context.xp_ProcurementHeader;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.xp_ProcurementHeader.Where(x => x.xp_procurement_header_id == Id);
            return queryable;
        }

        public IQueryable<vwxp_ProcurementHeaderSupplierDetail> GetAllxp_ProcurementHeaderSupplierDetail()
        {
            queryable1 = context.vwxp_ProcurementHeaderSupplierDetail;
            return queryable1;
        }

        public IQueryable<xp_ProcurementHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public xp_ProcurementHeader Create(xp_ProcurementHeader xp_ProcurementHeaderEntity, string loggedInUser)
        {
            if (validate(xp_ProcurementHeaderEntity))
            {
                try
                {
                   
                    xp_ProcurementHeaderEntity.modified_on = DateTime.Now;
                    xp_ProcurementHeaderEntity.created_on = DateTime.Now;
                    xp_ProcurementHeaderEntity.created_by = 0;
                    xp_ProcurementHeaderEntity.modified_by = 0;
                    xp_ProcurementHeaderEntity.user_ip = "";
                    xp_ProcurementHeaderEntity.is_active = true;
                   
                    xp_ProcurementHeaderEntity = context.xp_ProcurementHeader.Add(xp_ProcurementHeaderEntity);
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
            return xp_ProcurementHeaderEntity;
        }

        public xp_ProcurementHeader Update(xp_ProcurementHeader xp_ProcurementHeaderEntity, string loggedInUser)
        {
            xp_ProcurementHeader objxp_ProcurementHeader = null;
            if (validate(xp_ProcurementHeaderEntity))
            {
                try
                {
                    objxp_ProcurementHeader = context.xp_ProcurementHeader.Find(xp_ProcurementHeaderEntity.xp_procurement_header_id);

                    context.Entry(objxp_ProcurementHeader).CurrentValues.SetValues(xp_ProcurementHeaderEntity);

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
            return objxp_ProcurementHeader;
        }

        public bool Delete(xp_ProcurementHeader xp_ProcurementHeaderEntity, string loggedInUser)
        {
            if (validate(xp_ProcurementHeaderEntity))
            {
                try
                {
                    xp_ProcurementHeader _xp_ProcurementHeader = context.xp_ProcurementHeader.First(x => x.xp_procurement_header_id == xp_ProcurementHeaderEntity.xp_procurement_header_id);
                    context.xp_ProcurementHeader.Remove(_xp_ProcurementHeader);
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

        public bool validate(xp_ProcurementHeader xp_ProcurementHeaderEntity)
        {
            if (xp_ProcurementHeaderEntity != null)
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
