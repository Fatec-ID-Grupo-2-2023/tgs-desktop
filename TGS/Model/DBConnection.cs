using System.Data.SqlClient;

namespace TGS.Model {
    class DBConnection {
        
        public DBConnection() {
            dbConn.ConnectionString = @Configs.DBRoute;
        }

        // Classes
        SqlConnection dbConn = new SqlConnection();

        public SqlConnection Connect() {
            if (dbConn.State == System.Data.ConnectionState.Closed) {
                dbConn.Open();            
            }
            return dbConn;
        }

        public void Disconnect() {
            if (dbConn.State == System.Data.ConnectionState.Open) {
                dbConn.Close();
            }
        }
    }
}
