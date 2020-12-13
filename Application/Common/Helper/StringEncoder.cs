using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Common.Helper
{
    public class StringEncoder
    {
        public static string EncodeToBase64String(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
