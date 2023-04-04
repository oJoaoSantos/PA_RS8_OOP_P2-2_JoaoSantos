using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_Client.Repository
{
    static class RequestRepository
    {
        #region Create
        public static void CreateRequest(int client, int pt, DateTime dateTime, Request.EnumSatus status, string obs = "")
        {
            Request request = new Request()
            {
                ClientID = client,
                PersonalTrainerID = pt,
                DateAndTime = dateTime,
                Status = status,
                RequestObservations = obs
            };

            using (var context = new _DatabaseContext())
            {
                context.Request.Add(request);
                context.SaveChanges();
            }
        }
        #endregion

        #region Read

        #endregion
    }
}
