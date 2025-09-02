<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="service.aspx.cs" Inherits="AASGWeb.WebService.service" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <script src="/Content/js/vendor/jquery.min.js"></script>
        <script type="text/javascript">
           // alert('good')
            $(document).ready(function () {
                <%--$("#<%=btnLogin.ClientID %>").click(function () {
                    alert('god')
                });--%>
                $("[id*=btnLogin]").click(function () {
                    if ($("[id*=txtUserName]").val() == '') {
                        alert('Please Enter User Name')
                    }
                    else if ($("[id*=txtPassword]").val() == '') {
                        alert('Please Enter Password')
                    }
                    else {
                        alert('god')
                        debugger
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "service.aspx/AuthenticateUser",
                            // data: JSON.stringify({ "UserName": "" + $("[id*=txtUserName]").val() + "" }, { "UserName": "" + $("[id*=txtUserName]").val() + "" }),
                            data: "{'UserName':'" + $("[id*=txtUserName]").val() + "','Password':'" + $("[id*=txtPassword]").val() + "'}",
                            dataType: "json",
                            success: function (data) {
                                if (data.d == '') {
                                    alert('sorry no record found')
                                }
                                else
                                {
                                    alert(data.d)
                                }
                            }
                        });
                    }
                });


              


            //var ClientsmasterDetail;
            //$("#ContentPlaceHolder1_txtClientMaster").autocomplete({
            //    source: function (request, response) {
            //    $.ajax({
            //        type: "POST",
            //        contentType: "application/json; charset=utf-8",
            //        url: "/UI/Reports/AddReport.aspx/GetClientName",
            //        data: JSON.stringify({ "Name": "" + $("#ContentPlaceHolder1_txtClientMaster").val() + "" }),
            //        dataType: "json",
            //        success: function (data) {
            //            var ParsedObject = $.parseJSON(data.d);
            //            response($.map(ParsedObject, function (item) {
            //                return {
            //                    label: item.CompanyName,
            //                    value: item.CompanyName,
            //                    ClientsmasterDetail: item.UserLoginId + '' + item.CompanyName + '' + item.Id,
            //                };
            //            }))
            //        },
            //        error: function (result) {
            //            $("#ContentPlaceHolder1_txtClientMaster").css('border-color', 'red');
            //        }
            //    });
            //},
            //    minLength: 3,
            //    select: function (event, ui) {
            //        var str = ui.item.ClientsmasterDetail;

            //        var arrayclient = str.split("_");
            //        var ClientUserId = arrayclient[0];
            //        var ClientId = arrayclient[2];
            //        $("#ContentPlaceHolder1_hdnClientUserId").val(ClientUserId);
            //        $("#ContentPlaceHolder1_hdnClientId").val(ClientId);
            //        $("#ContentPlaceHolder1_txtClientMaster").css('border-color', 'green');
            //    }
            //});

        });

    </script>
    
    <style>
body {font-family: Arial, Helvetica, sans-serif;}
form {border: 3px solid #f1f1f1;}

input[type=text], #txtPassword {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

#btnLogin {
  background-color: #04AA6D;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
}

#btnLogin:hover {
  opacity: 0.8;
}

.cancelbtn {
  width: auto;
  padding: 10px 18px;
  background-color: #f44336;
}

.imgcontainer {
  text-align: center;
  margin: 24px 0 12px 0;
}

img.avatar {
  width: 40%;
  border-radius: 50%;
}

.container {
  padding: 16px;
}

span.psw {
  float: right;
  padding-top: 16px;
}

/* Change styles for span and cancel button on extra small screens */
@media screen and (max-width: 300px) {
  span.psw {
     display: block;
     float: none;
  }
  .cancelbtn {
     width: 100%;
  }
}
</style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="imgcontainer">
        <img src="img_avatar2.png" alt="Avatar" class="avatar"/>
        </div>

       <div class="container" >
            <div class="container">
            <input type ="text" id="txtUserName"  />
            <br />
            <input type ="password" id="txtPassword"  />
            <br />
         
            <input type="button" id="btnLogin" class="btn btn-success"  value="Login"/>
                </div>
         <%--   <button type="button" id="btnLogin" runat="server">Login</button>--%>
        </div> 
         <div class="container" style="background-color:#f1f1f1">
    <button type="button" class="cancelbtn">Cancel</button>
    <span class="psw">Forgot <a href="#">password?</a></span>
  </div>
    </form>
</body>
</html>
