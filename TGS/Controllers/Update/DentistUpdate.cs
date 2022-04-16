using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Update {
    public class DentistUpdate {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool Dentist(string id, string cro, string name, string lastName, string expertise, bool testing = false) {
            if (validateController.CRO(cro) && validateController.Text(name) && validateController.Text(lastName) && validateController.Text(expertise)) {
                try {
                    query.Connection = dbConn.Connect();

                    query.CommandText = $"UPDATE TB_DENTISTS SET CRO_DENTIST = '{cro}', NAME_DENTIST = '{validateController.ToTitleCase(name)}', LAST_NAME = '{validateController.ToTitleCase(lastName)}', EXPERTISE = '{validateController.ToTitleCase(expertise)}' WHERE CRO_DENTIST = '{id}';";
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