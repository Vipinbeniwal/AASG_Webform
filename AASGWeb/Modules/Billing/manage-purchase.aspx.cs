using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;


namespace AASGWeb.Modules.Billing
{
    public partial class manage_purchase : System.Web.UI.Page
    {
        #region Global Properties

        PurchaseHeader _objPurchaseHeader = new PurchaseHeader();
        PurchaseHeaderBL _objPurchaseHeaderBL = null;
        List<PurchaseHeader> _lstPurchaseHeader = new List<PurchaseHeader>();

        PurchaseItem _objPurchaseItem = new PurchaseItem();
        PurchaseItemBL _objPurchaseItemBL = null;
        List<PurchaseItem> _lstPurchaseItem = new List<PurchaseItem>();

        List<vwPurchaseHeaderSupplierDetail> _lstPurchaseHeaderSupplierDetail = new List<vwPurchaseHeaderSupplierDetail>();

        List<vwPurchaseOrderDashboardData> _lstvwPurchaseOrderDashboardDetail = new List<vwPurchaseOrderDashboardData>();
        vwPurchaseOrderDashboardData _objvwPurchaseOrderDashboardDetail = new vwPurchaseOrderDashboardData();

        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindPurchaseOrderrptr();
                BindPurchaseOrderDashboardDetails();
            }
        }
        #region Pageload method

        private void BindPurchaseOrderrptr()
        {

            DateTime date = DateTime.Now.Date;
            DateTime now = DateTime.Now;
            var _monthStartDate = new DateTime(now.Year, now.Month, 1);
            var _monthEndDate = _monthStartDate.AddMonths(1).AddDays(-1);


            _objPurchaseHeaderBL = new PurchaseHeaderBL();

            _lstPurchaseHeaderSupplierDetail = _objPurchaseHeaderBL.GetAllPurchaseHeaderWithSupplierItems().OrderByDescending(x => x.purchase_header_id).ToList();

            rptrPurchaseOrder.DataSource = _lstPurchaseHeaderSupplierDetail;
            rptrPurchaseOrder.DataBind();
            List<App.BusinessModel.vwPurchaseHeaderSupplierDetail> _lstPurchaseHeaderCount = new List<App.BusinessModel.vwPurchaseHeaderSupplierDetail>();
            
            _lstPurchaseHeaderCount = _lstPurchaseHeaderSupplierDetail.Where(x => x.purchase_item_date == Convert.ToDateTime(date)).ToList();

            _lstPurchaseHeaderSupplierDetail = _lstPurchaseHeaderSupplierDetail.Where(x => (x.purchase_item_date >= Convert.ToDateTime(date) && x.purchase_item_date <= Convert.ToDateTime(date))).ToList();



        }

        /// <summary>
        /// This Method Is Use dto get Purchase Order Count according to Today, Month Wise.
        /// </summary>
        private void BindPurchaseOrderDashboardDetails()
        {
            _objPurchaseHeaderBL = new PurchaseHeaderBL();

            _lstvwPurchaseOrderDashboardDetail = _objPurchaseHeaderBL.GetVwPurchaseOrderDashboardDatas().ToList();

            if (_lstvwPurchaseOrderDashboardDetail != null)
            {
                _objvwPurchaseOrderDashboardDetail = _lstvwPurchaseOrderDashboardDetail.Where(x => x.Attribute == "TodayPurchaseOrder").FirstOrDefault();

                if (_objvwPurchaseOrderDashboardDetail != null)
                {
                    lblTodayPurchaseOrders.Text = _objvwPurchaseOrderDashboardDetail.Value.ToString();
                   
                }

                _objvwPurchaseOrderDashboardDetail = _lstvwPurchaseOrderDashboardDetail.Where(x => x.Attribute == "CurrentMonthPurchaseOrder").FirstOrDefault();

                if (_objvwPurchaseOrderDashboardDetail != null)
                {
                    lblCurrentMonthPurchaseOrders.Text = _objvwPurchaseOrderDashboardDetail.Value.ToString();
                   
                }

                _objvwPurchaseOrderDashboardDetail = _lstvwPurchaseOrderDashboardDetail.Where(x => x.Attribute == "LastMonthPurchaseOrder").FirstOrDefault();

                if (_objvwPurchaseOrderDashboardDetail != null)
                {
                    lblLastMonthPurchaseOrder.Text = _objvwPurchaseOrderDashboardDetail.Value.ToString();
                   
                }

            }
            else
            {

            }
        }


        #endregion

        #region Purchase Order Status Update Method

        private void updateStatus(string purchaseOrderid)
        {
            Int64 id = Convert.ToInt64(purchaseOrderid);
            _objPurchaseHeaderBL = new PurchaseHeaderBL();
            _objPurchaseHeader = _objPurchaseHeaderBL.GetAllPurchaseHeaderItems().Where(x => x.purchase_header_id == id).FirstOrDefault();
            if (_objPurchaseHeader.is_active == true)
            {
                _objPurchaseHeader.is_active = false;
            }
            else
            {
                _objPurchaseHeader.is_active = true;
            }

            _objPurchaseHeader = _objPurchaseHeaderBL.UpdatePurchaseHeader(_objPurchaseHeader);
            if (_objPurchaseHeader != null)
            {
                //string description = "Article  <b>" + _objArticle.title + "</b> status has been updated By " + loginParams.UserName;
                //Logs("Article status Updated", "fa fa-user", "timeline-icon themed-background-fire themed-border-fire", "push-bit text-danger", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                BindPurchaseOrderrptr();
            }
        }

        #endregion


        #region

        private void SendEmail( string ToEmail, string Subject, String Message)
        {
            string _hostAdd, _fromEmail, _password = string.Empty;

            //Reading send Email credential from web.config file fromMail password
            _hostAdd = ConfigurationManager.AppSettings["host"].ToString();
            _fromEmail = ConfigurationManager.AppSettings["fromMail"].ToString();
            _password = ConfigurationManager.AppSettings["password"].ToString();

            //Creating the object of MailMessage

            MailMessage _objMailMessage = new MailMessage();

            _objMailMessage.From = new MailAddress(_fromEmail);
            _objMailMessage.Subject = Subject; //Subject of Email
            _objMailMessage.Body = Message;   // Body or Message of Email
            _objMailMessage.IsBodyHtml = true; 
            _objMailMessage.To.Add(new MailAddress(ToEmail)); //Recivers Email Id

            SmtpClient _smtp = new SmtpClient(); // Creating Object of SmtpClient
            _smtp.Host = _hostAdd;  // host of EmailAddress for example smtp.gmail.com etc

            // network and security related credentials 
            _smtp.EnableSsl = true;
            _smtp.UseDefaultCredentials = false;
            NetworkCredential _networkCredential = new NetworkCredential();
            _networkCredential.UserName = _objMailMessage.From.Address;
            _networkCredential.Password = _password;
            _smtp.Port = 587;
            _smtp.Credentials = _networkCredential;
           
            _smtp.Send(_objMailMessage);




        }

        #endregion

        protected void rptrPurchaseOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdPurchaseItemId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                        updateStatus(id);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "edit":
                    try
                    {

                        string url = "view-purchase-order-bill/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                      //  string url = "view-purchase-order-bill";
                       
                        Response.Redirect(url, false);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "send":
                    try
                    {
                        //string _ToEmail = "deepaksaini307@gmail.com";
                        //string _Subject = "Purchase Order Detail";
                        //string _Message = ConfigurationManager.AppSettings["documentbaseurl"].ToString() + "view-purchase-order-bill/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        //SendEmail(_ToEmail, _Subject, _Message);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrPurchaseOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                  
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }
    }
}