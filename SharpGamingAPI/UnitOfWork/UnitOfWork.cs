using SharpGamingAPI.Repository;

namespace SharpGamingAPI
{
	public class UnitOfWork : IUnitOfWork
    {
        //============================================= Public Properties  ======================  
        private ISportsRepository _sportss;
        public ISportsRepository Sportss => _sportss ?? (_sportss = new SportsRepository());
	}
}