using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;


namespace TGS.Controllers.Consult {
    class DentistsConsult {
        // Classes
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public string[,] Dentists() {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"SELECT COUNT(CRO_DENTIST) AS TOTAL FROM TB_DENTISTS;";
                reader = query.ExecuteReader();

                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] result = new string[int.Parse(total), 3];
                reader.Close();


                query.CommandText = $"SELECT * FROM TB_DENTISTS ORDER BY NAME_DENTIST;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    result[i, 0] = $"{reader["CRO_DENTIST"]}";
                    result[i, 1] = $"{reader["NAME_DENTIST"]} {reader["LAST_NAME"]}";
                    result[i++, 2] = $"{reader["EXPERTISE"]}";
                }

                reader.Close();

                dbConn.Disconnect();

                return result;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }

        public string[] Dentist(string id) {
            try {
                query.Connection = dbConn.Connect();

                string[] details = new string[4];

                query.CommandText = $"SELECT * FROM TB_DENTISTS WHERE CRO_DENTIST = '{id}';";
                reader = query.ExecuteReader();

                reader.Read();

                details[0] = $"{reader["CRO_DENTIST"]}";
                details[1] = $"{reader["NAME_DENTIST"]}";
                details[2] = $"{reader["LAST_NAME"]}";
                details[3] = $"{reader["EXPERTISE"]}";

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

                query.CommandText = $"SELECT COUNT(CRO_DENTIST) AS TOTAL FROM TB_DENTISTS WHERE CRO_DENTIST LIKE '%{value}%' OR NAME_DENTIST + ' ' + LAST_NAME LIKE '%{value}%';";
                reader = query.ExecuteReader();

                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] result = new string[int.Parse(total), 3];
                reader.Close();


                query.CommandText = $"SELECT * FROM TB_DENTISTS WHERE CRO_DENTIST LIKE '%{value}%' OR NAME_DENTIST + ' ' + LAST_NAME LIKE '%{value}%' ORDER BY NAME_DENTIST;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    result[i, 0] = $"{reader["CRO_DENTIST"]}";
                    result[i, 1] = $"{reader["NAME_DENTIST"]} {reader["LAST_NAME"]}";
                    result[i++, 2] = $"{reader["EXPERTISE"]}";
                }

                reader.Close();

                dbConn.Disconnect();

                return result;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }

        public string[,] SelectDentist() {
            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"SELECT COUNT(CRO_DENTIST) AS TOTAL FROM TB_DENTISTS;";
                reader = query.ExecuteReader();

                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] result = new string[int.Parse(total), 2];
                reader.Close();

                query.CommandText = $"SELECT CRO_DENTIST, NAME_DENTIST, LAST_NAME FROM TB_DENTISTS ORDER BY NAME_DENTIST;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    result[i, 0] = $"{reader["CRO_DENTIST"]}";
                    result[i++, 1] = $"{reader["NAME_DENTIST"]} {reader["LAST_NAME"]}";
                }

                reader.Close();
                dbConn.Disconnect();
                return result;
            } catch (SqlException e) {
                dbConn.Disconnect();
                statusController.InternalError();
                return null;
            }
        }
    }
}
