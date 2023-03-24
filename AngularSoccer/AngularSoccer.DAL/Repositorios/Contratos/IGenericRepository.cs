using System.Linq.Expressions;

namespace AngularSoccer.DAL.Repositorios.Contratos
{
    public interface IGenericRepository<TModelo> where TModelo : class
    {
        Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro);
        Task<TModelo> Crear(TModelo modelo);
        Task<bool> Editar(TModelo modelo);
        Task<bool> Eliminar(TModelo modelo);
        Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null);
    }
}
