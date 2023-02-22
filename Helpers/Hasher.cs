using System.Security.Cryptography;
using System.Text;

namespace Clocker.Helpers
{
    public class Hasher
    {

        public static string MD5Hash(string plainText)
        {
            if(String.IsNullOrEmpty(plainText))
            {
                return "";
            }
           
                StringBuilder sb = new StringBuilder();

                // Initialize a MD5 hash object
                using (MD5 md5 = MD5.Create())
                {
                    // Compute the hash of the given string
                    byte[] hashValue = md5.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                    // Convert the byte array to string format
                    foreach (byte b in hashValue)
                    {
                        sb.Append($"{b:X2}");
                    }
                }

                return sb.ToString().ToLower();
        }
    }
}
