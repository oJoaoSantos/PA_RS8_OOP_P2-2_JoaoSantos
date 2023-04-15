using RSGymAdministrative_DAL.Model;
using System;
using System.Linq;

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
                request.OrderBy(r => r.DateAndTime).ToList().ForEach(r => Console.WriteLine($" * Data: {r.DateAndTime.ToShortDateString()} * Horas: {r.DateAndTime.ToShortTimeString()} * ID: {r.RequestID} * Estado: {r.Status} * Cliente: {r.ClientName} * PT: {r.PtName} * Observações: {r.RequestObservations} *"));
            }
        }
        #endregion

        #region New Request
        public static Request AskNewRequest()
        {
            Request request = new Request();

            Console.Clear();
            Utilities.Basics.Title01("Criação de um Novo Pedido");
            Utilities.Basics.BlockSeparator(1);
            Utilities.Basics.Title02("Lista de Clientes");
            ClientRepository.ReadClient();
            Utilities.Basics.BlockSeparator(1);
            Utilities.Basics.Title02("Lista de PT's");
            PersonalTrainerRepository.ReadPersonalTrainer();
            Utilities.Basics.BlockSeparator(1);

            string valid = "";

            #region Client
            string id = "";
            do
            {
                id = Utilities.Basics.AskData("ID do Cliente");
                valid = Utilities.Validations.ValidateID(id);
            } while (valid == "ID inválido.");
            request.ClientID = int.Parse(valid);
            #endregion

            #region Pt
            string idPt = "";
            do
            {
                idPt = Utilities.Basics.AskData("ID do Personal Trainer");
                valid = Utilities.Validations.ValidateIDPt(idPt);
            } while (valid == "ID inválido.");
            request.PersonalTrainerID = int.Parse(valid);
            #endregion

            #region Date and Time
            request.DateAndTime = Utilities.Validations.ValidateDateAndTime();
            #endregion

            #region Obs
            string obs = "";
            do
            {
                obs = Utilities.Basics.AskData("Observações (opcional, enter para saltar)");
                valid = Utilities.Validations.ValidateObs(obs);
            } while (valid == "Máximo 255 caracteres.");
            request.RequestObservations = obs;
            #endregion

            request.Status = Request.EnumSatus.Agendado;
            return request;
        }
        #endregion
    }
}
