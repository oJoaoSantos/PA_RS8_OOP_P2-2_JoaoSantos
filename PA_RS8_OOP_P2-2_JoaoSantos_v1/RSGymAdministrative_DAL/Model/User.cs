using System.ComponentModel.DataAnnotations;

namespace RSGymAdministrative_DAL.Model
{
    public class User
    {
        #region Enumerations
        public enum EnumPermissionType
        {
            Admin,
            Colab
        }
        #endregion

        #region Scalar Properties
        
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Número de caracteres máximo = 100.")]
        public string UserName { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Número de caracteres mínimo = 4.")]
        [MaxLength(6, ErrorMessage = "Número de caracteres máximo = 6.")]
        public string Code { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z1234567890]{8,12}$", ErrorMessage = "Telemóvel Inválido")]
        public string PassWord { get; set; }

        [Required]
        public EnumPermissionType PermissionType { get; set; }
        #endregion

    }
}
