using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Xp_Master
{
    public partial class add_xp_item : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.xp_ItemMaster _objxp_ItemMaster = new App.BusinessModel.xp_ItemMaster();
        App.Business.xp_ItemMasterBL _objxp_ItemMasterBL = null;
        List<App.BusinessModel.xp_ItemMaster> _lstxp_ItemMaster = new List<App.BusinessModel.xp_ItemMaster>();

        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string _xpitemid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string xp_item_master_id = RouteData.Values["id"].ToString();
                    _xpitemid = App.Core.DataSecurity.Decryptdata(xp_item_master_id);
                    if (_xpitemid == "" || _xpitemid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {

                        hdnXPItemId.Value = _xpitemid;

                        if (hdnXPItemId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_xpitemid);
                        }

                    }


                }
            }
        }

        private void PopulateData(string _xpItemid)
        {
            try
            {
                Int32 xpITEMID = Convert.ToInt32(_xpItemid);

                _objxp_ItemMasterBL = new xp_ItemMasterBL();
                _objxp_ItemMaster = _objxp_ItemMasterBL.Getxp_ItemMasterItemsByID(Convert.ToInt32(xpITEMID)).FirstOrDefault();
                if (_objxp_ItemMaster.xp_item_master_id > 0)
                {
                    btnAddItem.Visible = false;
                    btnUpdateItem.Visible = true;
                 
                    txtBrand.Text = _objxp_ItemMaster.item_brand;
                    txtItemName.Text = _objxp_ItemMaster.item_name;
                    txtSerialNumber.Text = _objxp_ItemMaster.item_serial_number;
                    txtItemSpecification.Text = _objxp_ItemMaster.item_specification;
                    txtItemQuantity.Text = Convert.ToInt32(_objxp_ItemMaster.item_quantity).ToString();
                    txtItemPrice.Text = Convert.ToDecimal(_objxp_ItemMaster.item_price).ToString();

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Clearxp_ItemMasterForm();
        }

        private void Clearxp_ItemMasterForm()
        {

            btnAddItem.Visible = true;
          

            txtBrand.Text =txtSerialNumber.Text=txtItemName.Text=txtItemSpecification.Text = string.Empty;
            txtItemQuantity.Text = "0";
            txtItemPrice.Text = "0.0";
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        _objxp_ItemMasterBL = new xp_ItemMasterBL();

        //        _objxp_ItemMaster = _objxp_ItemMasterBL.GetAllxp_ItemMasterItems().Where(x => x.xp_item_master_id == Convert.ToInt32(hdnXPItemId.Value)).FirstOrDefault();
        //        if (_objxp_ItemMaster.xp_item_master_id != 0)
        //        {
        //            _objxp_ItemMaster = _objxp_ItemMasterBL.Updatexp_ItemMaster(Getxp_ItemMasterObjectForUpdate());

        //            if (_objxp_ItemMaster.xp_item_master_id > 0)
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemUpdate();", true);
        //                Clearxp_ItemMasterForm();
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
        //            }

        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
        //    }
        //}

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            _objxp_ItemMasterBL = new xp_ItemMasterBL();
            try
            {
                _lstxp_ItemMaster = _objxp_ItemMasterBL.GetAllxp_ItemMasterItems().Where(x => x.item_brand.ToLower() == txtBrand.Text.ToLower() && x.item_name.ToLower() == txtItemName.Text.ToLower()).ToList();

                if (_lstxp_ItemMaster.Count == 0)
                {
                    _objxp_ItemMasterBL = new xp_ItemMasterBL();
                    var response = _objxp_ItemMasterBL.Createxp_ItemMaster(Getxp_ItemMasterObject());

                    if (response.xp_item_master_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        Clearxp_ItemMasterForm();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyxp_ItemMaster();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        private App.BusinessModel.xp_ItemMaster Getxp_ItemMasterObject()
        {
            try
            {
                _objxp_ItemMaster.guid = Guid.NewGuid();
                _objxp_ItemMaster.item_brand = txtBrand.Text;
                _objxp_ItemMaster.item_name = txtItemName.Text;
                _objxp_ItemMaster.item_serial_number = txtSerialNumber.Text;
                _objxp_ItemMaster.item_specification = txtItemSpecification.Text;
                _objxp_ItemMaster.item_quantity = Convert.ToInt32(txtItemQuantity.Text);
               _objxp_ItemMaster.item_price= Convert.ToDecimal(txtItemPrice.Text);


                return _objxp_ItemMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objxp_ItemMaster;
        }

        private App.BusinessModel.xp_ItemMaster Getxp_ItemMasterObjectForUpdate()
        {
            try
            {
                _objxp_ItemMaster.guid = _objxp_ItemMaster.guid;
                _objxp_ItemMaster.xp_item_master_id = Convert.ToInt32(hdnXPItemId.Value);
                _objxp_ItemMaster.item_brand = txtBrand.Text;
                _objxp_ItemMaster.item_name = txtItemName.Text;
                _objxp_ItemMaster.item_serial_number = txtSerialNumber.Text;
                _objxp_ItemMaster.item_specification = txtItemSpecification.Text;
                _objxp_ItemMaster.item_quantity = Convert.ToInt32(txtItemQuantity.Text);
                _objxp_ItemMaster.item_price = Convert.ToDecimal(txtItemPrice.Text);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objxp_ItemMaster;
        }

        protected void btnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                _objxp_ItemMasterBL = new xp_ItemMasterBL();

                _objxp_ItemMaster = _objxp_ItemMasterBL.GetAllxp_ItemMasterItems().Where(x => x.xp_item_master_id == Convert.ToInt32(hdnXPItemId.Value)).FirstOrDefault();
                if (_objxp_ItemMaster.xp_item_master_id != 0)
                {
                    _objxp_ItemMaster = _objxp_ItemMasterBL.Updatexp_ItemMaster(Getxp_ItemMasterObjectForUpdate());

                    if (_objxp_ItemMaster.xp_item_master_id > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemUpdate();", true);
                        Clearxp_ItemMasterForm();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
    }
}