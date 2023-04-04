using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu02_General
    {
        public static Dictionary<string, string> Menu2AdminCreate()
        {
            Dictionary<string, string> menu2Admin = new Dictionary<string, string>()
            {
                { "1" , "Colaboradores" },
                { "2" , "Clientes" },
                { "3" , "Peersonal Trainers" },
                { "4" , "Pedidos" },
                { "0" , "Log Out" }
            };
            return menu2Admin;
        }

        public static Dictionary<string, string> Menu2ColabCreate()
        {
            Dictionary<string, string> menu2Colab = new Dictionary<string, string>()
            {
                { "1" , "Clientes" },
                { "2" , "Peersonal Trainers" },
                { "3" , "Pedidos" },
                { "0" , "Log Out" }
            };
            return menu2Colab;
        }
    }
}
