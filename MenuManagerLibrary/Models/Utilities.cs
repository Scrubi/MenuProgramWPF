using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;

namespace MenuManagerLibrary
{
    public class Utilities
    {
        public static string TrimString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return str.Trim();
        }

        public static string ToLowerCase(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return str.ToLower();
        }

        public static string UpperCaseFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            
            char[] letters = str.ToCharArray();
            
            letters[0] = char.ToUpper(letters[0]);
            
            return new string(letters);
        }

        public static string TrimLowerCaseString(string str)
        {
            string inputTrimmed = ToLowerCase(TrimString(str));
            return inputTrimmed;
        }

        public static bool IsDouble(string input)
        {
            double output;
            bool isDouble = Double.TryParse(input, out output);
            return isDouble;
        }

        public static bool CheckNameValidity(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return true;
        }
    }
}
