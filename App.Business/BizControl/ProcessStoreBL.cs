using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessStoreBL
    {
        #region Properties/Variables
        ProcessStoreDL _ProcessStoreDAL = new ProcessStoreDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessStoreBL()
        {
            // this._ProcessStoreDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessStore>();
        }

        public ProcessStoreBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessStoreDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessStore>();
        }
        #endregion

        public BusinessModel.ProcessStore CreateProcessStore(BusinessModel.ProcessStore ProcessStoreBusinessObject)
        {
            Mapper.Mappings.MapProcessStore ProcessStoreMenu = new Mapper.Mappings.MapProcessStore();

            var report = ProcessStoreMenu.GetProcessStoreDatabaseObject(ProcessStoreBusinessObject);

            report = this._ProcessStoreDAL.Create(report, this.LoggedInUser);

            ProcessStoreBusinessObject = ProcessStoreMenu.GetProcessStoreBusinessObject(report);

            return ProcessStoreBusinessObject;

        }

        public List<BusinessModel.ProcessStore> GetAllProcessStoreItems()
        {
            Mapper.Mappings.MapProcessStore ProcessStoreMenu = new Mapper.Mappings.MapProcessStore();

            var ProcessStoreItemsDALList = this._ProcessStoreDAL.GetAll();

            List<BusinessModel.ProcessStore> ProcessStoreItemsBusinessList = new List<BusinessModel.ProcessStore>();
            foreach (App.Data.ProcessStore ProcessStoreItem in ProcessStoreItemsDALList)
            {
                ProcessStoreItemsBusinessList.Add(ProcessStoreMenu.GetProcessStoreBusinessObject(ProcessStoreItem));
            }

            return ProcessStoreItemsBusinessList;
        }

        public List<BusinessModel.ProcessStore> GetProcessStoreItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessStore ProcessStoreMenu = new Mapper.Mappings.MapProcessStore();

            var ProcessStoreItemsDALList = this._ProcessStoreDAL.GetbyId(Id);

            List<BusinessModel.ProcessStore> ProcessStoreItemsBusinessList = new List<BusinessModel.ProcessStore>();
            foreach (App.Data.ProcessStore ProcessStoreItem in ProcessStoreItemsDALList)
            {
                ProcessStoreItemsBusinessList.Add(ProcessStoreMenu.GetProcessStoreBusinessObject(ProcessStoreItem));
            }

            return ProcessStoreItemsBusinessList;
        }

        public List<BusinessModel.ProcessStore> GetProcessStoreByName(string term)
        {
            Mapper.Mappings.MapProcessStore ProcessStoreMenu = new Mapper.Mappings.MapProcessStore();

            var ProcessStoreItemsDALList = this._ProcessStoreDAL.GetByName(term);

            List<BusinessModel.ProcessStore> ProcessStoreItemsBusinessList = new List<BusinessModel.ProcessStore>();

            foreach (App.Data.ProcessStore ProcessStoreItem in ProcessStoreItemsDALList)
            {
                ProcessStoreItemsBusinessList.Add(ProcessStoreMenu.GetProcessStoreBusinessObject(ProcessStoreItem));
            }

            return ProcessStoreItemsBusinessList;
        }

        public BusinessModel.ProcessStore UpdateProcessStore(BusinessModel.ProcessStore ProcessStoreBusinessObject)
        {
            Mapper.Mappings.MapProcessStore mapProcessStore = new Mapper.Mappings.MapProcessStore();

            var ProcessStore = mapProcessStore.GetProcessStoreDatabaseObject(ProcessStoreBusinessObject);

            ProcessStore = this._ProcessStoreDAL.Update(ProcessStore, this.LoggedInUser);

            ProcessStoreBusinessObject = mapProcessStore.GetProcessStoreBusinessObject(ProcessStore);

            return ProcessStoreBusinessObject;

        }

        public bool DeleteProcessStore(BusinessModel.ProcessStore ProcessStoreBusinessObject)
        {
            Mapper.Mappings.MapProcessStore mapProcessStore = new Mapper.Mappings.MapProcessStore();

            var ProcessStore = mapProcessStore.GetProcessStoreDatabaseObject(ProcessStoreBusinessObject);

            bool status = this._ProcessStoreDAL.Delete(ProcessStore, this.LoggedInUser);

            return status;
        }

    }
}
