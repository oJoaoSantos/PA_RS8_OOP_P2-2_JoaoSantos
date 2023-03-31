using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_DAL.Model
{
    public class Request
    {
        #region Enumerations
        public enum EnumSatus
        {
            Agendado,
            Terminado,
            Cancelado
        }
        #endregion

        #region Scalar Properties
        public int RequestID { get; set; }

        public int ClientID { get; set; }

        public int PersonalTrainerID { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        public EnumSatus Status { get; set; }

        [MaxLength(255, ErrorMessage = "Número de caracteres máximo = 255.")]
        public string RequestObservations { get; set; }
        #endregion

        #region Navigation Properties
        public Client Client { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }


        #endregion
    }
}
