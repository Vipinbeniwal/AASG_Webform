using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class xp_TimeSheetHeaderBL
    {
        #region Properties/Variables
        xp_TimeSheetHeaderDL _xp_TimeSheetHeaderDAL = new xp_TimeSheetHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public xp_TimeSheetHeaderBL()
        {
            // this._xp_TimeSheetHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_TimeSheetHeader>();
        }

        public xp_TimeSheetHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._xp_TimeSheetHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_TimeSheetHeader>();
        }
        #endregion

        public BusinessModel.xp_TimeSheetHeader Createxp_TimeSheetHeader(BusinessModel.xp_TimeSheetHeader xp_TimeSheetHeaderBusinessObject)
        {
            Mapper.Mappings.Mapxp_TimeSheetHeader xp_TimeSheetHeaderMenu = new Mapper.Mappings.Mapxp_TimeSheetHeader();

            var report = xp_TimeSheetHeaderMenu.Getxp_TimeSheetHeaderDatabaseObject(xp_TimeSheetHeaderBusinessObject);

            report = this._xp_TimeSheetHeaderDAL.Create(report, this.LoggedInUser);

            xp_TimeSheetHeaderBusinessObject = xp_TimeSheetHeaderMenu.Getxp_TimeSheetHeaderBusinessObject(report);

            return xp_TimeSheetHeaderBusinessObject;

        }

        public List<BusinessModel.xp_TimeSheetHeader> GetAllxp_TimeSheetHeaderItems()
        {
            Mapper.Mappings.Mapxp_TimeSheetHeader xp_TimeSheetHeaderMenu = new Mapper.Mappings.Mapxp_TimeSheetHeader();

            var xp_TimeSheetHeaderItemsDALList = this._xp_TimeSheetHeaderDAL.GetAll();

            List<BusinessModel.xp_TimeSheetHeader> xp_TimeSheetHeaderItemsBusinessList = new List<BusinessModel.xp_TimeSheetHeader>();
            foreach (App.Data.xp_TimeSheetHeader xp_TimeSheetHeaderItem in xp_TimeSheetHeaderItemsDALList)
            {
                xp_TimeSheetHeaderItemsBusinessList.Add(xp_TimeSheetHeaderMenu.Getxp_TimeSheetHeaderBusinessObject(xp_TimeSheetHeaderItem));
            }

            return xp_TimeSheetHeaderItemsBusinessList;
        }






        public List<BusinessModel.xp_TimeSheetHeader> Getxp_TimeSheetHeaderItemsByID(int Id)
        {
            Mapper.Mappings.Mapxp_TimeSheetHeader xp_TimeSheetHeaderMenu = new Mapper.Mappings.Mapxp_TimeSheetHeader();

            var xp_TimeSheetHeaderItemsDALList = this._xp_TimeSheetHeaderDAL.GetbyId(Id);

            List<BusinessModel.xp_TimeSheetHeader> xp_TimeSheetHeaderItemsBusinessList = new List<BusinessModel.xp_TimeSheetHeader>();
            foreach (App.Data.xp_TimeSheetHeader xp_TimeSheetHeaderItem in xp_TimeSheetHeaderItemsDALList)
            {
                xp_TimeSheetHeaderItemsBusinessList.Add(xp_TimeSheetHeaderMenu.Getxp_TimeSheetHeaderBusinessObject(xp_TimeSheetHeaderItem));
            }

            return xp_TimeSheetHeaderItemsBusinessList;
        }

        public List<BusinessModel.xp_TimeSheetHeader> Getxp_TimeSheetHeaderByName(string term)
        {
            Mapper.Mappings.Mapxp_TimeSheetHeader xp_TimeSheetHeaderMenu = new Mapper.Mappings.Mapxp_TimeSheetHeader();

            var xp_TimeSheetHeaderItemsDALList = this._xp_TimeSheetHeaderDAL.GetByName(term);

            List<BusinessModel.xp_TimeSheetHeader> xp_TimeSheetHeaderItemsBusinessList = new List<BusinessModel.xp_TimeSheetHeader>();

            foreach (App.Data.xp_TimeSheetHeader xp_TimeSheetHeaderItem in xp_TimeSheetHeaderItemsDALList)
            {
                xp_TimeSheetHeaderItemsBusinessList.Add(xp_TimeSheetHeaderMenu.Getxp_TimeSheetHeaderBusinessObject(xp_TimeSheetHeaderItem));
            }

            return xp_TimeSheetHeaderItemsBusinessList;
        }

        public BusinessModel.xp_TimeSheetHeader Updatexp_TimeSheetHeader(BusinessModel.xp_TimeSheetHeader xp_TimeSheetHeaderBusinessObject)
        {
            Mapper.Mappings.Mapxp_TimeSheetHeader mapxp_TimeSheetHeader = new Mapper.Mappings.Mapxp_TimeSheetHeader();

            var xp_TimeSheetHeader = mapxp_TimeSheetHeader.Getxp_TimeSheetHeaderDatabaseObject(xp_TimeSheetHeaderBusinessObject);

            xp_TimeSheetHeader = this._xp_TimeSheetHeaderDAL.Update(xp_TimeSheetHeader, this.LoggedInUser);

            xp_TimeSheetHeaderBusinessObject = mapxp_TimeSheetHeader.Getxp_TimeSheetHeaderBusinessObject(xp_TimeSheetHeader);

            return xp_TimeSheetHeaderBusinessObject;

        }

        public bool Deletexp_TimeSheetHeader(BusinessModel.xp_TimeSheetHeader xp_TimeSheetHeaderBusinessObject)
        {
            Mapper.Mappings.Mapxp_TimeSheetHeader mapxp_TimeSheetHeader = new Mapper.Mappings.Mapxp_TimeSheetHeader();

            var xp_TimeSheetHeader = mapxp_TimeSheetHeader.Getxp_TimeSheetHeaderDatabaseObject(xp_TimeSheetHeaderBusinessObject);

            bool status = this._xp_TimeSheetHeaderDAL.Delete(xp_TimeSheetHeader, this.LoggedInUser);

            return status;
        }

    }
}
