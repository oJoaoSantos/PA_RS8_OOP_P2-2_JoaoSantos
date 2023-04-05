using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Menu06_UserPermissionType
    {
        public static Dictionary<string, string> Menu6Create()
        {
            Dictionary<string, string> menu6 = new Dictionary<string, string>()
            {
                { "1" , "Admin" },
                { "2" , "Colab" }
            };
            return menu6;
        }
    }
}
