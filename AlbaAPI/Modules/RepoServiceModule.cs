
using Autofac;
using Layer.Caching;
using Layer.Core.Models;
using Layer.Core.Repositories;
using Layer.Core.Services;
using Layer.Core.UnitOfWork;
using Layer.Repositories;
using Layer.Repositories.Repositories;
using Layer.Repositories.UnitsOfWork;
using Layer.Service.Mapper;
using Layer.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace AlbaAPI.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).
                AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CampaignsServiceWithCaching>().As<IService<Campaigns>>();
        }





    }
}
