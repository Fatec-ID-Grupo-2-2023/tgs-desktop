using System.Data.SqlClient;
using TGS.Model;
using TGS.Controllers.Main;

namespace TGS.Controllers.Register {
    public class PatientsRegistration {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool PatientRegistration(string cpf, string rg, string name, string lastName, string nickname, string birthDate, string height, string weight, string email, string telephone, string cellphone, string street, string neighborhood, string city, string district, string cep, string complement, string number, bool testing = false) {
            if (telephone == "(  )    -") {
                telephone = null;
            }

            if (validateController.CPF(cpf) && validateController.RG(rg) && validateController.Email(email) && validateController.Text(name) && validateController.Text(lastName) && validateController.Text(nickname + " ") && validateController.Text(street) && validateController.Text(neighborhood) && validateController.Text(city) && validateController.Text(district) && (telephone == null || validateController.Telephone(telephone)) && validateController.Cellphone(cellphone)) {
                query.CommandText = $"INSERT INTO TB_PATIENTS (CPF_PATIENT, RG_PATIENT, NAME_PATIENT, LAST_NAME, NICKNAME, BIRTH_DATE, HEIGHT, WEIGHT_PATIENT, EMAIL, TELEPHONE, CELLPHONE, STREET, NEIGHBORHOOD, CITY, DISTRICT, CEP, COMPLEMENT, NUMBER) VALUES ('{cpf}', '{rg}', '{name}', '{lastName}', '{nickname}', '{birthDate}', '{height}', '{weight}', '{email}', '{telephone}', '{cellphone}', '{street}', '{neighborhood}', '{city}', '{district}', '{cep}', '{complement}', {int.Parse(number)});";
                try {
                    query.Connection = dbConn.Connect();
                    query.ExecuteNonQuery();
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
