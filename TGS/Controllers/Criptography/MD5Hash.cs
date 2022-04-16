using System.Text;
using System.Security.Cryptography;

namespace TGS.Controllers.Criptography {
    class MD5Hash {
        public string CreateMD5Hash(string password) {
            MD5 hashPassword = MD5.Create();
            //Conveter String para array de bytes
            byte[] bytePassword = hashPassword.ComputeHash(Encoding.UTF8.GetBytes(password));
            //Criar um String Builder para recompôr a string
            StringBuilder sBuilder = new StringBuilder();
            //Loop para formatar cada byte como uma string em Hexadecimal
            for (int i = 0; i < bytePassword.Length; i++) {
                sBuilder.Append(bytePassword[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
