using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.PLL.MenuDesign.MenuCollection;

namespace SocialNetwork.PLL.MenuDesign
{
    public static class MenuFormat
    {
        
        public static void Print(List<MenuItem> items,
                                char symbol = '*',
                                ConsoleColor color = ConsoleColor.Yellow)
        {
            
            if (items == null || !items.Any())
            {
                throw new ArgumentException("Список элементов не может быть пустым");
            }

            PrintInternal(items, symbol, color);
        }



      
        private static void PrintInternal(List<MenuItem> items, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine();

            int maxTextLength = items.Max(i => i.Text.Length);
            int width = maxTextLength + 19;

            Console.WriteLine(new string(symbol, width));

            foreach (var item in items)
            {
                string paddedText = item.Text.PadRight(maxTextLength);

                string displaySuffix = string.IsNullOrEmpty(item.Suffix)
                    ? new string(' ', 9) + item.Number.ToString() +" "
                    : $"{item.Suffix} {item.Number}";

                Console.WriteLine($"{symbol}  {paddedText}  {displaySuffix}  {symbol}  ");
            }

            Console.WriteLine(new string(symbol, width));
            Console.ResetColor();
        }

    }
}