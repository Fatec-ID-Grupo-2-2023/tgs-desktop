using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TGS.Controllers.Main;
using TGS.Controllers.Criptography;
using TGS.Controllers.Consult;
using TGS.Controllers.Delete;
using TGS.Controllers.Update;

namespace TGS.Views {
    public partial class DetailsPage : Form {
        public DetailsPage(string list, string idDetailItem) {
            detailRender = list;
            idDetailsItem = idDetailItem;            
            InitializeComponent();
            Render();
            CollapseMenu();

            lbl_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.Padding = new Padding(borderSize); // Border Size
            this.BackColor = Color.FromArgb(237, 245, 255); // Border Color
        }

        string detailRender;
        string idDetailsItem;

        //Classes
        HeaderController headerController = new HeaderController();
        AuthenticateController authenticateController = new AuthenticateController();
        AlterPageController alterPageController = new AlterPageController();
        DentistsConsult dentistsConsult = new DentistsConsult();
        StatusController statusController = new StatusController();

        // Fields
        private int borderSize = 2;


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        // Overridden Methods
        protected override void WndProc(ref Message m) {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST) { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        } else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                          {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        } else {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            // Remove the border
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1){
                return;
            }
            base.WndProc(ref m);
        }

        //Resize Form
        // Events Methods
        private void Home_Resize(object sender, EventArgs e) {
            AdjustForm();
        }

        // Private Methods
        private void AdjustForm() {
            switch (this.WindowState) {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize) {
                        this.Padding = new Padding(borderSize);
                    }
                break;
            }
        }


        //Header
        private void pnl_TitleBar_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_Close_Click(object sender, EventArgs e) {
            headerController.Exit();
        }

        private void btn_Maximize_Click(object sender, EventArgs e) {
            headerController.Maximize(ActiveForm);
        }

        private void btn_Minimize_Click(object sender, EventArgs e) {
            headerController.Minimize(ActiveForm);
        }

        
        //Menu
        private void CollapseMenu() {
            if (this.pnl_Menu.Width > 200) { // Collapse Menu
                pnl_Menu.Width = 100;
                img_LogoMenu.Visible = false;
                btn_MenuHamburger.Dock = DockStyle.Top;
                foreach (Button menuButton in pnl_Menu.Controls.OfType<Button>()) {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            } else { // Expand Menu
                pnl_Menu.Width = 230;
                img_LogoMenu.Visible = true;
                btn_MenuHamburger.Dock = DockStyle.None;
                foreach (Button menuButton in pnl_Menu.Controls.OfType<Button>()) {
                    menuButton.Text = "  " +  menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void btn_MenuHamburger_Click(object sender, EventArgs e) {
            CollapseMenu();
        }

        private void btn_MenuCalendar_Click(object sender, EventArgs e) {
            alterPageController.AlterPage(ActiveForm, "calendar");
        }

        private void btn_MenuChat_Click(object sender, EventArgs e) {
            alterPageController.AlterPage(null, "chat");
        }

        private void btn_MenuPacientes_Click(object sender, EventArgs e) {
            alterPageController.AlterPage(ActiveForm, "patients");
        }

        private void btn_MenuOptions_Click(object sender, EventArgs e) {
            alterPageController.AlterPage(ActiveForm, "options");
        }

        private void btn_MenuLogout_Click(object sender, EventArgs e) {
            authenticateController.Logout(ActiveForm);
        }

        private void Render() {
            switch (detailRender) {
                case "patient":
                    PatientsConsult patientsConsult = new PatientsConsult();
                    string[] patientFields = patientsConsult.Patient(idDetailsItem);

                    lbl_Welcome.Text = "Detalhes do Paciente";
                    lbl_DetailsTitle.Text = "Paciente";
                    // CPF
                    lbl_TitleDetail1.Text = "CPF";
                    txt_Detail1.Text = patientFields[0];
                    txt_Detail1.Mask = "000,000,000-00";
                    // RG
                    lbl_TitleDetail2.Text = "RG";
                    txt_Detail2.Text = patientFields[1];
                    txt_Detail2.Mask = "00,000,000-A";
                    // Name
                    lbl_TitleDetail3.Text = "Nome";
                    txt_Detail3.Text = patientFields[2];
                    txt_Detail3.MaxLength = 20;
                    // Last Name
                    lbl_TitleDetail4.Text = "Sobrenome";
                    txt_Detail4.Text = patientFields[3];
                    txt_Detail4.MaxLength = 40;
                    // Nickname
                    lbl_TitleDetail5.Text = "Apelido";
                    txt_Detail5.Text = patientFields[4];
                    txt_Detail3.MaxLength = 20;
                    // Birth Date
                    lbl_TitleDetail6.Text = "Data de Nascimento";
                    string birthDate = patientFields[5];
                    txt_Detail6.Text = birthDate.Substring(0, birthDate.IndexOf(' '));
                    txt_Detail6.Mask = "00/00/0000";
                    // Height
                    lbl_TitleDetail7.Text = "Altura";
                    txt_Detail7.Text = patientFields[6];
                    txt_Detail7.Mask = "0.00";
                    txt_Detail7.MaxLength = 4;
                    // Weight
                    lbl_TitleDetail8.Text = "Peso";
                    txt_Detail8.Text = patientFields[7];
                    txt_Detail8.Mask = "000.00";
                    txt_Detail8.MaxLength = 6;
                    // E-mail
                    lbl_TitleDetail9.Text = "E-mail";
                    txt_Detail9.Text = patientFields[8];
                    txt_Detail9.MaxLength = 40;
                    // Telephone
                    lbl_TitleDetail10.Text = "Telefone";
                    txt_Detail10.Text = patientFields[9];
                    txt_Detail10.Mask = "(00)0000-0000";
                    // Cellphone
                    lbl_TitleDetail11.Text = "Celular";
                    txt_Detail11.Text = patientFields[10];
                    txt_Detail11.Mask = "(00)00000-0000";
                    // Street
                    lbl_TitleDetail12.Text = "Rua";
                    txt_Detail12.Text = patientFields[11];
                    txt_Detail12.MaxLength = 50;
                    // Neighborhood
                    lbl_TitleDetail13.Text = "Bairro";
                    txt_Detail13.Text = patientFields[12];
                    txt_Detail13.MaxLength = 20;
                    // City
                    lbl_TitleDetail14.Text = "Cidade";
                    txt_Detail14.Text = patientFields[13];
                    txt_Detail14.MaxLength = 30;
                    // District
                    lbl_TitleDetail15.Text = "Estado";
                    txt_Detail15.Text = patientFields[14];
                    txt_Detail15.MaxLength = 20;
                    // CEP
                    lbl_TitleDetail16.Text = "CEP";
                    txt_Detail16.Text = patientFields[15];
                    txt_Detail16.Mask = "00,000-000";
                    // Complement
                    lbl_TitleDetail17.Text = "Complemento";
                    txt_Detail17.Text = patientFields[16];
                    txt_Detail17.MaxLength = 15;
                    // Number
                    lbl_TitleDetail18.Text = "Número";
                    txt_Detail18.Text = patientFields[17];
                    txt_Detail18.MaxLength = 4;
                    break;
                case "employee":
                    EmployeesConsult employeesConsult = new EmployeesConsult();
                    string[] employeeFields = employeesConsult.Employee(idDetailsItem);
                    lbl_Welcome.Text = "Detalhes do Funcionário";
                    lbl_DetailsTitle.Text = "Funcionário";
                    // Name
                    lbl_TitleDetail1.Text = "Nome";
                    txt_Detail1.Text = employeeFields[1];
                    txt_Detail1.MaxLength = 20;
                    // Last Name
                    lbl_TitleDetail2.Text = "Sobrenome";
                    txt_Detail2.Text = employeeFields[2];
                    txt_Detail2.MaxLength = 40;
                    // E=mail
                    lbl_TitleDetail3.Text = "E-mail";
                    txt_Detail3.Text = employeeFields[3];
                    txt_Detail3.MaxLength = 40;
                    // Cellhpone
                    lbl_TitleDetail4.Text = "Telefone";
                    txt_Detail4.Text = employeeFields[4];
                    txt_Detail4.Mask = "(00)0000-0000";
                    // Telephone
                    lbl_TitleDetail5.Text = "Celular";
                    txt_Detail5.Text = employeeFields[5];
                    txt_Detail5.Mask = "(00)00000-0000";
                    // CPF
                    lbl_TitleDetail6.Text = "CPF";
                    txt_Detail6.Text = employeeFields[0];
                    txt_Detail6.Mask = "000,000,000-00";
                    lbl_TitleDetail7.Visible = false;
                    lbl_TitleDetail8.Visible = false;
                    lbl_TitleDetail9.Visible = false;
                    lbl_TitleDetail10.Visible = false;
                    lbl_TitleDetail11.Visible = false;
                    lbl_TitleDetail12.Visible = false;
                    lbl_TitleDetail13.Visible = false;
                    lbl_TitleDetail14.Visible = false;
                    lbl_TitleDetail15.Visible = false;
                    lbl_TitleDetail16.Visible = false;
                    lbl_TitleDetail17.Visible = false;
                    lbl_TitleDetail18.Visible = false;
                    txt_Detail7.Visible = false;
                    txt_Detail8.Visible = false;
                    txt_Detail9.Visible = false;
                    txt_Detail10.Visible = false;
                    txt_Detail11.Visible = false;
                    txt_Detail12.Visible = false;
                    txt_Detail13.Visible = false;
                    txt_Detail14.Visible = false;
                    txt_Detail15.Visible = false;
                    txt_Detail16.Visible = false;
                    txt_Detail17.Visible = false;
                    txt_Detail18.Visible = false;
                    tb_Details.AutoScroll = false;
                break;
                case "dentist":
                    string[] employeeFileds = dentistsConsult.Dentist(idDetailsItem);
                    lbl_Welcome.Text = "Detalhes do Dentista";
                    lbl_DetailsTitle.Text = "Dentista";
                    // CRO
                    lbl_TitleDetail1.Text = "CRO";
                    txt_Detail1.Text = employeeFileds[0];
                    txt_Detail1.Mask = "00,000";
                    // Name
                    lbl_TitleDetail2.Text = "Nome";
                    txt_Detail2.Text = employeeFileds[1];
                    txt_Detail2.MaxLength = 20;
                    // Last Name
                    lbl_TitleDetail3.Text = "Sobrenome";
                    txt_Detail3.Text = employeeFileds[2];
                    txt_Detail3.MaxLength = 40;
                    // Expertise
                    lbl_TitleDetail4.Text = "Especialidade";
                    txt_Detail4.Text = employeeFileds[3];
                    txt_Detail4.MaxLength = 15;
                    lbl_TitleDetail5.Visible = false;
                    lbl_TitleDetail6.Visible = false;
                    lbl_TitleDetail7.Visible = false;
                    lbl_TitleDetail8.Visible = false;
                    lbl_TitleDetail9.Visible = false;
                    lbl_TitleDetail10.Visible = false;
                    lbl_TitleDetail11.Visible = false;
                    lbl_TitleDetail12.Visible = false;
                    lbl_TitleDetail13.Visible = false;
                    lbl_TitleDetail14.Visible = false;
                    lbl_TitleDetail15.Visible = false;
                    lbl_TitleDetail16.Visible = false;
                    lbl_TitleDetail17.Visible = false;
                    lbl_TitleDetail18.Visible = false;
                    txt_Detail5.Visible = false;
                    txt_Detail6.Visible = false;
                    txt_Detail7.Visible = false;
                    txt_Detail8.Visible = false;
                    txt_Detail9.Visible = false;
                    txt_Detail10.Visible = false;
                    txt_Detail11.Visible = false;
                    txt_Detail12.Visible = false;
                    txt_Detail13.Visible = false;
                    txt_Detail14.Visible = false;
                    txt_Detail15.Visible = false;
                    txt_Detail16.Visible = false;
                    txt_Detail17.Visible = false;
                    txt_Detail18.Visible = false;
                    tb_Details.AutoScroll = false;
                break;
                case "consult":
                    SchedulingConsult schedulingConsult = new SchedulingConsult();
                    string[] consultFields = schedulingConsult.ClosedConsult(int.Parse(idDetailsItem));
                    lbl_Welcome.Text = "Detalhes da Consulta";
                    lbl_DetailsTitle.Text = "Consulta";
                    // Patient
                    lbl_TitleDetail1.Text = "CPF Paciente";
                    txt_Detail1.Text = consultFields[4];
                    txt_Detail1.Mask = "000,000,000-00";
                    lbl_TitleDetail2.Text = "Nome Paciente";
                    txt_Detail2.Text = consultFields[5];
                    txt_Detail2.MaxLength = 20;
                    // Dentist
                    lbl_TitleDetail3.Text = "CRO Dentista";
                    txt_Detail3.Text = consultFields[2];
                    txt_Detail3.Mask = "00,000";
                    lbl_TitleDetail4.Text = "Nome Dentista";
                    txt_Detail4.Text = consultFields[3];
                    txt_Detail4.MaxLength = 20;
                    // Date and Time
                    lbl_TitleDetail5.Text = "Data";  // time.Substring(time.IndexOf('{') + 1, time.IndexOf('}') - time.IndexOf('{') - 1);                  
                    txt_Detail5.Text = consultFields[0].Substring(0, 10);
                    txt_Detail5.Mask = "00/00/0000";
                    lbl_TitleDetail6.Text = "Horário";
                    txt_Detail6.Text = consultFields[1].Substring(0, 5);
                    txt_Detail6.Mask = "00:00";
                    // Procedure Title
                    lbl_TitleDetail7.Text = "Procedimento";
                    txt_Detail7.Text = consultFields[6];
                    txt_Detail7.MaxLength = 20;
                    // Other Fields
                    lbl_TitleDetail8.Visible = false;
                    lbl_TitleDetail9.Visible = false;
                    lbl_TitleDetail10.Visible = false;
                    lbl_TitleDetail11.Visible = false;
                    lbl_TitleDetail12.Visible = false;
                    lbl_TitleDetail13.Visible = false;
                    lbl_TitleDetail14.Visible = false;
                    lbl_TitleDetail15.Visible = false;
                    lbl_TitleDetail16.Visible = false;
                    lbl_TitleDetail17.Visible = false;
                    lbl_TitleDetail18.Visible = false;
                    txt_Detail8.Visible = false;
                    txt_Detail9.Visible = false;
                    txt_Detail10.Visible = false;
                    txt_Detail11.Visible = false;
                    txt_Detail12.Visible = false;
                    txt_Detail13.Visible = false;
                    txt_Detail14.Visible = false;
                    txt_Detail15.Visible = false;
                    txt_Detail16.Visible = false;
                    txt_Detail17.Visible = false;
                    txt_Detail18.Visible = false;
                    tb_Details.AutoScroll = false;
                break;
                case "consult-category":
                    ProceduresConsult procedureConsult = new ProceduresConsult();
                    string[] procedureFields = procedureConsult.Procedure(int.Parse(idDetailsItem));
                    lbl_Welcome.Text = "Detalhes do Procedimento";
                    lbl_DetailsTitle.Text = "Procedimento";
                    // Title
                    lbl_TitleDetail1.Text = "Título";
                    txt_Detail1.Text = procedureFields[0];
                    txt_Detail1.MaxLength = 20;
                    lbl_TitleDetail2.Visible = false;
                    lbl_TitleDetail3.Visible = false;
                    lbl_TitleDetail4.Visible = false;
                    lbl_TitleDetail5.Visible = false;
                    lbl_TitleDetail6.Visible = false;
                    lbl_TitleDetail7.Visible = false;
                    lbl_TitleDetail8.Visible = false;
                    lbl_TitleDetail9.Visible = false;
                    lbl_TitleDetail10.Visible = false;
                    lbl_TitleDetail11.Visible = false;
                    lbl_TitleDetail12.Visible = false;
                    lbl_TitleDetail13.Visible = false;
                    lbl_TitleDetail14.Visible = false;
                    lbl_TitleDetail15.Visible = false;
                    lbl_TitleDetail16.Visible = false;
                    lbl_TitleDetail17.Visible = false;
                    lbl_TitleDetail18.Visible = false;
                    txt_Detail2.Visible = false;
                    txt_Detail3.Visible = false;
                    txt_Detail4.Visible = false;
                    txt_Detail5.Visible = false;
                    txt_Detail6.Visible = false;
                    txt_Detail7.Visible = false;
                    txt_Detail8.Visible = false;
                    txt_Detail9.Visible = false;
                    txt_Detail10.Visible = false;
                    txt_Detail11.Visible = false;
                    txt_Detail12.Visible = false;
                    txt_Detail13.Visible = false;
                    txt_Detail14.Visible = false;
                    txt_Detail15.Visible = false;
                    txt_Detail16.Visible = false;
                    txt_Detail17.Visible = false;
                    txt_Detail18.Visible = false;
                    tb_Details.AutoScroll = false;
                break;
                default:
                    statusController.PageNotFound();
                break;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e) {
            if (btn_Edit.Text == "Editar") {
                txt_Detail1.Enabled = true;
                txt_Detail2.Enabled = true;
                txt_Detail3.Enabled = true;
                txt_Detail4.Enabled = true;
                txt_Detail5.Enabled = true;
                txt_Detail6.Enabled = true;
                txt_Detail7.Enabled = true;
                txt_Detail8.Enabled = true;
                txt_Detail9.Enabled = true;
                txt_Detail10.Enabled = true;
                txt_Detail11.Enabled = true;
                txt_Detail12.Enabled = true;
                txt_Detail13.Enabled = true;
                txt_Detail14.Enabled = true;
                txt_Detail15.Enabled = true;
                txt_Detail16.Enabled = true;
                txt_Detail17.Enabled = true;
                txt_Detail18.Enabled = true;
                btn_Edit.Text = "Salvar";
            } else if (btn_Edit.Text == "Salvar") {
                switch (detailRender) {
                    case "patient":
                        PatientUpdate patientUpdate = new PatientUpdate();
                        patientUpdate.Patient(idDetailsItem, txt_Detail1.Text, txt_Detail2.Text, txt_Detail3.Text, txt_Detail4.Text, txt_Detail5.Text, txt_Detail6.Text, txt_Detail7.Text, txt_Detail8.Text, txt_Detail9.Text, txt_Detail10.Text, txt_Detail11.Text, txt_Detail12.Text, txt_Detail13.Text, txt_Detail14.Text, txt_Detail15.Text, txt_Detail16.Text, txt_Detail17.Text, int.Parse(txt_Detail18.Text));
                        alterPageController.AlterPage(ActiveForm, "patient-details", idDetailsItem);
                    break;

                    case "employee":
                        EmployeeUpdate employeeUpdate = new EmployeeUpdate();
                        employeeUpdate.Employee(idDetailsItem, txt_Detail6.Text, txt_Detail1.Text, txt_Detail2.Text, txt_Detail3.Text, txt_Detail4.Text, txt_Detail5.Text);
                        alterPageController.AlterPage(ActiveForm, "employee-details", idDetailsItem);
                    break;

                    case "dentist":
                        DentistUpdate dentistUpdate = new DentistUpdate();
                        dentistUpdate.Dentist(idDetailsItem, txt_Detail1.Text, txt_Detail2.Text, txt_Detail3.Text, txt_Detail4.Text);
                        alterPageController.AlterPage(ActiveForm, "dentist-details", idDetailsItem);
                    break;

                    case "consult":
                        ScheduleUpdate scheduleUpdate = new ScheduleUpdate();
                        scheduleUpdate.ScheduleUpdating(txt_Detail1.Text, txt_Detail5.Text, txt_Detail6.Text, int.Parse(idDetailsItem), txt_Detail7.Text);
                        alterPageController.AlterPage(ActiveForm, "consult-details", idDetailsItem);
                    break;

                    case "consult-category":
                        ProcedureUpdate procedureUpdate = new ProcedureUpdate();
                        procedureUpdate.Procedure(int.Parse(idDetailsItem), txt_Detail1.Text);
                        alterPageController.AlterPage(ActiveForm, "consult-category-details", idDetailsItem);
                    break;

                    default:
                        statusController.NonCreated();
                        break;
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e) {
            switch (detailRender) {
                case "patient":
                    alterPageController.AlterPage(ActiveForm, "patients");
                break;

                case "employee":
                    alterPageController.AlterPage(ActiveForm, "employee-list");
                break;

                case "dentist":
                    alterPageController.AlterPage(ActiveForm, "dentists-list");
                break;

                case "consult":
                    alterPageController.AlterPage(ActiveForm, "calendar");
                break;

                case "consult-category":
                    alterPageController.AlterPage(ActiveForm, "consult-category-list");
                break;

                default:
                    statusController.PageNotFound();
                break;
            }
        }

        private void btn_Delet_Click(object sender, EventArgs e) {
            switch (detailRender) {
                case "patient":
                    if (statusController.Warning()) {
                        PatientDelete patientDelete = new PatientDelete();
                        if (patientDelete.Patient(idDetailsItem)) {
                            alterPageController.AlterPage(ActiveForm, "patients");
                        }
                    }
                break;

                case "employee":
                    if (statusController.Warning()) {
                        EmployeeDelete employeeDelete= new EmployeeDelete();
                        if (employeeDelete.Employee(idDetailsItem)) {
                            alterPageController.AlterPage(ActiveForm, "employee-list");
                        }
                    }
                break;

                case "dentist":
                    if (statusController.Warning()) {
                        DentistDelete dentistDelete = new DentistDelete();
                        if (dentistDelete.Dentist(idDetailsItem)) {
                            alterPageController.AlterPage(ActiveForm, "dentists-list");
                        }
                    }
                break;

                case "consult":
                    if (statusController.Warning()) {
                        ConsultDelete consultDelete = new ConsultDelete();
                        if (consultDelete.Consult(int.Parse(idDetailsItem))) {
                            alterPageController.AlterPage(ActiveForm, "calendar");
                        }
                    }
                break;

                case "consult-category":
                    if (statusController.Warning()) {
                        ProcedureDelete procedureDelete = new ProcedureDelete();
                        if (procedureDelete.Procedure(int.Parse(idDetailsItem))) {
                            alterPageController.AlterPage(ActiveForm, "consult-category-list");
                        }
                    }
                break;

                default:
                    statusController.NonDeleted();
                break;
            }
        }
    }
}
