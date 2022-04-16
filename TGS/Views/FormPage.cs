using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TGS.Controllers.Main;
using TGS.Controllers.Criptography;
using TGS.Controllers.Register;

namespace TGS.Views {
    public partial class FormPage : Form {

        // Classes
        HeaderController headerController = new HeaderController();
        AuthenticateController authenticateController = new AuthenticateController();
        AlterPageController alterPageController = new AlterPageController();
        EmployeesRegistration employeesRegistration = new EmployeesRegistration();
        ConsultsRegistration consultsRegistration = new ConsultsRegistration();
        ProceduresRegistration proceduresRegistration = new ProceduresRegistration();
        PatientsRegistration patientsRegistration = new PatientsRegistration();
        DentistsRegistration dentistsRegistration = new DentistsRegistration();
        StatusController statusController = new StatusController();
        MD5Hash md5Hash = new MD5Hash();

        // Fields
        private int borderSize = 2;
        private string formRender;
        private int formPart = 1;
        private int[] ids;
        private string date, time, id;
        string[] patients = new string[18];

        public FormPage(String form, string dateSchedule = null, string timeSchedule = null, int[] idList = null) {
            formRender = form;
            date = dateSchedule;
            time = timeSchedule;
            ids = idList;
            InitializeComponent();
            Render();
            CollapseMenu();

            lbl_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");

            this.Padding = new Padding(borderSize); // Border Size
            this.BackColor = Color.FromArgb(237, 245, 255); // Border Color

            formPart = 1;
        }

        // Drag Form
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

        // Resize Form
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

        // Header
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

        
        // Menu
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
            DefaultForm();

            switch (formRender) {
                // Employees
                case "employees":
                    lbl_Title.Text = "Cadastro de Funcionários";
                    // Name
                    lbl_Title1.Text = "Nome";
                    txt_Input1.MaxLength = 20;
                    // Last Name
                    lbl_Title2.Text = "Sobrenome";
                    txt_Input2.MaxLength = 40;
                    // E-mail
                    lbl_Title3.Text = "E-mail";
                    txt_Input3.MaxLength = 40;
                    // Telephone
                    lbl_Title4.Text = "Telefone";
                    txt_Input4.Mask = "(00)0000-0000";
                    txt_Input4.MaxLength = 13;
                    // Cellphone
                    lbl_Title5.Text = "Celular";
                    txt_Input5.Mask = "(00)00000-0000";
                    txt_Input5.MaxLength = 14;
                    // CPF
                    lbl_Title6.Text = "CPF";
                    txt_Input6.Mask = "000,000,000-00";
                    txt_Input6.MaxLength = 14;
                    // Password
                    lbl_Title7.Text = "Senha";
                    txt_Input7.PasswordChar = Convert.ToChar("*");
                    txt_Input7.MaxLength = 26;
                    // Other Inputs
                    lbl_Title8.Visible = false;
                    txt_Input8.Visible = false;
                    lbl_Title9.Visible = false;
                    txt_Input9.Visible = false;
                    lbl_Title10.Visible = false;
                    txt_Input10.Visible = false;
                    lbl_Part.Visible = false;
                    break;
                // Dentists
                case "dentists":
                    lbl_Title.Text = "Cadastro de Denstistas";
                    // CRO
                    lbl_Title1.Text = "CRO";
                    txt_Input1.Mask = "00,000";
                    txt_Input1.MaxLength = 6;
                    // Name
                    lbl_Title2.Text = "Nome";
                    txt_Input2.MaxLength = 20;
                    // Last Name
                    lbl_Title3.Text = "Sobrenome";
                    txt_Input3.MaxLength = 40;
                    // Expertise
                    lbl_Title4.Text = "Especialidade";
                    txt_Input4.MaxLength = 15;
                    // Other Inputs
                    lbl_Title5.Visible = false;
                    txt_Input5.Visible = false;
                    lbl_Title6.Visible = false;
                    txt_Input6.Visible = false;
                    lbl_Title7.Visible = false;
                    txt_Input7.Visible = false;
                    lbl_Title8.Visible = false;
                    txt_Input8.Visible = false;
                    lbl_Title9.Visible = false;
                    txt_Input9.Visible = false;
                    lbl_Title10.Visible = false;
                    txt_Input10.Visible = false;
                    lbl_Part.Visible = false;
                    break;
                case "consults-categories":
                    lbl_Title.Text = "Cadastro de Categoria de Consulta";
                    // Title
                    lbl_Title1.Text = "Título da Categoria";
                    txt_Input1.MaxLength = 20;
                    // Other Inputs
                    lbl_Title2.Visible = false;
                    txt_Input2.Visible = false;
                    lbl_Title3.Visible = false;
                    txt_Input3.Visible = false;
                    lbl_Title4.Visible = false;
                    txt_Input4.Visible = false;
                    lbl_Title5.Visible = false;
                    txt_Input5.Visible = false;
                    lbl_Title6.Visible = false;
                    txt_Input6.Visible = false;
                    lbl_Title7.Visible = false;
                    txt_Input7.Visible = false;
                    lbl_Title8.Visible = false;
                    txt_Input8.Visible = false;
                    lbl_Title9.Visible = false;
                    txt_Input9.Visible = false;
                    lbl_Title10.Visible = false;
                    txt_Input10.Visible = false;
                    lbl_Part.Visible = false;
                    break;
                case "patients":
                    lbl_Title.Text = "Cadastro de Pacientes";
                    switch (formPart) {
                        // Basic Data
                        case 1:
                            lbl_TitlePart.Visible = true;
                            lbl_TitlePart.Text = "   Dados Básicos";
                            lbl_Part.Text = "Parte 1 de 3   ";
                            // Name
                            lbl_Title1.Text = "Nome";
                            txt_Input1.MaxLength = 20;
                            // Last Name
                            lbl_Title2.Text = "Sobrenome";
                            txt_Input2.MaxLength = 40;
                            // Nickname
                            lbl_Title3.Text = "Apelido";
                            txt_Input3.MaxLength = 20;
                            // Birth Date
                            lbl_Title4.Text = "Data de Nascimento";
                            txt_Input4.Mask = "00/00/0000";
                            txt_Input4.MaxLength = 10;
                            // CPF
                            lbl_Title5.Text = "CPF";
                            txt_Input5.Mask = "000,000,000-00";
                            txt_Input5.MaxLength = 14;
                            // RG
                            lbl_Title6.Text = "RG";
                            txt_Input6.Mask = "00,000,000-A";
                            txt_Input6.MaxLength = 12;
                            // Height
                            lbl_Title7.Text = "Altura";
                            txt_Input7.Mask = "0.00";
                            txt_Input7.MaxLength = 4;
                            // Weight
                            lbl_Title8.Text = "Peso";
                            txt_Input8.Mask = "000.00";
                            txt_Input8.MaxLength = 6;
                            // Other Inputs
                            lbl_Title9.Visible = false;
                            txt_Input9.Visible = false;
                            lbl_Title10.Visible = false;
                            txt_Input10.Visible = false;
                            btn_Forward.Text = "Avançar";
                            break;
                        // Contact
                        case 2:
                            lbl_TitlePart.Visible = true;
                            lbl_TitlePart.Text = "   Contato";
                            lbl_Part.Text = "Parte 2 de 3   ";
                            // Cellphone
                            lbl_Title1.Text = "Celular";
                            txt_Input1.Mask = "(00)00000-0000";
                            txt_Input1.MaxLength = 14;
                            // Telephone
                            lbl_Title2.Text = "Telefone";
                            txt_Input2.Mask = "(00)0000-0000";
                            txt_Input2.MaxLength = 13;
                            // E-mail
                            lbl_Title3.Text = "E-mail";
                            txt_Input3.MaxLength = 40;
                            // Other Inputs
                            lbl_Title4.Visible = false;
                            txt_Input4.Visible = false;
                            lbl_Title5.Visible = false;
                            txt_Input5.Visible = false;
                            lbl_Title6.Visible = false;
                            txt_Input6.Visible = false;
                            lbl_Title7.Visible = false;
                            txt_Input7.Visible = false;
                            lbl_Title8.Visible = false;
                            txt_Input8.Visible = false;
                            lbl_Title9.Visible = false;
                            txt_Input9.Visible = false;
                            lbl_Title10.Visible = false;
                            txt_Input10.Visible = false;
                            btn_Back.Visible = true;
                            btn_Forward.Text = "Avançar";
                            break;
                        // Address
                        case 3:
                            lbl_TitlePart.Visible = true;
                            lbl_TitlePart.Text = "   Localidade";
                            lbl_Part.Text = "Parte 3 de 3   ";
                            // Street
                            lbl_Title1.Text = "Logradouro";
                            txt_Input1.MaxLength = 50;
                            // Neighborhood
                            lbl_Title2.Text = "Bairro";
                            txt_Input2.MaxLength = 20;
                            // Number
                            lbl_Title3.Text = "Número";
                            txt_Input3.MaxLength = 4;
                            // Complement
                            lbl_Title4.Text = "Complemento";
                            txt_Input4.MaxLength = 15;
                            // City
                            lbl_Title5.Text = "Cidade";
                            txt_Input5.MaxLength = 30;
                            // CEP
                            lbl_Title6.Text = "CEP";
                            txt_Input6.Mask = "00,000-000";
                            txt_Input6.MaxLength = 10;
                            // District
                            lbl_Title7.Text = "Estado";
                            txt_Input7.MaxLength = 20;
                            // Other Inputs
                            lbl_Title8.Visible = false;
                            txt_Input8.Visible = false;
                            lbl_Title9.Visible = false;
                            txt_Input9.Visible = false;
                            lbl_Title10.Visible = false;
                            txt_Input10.Visible = false;
                            btn_Back.Visible = true;
                            break;
                        default:
                            statusController.PageNotFound();
                            break;
                    }
                    break;
                // Schedule
                case "schedule":
                    lbl_TitlePart.Visible = false;
                    lbl_Title.Text = "Abrir Agenda";

                    lbl_Title1.Text = "CRO do Dentista";
                    txt_Input1.Mask = "00,000";

                    lbl_Title2.Text = "Tempo de Consulta";
                    txt_Input2.Mask = "0.00";

                    lbl_Title3.Text = "Data Inicial";
                    txt_Input3.Mask = "00/00/0000";

                    lbl_Title4.Text = "Data Final";
                    txt_Input4.Mask = "00/00/0000";

                    lbl_Title5.Text = "Inicio do Expediente";
                    txt_Input5.Mask = "00:00";

                    lbl_Title6.Text = "Fim do Expediente";
                    txt_Input6.Mask = "00:00";

                    lbl_Title7.Text = "Inicio do Almoço";
                    txt_Input7.Mask = "00:00";

                    lbl_Title8.Text = "Fim do Almoço";
                    txt_Input8.Mask = "00:00";

                    
                    lbl_Title9.Visible = false;
                    txt_Input9.Visible = false;
                    lbl_Title10.Visible = false;
                    txt_Input10.Visible = false;
                    lbl_Part.Visible = false;

                    break;
                // Consults
                case "consults":
                    lbl_TitlePart.Visible = false;
                    lbl_Title.Text = "Cadastro de Consultas";
                    // Patient Name
                    lbl_Title1.Text = "Data";
                    txt_Input1.Mask = "00/00/0000";
                    txt_Input1.Text = date;
                    txt_Input1.Enabled = false;

                    // Date
                    lbl_Title2.Text = "Horário";
                    txt_Input2.Mask = "00:00";
                    txt_Input2.Text = time;
                    txt_Input2.Enabled = false;
                    // Time
                    lbl_Title3.Text = "CPF do Paciente";
                    txt_Input3.Mask = "000,000,000-00";
                    txt_Input3.MaxLength = 14;
                    // Procedure
                    lbl_Title4.Text = "Nome do Procedimento";
                    txt_Input4.MaxLength = 20;
                    // Other Inputs
                    lbl_Title5.Visible = false;
                    txt_Input5.Visible = false;
                    lbl_Title6.Visible = false;
                    txt_Input6.Visible = false;
                    lbl_Title7.Visible = false;
                    txt_Input7.Visible = false;
                    lbl_Title8.Visible = false;
                    txt_Input8.Visible = false;
                    lbl_Title9.Visible = false;
                    txt_Input9.Visible = false;
                    lbl_Title10.Visible = false;
                    txt_Input10.Visible = false;
                    lbl_Part.Visible = false;
                    break;
                default:
                    statusController.PageNotFound();
                    break;
            }
        }

        private void DefaultForm() {
            lbl_TitlePart.Visible = false;
            lbl_TitlePart.Visible = false;
            // Input 1
            lbl_Title1.Visible = true;
            txt_Input1.Visible = true;
            txt_Input1.Text = "";
            txt_Input1.Mask = "";
            // Input 2
            lbl_Title2.Visible = true;
            txt_Input2.Visible = true;
            txt_Input2.Text = "";
            txt_Input2.Mask = "";
            // Input 3
            lbl_Title3.Visible = true;
            txt_Input3.Visible = true;
            txt_Input3.Text = "";
            txt_Input3.Mask = "";
            // Input 4
            lbl_Title4.Visible = true;
            txt_Input4.Visible = true;
            txt_Input4.Text = "";
            txt_Input4.Mask = "";
            // Input 5
            lbl_Title5.Visible = true;
            txt_Input5.Visible = true;
            txt_Input5.Text = "";
            txt_Input5.Mask = "";
            // Input 6
            lbl_Title6.Visible = true;
            txt_Input6.Visible = true;
            txt_Input6.Text = "";
            txt_Input6.Mask = "";
            // Input 7
            lbl_Title7.Visible = true;
            txt_Input7.Visible = true;
            txt_Input7.Text = "";
            txt_Input7.Mask = "";
            // Input 8
            lbl_Title8.Visible = true;
            txt_Input8.Visible = true;
            txt_Input8.Text = "";
            txt_Input8.Mask = "";
            // Input 9
            lbl_Title9.Visible = true;
            txt_Input9.Visible = true;
            txt_Input9.Text = "";
            txt_Input9.Mask = "";
            // Input 10
            lbl_Title10.Visible = true;
            txt_Input10.Visible = true;
            txt_Input10.Text = "";
            txt_Input10.Mask = "";

            lbl_Part.Visible = true;
            btn_Back.Visible = false;
            btn_Forward.Text = "Cadastrar";
        }

        private void btn_Forward_Click(object sender, EventArgs e) {
            if(btn_Forward.Text == "Cadastrar") {
                switch (formRender) {
                    case "employees":                        
                        if (employeesRegistration.EmployeeRegistration(txt_Input6.Text, txt_Input1.Text, txt_Input2.Text, txt_Input3.Text, txt_Input4.Text, txt_Input5.Text, txt_Input7.Text)) {
                            alterPageController.AlterPage(ActiveForm, "employee-list");
                        }
                        break;
                    case "consults-categories":
                        if (proceduresRegistration.ProcedureRegistration(txt_Input1.Text)) {
                            alterPageController.AlterPage(ActiveForm, "consult-category-list");
                        }
                        break;
                    case "dentists":
                        if (dentistsRegistration.DentistRegistration(txt_Input1.Text, txt_Input2.Text, txt_Input3.Text, txt_Input4.Text)) {
                            alterPageController.AlterPage(ActiveForm, "dentists-list");
                        }
                        break;
                    case "patients":
                        patients[11] = txt_Input1.Text;
                        patients[12] = txt_Input2.Text;
                        patients[13] = txt_Input5.Text;
                        patients[14] = txt_Input7.Text;
                        patients[15] = txt_Input6.Text;
                        patients[16] = txt_Input4.Text;
                        patients[17] = txt_Input3.Text;
                        if (patientsRegistration.PatientRegistration(patients[0], patients[1], patients[2], patients[3], patients[4], patients[5], patients[6], patients[7], patients[8], patients[9], patients[10], patients[11], patients[12], patients[13], patients[14], patients[15], patients[16], patients[17])) {
                            alterPageController.AlterPage(ActiveForm, "patients");
                        }
                        break;
                    case "schedule":
                        if (consultsRegistration.ConsultOpen(txt_Input1.Text, txt_Input2.Text, txt_Input3.Text, txt_Input4.Text, txt_Input5.Text, txt_Input6.Text, txt_Input7.Text, txt_Input8.Text)) {
                            alterPageController.AlterPage(ActiveForm, "calendar");
                        }
                        break;
                    case "consults":
                        if (consultsRegistration.ConsultRegistration(txt_Input3.Text, txt_Input4.Text, ids)) {
                            alterPageController.AlterPage(ActiveForm, "calendar");
                        }
                        break;
                    default:
                        statusController.PageNotFound();
                        break;
                }
            } else if(btn_Forward.Text == "Avançar") {
                switch (formPart) {
                    case 1:
                        patients[0] = txt_Input5.Text;
                        patients[1] = txt_Input6.Text;
                        patients[2] = txt_Input1.Text;
                        patients[3] = txt_Input2.Text;
                        patients[4] = txt_Input3.Text;
                        patients[5] = txt_Input4.Text;
                        patients[6] = txt_Input7.Text;
                        patients[7] = txt_Input8.Text;
                        break;
                    case 2:
                        patients[8] = txt_Input3.Text;
                        patients[9] = txt_Input2.Text;
                        patients[10] = txt_Input1.Text;
                        break;
                    default:
                        statusController.PageNotFound();
                        break;
                }
                formPart++;
                Render();
            } else {
                statusController.InternalError();
            }
        }
        private void btn_Back_Click(object sender, EventArgs e) {
            formPart--;
            Render();
        }
    }
}
