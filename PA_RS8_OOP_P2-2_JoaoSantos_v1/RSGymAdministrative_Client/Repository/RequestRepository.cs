using RSGymAdministrative_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        public static void ReadRequest()
        {
            Console.Clear();
            Utilities.Basics.Title01("Consulta de Pedidos");
            Utilities.Basics.BlockSeparator(1);

            using (var context = new _DatabaseContext())
            {
                var request = from r in context.Request
                              join p in context.PersonalTrainer on r.PersonalTrainerID equals p.PersonalTrainerID
                              join c in context.Client on r.ClientID equals c.ClientID
                              select new
                              {
                                  r.RequestID,
                                  c.ClientName,
                                  p.PtName,
                                  r.DateAndTime,
                                  r.Status,
                                  r.RequestObservations
                              };
                request.OrderBy(r => r.DateAndTime).ToList().ForEach(r => Console.WriteLine($"Data: {r.DateAndTime.ToShortDateString()} | Horas: {r.DateAndTime.ToShortTimeString()} | ID: {r.RequestID} | Estado: {r.Status} | Cliente: {r.ClientName}\t| PT: {r.PtName}\t| Observações: {r.RequestObservations}"));
            }
        }
        #endregion
    }
}
