using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessHoleBL
    {
        #region Properties/Variables
        ProcessHoleDL _ProcessHoleDAL = new ProcessHoleDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessHoleBL()
        {
            // this._ProcessHoleDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessHole>();
        }

        public ProcessHoleBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessHoleDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessHole>();
        }
        #endregion

        public BusinessModel.ProcessHole CreateProcessHole(BusinessModel.ProcessHole ProcessHoleBusinessObject)
        {
            Mapper.Mappings.MapProcessHole ProcessHoleMenu = new Mapper.Mappings.MapProcessHole();

            var report = ProcessHoleMenu.GetProcessHoleDatabaseObject(ProcessHoleBusinessObject);

            report = this._ProcessHoleDAL.Create(report, this.LoggedInUser);

            ProcessHoleBusinessObject = ProcessHoleMenu.GetProcessHoleBusinessObject(report);

            return ProcessHoleBusinessObject;

        }

        public List<BusinessModel.ProcessHole> GetAllProcessHoleItems()
        {
            Mapper.Mappings.MapProcessHole ProcessHoleMenu = new Mapper.Mappings.MapProcessHole();

            var ProcessHoleItemsDALList = this._ProcessHoleDAL.GetAll();

            List<BusinessModel.ProcessHole> ProcessHoleItemsBusinessList = new List<BusinessModel.ProcessHole>();
            foreach (App.Data.ProcessHole ProcessHoleItem in ProcessHoleItemsDALList)
            {
                ProcessHoleItemsBusinessList.Add(ProcessHoleMenu.GetProcessHoleBusinessObject(ProcessHoleItem));
            }

            return ProcessHoleItemsBusinessList;
        }

        public List<BusinessModel.ProcessHole> GetProcessHoleItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessHole ProcessHoleMenu = new Mapper.Mappings.MapProcessHole();

            var ProcessHoleItemsDALList = this._ProcessHoleDAL.GetbyId(Id);

            List<BusinessModel.ProcessHole> ProcessHoleItemsBusinessList = new List<BusinessModel.ProcessHole>();
            foreach (App.Data.ProcessHole ProcessHoleItem in ProcessHoleItemsDALList)
            {
                ProcessHoleItemsBusinessList.Add(ProcessHoleMenu.GetProcessHoleBusinessObject(ProcessHoleItem));
            }

            return ProcessHoleItemsBusinessList;
        }

        public List<BusinessModel.ProcessHole> GetProcessHoleByName(string term)
        {
            Mapper.Mappings.MapProcessHole ProcessHoleMenu = new Mapper.Mappings.MapProcessHole();

            var ProcessHoleItemsDALList = this._ProcessHoleDAL.GetByName(term);

            List<BusinessModel.ProcessHole> ProcessHoleItemsBusinessList = new List<BusinessModel.ProcessHole>();

            foreach (App.Data.ProcessHole ProcessHoleItem in ProcessHoleItemsDALList)
            {
                ProcessHoleItemsBusinessList.Add(ProcessHoleMenu.GetProcessHoleBusinessObject(ProcessHoleItem));
            }

            return ProcessHoleItemsBusinessList;
        }

        public BusinessModel.ProcessHole UpdateProcessHole(BusinessModel.ProcessHole ProcessHoleBusinessObject)
        {
            Mapper.Mappings.MapProcessHole mapProcessHole = new Mapper.Mappings.MapProcessHole();

            var ProcessHole = mapProcessHole.GetProcessHoleDatabaseObject(ProcessHoleBusinessObject);

            ProcessHole = this._ProcessHoleDAL.Update(ProcessHole, this.LoggedInUser);

            ProcessHoleBusinessObject = mapProcessHole.GetProcessHoleBusinessObject(ProcessHole);

            return ProcessHoleBusinessObject;

        }

        public bool DeleteProcessHole(BusinessModel.ProcessHole ProcessHoleBusinessObject)
        {
            Mapper.Mappings.MapProcessHole mapProcessHole = new Mapper.Mappings.MapProcessHole();

            var ProcessHole = mapProcessHole.GetProcessHoleDatabaseObject(ProcessHoleBusinessObject);

            bool status = this._ProcessHoleDAL.Delete(ProcessHole, this.LoggedInUser);

            return status;
        }

    }
}
