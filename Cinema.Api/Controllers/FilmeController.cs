﻿using Domain.Dtos.FilmeDto;
using Domain.Models;
using Domain.Services.Entities;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase
    {
        IFilmeService _filmeService;

        public FilmeController(IFilmeService service)
        {
            _filmeService = service;
        }
        
        [HttpGet("BuscaTodosFilmes")]
        public IActionResult BuscaFilmes([FromQuery] int skip, int take)
        {
            var filmes = _filmeService.ConsultaTodos(skip,take);

            if (filmes != null)
            {
                return Ok(filmes);
            }
            return NotFound();
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet("BuscaFilmesArquivados")]
        public IActionResult BuscaFilmesArquivados([FromQuery] int skip, int take)
        {
           var filmesArq= _filmeService.BuscaFilmesArquivados(skip,take);
            return Ok(filmesArq);
        }
        [HttpGet("BuscaCompleta/{id}")]
        public IActionResult BuscaCompleta(int id)
        {
            var filme = _filmeService.BuscarFilmeCompleto(id);
            return Ok(filme);
        }
        [HttpGet("BucaUmFilme/{id}")]
        public IActionResult BuscaUmFilme(int id)
        {
            var filme = _filmeService.ConsultaPorId(id);

            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
        [Authorize(Roles ="Administrador")]
        [HttpPost("CadastraUmFilme")]
        public IActionResult CadastraFilme([FromBody] CriarFilmeDto criarFilmeDto)
        {
            _filmeService.Cadastra(criarFilmeDto);
            return Ok();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("AlteraUmFilme")]
        public IActionResult AlterarFilme(int id, [FromBody] AlterarFilmeDto filmeDto)
        {
            Result resultado = _filmeService.Altera(id, filmeDto);
            if (resultado.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("ArquivaUmFilme{id}")]
        public IActionResult ArquivarFilme(int id)
        {
            _filmeService.ArquivarFilme(id);
            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("ReativarFilme{id}")]
        public IActionResult ReativarFilme(int id)
        {
            _filmeService.ReativarFilme(id);
            return Ok();
        }


        [Authorize(Roles = "Administrador")]
        [HttpDelete("DeletaUmFilme/{id}")]
        public IActionResult DeletaUmFilme(int id)
        {
            _filmeService.Excluir(id);
            return Ok();
        }
        


    }
}
