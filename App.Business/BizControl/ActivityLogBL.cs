using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ActivityLogBL
    {
        #region Properties/Variables
        ActivityLogDL _ActivityLogDAL = new ActivityLogDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ActivityLogBL()
        {
            // this._ActivityLogDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ActivityLog>();
        }

        public ActivityLogBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ActivityLogDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ActivityLog>();
        }
        #endregion

        public BusinessModel.ActivityLog CreateActivityLog(BusinessModel.ActivityLog ActivityLogBusinessObject)
        {
            Mapper.Mappings.MapActivityLog ActivityLogMenu = new Mapper.Mappings.MapActivityLog();

            var report = ActivityLogMenu.GetActivityLogDatabaseObject(ActivityLogBusinessObject);

            report = this._ActivityLogDAL.Create(report, this.LoggedInUser);

            ActivityLogBusinessObject = ActivityLogMenu.GetActivityLogBusinessObject(report);

            return ActivityLogBusinessObject;

        }

        public List<BusinessModel.ActivityLog> GetAllActivityLogItems()
        {
            Mapper.Mappings.MapActivityLog ActivityLogMenu = new Mapper.Mappings.MapActivityLog();

            var ActivityLogItemsDALList = this._ActivityLogDAL.GetAll();

            List<BusinessModel.ActivityLog> ActivityLogItemsBusinessList = new List<BusinessModel.ActivityLog>();
            foreach (App.Data.ActivityLog ActivityLogItem in ActivityLogItemsDALList)
            {
                ActivityLogItemsBusinessList.Add(ActivityLogMenu.GetActivityLogBusinessObject(ActivityLogItem));
            }

            return ActivityLogItemsBusinessList;
        }

        public List<BusinessModel.ActivityLog> GetActivityLogItemsByID(int Id)
        {
            Mapper.Mappings.MapActivityLog ActivityLogMenu = new Mapper.Mappings.MapActivityLog();

            var ActivityLogItemsDALList = this._ActivityLogDAL.GetbyId(Id);

            List<BusinessModel.ActivityLog> ActivityLogItemsBusinessList = new List<BusinessModel.ActivityLog>();
            foreach (App.Data.ActivityLog ActivityLogItem in ActivityLogItemsDALList)
            {
                ActivityLogItemsBusinessList.Add(ActivityLogMenu.GetActivityLogBusinessObject(ActivityLogItem));
            }

            return ActivityLogItemsBusinessList;
        }

        public List<BusinessModel.ActivityLog> GetActivityLogByName(string term)
        {
            Mapper.Mappings.MapActivityLog ActivityLogMenu = new Mapper.Mappings.MapActivityLog();

            var ActivityLogItemsDALList = this._ActivityLogDAL.GetByName(term);

            List<BusinessModel.ActivityLog> ActivityLogItemsBusinessList = new List<BusinessModel.ActivityLog>();

            foreach (App.Data.ActivityLog ActivityLogItem in ActivityLogItemsDALList)
            {
                ActivityLogItemsBusinessList.Add(ActivityLogMenu.GetActivityLogBusinessObject(ActivityLogItem));
            }

            return ActivityLogItemsBusinessList;
        }

        public BusinessModel.ActivityLog UpdateActivityLog(BusinessModel.ActivityLog ActivityLogBusinessObject)
        {
            Mapper.Mappings.MapActivityLog mapActivityLog = new Mapper.Mappings.MapActivityLog();

            var ActivityLog = mapActivityLog.GetActivityLogDatabaseObject(ActivityLogBusinessObject);

            ActivityLog = this._ActivityLogDAL.Update(ActivityLog, this.LoggedInUser);

            ActivityLogBusinessObject = mapActivityLog.GetActivityLogBusinessObject(ActivityLog);

            return ActivityLogBusinessObject;

        }

        public bool DeleteActivityLog(BusinessModel.ActivityLog ActivityLogBusinessObject)
        {
            Mapper.Mappings.MapActivityLog mapActivityLog = new Mapper.Mappings.MapActivityLog();

            var ActivityLog = mapActivityLog.GetActivityLogDatabaseObject(ActivityLogBusinessObject);

            bool status = this._ActivityLogDAL.Delete(ActivityLog, this.LoggedInUser);

            return status;
        }

    }
}
