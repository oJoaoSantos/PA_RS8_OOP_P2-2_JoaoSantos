using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu01_Initial
    {
        public static Dictionary<int, string> Menu1Create()
        {
            Dictionary<int, string> menu1 = new Dictionary<int, string>()
            {
                { 1 , "Inserir Credenciais " },
                { 2 , "Sair " }
            };
            return menu1;
        }
    }
}
