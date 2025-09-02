using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class StockIssuanceHeaderBL
    {
        #region Properties/Variables
        StockIssuanceHeaderDL _StockIssuanceHeaderDAL = new StockIssuanceHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public StockIssuanceHeaderBL()
        {
            // this._StockIssuanceHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StockIssuanceHeader>();
        }

        public StockIssuanceHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._StockIssuanceHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StockIssuanceHeader>();
        }
        #endregion

        public BusinessModel.StockIssuanceHeader CreateStockIssuanceHeader(BusinessModel.StockIssuanceHeader StockIssuanceHeaderBusinessObject)
        {
            Mapper.Mappings.MapStockIssuanceHeader StockIssuanceHeaderMenu = new Mapper.Mappings.MapStockIssuanceHeader();

            var report = StockIssuanceHeaderMenu.GetStockIssuanceHeaderDatabaseObject(StockIssuanceHeaderBusinessObject);

            report = this._StockIssuanceHeaderDAL.Create(report, this.LoggedInUser);

            StockIssuanceHeaderBusinessObject = StockIssuanceHeaderMenu.GetStockIssuanceHeaderBusinessObject(report);

            return StockIssuanceHeaderBusinessObject;

        }

        public List<BusinessModel.StockIssuanceHeader> GetAllStockIssuanceHeaderItems()
        {
            Mapper.Mappings.MapStockIssuanceHeader StockIssuanceHeaderMenu = new Mapper.Mappings.MapStockIssuanceHeader();

            var StockIssuanceHeaderItemsDALList = this._StockIssuanceHeaderDAL.GetAll();

            List<BusinessModel.StockIssuanceHeader> StockIssuanceHeaderItemsBusinessList = new List<BusinessModel.StockIssuanceHeader>();
            foreach (App.Data.StockIssuanceHeader StockIssuanceHeaderItem in StockIssuanceHeaderItemsDALList)
            {
                StockIssuanceHeaderItemsBusinessList.Add(StockIssuanceHeaderMenu.GetStockIssuanceHeaderBusinessObject(StockIssuanceHeaderItem));
            }

            return StockIssuanceHeaderItemsBusinessList;
        }

        public List<BusinessModel.StockIssuanceHeader> GetStockIssuanceHeaderItemsByID(int Id)
        {
            Mapper.Mappings.MapStockIssuanceHeader StockIssuanceHeaderMenu = new Mapper.Mappings.MapStockIssuanceHeader();

            var StockIssuanceHeaderItemsDALList = this._StockIssuanceHeaderDAL.GetbyId(Id);

            List<BusinessModel.StockIssuanceHeader> StockIssuanceHeaderItemsBusinessList = new List<BusinessModel.StockIssuanceHeader>();
            foreach (App.Data.StockIssuanceHeader StockIssuanceHeaderItem in StockIssuanceHeaderItemsDALList)
            {
                StockIssuanceHeaderItemsBusinessList.Add(StockIssuanceHeaderMenu.GetStockIssuanceHeaderBusinessObject(StockIssuanceHeaderItem));
            }

            return StockIssuanceHeaderItemsBusinessList;
        }

        public List<BusinessModel.StockIssuanceHeader> GetStockIssuanceHeaderByName(string term)
        {
            Mapper.Mappings.MapStockIssuanceHeader StockIssuanceHeaderMenu = new Mapper.Mappings.MapStockIssuanceHeader();

            var StockIssuanceHeaderItemsDALList = this._StockIssuanceHeaderDAL.GetByName(term);

            List<BusinessModel.StockIssuanceHeader> StockIssuanceHeaderItemsBusinessList = new List<BusinessModel.StockIssuanceHeader>();

            foreach (App.Data.StockIssuanceHeader StockIssuanceHeaderItem in StockIssuanceHeaderItemsDALList)
            {
                StockIssuanceHeaderItemsBusinessList.Add(StockIssuanceHeaderMenu.GetStockIssuanceHeaderBusinessObject(StockIssuanceHeaderItem));
            }

            return StockIssuanceHeaderItemsBusinessList;
        }

        public BusinessModel.StockIssuanceHeader UpdateStockIssuanceHeader(BusinessModel.StockIssuanceHeader StockIssuanceHeaderBusinessObject)
        {
            Mapper.Mappings.MapStockIssuanceHeader mapStockIssuanceHeader = new Mapper.Mappings.MapStockIssuanceHeader();

            var StockIssuanceHeader = mapStockIssuanceHeader.GetStockIssuanceHeaderDatabaseObject(StockIssuanceHeaderBusinessObject);

            StockIssuanceHeader = this._StockIssuanceHeaderDAL.Update(StockIssuanceHeader, this.LoggedInUser);

            StockIssuanceHeaderBusinessObject = mapStockIssuanceHeader.GetStockIssuanceHeaderBusinessObject(StockIssuanceHeader);

            return StockIssuanceHeaderBusinessObject;

        }

        public bool DeleteStockIssuanceHeader(BusinessModel.StockIssuanceHeader StockIssuanceHeaderBusinessObject)
        {
            Mapper.Mappings.MapStockIssuanceHeader mapStockIssuanceHeader = new Mapper.Mappings.MapStockIssuanceHeader();

            var StockIssuanceHeader = mapStockIssuanceHeader.GetStockIssuanceHeaderDatabaseObject(StockIssuanceHeaderBusinessObject);

            bool status = this._StockIssuanceHeaderDAL.Delete(StockIssuanceHeader, this.LoggedInUser);

            return status;
        }

    }
}
