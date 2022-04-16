using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Delete {
    class ProcedureDelete {
        // Classes
        SqlCommand query = new SqlCommand();        
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public bool Procedure(int id) {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"DELETE FROM TB_PROCEDURES WHERE ID_PROCEDURE = {id};";
                query.ExecuteNonQuery();

                dbConn.Disconnect();
                statusController.Deleted();
                return true;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.NonDeleted();
                return false;
            }
        }
    }
}