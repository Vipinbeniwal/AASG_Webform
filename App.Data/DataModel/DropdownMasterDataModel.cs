using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class DropdownMasterDL : IDropdownMaster, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<DropdownMaster> queryable;

        public IQueryable<DropdownMaster> GetAll()
        {
            queryable = context.DropdownMasters;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.DropdownMasters.Where(x => x.dropdown_master_id == Id);
            return queryable;
        }

        public IQueryable<DropdownMaster> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public DropdownMaster Create(DropdownMaster DropdownMasterEntity, string loggedInUser)
        {
            if (validate(DropdownMasterEntity))
            {
                try
                {
                    DropdownMasterEntity.modified_on = DateTime.Now;
                    DropdownMasterEntity.created_on = DateTime.Now;
                    DropdownMasterEntity.created_by = 0;
                    DropdownMasterEntity.modified_by = 0;
                    DropdownMasterEntity.user_ip = "";
                    DropdownMasterEntity.is_active = true;
                    DropdownMasterEntity = context.DropdownMasters.Add(DropdownMasterEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return DropdownMasterEntity;
        }

        public DropdownMaster Update(DropdownMaster DropdownMasterEntity, string loggedInUser)
        {
            DropdownMaster objDropdownMaster = null;
            if (validate(DropdownMasterEntity))
            {
                objDropdownMaster = context.DropdownMasters.Find(DropdownMasterEntity.dropdown_master_id);

                context.Entry(objDropdownMaster).CurrentValues.SetValues(DropdownMasterEntity);

                context.SaveChanges();
            }
            return objDropdownMaster;
        }

        public bool Delete(DropdownMaster DropdownMasterEntity, string loggedInUser)
        {
            if (validate(DropdownMasterEntity))
            {
                try
                {
                    DropdownMaster _DropdownMaster = context.DropdownMasters.First(x => x.dropdown_master_id == DropdownMasterEntity.dropdown_master_id);
                    context.DropdownMasters.Remove(_DropdownMaster);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(DropdownMaster DropdownMasterEntity)
        {
            if (DropdownMasterEntity != null)
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
