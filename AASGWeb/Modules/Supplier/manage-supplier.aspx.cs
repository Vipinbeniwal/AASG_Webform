using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Net;
using App.BusinessModel;
using App.Business;

namespace AASGWeb.Modules.Supplier
{
    public partial class manage_supplier : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.SupplierMaster _objSupplierMaster = new App.BusinessModel.SupplierMaster();
        App.Business.SupplierMasterBL _objSupplierMasterBL = null;
        List<App.BusinessModel.SupplierMaster> _lstSupplierMaster = new List<App.BusinessModel.SupplierMaster>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSuppliersGrid();
            }
        }
        private void BindSuppliersGrid()
        {
            try
            {
                _objSupplierMasterBL = new SupplierMasterBL();
                _lstSupplierMaster = _objSupplierMasterBL.GetAllSupplierMasterItems().OrderByDescending(x => x.created_on).ToList();

                rptrManageSupplier.DataSource = _lstSupplierMaster;
                rptrManageSupplier.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrManageSupplier_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrManageSupplier_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}