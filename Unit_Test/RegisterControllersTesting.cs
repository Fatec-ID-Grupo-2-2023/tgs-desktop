using NUnit.Framework;
using System.Collections.Generic;
using TGS.Controllers.Register;

namespace Unit_Test {
    [TestFixture]
    public class RegisterControllersTesting {
        ConsultsRegistration consultsRegistration = new ConsultsRegistration();
        DentistsRegistration dentistsRegistration = new DentistsRegistration();
        EmployeesRegistration employeesRegistration = new EmployeesRegistration();
        PatientsRegistration patientsRegistration = new PatientsRegistration();
        ProceduresRegistration proceduresRegistration = new ProceduresRegistration();

        [Test, TestCaseSource(typeof(RegisterCases), "Schedulings")]
        public bool ScheduleTest(string cro, string date, string time) => consultsRegistration.ConsultOpen(cro, date, time, true);

        [Test, TestCaseSource(typeof(RegisterCases), "Consults")]
        public bool ConsultTest(string cpf, int procedure, int consult) => consultsRegistration.ConsultRegistration(cpf, procedure, consult, true);

        [Test, TestCaseSource(typeof(RegisterCases), "Dentists")]
        public bool DentistTest(string cro, string name, string lastName, string expertise) => dentistsRegistration.DentistRegistration(cro, name, lastName, expertise, true);

        [Test, TestCaseSource(typeof(RegisterCases), "Employees")]
        public bool EmployeeTest(string cpf, string name, string lastName, string email, string telephone, string cellphone, string password) => employeesRegistration.EmployeeRegistration(cpf, name, lastName, email, telephone, cellphone, password, true);

        [Test, TestCaseSource(typeof(RegisterCases), "Patients")]
        public bool PatientTest(string cpf, string rg, string name, string lastName, string nickname, string birthDate, string height, string weight, string email, string telephone, string cellphone, string street, string neighborhood, string city, string district, string cep, string complement, string number) => patientsRegistration.PatientRegistration(cpf, rg, name, lastName, nickname, birthDate, height, weight, email, telephone, cellphone, street, neighborhood, city, district, cep, complement, number, true);

        [Test, TestCaseSource(typeof(RegisterCases), "Procedures")]
        public bool ProcedureTest(string title) => proceduresRegistration.ProcedureRegistration(title, true);
    }

    public class RegisterCases {
        public static List<TestCaseData> Schedulings {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("12.623", "22/09/2021", "08:00").Returns(true).SetCategory("Agendamento Válido"),
                    new TestCaseData("", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12523", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.23", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12-823", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12-823", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("AAAA", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("ab.cde", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("*$#@", "22/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "111/09/2021", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "11/09/0000", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "00/09/2020", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/00/2020", "08:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/01/2020", "").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/09/2021", "998:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/09/2021", "26:00").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/09/2021", "08:80").Returns(false).SetCategory("Agendamento Inválido"),
                    new TestCaseData("12.623", "01/09/2021", "08:888").Returns(false).SetCategory("Agendamento Inválido")
                };
            }
        }

        public static List<TestCaseData> Consults {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12", 1, 4).Returns(true).SetCategory("Consulta Válida"),
                    new TestCaseData("", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("12312312312", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123.12", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123-1", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123-123", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123-AA", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123-**", 1, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123-12", null, 4).Returns(false).SetCategory("Consulta Inválida"),
                    new TestCaseData("123.123.123-12", 1, null).Returns(false).SetCategory("Consulta Inválida"),
                };
            }
        }

        public static List<TestCaseData> Dentists {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("92.623", "Roberto", "Lakhross", "Canal").Returns(true).SetCategory("Dentista Válido"),
                    new TestCaseData("", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12123", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12-123", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12.1234", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("12.12", "Roberto", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("82.623", "", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),                                        
                    new TestCaseData("72.623", "123", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("62.623", "@*#", "Lakhross", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("52.623", "Roberto", "", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("42.623", "Roberto", "123", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("32.623", "Roberto", "@*#", "Canal").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("22.623", "Roberto", "Lakhross", "").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("19.623", "Roberto", "Lakhross", "123").Returns(false).SetCategory("Dentista Inválido"),
                    new TestCaseData("18.623", "Roberto", "Lakhross", "@*#").Returns(false).SetCategory("Dentista Inválido")
                };
            }
        }

        public static List<TestCaseData> Employees {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(true).SetCategory("Funcionário Válido"),
                    new TestCaseData("", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("12312312312", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("AAA.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-*", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "123", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "@#&%", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "123", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "&%¨#", "renata@gmail.com", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa*", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa/", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa@aaaa.111", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "aaaaa.aaaaa@**", "(19)1234-1234", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),                  
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "", "(19)91234-1234", "MySenha").Returns(true).SetCategory("Funcionário Válido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(1784)-12044-0512", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)-1204-05112", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(*9)-1204-051145", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1021,2021*", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1021,2021", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1021*2021", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)10.21,20,21*", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)10,21,2021*", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1**1,2021", "(19)91234-1234", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),                 
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)912700512", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)-1204-051", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(*9)-1204-45", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)99021,202*", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)10212021", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)1021*2021", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)102,20,21*", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "(19)921,20211*", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "()*13164-0490", "MySenha").Returns(false).SetCategory("Funcionário Inválido"),
                    new TestCaseData("123.123.123-12", "Renata", "Da Silva", "renata@gmail.com", "(19)1234-1234", "()*13164-0490", "").Returns(false).SetCategory("Funcionário Inválido")
                };
            }
        }

        public static List<TestCaseData> Patients {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-1", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "(19)1234-1234", "Ronaldinho@outlook.com", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("12312312312", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("AAA.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-*", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "121231234", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-*", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "AA.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "123", "Junqueira", "Ana", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "123", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "***", "11/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "AA/08/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/AA/1980", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/AAAA", "1,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(true).SetCategory("Paciente Válido"),                                                                                               
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "A,70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),                   
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(true).SetCategory("Paciente Válido"),                                                                                              
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "AA,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,A", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "aaaaa.aaaaa", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "aaaaa.aaaaa*", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "aaaaa.aaaaa/", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "aaaaa.aaaaa@aaaa.111", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "aaaaa.aaaaa@**", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(AA)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)AAAA-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-AAAA", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "**", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "**", "Itu", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "**", "SP", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "**", "12.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "AA.123-123", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-AAA", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-**", "Casa 2", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-**", "", "105").Returns(true).SetCategory("Paciente Válido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "**", "105").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2 ", "").Returns(false).SetCategory("Paciente Inválido"),
                    new TestCaseData("123.123.123-12", "12.123.123-4", "Ronaldo", "Junqueira", "Ana", "11/08/1980", "1.70", "80,5", "Ronaldinho@outlook.com", "(19)1234-1234", "(19)91234-1234", "Rua Um", "Alameda das Flores", "Itu", "SP", "12.123-123", "Casa 2 ", "**").Returns(false).SetCategory("Paciente Inválido")
                };                                                                                                                  
            }
        }

        public static List<TestCaseData> Procedures {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("Implante").Returns(true).SetCategory("Procedimento Válido"),
                    new TestCaseData("").Returns(false).SetCategory("Procedimento Inválido"),
                    new TestCaseData("12343").Returns(false).SetCategory("Procedimento Inválido"),
                    new TestCaseData("*&#(").Returns(false).SetCategory("Procedimento Inválido")
                };
            }
        }
    }
}
