using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace App.Helper
{
    public static class Utils
    {
        //#region send Message

        //public static string SendRegisterSMS(string name, string PhoneNumber, string email, string password) 
        //{
        //    try
        //    {
        //        // string baseURL = ConfigurationManager.AppSettings["apiBaseUrl"].ToString();
        //        string senderId = ConfigurationManager.AppSettings["senderIdKey"].ToString();
        //        string message = "Hii " + name + ",\nYour registration is successful.\nPlease check your credential for login\nUsername : " + email + "\nPassword : " + password;
        //        WebClient client = new WebClient();
        //        string requestUrl = ConfigurationManager.AppSettings["smsURL"].ToString() + "Group_id=group_id&authkey=273720Awb3FqwP5cbff930&mobiles=" + PhoneNumber + "&country=91&message=" + message + "&sender=ASTBZR&route=4";
        //        //  string baseurl = baseURL + "user=20088778&pwd=Password!23&senderid=" + senderId + "&mobileno=" + phone + "&msgtext=" + message + "";
        //        Stream data = client.OpenRead(requestUrl);
        //        StreamReader reader = new StreamReader(data);
        //        string result = reader.ReadToEnd();
        //        data.Close();
        //        reader.Close();
        //        return "send msg";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.InnerException.ToString();
        //    }
        //}

        //public static string SendBookedSMS(string name, string PhoneNumber, string time, string date, int tokenNumber)
        //{
        //    try
        //    {
        //        string baseURL = ConfigurationManager.AppSettings["smsURL"].ToString();
        //        string senderId = ConfigurationManager.AppSettings["senderIdKey"].ToString();
        //        string message = "जय श्री कृष्ण " + name + "," + System.Environment.NewLine + "मधुसूदन के ज्योतिषीय संसार में आपका स्वागत है |" + System.Environment.NewLine + "आपकी Appointment book हो चुकी है" + System.Environment.NewLine + "आपका टोकन न. : " + tokenNumber + System.Environment.NewLine + "तिथि : " + String.Format("{0:MMMM d, yyyy}", date) + System.Environment.NewLine + "अनुमानित समय  : " + time;

        //        //  string message = "नमस्ते  " + name + System.Environment.NewLine + ", आपकी Appointment book हो चुकी है |" +System.Environment.NewLine+"तिथि : " + date+ System.Environment.NewLine+ "अनुमानित समय  : " + time + System.Environment.NewLine+ "टोकन न. : " + tokenNumber;
        //        WebClient client = new WebClient();
        //        string requestUrl = baseURL + "Group_id=group_id&authkey=273720Awb3FqwP5cbff930&mobiles=" + PhoneNumber + "&country=91&message=" + message + "&sender=ASTBZR&route=4&unicode=1";
        //        //string baseurl = baseURL + "user=20088778&pwd=Password!23&senderid=" + senderId + "&mobileno=" + phone + "&msgtext=" + message + "";
        //        Stream data = client.OpenRead(requestUrl);
        //        StreamReader reader = new StreamReader(data);
        //        string result = reader.ReadToEnd();
        //        data.Close();
        //        reader.Close();
        //        return "send msg";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.InnerException.ToString();
        //    }
        //}
        //public static string SendUpayeSMS(string name, string PhoneNumber)
        //{
        //    try
        //    {
        //        string baseURL = ConfigurationManager.AppSettings["smsURL"].ToString();
        //        string senderId = ConfigurationManager.AppSettings["senderIdKey"].ToString();
        //        string message = "जय श्री कृष्ण " + name + "," + System.Environment.NewLine + "मधुसूदन के ज्योतिषीय संसार में आपका स्वागत है |" + System.Environment.NewLine + "आपकी सुविधा अनुसार आपके उपाए एवं समाधान भेज दिए गये हैं|";

        //        //  string message = "नमस्ते  " + name + System.Environment.NewLine + ", आपकी Appointment book हो चुकी है |" +System.Environment.NewLine+"तिथि : " + date+ System.Environment.NewLine+ "अनुमानित समय  : " + time + System.Environment.NewLine+ "टोकन न. : " + tokenNumber;
        //        WebClient client = new WebClient();
        //        string requestUrl = baseURL + "Group_id=group_id&authkey=273720Awb3FqwP5cbff930&mobiles=" + PhoneNumber + "&country=91&message=" + message + "&sender=ASTBZR&route=4&unicode=1";
        //        //string baseurl = baseURL + "user=20088778&pwd=Password!23&senderid=" + senderId + "&mobileno=" + phone + "&msgtext=" + message + "";
        //        Stream data = client.OpenRead(requestUrl);
        //        StreamReader reader = new StreamReader(data);
        //        string result = reader.ReadToEnd();
        //        data.Close();
        //        reader.Close();
        //        return "send msg";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.InnerException.ToString();
        //    }
        //}
        //#endregion

        #region generate otp
        public static string GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return Convert.ToString(_rdm.Next(_min, _max));
        }

        public static bool sendSMS(string PhoneNumber, string msg, string DLT_TE_ID)
        {
            WebClient client = new WebClient();

            try
            {

                string requestUrl = ConfigurationManager.AppSettings["smsURL"].ToString() + "Group_id=group_id&authkey=273720Awb3FqwP5cbff930&mobiles=" + PhoneNumber + "&country=91&unicode=1&message=" + msg + "&sender=AASGIN&route=4&DLT_TE_ID=" + DLT_TE_ID;
                Stream data = client.OpenRead(requestUrl);
                StreamReader reader = new StreamReader(data);
                string result = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return false;
            }
        }

        #region Order Status
        public enum OrderStatus { pending, approved, rejected, added,production, progress,hold,complete,transfer };

        #endregion

        #region Production Type
        public enum ProductionType { cutting, grinding, washingone, hole, washing, paint, dfgprint, tempring, transfer, packing, store };
        
        #endregion 



        #endregion

        #region Notification
        public static string SendOneSignalNotification(string playerId, string title, string description, string dataType)
        {
            var requestURL = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            requestURL.KeepAlive = true;
            requestURL.Method = "POST";
            requestURL.ContentType = "application/json; charset=utf-8";
            string imagePath = "";
            // string imagePath = "https://tonnijapi.nijomee.com/assets/welcome.png";

            requestURL.Headers.Add("authorization", "Basic M2UwODFmNGEtNjdjYy00NDhkLTk2N2UtOTBiMWMzMDMyMzM1");
            byte[] byteArrayQuod = null;
            string responseResult = string.Empty;

            if (playerId != null)
            {
                if (!string.IsNullOrEmpty(dataType))
                {
                    byteArrayQuod = Encoding.UTF8.GetBytes("{"
                                                            + "\"app_id\": \"d21f655c-fd51-4921-9cd3-b976a190f05c\","
                                                            //+ "\"android_channel_id\": \"08129a01-2870-4c69-9620-6765ba6e0fe5\","
                                                            + "\"headings\": {\"en\": \"" + title + "\"},"
                                                            + "\"contents\": {\"en\": \"" + description + "\"},"
                                                            + "\"data\":{\"type\": \"" + dataType + "\"},"
                                                            + "\"include_player_ids\": [\"" + playerId + "\"]}");
                }
                else
                {
                    byteArrayQuod = Encoding.UTF8.GetBytes("{"
                                                           + "\"app_id\": \"d21f655c-fd51-4921-9cd3-b976a190f05c\","
                                                           //+ "\"android_channel_id\": \"08129a01-2870-4c69-9620-6765ba6e0fe5\","
                                                           + "\"big_picture\":\"" + imagePath + "\","
                                                           + "\"headings\": {\"en\": \"" + title + "\"},"
                                                           + "\"contents\": {\"en\": \"" + description + "\"},"
                                                           + "\"include_player_ids\": [\"" + playerId + "\"]}");
                }

                string responseContentQod = null;

                try
                {
                    using (var writer = requestURL.GetRequestStream())
                    {
                        writer.Write(byteArrayQuod, 0, byteArrayQuod.Length);
                    }

                    using (var response1 = requestURL.GetResponse() as HttpWebResponse)
                    {
                        using (var reader = new StreamReader(response1.GetResponseStream()))
                        {
                            responseContentQod = reader.ReadToEnd();
                        }
                    }

                    responseResult = "Success";
                }

                catch (Exception ex)
                {
                    responseResult = ex.InnerException.ToString();
                }
            }
            return responseResult;
        }

        #endregion

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_' || c == '-')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static bool IsValidExtension(string fileUploadFile)
        {
            bool flag = false;
            if (fileUploadFile == ".jpg" || fileUploadFile == ".jpeg" || fileUploadFile == ".png")
            {
                flag = true;
            }
            return flag;
        }

        //public static bool IsValidExtension(string fileUploadFile)
        //{
        //    bool flag = false;
        //    if (fileUploadFile == ".png")
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}

    }
}
