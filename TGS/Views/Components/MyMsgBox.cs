using System;
using System.Windows.Forms;

namespace TGS.Views.Components {
    public partial class MyMsgBox : Form {
        public MyMsgBox() {
            InitializeComponent();
        }

        // Remove the border
        protected override void WndProc(ref Message m) {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1) {
                return;
            }
            base.WndProc(ref m);
        }

        // Body
        public DialogResult Result {
            get;
            private set;
        }

        public static DialogResult Show(string message, string title = null, bool buttons = false) {
            var MsgBox = new MyMsgBox();
            MsgBox.lbl_MsgBoxTitle.Text = title;
            MsgBox.lbl_MsgBoxMessage.Text = message;

            if (!buttons) {
                MsgBox.timer.Enabled = true;
                MsgBox.btn_Yes.Visible = false;
                MsgBox.btn_No.Visible = false;
            }

            MsgBox.ShowDialog();
            return MsgBox.Result;
        }


        

        private void btn_Yes_Click(object sender, EventArgs e) {
            Result = DialogResult.Yes;
            Close();
        }

        private void iconButton1_Click(object sender, EventArgs e) {
            Result = DialogResult.No;
            Close();
        }

        private void timer_Tick(object sender, EventArgs e) {
            Close();
        }
    }
}
