using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Update {
    public class ProcedureUpdate {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool Procedure(int id, string title, bool testing = false) {
            if (validateController.Text(title)) {
                try {
                    query.Connection = dbConn.Connect();

                    query.CommandText = $"UPDATE TB_PROCEDURES SET PROCEDURE_TITLE = '{validateController.ToTitleCase(title)}' WHERE ID_PROCEDURE = {id};";
                    query.ExecuteNonQuery();

                    dbConn.Disconnect();

                    if (!testing)
                        statusController.Updated();
                    return true;
                } catch (SqlException e) {
                    dbConn.Disconnect();
                    if (!testing) statusController.NonUpdated();
                    return false;
                }
            } else {
                dbConn.Disconnect();
                statusController.NonUpdated();
                return false;
            }
        }
    }
}