using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Delete {
    class DentistDelete {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public bool Dentist(string id) {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"DELETE FROM TB_DENTISTS WHERE CRO_DENTIST = '{id}';";
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