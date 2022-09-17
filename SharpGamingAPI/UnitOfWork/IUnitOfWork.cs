using SharpGamingAPI.Repository;

namespace SharpGamingAPI
{
    public interface IUnitOfWork
    {
        public ISportsRepository Sportss { get; }
    }
}