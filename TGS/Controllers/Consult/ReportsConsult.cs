using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;


namespace TGS.Controllers.Consult {
    class ReportsConsult {
        // Classes
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public string[,] Reports() {
            try {
                int[] reportsSearch = Configs.ReportsList;
                string[,] reports = new string[reportsSearch.Length, 2];
                query.Connection = dbConn.Connect();
                int i = 0;
                if (reportsSearch[0] == 0) {
                    query.CommandText = "SELECT COUNT(CPF_PATIENT) AS TOTAL FROM TB_PATIENTS;";
                    reader = query.ExecuteReader();
                    reader.Read();
                    reports[0, 0] = "Pacientes";
                    reports[0, 1] = $"{reader["TOTAL"]}";
                    reader.Close();
                    i++;
                }

                for (int j = i; j < reportsSearch.Length; j++) {
                    query.CommandText = $"SELECT PROCEDURE_TITLE FROM TB_PROCEDURES WHERE ID_PROCEDURE = {reportsSearch[j]};";
                    reader = query.ExecuteReader();
                    reader.Read();
                    reports[j, 0] = $"{reader["PROCEDURE_TITLE"]}";
                    reader.Close();

                    query.CommandText = $"SELECT COUNT(ID_PROCEDURE) AS TOTAL FROM TB_CONSULTS WHERE ID_PROCEDURE = {reportsSearch[j]};";
                    reader = query.ExecuteReader();
                    reader.Read();
                    reports[j, 1] = $"{reader["TOTAL"]}";
                    reader.Close();
                }

                dbConn.Disconnect();
                return reports;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }
    }
}