using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Production
{
    public partial class add_packaging : System.Web.UI.Page
    {
        #region Global Variables
        SqlConnection _sqlConnection = new SqlConnection();
        SqlCommand _sqlCommand = new SqlCommand();
        SqlDataAdapter _sqlDataAdapter = null;
        DataTable _datatable = null;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getProductionItemBreakageRejectOkDetails();
            }
            else
            {
            }
        }

        private void getProductionItemBreakageRejectOkDetails()
        {
            try
            {
                using (_sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {

                    _sqlConnection.Open();
                    _sqlCommand = new SqlCommand("sp_GetProductionItemBreakageRejectOkCountDetails", _sqlConnection);
                    _sqlCommand.CommandType = CommandType.StoredProcedure;
                    //_sqlCommand.Parameters.AddWithValue("@SaleHeaderId", SaleHeaderIds);
                    _sqlCommand.CommandTimeout = 600;
                    _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                    _datatable = new DataTable();
                    _sqlDataAdapter.Fill(_datatable);

                    if (_datatable != null)
                    {
                        if (_datatable.Rows.Count > 0)
                        {

                            rptrProductionItemBreakageOkRejectDetail.DataSource = _datatable;
                            rptrProductionItemBreakageOkRejectDetail.DataBind();
                        }
                        else
                        {

                        }
                    }
                    _sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                _sqlConnection.Close();
            }
        }

        protected void rptrProductionItemBreakageOkRejectDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrProductionItemBreakageOkRejectDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}