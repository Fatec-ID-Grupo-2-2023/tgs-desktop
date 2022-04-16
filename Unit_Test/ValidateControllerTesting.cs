using NUnit.Framework;
using System.Collections.Generic;
using TGS.Controllers.Main;

namespace Unit_Test {
    [TestFixture]
    public class ValidateControllerTesting {
        ValidateController validateController = new ValidateController();

        [Test, TestCaseSource(typeof(ValidateCases), "Dates")]
        public bool DateTest(string date) => validateController.Date(date);

        [Test, TestCaseSource(typeof(ValidateCases), "Times")]
        public bool TimeTest(string time) => validateController.Time(time);

        [Test, TestCaseSource(typeof(ValidateCases), "Emails")]
        public bool EmailTest(string email) => validateController.Email(email);

        [Test, TestCaseSource(typeof(ValidateCases), "RGs")]
        public bool RgTest(string rg) => validateController.RG(rg);

        [Test, TestCaseSource(typeof(ValidateCases), "CPFs")]
        public bool CpfTest(string cpf) => validateController.CPF(cpf);

        [Test, TestCaseSource(typeof(ValidateCases), "CROs")]
        public bool CroTest(string cro) => validateController.CRO(cro);

        [Test, TestCaseSource(typeof(ValidateCases), "CEPs")]
        public bool CepTest(string cep) => validateController.CEP(cep);

        [Test, TestCaseSource(typeof(ValidateCases), "Telephones")]
        public bool TelephoneTest(string telephone) => validateController.Telephone(telephone);

        [Test, TestCaseSource(typeof(ValidateCases), "Cellphones")]
        public bool CellphoneTest(string cellphone) => validateController.Cellphone(cellphone);
    }

    public class ValidateCases {
        public static List<TestCaseData> Dates {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("11/11/1111").Returns(true).SetCategory("Data Válida"),
                    new TestCaseData("").Returns(false).SetCategory("Data Inválida"),
                    new TestCaseData("**/11/1111").Returns(false).SetCategory("Data Inválida"),
                    new TestCaseData("11/**/1111").Returns(false).SetCategory("Data Inválida"),
                    new TestCaseData("11/11/****").Returns(false).SetCategory("Data Inválida"),
                    new TestCaseData("AA/11/1111").Returns(false).SetCategory("Data Inválida"),
                    new TestCaseData("11/AA/1111").Returns(false).SetCategory("Data Inválida"),
                    new TestCaseData("11/11/AAAA").Returns(false).SetCategory("Data Inválida")
                };
            }
        }

        public static List<TestCaseData> Times {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("00:00").Returns(true).SetCategory("Horário Válido"),
                    new TestCaseData("").Returns(false).SetCategory("Horário Inválido"),
                    new TestCaseData("00,00").Returns(false).SetCategory("Horário Inválido"),
                    new TestCaseData("0:0").Returns(false).SetCategory("Horário Inválido"),
                    new TestCaseData("A:00").Returns(false).SetCategory("Horário Inválido"),
                    new TestCaseData("0:AA").Returns(false).SetCategory("Horário Inválido"),
                    new TestCaseData("AA:AA").Returns(false).SetCategory("Horário Inválido"),
                    new TestCaseData("**:**").Returns(false).SetCategory("Horário Inválido")
                };
            }
        }

        public static List<TestCaseData> Emails {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("aaaaa.aaaaaa@aaaaa.aaa.aa").Returns(true).SetCategory("E-mail Válido"),
                    new TestCaseData("").Returns(false).SetCategory("E-mail Inválido"),
                    new TestCaseData("aaaaa.aaaaa").Returns(false).SetCategory("E-mail Inválido"),
                    new TestCaseData("aaaaa.aaaaa*").Returns(false).SetCategory("E-mail Inválido"),
                    new TestCaseData("aaaaa.aaaaa/").Returns(false).SetCategory("E-mail Inválido"),
                    new TestCaseData("aaaaa.aaaaa@aaaa.111").Returns(false).SetCategory("E-mail Inválido"),
                    new TestCaseData("aaaaa.aaaaa@**").Returns(false).SetCategory("E-mail Inválido")
                };
            }
        }

        public static List<TestCaseData> RGs {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("12.435.789-9").Returns(true).SetCategory("RG Válido"),
                    new TestCaseData("").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("123.435.78999").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("13.456.89").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("123.567.X").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("12.456.789.144").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("123.456.7").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("12.456.78.000").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("123.456.7891-*").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("123,456,789").Returns(false).SetCategory("RG Inválido"),
                    new TestCaseData("12.0,.7891,").Returns(false).SetCategory("RG Inválido")
                };
            }
        }

        public static List<TestCaseData> CPFs {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("123.123.123-12").Returns(true).SetCategory("CPF Válido"),
                    new TestCaseData("").Returns(false).SetCategory("CPF Inválido"),
                    new TestCaseData("12312312312").Returns(false).SetCategory("CPF Inválido"),
                    new TestCaseData("123.123.123.12").Returns(false).SetCategory("CPF Inválido"),
                    new TestCaseData("123.123.123-1").Returns(false).SetCategory("CPF Inválido"),
                    new TestCaseData("123.123.123-123").Returns(false).SetCategory("CPF Inválido"),
                    new TestCaseData("123.123.123-AA").Returns(false).SetCategory("CPF Inválido"),
                    new TestCaseData("123.123.123-**").Returns(false).SetCategory("CPF Inválido")
                };
            }
        }

        public static List<TestCaseData> CROs {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("12.345").Returns(true).SetCategory("CRO Válido"),
                    new TestCaseData("").Returns(false).SetCategory("CRO Inválido"),
                    new TestCaseData("12,345").Returns(false).SetCategory("CRO Inválido"),
                    new TestCaseData("1,2345").Returns(false).SetCategory("CRO Inválido"),
                    new TestCaseData("AA.123").Returns(false).SetCategory("CRO Inválido"),
                    new TestCaseData("12.AAA").Returns(false).SetCategory("CRO Inválido"),
                    new TestCaseData("12345").Returns(false).SetCategory("CRO Inválido"),
                    new TestCaseData("**.123").Returns(false).SetCategory("CRO Inválido")
                };
            }
        }

        public static List<TestCaseData> CEPs {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("13.164-000").Returns(true).SetCategory("CEP Válido"),
                    new TestCaseData("").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("13164-000").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("131646-000").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("1315408-000").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("*13.164-000").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("*13.164-00").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("13,164-00").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("*13,164,00").Returns(false).SetCategory("CEP Inválido"),
                    new TestCaseData("*13164-0490").Returns(false).SetCategory("CEP Inválido")
                };
            }
        }

        public static List<TestCaseData> Telephones {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("(19)3879-1245").Returns(true).SetCategory("Telefone Válido"),
                    new TestCaseData("").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(1784)-12044-0512").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)-1204-05112").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(*9)-1204-051145").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)1021,2021*").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)1021,2021").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)1021*2021").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)10.21,20,21*").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)10,21,2021*").Returns(false).SetCategory("Telefone Inválido"),
                    new TestCaseData("(19)1**1,2021").Returns(false).SetCategory("Telefone Inválido")
                };
            }
        }

        public static List<TestCaseData> Cellphones {
            get {
                return new List<TestCaseData>() {
                    new TestCaseData("(19)99877-2020").Returns(true).SetCategory("Celular Válido"),
                    new TestCaseData("").Returns(false).SetCategory("Celular  Inválido"),
                    new TestCaseData("(19)912700512").Returns(false).SetCategory("Celular  Inválido"),
                    new TestCaseData("(19)-1204-051").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("(*9)-1204-45").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("(19)99021,202*").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("(19)10212021").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("(19)1021*2021").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("(19)102,20,21*").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("(19)921,20211*").Returns(false).SetCategory("Celular Inválido"),
                    new TestCaseData("()*13164-0490").Returns(false).SetCategory("Celular Inválido")
                };
            }
        }
    }
}