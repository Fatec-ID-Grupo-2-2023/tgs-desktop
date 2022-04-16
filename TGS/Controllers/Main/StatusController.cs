using System.Windows.Forms;
using TGS.Views.Components;

namespace TGS.Controllers.Main {
    public class StatusController {
        public void PageNotFound() {
            MyMsgBox.Show("Página não encontrada!", "404");
        }

        public void Created() {
            MyMsgBox.Show("Cadastrado com sucesso!", "201");   
        }

        public void NonCreated() {
            MyMsgBox.Show("Cadastro não realizado!","400");
        }

        public void Updated() {
            MyMsgBox.Show("Cadastro atualizado com sucesso!", "201");
        }

        public void NonUpdated() {
            MyMsgBox.Show("Cadastro não atualizado!", "400");
        }

        public void LoginFail() {
            MyMsgBox.Show("E-mail e/ou senha inválido(s)!", "401");
        }

        public void Unauthorized() {
            MyMsgBox.Show("Acesso não permitido!", "401");
        }

        public void InternalError() {
            MyMsgBox.Show("Erro interno!", "500");
        }

        public void NotAcceptable() {
            MyMsgBox.Show("Dados Inválidos!", "406");
        }

        public void Deleted() {
            MyMsgBox.Show("Cadastro deletado!", "201");
        }

        public void NonDeleted() {
            MyMsgBox.Show("Cadastro não deletado!", "400");
        }

        public bool Exit() {
            return MyMsgBox.Show("Deseja realmente sair?", "", true) == DialogResult.Yes;
        }

        public bool Warning() {
            return MyMsgBox.Show("Deseja realmente excluir esse registro?", "Alerta", true) == DialogResult.Yes;
        }
    }
}
