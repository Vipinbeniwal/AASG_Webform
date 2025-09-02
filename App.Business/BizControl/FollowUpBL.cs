using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class FollowUpBL
    {
        #region Properties/Variables
        FollowUpDL _FollowUpDAL = new FollowUpDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public FollowUpBL()
        {
            // this._FollowUpDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.FollowUp>();
        }

        public FollowUpBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._FollowUpDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.FollowUp>();
        }
        #endregion

        public BusinessModel.FollowUp CreateFollowUp(BusinessModel.FollowUp FollowUpBusinessObject)
        {
            Mapper.Mappings.MapFollowUp FollowUpMenu = new Mapper.Mappings.MapFollowUp();

            var report = FollowUpMenu.GetFollowUpDatabaseObject(FollowUpBusinessObject);

            report = this._FollowUpDAL.Create(report, this.LoggedInUser);

            FollowUpBusinessObject = FollowUpMenu.GetFollowUpBusinessObject(report);

            return FollowUpBusinessObject;

        }

        public List<BusinessModel.FollowUp> GetAllFollowUpItems()
        {
            Mapper.Mappings.MapFollowUp FollowUpMenu = new Mapper.Mappings.MapFollowUp();

            var FollowUpItemsDALList = this._FollowUpDAL.GetAll();

            List<BusinessModel.FollowUp> FollowUpItemsBusinessList = new List<BusinessModel.FollowUp>();
            foreach (App.Data.FollowUp FollowUpItem in FollowUpItemsDALList)
            {
                FollowUpItemsBusinessList.Add(FollowUpMenu.GetFollowUpBusinessObject(FollowUpItem));
            }

            return FollowUpItemsBusinessList;
        }

        public List<BusinessModel.FollowUp> GetFollowUpItemsByID(int Id)
        {
            Mapper.Mappings.MapFollowUp FollowUpMenu = new Mapper.Mappings.MapFollowUp();

            var FollowUpItemsDALList = this._FollowUpDAL.GetbyId(Id);

            List<BusinessModel.FollowUp> FollowUpItemsBusinessList = new List<BusinessModel.FollowUp>();
            foreach (App.Data.FollowUp FollowUpItem in FollowUpItemsDALList)
            {
                FollowUpItemsBusinessList.Add(FollowUpMenu.GetFollowUpBusinessObject(FollowUpItem));
            }

            return FollowUpItemsBusinessList;
        }

        public List<BusinessModel.FollowUp> GetFollowUpByName(string term)
        {
            Mapper.Mappings.MapFollowUp FollowUpMenu = new Mapper.Mappings.MapFollowUp();

            var FollowUpItemsDALList = this._FollowUpDAL.GetByName(term);

            List<BusinessModel.FollowUp> FollowUpItemsBusinessList = new List<BusinessModel.FollowUp>();

            foreach (App.Data.FollowUp FollowUpItem in FollowUpItemsDALList)
            {
                FollowUpItemsBusinessList.Add(FollowUpMenu.GetFollowUpBusinessObject(FollowUpItem));
            }

            return FollowUpItemsBusinessList;
        }

        public BusinessModel.FollowUp UpdateFollowUp(BusinessModel.FollowUp FollowUpBusinessObject)
        {
            Mapper.Mappings.MapFollowUp mapFollowUp = new Mapper.Mappings.MapFollowUp();

            var FollowUp = mapFollowUp.GetFollowUpDatabaseObject(FollowUpBusinessObject);

            FollowUp = this._FollowUpDAL.Update(FollowUp, this.LoggedInUser);

            FollowUpBusinessObject = mapFollowUp.GetFollowUpBusinessObject(FollowUp);

            return FollowUpBusinessObject;

        }

        public bool DeleteFollowUp(BusinessModel.FollowUp FollowUpBusinessObject)
        {
            Mapper.Mappings.MapFollowUp mapFollowUp = new Mapper.Mappings.MapFollowUp();

            var FollowUp = mapFollowUp.GetFollowUpDatabaseObject(FollowUpBusinessObject);

            bool status = this._FollowUpDAL.Delete(FollowUp, this.LoggedInUser);

            return status;
        }

    }
}
