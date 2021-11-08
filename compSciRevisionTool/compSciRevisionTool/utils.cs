    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace compSciRevisionTool
{
    class utils
    {
        public static string hashPassword(string password)
        {
            char[] password_chars = password.ToCharArray();
            int[] encryted_key = new int[password.Length]; ;
            for (int i = 0; i < password_chars.Length; i = i + 1)
            {
                encryted_key[i] = (int)password_chars[i];
                encryted_key[i] = encryted_key[i] + i;
                encryted_key[i] = encryted_key[i] + 3;
            }
        }
    }
}
