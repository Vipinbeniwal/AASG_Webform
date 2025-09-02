using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ChallanItemBL
    {
        #region Properties/Variables
        ChallanItemDL _ChallanItemDAL = new ChallanItemDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ChallanItemBL()
        {
            // this._ChallanItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ChallanItem>();
        }

        public ChallanItemBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ChallanItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ChallanItem>();
        }
        #endregion

        public BusinessModel.ChallanItem CreateChallanItem(BusinessModel.ChallanItem ChallanItemBusinessObject)
        {
            Mapper.Mappings.MapChallanItem ChallanItemMenu = new Mapper.Mappings.MapChallanItem();

            var report = ChallanItemMenu.GetChallanItemDatabaseObject(ChallanItemBusinessObject);

            report = this._ChallanItemDAL.Create(report, this.LoggedInUser);

            ChallanItemBusinessObject = ChallanItemMenu.GetChallanItemBusinessObject(report);

            return ChallanItemBusinessObject;

        }

        public List<BusinessModel.ChallanItem> GetAllChallanItemItems()
        {
            Mapper.Mappings.MapChallanItem ChallanItemMenu = new Mapper.Mappings.MapChallanItem();

            var ChallanItemItemsDALList = this._ChallanItemDAL.GetAll();

            List<BusinessModel.ChallanItem> ChallanItemItemsBusinessList = new List<BusinessModel.ChallanItem>();
            foreach (App.Data.ChallanItem ChallanItemItem in ChallanItemItemsDALList)
            {
                ChallanItemItemsBusinessList.Add(ChallanItemMenu.GetChallanItemBusinessObject(ChallanItemItem));
            }

            return ChallanItemItemsBusinessList;
        }

        public List<BusinessModel.ChallanItem> GetChallanItemItemsByID(int Id)
        {
            Mapper.Mappings.MapChallanItem ChallanItemMenu = new Mapper.Mappings.MapChallanItem();

            var ChallanItemItemsDALList = this._ChallanItemDAL.GetbyId(Id);

            List<BusinessModel.ChallanItem> ChallanItemItemsBusinessList = new List<BusinessModel.ChallanItem>();
            foreach (App.Data.ChallanItem ChallanItemItem in ChallanItemItemsDALList)
            {
                ChallanItemItemsBusinessList.Add(ChallanItemMenu.GetChallanItemBusinessObject(ChallanItemItem));
            }

            return ChallanItemItemsBusinessList;
        }

        public List<BusinessModel.ChallanItem> GetChallanItemByName(string term)
        {
            Mapper.Mappings.MapChallanItem ChallanItemMenu = new Mapper.Mappings.MapChallanItem();

            var ChallanItemItemsDALList = this._ChallanItemDAL.GetByName(term);

            List<BusinessModel.ChallanItem> ChallanItemItemsBusinessList = new List<BusinessModel.ChallanItem>();

            foreach (App.Data.ChallanItem ChallanItemItem in ChallanItemItemsDALList)
            {
                ChallanItemItemsBusinessList.Add(ChallanItemMenu.GetChallanItemBusinessObject(ChallanItemItem));
            }

            return ChallanItemItemsBusinessList;
        }

        public BusinessModel.ChallanItem UpdateChallanItem(BusinessModel.ChallanItem ChallanItemBusinessObject)
        {
            Mapper.Mappings.MapChallanItem mapChallanItem = new Mapper.Mappings.MapChallanItem();

            var ChallanItem = mapChallanItem.GetChallanItemDatabaseObject(ChallanItemBusinessObject);

            ChallanItem = this._ChallanItemDAL.Update(ChallanItem, this.LoggedInUser);

            ChallanItemBusinessObject = mapChallanItem.GetChallanItemBusinessObject(ChallanItem);

            return ChallanItemBusinessObject;

        }

        public bool DeleteChallanItem(BusinessModel.ChallanItem ChallanItemBusinessObject)
        {
            Mapper.Mappings.MapChallanItem mapChallanItem = new Mapper.Mappings.MapChallanItem();

            var ChallanItem = mapChallanItem.GetChallanItemDatabaseObject(ChallanItemBusinessObject);

            bool status = this._ChallanItemDAL.Delete(ChallanItem, this.LoggedInUser);

            return status;
        }

    }
}
