using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Commonm
{
public   class HashingUtility
    {
    public static string GetHash(string text)
    {
        var salt = Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        var result = GenerateSaltedHash(text,salt);

        return result;
    }

        static string GenerateSaltedHash(string  plainText,string salt)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return string.Join("", hash
                  .ComputeHash(Encoding.UTF8.GetBytes(plainText+"^"+salt))
                  .Select(item => item.ToString("x2")));
            }
        }
    }
}
