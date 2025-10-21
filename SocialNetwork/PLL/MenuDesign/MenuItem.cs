using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.PLL.Views;
namespace SocialNetwork.PLL.MenuDesign
{
    public class MenuItem
    {
        public string? Text { get; set; }
        public string Suffix { get; set; } = string.Empty;
        public int Number { get; set; }


        public static List<MenuItem> CreateFromData(MenuData data)
        {
            var items = new List<MenuItem>();
            for (int i = 0; i < data.Count; i++)  
            {
                items.Add(new MenuItem
                {
                    Text = data.Texts[i],
                    Suffix = data.Suffixes[i],
                    Number = data.Numbers[i]
                });
            }
            return items;
        }
    }
}
 