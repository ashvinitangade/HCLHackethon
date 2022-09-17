using System.Threading.Tasks;

namespace SharpGamingAPI.Generic
{
    public interface IUpdate<TEntity> where TEntity : class
    {
        Task<int> Update(TEntity entity);
    }
}