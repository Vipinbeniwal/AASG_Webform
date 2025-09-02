using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class xp_ProcurementItemBL
    {
        #region Properties/Variables
        xp_ProcurementItemDL _xp_ProcurementItemDAL = new xp_ProcurementItemDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public xp_ProcurementItemBL()
        {
            // this._xp_ProcurementItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_ProcurementItem>();
        }

        public xp_ProcurementItemBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._xp_ProcurementItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.xp_ProcurementItem>();
        }
        #endregion

        public BusinessModel.xp_ProcurementItem Createxp_ProcurementItem(BusinessModel.xp_ProcurementItem xp_ProcurementItemBusinessObject)
        {
            Mapper.Mappings.Mapxp_ProcurementItem xp_ProcurementItemMenu = new Mapper.Mappings.Mapxp_ProcurementItem();

            var report = xp_ProcurementItemMenu.Getxp_ProcurementItemDatabaseObject(xp_ProcurementItemBusinessObject);

            report = this._xp_ProcurementItemDAL.Create(report, this.LoggedInUser);

            xp_ProcurementItemBusinessObject = xp_ProcurementItemMenu.Getxp_ProcurementItemBusinessObject(report);

            return xp_ProcurementItemBusinessObject;

        }

        public List<BusinessModel.xp_ProcurementItem> GetAllxp_ProcurementItemItems()
        {
            Mapper.Mappings.Mapxp_ProcurementItem xp_ProcurementItemMenu = new Mapper.Mappings.Mapxp_ProcurementItem();

            var xp_ProcurementItemItemsDALList = this._xp_ProcurementItemDAL.GetAll();

            List<BusinessModel.xp_ProcurementItem> xp_ProcurementItemItemsBusinessList = new List<BusinessModel.xp_ProcurementItem>();
            foreach (App.Data.xp_ProcurementItem xp_ProcurementItemItem in xp_ProcurementItemItemsDALList)
            {
                xp_ProcurementItemItemsBusinessList.Add(xp_ProcurementItemMenu.Getxp_ProcurementItemBusinessObject(xp_ProcurementItemItem));
            }

            return xp_ProcurementItemItemsBusinessList;
        }

        public List<BusinessModel.xp_ProcurementItem> Getxp_ProcurementItemItemsByID(int Id)
        {
            Mapper.Mappings.Mapxp_ProcurementItem xp_ProcurementItemMenu = new Mapper.Mappings.Mapxp_ProcurementItem();

            var xp_ProcurementItemItemsDALList = this._xp_ProcurementItemDAL.GetbyId(Id);

            List<BusinessModel.xp_ProcurementItem> xp_ProcurementItemItemsBusinessList = new List<BusinessModel.xp_ProcurementItem>();
            foreach (App.Data.xp_ProcurementItem xp_ProcurementItemItem in xp_ProcurementItemItemsDALList)
            {
                xp_ProcurementItemItemsBusinessList.Add(xp_ProcurementItemMenu.Getxp_ProcurementItemBusinessObject(xp_ProcurementItemItem));
            }

            return xp_ProcurementItemItemsBusinessList;
        }

        public List<BusinessModel.xp_ProcurementItem> Getxp_ProcurementItemByName(string term)
        {
            Mapper.Mappings.Mapxp_ProcurementItem xp_ProcurementItemMenu = new Mapper.Mappings.Mapxp_ProcurementItem();

            var xp_ProcurementItemItemsDALList = this._xp_ProcurementItemDAL.GetByName(term);

            List<BusinessModel.xp_ProcurementItem> xp_ProcurementItemItemsBusinessList = new List<BusinessModel.xp_ProcurementItem>();

            foreach (App.Data.xp_ProcurementItem xp_ProcurementItemItem in xp_ProcurementItemItemsDALList)
            {
                xp_ProcurementItemItemsBusinessList.Add(xp_ProcurementItemMenu.Getxp_ProcurementItemBusinessObject(xp_ProcurementItemItem));
            }

            return xp_ProcurementItemItemsBusinessList;
        }

        public BusinessModel.xp_ProcurementItem Updatexp_ProcurementItem(BusinessModel.xp_ProcurementItem xp_ProcurementItemBusinessObject)
        {
            Mapper.Mappings.Mapxp_ProcurementItem mapxp_ProcurementItem = new Mapper.Mappings.Mapxp_ProcurementItem();

            var xp_ProcurementItem = mapxp_ProcurementItem.Getxp_ProcurementItemDatabaseObject(xp_ProcurementItemBusinessObject);

            xp_ProcurementItem = this._xp_ProcurementItemDAL.Update(xp_ProcurementItem, this.LoggedInUser);

            xp_ProcurementItemBusinessObject = mapxp_ProcurementItem.Getxp_ProcurementItemBusinessObject(xp_ProcurementItem);

            return xp_ProcurementItemBusinessObject;

        }

        public bool Deletexp_ProcurementItem(BusinessModel.xp_ProcurementItem xp_ProcurementItemBusinessObject)
        {
            Mapper.Mappings.Mapxp_ProcurementItem mapxp_ProcurementItem = new Mapper.Mappings.Mapxp_ProcurementItem();

            var xp_ProcurementItem = mapxp_ProcurementItem.Getxp_ProcurementItemDatabaseObject(xp_ProcurementItemBusinessObject);

            bool status = this._xp_ProcurementItemDAL.Delete(xp_ProcurementItem, this.LoggedInUser);

            return status;
        }

    }
}
