﻿using Data.Context;
using Data.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GeneroFilmeComEfCore : BaseRepository<GeneroFilme>, IGeneroFilmeRepository
    {
        private readonly DbSet<GeneroFilme> _dbset;
        

        public GeneroFilmeComEfCore(MyContext _context) : base(_context)
        {
            _dbset = _context.Set<GeneroFilme>();
            
        }

        public async Task<IEnumerable<GeneroFilme>> BuscaFilmesPorGenero(int IdGeneroFilme)
        {
            var queryFilmes = await _context.GenerosFilmes
            .Include(g => g.Genero)
            .Include(f => f.Filme)
            .ThenInclude(d => d.Diretor)
            .Where(gf => gf.IdGenero == IdGeneroFilme)
            .ToListAsync();

            return queryFilmes;
        }

        public async Task<GeneroFilme> BuscaGeneroDoFilme(int idGenero,int idFilme)
        {
            var query = await _context.GenerosFilmes
                .Include(g => g.Genero)
                .Include(f => f.Filme)
                .Where(gf => gf.IdGenero == idGenero && gf.IdFilme == idFilme)
                .FirstAsync();
            return query;
        }
    }
}
