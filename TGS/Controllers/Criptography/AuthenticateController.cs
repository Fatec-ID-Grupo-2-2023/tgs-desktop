using System;
using System.Windows.Forms;
using TGS.Controllers.Main;
using System.Data.SqlClient;
using TGS.Model;

namespace TGS.Controllers.Criptography {
    class AuthenticateController {
        AlterPageController alterPageController = new AlterPageController();
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        MD5Hash md5Hash = new MD5Hash();
        StatusController statusController = new StatusController();

        public void Login(string email, string password, Form form) {
            ValidateController validateController = new ValidateController();

            if (validateController.Email(email)) {                      
                string hashPassword = md5Hash.CreateMD5Hash(password);
                query.Connection = dbConn.Connect();
                query.CommandText = $"SELECT CPF_EMPLOYEE, NAME_EMPLOYEE FROM TB_EMPLOYEES WHERE EMAIL = '{email}' AND PASSWORD_EMPLOYEE = '{hashPassword}';";
                reader = query.ExecuteReader();
                if (reader.Read()) {
                    Session.Name = $"{reader["NAME_EMPLOYEE"]}";
                    Session.CPF = $"{reader["CPF_EMPLOYEE"]}";
                    reader.Close();
                    dbConn.Disconnect();
                    alterPageController.AlterPage(form, "home");
                } else {
                    statusController.LoginFail();
                }
                reader.Close();
                dbConn.Disconnect();
            } else {
                statusController.LoginFail();
            }
        }

        public void Logout(Form form) {
            if (statusController.Exit()) {
                DestroySession();
                alterPageController.AlterPage(form, "login");
            }
        }

        public void DestroySession() {
            Session.Name = "";
            Session.CPF = "";
        }
    }
}
