using FileSharingSystem.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingSystem.Service
{
	public class HashService : IHashService
	{
		public string HashUserPassword(string plainTextPassword)
		{
			string hashedPassword;
			using (SHA256 sha256Hash = SHA256.Create())
			{
				hashedPassword = GetHash(sha256Hash, plainTextPassword);
			}
			return hashedPassword;
		}
		private static string GetHash(HashAlgorithm hashAlgorithm, string input)
		{
			byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

			StringBuilder? sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}
	}
}
