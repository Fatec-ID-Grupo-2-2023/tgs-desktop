using NUnit.Framework;
using System.Collections.Generic;
using TGS.Controllers.Update;

namespace Unit_Test {
    [TestFixture]
    public class UpdateControllerTesting {
        ScheduleUpdate consultUpdate = new ScheduleUpdate();
        DentistUpdate dentistUpdate = new DentistUpdate();
        EmployeeUpdate employeeUpdate = new EmployeeUpdate();
        PatientUpdate patientUpdate = new PatientUpdate();
        ProcedureUpdate procedureUpdate = new ProcedureUpdate();

        [Test, TestCaseSource(typeof(UpdateCases), "Consults")]
        public bool ConsultTest(string cpfPatient, string date, string time, int oldId, string procedureTitle) => consultUpdate.ScheduleUpdating(cpfPatient, date, time, oldId, procedureTitle, true);

        [Test, TestCaseSource(typeof(UpdateCases), "Dentists")]
        public bool DentistTest(string id, string cro, string name, string lastName, string expertise) => dentistUpdate.Dentist(id, cro, name, lastName, expertise, true);

        [Test, TestCaseSource(typeof(UpdateCases), "Employees")]
        public bool EmployeeTest(string id, string cpf, string name, string lastName, string email, string telephone, string cellphone) => employeeUpdate.Employee(id, cpf, name, lastName, email, telephone, cellphone, true);

        [Test, TestCaseSource(typeof(UpdateCases), "Patients")]
        public bool PatientTest(string id, string cpf, string rg, string name, string lastName, string nickname, string birthDate, string height, string weight, string email, string telephone, string cellphone, string street, string neighborhood, string city, string district, string cep, string complement, int number) => patientUpdate.Patient(id, cpf, rg, name, lastName, nickname, birthDate, height, weight, email, telephone, cellphone, street, neighborhood, city, district, cep, complement, number, true);

        [Test, TestCaseSource(typeof(UpdateCases), "Procedures")]
        public bool ProcedureTest(int id, string title) => procedureUpdate.Procedure(id, title, true);
    }

    public class UpdateCases {
        public static List<TestCaseData> Consults {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12", "21/09/2021", "13:00", 1, "Consulta").Returns(true).SetCategory("Agendamento Válido"),
                    new TestCaseData("", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12312312312", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123.12", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-1", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-123", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-AA", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-**", "21/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "01/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "111/09/2021", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "11/09/0000", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "00/09/2020", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "01/00/2020", "13:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "998:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "26:00", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "08:80", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "08:888", 1, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "13:00", null, "Consulta").Returns(false).SetCategory("Agendamento Inválido"),                    
                    new TestCaseData("123.123.123-12", "21/09/2021", "13:00", 1, "").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "13:00", 1, "12345").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("123.123.123-12", "21/09/2021", "13:00", 1, "*&%$#@").Returns(false).SetCategory("Agendamento Inválido"),
                };
            }
        }

        public static List<TestCaseData> Dentists {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("92.623", "92.623", "Roberto", "Lakhross", "Canal").Returns(true).SetCategory("Dentista Válido"),
                    new TestCaseData("", "92.623", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12123", "92.623", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12-123", "92.623", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12.1234", "92.623", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12.12", "92.623", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "12123", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "12-123", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "12.1234", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "12.12", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "92.623", "", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("72.623", "92.623", "123", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("62.623", "92.623", "@*#", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("52.623", "92.623", "Roberto", "", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("42.623", "92.623", "Roberto", "123", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("32.623", "92.623", "Roberto", "@*#", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("22.623", "92.623", "Roberto", "Lakhross", "").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("19.623", "92.623", "Roberto", "Lakhross", "123").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("18.623", "92.623", "Roberto", "Lakhross", "@*#").Returns(false).SetCategory("Dentista Inválido")
                };
            }
        }

        public static List<TestCaseData> Employees {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(true).SetCategory("Funcionário Válido"),
                    new TestCaseData("", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("12312312312", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("AAA.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-*", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "12312312312", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "AAA.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-*", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),                    
                    new TestCaseData("123.123.123-12", "123.123.123-12", "", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "123", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "@#&%", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "123", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "&%¨#", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa*", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa/", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa@aaaa.111", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa@**", "(19)1234-1234", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "", "(19)91234-1234").Returns(true).SetCategory("Funcionário Válido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(1784)-12044-0512", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)-1204-05112", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(*9)-1204-051145", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1021,2021*", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1021,2021", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1021*2021", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)10.21,20,21*", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)10,21,2021*", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1**1,2021", "(19)91234-1234").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)912700512").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)-1204-051").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(*9)-1204-45").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)99021,202*").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)10212021").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)1021*2021").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)102,20,21*").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)921,20211*").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "()*13164-0490").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "()*13164-0490").Returns(false).SetCategory("Funcionário Inválido")
                };
            }
        }

        public static List<TestCaseData> Patients {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-1", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "(19)1234-1234", "Ronaldinho@outlook.com", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("12312312312", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("AAA.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-*", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12312312312", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "AAA.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-*", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "121231234", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-*", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "AA.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "123", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "*¨$#", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "123", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "*&$#", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "123", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "***", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "AA/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/AA/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/AAAA", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "A,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "AA,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,A", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(AA)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)AAAA-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-AAAA", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "**", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "**", "Itu", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "**", "SP", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "**", "12.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "AA.123-123", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-AAA", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-**", "Casa 2", 105).Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-**", "", 105).Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "**", 105).Returns(false).SetCategory("Paciente Inválido"),                    
                };
            }
        }

        public static List<TestCaseData> Procedures {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData(1, "Implante").Returns(true).SetCategory("Procedimento Válido"),
                    new TestCaseData(null, "Implante").Returns(false).SetCategory("Procedimento Inválido"),
                    new TestCaseData(1, "").Returns(false).SetCategory("Procedimento Inválido"),
                    new TestCaseData(1, "12343").Returns(false).SetCategory("Procedimento Inválido"),
                    new TestCaseData(1, "*&#(").Returns(false).SetCategory("Procedimento Inválido")
                };
            }
        }
    }
}