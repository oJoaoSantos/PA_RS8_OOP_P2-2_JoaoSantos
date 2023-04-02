using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_Client.Structure;
using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RSGymAdministrative_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InitializeData.CreateInitialData();

            Utilities.Basics.SetUniCodeConsole();

            ProgramStructure.RunStructure();
            
            Console.ReadKey();
        }
    }
}
