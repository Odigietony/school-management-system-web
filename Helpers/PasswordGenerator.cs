using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Helpers
{
    public class PasswordGenerator : IPasswordGenerator
    {
        Random random = new Random();
        private string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private string Digits = "0123456789";
        private string Symbols = "~!@#$%^&*()_-+=}{[]?";
        public string GeneratePassword(int length)
        {
            char[] uppercase = Uppercase.ToCharArray();
            char[] lowercase = Lowercase.ToCharArray();
            char[] digits = Digits.ToCharArray();
            char[] symbols =  Symbols.ToCharArray(); 
            List<char> password = new List<char>(); 
            password.Insert(random.Next(0, password.Count), uppercase[random.Next(0, uppercase.Length)]);
            password.Insert(random.Next(0, password.Count), lowercase[random.Next(0, lowercase.Length)]);
            password.Insert(random.Next(0, password.Count), digits[random.Next(0, digits.Length)]);
            password.Insert(random.Next(0, password.Count), symbols[random.Next(0, symbols.Length)]);
            for(int count = password.Count; count < length; count++)
            {
                string randomStrings = uppercase[random.Next(0, uppercase.Length)].ToString() + 
                                        lowercase[random.Next(0, lowercase.Length)].ToString() + 
                                        digits[random.Next(0, digits.Length)].ToString() + 
                                        symbols[random.Next(0, symbols.Length)].ToString();
                password.Insert(random.Next(0, password.Count), randomStrings[random.Next(0, randomStrings.Length)]);
            }
            return new string(password.ToArray());
        }

        public string GenerateUsernameFromEmail(string emailAddress)
        {
            string[] usernameChars = emailAddress.ToString().Split("@");
            string username = usernameChars[0].ToString();
            return username + random.Next(1000, 9999);
        }
    }
}