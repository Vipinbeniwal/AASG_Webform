using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class SaleHeaderDL : ISaleHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<SaleHeader> queryable;
        IQueryable<vwSaleHeaderPartyDetail> queryable1;
        IQueryable<vwSaleOrderDashboardData> queryable2;

        public IQueryable<SaleHeader> GetAll()
        {
            queryable = context.SaleHeaders;
            return queryable;
        }

        public IQueryable<vwSaleHeaderPartyDetail> GetAllSaleHeaderWithPartyDetails()
        {
            queryable1 = context.vwSaleHeaderPartyDetails;
            return queryable1;
        }
        public IQueryable<vwSaleOrderDashboardData> GetAllSaleHeaderDashboardData()
        {
            queryable2 = context.vwSaleOrderDashboardDatas;
            return queryable2;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.SaleHeaders.Where(x => x.sale_header_id == Id);
            return queryable;
        }

        public IQueryable<SaleHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public SaleHeader Create(SaleHeader SaleHeaderEntity, string loggedInUser)
        {
            if (validate(SaleHeaderEntity))
            {
                try
                {
                   
                    SaleHeaderEntity.modified_on = DateTime.Now;
                    SaleHeaderEntity.created_on = DateTime.Now;
                    //SaleHeaderEntity.created_by = 0;
                    //SaleHeaderEntity.modified_by = 0;
                    SaleHeaderEntity.user_ip = "";
                    SaleHeaderEntity.is_active = true;
                   
                    SaleHeaderEntity = context.SaleHeaders.Add(SaleHeaderEntity);
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
            return SaleHeaderEntity;
        }

        public SaleHeader Update(SaleHeader SaleHeaderEntity, string loggedInUser)
        {
            SaleHeader objSaleHeader = null;
            if (validate(SaleHeaderEntity))
            {
                try
                {

                    SaleHeaderEntity.modified_on = DateTime.Now;
                    

                    objSaleHeader = context.SaleHeaders.Find(SaleHeaderEntity.sale_header_id);

                   

                    context.Entry(objSaleHeader).CurrentValues.SetValues(SaleHeaderEntity);

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
            return objSaleHeader;
        }

        public bool Delete(SaleHeader SaleHeaderEntity, string loggedInUser)
        {
            if (validate(SaleHeaderEntity))
            {
                try
                {
                    SaleHeader _SaleHeader = context.SaleHeaders.First(x => x.sale_header_id == SaleHeaderEntity.sale_header_id);
                    context.SaleHeaders.Remove(_SaleHeader);
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

        public bool validate(SaleHeader SaleHeaderEntity)
        {
            if (SaleHeaderEntity != null)
            {
                return true;
            }
            else
                return false;
        }


        public string GetLatestOrderNumber()
        {
            string latestOrderNumber = string.Empty;

            using (DBEntities _dbEntities = new DBEntities())
            {
                try
                {
                    latestOrderNumber = _dbEntities.SaleHeaders.OrderByDescending(x => x.sale_header_id).FirstOrDefault().order_number;
                }

                catch (Exception ex)
                {
                    var exception = ex.ToString();
                }
            }

            return latestOrderNumber;
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
