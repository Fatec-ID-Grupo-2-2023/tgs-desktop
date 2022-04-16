using System;
using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;
using TGS.Views.Components;

namespace TGS.Controllers.Register {
    public class ConsultsRegistration {
        // Classes
        SqlCommand query = new SqlCommand();
        SqlDataReader reader = null;
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool ConsultOpen(string croDentist, string durate, string startDate, string endDate, string startOffice, string endOffice, string startLunch, string endLunch, bool testing = false) {            
            if (startLunch == "  :") {
                startLunch = null;
            }
            if (endLunch == "  :") {
                endLunch = null;
            }

            if (validateController.CRO(croDentist) && validateController.DurationConsult(durate) && validateController.Date(startDate) && validateController.Date(endDate) && validateController.Time(startOffice) && validateController.Time(endOffice) && (startLunch == null || validateController.Time(startLunch)) && (endLunch == null || validateController.Time(endLunch))) {
                try {        
                    query.Connection = dbConn.Connect();

                    query.CommandText = $"SELECT CRO_DENTIST FROM TB_DENTISTS WHERE CRO_DENTIST = '{croDentist}';";
                    SqlDataReader reader = query.ExecuteReader();

                    reader.Read();

                    string id = $"{reader["CRO_DENTIST"]}";

                    reader.Close();
                    dbConn.Disconnect();
                } catch (Exception e) {
                    dbConn.Disconnect();
                    if (!testing) statusController.NonCreated();
                    return false;
                }

                DateTime date = Convert.ToDateTime(startDate), convertedEndDate = Convert.ToDateTime(endDate);
                DateTime time, convertedStartOffice = Convert.ToDateTime(startOffice), convertedEndOffice = Convert.ToDateTime(endOffice), convertedStartLunch = Convert.ToDateTime(startLunch), convertedEndLunch = Convert.ToDateTime(endLunch);
                double duration = double.Parse(durate);

                if ((convertedStartLunch.ToShortTimeString().ToString() == "00:00") && (convertedEndLunch.ToShortTimeString().ToString() == "00:00")) {                                                                
                    try {
                        query.Connection = dbConn.Connect();
                        do {
                            time = convertedStartOffice;

                            while (time < convertedEndOffice) {
                                query.CommandText = $"INSERT INTO TB_CONSULTS (CRO_DENTIST, DATE_CONSULT, TIME_CONSULT, CPF_EMPLOYEE, STATUS_SCHEDULE) VALUES ('{croDentist}', '{date}', '{time.ToShortTimeString()}', '{Session.CPF}', 0);";
                                query.ExecuteNonQuery();                                
                                time = time.AddHours(duration);
                            }

                            date = date.AddDays(1);
                        } while (date <= convertedEndDate);


                        dbConn.Disconnect();

                        if (!testing) statusController.Created();
                        return true;
                    } catch (SqlException e) {
                        dbConn.Disconnect();
                        if (!testing) statusController.NonCreated();
                        return false;
                    }
                } else {
                    if ((date <= convertedEndDate) && (convertedStartOffice <= convertedEndOffice.AddHours(-duration)) && (convertedStartLunch < convertedEndLunch) && (convertedStartLunch >= convertedStartOffice.AddHours(duration)) && (convertedEndLunch <= convertedEndOffice.AddHours(-duration))) {
                        try {
                            query.Connection = dbConn.Connect();

                            do {
                                time = convertedStartOffice;

                                while (time < convertedStartLunch) {
                                    query.CommandText = $"INSERT INTO TB_CONSULTS (CRO_DENTIST, DATE_CONSULT, TIME_CONSULT, CPF_EMPLOYEE, STATUS_SCHEDULE) VALUES ('{croDentist}', '{date}', '{time.ToShortTimeString()}', '{Session.CPF}', 0);";
                                    query.ExecuteNonQuery();
                                    time = time.AddHours(duration);
                                }

                                time = convertedEndLunch;

                                while (time < convertedEndOffice) {
                                    query.CommandText = $"INSERT INTO TB_CONSULTS (CRO_DENTIST, DATE_CONSULT, TIME_CONSULT, CPF_EMPLOYEE, STATUS_SCHEDULE) VALUES ('{croDentist}', '{date}', '{time.ToShortTimeString()}', '{Session.CPF}', 0);";
                                    query.ExecuteNonQuery();
                                    time = time.AddHours(duration);
                                }

                                date = date.AddDays(1);
                            } while (date <= convertedEndDate);


                            dbConn.Disconnect();

                            if (!testing) statusController.Created();
                            return true;
                        } catch (SqlException e) {
                            dbConn.Disconnect();
                            if (!testing) statusController.NonCreated();
                            return false;
                        }
                    } else {
                        dbConn.Disconnect();
                        if (!testing) statusController.NonCreated();
                        return false;
                    }
                }              
            } else {
                dbConn.Disconnect();
                if (!testing) statusController.NotAcceptable();
                return false;
            }
        }

        public bool ConsultRegistration(string cpfPatient, string procedureTitle, int[] idConsult, bool testing = false) {
            if (validateController.CPF(cpfPatient) && validateController.Text(procedureTitle)) {
                query.Connection = dbConn.Connect();

                int length = idConsult.Length;

                for (int i = 0; i < length; i++) {
                    query.CommandText = $"SELECT STATUS_SCHEDULE FROM TB_CONSULTS WHERE ID_CONSULT = '{idConsult[i]}';";
                    reader = query.ExecuteReader();
                    reader.Read();
                    if (bool.Parse($"{reader["STATUS_SCHEDULE"]}")) {
                        reader.Close();
                        dbConn.Disconnect();
                        statusController.NonCreated();
                        return false;
                    }
                    reader.Close();
                }

                try {
                    int idProcedure;

                    try {
                        query.CommandText = $"SELECT ID_PROCEDURE FROM TB_PROCEDURES WHERE PROCEDURE_TITLE = '{procedureTitle}';";
                        reader = query.ExecuteReader();
                        reader.Read();
                        idProcedure = int.Parse($"{reader["ID_PROCEDURE"]}");
                        reader.Close();
                    } catch (Exception e) {
                        dbConn.Disconnect();
                        statusController.NonCreated();
                        return false;
                    }

                    for (int j = 0; j < length; j++) {
                        query.CommandText = $"UPDATE TB_CONSULTS SET STATUS_SCHEDULE = 1, CPF_EMPLOYEE = '{Session.CPF}', CPF_PATIENT = '{cpfPatient}', ID_PROCEDURE = {idProcedure} WHERE ID_CONSULT = {idConsult[j]};";
                        query.ExecuteNonQuery();
                    }

                    dbConn.Disconnect();

                    if (!testing) statusController.Created();
                    return true;
                } catch (SqlException e) {
                    dbConn.Disconnect();
                    if (!testing) statusController.NonCreated();
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
