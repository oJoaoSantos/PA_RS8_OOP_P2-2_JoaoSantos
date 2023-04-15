using RSGymAdministrative_Client.Repository;
using RSGymAdministrative_DAL.Model;
using System;

namespace RSGymAdministrative_Client.Structure
{
    public class InitializeData
    {
        #region Initial Data
        public static void CreateInitialData()
        {
            #region Create ZipCodes
            ZipCodeRepository.CreateZipCode("1111-001", "Localiade A, Teste");
            ZipCodeRepository.CreateZipCode("2222-002", "Localiade B, Teste");
            ZipCodeRepository.CreateZipCode("3333-003", "Localiade C, Teste");
            ZipCodeRepository.CreateZipCode("4444-004", "Localiade D, Teste");
            ZipCodeRepository.CreateZipCode("5555-005", "Localiade E, Teste");
            #endregion

            #region Create Users
            UserRepository.CreateUser(User.EnumPermissionType.Admin, "João Pedro Santos", "ADJS", "12345678");
            UserRepository.CreateUser(User.EnumPermissionType.Colab, "Matilde Loureiro Santos", "COMS", "12345678");
            UserRepository.CreateUser(User.EnumPermissionType.Colab, "Érica Santos Teixeira", "COET", "12345678");
            #endregion

            #region Create Clients
            ClientRepository.CreateClient(1, "Cliente Teste A", new DateTime(1995, 01, 01), "123456789", "912345678", "c01@rsgym.pt", "Rua a, N1, Teste");
            ClientRepository.CreateClient(2, "Cliente Teste B", new DateTime(1995, 02, 02), "987654321", "923456789", "c02@rsgym.pt", "Rua b, N2, Teste");
            ClientRepository.CreateClient(3, "Cliente Teste C", new DateTime(1995, 03, 03), "456123789", "934567891", "c03@rsgym.pt", "Rua c, N3, Teste");
            #endregion

            #region CreatePT's
            PersonalTrainerRepository.CreatePersonalTrainer(4, "PT01", "Personal Trainner A", "123789456", "965498712", "pt01@rsgym.pt", "Rua d, N4, Teste");
            PersonalTrainerRepository.CreatePersonalTrainer(5, "PT02", "Personal Trainner B", "789456123", "914567891", "pt02@rsgym.pt", "Rua e, N5, Teste");
            #endregion

            #region CreateRequests
            RequestRepository.CreateRequest(1, 1, new DateTime(2023, 05, 01, 10, 00, 0), Request.EnumSatus.Agendado);
            RequestRepository.CreateRequest(2, 1, new DateTime(2023, 05, 02, 11, 00, 0), Request.EnumSatus.Agendado);
            RequestRepository.CreateRequest(3, 2, new DateTime(2023, 05, 03, 12, 00, 0), Request.EnumSatus.Agendado);
            #endregion
        }
        #endregion
    }
}
