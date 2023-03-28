﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RSGymAdministrative_DAL.Model.User;

namespace RSGymAdministrative_DAL.Model
{
    public class Client
    {
        #region Scalar Properties
        public int ClientID { get; set; }
        public int ZipCodeID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Número de caracteres máximo = 100.")]
        public int ClientName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "NIF inválido.")]
        public string ClientVat { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "Contacto inválido.")]
        public string ClientPhoneNumber { get; set; }

        [Required]
        //ToDo JPS: Regular expression
        public string ClientEmail { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Número de caracteres máximo = 200.")]
        public string ClientAdress { get; set; }

        [MaxLength(255, ErrorMessage = "Número de caracteres máximo = 255.")]
        public string ClientObservations { get; set; }

        [Required]
        public bool ActiveNow { get; set; }

        #endregion

        #region Navigation Properties
        public ZipCode ZipCode { get; set; }
        public ICollection<Request> Requests { get; set; }

        #endregion
    }
}
