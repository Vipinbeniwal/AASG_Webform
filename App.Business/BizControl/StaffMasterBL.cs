using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class StaffMasterBL
    {
        #region Properties/Variables
        StaffMasterDL _StaffMasterDAL = new StaffMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public StaffMasterBL()
        {
            // this._StaffMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StaffMaster>();
        }

        public StaffMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._StaffMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.StaffMaster>();
        }
        #endregion

        public BusinessModel.StaffMaster CreateStaffMaster(BusinessModel.StaffMaster StaffMasterBusinessObject)
        {
            Mapper.Mappings.MapStaffMaster StaffMasterMenu = new Mapper.Mappings.MapStaffMaster();

            var report = StaffMasterMenu.GetStaffMasterDatabaseObject(StaffMasterBusinessObject);

            report = this._StaffMasterDAL.Create(report, this.LoggedInUser);

            StaffMasterBusinessObject = StaffMasterMenu.GetStaffMasterBusinessObject(report);

            return StaffMasterBusinessObject;

        }

        public List<BusinessModel.StaffMaster> GetAllStaffMasterItems()
        {
            Mapper.Mappings.MapStaffMaster StaffMasterMenu = new Mapper.Mappings.MapStaffMaster();

            var StaffMasterItemsDALList = this._StaffMasterDAL.GetAll();

            List<BusinessModel.StaffMaster> StaffMasterItemsBusinessList = new List<BusinessModel.StaffMaster>();
            foreach (App.Data.StaffMaster StaffMasterItem in StaffMasterItemsDALList)
            {
                StaffMasterItemsBusinessList.Add(StaffMasterMenu.GetStaffMasterBusinessObject(StaffMasterItem));
            }

            return StaffMasterItemsBusinessList;
        }

        public List<BusinessModel.StaffMaster> GetStaffMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapStaffMaster StaffMasterMenu = new Mapper.Mappings.MapStaffMaster();

            var StaffMasterItemsDALList = this._StaffMasterDAL.GetbyId(Id);

            List<BusinessModel.StaffMaster> StaffMasterItemsBusinessList = new List<BusinessModel.StaffMaster>();
            foreach (App.Data.StaffMaster StaffMasterItem in StaffMasterItemsDALList)
            {
                StaffMasterItemsBusinessList.Add(StaffMasterMenu.GetStaffMasterBusinessObject(StaffMasterItem));
            }

            return StaffMasterItemsBusinessList;
        }

        public List<BusinessModel.StaffMaster> GetStaffMasterByName(string term)
        {
            Mapper.Mappings.MapStaffMaster StaffMasterMenu = new Mapper.Mappings.MapStaffMaster();

            var StaffMasterItemsDALList = this._StaffMasterDAL.GetByName(term);

            List<BusinessModel.StaffMaster> StaffMasterItemsBusinessList = new List<BusinessModel.StaffMaster>();

            foreach (App.Data.StaffMaster StaffMasterItem in StaffMasterItemsDALList)
            {
                StaffMasterItemsBusinessList.Add(StaffMasterMenu.GetStaffMasterBusinessObject(StaffMasterItem));
            }

            return StaffMasterItemsBusinessList;
        }

        public BusinessModel.StaffMaster UpdateStaffMaster(BusinessModel.StaffMaster StaffMasterBusinessObject)
        {
            Mapper.Mappings.MapStaffMaster mapStaffMaster = new Mapper.Mappings.MapStaffMaster();

            var StaffMaster = mapStaffMaster.GetStaffMasterDatabaseObject(StaffMasterBusinessObject);

            StaffMaster = this._StaffMasterDAL.Update(StaffMaster, this.LoggedInUser);

            StaffMasterBusinessObject = mapStaffMaster.GetStaffMasterBusinessObject(StaffMaster);

            return StaffMasterBusinessObject;

        }

        public bool DeleteStaffMaster(BusinessModel.StaffMaster StaffMasterBusinessObject)
        {
            Mapper.Mappings.MapStaffMaster mapStaffMaster = new Mapper.Mappings.MapStaffMaster();

            var StaffMaster = mapStaffMaster.GetStaffMasterDatabaseObject(StaffMasterBusinessObject);

            bool status = this._StaffMasterDAL.Delete(StaffMaster, this.LoggedInUser);

            return status;
        }

    }
}
