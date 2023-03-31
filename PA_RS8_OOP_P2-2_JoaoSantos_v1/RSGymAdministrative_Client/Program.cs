using RSGymAdministrative_Client.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgramStructure.CreateInitialData();

            Console.ReadKey();
        }
    }
}
