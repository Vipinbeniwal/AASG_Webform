using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class xp_ProcurementHeaderBL
    {
        #region Properties/Variables
        xp_ProcurementHeaderDL _xp_ProcurementHeaderDAL = new xp_ProcurementHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public xp_ProcurementHeaderBL()
        {
            // this._xp_ProcurementHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_ProcurementHeader>();
        }

        public xp_ProcurementHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._xp_ProcurementHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_ProcurementHeader>();
        }
        #endregion

        public BusinessModel.xp_ProcurementHeader Createxp_ProcurementHeader(BusinessModel.xp_ProcurementHeader xp_ProcurementHeaderBusinessObject)
        {
            Mapper.Mappings.Mapxp_ProcurementHeader xp_ProcurementHeaderMenu = new Mapper.Mappings.Mapxp_ProcurementHeader();

            var report = xp_ProcurementHeaderMenu.Getxp_ProcurementHeaderDatabaseObject(xp_ProcurementHeaderBusinessObject);

            report = this._xp_ProcurementHeaderDAL.Create(report, this.LoggedInUser);

            xp_ProcurementHeaderBusinessObject = xp_ProcurementHeaderMenu.Getxp_ProcurementHeaderBusinessObject(report);

            return xp_ProcurementHeaderBusinessObject;

        }

        public List<BusinessModel.xp_ProcurementHeader> GetAllxp_ProcurementHeaderItems()
        {
            Mapper.Mappings.Mapxp_ProcurementHeader xp_ProcurementHeaderMenu = new Mapper.Mappings.Mapxp_ProcurementHeader();

            var xp_ProcurementHeaderItemsDALList = this._xp_ProcurementHeaderDAL.GetAll();

            List<BusinessModel.xp_ProcurementHeader> xp_ProcurementHeaderItemsBusinessList = new List<BusinessModel.xp_ProcurementHeader>();
            foreach (App.Data.xp_ProcurementHeader xp_ProcurementHeaderItem in xp_ProcurementHeaderItemsDALList)
            {
                xp_ProcurementHeaderItemsBusinessList.Add(xp_ProcurementHeaderMenu.Getxp_ProcurementHeaderBusinessObject(xp_ProcurementHeaderItem));
            }

            return xp_ProcurementHeaderItemsBusinessList;
        }



        public List<BusinessModel.vwxp_ProcurementHeaderSupplierDetail> GetAllxp_ProcurementHeaderWithSupplierItems()
        {
            Mapper.Mappings.Mapvwxp_ProcurementHeaderSupplierDetail xp_ProcurementHeaderMenu = new Mapper.Mappings.Mapvwxp_ProcurementHeaderSupplierDetail();

            var xp_ProcurementHeaderItemsDALList = this._xp_ProcurementHeaderDAL.GetAllxp_ProcurementHeaderSupplierDetail();

            List<BusinessModel.vwxp_ProcurementHeaderSupplierDetail> xp_ProcurementHeaderItemsBusinessList = new List<BusinessModel.vwxp_ProcurementHeaderSupplierDetail>();
            foreach (App.Data.vwxp_ProcurementHeaderSupplierDetail xp_ProcurementHeaderItem in xp_ProcurementHeaderItemsDALList)
            {
                xp_ProcurementHeaderItemsBusinessList.Add(xp_ProcurementHeaderMenu.GetvwPurchaseHeaderDetailBusinessObject(xp_ProcurementHeaderItem));
            }

            return xp_ProcurementHeaderItemsBusinessList;
        }





        public List<BusinessModel.xp_ProcurementHeader> Getxp_ProcurementHeaderItemsByID(int Id)
        {
            Mapper.Mappings.Mapxp_ProcurementHeader xp_ProcurementHeaderMenu = new Mapper.Mappings.Mapxp_ProcurementHeader();

            var xp_ProcurementHeaderItemsDALList = this._xp_ProcurementHeaderDAL.GetbyId(Id);

            List<BusinessModel.xp_ProcurementHeader> xp_ProcurementHeaderItemsBusinessList = new List<BusinessModel.xp_ProcurementHeader>();
            foreach (App.Data.xp_ProcurementHeader xp_ProcurementHeaderItem in xp_ProcurementHeaderItemsDALList)
            {
                xp_ProcurementHeaderItemsBusinessList.Add(xp_ProcurementHeaderMenu.Getxp_ProcurementHeaderBusinessObject(xp_ProcurementHeaderItem));
            }

            return xp_ProcurementHeaderItemsBusinessList;
        }

        public List<BusinessModel.xp_ProcurementHeader> Getxp_ProcurementHeaderByName(string term)
        {
            Mapper.Mappings.Mapxp_ProcurementHeader xp_ProcurementHeaderMenu = new Mapper.Mappings.Mapxp_ProcurementHeader();

            var xp_ProcurementHeaderItemsDALList = this._xp_ProcurementHeaderDAL.GetByName(term);

            List<BusinessModel.xp_ProcurementHeader> xp_ProcurementHeaderItemsBusinessList = new List<BusinessModel.xp_ProcurementHeader>();

            foreach (App.Data.xp_ProcurementHeader xp_ProcurementHeaderItem in xp_ProcurementHeaderItemsDALList)
            {
                xp_ProcurementHeaderItemsBusinessList.Add(xp_ProcurementHeaderMenu.Getxp_ProcurementHeaderBusinessObject(xp_ProcurementHeaderItem));
            }

            return xp_ProcurementHeaderItemsBusinessList;
        }

        public BusinessModel.xp_ProcurementHeader Updatexp_ProcurementHeader(BusinessModel.xp_ProcurementHeader xp_ProcurementHeaderBusinessObject)
        {
            Mapper.Mappings.Mapxp_ProcurementHeader mapxp_ProcurementHeader = new Mapper.Mappings.Mapxp_ProcurementHeader();

            var xp_ProcurementHeader = mapxp_ProcurementHeader.Getxp_ProcurementHeaderDatabaseObject(xp_ProcurementHeaderBusinessObject);

            xp_ProcurementHeader = this._xp_ProcurementHeaderDAL.Update(xp_ProcurementHeader, this.LoggedInUser);

            xp_ProcurementHeaderBusinessObject = mapxp_ProcurementHeader.Getxp_ProcurementHeaderBusinessObject(xp_ProcurementHeader);

            return xp_ProcurementHeaderBusinessObject;

        }

        public bool Deletexp_ProcurementHeader(BusinessModel.xp_ProcurementHeader xp_ProcurementHeaderBusinessObject)
        {
            Mapper.Mappings.Mapxp_ProcurementHeader mapxp_ProcurementHeader = new Mapper.Mappings.Mapxp_ProcurementHeader();

            var xp_ProcurementHeader = mapxp_ProcurementHeader.Getxp_ProcurementHeaderDatabaseObject(xp_ProcurementHeaderBusinessObject);

            bool status = this._xp_ProcurementHeaderDAL.Delete(xp_ProcurementHeader, this.LoggedInUser);

            return status;
        }

    }
}
