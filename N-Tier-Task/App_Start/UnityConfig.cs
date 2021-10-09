using BOL.EntitiesDBContext;
using DAL.BaseRepositories;
using DAL.CustomRepositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace N_Tier_Task
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IBaseRepository<Country>,CountryRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}