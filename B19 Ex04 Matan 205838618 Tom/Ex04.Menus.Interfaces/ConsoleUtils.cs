using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ex04.Menus.Interfaces
{
    static class ConsoleUtils
    {
        public static string InputValidation(string i_ToCheck, eValidationOptions i_ValidationType, int? i_RangeMinValue = null, int? i_RangeMaxValue = null)
        {
            string regexPattern = string.Empty;
            string errorToShow = string.Empty;
           
            switch (i_ValidationType)
            {
                case eValidationOptions.YesNoQuestion:
                    regexPattern = "^[y|n|Y|N]{1}$";
                    errorToShow = "Invalid Input. Please choose between Y/N, try again and then press enter:";
                    break;
                case eValidationOptions.NumbersInRange:
                    regexPattern = "^[" + i_RangeMinValue + "-" + i_RangeMaxValue + "]{1}$";
                    errorToShow = string.Format(
@"Invalid Input. The input should be in the number range {0}-{1}, try again and then press enter: ", i_RangeMinValue, i_RangeMaxValue);
                    break;
                default:
                    break;
            }

            while (!Regex.IsMatch(i_ToCheck, regexPattern))
            {
                Console.WriteLine(errorToShow);
                i_ToCheck = Console.ReadLine();
            }

            return i_ToCheck.ToLower();
        }
    }
}
