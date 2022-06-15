using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace P_Jass
{
    class Encode
    {
        /*public static string ProtectPassword(string clearPassword)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(clearPassword);
            byte[] protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedBytes);
        }

        public static string UnprotectPassword(string protectedPassword)
        {
            byte[] protectedBytes = Convert.FromBase64String(protectedPassword);
            byte[] bytes = ProtectedData.Unprotect(protectedBytes, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(bytes);
        }*/




        public static void EncodeString(string str)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
                rngCsp.
            }
            System.Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");


            /*
            Encoding encoding = Encoding.ASCII;

            Byte[] allCharactersFromEncoder = encoding.GetBytes(str);
            ShowArray(allCharactersFromEncoder);

            Encoder encoder = encoding.GetEncoder();


            bool bFlushState = false;*/
        }

        public static void ShowArray(Array theArray)
        {
            foreach (Object o in theArray)
            {
                System.Console.Write("[{0}]", o);
            }
            System.Console.WriteLine("\n");
        }
    }
}
