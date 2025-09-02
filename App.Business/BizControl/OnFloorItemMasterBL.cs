using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class OnFloorItemMasterBL
    {
        #region Properties/Variables
        OnFloorItemMasterDL _OnFloorItemMasterDAL = new OnFloorItemMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public OnFloorItemMasterBL()
        {
            // this._OnFloorItemMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.OnFloorItemMaster>();
        }

        public OnFloorItemMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._OnFloorItemMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.OnFloorItemMaster>();
        }
        #endregion

        public BusinessModel.OnFloorItemMaster CreateOnFloorItemMaster(BusinessModel.OnFloorItemMaster OnFloorItemMasterBusinessObject)
        {
            Mapper.Mappings.MapOnFloorItemMaster OnFloorItemMasterMenu = new Mapper.Mappings.MapOnFloorItemMaster();

            var report = OnFloorItemMasterMenu.GetOnFloorItemMasterDatabaseObject(OnFloorItemMasterBusinessObject);

            report = this._OnFloorItemMasterDAL.Create(report, this.LoggedInUser);

            OnFloorItemMasterBusinessObject = OnFloorItemMasterMenu.GetOnFloorItemMasterBusinessObject(report);

            return OnFloorItemMasterBusinessObject;

        }

        public List<BusinessModel.OnFloorItemMaster> GetAllOnFloorItemMasterItems()
        {
            Mapper.Mappings.MapOnFloorItemMaster OnFloorItemMasterMenu = new Mapper.Mappings.MapOnFloorItemMaster();

            var OnFloorItemMasterItemsDALList = this._OnFloorItemMasterDAL.GetAll();

            List<BusinessModel.OnFloorItemMaster> OnFloorItemMasterItemsBusinessList = new List<BusinessModel.OnFloorItemMaster>();
            foreach (App.Data.OnFloorItemMaster OnFloorItemMasterItem in OnFloorItemMasterItemsDALList)
            {
                OnFloorItemMasterItemsBusinessList.Add(OnFloorItemMasterMenu.GetOnFloorItemMasterBusinessObject(OnFloorItemMasterItem));
            }

            return OnFloorItemMasterItemsBusinessList;
        }

        public List<BusinessModel.OnFloorItemMaster> GetOnFloorItemMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapOnFloorItemMaster OnFloorItemMasterMenu = new Mapper.Mappings.MapOnFloorItemMaster();

            var OnFloorItemMasterItemsDALList = this._OnFloorItemMasterDAL.GetbyId(Id);

            List<BusinessModel.OnFloorItemMaster> OnFloorItemMasterItemsBusinessList = new List<BusinessModel.OnFloorItemMaster>();
            foreach (App.Data.OnFloorItemMaster OnFloorItemMasterItem in OnFloorItemMasterItemsDALList)
            {
                OnFloorItemMasterItemsBusinessList.Add(OnFloorItemMasterMenu.GetOnFloorItemMasterBusinessObject(OnFloorItemMasterItem));
            }

            return OnFloorItemMasterItemsBusinessList;
        }

        public List<BusinessModel.OnFloorItemMaster> GetOnFloorItemMasterByName(string term)
        {
            Mapper.Mappings.MapOnFloorItemMaster OnFloorItemMasterMenu = new Mapper.Mappings.MapOnFloorItemMaster();

            var OnFloorItemMasterItemsDALList = this._OnFloorItemMasterDAL.GetByName(term);

            List<BusinessModel.OnFloorItemMaster> OnFloorItemMasterItemsBusinessList = new List<BusinessModel.OnFloorItemMaster>();

            foreach (App.Data.OnFloorItemMaster OnFloorItemMasterItem in OnFloorItemMasterItemsDALList)
            {
                OnFloorItemMasterItemsBusinessList.Add(OnFloorItemMasterMenu.GetOnFloorItemMasterBusinessObject(OnFloorItemMasterItem));
            }

            return OnFloorItemMasterItemsBusinessList;
        }

        public BusinessModel.OnFloorItemMaster UpdateOnFloorItemMaster(BusinessModel.OnFloorItemMaster OnFloorItemMasterBusinessObject)
        {
            Mapper.Mappings.MapOnFloorItemMaster mapOnFloorItemMaster = new Mapper.Mappings.MapOnFloorItemMaster();

            var OnFloorItemMaster = mapOnFloorItemMaster.GetOnFloorItemMasterDatabaseObject(OnFloorItemMasterBusinessObject);

            OnFloorItemMaster = this._OnFloorItemMasterDAL.Update(OnFloorItemMaster, this.LoggedInUser);

            OnFloorItemMasterBusinessObject = mapOnFloorItemMaster.GetOnFloorItemMasterBusinessObject(OnFloorItemMaster);

            return OnFloorItemMasterBusinessObject;

        }

        public bool DeleteOnFloorItemMaster(BusinessModel.OnFloorItemMaster OnFloorItemMasterBusinessObject)
        {
            Mapper.Mappings.MapOnFloorItemMaster mapOnFloorItemMaster = new Mapper.Mappings.MapOnFloorItemMaster();

            var OnFloorItemMaster = mapOnFloorItemMaster.GetOnFloorItemMasterDatabaseObject(OnFloorItemMasterBusinessObject);

            bool status = this._OnFloorItemMasterDAL.Delete(OnFloorItemMaster, this.LoggedInUser);

            return status;
        }

    }
}
