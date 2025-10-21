using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.MenuDesign
{
    public class MenuData
    {
        public string[] Texts { get; }
        public string[] Suffixes { get; }
        public int[] Numbers { get; }

        public int Count => Texts.Length;

        public MenuData(string[] texts, string[] suffixes, int[] numbers)
        {
            // Проверка длин массивов
            if (texts.Length != suffixes.Length || texts.Length != numbers.Length)
                throw new ArgumentException("Массивы должны быть одинаковой длины!");

            Texts = texts;
            Suffixes = suffixes;
            Numbers = numbers;
        }
    }

}
