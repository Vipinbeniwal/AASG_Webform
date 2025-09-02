using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class xp_TimeSheetChildBL
    {
        #region Properties/Variables
        xp_TimeSheetChildDL _xp_TimeSheetChildDAL = new xp_TimeSheetChildDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public xp_TimeSheetChildBL()
        {
            // this._xp_TimeSheetChildDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_TimeSheetChild>();
        }

        public xp_TimeSheetChildBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._xp_TimeSheetChildDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_TimeSheetChild>();
        }
        #endregion

        public BusinessModel.xp_TimeSheetChild Createxp_TimeSheetChild(BusinessModel.xp_TimeSheetChild xp_TimeSheetChildBusinessObject)
        {
            Mapper.Mappings.Mapxp_TimeSheetChild xp_TimeSheetChildMenu = new Mapper.Mappings.Mapxp_TimeSheetChild();

            var report = xp_TimeSheetChildMenu.Getxp_TimeSheetChildDatabaseObject(xp_TimeSheetChildBusinessObject);

            report = this._xp_TimeSheetChildDAL.Create(report, this.LoggedInUser);

            xp_TimeSheetChildBusinessObject = xp_TimeSheetChildMenu.Getxp_TimeSheetChildBusinessObject(report);

            return xp_TimeSheetChildBusinessObject;

        }

        public List<BusinessModel.xp_TimeSheetChild> GetAllxp_TimeSheetChildItems()
        {
            Mapper.Mappings.Mapxp_TimeSheetChild xp_TimeSheetChildMenu = new Mapper.Mappings.Mapxp_TimeSheetChild();

            var xp_TimeSheetChildItemsDALList = this._xp_TimeSheetChildDAL.GetAll();

            List<BusinessModel.xp_TimeSheetChild> xp_TimeSheetChildItemsBusinessList = new List<BusinessModel.xp_TimeSheetChild>();
            foreach (App.Data.xp_TimeSheetChild xp_TimeSheetChildItem in xp_TimeSheetChildItemsDALList)
            {
                xp_TimeSheetChildItemsBusinessList.Add(xp_TimeSheetChildMenu.Getxp_TimeSheetChildBusinessObject(xp_TimeSheetChildItem));
            }

            return xp_TimeSheetChildItemsBusinessList;
        }

        public List<BusinessModel.xp_TimeSheetChild> Getxp_TimeSheetChildItemsByID(int Id)
        {
            Mapper.Mappings.Mapxp_TimeSheetChild xp_TimeSheetChildMenu = new Mapper.Mappings.Mapxp_TimeSheetChild();

            var xp_TimeSheetChildItemsDALList = this._xp_TimeSheetChildDAL.GetbyId(Id);

            List<BusinessModel.xp_TimeSheetChild> xp_TimeSheetChildItemsBusinessList = new List<BusinessModel.xp_TimeSheetChild>();
            foreach (App.Data.xp_TimeSheetChild xp_TimeSheetChildItem in xp_TimeSheetChildItemsDALList)
            {
                xp_TimeSheetChildItemsBusinessList.Add(xp_TimeSheetChildMenu.Getxp_TimeSheetChildBusinessObject(xp_TimeSheetChildItem));
            }

            return xp_TimeSheetChildItemsBusinessList;
        }

        public List<BusinessModel.xp_TimeSheetChild> Getxp_TimeSheetChildByName(string term)
        {
            Mapper.Mappings.Mapxp_TimeSheetChild xp_TimeSheetChildMenu = new Mapper.Mappings.Mapxp_TimeSheetChild();

            var xp_TimeSheetChildItemsDALList = this._xp_TimeSheetChildDAL.GetByName(term);

            List<BusinessModel.xp_TimeSheetChild> xp_TimeSheetChildItemsBusinessList = new List<BusinessModel.xp_TimeSheetChild>();

            foreach (App.Data.xp_TimeSheetChild xp_TimeSheetChildItem in xp_TimeSheetChildItemsDALList)
            {
                xp_TimeSheetChildItemsBusinessList.Add(xp_TimeSheetChildMenu.Getxp_TimeSheetChildBusinessObject(xp_TimeSheetChildItem));
            }

            return xp_TimeSheetChildItemsBusinessList;
        }

        public BusinessModel.xp_TimeSheetChild Updatexp_TimeSheetChild(BusinessModel.xp_TimeSheetChild xp_TimeSheetChildBusinessObject)
        {
            Mapper.Mappings.Mapxp_TimeSheetChild mapxp_TimeSheetChild = new Mapper.Mappings.Mapxp_TimeSheetChild();

            var xp_TimeSheetChild = mapxp_TimeSheetChild.Getxp_TimeSheetChildDatabaseObject(xp_TimeSheetChildBusinessObject);

            xp_TimeSheetChild = this._xp_TimeSheetChildDAL.Update(xp_TimeSheetChild, this.LoggedInUser);

            xp_TimeSheetChildBusinessObject = mapxp_TimeSheetChild.Getxp_TimeSheetChildBusinessObject(xp_TimeSheetChild);

            return xp_TimeSheetChildBusinessObject;

        }

        public bool Deletexp_TimeSheetChild(BusinessModel.xp_TimeSheetChild xp_TimeSheetChildBusinessObject)
        {
            Mapper.Mappings.Mapxp_TimeSheetChild mapxp_TimeSheetChild = new Mapper.Mappings.Mapxp_TimeSheetChild();

            var xp_TimeSheetChild = mapxp_TimeSheetChild.Getxp_TimeSheetChildDatabaseObject(xp_TimeSheetChildBusinessObject);

            bool status = this._xp_TimeSheetChildDAL.Delete(xp_TimeSheetChild, this.LoggedInUser);

            return status;
        }

    }
}
