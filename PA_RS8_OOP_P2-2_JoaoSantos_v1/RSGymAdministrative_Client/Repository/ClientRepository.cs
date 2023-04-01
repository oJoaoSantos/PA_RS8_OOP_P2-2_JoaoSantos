using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Repository
{
    static class ClientRepository
    {
        public static void CreateClient(int zipID, string name, DateTime birth, string vat, string phone, string mail, string adress, string obs = "", bool active = true)
        {
            Client client = new Client()
            {
                ZipCodeID = zipID,
                ClientName = name,
                BirthDate = birth,
                ClientVat = vat,
                ClientPhoneNumber = phone,
                ClientEmail = mail,
                ClientAdress = adress,
                ClientObservations = obs,
                ActiveNow = active
            };

            using (var context = new _DatabaseContext())
            {
                context.Client.Add(client);
                context.SaveChanges();
            }
        }
    }
}
