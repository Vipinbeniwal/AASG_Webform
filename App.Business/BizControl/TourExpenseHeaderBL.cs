using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class TourExpenseHeaderBL
    {
        #region Properties/Variables
        TourExpenseHeaderDL _TourExpenseHeaderDAL = new TourExpenseHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public TourExpenseHeaderBL()
        {
            // this._TourExpenseHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourExpenseHeader>();
        }

        public TourExpenseHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._TourExpenseHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourExpenseHeader>();
        }
        #endregion

        public BusinessModel.TourExpenseHeader CreateTourExpenseHeader(BusinessModel.TourExpenseHeader TourExpenseHeaderBusinessObject)
        {
            Mapper.Mappings.MapTourExpenseHeader TourExpenseHeaderMenu = new Mapper.Mappings.MapTourExpenseHeader();

            var report = TourExpenseHeaderMenu.GetTourExpenseHeaderDatabaseObject(TourExpenseHeaderBusinessObject);

            report = this._TourExpenseHeaderDAL.Create(report, this.LoggedInUser);

            TourExpenseHeaderBusinessObject = TourExpenseHeaderMenu.GetTourExpenseHeaderBusinessObject(report);

            return TourExpenseHeaderBusinessObject;

        }

        public List<BusinessModel.TourExpenseHeader> GetAllTourExpenseHeaderItems()
        {
            Mapper.Mappings.MapTourExpenseHeader TourExpenseHeaderMenu = new Mapper.Mappings.MapTourExpenseHeader();

            var TourExpenseHeaderItemsDALList = this._TourExpenseHeaderDAL.GetAll();

            List<BusinessModel.TourExpenseHeader> TourExpenseHeaderItemsBusinessList = new List<BusinessModel.TourExpenseHeader>();
            foreach (App.Data.TourExpenseHeader TourExpenseHeaderItem in TourExpenseHeaderItemsDALList)
            {
                TourExpenseHeaderItemsBusinessList.Add(TourExpenseHeaderMenu.GetTourExpenseHeaderBusinessObject(TourExpenseHeaderItem));
            }

            return TourExpenseHeaderItemsBusinessList;
        }

        public List<BusinessModel.TourExpenseHeader> GetTourExpenseHeaderItemsByID(int Id)
        {
            Mapper.Mappings.MapTourExpenseHeader TourExpenseHeaderMenu = new Mapper.Mappings.MapTourExpenseHeader();

            var TourExpenseHeaderItemsDALList = this._TourExpenseHeaderDAL.GetbyId(Id);

            List<BusinessModel.TourExpenseHeader> TourExpenseHeaderItemsBusinessList = new List<BusinessModel.TourExpenseHeader>();
            foreach (App.Data.TourExpenseHeader TourExpenseHeaderItem in TourExpenseHeaderItemsDALList)
            {
                TourExpenseHeaderItemsBusinessList.Add(TourExpenseHeaderMenu.GetTourExpenseHeaderBusinessObject(TourExpenseHeaderItem));
            }

            return TourExpenseHeaderItemsBusinessList;
        }

        public List<BusinessModel.TourExpenseHeader> GetTourExpenseHeaderByName(string term)
        {
            Mapper.Mappings.MapTourExpenseHeader TourExpenseHeaderMenu = new Mapper.Mappings.MapTourExpenseHeader();

            var TourExpenseHeaderItemsDALList = this._TourExpenseHeaderDAL.GetByName(term);

            List<BusinessModel.TourExpenseHeader> TourExpenseHeaderItemsBusinessList = new List<BusinessModel.TourExpenseHeader>();

            foreach (App.Data.TourExpenseHeader TourExpenseHeaderItem in TourExpenseHeaderItemsDALList)
            {
                TourExpenseHeaderItemsBusinessList.Add(TourExpenseHeaderMenu.GetTourExpenseHeaderBusinessObject(TourExpenseHeaderItem));
            }

            return TourExpenseHeaderItemsBusinessList;
        }

        public BusinessModel.TourExpenseHeader UpdateTourExpenseHeader(BusinessModel.TourExpenseHeader TourExpenseHeaderBusinessObject)
        {
            Mapper.Mappings.MapTourExpenseHeader mapTourExpenseHeader = new Mapper.Mappings.MapTourExpenseHeader();

            var TourExpenseHeader = mapTourExpenseHeader.GetTourExpenseHeaderDatabaseObject(TourExpenseHeaderBusinessObject);

            TourExpenseHeader = this._TourExpenseHeaderDAL.Update(TourExpenseHeader, this.LoggedInUser);

            TourExpenseHeaderBusinessObject = mapTourExpenseHeader.GetTourExpenseHeaderBusinessObject(TourExpenseHeader);

            return TourExpenseHeaderBusinessObject;

        }

        public bool DeleteTourExpenseHeader(BusinessModel.TourExpenseHeader TourExpenseHeaderBusinessObject)
        {
            Mapper.Mappings.MapTourExpenseHeader mapTourExpenseHeader = new Mapper.Mappings.MapTourExpenseHeader();

            var TourExpenseHeader = mapTourExpenseHeader.GetTourExpenseHeaderDatabaseObject(TourExpenseHeaderBusinessObject);

            bool status = this._TourExpenseHeaderDAL.Delete(TourExpenseHeader, this.LoggedInUser);

            return status;
        }

    }
}
