using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class xp_TimeSheetChildDL : Ixp_TimeSheetChild, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<xp_TimeSheetChild> queryable;

        public IQueryable<xp_TimeSheetChild> GetAll()
        {
            queryable = context.xp_TimeSheetChild;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.xp_TimeSheetChild.Where(x => x.time_sheet_child_id == Id);
            return queryable;
        }

        public IQueryable<xp_TimeSheetChild> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public xp_TimeSheetChild Create(xp_TimeSheetChild xp_TimeSheetChildEntity, string loggedInUser)
        {
            if (validate(xp_TimeSheetChildEntity))
            {
                try
                {
                   
                    xp_TimeSheetChildEntity.modified_on = DateTime.Now;
                    xp_TimeSheetChildEntity.created_on = DateTime.Now;
                    xp_TimeSheetChildEntity.created_by = 0;
                    xp_TimeSheetChildEntity.modified_by = 0;
                    xp_TimeSheetChildEntity.user_ip = "";
                    xp_TimeSheetChildEntity.is_active = true;
                   
                    xp_TimeSheetChildEntity = context.xp_TimeSheetChild.Add(xp_TimeSheetChildEntity);
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
            return xp_TimeSheetChildEntity;
        }

        public xp_TimeSheetChild Update(xp_TimeSheetChild xp_TimeSheetChildEntity, string loggedInUser)
        {
            xp_TimeSheetChild objxp_TimeSheetChild = null;
            if (validate(xp_TimeSheetChildEntity))
            {
                try
                {
                    objxp_TimeSheetChild = context.xp_TimeSheetChild.Find(xp_TimeSheetChildEntity.time_sheet_header_id);

                    context.Entry(objxp_TimeSheetChild).CurrentValues.SetValues(xp_TimeSheetChildEntity);

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
            return objxp_TimeSheetChild;
        }

        public bool Delete(xp_TimeSheetChild xp_TimeSheetChildEntity, string loggedInUser)
        {
            if (validate(xp_TimeSheetChildEntity))
            {
                try
                {
                    xp_TimeSheetChild _xp_TimeSheetChild = context.xp_TimeSheetChild.First(x => x.time_sheet_header_id == xp_TimeSheetChildEntity.time_sheet_header_id);
                    context.xp_TimeSheetChild.Remove(_xp_TimeSheetChild);
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

        public bool validate(xp_TimeSheetChild xp_TimeSheetChildEntity)
        {
            if (xp_TimeSheetChildEntity != null)
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
