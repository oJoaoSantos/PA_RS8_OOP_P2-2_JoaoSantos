using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymAdministrative_DAL.Model
{
    public class ZipCode
    {
        #region Scalar Properties
        public int ZipCodeID { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{3}$")]
        public int Zip { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Número de caracteres máximo = 50.")]
        public string City { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Client> Clients { get; set; }
        public ICollection<PersonalTrainer> PersonalTrainers { get; set; }

        #endregion
    }
}
