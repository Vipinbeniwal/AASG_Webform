using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data;


namespace App.Business
{
    public class ProcessPaintBL
    {
        #region Properties/Variables
        ProcessPaintDL _ProcessPaintDAL = new ProcessPaintDL();
        private string LoggedInUser = string.Empty;
        #endregion

        #region Constructor

        public ProcessPaintBL()
        {
            // this._ProcessPaintDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessPaint>();
        }

        public ProcessPaintBL(string loggedInUser)
        {
            this.LoggedInUser = loggedInUser;
            //this._ProcessPaintDAL = (new App.Data.Factory()).GetDataAccessObject<App.Data.ProcessPaint>();
        }
        #endregion

        public BusinessModel.ProcessPaint CreateProcessPaint(BusinessModel.ProcessPaint ProcessPaintBusinessObject)
        {
            Mapper.Mappings.MapProcessPaint ProcessPaintMenu = new Mapper.Mappings.MapProcessPaint();

            var report = ProcessPaintMenu.GetProcessPaintDatabaseObject(ProcessPaintBusinessObject);

            report = this._ProcessPaintDAL.Create(report, this.LoggedInUser);

            ProcessPaintBusinessObject = ProcessPaintMenu.GetProcessPaintBusinessObject(report);

            return ProcessPaintBusinessObject;

        }

        public List<BusinessModel.ProcessPaint> GetAllProcessPaintItems()
        {
            Mapper.Mappings.MapProcessPaint ProcessPaintMenu = new Mapper.Mappings.MapProcessPaint();

            var ProcessPaintItemsDALList = this._ProcessPaintDAL.GetAll();

            List<BusinessModel.ProcessPaint> ProcessPaintItemsBusinessList = new List<BusinessModel.ProcessPaint>();
            foreach (App.Data.ProcessPaint ProcessPaintItem in ProcessPaintItemsDALList)
            {
                ProcessPaintItemsBusinessList.Add(ProcessPaintMenu.GetProcessPaintBusinessObject(ProcessPaintItem));
            }

            return ProcessPaintItemsBusinessList;
        }

        public List<BusinessModel.ProcessPaint> GetProcessPaintItemsByID(int Id)
        {
            Mapper.Mappings.MapProcessPaint ProcessPaintMenu = new Mapper.Mappings.MapProcessPaint();

            var ProcessPaintItemsDALList = this._ProcessPaintDAL.GetbyId(Id);

            List<BusinessModel.ProcessPaint> ProcessPaintItemsBusinessList = new List<BusinessModel.ProcessPaint>();
            foreach (App.Data.ProcessPaint ProcessPaintItem in ProcessPaintItemsDALList)
            {
                ProcessPaintItemsBusinessList.Add(ProcessPaintMenu.GetProcessPaintBusinessObject(ProcessPaintItem));
            }

            return ProcessPaintItemsBusinessList;
        }

        public List<BusinessModel.ProcessPaint> GetProcessPaintByName(string term)
        {
            Mapper.Mappings.MapProcessPaint ProcessPaintMenu = new Mapper.Mappings.MapProcessPaint();

            var ProcessPaintItemsDALList = this._ProcessPaintDAL.GetByName(term);

            List<BusinessModel.ProcessPaint> ProcessPaintItemsBusinessList = new List<BusinessModel.ProcessPaint>();

            foreach (App.Data.ProcessPaint ProcessPaintItem in ProcessPaintItemsDALList)
            {
                ProcessPaintItemsBusinessList.Add(ProcessPaintMenu.GetProcessPaintBusinessObject(ProcessPaintItem));
            }

            return ProcessPaintItemsBusinessList;
        }

        public BusinessModel.ProcessPaint UpdateProcessPaint(BusinessModel.ProcessPaint ProcessPaintBusinessObject)
        {
            Mapper.Mappings.MapProcessPaint mapProcessPaint = new Mapper.Mappings.MapProcessPaint();

            var ProcessPaint = mapProcessPaint.GetProcessPaintDatabaseObject(ProcessPaintBusinessObject);

            ProcessPaint = this._ProcessPaintDAL.Update(ProcessPaint, this.LoggedInUser);

            ProcessPaintBusinessObject = mapProcessPaint.GetProcessPaintBusinessObject(ProcessPaint);

            return ProcessPaintBusinessObject;

        }

        public bool DeleteProcessPaint(BusinessModel.ProcessPaint ProcessPaintBusinessObject)
        {
            Mapper.Mappings.MapProcessPaint mapProcessPaint = new Mapper.Mappings.MapProcessPaint();

            var ProcessPaint = mapProcessPaint.GetProcessPaintDatabaseObject(ProcessPaintBusinessObject);

            bool status = this._ProcessPaintDAL.Delete(ProcessPaint, this.LoggedInUser);

            return status;
        }

    }
}
