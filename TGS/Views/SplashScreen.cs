using System;
using System.Windows.Forms;
using TGS.Controllers.Main;

namespace TGS.Views {
    public partial class SplashScreen : Form {
        public SplashScreen() {
            InitializeComponent();
        }

        AlterPageController alterPageController = new AlterPageController();

        protected override void WndProc(ref Message m) {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1) {
                return;
            }
            base.WndProc(ref m);
        }

        private void SplashScreen_Shown(object sender, EventArgs e) {
            LoadConfigsController loadConfigs = new LoadConfigsController();
            loadConfigs.Load();
            alterPageController.AlterPage(ActiveForm, "login");
        }
    }
}
