using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class PurchaseItemBL
    {
        #region Properties/Variables
        PurchaseItemDL _PurchaseItemDAL = new PurchaseItemDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public PurchaseItemBL()
        {
            // this._PurchaseItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.PurchaseItem>();
        }

        public PurchaseItemBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._PurchaseItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.PurchaseItem>();
        }
        #endregion

        public BusinessModel.PurchaseItem CreatePurchaseItem(BusinessModel.PurchaseItem PurchaseItemBusinessObject)
        {
            Mapper.Mappings.MapPurchaseItem PurchaseItemMenu = new Mapper.Mappings.MapPurchaseItem();

            var report = PurchaseItemMenu.GetPurchaseItemDatabaseObject(PurchaseItemBusinessObject);

            report = this._PurchaseItemDAL.Create(report, this.LoggedInUser);

            PurchaseItemBusinessObject = PurchaseItemMenu.GetPurchaseItemBusinessObject(report);

            return PurchaseItemBusinessObject;

        }

        public List<BusinessModel.PurchaseItem> GetAllPurchaseItemItems()
        {
            Mapper.Mappings.MapPurchaseItem PurchaseItemMenu = new Mapper.Mappings.MapPurchaseItem();

            var PurchaseItemItemsDALList = this._PurchaseItemDAL.GetAll();

            List<BusinessModel.PurchaseItem> PurchaseItemItemsBusinessList = new List<BusinessModel.PurchaseItem>();
            foreach (App.Data.PurchaseItem PurchaseItemItem in PurchaseItemItemsDALList)
            {
                PurchaseItemItemsBusinessList.Add(PurchaseItemMenu.GetPurchaseItemBusinessObject(PurchaseItemItem));
            }

            return PurchaseItemItemsBusinessList;
        }

        public List<BusinessModel.PurchaseItem> GetPurchaseItemItemsByID(int Id)
        {
            Mapper.Mappings.MapPurchaseItem PurchaseItemMenu = new Mapper.Mappings.MapPurchaseItem();

            var PurchaseItemItemsDALList = this._PurchaseItemDAL.GetbyId(Id);

            List<BusinessModel.PurchaseItem> PurchaseItemItemsBusinessList = new List<BusinessModel.PurchaseItem>();
            foreach (App.Data.PurchaseItem PurchaseItemItem in PurchaseItemItemsDALList)
            {
                PurchaseItemItemsBusinessList.Add(PurchaseItemMenu.GetPurchaseItemBusinessObject(PurchaseItemItem));
            }

            return PurchaseItemItemsBusinessList;
        }

        public List<BusinessModel.PurchaseItem> GetPurchaseItemByName(string term)
        {
            Mapper.Mappings.MapPurchaseItem PurchaseItemMenu = new Mapper.Mappings.MapPurchaseItem();

            var PurchaseItemItemsDALList = this._PurchaseItemDAL.GetByName(term);

            List<BusinessModel.PurchaseItem> PurchaseItemItemsBusinessList = new List<BusinessModel.PurchaseItem>();

            foreach (App.Data.PurchaseItem PurchaseItemItem in PurchaseItemItemsDALList)
            {
                PurchaseItemItemsBusinessList.Add(PurchaseItemMenu.GetPurchaseItemBusinessObject(PurchaseItemItem));
            }

            return PurchaseItemItemsBusinessList;
        }

        public BusinessModel.PurchaseItem UpdatePurchaseItem(BusinessModel.PurchaseItem PurchaseItemBusinessObject)
        {
            Mapper.Mappings.MapPurchaseItem mapPurchaseItem = new Mapper.Mappings.MapPurchaseItem();

            var PurchaseItem = mapPurchaseItem.GetPurchaseItemDatabaseObject(PurchaseItemBusinessObject);

            PurchaseItem = this._PurchaseItemDAL.Update(PurchaseItem, this.LoggedInUser);

            PurchaseItemBusinessObject = mapPurchaseItem.GetPurchaseItemBusinessObject(PurchaseItem);

            return PurchaseItemBusinessObject;

        }

        public bool DeletePurchaseItem(BusinessModel.PurchaseItem PurchaseItemBusinessObject)
        {
            Mapper.Mappings.MapPurchaseItem mapPurchaseItem = new Mapper.Mappings.MapPurchaseItem();

            var PurchaseItem = mapPurchaseItem.GetPurchaseItemDatabaseObject(PurchaseItemBusinessObject);

            bool status = this._PurchaseItemDAL.Delete(PurchaseItem, this.LoggedInUser);

            return status;
        }

    }
}
