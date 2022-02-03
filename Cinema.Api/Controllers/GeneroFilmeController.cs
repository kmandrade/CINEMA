﻿using Domain.Dtos.FilmeGenero;
using Microsoft.AspNetCore.Mvc;
using Serviços.Services.Entities;

namespace Cinema.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroFilmeController : ControllerBase
    {
        private IGeneroFilmeService _generoFilmeService;

        public GeneroFilmeController(IGeneroFilmeService generoFilmeService)
        {
            _generoFilmeService = generoFilmeService;
        }
        [HttpPost("Adiciona GeneroFilme")]
        public IActionResult AdicionaGeneroFilme(CriarGeneroFilmeDto criarGeneroFilmeDto)
        {
            _generoFilmeService.AdicionaGeneroFilme(criarGeneroFilmeDto);
            return Ok();
        }
        [HttpGet("Busca Filmes Por Genero")]
        public IActionResult BuscarFilmesPorGenero([FromQuery]LerGeneroFilmeDto lerGeneroFilmeDto)
        {
            var gf = _generoFilmeService.BuscarFilmesPorGenero(lerGeneroFilmeDto);
            return Ok(gf);
        }
    }
}
