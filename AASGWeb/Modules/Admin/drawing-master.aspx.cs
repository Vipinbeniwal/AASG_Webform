using App.Business;
using App.BusinessModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class drawing_master : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        UserRole _objUserRole = new UserRole();
        UserRoleBL _objUserRoleBL = null;
        List<UserRole> _lstUserRole = new List<UserRole>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        vwItemListWithModelAndGlassColor _objItemListWithModelAndGlassColor = new vwItemListWithModelAndGlassColor();
        
        List<vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List<vwItemListWithModelAndGlassColor>();
        
        DrawingMaster _objDrawingMaster = new DrawingMaster();
        DrawingMasterBL _objDrawingMasterBL = null;
        List<DrawingMaster> _lstDrawingMaster = new List<DrawingMaster>();

        MenuMaster MenuMasterobj = new MenuMaster();
        MenuMasterBL MenuMasterBLobj = new MenuMasterBL("admin");
        List<MenuMaster> MenuMasterlstobj = new List<MenuMaster>();

        string UserIp = string.Empty;
        public static byte[] bytes;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string _drawingMasterid;
                BindItemsName();
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string _drawing_master_id = RouteData.Values["id"].ToString();
                    _drawingMasterid = App.Core.DataSecurity.Decryptdata(_drawing_master_id);
                    if (_drawingMasterid == "" || _drawingMasterid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdfdrawingMasterId.Value = _drawingMasterid;

                        if (hdfdrawingMasterId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_drawingMasterid);

                        }

                    }


                }
               
            }
        }

        #region  Page Load Method
        #region Get User Role Data

        private void PopulateData(string _drawingMaster_Id)
        {
            try
            {
                Int32 DrawingMasterId = Convert.ToInt32(_drawingMaster_Id);

                _objDrawingMasterBL = new DrawingMasterBL();
                _objDrawingMaster = _objDrawingMasterBL.GetDrawingMasterItemsByID(Convert.ToInt32(DrawingMasterId)).FirstOrDefault();
                if (_objDrawingMaster!=null)
                {
                    if(_objDrawingMaster.drawing_master_id > 0)
                    {
                        btnUpdateItems.Visible = true;
                        btnAddSelectedItems.Visible = false;

                        txtDrawingName.Text = _objDrawingMaster.drawing_name;
                        txtDrawingType.Text = _objDrawingMaster.drawing_type;
                        txtDrawingAlias.Text = _objDrawingMaster.drawing_alias;
                        txtDrawingDescription.Text = _objDrawingMaster.drawing_description;

                        if (_objDrawingMaster.drawing_image != "")
                        {
                            imagePreview.ImageUrl = "";
                            imagePreview.ImageUrl = "/assets/drawing/"+ _objDrawingMaster.drawing_image;
                        }
                        else
                        {
                            imagePreview.ImageUrl = "/Content/img/default-image.jpg";
                        }


                        //  ddlAssignedMenu.SelectedValue = _objUserRole.user_role_id.ToString();
                        //  _objLoanTypeModel = _lstLoanTypeModel.Where(x => x.loan_name.ToLower() == value.ToLower() && x.is_active == true).FirstOrDefault();
                       

                        string SelectedItemMasterId = _objDrawingMaster.selected_item_master_id;
                        _objItemMasterBL = new ItemMasterBL();
                        _lstvwItemListWithModelAndGlassColor = _objItemMasterBL.GetVwItemListWithModelAndGlassColors().OrderBy(x => x.model).ToList();
                        if (!string.IsNullOrEmpty(SelectedItemMasterId))
                        {
                            string lasttm = SelectedItemMasterId.TrimEnd(',');
                            string[] arrOfSelections = lasttm.Split(',');
                            foreach (string value in arrOfSelections)
                            {
                                
                                _objItemListWithModelAndGlassColor = _lstvwItemListWithModelAndGlassColor.Where(x => x.item_master_id == Convert.ToInt32(value)).FirstOrDefault();

                                if(_objItemListWithModelAndGlassColor == null)
                                {

                                }
                                else
                                {  
                                    ddlItemName.Items.Add(new ListItem() { Text = _objItemListWithModelAndGlassColor.modelwithglass, Value = value, Selected = true });
                                }
                                
                               
                            }
                        }

                    }
                    else
                    {

                    }
                   
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

        private void BindItemsName()
        {
            try
            {
                _objItemMasterBL = new ItemMasterBL();
                _lstvwItemListWithModelAndGlassColor = _objItemMasterBL.GetVwItemListWithModelAndGlassColors().OrderBy(x => x.model).ToList();
                ddlItemName.DataSource = _lstvwItemListWithModelAndGlassColor;
                ddlItemName.DataTextField = "modelwithglass";
                ddlItemName.DataValueField = "item_master_id";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        #endregion

        #endregion

        protected void btnAddSelectedItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuUploadedFile.HasFile == true)
                {

                    string filename = Path.GetFileName(fuUploadedFile.PostedFile.FileName);
                    string contentType = fuUploadedFile.PostedFile.ContentType;
                    string fileUploadFile = Path.GetExtension(fuUploadedFile.FileName.ToString());
                    if (fileUploadFile.ToLower() == ".png" || fileUploadFile.ToLower() == ".jpg" || fileUploadFile.ToLower() == ".jpeg")
                    {

                        using (Stream fs = fuUploadedFile.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                if (bytes.Length > 1048576)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingImageSize();", true);
                                   
                                }
                                else
                                {
                                    
                                    if(ddlItemName.SelectedValue != "")
                                    {
                                        _objDrawingMasterBL = new DrawingMasterBL();
                                        _lstDrawingMaster = _objDrawingMasterBL.GetAllDrawingMasterItems().Where(x => x.drawing_name.ToLower() == txtDrawingName.Text.ToLower() && x.drawing_type.ToLower() == txtDrawingType.Text.ToLower()).ToList();

                                        if (_lstDrawingMaster.Count == 0)
                                        {
                                            //_objDrawingMasterBL = new DrawingMasterBL();
                                            string ActionName = "add";
                                            _objDrawingMaster = _objDrawingMasterBL.CreateDrawingMaster(GetDrawingMasterObject(ActionName));

                                            if (_objDrawingMaster.drawing_master_id != 0)
                                            {


                                                string imageName = _objDrawingMaster.guid.ToString();
                                                _objDrawingMaster.drawing_image = imageName;

                                                String path = HttpContext.Current.Server.MapPath("~/assets/drawing/");
                                                //String path = "/assets/drawing/";

                                                String ImgExtension = System.IO.Path.GetExtension(fuUploadedFile.FileName);
                                                string chkfile = path + imageName + ".png";
                                                if (File.Exists(chkfile))
                                                {
                                                    File.Delete(chkfile);
                                                }
                                                else
                                                {
                                                    string imgPath = imageName + ".png";
                                                    string fullpath = Path.Combine(path, imgPath);

                                                    _objDrawingMaster.drawing_image = imgPath;

                                                    File.WriteAllBytes(fullpath, bytes);

                                                    _objDrawingMasterBL = new DrawingMasterBL();

                                                    _objDrawingMaster = _objDrawingMasterBL.UpdateDrawingMaster(_objDrawingMaster);
                                                    if (_objDrawingMaster.drawing_image != "")
                                                    {
                                                        ClearDrawingForm();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingSuccess();", true);



                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                                // ClearGeneralForm();
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingAlready();", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                                    }
                                    

                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingPngJpg();", true);

                    }

                   
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }

                

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearDrawingForm();
        }

        #region Clear control
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearDrawingForm()
        {
            txtDrawingName.Text = txtDrawingType.Text = txtDrawingAlias.Text = txtDrawingDescription.Text =  string.Empty;
            btnUpdateItems.Visible = false;
            imagePreview.ImageUrl = "/Content/img/default-image.jpg";
            BindItemsName();
        }

        #endregion

        private App.BusinessModel.DrawingMaster GetDrawingMasterObject( string _actionName)
        {
            try
            {
                if(_actionName == "add")
                {
                    _objDrawingMaster.guid = Guid.NewGuid();
                }
                else if (_actionName == "update")
                {
                    _objDrawingMaster.guid = _objDrawingMaster.guid;
                }
                else
                {

                }
               
                _objDrawingMaster.drawing_name = txtDrawingName.Text;
                _objDrawingMaster.drawing_type = txtDrawingType.Text;
                _objDrawingMaster.drawing_alias = txtDrawingAlias.Text;
                _objDrawingMaster.drawing_description = txtDrawingDescription.Text;
                _objDrawingMaster.selected_item_master_id = "0";

                if (ddlItemName.Items.Count > 0)
                {
                    string totalitem = null;
                    for (int i = 0; i < ddlItemName.Items.Count; i++)
                    {
                        if (ddlItemName.Items[i].Selected)
                        {
                            string selectedItem = ddlItemName.Items[i].Value + ",";
                            //insert command
                            totalitem = totalitem + selectedItem;
                        }
                    }
                    string lasttm = totalitem.TrimEnd(',');
                    _objDrawingMaster.selected_item_master_id = lasttm;
                }

                //   ddlAssignedMenu.DataTextField = Convert.ToString(_objUserRole.assigned_menu_ids);


                return _objDrawingMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objDrawingMaster;
        }

        #region File convert to base64
        /// <summary>
        /// This Method is User to Convert only a Image Like (.jpg ,.png) to Base64 String
        /// </summary>
        /// <returns>This Return a String Value always</returns>
        public string getimages()
        {
            string base64ImageRepresentation = string.Empty;
            //AppUserProfileModel _appuserprofilemodel = new AppUserProfileModel();
            if (fuUploadedFile.HasFile)
            {
                string filename = Path.GetFileName(fuUploadedFile.PostedFile.FileName);
                string contentType = fuUploadedFile.PostedFile.ContentType;
                string fileUploadFile = Path.GetExtension(fuUploadedFile.FileName.ToString());
                if (fileUploadFile.ToLower() == ".png" || fileUploadFile.ToLower() == ".jpg" || fileUploadFile.ToLower() == ".jpeg")
                {

                    using (Stream fs = fuUploadedFile.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            if (bytes.Length > 1048576)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('image Size should be 1 MB','warning');", true);
                                base64ImageRepresentation = "sizenotmatch";
                            }
                            else
                            {
                                base64ImageRepresentation = Convert.ToBase64String(bytes);

                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('image should be png or jpg','warning');", true);
                    base64ImageRepresentation = "imagepngjpg";
                }
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Please select image ','warning');", true);

            }
            return base64ImageRepresentation;

        }

        #endregion

        protected void btnUpdateItems_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuUploadedFile.HasFile == true)
                {

                    string filename = Path.GetFileName(fuUploadedFile.PostedFile.FileName);
                    string contentType = fuUploadedFile.PostedFile.ContentType;
                    string fileUploadFile = Path.GetExtension(fuUploadedFile.FileName.ToString());
                    if (fileUploadFile.ToLower() == ".png" || fileUploadFile.ToLower() == ".jpg" || fileUploadFile.ToLower() == ".jpeg")
                    {

                        using (Stream fs = fuUploadedFile.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);

                                if (bytes.Length > 1048576)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingImageSize();", true);

                                }
                                else
                                {

                                    if (ddlItemName.SelectedValue != "")
                                    {
                                        _objDrawingMasterBL = new DrawingMasterBL();
                                        _objDrawingMaster = _objDrawingMasterBL.GetDrawingMasterItemsByID(Convert.ToInt32(hdfdrawingMasterId.Value)).FirstOrDefault();

                                        if (_objDrawingMaster.drawing_master_id > 0)
                                        {
                                            //_objDrawingMasterBL = new DrawingMasterBL();
                                            string _ActionName = "update";
                                            _objDrawingMaster = _objDrawingMasterBL.UpdateDrawingMaster(GetDrawingMasterObject(_ActionName));

                                            if (_objDrawingMaster.drawing_master_id != 0)
                                            {


                                                string imageName = _objDrawingMaster.guid.ToString();
                                                _objDrawingMaster.drawing_image = imageName;


                                                String path = HttpContext.Current.Server.MapPath("~/assets/drawing/");

                                                String ImgExtension = System.IO.Path.GetExtension(fuUploadedFile.FileName);
                                                string chkfile = path + imageName + ".png";
                                                if (File.Exists(chkfile))
                                                {
                                                    File.Delete(chkfile);
                                                    string imgPath = imageName + ".png";
                                                    string fullpath = Path.Combine(path, imgPath);

                                                    _objDrawingMaster.drawing_image = imgPath;

                                                    File.WriteAllBytes(fullpath, bytes);

                                                    _objDrawingMasterBL = new DrawingMasterBL();

                                                    _objDrawingMaster = _objDrawingMasterBL.UpdateDrawingMaster(_objDrawingMaster);
                                                    if (_objDrawingMaster.drawing_image != "")
                                                    {
                                                        ClearDrawingForm();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingSuccess();", true);



                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                                else
                                                {
                                                    string imgPath = imageName + ".png";
                                                    string fullpath = Path.Combine(path, imgPath);

                                                    _objDrawingMaster.drawing_image = imgPath;

                                                    File.WriteAllBytes(fullpath, bytes);

                                                    _objDrawingMasterBL = new DrawingMasterBL();

                                                    _objDrawingMaster = _objDrawingMasterBL.UpdateDrawingMaster(_objDrawingMaster);
                                                    if (_objDrawingMaster.drawing_image != "")
                                                    {
                                                        ClearDrawingForm();
                                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingSuccess();", true);



                                                    }
                                                    else
                                                    {

                                                    }
                                                }

                                                // ClearGeneralForm();
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingAlready();", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                                    }


                                }
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDrawingPngJpg();", true);

                    }


                }
                else
                {
                    if (ddlItemName.SelectedValue != "")
                    {
                        _objDrawingMasterBL = new DrawingMasterBL();
                        _objDrawingMaster = _objDrawingMasterBL.GetDrawingMasterItemsByID(Convert.ToInt32(hdfdrawingMasterId.Value)).FirstOrDefault();

                        if (_objDrawingMaster.drawing_master_id > 0)
                        {
                            //_objDrawingMasterBL = new DrawingMasterBL();
                            string _ActionName = "update";
                            _objDrawingMaster = _objDrawingMasterBL.UpdateDrawingMaster(GetDrawingMasterObject(_ActionName));

                            if (_objDrawingMaster.drawing_master_id != 0)
                            {


                                ClearDrawingForm();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showUpdate();", true);


                                // ClearGeneralForm();
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                    }
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