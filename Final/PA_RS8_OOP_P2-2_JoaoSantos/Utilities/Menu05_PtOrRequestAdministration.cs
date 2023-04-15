using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu05_PtOrRequestAdministration
    {
        public static Dictionary<string, string> Menu5Create()
        {
            Dictionary<string, string> menu4 = new Dictionary<string, string>()
            {
                { "1" , "Criar" },
                { "2" , "Consultar" },
                { "0" , "Voltar ao Menu Anterior" }
            };
            return menu4;
        }
    }
}
