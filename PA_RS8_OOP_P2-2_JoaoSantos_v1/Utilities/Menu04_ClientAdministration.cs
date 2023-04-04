using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu04_ClientAdministration
    {
        public static Dictionary<string, string> Menu4Create()
        {
            Dictionary<string, string> menu4 = new Dictionary<string, string>()
            {
                { "1" , "Criar" },
                { "2" , "ALterar" },
                { "3" , "Consultar" },
                { "4" , "Ativar ou Desativar" },
                { "0" , "Voltar ao Menu Anterior" }
            };
            return menu4;
        }
    }
}
