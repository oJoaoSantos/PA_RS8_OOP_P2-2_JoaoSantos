using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Structure
{
    public class ProgramStructure
    {
        public static void RunStructure()
        {
            string choiceMenu01 = "";
            do
            {
                #region Menu01 Initial
                choiceMenu01 = Menus.InitialMenu();
                #endregion

                if (choiceMenu01 == "1")
                {
                    #region LogIn
                    string userType = Menus.LogIn();
                    #endregion

                    #region Menu02 General Admin
                    if (userType == "Admin")
                    {
                        string choiceMenu02Admin = "";
                        while (choiceMenu02Admin != "0")
                        {
                            Console.Clear();
                            choiceMenu02Admin = Menus.GeneralMenuAdmin();
                            if (choiceMenu02Admin != "0")
                            {
                                #region Menu03 User Administration
                                string choiceMenu03UserAdministration = "";
                                while (choiceMenu03UserAdministration != "0")
                                {
                                    choiceMenu03UserAdministration = Menus.UserAdministrationMenu();
                                };
                                #endregion
                                #region Menu04 Client Administration

                                #endregion

                                #region Menu05 PT Administration

                                #endregion

                                #region Menu06 Request Administration

                                #endregion
                            }
                        };


                    }
                    #endregion

                    #region Menu02 General Colab
                    else if (userType == "Colab")
                    {
                        string choiceMenu02Colab = "";
                        do
                        {
                            Console.Clear();
                            choiceMenu02Colab = Menus.GeneralMenuColab();

                            #region Menu04 Client Administration

                            #endregion

                            #region Menu05 PT Administration

                            #endregion

                            #region Menu06 Request Administration

                            #endregion
                        } while (choiceMenu02Colab != "0");

                    }
                    #endregion
                    else
                    {
                        Console.WriteLine($"{userType}! Pressiona qualquer tecla para voltares ao menu incial.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

            } while (choiceMenu01 != "0");
            
        }
    }
}
