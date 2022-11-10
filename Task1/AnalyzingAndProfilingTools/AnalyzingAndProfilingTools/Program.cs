using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AnalyzingAndProfilingTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iterCount = 1000;
            var salt = PasswordHelper.GetSalt(16);
            var passwordText = "password1234";
            PasswordHelper.GeneratePasswordHashUsingSalt(passwordText, salt);
            PasswordHelper.GeneratePasswordHashUsingSaltMark2(passwordText, salt);

            var result1 = new Stopwatch();
            result1.Start();
            for (int i = 0; i < iterCount; i++)
            {
                PasswordHelper.GeneratePasswordHashUsingSalt(passwordText, salt);
            }
            result1.Stop();

            Console.WriteLine($"Rfc2898DeriveBytes result: {result1.Elapsed / iterCount}");

            var result2 = new Stopwatch();
            result2.Start();
            for (int i = 0; i < iterCount; i++)
            {
                PasswordHelper.GeneratePasswordHashUsingSaltMark2(passwordText, salt);
            }
            result2.Stop();

            Console.WriteLine($"UnmanagedPBKDF2 result: {result2.Elapsed / iterCount}");

            var result3 = new Stopwatch();
            result3.Start();
            for (int i = 0; i < iterCount; i++)
            {
                PasswordHelper.GeneratePasswordHashUsingSaltMark3(passwordText, salt);
            }
            result3.Stop();

            Console.WriteLine($"KeyDerivation result: {result3.Elapsed / iterCount}");
        }
    }
}
