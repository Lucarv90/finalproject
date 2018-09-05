using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Projeto.UTIL
{
    public class Criptografia
    {
        public string EncriptarSenha(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
           
            byte[] hash = md5.ComputeHash(senhaBytes);
            
            string resultado = string.Empty;
            foreach (byte b in hash)
            {
                resultado += b.ToString("x");
            }
            return resultado; 
        }
    }
}
