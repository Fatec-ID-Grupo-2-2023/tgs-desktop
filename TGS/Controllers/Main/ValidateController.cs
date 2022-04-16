using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TGS.Controllers.Main {
    public class ValidateController {
        public bool Date(string date) {
            return DateTime.TryParse(date, out DateTime dateTime);
        }

        public bool Time(string time) {
            Regex timeValidate = new Regex(@"^(\d{2})\:(\d{2})\:?(\d{2})?\.?(\d{4})?$");
            return timeValidate.IsMatch(time);
        }

        public bool Email(string email) {
            Regex emailValidate = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");          
            return emailValidate.IsMatch(email);
        }

        public bool RG(string rg) {
            Regex rgValidate = new Regex(@"^((\d{2})\.(\d{3})\.(\d{3})\-(\d))$");
            return rgValidate.IsMatch(rg);
        }

        public bool CPF(string cpf) {
            Regex cpfValidate = new Regex(@"^((\d{3})\.(\d{3})\.(\d{3})\-(\d{2}))$");
            return cpfValidate.IsMatch(cpf);
        }

        public bool CRO(string cro) {
            Regex croValidate = new Regex(@"^(\d{2})\.(\d{3})$");
            return croValidate.IsMatch(cro);
        }

        public bool CEP(string cep) {
            Regex cepValidate = new Regex(@"^(\d{2})\.(\d{3})-(\d{3})$");
            return cepValidate.IsMatch(cep);
        }

        public bool Telephone(string telephone) {
            Regex telephoneValidate = new Regex(@"^(\((\d{2})\))(\d{4})-(\d{4})$");
            return telephoneValidate.IsMatch(telephone);
        }

        public bool Cellphone(string cellphone) {
            Regex cellphoneValidate = new Regex(@"^(\((\d{2})\))(\d{5})-(\d{4})$");
            return cellphoneValidate.IsMatch(cellphone);
        }

        public bool DurationConsult(string duration) {
            Regex durationValidate = new Regex(@"^(\d)?\d\,\d(\d)?$");
            return durationValidate.IsMatch(duration);
        }

        public string ToTitleCase(string str) {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public bool Text(string text) {
            Regex textValidate = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$");
            return textValidate.IsMatch(text);
            //return true;
        }
    }
}
