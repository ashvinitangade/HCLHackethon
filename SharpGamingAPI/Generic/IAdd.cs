using System.Threading.Tasks;

namespace SharpGamingAPI.Generic
{
    public interface IAdd<TEntity> where TEntity : class
    {
        Task<int> Add(TEntity entity);
    }
}