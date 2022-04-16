using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Delete {
    class ConsultDelete {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public bool Schedule(int id) {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"DELETE FROM TB_CONSULTS WHERE ID_CONSULT = {id};";
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

        public bool Consult(int id) {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"UPDATE TB_CONSULTS SET STATUS_SCHEDULE = 0, CPF_EMPLOYEE = '{Session.CPF}', CPF_PATIENT = NULL, ID_PROCEDURE = NULL WHERE ID_CONSULT = {id};";
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