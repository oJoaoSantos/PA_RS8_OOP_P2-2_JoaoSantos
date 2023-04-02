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
                    List<User.EnumPermissionType> userType = Menus.LogIn();
                    #endregion
                    
                    //if (userType.Contains("Admin"))
                    //{
                        #region Menu02 General Admin

                        #endregion
                    //}
                    //else
                    //{
                        #region Menu02 General Colab

                        #endregion
                    //}

                }

            } while (choiceMenu01 != "0");
            
        }
    }
}
