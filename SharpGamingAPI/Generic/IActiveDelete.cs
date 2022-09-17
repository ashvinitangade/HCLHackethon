using System.Threading.Tasks;

namespace SharpGamingAPI.Generic
{
    public interface IActiveDelete
    {
        Task<int> Active(long Id);
        Task<int> Delete(long Id);
    }
}