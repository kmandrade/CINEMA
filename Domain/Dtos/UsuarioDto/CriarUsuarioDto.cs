﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.UsuarioDto
{
    public class CriarUsuarioDto
    {
        [Required(ErrorMessage ="Necessario o nome do usuario")]
        public string NomeUsuarioDto { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string EmailDto { get; set; }


        [Required(ErrorMessage = "A senha é obrigatorio")]
        [DataType(DataType.Password)]//inferindo que sera do tipo password
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
