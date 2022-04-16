using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TGS.Controllers.Main;
using TGS.Controllers.Criptography;
using TGS.Controllers.Consult;

namespace TGS.Views {
    public partial class SchedulePage : Form {
        public SchedulePage() {
            InitializeComponent();
            CollapseMenu();

            txt_Date.Text = lbl_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");

            ListRender();

            this.Padding = new Padding(borderSize); // Border Size
            this.BackColor = Color.FromArgb(237, 245, 255); // Border Color
        }

        //Classes
        HeaderController headerController = new HeaderController();
        AuthenticateController authenticateController = new AuthenticateController();
        AlterPageController alterPageController = new AlterPageController();
        SchedulingConsult schedulingConsult = new SchedulingConsult();


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

        private void btn_MenuHome_Click(object sender, EventArgs e) {
            alterPageController.AlterPage(ActiveForm, "home");
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

        private void cb_TypeSchedule_OnSelectedIndexChanged(object sender, EventArgs e) {
            ListRender();
        }      

        private void txt_Date_TextChanged(object sender, EventArgs e) {
            if (txt_Date.Text.Length == 10) {
                ValidateController validateController = new ValidateController();
                if (!validateController.Date(txt_Date.Text)) {
                    txt_Date.Text = lbl_Date.Text;
                }
                ListRender();
            }
        }

        private void btn_Next_Click(object sender, EventArgs e) {
            AddDays(1);
            ListRender();
        }

        private void btn_Return_Click(object sender, EventArgs e) {
            AddDays(-1);
            ListRender();
        }

        private void ListRender() {
            if (txt_Date.Text.Length == 10) {
                if (cb_TypeSchedule.Texts == "Agenda Livre") {
                    lv_Schedule.Clear();
                    lv_Schedule.MultiSelect = true;
                    lv_Schedule.Columns.Add("ID", 0, HorizontalAlignment.Left);
                    lv_Schedule.Columns.Add("Data", 0, HorizontalAlignment.Center);
                    lv_Schedule.Columns.Add("Horário", 140, HorizontalAlignment.Center);
                    lv_Schedule.Columns.Add("Dentista", 400, HorizontalAlignment.Center);
                    List(schedulingConsult.ScheduleOpenedConsult(txt_Date.Text));
                } else {
                    lv_Schedule.Clear();
                    lv_Schedule.MultiSelect = false;
                    lv_Schedule.Columns.Add("ID", 0, HorizontalAlignment.Left);
                    lv_Schedule.Columns.Add("Data", 0, HorizontalAlignment.Center);
                    lv_Schedule.Columns.Add("Horário", 140, HorizontalAlignment.Center);
                    lv_Schedule.Columns.Add("Dentista", 300, HorizontalAlignment.Center);
                    lv_Schedule.Columns.Add("Paciente", 300, HorizontalAlignment.Center);
                    lv_Schedule.Columns.Add("Procedimento", 200, HorizontalAlignment.Center);
                    List(schedulingConsult.ScheduleClosedConsult(txt_Date.Text));
                }
            }
        }

        private void List(string[,] items) {
            if (items != null) {
                for (int i = 0; i < items.GetLength(0); i++) {
                    lv_Schedule.Items.Add(items[i, 0]);
                    for (int j = 1; j < items.GetLength(1); j++) {
                        lv_Schedule.Items[i].SubItems.Add(items[i, j]);
                    }
                }
            }
        }

        private void AddDays(int days) {
            ValidateController validateController = new ValidateController();
            if (validateController.Date(txt_Date.Text)) {
                DateTime date = Convert.ToDateTime(txt_Date.Text);
                string newDate = Convert.ToString(date.AddDays(days));
                txt_Date.Text = newDate.Substring(0, newDate.IndexOf(' '));
            } else {
                txt_Date.Text = lbl_Date.Text;
            }
        }

        private bool ValidateDate(string date) {
            return DateTime.TryParse(date, out DateTime time);
        }

        private void lv_Schedule_ItemActivate(object sender, EventArgs e) {
            if (cb_TypeSchedule.Texts == "Agenda Livre") {


                string date = lv_Schedule.SelectedItems[0].SubItems[1].ToString();
                date = date.Substring(date.IndexOf('{') + 1, date.IndexOf('}') - date.IndexOf('{') - 1);

                string time = lv_Schedule.SelectedItems[0].SubItems[2].ToString();
                time = time.Substring(time.IndexOf('{') + 1, time.IndexOf('}') - time.IndexOf('{') - 1);

                int selectedItem = lv_Schedule.SelectedItems.Count;
                int[] idList = new int[selectedItem];

                for (int i = 0; i < selectedItem; i++) {
                    string id = lv_Schedule.SelectedItems[i].SubItems[0].ToString();
                    idList[i] = int.Parse(id.Substring(id.IndexOf('{') + 1, id.IndexOf('}') - id.IndexOf('{') - 1));
                }
                alterPageController.AlterPage(ActiveForm, "consults-registration", null, date.Substring(0, date.IndexOf(' ')), time, idList);
            } else {
                string id = lv_Schedule.SelectedItems[0].ToString();
                id = id.Substring(id.IndexOf('{') + 1, id.IndexOf('}') - id.IndexOf('{') - 1);
                alterPageController.AlterPage(ActiveForm, "consult-details", id);
            }
        }

        private void btn_OpenSchedule_Click(object sender, EventArgs e) {
            alterPageController.AlterPage(ActiveForm, "schedule-open");
        }
    }
}
