    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Drawing;

namespace compSciRevisionTool
{
    class utils
    {
        public static string hashPassword(string password)
        {
            char[] password_chars = password.ToCharArray();
            char[] reversepassword_chars = reverseLetters(bubbleSortLetters(password)).ToCharArray();
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
                string reverseBinary = Convert.ToString(reversepassword_chars[i], 2);
                hashed_pass[i] = XOR(binary, keyBinary);
                hashed_passINT[i] = Convert.ToInt32(hashed_pass[i], 2);
                finalHashedPassword = finalHashedPassword + Convert.ToInt32(XOR(hashed_pass[i], reverseBinary), 2);
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

        //private string[] updateCorrectQuestion(int topicID)
        //{
        //    SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Documents\RevisionStorageDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming

        //        Connection.Open();
        //        string query = "INSERT into UserTable (username, password) values('" + usernameInput + "', '" + passwordInput + "')";
        //        SqlCommand cmd = new SqlCommand(query, Connection);
        //        cmd.ExecuteNonQuery();
        //        Connection.Close();

        //    Connection.Open();
        //    string SQLquery = "Select * from UserTable where username= '" + usernameInput + "' and password= '" + passwordInput + "'";
        //    SqlCommand cmd = new SqlCommand(SQLquery, Connection);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //}

        public static string reverseLetters(string word) 
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string bubbleSortLetters(string word)
        {
            char[] characters = word.ToCharArray(); ;
            int itemCount = characters.Length;
            int[] numbers = new int[itemCount];
            string returnstring = "";
            for (int i = 0; i < itemCount; i = i + 1)
            {
                numbers[i] = ((int)characters[i]);
            }

            for (int j = 0; j < numbers.Length - 1; j = j + 1)
            {
                for (int i = 0; i < numbers.Length - 1; i = i + 1)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = temp;
                    }
                }
            }

            for (int i = 0; i < characters.Length; i = i + 1)
            {
                returnstring = returnstring + ((char)numbers[i]);
            }

            return returnstring;
        }


        public static Bitmap ScaleImage(Bitmap bmp, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / bmp.Width;
            var ratioY = (double)maxHeight / bmp.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(bmp.Width * ratio);
            var newHeight = (int)(bmp.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(bmp, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        public static bool regulateStringInput(string input, int minLen, int maxLen, int charNum = 0, int numNum = 0, int specNum = 0)
        {
            int charNumCount = 0;
            int numNumCount = 0;
            int specNumCount = 0;
            int totalCount = input.Length;

            for (int i = 0; i < input.Length; i = i + 1)
            {
                int asciiVal = (int)input[i];

                if (asciiVal >= 65 && asciiVal <= 90 || asciiVal >= 97 && asciiVal <= 122)
                {
                    charNumCount++;
                }

                if (asciiVal >= 48 && asciiVal <= 57)
                {
                    numNumCount++;
                }

                if (asciiVal >= 123 && asciiVal <= 126 || asciiVal >= 91 && asciiVal <= 96 || asciiVal >= 58 && asciiVal <= 64 || asciiVal >= 32 && asciiVal <= 47)
                {
                    specNumCount++;
                }
            }

            if (charNum <= charNumCount && numNum <= numNumCount && specNum <= specNumCount && minLen <= totalCount && maxLen >= totalCount)
            {
                return true;
            }
            return false;
        }

        public static void msg(string _daMessageToDisplay, string _subcolour = "4")
        {
            messgaeBox box = new messgaeBox(_daMessageToDisplay, _subcolour);
        }

        public static int getUserID()
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ham7a\Documents\lapRevisionToolDB.mdf;Integrated Security=True;Connect Timeout=30"); // should be made with the declerations but is here to stop errors as the table doesn't exist at the time of programming
            Connection.Open();
            string SQLquery = "Select * from currentUserTable where Id= 1";
            SqlCommand cmd = new SqlCommand(SQLquery, Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int toReturn = Convert.ToInt32(dr["userID"]);
            dr.Close();
            Debug.WriteLine("THE USER ID IS: " + toReturn);
            return toReturn;
        }
    }
}
