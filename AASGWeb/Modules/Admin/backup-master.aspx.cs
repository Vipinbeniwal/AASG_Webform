using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class backup_master : System.Web.UI.Page
    {
        #region
        SqlConnection _sqlConnection, _sqlConnection2 = new SqlConnection();
        SqlCommand _sqlCommand, _sqlCommand3 = new SqlCommand();

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
        }
        protected void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = string.Empty;
                if (!Directory.Exists(Server.MapPath("~/assets/dbfile/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/assets/dbfile/"));
                }
                string _fileName = Server.MapPath("~/assets/dbfile/");

                string _connectionstring = (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                using (SqlConnection _sqlConnection = new SqlConnection(_connectionstring))
                {
                    string _query = "USE aasgweb; BACKUP DATABASE aasgweb TO DISK = " + "'" + _fileName + "Today_DB_Backup.bak" + "'" + " WITH FORMAT,MEDIANAME = 'aasgwebDBBackup',NAME = 'Full Backup of aasgweb'; ";

                    using (SqlCommand _sqlCommand = new SqlCommand(_query, _sqlConnection))
                    {
                        _sqlConnection.Open();

                        _sqlCommand.CommandTimeout = 600;

                        int _outputCount = _sqlCommand.ExecuteNonQuery();

                        if (!Directory.Exists(Server.MapPath("~/assets/dbfile/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/assets/dbfile/"));
                        }

                        Boolean _response = ZipFunction(_fileName);

                        if (_response == true)
                        {
                            //lblMessage.Text = "Backup Created Successfully";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        }
                        else
                        {

                        }

                        _sqlConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                _sqlConnection.Close();
            }
        }

        #region
        /// <summary>
        /// This Method is Used to Create Zip File. a Simple file like(.bak to Zip File)
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="fileextension"></param>
        /// <returns></returns>
        public bool ZipFunction(string filename)
        {
            Boolean _zipUnzipStatus = false;
            string _tempDirectory = filename;
            string _DesdirPathforZip;
            // Directory.CreateDirectory(_tempDirectory);


            string _PreDirectory = string.Empty;
            _PreDirectory = Server.MapPath("~/assets/dbbackup/");
            _DesdirPathforZip = _PreDirectory + "aasgweb" + ".zip";
            if (File.Exists(_DesdirPathforZip))
            {
                File.Delete(_DesdirPathforZip);
            }

            System.IO.Compression.ZipFile.CreateFromDirectory(_tempDirectory, _DesdirPathforZip, CompressionLevel.Fastest, true);

            _zipUnzipStatus = true;


            return _zipUnzipStatus;
        }
        #endregion


    }
}