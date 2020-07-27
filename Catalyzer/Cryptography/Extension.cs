using System;
using System.Security.Cryptography;
using System.Text;

namespace Catalyzer.Cryptography
{
    public static class Extension
    {
        public static string MD5(this string content, string salt = null)
        {
            using (var provider = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(content + salt))).Replace("-", "");
            }
        }

        public static string SHA1(this string content, string salt = null)
        {
            using (var provider = new SHA1CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(content + salt))).Replace("-", "");
            }
        }

        public static string SHA256(this string content, string salt = null)
        {
            using (var provider = new SHA256CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(content + salt))).Replace("-", "");
            }
        }

        public static string SHA384(this string content, string salt = null)
        {
            using (var provider = new SHA384CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(content + salt))).Replace("-", "");
            }
        }

        public static string SHA512(this string content, string salt = null)
        {
            using (var provider = new SHA512CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(content + salt))).Replace("-", "");
            }
        }

        public static string ToBase64(this string content)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(content));
        }

        public static string FromBase64(this string content)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(content));
        }
    }
}