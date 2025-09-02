using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessCuttingBL
    {
        #region Properties/Variables
        ProcessCuttingDL _ProcessCuttingDAL = new ProcessCuttingDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessCuttingBL()
        {
            // this._ProcessCuttingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessCutting>();
        }

        public ProcessCuttingBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessCuttingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessCutting>();
        }
        #endregion

        public BusinessModel.ProcessCutting CreateProcessCutting(BusinessModel.ProcessCutting ProcessCuttingBusinessObject)
        {
            Mapper.Mappings.MapProcessCutting ProcessCuttingMenu = new Mapper.Mappings.MapProcessCutting();

            var report = ProcessCuttingMenu.GetProcessCuttingDatabaseObject(ProcessCuttingBusinessObject);

            report = this._ProcessCuttingDAL.Create(report, this.LoggedInUser);

            ProcessCuttingBusinessObject = ProcessCuttingMenu.GetProcessCuttingBusinessObject(report);

            return ProcessCuttingBusinessObject;

        }

        public List<BusinessModel.ProcessCutting> GetAllProcessCuttingItems()
        {
            Mapper.Mappings.MapProcessCutting ProcessCuttingMenu = new Mapper.Mappings.MapProcessCutting();

            var ProcessCuttingItemsDALList = this._ProcessCuttingDAL.GetAll();

            List<BusinessModel.ProcessCutting> ProcessCuttingItemsBusinessList = new List<BusinessModel.ProcessCutting>();
            foreach (App.Data.ProcessCutting ProcessCuttingItem in ProcessCuttingItemsDALList)
            {
                ProcessCuttingItemsBusinessList.Add(ProcessCuttingMenu.GetProcessCuttingBusinessObject(ProcessCuttingItem));
            }

            return ProcessCuttingItemsBusinessList;
        }

        public List<BusinessModel.ProcessCutting> GetProcessCuttingItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessCutting ProcessCuttingMenu = new Mapper.Mappings.MapProcessCutting();

            var ProcessCuttingItemsDALList = this._ProcessCuttingDAL.GetbyId(Id);

            List<BusinessModel.ProcessCutting> ProcessCuttingItemsBusinessList = new List<BusinessModel.ProcessCutting>();
            foreach (App.Data.ProcessCutting ProcessCuttingItem in ProcessCuttingItemsDALList)
            {
                ProcessCuttingItemsBusinessList.Add(ProcessCuttingMenu.GetProcessCuttingBusinessObject(ProcessCuttingItem));
            }

            return ProcessCuttingItemsBusinessList;
        }

        public List<BusinessModel.ProcessCutting> GetProcessCuttingByName(string term)
        {
            Mapper.Mappings.MapProcessCutting ProcessCuttingMenu = new Mapper.Mappings.MapProcessCutting();

            var ProcessCuttingItemsDALList = this._ProcessCuttingDAL.GetByName(term);

            List<BusinessModel.ProcessCutting> ProcessCuttingItemsBusinessList = new List<BusinessModel.ProcessCutting>();

            foreach (App.Data.ProcessCutting ProcessCuttingItem in ProcessCuttingItemsDALList)
            {
                ProcessCuttingItemsBusinessList.Add(ProcessCuttingMenu.GetProcessCuttingBusinessObject(ProcessCuttingItem));
            }

            return ProcessCuttingItemsBusinessList;
        }

        public BusinessModel.ProcessCutting UpdateProcessCutting(BusinessModel.ProcessCutting ProcessCuttingBusinessObject)
        {
            Mapper.Mappings.MapProcessCutting mapProcessCutting = new Mapper.Mappings.MapProcessCutting();

            var ProcessCutting = mapProcessCutting.GetProcessCuttingDatabaseObject(ProcessCuttingBusinessObject);

            ProcessCutting = this._ProcessCuttingDAL.Update(ProcessCutting, this.LoggedInUser);

            ProcessCuttingBusinessObject = mapProcessCutting.GetProcessCuttingBusinessObject(ProcessCutting);

            return ProcessCuttingBusinessObject;

        }

        public bool DeleteProcessCutting(BusinessModel.ProcessCutting ProcessCuttingBusinessObject)
        {
            Mapper.Mappings.MapProcessCutting mapProcessCutting = new Mapper.Mappings.MapProcessCutting();

            var ProcessCutting = mapProcessCutting.GetProcessCuttingDatabaseObject(ProcessCuttingBusinessObject);

            bool status = this._ProcessCuttingDAL.Delete(ProcessCutting, this.LoggedInUser);

            return status;
        }

    }
}
