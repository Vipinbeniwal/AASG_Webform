using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class MenuMasterDL : IMenuMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<MenuMaster> queryable;

        public IQueryable<MenuMaster> GetAll()
        {
            queryable = context.MenuMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.MenuMasters.Where(x => x.menu_master_id == Id);
            return queryable;
        }

        public IQueryable<MenuMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public MenuMaster Create(MenuMaster MenuMasterEntity, string loggedInUser)
        {
            if (validate(MenuMasterEntity))
            {
                try
                {
                   
                    MenuMasterEntity.modified_on = DateTime.Now;
                    MenuMasterEntity.created_on = DateTime.Now;
                    MenuMasterEntity.created_by = 0;
                    MenuMasterEntity.modified_by = 0;
                    MenuMasterEntity.user_ip = "";
                    MenuMasterEntity.is_active = true;
                   
                    MenuMasterEntity = context.MenuMasters.Add(MenuMasterEntity);
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
            return MenuMasterEntity;
        }

        public MenuMaster Update(MenuMaster MenuMasterEntity, string loggedInUser)
        {
            MenuMaster objMenuMaster = null;
            if (validate(MenuMasterEntity))
            {
                try
                {
                    objMenuMaster = context.MenuMasters.Find(MenuMasterEntity.menu_master_id);

                    context.Entry(objMenuMaster).CurrentValues.SetValues(MenuMasterEntity);

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
            return objMenuMaster;
        }

        public bool Delete(MenuMaster MenuMasterEntity, string loggedInUser)
        {
            if (validate(MenuMasterEntity))
            {
                try
                {
                    MenuMaster _MenuMaster = context.MenuMasters.First(x => x.menu_master_id == MenuMasterEntity.menu_master_id);
                    context.MenuMasters.Remove(_MenuMaster);
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

        public bool validate(MenuMaster MenuMasterEntity)
        {
            if (MenuMasterEntity != null)
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
