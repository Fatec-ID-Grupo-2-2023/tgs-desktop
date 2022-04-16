using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Register {
    public class DentistsRegistration {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool DentistRegistration(string croDentist, string nameDentist, string lastName, string expertise, bool testing = false) {
            if (validateController.CRO(croDentist) && validateController.Text(nameDentist) && validateController.Text(lastName) && validateController.Text(expertise)) {
                try {
                    query.CommandText = $"INSERT INTO TB_DENTISTS (CRO_DENTIST, NAME_DENTIST, LAST_NAME, EXPERTISE) VALUES ('{croDentist}', '{validateController.ToTitleCase(nameDentist)}', '{validateController.ToTitleCase(lastName)}', '{validateController.ToTitleCase(expertise)}');";
                    query.Connection = dbConn.Connect();
                    query.ExecuteNonQuery();
                    dbConn.Disconnect();
                    if(!testing) statusController.Created();
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
