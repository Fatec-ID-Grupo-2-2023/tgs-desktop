using System.Windows.Forms;
using TGS.Controllers.Criptography;

namespace TGS.Controllers.Main {
    class HeaderController {

        // Classes
        AuthenticateController authenticateController = new AuthenticateController();
        StatusController statusController = new StatusController();

        public void Exit() {
            if (statusController.Exit()) {
                authenticateController.DestroySession();
                Application.Exit();
            }
        }

        public void Maximize(Form form) {
            if (form.WindowState == FormWindowState.Normal) {
                form.WindowState = FormWindowState.Maximized;
            } else {
                form.WindowState = FormWindowState.Normal;
            }
        }

        public void Minimize(Form form) {
            form.WindowState = FormWindowState.Minimized;
        }
    }
}
