﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dtos.FilmeDto
{
    public class CriarFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatorio")]

        public string Titulo { get; set; }

        public int Duracao { get; set; }
        [Required]
        public int DiretorId { get; set; }

        
        public SituacaoFilme Situacao { get; set; }

    }
    //public class CriarFilmeGeneroDto public IEnumerable<CriarFilmeGeneroDto> Generos { get; set; }
    //{
    //    public int Id { get; set; }
    //}
    //public class CriarFilmeAtorDto
    //{
    //    public int Id { get; set; }
    //}
}
