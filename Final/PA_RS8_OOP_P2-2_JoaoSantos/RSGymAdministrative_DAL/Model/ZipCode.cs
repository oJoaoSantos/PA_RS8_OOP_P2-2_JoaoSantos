using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RSGymAdministrative_DAL.Model
{
    public class ZipCode
    {
        #region Scalar Properties
        [Key]
        public int ZipCodeID { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{3}$")]
        public string Zip { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Número de caracteres máximo = 100.")]
        public string City { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Client> Client { get; set; }
        public ICollection<PersonalTrainer> PersonalTrainer { get; set; }
        #endregion
    }
}
