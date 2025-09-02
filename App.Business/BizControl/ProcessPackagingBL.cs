using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessPackagingBL
    {
        #region Properties/Variables
        ProcessPackagingDL _ProcessPackagingDAL = new ProcessPackagingDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessPackagingBL()
        {
            // this._ProcessPackagingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessPackaging>();
        }

        public ProcessPackagingBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessPackagingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessPackaging>();
        }
        #endregion

        public BusinessModel.ProcessPackaging CreateProcessPackaging(BusinessModel.ProcessPackaging ProcessPackagingBusinessObject)
        {
            Mapper.Mappings.MapProcessPackaging ProcessPackagingMenu = new Mapper.Mappings.MapProcessPackaging();

            var report = ProcessPackagingMenu.GetProcessPackagingDatabaseObject(ProcessPackagingBusinessObject);

            report = this._ProcessPackagingDAL.Create(report, this.LoggedInUser);

            ProcessPackagingBusinessObject = ProcessPackagingMenu.GetProcessPackagingBusinessObject(report);

            return ProcessPackagingBusinessObject;

        }

        public List<BusinessModel.ProcessPackaging> GetAllProcessPackagingItems()
        {
            Mapper.Mappings.MapProcessPackaging ProcessPackagingMenu = new Mapper.Mappings.MapProcessPackaging();

            var ProcessPackagingItemsDALList = this._ProcessPackagingDAL.GetAll();

            List<BusinessModel.ProcessPackaging> ProcessPackagingItemsBusinessList = new List<BusinessModel.ProcessPackaging>();
            foreach (App.Data.ProcessPackaging ProcessPackagingItem in ProcessPackagingItemsDALList)
            {
                ProcessPackagingItemsBusinessList.Add(ProcessPackagingMenu.GetProcessPackagingBusinessObject(ProcessPackagingItem));
            }

            return ProcessPackagingItemsBusinessList;
        }

        public List<BusinessModel.ProcessPackaging> GetProcessPackagingItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessPackaging ProcessPackagingMenu = new Mapper.Mappings.MapProcessPackaging();

            var ProcessPackagingItemsDALList = this._ProcessPackagingDAL.GetbyId(Id);

            List<BusinessModel.ProcessPackaging> ProcessPackagingItemsBusinessList = new List<BusinessModel.ProcessPackaging>();
            foreach (App.Data.ProcessPackaging ProcessPackagingItem in ProcessPackagingItemsDALList)
            {
                ProcessPackagingItemsBusinessList.Add(ProcessPackagingMenu.GetProcessPackagingBusinessObject(ProcessPackagingItem));
            }

            return ProcessPackagingItemsBusinessList;
        }

        public List<BusinessModel.ProcessPackaging> GetProcessPackagingByName(string term)
        {
            Mapper.Mappings.MapProcessPackaging ProcessPackagingMenu = new Mapper.Mappings.MapProcessPackaging();

            var ProcessPackagingItemsDALList = this._ProcessPackagingDAL.GetByName(term);

            List<BusinessModel.ProcessPackaging> ProcessPackagingItemsBusinessList = new List<BusinessModel.ProcessPackaging>();

            foreach (App.Data.ProcessPackaging ProcessPackagingItem in ProcessPackagingItemsDALList)
            {
                ProcessPackagingItemsBusinessList.Add(ProcessPackagingMenu.GetProcessPackagingBusinessObject(ProcessPackagingItem));
            }

            return ProcessPackagingItemsBusinessList;
        }

        public BusinessModel.ProcessPackaging UpdateProcessPackaging(BusinessModel.ProcessPackaging ProcessPackagingBusinessObject)
        {
            Mapper.Mappings.MapProcessPackaging mapProcessPackaging = new Mapper.Mappings.MapProcessPackaging();

            var ProcessPackaging = mapProcessPackaging.GetProcessPackagingDatabaseObject(ProcessPackagingBusinessObject);

            ProcessPackaging = this._ProcessPackagingDAL.Update(ProcessPackaging, this.LoggedInUser);

            ProcessPackagingBusinessObject = mapProcessPackaging.GetProcessPackagingBusinessObject(ProcessPackaging);

            return ProcessPackagingBusinessObject;

        }

        public bool DeleteProcessPackaging(BusinessModel.ProcessPackaging ProcessPackagingBusinessObject)
        {
            Mapper.Mappings.MapProcessPackaging mapProcessPackaging = new Mapper.Mappings.MapProcessPackaging();

            var ProcessPackaging = mapProcessPackaging.GetProcessPackagingDatabaseObject(ProcessPackagingBusinessObject);

            bool status = this._ProcessPackagingDAL.Delete(ProcessPackaging, this.LoggedInUser);

            return status;
        }

    }
}
