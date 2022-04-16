using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;
using TGS.Controllers.Criptography;

namespace TGS.Controllers.Register {
    public class EmployeesRegistration {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        MD5Hash md5Hash = new MD5Hash();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool EmployeeRegistration(string cpf, string name, string lastName, string email, string telephone, string cellphone, string password, bool testing = false) {        
            string hashPassword = md5Hash.CreateMD5Hash(password);

            if (telephone == "(  )    -") {
                telephone = null;
            }

            if (validateController.CPF(cpf) && validateController.Email(email) && (telephone == null || validateController.Telephone(telephone)) && validateController.Cellphone(cellphone) && validateController.Text(name) && validateController.Text(lastName)) {
                query.CommandText = $"INSERT INTO TB_EMPLOYEES (CPF_EMPLOYEE, NAME_EMPLOYEE, LAST_NAME, EMAIL, TELEPHONE, CELLPHONE, PASSWORD_EMPLOYEE) VALUES ('{cpf}', '{validateController.ToTitleCase(name)}', '{validateController.ToTitleCase(lastName)}', '{email}', '{telephone}', '{cellphone}', '{hashPassword}');";
                try {
                    query.Connection = dbConn.Connect();
                    query.ExecuteNonQuery();
                    dbConn.Disconnect();

                    if (!testing) statusController.Created();
                    return true;
                } catch (SqlException e) {
                    dbConn.Disconnect();
                    if (!testing) statusController.NonCreated();
                    return false;
                }
            } else {
                dbConn.Disconnect();
                if (!testing) statusController.NotAcceptable();
                return false;
            }
        }
    }
}
