using System.Threading.Tasks;

namespace SharpGamingAPI.Generic
{
    public interface IGetById<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(long Id);
    }
}