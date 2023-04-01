using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Validations
    {
        public static string MenuOptionReaded(Dictionary<int, string> menu, string readed)
        {
            if (int.TryParse(readed, out int converted) && menu.ContainsKey(converted))
            {
                return "ok";
            }
            else
            {
                return "Opção inválida";
            };
        }

        public static void ValidateLogIn()
        { 
        
        }
    }
}
