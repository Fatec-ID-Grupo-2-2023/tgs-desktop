using System;
using System.Windows.Forms;
using TGS.Views;
using TGS.Views.Components;

namespace TGS.Controllers.Main {
    class AlterPageController {
        // Classes
        StatusController statusController = new StatusController();

        //Fields
        private String chatLink = "whatsapp://";

        public void AlterPage(Form formAtual, String formDestino, String id = null, string dateSchedule = null, string timeSchedule = null, int[] idList = null) {
            if (!(formAtual is null)) {
                formAtual.Hide();
            }

            switch (formDestino) {
                /* ---- MENU PAGES ---- */
                // Home
                case "home":
                    Home home = new Home();
                    home.ShowDialog();
                break;
                // Calendar
                case "calendar":
                    SchedulePage calendar = new SchedulePage();
                    calendar.ShowDialog();
                break;
                // Chat
                case "chat":
                    OpenLink(chatLink);
                break;
                // Patients List
                case "patients":
                    ListPage patients = new ListPage("patients");
                    patients.ShowDialog();
                break;
                // Options
                case "options":
                    Options options = new Options();
                    options.ShowDialog();
                break;
                /* ---- END MENU PAGES ---- */

                /* ---- REGISTRATION PAGES ---- */
                // Patients
                case "patients-registration":
                    FormPage patientsRegistration = new FormPage("patients");
                    patientsRegistration.ShowDialog();
                break;
                // Dentists
                case "dentists-registration":
                    FormPage dentistsRegistration = new FormPage("dentists");
                    dentistsRegistration.ShowDialog();
                break;
                // Schedule
                case "schedule-open":
                    FormPage scheduleOpen = new FormPage("schedule");
                    scheduleOpen.ShowDialog();
                break;
                // Consults
                case "consults-registration":
                    FormPage consultsRegistration = new FormPage("consults", dateSchedule, timeSchedule, idList);
                    consultsRegistration.ShowDialog();
                break;
                // Employees
                case "employee-registration":
                    FormPage employeesRegistration = new FormPage("employees");
                    employeesRegistration.ShowDialog();
                break;
                // Consult Categories
                case "consult-category-registration":
                    FormPage consultsCategoryRegistration = new FormPage("consults-categories");
                    consultsCategoryRegistration.ShowDialog();
                break;
                /* ---- END REGISTRATION PAGES ---- */

                /* ---- LIST PAGES ---- */
                // Dentists
                case "dentists-list":
                    ListPage dentists = new ListPage("dentists");
                    dentists.ShowDialog();
                break;
                // Employees
                case "employee-list":
                    ListPage employees = new ListPage("employees");
                    employees.ShowDialog();
                break;
                // Consult Categories
                case "consult-category-list":
                    ListPage consultsCategory = new ListPage("consult-categories");
                    consultsCategory.ShowDialog();
                break;
                /* ---- END LIST PAGES ---- */

                /* ---- DETAIL PAGES ---- */
                // Patients
                case "patient-details":
                    DetailsPage patientDetails = new DetailsPage("patient", id);
                    patientDetails.ShowDialog();
                break;
                // Dentists
                case "dentist-details":
                    DetailsPage dentistDetails = new DetailsPage("dentist", id);
                    dentistDetails.ShowDialog();
                break;
                // Employee
                case "employee-details":
                    DetailsPage employeeDetails = new DetailsPage("employee", id);
                    employeeDetails.ShowDialog();
                break;
                // Consults
                case "consult-details":
                    DetailsPage consultsDetails = new DetailsPage("consult", id);
                    consultsDetails.ShowDialog();
                break;
                // Consult Categories
                case "consult-category-details":
                    DetailsPage consultsCategoryDetails = new DetailsPage("consult-category", id);
                    consultsCategoryDetails.ShowDialog();
                break;
                /* ---- END DETAIL PAGES ---- */

                /* ---- OTHER PAGES ---- */
                // Support
                case "support":
                    OpenLink("https://caiquepatelliscapeline.github.io/TGS/Official_Page/pages/help.html");
                    AlterPage(null, "home");
                    break;
                // Logout
                case "login":
                    Login login = new Login();
                    login.ShowDialog();
                break;
                default:
                    statusController.PageNotFound();
                    AlterPage(null, "home");
                break;
            }
        }

        private void OpenLink(String link) {
            try {
                System.Diagnostics.Process.Start("cmd", $"/c start {link}");
            } catch (Exception ex) {
                statusController.PageNotFound();
                AlterPage(null, "home");
            }
        }        

        public void Errors(String title, String message) {
            MyMsgBox.Show(title, message, false);
            AlterPage(null, "home");
        }
    }
}
