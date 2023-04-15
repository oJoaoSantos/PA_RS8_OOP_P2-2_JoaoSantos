using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_Client.Structure;
using System;

namespace RSGymAdministrative_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utilities.Basics.SetUniCodeConsole();
            try
            {
                InitializeData.CreateInitialData();

                ProgramStructure.RunStructure();
            }
            catch (Exception)
            {
                Console.WriteLine("Aconteceu um erro.");
                throw;
            }
        }
    }
}
