using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashingLibrary
{
    //This function is used for hashing the passwords and securely storing them
    public class HashingFunction
    {
        //This algorithm is used for hasing using sha encryption
        public string HashingAlgorithm(string value, string stringSalt)
        {
            using (var sha = new SHA512CryptoServiceProvider())
            {
                //string with input is combined with stringSalt to generate encoded password
                var hashed_String = sha.ComputeHash(Encoding.Default.GetBytes(value + stringSalt));
                return Convert.ToBase64String(hashed_String);
            }
        }
    }
}
