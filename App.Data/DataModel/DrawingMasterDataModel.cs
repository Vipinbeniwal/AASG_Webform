using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class DrawingMasterDL : IDrawingMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<DrawingMaster> queryable;

        public IQueryable<DrawingMaster> GetAll()
        {
            queryable = context.DrawingMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.DrawingMasters.Where(x => x.drawing_master_id == Id);
            return queryable;
        }

        public IQueryable<DrawingMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public DrawingMaster Create(DrawingMaster DrawingMasterEntity, string loggedInUser)
        {
            if (validate(DrawingMasterEntity))
            {
                try
                {
                   
                    DrawingMasterEntity.modified_on = DateTime.Now;
                    DrawingMasterEntity.created_on = DateTime.Now;
                    DrawingMasterEntity.created_by = 0;
                    DrawingMasterEntity.modified_by = 0;
                    DrawingMasterEntity.user_ip = "";
                    DrawingMasterEntity.is_active = true;
                   
                    DrawingMasterEntity = context.DrawingMasters.Add(DrawingMasterEntity);
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
            return DrawingMasterEntity;
        }

        public DrawingMaster Update(DrawingMaster DrawingMasterEntity, string loggedInUser)
        {
            DrawingMaster objDrawingMaster = null;
            if (validate(DrawingMasterEntity))
            {
                try
                {
                    objDrawingMaster = context.DrawingMasters.Find(DrawingMasterEntity.drawing_master_id);

                    context.Entry(objDrawingMaster).CurrentValues.SetValues(DrawingMasterEntity);

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
            return objDrawingMaster;
        }

        public bool Delete(DrawingMaster DrawingMasterEntity, string loggedInUser)
        {
            if (validate(DrawingMasterEntity))
            {
                try
                {
                    DrawingMaster _DrawingMaster = context.DrawingMasters.First(x => x.drawing_master_id == DrawingMasterEntity.drawing_master_id);
                    context.DrawingMasters.Remove(_DrawingMaster);
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

        public bool validate(DrawingMaster DrawingMasterEntity)
        {
            if (DrawingMasterEntity != null)
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
