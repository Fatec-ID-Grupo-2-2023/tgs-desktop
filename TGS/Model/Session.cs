namespace TGS.Model {
    public class Session {
        private static string name;
        private static string cpf;

        public static string Name {
            get {return Session.name;}
            set {Session.name = value;}
        }

        public static string CPF {
            get {return Session.cpf;}
            set {Session.cpf = value;}
        }
    }
}
