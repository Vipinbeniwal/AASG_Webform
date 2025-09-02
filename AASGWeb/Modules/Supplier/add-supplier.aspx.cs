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
    public partial class add_supplier : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        App.Business.ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.SupplierMaster _objSupplierMaster = new App.BusinessModel.SupplierMaster();
        App.Business.SupplierMasterBL _objSupplierMasterBL = null;
        List<App.BusinessModel.SupplierMaster> _lstSupplierMaster = new List<App.BusinessModel.SupplierMaster>();


        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ClearGeneralForm()
        {
            txtSupplierName.Text = txtContactPerson.Text = txtMobile.Text = txtEmail.Text = txtGstNumber.Text = txtRegion.Text = txtState.Text = txtCity.Text = txtPinCode.Text = txtShipToAddress.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        protected void btnAddSupplier_Click(object sender, EventArgs e)
        {
            _objSupplierMasterBL = new SupplierMasterBL();
            try
            {
                if(txtSupplierName.Text=="" || txtSupplierName.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
               
                else if (txtMobile.Text == "" || txtMobile.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else if (txtShipToAddress.Text == "" || txtShipToAddress.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else if (txtState.Text == "" || txtState.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else if (txtCity.Text == "" || txtCity.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else if (txtPinCode.Text == "" || txtPinCode.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else if (txtGstNumber.Text == "" || txtGstNumber.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else
                {
                    _lstSupplierMaster = _objSupplierMasterBL.GetAllSupplierMasterItems().Where(x => x.supplier_phoneno == txtMobile.Text).ToList();

                    if (_lstSupplierMaster.Count == 0)
                    {
                        _objSupplierMasterBL = new SupplierMasterBL();
                        var response = _objSupplierMasterBL.CreateSupplierMaster(GetSupplierMasterObject());

                        if (response.supplier_master_id != 0)
                        {
                            ClearGeneralForm();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadySupplierMaster();", true);
                    }
                }

               

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private App.BusinessModel.SupplierMaster GetSupplierMasterObject()
        {
            try
            {
                _objSupplierMaster.guid = Guid.NewGuid();
                _objSupplierMaster.supplier_name =txtSupplierName.Text;
                _objSupplierMaster.supplier_contact_person = txtContactPerson.Text;
                _objSupplierMaster.supplier_phoneno = txtMobile.Text;
                _objSupplierMaster.supplier_email = txtEmail.Text;
                _objSupplierMaster.supplier_gst = txtGstNumber.Text;
                _objSupplierMaster.supplier_address = txtShipToAddress.Text;
                _objSupplierMaster.supplier_state = txtState.Text;
                _objSupplierMaster.supplier_city = txtCity.Text;
                _objSupplierMaster.supplier_pincode = txtPinCode.Text;
                _objSupplierMaster.supplier_region = txtRegion.Text;

                return _objSupplierMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objSupplierMaster;
        }
    }
}