using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;
namespace App.Data
{
    public partial class ChallanItemDL : IChallanItem, IDisposable
    {
        private DBEntities context = new Connection().ReturnContext();

        private bool disposed = false;

        IQueryable<ChallanItem> queryable;

        public IQueryable<ChallanItem> GetAll()
        {
            queryable = context.ChallanItems;
            return queryable;
        }

        public IQueryable GetbyId(int Id)
        {
            queryable = context.ChallanItems.Where(x => x.challan_item_id == Id);
            return queryable;
        }

        public IQueryable<ChallanItem> GetByName(string Term)
        {
            throw new NotImplementedException();
        }

        public ChallanItem Create(ChallanItem ChallanItemEntity, string loggedInUser)
        {
            if (validate(ChallanItemEntity))
            {
                try
                {
                    ChallanItemEntity.modified_on = DateTime.Now;
                    ChallanItemEntity.created_on = DateTime.Now;
                    //ChallanItemEntity.created_by = 0;
                    //ChallanItemEntity.modified_by = 0;
                    ChallanItemEntity.user_ip = "";
                    ChallanItemEntity.is_active = true;
                    ChallanItemEntity = context.ChallanItems.Add(ChallanItemEntity);
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string error = ex.ToString();
                }
            }
            return ChallanItemEntity;
        }

        public ChallanItem Update(ChallanItem ChallanItemEntity, string loggedInUser)
        {
            ChallanItem objChallanItem = null;
            if (validate(ChallanItemEntity))
            {
                objChallanItem = context.ChallanItems.Find(ChallanItemEntity.challan_item_id);

                context.Entry(objChallanItem).CurrentValues.SetValues(ChallanItemEntity);

                context.SaveChanges();
            }
            return objChallanItem;
        }

        public bool Delete(ChallanItem ChallanItemEntity, string loggedInUser)
        {
            if (validate(ChallanItemEntity))
            {
                try
                {
                    ChallanItem _ChallanItem = context.ChallanItems.First(x => x.challan_item_id == ChallanItemEntity.challan_item_id);
                    context.ChallanItems.Remove(_ChallanItem);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            return true;
        }

        public bool validate(ChallanItem ChallanItemEntity)
        {
            if (ChallanItemEntity != null)
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
