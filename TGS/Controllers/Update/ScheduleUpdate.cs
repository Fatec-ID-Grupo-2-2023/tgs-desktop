using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Update {
    public class ScheduleUpdate {
        // Classes
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool ScheduleUpdating(string cpfPatient, string dateSchedule,string timeSchedule, int oldId, string procedureTitle, bool testing = false) {
            if (validateController.CPF(cpfPatient) && validateController.Date(dateSchedule) && validateController.Time(timeSchedule) && validateController.Text(procedureTitle)) {
                try {
                    query.Connection = dbConn.Connect();

                    query.CommandText = $"UPDATE TB_CONSULTS SET STATUS_SCHEDULE = 0, CPF_EMPLOYEE = '{Session.CPF}', CPF_PATIENT = null, ID_PROCEDURE = null WHERE ID_CONSULT = {oldId};";
                    query.ExecuteNonQuery();
                    query.CommandText = $"SELECT ID_PROCEDURE FROM TB_PROCEDURES WHERE PROCEDURE_TITLE = '{procedureTitle}';";
                    reader = query.ExecuteReader();
                    reader.Read();
                    int idProcedure = int.Parse($"{reader["ID_PROCEDURE"]}");
                    reader.Close();
                    query.CommandText = $"UPDATE TB_CONSULTS SET STATUS_SCHEDULE = 1, CPF_EMPLOYEE = '{Session.CPF}', CPF_PATIENT = '{cpfPatient}', ID_PROCEDURE = {idProcedure} WHERE DATE_CONSULT = '{dateSchedule}' AND TIME_CONSULT = '{timeSchedule}';";
                    query.ExecuteNonQuery();
                    dbConn.Disconnect();

                    if (!testing) statusController.Updated();
                    return true;
                } catch (SqlException e) {
                    dbConn.Disconnect();
                    if (!testing) statusController.NonUpdated();
                    return false;
                }
            } else {
                dbConn.Disconnect();
                if (!testing) statusController.NotAcceptable();
                return false;
            }
        }
    }
}
