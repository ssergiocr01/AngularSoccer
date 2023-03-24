﻿using AngularSoccer.DAL.DBContext;
using AngularSoccer.DAL.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AngularSoccer.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly SoccerDbContext _context;

        public GenericRepository(SoccerDbContext context)
        {
            _context = context;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _context.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _context.Set<TModelo>().Add(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _context.Set<TModelo>().Update(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _context.Set<TModelo>().Remove(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> queryModelo = filtro == null ? _context.Set<TModelo>() : _context.Set<TModelo>().Where(filtro);
                return queryModelo;
            }
            catch
            {
                throw;
            }
        }
    }
}
