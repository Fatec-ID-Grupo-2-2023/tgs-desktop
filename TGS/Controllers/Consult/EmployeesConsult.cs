using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Consult {
    class EmployeesConsult {
        // Classes
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        StatusController statusController = new StatusController();

        public string[,] Employees() {

            try {
                query.Connection = dbConn.Connect();

                query.CommandText = $"SELECT COUNT(CPF_EMPLOYEE) AS TOTAL FROM TB_EMPLOYEES;";
                reader = query.ExecuteReader();

                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] procedures = new string[int.Parse(total), 5];
                reader.Close();


                query.CommandText = $"SELECT CPF_EMPLOYEE, NAME_EMPLOYEE, LAST_NAME, EMAIL, TELEPHONE, CELLPHONE FROM TB_EMPLOYEES ORDER BY NAME_EMPLOYEE;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    procedures[i, 0] = $"{reader["CPF_EMPLOYEE"]}";
                    procedures[i, 1] = $"{reader["NAME_EMPLOYEE"]} {reader["LAST_NAME"]}";
                    procedures[i, 2] = $"{reader["EMAIL"]}";
                    procedures[i, 3] = $"{reader["TELEPHONE"]}";                 
                    procedures[i++, 4] = $"{reader["CELLPHONE"]}";
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

        public string[] Employee(string id) {
            try {
                query.Connection = dbConn.Connect();

                string[] details = new string[6];

                query.CommandText = $"SELECT CPF_EMPLOYEE, NAME_EMPLOYEE, LAST_NAME, EMAIL, TELEPHONE, CELLPHONE FROM TB_EMPLOYEES WHERE CPF_EMPLOYEE = '{id}';";
                reader = query.ExecuteReader();

                reader.Read();

                details[0] = $"{reader["CPF_EMPLOYEE"]}";
                details[1] = $"{reader["NAME_EMPLOYEE"]}";
                details[2] = $"{reader["LAST_NAME"]}";
                details[3] = $"{reader["EMAIL"]}";
                details[4] = $"{reader["TELEPHONE"]}";
                details[5] = $"{reader["CELLPHONE"]}";

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

                query.CommandText = $"SELECT COUNT(CPF_EMPLOYEE) AS TOTAL FROM TB_EMPLOYEES WHERE CPF_EMPLOYEE LIKE '%{value}%' OR NAME_EMPLOYEE + ' ' + LAST_NAME LIKE '%{value}%';";
                reader = query.ExecuteReader();
                
                reader.Read();
                string total = $"{reader["TOTAL"]}";
                string[,] procedures = new string[int.Parse(total), 5];
                reader.Close();


                query.CommandText = $"SELECT CPF_EMPLOYEE, NAME_EMPLOYEE, LAST_NAME, EMAIL, TELEPHONE, CELLPHONE FROM TB_EMPLOYEES WHERE CPF_EMPLOYEE LIKE '%{value}%' OR NAME_EMPLOYEE + ' ' + LAST_NAME LIKE '%{value}%' ORDER BY NAME_EMPLOYEE;";
                reader = query.ExecuteReader();

                int i = 0;
                while (reader.Read()) {
                    procedures[i, 0] = $"{reader["CPF_EMPLOYEE"]}";
                    procedures[i, 1] = $"{reader["NAME_EMPLOYEE"]} {reader["LAST_NAME"]}";
                    procedures[i, 2] = $"{reader["EMAIL"]}";
                    procedures[i, 3] = $"{reader["TELEPHONE"]}";
                    procedures[i++, 4] = $"{reader["CELLPHONE"]}";
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