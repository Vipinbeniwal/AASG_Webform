using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class LoadingMasterBL
    {
        #region Properties/Variables
        LoadingMasterDL _LoadingMasterDAL = new LoadingMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public LoadingMasterBL()
        {
            // this._LoadingMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.LoadingMaster>();
        }

        public LoadingMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._LoadingMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.LoadingMaster>();
        }
        #endregion

        public BusinessModel.LoadingMaster CreateLoadingMaster(BusinessModel.LoadingMaster LoadingMasterBusinessObject)
        {
            Mapper.Mappings.MapLoadingMaster LoadingMasterMenu = new Mapper.Mappings.MapLoadingMaster();

            var report = LoadingMasterMenu.GetLoadingMasterDatabaseObject(LoadingMasterBusinessObject);

            report = this._LoadingMasterDAL.Create(report, this.LoggedInUser);

            LoadingMasterBusinessObject = LoadingMasterMenu.GetLoadingMasterBusinessObject(report);

            return LoadingMasterBusinessObject;

        }

        public List<BusinessModel.LoadingMaster> GetAllLoadingMasterItems()
        {
            Mapper.Mappings.MapLoadingMaster LoadingMasterMenu = new Mapper.Mappings.MapLoadingMaster();

            var LoadingMasterItemsDALList = this._LoadingMasterDAL.GetAll();

            List<BusinessModel.LoadingMaster> LoadingMasterItemsBusinessList = new List<BusinessModel.LoadingMaster>();
            foreach (App.Data.LoadingMaster LoadingMasterItem in LoadingMasterItemsDALList)
            {
                LoadingMasterItemsBusinessList.Add(LoadingMasterMenu.GetLoadingMasterBusinessObject(LoadingMasterItem));
            }

            return LoadingMasterItemsBusinessList;
        }

        public List<BusinessModel.LoadingMaster> GetLoadingMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapLoadingMaster LoadingMasterMenu = new Mapper.Mappings.MapLoadingMaster();

            var LoadingMasterItemsDALList = this._LoadingMasterDAL.GetbyId(Id);

            List<BusinessModel.LoadingMaster> LoadingMasterItemsBusinessList = new List<BusinessModel.LoadingMaster>();
            foreach (App.Data.LoadingMaster LoadingMasterItem in LoadingMasterItemsDALList)
            {
                LoadingMasterItemsBusinessList.Add(LoadingMasterMenu.GetLoadingMasterBusinessObject(LoadingMasterItem));
            }

            return LoadingMasterItemsBusinessList;
        }


        public List<BusinessModel.LoadingMaster> GetLoadingMasterItemsByOrderNumber(string Id)
        {
            Mapper.Mappings.MapLoadingMaster LoadingMasterMenu = new Mapper.Mappings.MapLoadingMaster();

            var LoadingMasterItemsDALList = this._LoadingMasterDAL.GetbyOrderNumber(Id);

            List<BusinessModel.LoadingMaster> LoadingMasterItemsBusinessList = new List<BusinessModel.LoadingMaster>();
            foreach (App.Data.LoadingMaster LoadingMasterItem in LoadingMasterItemsDALList)
            {
                LoadingMasterItemsBusinessList.Add(LoadingMasterMenu.GetLoadingMasterBusinessObject(LoadingMasterItem));
            }

            return LoadingMasterItemsBusinessList;
        }

        public List<BusinessModel.LoadingMaster> GetLoadingMasterByName(string term)
        {
            Mapper.Mappings.MapLoadingMaster LoadingMasterMenu = new Mapper.Mappings.MapLoadingMaster();

            var LoadingMasterItemsDALList = this._LoadingMasterDAL.GetByName(term);

            List<BusinessModel.LoadingMaster> LoadingMasterItemsBusinessList = new List<BusinessModel.LoadingMaster>();

            foreach (App.Data.LoadingMaster LoadingMasterItem in LoadingMasterItemsDALList)
            {
                LoadingMasterItemsBusinessList.Add(LoadingMasterMenu.GetLoadingMasterBusinessObject(LoadingMasterItem));
            }

            return LoadingMasterItemsBusinessList;
        }

        public BusinessModel.LoadingMaster UpdateLoadingMaster(BusinessModel.LoadingMaster LoadingMasterBusinessObject)
        {
            Mapper.Mappings.MapLoadingMaster mapLoadingMaster = new Mapper.Mappings.MapLoadingMaster();

            var LoadingMaster = mapLoadingMaster.GetLoadingMasterDatabaseObject(LoadingMasterBusinessObject);

            LoadingMaster = this._LoadingMasterDAL.Update(LoadingMaster, this.LoggedInUser);

            LoadingMasterBusinessObject = mapLoadingMaster.GetLoadingMasterBusinessObject(LoadingMaster);

            return LoadingMasterBusinessObject;

        }

        public bool DeleteLoadingMaster(BusinessModel.LoadingMaster LoadingMasterBusinessObject)
        {
            Mapper.Mappings.MapLoadingMaster mapLoadingMaster = new Mapper.Mappings.MapLoadingMaster();

            var LoadingMaster = mapLoadingMaster.GetLoadingMasterDatabaseObject(LoadingMasterBusinessObject);

            bool status = this._LoadingMasterDAL.Delete(LoadingMaster, this.LoggedInUser);

            return status;
        }

    }
}
