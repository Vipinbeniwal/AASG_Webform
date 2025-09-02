using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessGrindingBL
    {
        #region Properties/Variables
        ProcessGrindingDL _ProcessGrindingDAL = new ProcessGrindingDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessGrindingBL()
        {
            // this._ProcessGrindingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessGrinding>();
        }

        public ProcessGrindingBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessGrindingDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessGrinding>();
        }
        #endregion

        public BusinessModel.ProcessGrinding CreateProcessGrinding(BusinessModel.ProcessGrinding ProcessGrindingBusinessObject)
        {
            Mapper.Mappings.MapProcessGrinding ProcessGrindingMenu = new Mapper.Mappings.MapProcessGrinding();

            var report = ProcessGrindingMenu.GetProcessGrindingDatabaseObject(ProcessGrindingBusinessObject);

            report = this._ProcessGrindingDAL.Create(report, this.LoggedInUser);

            ProcessGrindingBusinessObject = ProcessGrindingMenu.GetProcessGrindingBusinessObject(report);

            return ProcessGrindingBusinessObject;

        }

        public List<BusinessModel.ProcessGrinding> GetAllProcessGrindingItems()
        {
            Mapper.Mappings.MapProcessGrinding ProcessGrindingMenu = new Mapper.Mappings.MapProcessGrinding();

            var ProcessGrindingItemsDALList = this._ProcessGrindingDAL.GetAll();

            List<BusinessModel.ProcessGrinding> ProcessGrindingItemsBusinessList = new List<BusinessModel.ProcessGrinding>();
            foreach (App.Data.ProcessGrinding ProcessGrindingItem in ProcessGrindingItemsDALList)
            {
                ProcessGrindingItemsBusinessList.Add(ProcessGrindingMenu.GetProcessGrindingBusinessObject(ProcessGrindingItem));
            }

            return ProcessGrindingItemsBusinessList;
        }

        public List<BusinessModel.ProcessGrinding> GetProcessGrindingItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessGrinding ProcessGrindingMenu = new Mapper.Mappings.MapProcessGrinding();

            var ProcessGrindingItemsDALList = this._ProcessGrindingDAL.GetbyId(Id);

            List<BusinessModel.ProcessGrinding> ProcessGrindingItemsBusinessList = new List<BusinessModel.ProcessGrinding>();
            foreach (App.Data.ProcessGrinding ProcessGrindingItem in ProcessGrindingItemsDALList)
            {
                ProcessGrindingItemsBusinessList.Add(ProcessGrindingMenu.GetProcessGrindingBusinessObject(ProcessGrindingItem));
            }

            return ProcessGrindingItemsBusinessList;
        }

        public List<BusinessModel.ProcessGrinding> GetProcessGrindingByName(string term)
        {
            Mapper.Mappings.MapProcessGrinding ProcessGrindingMenu = new Mapper.Mappings.MapProcessGrinding();

            var ProcessGrindingItemsDALList = this._ProcessGrindingDAL.GetByName(term);

            List<BusinessModel.ProcessGrinding> ProcessGrindingItemsBusinessList = new List<BusinessModel.ProcessGrinding>();

            foreach (App.Data.ProcessGrinding ProcessGrindingItem in ProcessGrindingItemsDALList)
            {
                ProcessGrindingItemsBusinessList.Add(ProcessGrindingMenu.GetProcessGrindingBusinessObject(ProcessGrindingItem));
            }

            return ProcessGrindingItemsBusinessList;
        }

        public BusinessModel.ProcessGrinding UpdateProcessGrinding(BusinessModel.ProcessGrinding ProcessGrindingBusinessObject)
        {
            Mapper.Mappings.MapProcessGrinding mapProcessGrinding = new Mapper.Mappings.MapProcessGrinding();

            var ProcessGrinding = mapProcessGrinding.GetProcessGrindingDatabaseObject(ProcessGrindingBusinessObject);

            ProcessGrinding = this._ProcessGrindingDAL.Update(ProcessGrinding, this.LoggedInUser);

            ProcessGrindingBusinessObject = mapProcessGrinding.GetProcessGrindingBusinessObject(ProcessGrinding);

            return ProcessGrindingBusinessObject;

        }

        public bool DeleteProcessGrinding(BusinessModel.ProcessGrinding ProcessGrindingBusinessObject)
        {
            Mapper.Mappings.MapProcessGrinding mapProcessGrinding = new Mapper.Mappings.MapProcessGrinding();

            var ProcessGrinding = mapProcessGrinding.GetProcessGrindingDatabaseObject(ProcessGrindingBusinessObject);

            bool status = this._ProcessGrindingDAL.Delete(ProcessGrinding, this.LoggedInUser);

            return status;
        }

    }
}
