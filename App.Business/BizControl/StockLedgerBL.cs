using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class StockLedgerBL
    {
        #region Properties/Variables
        StockLedgerDL _StockLedgerDAL = new StockLedgerDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public StockLedgerBL()
        {
            // this._StockLedgerDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StockLedger>();
        }

        public StockLedgerBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._StockLedgerDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StockLedger>();
        }
        #endregion

        public BusinessModel.StockLedger CreateStockLedger(BusinessModel.StockLedger StockLedgerBusinessObject)
        {
            Mapper.Mappings.MapStockLedger StockLedgerMenu = new Mapper.Mappings.MapStockLedger();

            var report = StockLedgerMenu.GetStockLedgerDatabaseObject(StockLedgerBusinessObject);

            report = this._StockLedgerDAL.Create(report, this.LoggedInUser);

            StockLedgerBusinessObject = StockLedgerMenu.GetStockLedgerBusinessObject(report);

            return StockLedgerBusinessObject;

        }

        public List<BusinessModel.StockLedger> GetAllStockLedgerItems()
        {
            Mapper.Mappings.MapStockLedger StockLedgerMenu = new Mapper.Mappings.MapStockLedger();

            var StockLedgerItemsDALList = this._StockLedgerDAL.GetAll();

            List<BusinessModel.StockLedger> StockLedgerItemsBusinessList = new List<BusinessModel.StockLedger>();
            foreach (App.Data.StockLedger StockLedgerItem in StockLedgerItemsDALList)
            {
                StockLedgerItemsBusinessList.Add(StockLedgerMenu.GetStockLedgerBusinessObject(StockLedgerItem));
            }

            return StockLedgerItemsBusinessList;
        }

        public List<BusinessModel.StockLedger> GetStockLedgerItemsByID(int Id)
        {
            Mapper.Mappings.MapStockLedger StockLedgerMenu = new Mapper.Mappings.MapStockLedger();

            var StockLedgerItemsDALList = this._StockLedgerDAL.GetbyId(Id);

            List<BusinessModel.StockLedger> StockLedgerItemsBusinessList = new List<BusinessModel.StockLedger>();
            foreach (App.Data.StockLedger StockLedgerItem in StockLedgerItemsDALList)
            {
                StockLedgerItemsBusinessList.Add(StockLedgerMenu.GetStockLedgerBusinessObject(StockLedgerItem));
            }

            return StockLedgerItemsBusinessList;
        }

        public List<BusinessModel.StockLedger> GetStockLedgerByName(string term)
        {
            Mapper.Mappings.MapStockLedger StockLedgerMenu = new Mapper.Mappings.MapStockLedger();

            var StockLedgerItemsDALList = this._StockLedgerDAL.GetByName(term);

            List<BusinessModel.StockLedger> StockLedgerItemsBusinessList = new List<BusinessModel.StockLedger>();

            foreach (App.Data.StockLedger StockLedgerItem in StockLedgerItemsDALList)
            {
                StockLedgerItemsBusinessList.Add(StockLedgerMenu.GetStockLedgerBusinessObject(StockLedgerItem));
            }

            return StockLedgerItemsBusinessList;
        }

        public BusinessModel.StockLedger UpdateStockLedger(BusinessModel.StockLedger StockLedgerBusinessObject)
        {
            Mapper.Mappings.MapStockLedger mapStockLedger = new Mapper.Mappings.MapStockLedger();

            var StockLedger = mapStockLedger.GetStockLedgerDatabaseObject(StockLedgerBusinessObject);

            StockLedger = this._StockLedgerDAL.Update(StockLedger, this.LoggedInUser);

            StockLedgerBusinessObject = mapStockLedger.GetStockLedgerBusinessObject(StockLedger);

            return StockLedgerBusinessObject;

        }

        public bool DeleteStockLedger(BusinessModel.StockLedger StockLedgerBusinessObject)
        {
            Mapper.Mappings.MapStockLedger mapStockLedger = new Mapper.Mappings.MapStockLedger();

            var StockLedger = mapStockLedger.GetStockLedgerDatabaseObject(StockLedgerBusinessObject);

            bool status = this._StockLedgerDAL.Delete(StockLedger, this.LoggedInUser);

            return status;
        }

    }
}
