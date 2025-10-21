using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.MenuDesign
{

    public static class MenuFormat
    {
        public static void Print(List<MenuItem> items)
        {

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();

            int maxTextLength = items.Max(i => i.Text.Length);
            int width = maxTextLength + 18;

            WriteLine(new string('*', width));

            foreach (var item in items)
            {
                string paddedText = item.Text.PadRight(maxTextLength);
              
                string displaySuffix = string.IsNullOrEmpty(item.Suffix)
                    ? new string(' ', 9) + item.Number.ToString()
                    : $"{item.Suffix}{item.Number}";

                WriteLine($"*  {paddedText}  {displaySuffix}  *");
            }

            WriteLine(new string('*', width));
            ResetColor();
        }
    }
}