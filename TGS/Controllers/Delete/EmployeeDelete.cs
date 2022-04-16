using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Delete {
    class EmployeeDelete {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public bool Employee(string id) {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"DELETE FROM TB_EMPLOYEES WHERE CPF_EMPLOYEE = '{id}';";
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