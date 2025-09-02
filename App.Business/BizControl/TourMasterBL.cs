using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class TourMasterBL
    {
        #region Properties/Variables
        TourMasterDL _TourMasterDAL = new TourMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public TourMasterBL()
        {
            // this._TourMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourMaster>();
        }

        public TourMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._TourMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourMaster>();
        }
        #endregion

        public BusinessModel.TourMaster CreateTourMaster(BusinessModel.TourMaster TourMasterBusinessObject)
        {
            Mapper.Mappings.MapTourMaster TourMasterMenu = new Mapper.Mappings.MapTourMaster();

            var report = TourMasterMenu.GetTourMasterDatabaseObject(TourMasterBusinessObject);

            report = this._TourMasterDAL.Create(report, this.LoggedInUser);

            TourMasterBusinessObject = TourMasterMenu.GetTourMasterBusinessObject(report);

            return TourMasterBusinessObject;

        }

        public List<BusinessModel.TourMaster> GetAllTourMasterItems()
        {
            Mapper.Mappings.MapTourMaster TourMasterMenu = new Mapper.Mappings.MapTourMaster();

            var TourMasterItemsDALList = this._TourMasterDAL.GetAll();

            List<BusinessModel.TourMaster> TourMasterItemsBusinessList = new List<BusinessModel.TourMaster>();
            foreach (App.Data.TourMaster TourMasterItem in TourMasterItemsDALList)
            {
                TourMasterItemsBusinessList.Add(TourMasterMenu.GetTourMasterBusinessObject(TourMasterItem));
            }

            return TourMasterItemsBusinessList;
        }

        public List<BusinessModel.TourMaster> GetTourMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapTourMaster TourMasterMenu = new Mapper.Mappings.MapTourMaster();

            var TourMasterItemsDALList = this._TourMasterDAL.GetbyId(Id);

            List<BusinessModel.TourMaster> TourMasterItemsBusinessList = new List<BusinessModel.TourMaster>();
            foreach (App.Data.TourMaster TourMasterItem in TourMasterItemsDALList)
            {
                TourMasterItemsBusinessList.Add(TourMasterMenu.GetTourMasterBusinessObject(TourMasterItem));
            }

            return TourMasterItemsBusinessList;
        }

        public List<BusinessModel.TourMaster> GetTourMasterByName(string term)
        {
            Mapper.Mappings.MapTourMaster TourMasterMenu = new Mapper.Mappings.MapTourMaster();

            var TourMasterItemsDALList = this._TourMasterDAL.GetByName(term);

            List<BusinessModel.TourMaster> TourMasterItemsBusinessList = new List<BusinessModel.TourMaster>();

            foreach (App.Data.TourMaster TourMasterItem in TourMasterItemsDALList)
            {
                TourMasterItemsBusinessList.Add(TourMasterMenu.GetTourMasterBusinessObject(TourMasterItem));
            }

            return TourMasterItemsBusinessList;
        }

        public BusinessModel.TourMaster UpdateTourMaster(BusinessModel.TourMaster TourMasterBusinessObject)
        {
            Mapper.Mappings.MapTourMaster mapTourMaster = new Mapper.Mappings.MapTourMaster();

            var TourMaster = mapTourMaster.GetTourMasterDatabaseObject(TourMasterBusinessObject);

            TourMaster = this._TourMasterDAL.Update(TourMaster, this.LoggedInUser);

            TourMasterBusinessObject = mapTourMaster.GetTourMasterBusinessObject(TourMaster);

            return TourMasterBusinessObject;

        }

        public bool DeleteTourMaster(BusinessModel.TourMaster TourMasterBusinessObject)
        {
            Mapper.Mappings.MapTourMaster mapTourMaster = new Mapper.Mappings.MapTourMaster();

            var TourMaster = mapTourMaster.GetTourMasterDatabaseObject(TourMasterBusinessObject);

            bool status = this._TourMasterDAL.Delete(TourMaster, this.LoggedInUser);

            return status;
        }

    }
}
