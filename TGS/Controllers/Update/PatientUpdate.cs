using System.Data.SqlClient;
using TGS.Model;
using TGS.Views;
using TGS.Controllers.Main;

namespace TGS.Controllers.Update {
    public class PatientUpdate {
        // Classes
        SqlCommand query = new SqlCommand();
        DBConnection dbConn = new DBConnection();
        ValidateController validateController = new ValidateController();
        StatusController statusController = new StatusController();

        public bool Patient(string id, string cpf, string rg, string name, string lastName, string nickname, string birthDate, string height, string weight, string email, string telephone, string cellphone, string street, string neighborhood, string city, string district, string cep, string complement, int number, bool testing = false) {
            if (telephone == "(  )    -") {
                telephone = null;
            }

            if (validateController.CPF(cpf) && validateController.RG(rg) && validateController.Email(email) && validateController.Text(name) && validateController.Text(lastName) && validateController.Text(nickname + " ") && validateController.Text(street) && validateController.Text(neighborhood) && validateController.Text(city) && validateController.Text(district) && (telephone == null || validateController.Telephone(telephone)) && validateController.Cellphone(cellphone)) {
                try {
                    query.Connection = dbConn.Connect();
                    query.CommandText = $"UPDATE TB_PATIENTS SET CPF_PATIENT = '{cpf}', RG_PATIENT = '{rg}', NAME_PATIENT = '{validateController.ToTitleCase(name)}', LAST_NAME = '{validateController.ToTitleCase(lastName)}', NICKNAME = '{validateController.ToTitleCase(nickname)}', BIRTH_DATE = '{birthDate}', HEIGHT = '{height}', WEIGHT_PATIENT = '{weight}', EMAIL = '{email}', TELEPHONE = '{telephone}', CELLPHONE = '{cellphone}', STREET = '{validateController.ToTitleCase(street)}', NEIGHBORHOOD = '{validateController.ToTitleCase(neighborhood)}', CITY = '{validateController.ToTitleCase(city)}', DISTRICT = '{validateController.ToTitleCase(district)}', CEP = '{cep}', COMPLEMENT = '{complement}', NUMBER = {number} WHERE CPF_PATIENT = '{id}';";
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