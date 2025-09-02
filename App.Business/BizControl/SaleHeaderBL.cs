using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class SaleHeaderBL
    {
        #region Properties/Variables
        SaleHeaderDL _SaleHeaderDAL = new SaleHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public SaleHeaderBL()
        {
            // this._SaleHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.SaleHeader>();
        }

        public SaleHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._SaleHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.SaleHeader>();
        }
        #endregion

        public BusinessModel.SaleHeader CreateSaleHeader(BusinessModel.SaleHeader SaleHeaderBusinessObject)
        {
            Mapper.Mappings.MapSaleHeader SaleHeaderMenu = new Mapper.Mappings.MapSaleHeader();

            var report = SaleHeaderMenu.GetSaleHeaderDatabaseObject(SaleHeaderBusinessObject);

            report = this._SaleHeaderDAL.Create(report, this.LoggedInUser);

            SaleHeaderBusinessObject = SaleHeaderMenu.GetSaleHeaderBusinessObject(report);

            return SaleHeaderBusinessObject;

        }

        public List<BusinessModel.SaleHeader> GetAllSaleHeaderItems()
        {
            Mapper.Mappings.MapSaleHeader SaleHeaderMenu = new Mapper.Mappings.MapSaleHeader();

            var SaleHeaderItemsDALList = this._SaleHeaderDAL.GetAll();

            List<BusinessModel.SaleHeader> SaleHeaderItemsBusinessList = new List<BusinessModel.SaleHeader>();
            foreach (App.Data.SaleHeader SaleHeaderItem in SaleHeaderItemsDALList)
            {
                SaleHeaderItemsBusinessList.Add(SaleHeaderMenu.GetSaleHeaderBusinessObject(SaleHeaderItem));
            }

            return SaleHeaderItemsBusinessList;
        }

        public List<BusinessModel.vwSaleHeaderPartyDetail> GetAllSaleHeaderItemsWithPatryDetails()
        {
            Mapper.Mappings.MapvwSaleHeaderPartyDetail SaleHeaderMenu = new Mapper.Mappings.MapvwSaleHeaderPartyDetail();

            var SaleHeaderItemsDALList = this._SaleHeaderDAL.GetAllSaleHeaderWithPartyDetails();

            List<BusinessModel.vwSaleHeaderPartyDetail> vwSaleHeaderItemsBusinessList = new List<BusinessModel.vwSaleHeaderPartyDetail>();
            foreach (App.Data.vwSaleHeaderPartyDetail vwSaleHeaderItem in SaleHeaderItemsDALList)
            {
                vwSaleHeaderItemsBusinessList.Add(SaleHeaderMenu.GetvwSaleHeaderPartyDetailBusinessObject(vwSaleHeaderItem));
            }

            return vwSaleHeaderItemsBusinessList;
        }


        public List<BusinessModel.vwSaleOrderDashboardData> GetVwSaleOrderDashboardDatas()
        {
            Mapper.Mappings.MapvwSaleOrderDashboardData SaleHeaderMenu = new Mapper.Mappings.MapvwSaleOrderDashboardData();

            var SaleHeaderItemsDALList = this._SaleHeaderDAL.GetAllSaleHeaderDashboardData();

            List<BusinessModel.vwSaleOrderDashboardData> vwSaleHeaderItemsBusinessList = new List<BusinessModel.vwSaleOrderDashboardData>();
            foreach (App.Data.vwSaleOrderDashboardData vwSaleHeaderItem in SaleHeaderItemsDALList)
            {
                vwSaleHeaderItemsBusinessList.Add(SaleHeaderMenu.GetvwSaleOrderDashboardDataBusinessObject(vwSaleHeaderItem));
            }

            return vwSaleHeaderItemsBusinessList;
        }



        public string GetLatestOrderNumber()
        {
            string _getLatestOrderNumber = string.Empty;

            var SaleHeaderLatestOrderNumber = this._SaleHeaderDAL.GetLatestOrderNumber();

            _getLatestOrderNumber = SaleHeaderLatestOrderNumber;

            return _getLatestOrderNumber;
        }

        public List<BusinessModel.SaleHeader> GetSaleHeaderItemsByID(int Id)
        {
            Mapper.Mappings.MapSaleHeader SaleHeaderMenu = new Mapper.Mappings.MapSaleHeader();

            var SaleHeaderItemsDALList = this._SaleHeaderDAL.GetbyId(Id);

            List<BusinessModel.SaleHeader> SaleHeaderItemsBusinessList = new List<BusinessModel.SaleHeader>();
            foreach (App.Data.SaleHeader SaleHeaderItem in SaleHeaderItemsDALList)
            {
                SaleHeaderItemsBusinessList.Add(SaleHeaderMenu.GetSaleHeaderBusinessObject(SaleHeaderItem));
            }

            return SaleHeaderItemsBusinessList;
        }

        public List<BusinessModel.SaleHeader> GetSaleHeaderByName(string term)
        {
            Mapper.Mappings.MapSaleHeader SaleHeaderMenu = new Mapper.Mappings.MapSaleHeader();

            var SaleHeaderItemsDALList = this._SaleHeaderDAL.GetByName(term);

            List<BusinessModel.SaleHeader> SaleHeaderItemsBusinessList = new List<BusinessModel.SaleHeader>();

            foreach (App.Data.SaleHeader SaleHeaderItem in SaleHeaderItemsDALList)
            {
                SaleHeaderItemsBusinessList.Add(SaleHeaderMenu.GetSaleHeaderBusinessObject(SaleHeaderItem));
            }

            return SaleHeaderItemsBusinessList;
        }

        public BusinessModel.SaleHeader UpdateSaleHeader(BusinessModel.SaleHeader SaleHeaderBusinessObject)
        {
            Mapper.Mappings.MapSaleHeader mapSaleHeader = new Mapper.Mappings.MapSaleHeader();

            var SaleHeader = mapSaleHeader.GetSaleHeaderDatabaseObject(SaleHeaderBusinessObject);

            SaleHeader = this._SaleHeaderDAL.Update(SaleHeader, this.LoggedInUser);

            SaleHeaderBusinessObject = mapSaleHeader.GetSaleHeaderBusinessObject(SaleHeader);

            return SaleHeaderBusinessObject;

        }

        public bool DeleteSaleHeader(BusinessModel.SaleHeader SaleHeaderBusinessObject)
        {
            Mapper.Mappings.MapSaleHeader mapSaleHeader = new Mapper.Mappings.MapSaleHeader();

            var SaleHeader = mapSaleHeader.GetSaleHeaderDatabaseObject(SaleHeaderBusinessObject);

            bool status = this._SaleHeaderDAL.Delete(SaleHeader, this.LoggedInUser);

            return status;
        }

    }
}
