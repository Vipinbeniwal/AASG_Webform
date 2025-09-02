using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class DraftMasterBL
    {
        #region Properties/Variables
        DraftMasterDL _DraftMasterDAL = new DraftMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public DraftMasterBL()
        {
            // this._DraftMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.DraftMaster>();
        }

        public DraftMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._DraftMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.DraftMaster>();
        }
        #endregion

        public BusinessModel.DraftMaster CreateDraftMaster(BusinessModel.DraftMaster DraftMasterBusinessObject)
        {
            Mapper.Mappings.MapDraftMaster DraftMasterMenu = new Mapper.Mappings.MapDraftMaster();

            var report = DraftMasterMenu.GetDraftMasterDatabaseObject(DraftMasterBusinessObject);

            report = this._DraftMasterDAL.Create(report, this.LoggedInUser);

            DraftMasterBusinessObject = DraftMasterMenu.GetDraftMasterBusinessObject(report);

            return DraftMasterBusinessObject;

        }

        public List<BusinessModel.DraftMaster> GetAllDraftMasterItems()
        {
            Mapper.Mappings.MapDraftMaster DraftMasterMenu = new Mapper.Mappings.MapDraftMaster();

            var DraftMasterItemsDALList = this._DraftMasterDAL.GetAll();

            List<BusinessModel.DraftMaster> DraftMasterItemsBusinessList = new List<BusinessModel.DraftMaster>();
            foreach (App.Data.DraftMaster DraftMasterItem in DraftMasterItemsDALList)
            {
                DraftMasterItemsBusinessList.Add(DraftMasterMenu.GetDraftMasterBusinessObject(DraftMasterItem));
            }

            return DraftMasterItemsBusinessList;
        }

        public List<BusinessModel.DraftMaster> GetDraftMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapDraftMaster DraftMasterMenu = new Mapper.Mappings.MapDraftMaster();

            var DraftMasterItemsDALList = this._DraftMasterDAL.GetbyId(Id);

            List<BusinessModel.DraftMaster> DraftMasterItemsBusinessList = new List<BusinessModel.DraftMaster>();
            foreach (App.Data.DraftMaster DraftMasterItem in DraftMasterItemsDALList)
            {
                DraftMasterItemsBusinessList.Add(DraftMasterMenu.GetDraftMasterBusinessObject(DraftMasterItem));
            }

            return DraftMasterItemsBusinessList;
        }

        public List<BusinessModel.DraftMaster> GetDraftMasterByName(string term)
        {
            Mapper.Mappings.MapDraftMaster DraftMasterMenu = new Mapper.Mappings.MapDraftMaster();

            var DraftMasterItemsDALList = this._DraftMasterDAL.GetByName(term);

            List<BusinessModel.DraftMaster> DraftMasterItemsBusinessList = new List<BusinessModel.DraftMaster>();

            foreach (App.Data.DraftMaster DraftMasterItem in DraftMasterItemsDALList)
            {
                DraftMasterItemsBusinessList.Add(DraftMasterMenu.GetDraftMasterBusinessObject(DraftMasterItem));
            }

            return DraftMasterItemsBusinessList;
        }

        public BusinessModel.DraftMaster UpdateDraftMaster(BusinessModel.DraftMaster DraftMasterBusinessObject)
        {
            Mapper.Mappings.MapDraftMaster mapDraftMaster = new Mapper.Mappings.MapDraftMaster();

            var DraftMaster = mapDraftMaster.GetDraftMasterDatabaseObject(DraftMasterBusinessObject);

            DraftMaster = this._DraftMasterDAL.Update(DraftMaster, this.LoggedInUser);

            DraftMasterBusinessObject = mapDraftMaster.GetDraftMasterBusinessObject(DraftMaster);

            return DraftMasterBusinessObject;

        }

        public bool DeleteDraftMaster(BusinessModel.DraftMaster DraftMasterBusinessObject)
        {
            Mapper.Mappings.MapDraftMaster mapDraftMaster = new Mapper.Mappings.MapDraftMaster();

            var DraftMaster = mapDraftMaster.GetDraftMasterDatabaseObject(DraftMasterBusinessObject);

            bool status = this._DraftMasterDAL.Delete(DraftMaster, this.LoggedInUser);

            return status;
        }

    }
}
