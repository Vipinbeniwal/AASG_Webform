using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class StockIssuanceItemBL
    {
        #region Properties/Variables
        StockIssuanceItemDL _StockIssuanceItemDAL = new StockIssuanceItemDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public StockIssuanceItemBL()
        {
            // this._StockIssuanceItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StockIssuanceItem>();
        }

        public StockIssuanceItemBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._StockIssuanceItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StockIssuanceItem>();
        }
        #endregion

        public BusinessModel.StockIssuanceItem CreateStockIssuanceItem(BusinessModel.StockIssuanceItem StockIssuanceItemBusinessObject)
        {
            Mapper.Mappings.MapStockIssuanceItem StockIssuanceItemMenu = new Mapper.Mappings.MapStockIssuanceItem();

            var report = StockIssuanceItemMenu.GetStockIssuanceItemDatabaseObject(StockIssuanceItemBusinessObject);

            report = this._StockIssuanceItemDAL.Create(report, this.LoggedInUser);

            StockIssuanceItemBusinessObject = StockIssuanceItemMenu.GetStockIssuanceItemBusinessObject(report);

            return StockIssuanceItemBusinessObject;

        }

        public List<BusinessModel.StockIssuanceItem> GetAllStockIssuanceItemItems()
        {
            Mapper.Mappings.MapStockIssuanceItem StockIssuanceItemMenu = new Mapper.Mappings.MapStockIssuanceItem();

            var StockIssuanceItemItemsDALList = this._StockIssuanceItemDAL.GetAll();

            List<BusinessModel.StockIssuanceItem> StockIssuanceItemItemsBusinessList = new List<BusinessModel.StockIssuanceItem>();
            foreach (App.Data.StockIssuanceItem StockIssuanceItemItem in StockIssuanceItemItemsDALList)
            {
                StockIssuanceItemItemsBusinessList.Add(StockIssuanceItemMenu.GetStockIssuanceItemBusinessObject(StockIssuanceItemItem));
            }

            return StockIssuanceItemItemsBusinessList;
        }

        public List<BusinessModel.StockIssuanceItem> GetStockIssuanceItemItemsByID(int Id)
        {
            Mapper.Mappings.MapStockIssuanceItem StockIssuanceItemMenu = new Mapper.Mappings.MapStockIssuanceItem();

            var StockIssuanceItemItemsDALList = this._StockIssuanceItemDAL.GetbyId(Id);

            List<BusinessModel.StockIssuanceItem> StockIssuanceItemItemsBusinessList = new List<BusinessModel.StockIssuanceItem>();
            foreach (App.Data.StockIssuanceItem StockIssuanceItemItem in StockIssuanceItemItemsDALList)
            {
                StockIssuanceItemItemsBusinessList.Add(StockIssuanceItemMenu.GetStockIssuanceItemBusinessObject(StockIssuanceItemItem));
            }

            return StockIssuanceItemItemsBusinessList;
        }

        public List<BusinessModel.StockIssuanceItem> GetStockIssuanceItemByName(string term)
        {
            Mapper.Mappings.MapStockIssuanceItem StockIssuanceItemMenu = new Mapper.Mappings.MapStockIssuanceItem();

            var StockIssuanceItemItemsDALList = this._StockIssuanceItemDAL.GetByName(term);

            List<BusinessModel.StockIssuanceItem> StockIssuanceItemItemsBusinessList = new List<BusinessModel.StockIssuanceItem>();

            foreach (App.Data.StockIssuanceItem StockIssuanceItemItem in StockIssuanceItemItemsDALList)
            {
                StockIssuanceItemItemsBusinessList.Add(StockIssuanceItemMenu.GetStockIssuanceItemBusinessObject(StockIssuanceItemItem));
            }

            return StockIssuanceItemItemsBusinessList;
        }

        public BusinessModel.StockIssuanceItem UpdateStockIssuanceItem(BusinessModel.StockIssuanceItem StockIssuanceItemBusinessObject)
        {
            Mapper.Mappings.MapStockIssuanceItem mapStockIssuanceItem = new Mapper.Mappings.MapStockIssuanceItem();

            var StockIssuanceItem = mapStockIssuanceItem.GetStockIssuanceItemDatabaseObject(StockIssuanceItemBusinessObject);

            StockIssuanceItem = this._StockIssuanceItemDAL.Update(StockIssuanceItem, this.LoggedInUser);

            StockIssuanceItemBusinessObject = mapStockIssuanceItem.GetStockIssuanceItemBusinessObject(StockIssuanceItem);

            return StockIssuanceItemBusinessObject;

        }

        public bool DeleteStockIssuanceItem(BusinessModel.StockIssuanceItem StockIssuanceItemBusinessObject)
        {
            Mapper.Mappings.MapStockIssuanceItem mapStockIssuanceItem = new Mapper.Mappings.MapStockIssuanceItem();

            var StockIssuanceItem = mapStockIssuanceItem.GetStockIssuanceItemDatabaseObject(StockIssuanceItemBusinessObject);

            bool status = this._StockIssuanceItemDAL.Delete(StockIssuanceItem, this.LoggedInUser);

            return status;
        }

    }
}
