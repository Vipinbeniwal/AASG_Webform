using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class PurchaseHeaderBL
    {
        #region Properties/Variables
        PurchaseHeaderDL _PurchaseHeaderDAL = new PurchaseHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public PurchaseHeaderBL()
        {
            // this._PurchaseHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.PurchaseHeader>();
        }

        public PurchaseHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._PurchaseHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.PurchaseHeader>();
        }
        #endregion

        public BusinessModel.PurchaseHeader CreatePurchaseHeader(BusinessModel.PurchaseHeader PurchaseHeaderBusinessObject)
        {
            Mapper.Mappings.MapPurchaseHeader PurchaseHeaderMenu = new Mapper.Mappings.MapPurchaseHeader();

            var report = PurchaseHeaderMenu.GetPurchaseHeaderDatabaseObject(PurchaseHeaderBusinessObject);

            report = this._PurchaseHeaderDAL.Create(report, this.LoggedInUser);

            PurchaseHeaderBusinessObject = PurchaseHeaderMenu.GetPurchaseHeaderBusinessObject(report);

            return PurchaseHeaderBusinessObject;

        }

        public List<BusinessModel.PurchaseHeader> GetAllPurchaseHeaderItems()
        {
            Mapper.Mappings.MapPurchaseHeader PurchaseHeaderMenu = new Mapper.Mappings.MapPurchaseHeader();

            var PurchaseHeaderItemsDALList = this._PurchaseHeaderDAL.GetAll();

            List<BusinessModel.PurchaseHeader> PurchaseHeaderItemsBusinessList = new List<BusinessModel.PurchaseHeader>();
            foreach (App.Data.PurchaseHeader PurchaseHeaderItem in PurchaseHeaderItemsDALList)
            {
                PurchaseHeaderItemsBusinessList.Add(PurchaseHeaderMenu.GetPurchaseHeaderBusinessObject(PurchaseHeaderItem));
            }

            return PurchaseHeaderItemsBusinessList;
        }


        public List<BusinessModel.vwPurchaseHeaderSupplierDetail> GetAllPurchaseHeaderWithSupplierItems()
        {
            Mapper.Mappings.MapvwPurchaseHeaderSupplierDetail PurchaseHeaderMenu = new Mapper.Mappings.MapvwPurchaseHeaderSupplierDetail();

            var PurchaseHeaderItemsDALList = this._PurchaseHeaderDAL.GetAllPurchaseHeaderSupplierDetails();

            List<BusinessModel.vwPurchaseHeaderSupplierDetail> PurchaseHeaderItemsBusinessList = new List<BusinessModel.vwPurchaseHeaderSupplierDetail>();
            foreach (App.Data.vwPurchaseHeaderSupplierDetail PurchaseHeaderItem in PurchaseHeaderItemsDALList)
            {
                PurchaseHeaderItemsBusinessList.Add(PurchaseHeaderMenu.GetvwPurchaseHeaderDetailBusinessObject(PurchaseHeaderItem));
            }

            return PurchaseHeaderItemsBusinessList;
        }


        public List<BusinessModel.vwPurchaseOrderDashboardData> GetVwPurchaseOrderDashboardDatas()
        {
            Mapper.Mappings.MapvwPurchaseOrderDashboardData PurchaseHeaderMenu = new Mapper.Mappings.MapvwPurchaseOrderDashboardData();

            var PurchaseHeaderItemsDALList = this._PurchaseHeaderDAL.GetAllPurchaseHeaderDashboardData();

            List<BusinessModel.vwPurchaseOrderDashboardData> vwPurchaseHeaderItemsBusinessList = new List<BusinessModel.vwPurchaseOrderDashboardData>();
            foreach (App.Data.vwPurchaseOrderDashboardData vwPurchaseHeaderItem in PurchaseHeaderItemsDALList)
            {
                vwPurchaseHeaderItemsBusinessList.Add(PurchaseHeaderMenu.GetvwPurchaseHeaderDetailBusinessObject(vwPurchaseHeaderItem));
            }

            return vwPurchaseHeaderItemsBusinessList;
        }


        public List<BusinessModel.PurchaseHeader> GetPurchaseHeaderItemsByID(int Id)
        {
            Mapper.Mappings.MapPurchaseHeader PurchaseHeaderMenu = new Mapper.Mappings.MapPurchaseHeader();

            var PurchaseHeaderItemsDALList = this._PurchaseHeaderDAL.GetbyId(Id);

            List<BusinessModel.PurchaseHeader> PurchaseHeaderItemsBusinessList = new List<BusinessModel.PurchaseHeader>();
            foreach (App.Data.PurchaseHeader PurchaseHeaderItem in PurchaseHeaderItemsDALList)
            {
                PurchaseHeaderItemsBusinessList.Add(PurchaseHeaderMenu.GetPurchaseHeaderBusinessObject(PurchaseHeaderItem));
            }

            return PurchaseHeaderItemsBusinessList;
        }

        public List<BusinessModel.PurchaseHeader> GetPurchaseHeaderByName(string term)
        {
            Mapper.Mappings.MapPurchaseHeader PurchaseHeaderMenu = new Mapper.Mappings.MapPurchaseHeader();

            var PurchaseHeaderItemsDALList = this._PurchaseHeaderDAL.GetByName(term);

            List<BusinessModel.PurchaseHeader> PurchaseHeaderItemsBusinessList = new List<BusinessModel.PurchaseHeader>();

            foreach (App.Data.PurchaseHeader PurchaseHeaderItem in PurchaseHeaderItemsDALList)
            {
                PurchaseHeaderItemsBusinessList.Add(PurchaseHeaderMenu.GetPurchaseHeaderBusinessObject(PurchaseHeaderItem));
            }

            return PurchaseHeaderItemsBusinessList;
        }

        public BusinessModel.PurchaseHeader UpdatePurchaseHeader(BusinessModel.PurchaseHeader PurchaseHeaderBusinessObject)
        {
            Mapper.Mappings.MapPurchaseHeader mapPurchaseHeader = new Mapper.Mappings.MapPurchaseHeader();

            var PurchaseHeader = mapPurchaseHeader.GetPurchaseHeaderDatabaseObject(PurchaseHeaderBusinessObject);

            PurchaseHeader = this._PurchaseHeaderDAL.Update(PurchaseHeader, this.LoggedInUser);

            PurchaseHeaderBusinessObject = mapPurchaseHeader.GetPurchaseHeaderBusinessObject(PurchaseHeader);

            return PurchaseHeaderBusinessObject;

        }

        public bool DeletePurchaseHeader(BusinessModel.PurchaseHeader PurchaseHeaderBusinessObject)
        {
            Mapper.Mappings.MapPurchaseHeader mapPurchaseHeader = new Mapper.Mappings.MapPurchaseHeader();

            var PurchaseHeader = mapPurchaseHeader.GetPurchaseHeaderDatabaseObject(PurchaseHeaderBusinessObject);

            bool status = this._PurchaseHeaderDAL.Delete(PurchaseHeader, this.LoggedInUser);

            return status;
        }

    }
}
