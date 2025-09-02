using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class TourGradeMasterBL
    {
        #region Properties/Variables
        TourGradeMasterDL _TourGradeMasterDAL = new TourGradeMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public TourGradeMasterBL()
        {
            // this._TourGradeMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourGradeMaster>();
        }

        public TourGradeMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._TourGradeMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.TourGradeMaster>();
        }
        #endregion

        public BusinessModel.TourGradeMaster CreateTourGradeMaster(BusinessModel.TourGradeMaster TourGradeMasterBusinessObject)
        {
            Mapper.Mappings.MapTourGradeMaster TourGradeMasterMenu = new Mapper.Mappings.MapTourGradeMaster();

            var report = TourGradeMasterMenu.GetTourGradeMasterDatabaseObject(TourGradeMasterBusinessObject);

            report = this._TourGradeMasterDAL.Create(report, this.LoggedInUser);

            TourGradeMasterBusinessObject = TourGradeMasterMenu.GetTourGradeMasterBusinessObject(report);

            return TourGradeMasterBusinessObject;

        }

        public List<BusinessModel.TourGradeMaster> GetAllTourGradeMasterItems()
        {
            Mapper.Mappings.MapTourGradeMaster TourGradeMasterMenu = new Mapper.Mappings.MapTourGradeMaster();

            var TourGradeMasterItemsDALList = this._TourGradeMasterDAL.GetAll();

            List<BusinessModel.TourGradeMaster> TourGradeMasterItemsBusinessList = new List<BusinessModel.TourGradeMaster>();
            foreach (App.Data.TourGradeMaster TourGradeMasterItem in TourGradeMasterItemsDALList)
            {
                TourGradeMasterItemsBusinessList.Add(TourGradeMasterMenu.GetTourGradeMasterBusinessObject(TourGradeMasterItem));
            }

            return TourGradeMasterItemsBusinessList;
        }

        public List<BusinessModel.TourGradeMaster> GetTourGradeMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapTourGradeMaster TourGradeMasterMenu = new Mapper.Mappings.MapTourGradeMaster();

            var TourGradeMasterItemsDALList = this._TourGradeMasterDAL.GetbyId(Id);

            List<BusinessModel.TourGradeMaster> TourGradeMasterItemsBusinessList = new List<BusinessModel.TourGradeMaster>();
            foreach (App.Data.TourGradeMaster TourGradeMasterItem in TourGradeMasterItemsDALList)
            {
                TourGradeMasterItemsBusinessList.Add(TourGradeMasterMenu.GetTourGradeMasterBusinessObject(TourGradeMasterItem));
            }

            return TourGradeMasterItemsBusinessList;
        }

        public List<BusinessModel.TourGradeMaster> GetTourGradeMasterByName(string term)
        {
            Mapper.Mappings.MapTourGradeMaster TourGradeMasterMenu = new Mapper.Mappings.MapTourGradeMaster();

            var TourGradeMasterItemsDALList = this._TourGradeMasterDAL.GetByName(term);

            List<BusinessModel.TourGradeMaster> TourGradeMasterItemsBusinessList = new List<BusinessModel.TourGradeMaster>();

            foreach (App.Data.TourGradeMaster TourGradeMasterItem in TourGradeMasterItemsDALList)
            {
                TourGradeMasterItemsBusinessList.Add(TourGradeMasterMenu.GetTourGradeMasterBusinessObject(TourGradeMasterItem));
            }

            return TourGradeMasterItemsBusinessList;
        }

        public BusinessModel.TourGradeMaster UpdateTourGradeMaster(BusinessModel.TourGradeMaster TourGradeMasterBusinessObject)
        {
            Mapper.Mappings.MapTourGradeMaster mapTourGradeMaster = new Mapper.Mappings.MapTourGradeMaster();

            var TourGradeMaster = mapTourGradeMaster.GetTourGradeMasterDatabaseObject(TourGradeMasterBusinessObject);

            TourGradeMaster = this._TourGradeMasterDAL.Update(TourGradeMaster, this.LoggedInUser);

            TourGradeMasterBusinessObject = mapTourGradeMaster.GetTourGradeMasterBusinessObject(TourGradeMaster);

            return TourGradeMasterBusinessObject;

        }

        public bool DeleteTourGradeMaster(BusinessModel.TourGradeMaster TourGradeMasterBusinessObject)
        {
            Mapper.Mappings.MapTourGradeMaster mapTourGradeMaster = new Mapper.Mappings.MapTourGradeMaster();

            var TourGradeMaster = mapTourGradeMaster.GetTourGradeMasterDatabaseObject(TourGradeMasterBusinessObject);

            bool status = this._TourGradeMasterDAL.Delete(TourGradeMaster, this.LoggedInUser);

            return status;
        }

    }
}
