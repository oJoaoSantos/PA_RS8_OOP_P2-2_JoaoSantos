using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu03_UserAdministration
    {
        public static Dictionary<string, string> Menu3Create()
        {
            Dictionary<string, string> menu3 = new Dictionary<string, string>()
            {
                { "1" , "Criar" },
                { "2" , "ALterar" },
                { "3" , "Consultar" },
                { "0" , "Voltar ao Menu Anterior" }
            };
            return menu3;
        }
    }
}
