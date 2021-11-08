    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;

namespace compSciRevisionTool
{
    class utils
    {
        public static string hashPassword(string password)
        {
            char[] password_chars = password.ToCharArray();
            int[] encryted_key = new int[password.Length];
            string[] hashed_pass = new string[password.Length];
            int[] hashed_passINT = new int[password.Length];
            string finalHashedPassword = "";
            for (int i = 0; i < password_chars.Length; i = i + 1)
            {
                encryted_key[i] = (int)password_chars[i];
                encryted_key[i] = encryted_key[i] + i + 3;
                string binary = Convert.ToString(password_chars[i], 2);
                string keyBinary = Convert.ToString(encryted_key[i], 2);
                hashed_pass[i] = XOR(binary, keyBinary);
                hashed_passINT[i] = Convert.ToInt32(hashed_pass[i], 2);
                hashed_passINT[i] = Convert.ToInt32(hashed_pass[i], 2);
                finalHashedPassword = finalHashedPassword + (char)hashed_passINT[i];
            }

            Debug.WriteLine(finalHashedPassword);
            return finalHashedPassword;
        }

        public static string XOR(string binaryA, string binaryB)
        {
            string returnString = "";
            for (int i = 0; i < binaryA.Length; i = i + 1)
            {
                if (binaryA[i] == '0' && binaryB[i] == '1')
                {
                    returnString = returnString + "1";
                }
                else if(binaryA[i] == '1' && binaryB[i] == '0')
                {
                    returnString = returnString+ "1";
                }
                else
                {
                    returnString = returnString + "0";
                }
            }
            return returnString;
        }
    }
}
