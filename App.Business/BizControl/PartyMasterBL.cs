using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class PartyMasterBL
    {
        #region Properties/Variables
        PartyMasterDL _PartyMasterDAL = new PartyMasterDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public PartyMasterBL()
        {
            // this._PartyMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.PartyMaster>();
        }

        public PartyMasterBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._PartyMasterDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.PartyMaster>();
        }
        #endregion

        public BusinessModel.PartyMaster CreatePartyMaster(BusinessModel.PartyMaster PartyMasterBusinessObject)
        {
            Mapper.Mappings.MapPartyMaster PartyMasterMenu = new Mapper.Mappings.MapPartyMaster();

            var report = PartyMasterMenu.GetPartyMasterDatabaseObject(PartyMasterBusinessObject);

            report = this._PartyMasterDAL.Create(report, this.LoggedInUser);

            PartyMasterBusinessObject = PartyMasterMenu.GetPartyMasterBusinessObject(report);

            return PartyMasterBusinessObject;

        }

        public List<BusinessModel.PartyMaster> GetAllPartyMasterItems()
        {
            Mapper.Mappings.MapPartyMaster PartyMasterMenu = new Mapper.Mappings.MapPartyMaster();

            var PartyMasterItemsDALList = this._PartyMasterDAL.GetAll();

            List<BusinessModel.PartyMaster> PartyMasterItemsBusinessList = new List<BusinessModel.PartyMaster>();
            foreach (App.Data.PartyMaster PartyMasterItem in PartyMasterItemsDALList)
            {
                PartyMasterItemsBusinessList.Add(PartyMasterMenu.GetPartyMasterBusinessObject(PartyMasterItem));
            }

            return PartyMasterItemsBusinessList;
        }

        public List<BusinessModel.PartyMaster> GetPartyMasterItemsByID(int Id)
        {
            Mapper.Mappings.MapPartyMaster PartyMasterMenu = new Mapper.Mappings.MapPartyMaster();

            var PartyMasterItemsDALList = this._PartyMasterDAL.GetbyId(Id);

            List<BusinessModel.PartyMaster> PartyMasterItemsBusinessList = new List<BusinessModel.PartyMaster>();
            foreach (App.Data.PartyMaster PartyMasterItem in PartyMasterItemsDALList)
            {
                PartyMasterItemsBusinessList.Add(PartyMasterMenu.GetPartyMasterBusinessObject(PartyMasterItem));
            }

            return PartyMasterItemsBusinessList;
        }

        public List<BusinessModel.PartyMaster> GetPartyMasterByName(string term)
        {
            Mapper.Mappings.MapPartyMaster PartyMasterMenu = new Mapper.Mappings.MapPartyMaster();

            var PartyMasterItemsDALList = this._PartyMasterDAL.GetByName(term);

            List<BusinessModel.PartyMaster> PartyMasterItemsBusinessList = new List<BusinessModel.PartyMaster>();

            foreach (App.Data.PartyMaster PartyMasterItem in PartyMasterItemsDALList)
            {
                PartyMasterItemsBusinessList.Add(PartyMasterMenu.GetPartyMasterBusinessObject(PartyMasterItem));
            }

            return PartyMasterItemsBusinessList;
        }

        public BusinessModel.PartyMaster UpdatePartyMaster(BusinessModel.PartyMaster PartyMasterBusinessObject)
        {
            Mapper.Mappings.MapPartyMaster mapPartyMaster = new Mapper.Mappings.MapPartyMaster();

            var PartyMaster = mapPartyMaster.GetPartyMasterDatabaseObject(PartyMasterBusinessObject);

            PartyMaster = this._PartyMasterDAL.Update(PartyMaster, this.LoggedInUser);

            PartyMasterBusinessObject = mapPartyMaster.GetPartyMasterBusinessObject(PartyMaster);

            return PartyMasterBusinessObject;

        }

        public bool DeletePartyMaster(BusinessModel.PartyMaster PartyMasterBusinessObject)
        {
            Mapper.Mappings.MapPartyMaster mapPartyMaster = new Mapper.Mappings.MapPartyMaster();

            var PartyMaster = mapPartyMaster.GetPartyMasterDatabaseObject(PartyMasterBusinessObject);

            bool status = this._PartyMasterDAL.Delete(PartyMaster, this.LoggedInUser);

            return status;
        }

    }
}
