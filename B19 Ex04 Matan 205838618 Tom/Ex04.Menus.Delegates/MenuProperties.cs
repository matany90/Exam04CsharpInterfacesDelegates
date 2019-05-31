using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    class MenuProperties
    {        
        public int ShowMenuAndGetChoiceFromUser(List<MenuItem> i_MenuItems, bool isFirstLevel)
        {
            Console.Clear();
            string allOptions = string.Empty;
            int index = 1;

            foreach (MenuItem menuItem in i_MenuItems)
            {
                allOptions += index + ". " + menuItem.ItemName + Environment.NewLine;
                index++;
            }
            if (isFirstLevel)
            {
                allOptions += "0. Exit";
            }
            else
            {
                allOptions += "0. Back";
            }

            int? RangeMinValue = 0, RangeMaxValue = i_MenuItems.Count;
            Console.WriteLine(string.Format(
@"Please select one of the options ({0}-{1}), then press enter:
{2}", RangeMinValue, RangeMaxValue, allOptions));

            return int.Parse(ConsoleUtils.InputValidation(Console.ReadLine(), eValidationOptions.NumbersInRange, RangeMinValue, RangeMaxValue));
        }
    }
}
