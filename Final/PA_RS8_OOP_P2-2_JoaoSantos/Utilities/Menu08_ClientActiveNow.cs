using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu08_ClientActiveNow
    {
        public static Dictionary<string, string> Menu8Create()
        {
            Dictionary<string, string> menu8 = new Dictionary<string, string>()
            {
                { "1" , "Ativar" },
                { "0" , "Desativar" }
            };
            return menu8;
        }
    }
}
