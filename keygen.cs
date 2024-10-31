using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System;

namespace HelloWorld
{
	public class Program
	{
		public static void Main(string[] args)
    {
        var generatedKey = GenerateKey();
        Console.WriteLine(generatedKey);
    }

    public static string GenerateKey()
    {
      var numArray1 = new[] { 1, 2, 5, 7, 9, 11, 12, 13, 15, 16, 17, 19, 21, 22, 24, 25, 26, 29, 30, 31 };

			var numArray2 = new[] { 22, 23, 28, 32, 13, 33, 24, 30, 21, 29, 34, 17, 20, 27, 10, 4, 26, 11, 14, 8 };

			var calculatedHashUpper = GetMd5Hash("vadimua757@gmail.com" + ":fazilkapunjabcivillinestuneblade", false).ToUpper();

			var generatedKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
			
			for (var index = 0; index < numArray2.Length; ++index)
			{
				var num2 = numArray2[index];
				var num1 = numArray1[index];

				generatedKey = generatedKey.Remove(num2, 1).Insert(num2, calculatedHashUpper[num1] + "");
			}
			 
		  return new string(generatedKey);

    }
    public static string GetMd5Hash(string input, bool upperCase)
		{
			var hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input));
			var stringBuilder = new StringBuilder();

			foreach (var t in hash)
			{
				stringBuilder.Append(upperCase ? t.ToString("X2") : t.ToString("x2"));
			}

			return stringBuilder.ToString();
		}

		public static bool IsValidEmail(string email)
		{
			return email.Length >= 5 && email.Contains<char>('@') && email.Contains<char>('.');
		}

	}
}
