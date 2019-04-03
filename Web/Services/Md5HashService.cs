using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Web.Services
{
    public class Md5HashService
    {
        public string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
            byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(input));

            var sb = new StringBuilder();

            foreach (var d in data)
            {
                sb.Append(d.ToString("x2"));
            }

            return sb.ToString();
        }

        public bool CompareHash(string input, string hash)
        {
            var inputHash = GetMd5Hash(input);

            return string.Equals(inputHash, hash);
        }
    }
}
