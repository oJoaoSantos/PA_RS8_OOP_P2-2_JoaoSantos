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
        [MinLength(4, ErrorMessage = "Número de caracteres = 4.")]
        [MaxLength(4, ErrorMessage = "Número de caracteres = 4.")]
        public string PtCode { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Número de caracteres máximo = 100.")]
        public string PtName { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "NIF Inválido")]
        public string PtVat { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Telemóvel Inválido")]
        public string PtPhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email Inválido")]
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
