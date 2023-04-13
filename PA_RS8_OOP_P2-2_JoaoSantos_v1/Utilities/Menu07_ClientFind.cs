using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu07_ClientFind
    {
        public static Dictionary<string, string> Menu7Create()
        {
            Dictionary<string, string> menu7 = new Dictionary<string, string>()
            {
                { "1" , "Sim" },
                { "0" , "Não" }
            };
            return menu7;
        }
    }
}
