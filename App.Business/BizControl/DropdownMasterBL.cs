using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class DropdownMasterBL
    {
        #region Properties/Variables
        DropdownMasterDL _DropdownMasterDAL = new DropdownMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public DropdownMasterBL()
        {
            // this._DropdownMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.DropdownMaster>();
        }

        public DropdownMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._DropdownMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.DropdownMaster>();
        }
        #endregion

        public BusinessModel.DropdownMaster CreateDropdownMaster(BusinessModel.DropdownMaster DropdownMasterBusinessObject)
        {
            Mapper.Mappings.MapDropdownMaster DropdownMasterMenu = new Mapper.Mappings.MapDropdownMaster();

            var report = DropdownMasterMenu.GetDropdownMasterDatabaseObject(DropdownMasterBusinessObject);

            report = this._DropdownMasterDAL.Create(report, this.LoggedInUser);

            DropdownMasterBusinessObject = DropdownMasterMenu.GetDropdownMasterBusinessObject(report);

            return DropdownMasterBusinessObject;

        }

        public List<BusinessModel.DropdownMaster> GetAllDropdownMasterItems()
        {
            Mapper.Mappings.MapDropdownMaster DropdownMasterMenu = new Mapper.Mappings.MapDropdownMaster();

            var DropdownMasterItemsDALList = this._DropdownMasterDAL.GetAll();

            List<BusinessModel.DropdownMaster> DropdownMasterItemsBusinessList = new List<BusinessModel.DropdownMaster>();
            foreach (App.Data.DropdownMaster DropdownMasterItem in DropdownMasterItemsDALList)
            {
                DropdownMasterItemsBusinessList.Add(DropdownMasterMenu.GetDropdownMasterBusinessObject(DropdownMasterItem));
            }

            return DropdownMasterItemsBusinessList;
        }

        public List<BusinessModel.DropdownMaster> GetDropdownMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapDropdownMaster DropdownMasterMenu = new Mapper.Mappings.MapDropdownMaster();

            var DropdownMasterItemsDALList = this._DropdownMasterDAL.GetbyId(Id);

            List<BusinessModel.DropdownMaster> DropdownMasterItemsBusinessList = new List<BusinessModel.DropdownMaster>();
            foreach (App.Data.DropdownMaster DropdownMasterItem in DropdownMasterItemsDALList)
            {
                DropdownMasterItemsBusinessList.Add(DropdownMasterMenu.GetDropdownMasterBusinessObject(DropdownMasterItem));
            }

            return DropdownMasterItemsBusinessList;
        }

        public List<BusinessModel.DropdownMaster> GetDropdownMasterByName(string term)
        {
            Mapper.Mappings.MapDropdownMaster DropdownMasterMenu = new Mapper.Mappings.MapDropdownMaster();

            var DropdownMasterItemsDALList = this._DropdownMasterDAL.GetByName(term);

            List<BusinessModel.DropdownMaster> DropdownMasterItemsBusinessList = new List<BusinessModel.DropdownMaster>();

            foreach (App.Data.DropdownMaster DropdownMasterItem in DropdownMasterItemsDALList)
            {
                DropdownMasterItemsBusinessList.Add(DropdownMasterMenu.GetDropdownMasterBusinessObject(DropdownMasterItem));
            }

            return DropdownMasterItemsBusinessList;
        }

        public BusinessModel.DropdownMaster UpdateDropdownMaster(BusinessModel.DropdownMaster DropdownMasterBusinessObject)
        {
            Mapper.Mappings.MapDropdownMaster mapDropdownMaster = new Mapper.Mappings.MapDropdownMaster();

            var DropdownMaster = mapDropdownMaster.GetDropdownMasterDatabaseObject(DropdownMasterBusinessObject);

            DropdownMaster = this._DropdownMasterDAL.Update(DropdownMaster, this.LoggedInUser);

            DropdownMasterBusinessObject = mapDropdownMaster.GetDropdownMasterBusinessObject(DropdownMaster);

            return DropdownMasterBusinessObject;

        }

        public bool DeleteDropdownMaster(BusinessModel.DropdownMaster DropdownMasterBusinessObject)
        {
            Mapper.Mappings.MapDropdownMaster mapDropdownMaster = new Mapper.Mappings.MapDropdownMaster();

            var DropdownMaster = mapDropdownMaster.GetDropdownMasterDatabaseObject(DropdownMasterBusinessObject);

            bool status = this._DropdownMasterDAL.Delete(DropdownMaster, this.LoggedInUser);

            return status;
        }

    }
}
