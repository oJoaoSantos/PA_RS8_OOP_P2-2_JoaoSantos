using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_DAL.Model
{
    public class PersonalTrainer
    {
        #region Scalar Properties
        
        [Key]
        public int PersonalTrainerID { get; set; }

        public int ZipCodeID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Número de caracteres máximo = 100.")]
        public string PtName { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "NIF inválido.")]
        public string PtVat { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "Contacto inválido.")]
        public string PtPhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string PtEmail { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Número de caracteres máximo = 200.")]
        public string PtAdress { get; set; }
        #endregion

        #region Navigation Properties
        public ZipCode ZipCode { get; set; }
        public ICollection<Client> Client { get; set; }
        public ICollection<Request> Request { get; set; }
        #endregion
    }
}
