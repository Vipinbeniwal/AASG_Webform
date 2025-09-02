using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class xp_TimeSheetHeaderDL : Ixp_TimeSheetHeader, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<xp_TimeSheetHeader> queryable;
        //IQueryable<xp_TimeSheetHeaderSupplierDetail>  queryable1;
        //IQueryable<vwPurchaseOrderDashboardData> queryable2;


        public IQueryable<xp_TimeSheetHeader> GetAll()
        {
            queryable = context.xp_TimeSheetHeader;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.xp_TimeSheetHeader.Where(x => x.time_sheet_header_id == Id);
            return queryable;
        }

        //public IQueryable<vwxp_TimeSheetHeaderSupplierDetail> GetAllxp_TimeSheetHeaderSupplierDetails()
        //{
        //    queryable1 = context.vwxp_TimeSheetHeaderSupplierDetails;
        //    return queryable1;
        //}

        //public IQueryable<vwPurchaseOrderDashboardData> GetAllxp_TimeSheetHeaderDashboardData()
        //{
        //    queryable2 = context.vwPurchaseOrderDashboardDatas;
        //    return queryable2;
        //}
        public IQueryable<xp_TimeSheetHeader> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public xp_TimeSheetHeader Create(xp_TimeSheetHeader xp_TimeSheetHeaderEntity, string loggedInUser)
        {
            if (validate(xp_TimeSheetHeaderEntity))
            {
                try
                {
                   
                    xp_TimeSheetHeaderEntity.modified_on = DateTime.Now;
                    xp_TimeSheetHeaderEntity.created_on = DateTime.Now;
                    xp_TimeSheetHeaderEntity.created_by = 0;
                    xp_TimeSheetHeaderEntity.modified_by = 0;
                    xp_TimeSheetHeaderEntity.user_ip = "";
                    xp_TimeSheetHeaderEntity.is_active = true;
                   
                    xp_TimeSheetHeaderEntity = context.xp_TimeSheetHeader.Add(xp_TimeSheetHeaderEntity);
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
            return xp_TimeSheetHeaderEntity;
        }

        public xp_TimeSheetHeader Update(xp_TimeSheetHeader xp_TimeSheetHeaderEntity, string loggedInUser)
        {
            xp_TimeSheetHeader objxp_TimeSheetHeader = null;
            if (validate(xp_TimeSheetHeaderEntity))
            {
                try
                {
                    objxp_TimeSheetHeader = context.xp_TimeSheetHeader.Find(xp_TimeSheetHeaderEntity.time_sheet_header_id);

                    context.Entry(objxp_TimeSheetHeader).CurrentValues.SetValues(xp_TimeSheetHeaderEntity);

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
            return objxp_TimeSheetHeader;
        }

        public bool Delete(xp_TimeSheetHeader xp_TimeSheetHeaderEntity, string loggedInUser)
        {
            if (validate(xp_TimeSheetHeaderEntity))
            {
                try
                {
                    xp_TimeSheetHeader _xp_TimeSheetHeader = context.xp_TimeSheetHeader.First(x => x.time_sheet_header_id == xp_TimeSheetHeaderEntity.time_sheet_header_id);
                    context.xp_TimeSheetHeader.Remove(_xp_TimeSheetHeader);
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

        public bool validate(xp_TimeSheetHeader xp_TimeSheetHeaderEntity)
        {
            if (xp_TimeSheetHeaderEntity != null)
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
