using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SeminarWebsite
{
    public static class PasswordLottery
    {
        const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string symbolChars = "!@#$%&"; //'!@#$%^&*()_+-={}[]|:;"<>,.?/~';

        //PasswordLotteryFunction
        #region PasswordLotteryFunction
        public static string PasswordLotteryFunction(int lengthPassword = 6)
        {
            var password = "";
            var newPassword = "";
            password += uppercaseChars.ElementAt(new Random().Next(uppercaseChars.Length));
            password += lowercaseChars.ElementAt(new Random().Next(lowercaseChars.Length));
            password += numberChars.ElementAt(new Random().Next(numberChars.Length));
            password += symbolChars.ElementAt(new Random().Next(symbolChars.Length));

            
        for (int index = 0; index < (lengthPassword - 4); index++)
            {
                switch (new Random().Next(4))
                {
                    case 0:
                        password += uppercaseChars.ElementAt(new Random().Next(uppercaseChars.Length));
                        break;
                    case 1:
                        password += lowercaseChars.ElementAt(new Random().Next(lowercaseChars.Length));
                        break;
                    case 2:
                        password += numberChars.ElementAt(new Random().Next(numberChars.Length));
                        break;
                    case 3:
                        password += symbolChars.ElementAt(new Random().Next(symbolChars.Length));
                        break;
                    default:
                        break;
                }
            }

            for (int index = 0; index < lengthPassword; index++)
            {
                var ch = password[new Random().Next(password.Length)];
                newPassword += ch;
                password = password.Substring(0, password.IndexOf(ch)) + password.Substring(password.IndexOf(ch) + 1);
            }
            return newPassword;
        }
        #endregion
    }
}
