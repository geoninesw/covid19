using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Covid19.Core.PasswordHasher
{
    /// <summary>
    /// https://visualstudiomagazine.com/articles/2016/12/01/hashing-passwords.aspx
    /// </summary>
    public class PasswordHasher
    {
        public static byte[] GetSalt()
        {
            RNGCryptoServiceProvider saltCellar = new RNGCryptoServiceProvider();
            byte[] salt = new byte[24];
            saltCellar.GetBytes(salt);

            return salt;
        }

        public static HashPasswordItem HashPassword(string password, byte[] salt)
        {
            int iteration = 1000;

            Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(password, salt);
            hashTool.IterationCount = iteration;
            byte[] hash = hashTool.GetBytes(24);

            string strSalt = Convert.ToBase64String(salt);
            string strPassword = Convert.ToBase64String(hash);

            HashPasswordItem hashItem = new HashPasswordItem
            {
                SaltByte = salt,
                SaltString = strSalt,
                HashPasswordByte = hash,
                HashPasswordString = strPassword,

                CombineHash = $"{iteration}:{strSalt}:{strPassword}"
            };
            return hashItem;
        }

        public static bool IsPasswordMatch(string testPassword, string storedPassword)
        {
            try
            {
                string[] hashParts = storedPassword.Split(':');
                int iterations = Int32.Parse(hashParts[0]);
                byte[] originalSalt = Convert.FromBase64String(hashParts[1]);
                byte[] originalHash = Convert.FromBase64String(hashParts[2]);

                Rfc2898DeriveBytes hashTool = new Rfc2898DeriveBytes(testPassword, originalSalt);
                hashTool.IterationCount = iterations;
                byte[] testHash = hashTool.GetBytes(originalHash.Length);

                uint differences = (uint)originalHash.Length ^ (uint)testHash.Length;
                for (int position = 0; position < Math.Min(originalHash.Length,
                  testHash.Length); position++)
                    differences |= (uint)(originalHash[position] ^ testHash[position]);
                bool passwordMatches = (differences == 0);

                return passwordMatches;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
