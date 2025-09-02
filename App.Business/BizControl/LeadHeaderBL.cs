using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class LeadHeaderBL
    {
        #region Properties/Variables
        LeadHeaderDL _LeadHeaderDAL = new LeadHeaderDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public LeadHeaderBL()
        {
            // this._LeadHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.LeadHeader>();
        }

        public LeadHeaderBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._LeadHeaderDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.LeadHeader>();
        }
        #endregion

        public BusinessModel.LeadHeader CreateLeadHeader(BusinessModel.LeadHeader LeadHeaderBusinessObject)
        {
            Mapper.Mappings.MapLeadHeader LeadHeaderMenu = new Mapper.Mappings.MapLeadHeader();

            var report = LeadHeaderMenu.GetLeadHeaderDatabaseObject(LeadHeaderBusinessObject);

            report = this._LeadHeaderDAL.Create(report, this.LoggedInUser);

            LeadHeaderBusinessObject = LeadHeaderMenu.GetLeadHeaderBusinessObject(report);

            return LeadHeaderBusinessObject;

        }

        public List<BusinessModel.LeadHeader> GetAllLeadHeaderItems()
        {
            Mapper.Mappings.MapLeadHeader LeadHeaderMenu = new Mapper.Mappings.MapLeadHeader();

            var LeadHeaderItemsDALList = this._LeadHeaderDAL.GetAll();

            List<BusinessModel.LeadHeader> LeadHeaderItemsBusinessList = new List<BusinessModel.LeadHeader>();
            foreach (App.Data.LeadHeader LeadHeaderItem in LeadHeaderItemsDALList)
            {
                LeadHeaderItemsBusinessList.Add(LeadHeaderMenu.GetLeadHeaderBusinessObject(LeadHeaderItem));
            }

            return LeadHeaderItemsBusinessList;
        }

        public List<BusinessModel.LeadHeader> GetLeadHeaderItemsByID(int Id)
        {
            Mapper.Mappings.MapLeadHeader LeadHeaderMenu = new Mapper.Mappings.MapLeadHeader();

            var LeadHeaderItemsDALList = this._LeadHeaderDAL.GetbyId(Id);

            List<BusinessModel.LeadHeader> LeadHeaderItemsBusinessList = new List<BusinessModel.LeadHeader>();
            foreach (App.Data.LeadHeader LeadHeaderItem in LeadHeaderItemsDALList)
            {
                LeadHeaderItemsBusinessList.Add(LeadHeaderMenu.GetLeadHeaderBusinessObject(LeadHeaderItem));
            }

            return LeadHeaderItemsBusinessList;
        }

        public List<BusinessModel.LeadHeader> GetLeadHeaderByName(string term)
        {
            Mapper.Mappings.MapLeadHeader LeadHeaderMenu = new Mapper.Mappings.MapLeadHeader();

            var LeadHeaderItemsDALList = this._LeadHeaderDAL.GetByName(term);

            List<BusinessModel.LeadHeader> LeadHeaderItemsBusinessList = new List<BusinessModel.LeadHeader>();

            foreach (App.Data.LeadHeader LeadHeaderItem in LeadHeaderItemsDALList)
            {
                LeadHeaderItemsBusinessList.Add(LeadHeaderMenu.GetLeadHeaderBusinessObject(LeadHeaderItem));
            }

            return LeadHeaderItemsBusinessList;
        }

        public BusinessModel.LeadHeader UpdateLeadHeader(BusinessModel.LeadHeader LeadHeaderBusinessObject)
        {
            Mapper.Mappings.MapLeadHeader mapLeadHeader = new Mapper.Mappings.MapLeadHeader();

            var LeadHeader = mapLeadHeader.GetLeadHeaderDatabaseObject(LeadHeaderBusinessObject);

            LeadHeader = this._LeadHeaderDAL.Update(LeadHeader, this.LoggedInUser);

            LeadHeaderBusinessObject = mapLeadHeader.GetLeadHeaderBusinessObject(LeadHeader);

            return LeadHeaderBusinessObject;

        }

        public bool DeleteLeadHeader(BusinessModel.LeadHeader LeadHeaderBusinessObject)
        {
            Mapper.Mappings.MapLeadHeader mapLeadHeader = new Mapper.Mappings.MapLeadHeader();

            var LeadHeader = mapLeadHeader.GetLeadHeaderDatabaseObject(LeadHeaderBusinessObject);

            bool status = this._LeadHeaderDAL.Delete(LeadHeader, this.LoggedInUser);

            return status;
        }

    }
}
