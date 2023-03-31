using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [MinLength(8, ErrorMessage = "Número de caracteres mínimo = 8.")]
        [MaxLength(12, ErrorMessage = "Número de caracteres máximo = 12.")]
        public string PassWord { get; set; }

        [Required]
        public EnumPermissionType PermissionType { get; set; }
        #endregion

        #region Navigation Properties
        // ToDo JPS: Verificar se necessita de ligar a alguma tabela
        #endregion
    }
}
