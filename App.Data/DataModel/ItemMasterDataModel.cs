using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ItemMasterDL : IItemMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ItemMaster> queryable;
        IQueryable<vwItemListWithModelAndGlassColor> queryable2;

        public IQueryable<ItemMaster> GetAll()
        {
            queryable = context.ItemMasters;
            return queryable;
        }
        public IQueryable<vwItemListWithModelAndGlassColor> GetAllItemListWithModelAndGlassColor()
        {
            queryable2 = context.vwItemListWithModelAndGlassColors;
            return queryable2;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ItemMasters.Where(x => x.item_master_id == Id);
            return queryable;
        }

        public IQueryable<ItemMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ItemMaster Create(ItemMaster ItemMasterEntity, string loggedInUser)
        {
            if (validate(ItemMasterEntity))
            {
                try
                {
                    ItemMasterEntity.modified_on = DateTime.Now;
                    ItemMasterEntity.created_on = DateTime.Now;
                    ItemMasterEntity.created_by = 0;
                    ItemMasterEntity.modified_by = 0;
                    ItemMasterEntity.user_ip = "";
                    ItemMasterEntity.is_active = true;

                    ItemMasterEntity = context.ItemMasters.Add(ItemMasterEntity);
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
              //  string error = ex.ToString();
                }
            }
            return ItemMasterEntity;
        }

        public ItemMaster Update(ItemMaster ItemMasterEntity, string loggedInUser)
        {
            ItemMaster objItemMaster = null;
            if (validate(ItemMasterEntity))
            {
                objItemMaster = context.ItemMasters.Find(ItemMasterEntity.item_master_id);

                context.Entry(objItemMaster).CurrentValues.SetValues(ItemMasterEntity);

                context.SaveChanges();
            }
            return objItemMaster;
        }

        public bool Delete(ItemMaster ItemMasterEntity, string loggedInUser)
        {
            if (validate(ItemMasterEntity))
            {
                try
                {
                    ItemMaster _ItemMaster = context.ItemMasters.First(x => x.item_master_id == ItemMasterEntity.item_master_id);
                    context.ItemMasters.Remove(_ItemMaster);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(ItemMaster ItemMasterEntity)
        {
            if (ItemMasterEntity != null)
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
