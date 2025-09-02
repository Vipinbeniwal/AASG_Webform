using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessWashingBL
    {
        #region Properties/Variables
        ProcessWashingDL _ProcessWashingDAL = new ProcessWashingDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessWashingBL()
        {
            // this._ProcessWashingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessWashing>();
        }

        public ProcessWashingBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessWashingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessWashing>();
        }
        #endregion

        public BusinessModel.ProcessWashing CreateProcessWashing(BusinessModel.ProcessWashing ProcessWashingBusinessObject)
        {
            Mapper.Mappings.MapProcessWashing ProcessWashingMenu = new Mapper.Mappings.MapProcessWashing();

            var report = ProcessWashingMenu.GetProcessWashingDatabaseObject(ProcessWashingBusinessObject);

            report = this._ProcessWashingDAL.Create(report, this.LoggedInUser);

            ProcessWashingBusinessObject = ProcessWashingMenu.GetProcessWashingBusinessObject(report);

            return ProcessWashingBusinessObject;

        }

        public List<BusinessModel.ProcessWashing> GetAllProcessWashingItems()
        {
            Mapper.Mappings.MapProcessWashing ProcessWashingMenu = new Mapper.Mappings.MapProcessWashing();

            var ProcessWashingItemsDALList = this._ProcessWashingDAL.GetAll();

            List<BusinessModel.ProcessWashing> ProcessWashingItemsBusinessList = new List<BusinessModel.ProcessWashing>();
            foreach (App.Data.ProcessWashing ProcessWashingItem in ProcessWashingItemsDALList)
            {
                ProcessWashingItemsBusinessList.Add(ProcessWashingMenu.GetProcessWashingBusinessObject(ProcessWashingItem));
            }

            return ProcessWashingItemsBusinessList;
        }

        public List<BusinessModel.ProcessWashing> GetProcessWashingItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessWashing ProcessWashingMenu = new Mapper.Mappings.MapProcessWashing();

            var ProcessWashingItemsDALList = this._ProcessWashingDAL.GetbyId(Id);

            List<BusinessModel.ProcessWashing> ProcessWashingItemsBusinessList = new List<BusinessModel.ProcessWashing>();
            foreach (App.Data.ProcessWashing ProcessWashingItem in ProcessWashingItemsDALList)
            {
                ProcessWashingItemsBusinessList.Add(ProcessWashingMenu.GetProcessWashingBusinessObject(ProcessWashingItem));
            }

            return ProcessWashingItemsBusinessList;
        }

        public List<BusinessModel.ProcessWashing> GetProcessWashingByName(string term)
        {
            Mapper.Mappings.MapProcessWashing ProcessWashingMenu = new Mapper.Mappings.MapProcessWashing();

            var ProcessWashingItemsDALList = this._ProcessWashingDAL.GetByName(term);

            List<BusinessModel.ProcessWashing> ProcessWashingItemsBusinessList = new List<BusinessModel.ProcessWashing>();

            foreach (App.Data.ProcessWashing ProcessWashingItem in ProcessWashingItemsDALList)
            {
                ProcessWashingItemsBusinessList.Add(ProcessWashingMenu.GetProcessWashingBusinessObject(ProcessWashingItem));
            }

            return ProcessWashingItemsBusinessList;
        }

        public BusinessModel.ProcessWashing UpdateProcessWashing(BusinessModel.ProcessWashing ProcessWashingBusinessObject)
        {
            Mapper.Mappings.MapProcessWashing mapProcessWashing = new Mapper.Mappings.MapProcessWashing();

            var ProcessWashing = mapProcessWashing.GetProcessWashingDatabaseObject(ProcessWashingBusinessObject);

            ProcessWashing = this._ProcessWashingDAL.Update(ProcessWashing, this.LoggedInUser);

            ProcessWashingBusinessObject = mapProcessWashing.GetProcessWashingBusinessObject(ProcessWashing);

            return ProcessWashingBusinessObject;

        }

        public bool DeleteProcessWashing(BusinessModel.ProcessWashing ProcessWashingBusinessObject)
        {
            Mapper.Mappings.MapProcessWashing mapProcessWashing = new Mapper.Mappings.MapProcessWashing();

            var ProcessWashing = mapProcessWashing.GetProcessWashingDatabaseObject(ProcessWashingBusinessObject);

            bool status = this._ProcessWashingDAL.Delete(ProcessWashing, this.LoggedInUser);

            return status;
        }

    }
}
