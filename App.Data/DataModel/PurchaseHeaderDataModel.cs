using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class PurchaseHeaderDL : IPurchaseHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<PurchaseHeader> queryable;
        IQueryable<vwPurchaseHeaderSupplierDetail>  queryable1;
        IQueryable<vwPurchaseOrderDashboardData> queryable2;


        public IQueryable<PurchaseHeader> GetAll()
        {
            queryable = context.PurchaseHeaders;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.PurchaseHeaders.Where(x => x.purchase_header_id == Id);
            return queryable;
        }

        public IQueryable<vwPurchaseHeaderSupplierDetail> GetAllPurchaseHeaderSupplierDetails()
        {
            queryable1 = context.vwPurchaseHeaderSupplierDetails;
            return queryable1;
        }

        public IQueryable<vwPurchaseOrderDashboardData> GetAllPurchaseHeaderDashboardData()
        {
            queryable2 = context.vwPurchaseOrderDashboardDatas;
            return queryable2;
        }
        public IQueryable<PurchaseHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public PurchaseHeader Create(PurchaseHeader PurchaseHeaderEntity, string loggedInUser)
        {
            if (validate(PurchaseHeaderEntity))
            {
                try
                {
                   
                    PurchaseHeaderEntity.modified_on = DateTime.Now;
                    PurchaseHeaderEntity.created_on = DateTime.Now;
                    PurchaseHeaderEntity.created_by = 0;
                    PurchaseHeaderEntity.modified_by = 0;
                    PurchaseHeaderEntity.user_ip = "";
                    PurchaseHeaderEntity.is_active = true;
                   
                    PurchaseHeaderEntity = context.PurchaseHeaders.Add(PurchaseHeaderEntity);
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
            return PurchaseHeaderEntity;
        }

        public PurchaseHeader Update(PurchaseHeader PurchaseHeaderEntity, string loggedInUser)
        {
            PurchaseHeader objPurchaseHeader = null;
            if (validate(PurchaseHeaderEntity))
            {
                try
                {
                    objPurchaseHeader = context.PurchaseHeaders.Find(PurchaseHeaderEntity.purchase_header_id);

                    context.Entry(objPurchaseHeader).CurrentValues.SetValues(PurchaseHeaderEntity);

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
            return objPurchaseHeader;
        }

        public bool Delete(PurchaseHeader PurchaseHeaderEntity, string loggedInUser)
        {
            if (validate(PurchaseHeaderEntity))
            {
                try
                {
                    PurchaseHeader _PurchaseHeader = context.PurchaseHeaders.First(x => x.purchase_header_id == PurchaseHeaderEntity.purchase_header_id);
                    context.PurchaseHeaders.Remove(_PurchaseHeader);
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

        public bool validate(PurchaseHeader PurchaseHeaderEntity)
        {
            if (PurchaseHeaderEntity != null)
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
