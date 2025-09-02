using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class xp_ItemMasterBL
    {
        #region Properties/Variables
        xp_ItemMasterDL _xp_ItemMasterDAL = new xp_ItemMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public xp_ItemMasterBL()
        {
            // this._xp_ItemMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_ItemMaster>();
        }

        public xp_ItemMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._xp_ItemMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_ItemMaster>();
        }
        #endregion

        public BusinessModel.xp_ItemMaster Createxp_ItemMaster(BusinessModel.xp_ItemMaster xp_ItemMasterBusinessObject)
        {
            Mapper.Mappings.Mapxp_ItemMaster xp_ItemMasterMenu = new Mapper.Mappings.Mapxp_ItemMaster();

            var report = xp_ItemMasterMenu.Getxp_ItemMasterDatabaseObject(xp_ItemMasterBusinessObject);

            report = this._xp_ItemMasterDAL.Create(report, this.LoggedInUser);

            xp_ItemMasterBusinessObject = xp_ItemMasterMenu.Getxp_ItemMasterBusinessObject(report);

            return xp_ItemMasterBusinessObject;

        }

        public List<BusinessModel.xp_ItemMaster> GetAllxp_ItemMasterItems()
        {
            Mapper.Mappings.Mapxp_ItemMaster xp_ItemMasterMenu = new Mapper.Mappings.Mapxp_ItemMaster();

            var xp_ItemMasterItemsDALList = this._xp_ItemMasterDAL.GetAll();

            List<BusinessModel.xp_ItemMaster> xp_ItemMasterItemsBusinessList = new List<BusinessModel.xp_ItemMaster>();
            foreach (App.Data.xp_ItemMaster xp_ItemMasterItem in xp_ItemMasterItemsDALList)
            {
                xp_ItemMasterItemsBusinessList.Add(xp_ItemMasterMenu.Getxp_ItemMasterBusinessObject(xp_ItemMasterItem));
            }

            return xp_ItemMasterItemsBusinessList;
        }

        public List<BusinessModel.xp_ItemMaster> Getxp_ItemMasterItemsByID(int Id)
        {
            Mapper.Mappings.Mapxp_ItemMaster xp_ItemMasterMenu = new Mapper.Mappings.Mapxp_ItemMaster();

            var xp_ItemMasterItemsDALList = this._xp_ItemMasterDAL.GetbyId(Id);

            List<BusinessModel.xp_ItemMaster> xp_ItemMasterItemsBusinessList = new List<BusinessModel.xp_ItemMaster>();
            foreach (App.Data.xp_ItemMaster xp_ItemMasterItem in xp_ItemMasterItemsDALList)
            {
                xp_ItemMasterItemsBusinessList.Add(xp_ItemMasterMenu.Getxp_ItemMasterBusinessObject(xp_ItemMasterItem));
            }

            return xp_ItemMasterItemsBusinessList;
        }

        public List<BusinessModel.xp_ItemMaster> Getxp_ItemMasterByName(string term)
        {
            Mapper.Mappings.Mapxp_ItemMaster xp_ItemMasterMenu = new Mapper.Mappings.Mapxp_ItemMaster();

            var xp_ItemMasterItemsDALList = this._xp_ItemMasterDAL.GetByName(term);

            List<BusinessModel.xp_ItemMaster> xp_ItemMasterItemsBusinessList = new List<BusinessModel.xp_ItemMaster>();

            foreach (App.Data.xp_ItemMaster xp_ItemMasterItem in xp_ItemMasterItemsDALList)
            {
                xp_ItemMasterItemsBusinessList.Add(xp_ItemMasterMenu.Getxp_ItemMasterBusinessObject(xp_ItemMasterItem));
            }

            return xp_ItemMasterItemsBusinessList;
        }

        public BusinessModel.xp_ItemMaster Updatexp_ItemMaster(BusinessModel.xp_ItemMaster xp_ItemMasterBusinessObject)
        {
            Mapper.Mappings.Mapxp_ItemMaster mapxp_ItemMaster = new Mapper.Mappings.Mapxp_ItemMaster();

            var xp_ItemMaster = mapxp_ItemMaster.Getxp_ItemMasterDatabaseObject(xp_ItemMasterBusinessObject);

            xp_ItemMaster = this._xp_ItemMasterDAL.Update(xp_ItemMaster, this.LoggedInUser);

            xp_ItemMasterBusinessObject = mapxp_ItemMaster.Getxp_ItemMasterBusinessObject(xp_ItemMaster);

            return xp_ItemMasterBusinessObject;

        }

        public bool Deletexp_ItemMaster(BusinessModel.xp_ItemMaster xp_ItemMasterBusinessObject)
        {
            Mapper.Mappings.Mapxp_ItemMaster mapxp_ItemMaster = new Mapper.Mappings.Mapxp_ItemMaster();

            var xp_ItemMaster = mapxp_ItemMaster.Getxp_ItemMasterDatabaseObject(xp_ItemMasterBusinessObject);

            bool status = this._xp_ItemMasterDAL.Delete(xp_ItemMaster, this.LoggedInUser);

            return status;
        }

    }
}
