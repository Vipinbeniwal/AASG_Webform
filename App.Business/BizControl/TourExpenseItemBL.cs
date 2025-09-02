using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class TourExpenseItemBL
    {
        #region Properties/Variables
        TourExpenseItemDL _TourExpenseItemDAL = new TourExpenseItemDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public TourExpenseItemBL()
        {
            // this._TourExpenseItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourExpenseItem>();
        }

        public TourExpenseItemBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._TourExpenseItemDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourExpenseItem>();
        }
        #endregion

        public BusinessModel.TourExpenseItem CreateTourExpenseItem(BusinessModel.TourExpenseItem TourExpenseItemBusinessObject)
        {
            Mapper.Mappings.MapTourExpenseItem TourExpenseItemMenu = new Mapper.Mappings.MapTourExpenseItem();

            var report = TourExpenseItemMenu.GetTourExpenseItemDatabaseObject(TourExpenseItemBusinessObject);

            report = this._TourExpenseItemDAL.Create(report, this.LoggedInUser);

            TourExpenseItemBusinessObject = TourExpenseItemMenu.GetTourExpenseItemBusinessObject(report);

            return TourExpenseItemBusinessObject;

        }

        public List<BusinessModel.TourExpenseItem> GetAllTourExpenseItemItems()
        {
            Mapper.Mappings.MapTourExpenseItem TourExpenseItemMenu = new Mapper.Mappings.MapTourExpenseItem();

            var TourExpenseItemItemsDALList = this._TourExpenseItemDAL.GetAll();

            List<BusinessModel.TourExpenseItem> TourExpenseItemItemsBusinessList = new List<BusinessModel.TourExpenseItem>();
            foreach (App.Data.TourExpenseItem TourExpenseItemItem in TourExpenseItemItemsDALList)
            {
                TourExpenseItemItemsBusinessList.Add(TourExpenseItemMenu.GetTourExpenseItemBusinessObject(TourExpenseItemItem));
            }

            return TourExpenseItemItemsBusinessList;
        }

        public List<BusinessModel.TourExpenseItem> GetTourExpenseItemItemsByID(int Id)
        {
            Mapper.Mappings.MapTourExpenseItem TourExpenseItemMenu = new Mapper.Mappings.MapTourExpenseItem();

            var TourExpenseItemItemsDALList = this._TourExpenseItemDAL.GetbyId(Id);

            List<BusinessModel.TourExpenseItem> TourExpenseItemItemsBusinessList = new List<BusinessModel.TourExpenseItem>();
            foreach (App.Data.TourExpenseItem TourExpenseItemItem in TourExpenseItemItemsDALList)
            {
                TourExpenseItemItemsBusinessList.Add(TourExpenseItemMenu.GetTourExpenseItemBusinessObject(TourExpenseItemItem));
            }

            return TourExpenseItemItemsBusinessList;
        }

        public List<BusinessModel.TourExpenseItem> GetTourExpenseItemByName(string term)
        {
            Mapper.Mappings.MapTourExpenseItem TourExpenseItemMenu = new Mapper.Mappings.MapTourExpenseItem();

            var TourExpenseItemItemsDALList = this._TourExpenseItemDAL.GetByName(term);

            List<BusinessModel.TourExpenseItem> TourExpenseItemItemsBusinessList = new List<BusinessModel.TourExpenseItem>();

            foreach (App.Data.TourExpenseItem TourExpenseItemItem in TourExpenseItemItemsDALList)
            {
                TourExpenseItemItemsBusinessList.Add(TourExpenseItemMenu.GetTourExpenseItemBusinessObject(TourExpenseItemItem));
            }

            return TourExpenseItemItemsBusinessList;
        }

        public BusinessModel.TourExpenseItem UpdateTourExpenseItem(BusinessModel.TourExpenseItem TourExpenseItemBusinessObject)
        {
            Mapper.Mappings.MapTourExpenseItem mapTourExpenseItem = new Mapper.Mappings.MapTourExpenseItem();

            var TourExpenseItem = mapTourExpenseItem.GetTourExpenseItemDatabaseObject(TourExpenseItemBusinessObject);

            TourExpenseItem = this._TourExpenseItemDAL.Update(TourExpenseItem, this.LoggedInUser);

            TourExpenseItemBusinessObject = mapTourExpenseItem.GetTourExpenseItemBusinessObject(TourExpenseItem);

            return TourExpenseItemBusinessObject;

        }

        public bool DeleteTourExpenseItem(BusinessModel.TourExpenseItem TourExpenseItemBusinessObject)
        {
            Mapper.Mappings.MapTourExpenseItem mapTourExpenseItem = new Mapper.Mappings.MapTourExpenseItem();

            var TourExpenseItem = mapTourExpenseItem.GetTourExpenseItemDatabaseObject(TourExpenseItemBusinessObject);

            bool status = this._TourExpenseItemDAL.Delete(TourExpenseItem, this.LoggedInUser);

            return status;
        }

    }
}
