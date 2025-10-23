using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.PLL.Views;
namespace SocialNetwork.PLL.MenuDesign
{
    public class MenuCollection
    {
        public List<MenuItem> _items = new List<MenuItem>();

        public int Count => _items.Count;

        public MenuItem this[int index] => _items[index];

        public void Add(MenuItem item)
        {
            _items.Add(item);
        }

        public class MenuItem
        {
            
            private const string DefaultSuffix = "(нажмите)";
            private const int DefaultNumber = 0;

            public string Text { get; set; }
            public string Suffix { get; set; } = DefaultSuffix;
            public int Number { get; set; } = DefaultNumber;

            public MenuItem()
            {
                Text = string.Empty;
                Suffix = DefaultSuffix;
                Number = DefaultNumber;
            }
           
            public MenuItem(string text, string suffix = DefaultSuffix, int number = DefaultNumber)
            {
                Text = text;
                Suffix = suffix;
                Number = number;
            }
        }
    }

}
