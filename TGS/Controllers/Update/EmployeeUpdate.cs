using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Update {
    public class EmployeeUpdate {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool Employee(string id, string cpf, string name, string lastName, string email, string telephone, string cellphone, bool testing = false) {
            if(telephone == "(  )    -") {
                telephone = null;
            }

            if (validateController.CPF(cpf) && validateController.Text(name) && validateController.Text(lastName) && validateController.Email(email) && (telephone == null || validateController.Telephone(telephone)) && validateController.Cellphone(cellphone)) {
                try {
                    query.Connection = dbConn.Connect();

                    query.CommandText = $"UPDATE TB_EMPLOYEES SET CPF_EMPLOYEE = '{cpf}', NAME_EMPLOYEE = '{validateController.ToTitleCase(name)}', LAST_NAME = '{validateController.ToTitleCase(lastName)}', EMAIL = '{email}', TELEPHONE = '{telephone}', CELLPHONE = '{cellphone}' WHERE CPF_EMPLOYEE = '{id}';";
                    query.ExecuteNonQuery();

                    dbConn.Disconnect();

                    if(!testing) statusController.Updated();
                    return true;
                } catch (SqlException e) {
                    dbConn.Disconnect();
                    if (!testing) statusController.NonUpdated();
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