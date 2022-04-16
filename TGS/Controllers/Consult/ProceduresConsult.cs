using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Consult {
    class ProceduresConsult {
        // Classes
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public string[,] Procedures() {

            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"SELECT COUNT(ID_PROCEDURE) AS TOTAL FROM TB_PROCEDURES;";
                reader = query.ExecuteReader();

                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] procedures = new string[int.Parse(total), 2];
                reader.Close();


                query.CommandText = $"SELECT * FROM TB_PROCEDURES ORDER BY ID_PROCEDURE;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    procedures[i, 0] = $"{reader["ID_PROCEDURE"]}";
                    procedures[i++, 1] = $"{reader["PROCEDURE_TITLE"]}";
                }

                reader.Close();

                dbConn.Disconnect();

                return procedures;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }

        public string[] Procedure(int id) {
            try {
                query.Connection = dbConn.Connect();

                string[] details = new string[1];

                query.CommandText = $"SELECT PROCEDURE_TITLE FROM TB_PROCEDURES WHERE ID_PROCEDURE = {id};";
                reader = query.ExecuteReader();

                reader.Read();

                details[0] = $"{reader["PROCEDURE_TITLE"]}";

                reader.Close();

                dbConn.Disconnect();

                return details;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }

        public string[,] Filter(string value) {

            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"SELECT COUNT(ID_PROCEDURE) AS TOTAL FROM TB_PROCEDURES WHERE PROCEDURE_TITLE LIKE '%{value}%';";
                reader = query.ExecuteReader();

                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] procedures = new string[int.Parse(total), 2];
                reader.Close();


                query.CommandText = $"SELECT * FROM TB_PROCEDURES WHERE PROCEDURE_TITLE LIKE '%{value}%' ORDER BY ID_PROCEDURE;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    procedures[i, 0] = $"{reader["ID_PROCEDURE"]}";
                    procedures[i++, 1] = $"{reader["PROCEDURE_TITLE"]}";
                }

                reader.Close();

                dbConn.Disconnect();

                return procedures;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }
    }
}
