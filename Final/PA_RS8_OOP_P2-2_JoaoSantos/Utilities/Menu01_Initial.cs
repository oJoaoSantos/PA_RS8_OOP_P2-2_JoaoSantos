using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu01_Initial
    {
        public static Dictionary<string, string> Menu1Create()
        {
            Dictionary<string, string> menu1 = new Dictionary<string, string>()
            {
                { "1" , "Inserir Credenciais" },
                { "0" , "Sair" }
            };
            return menu1;
        }
    }
}
