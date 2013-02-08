using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sample.DAL;
using Sample.Domain.Interfaces;
using Sample.Domain.Interfaces.Services;
using Sample.Domain.Models;
using Sample.Domain.Services;
using Unity.Mvc4;

namespace Sample.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

	  DependencyResolver.SetResolver(new UnityDependencyResolver(container));
	  GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
	    container.RegisterType<SampleContext>();
		container.RegisterType<IUnitOfWork, UnitOfWork>();
	    container.RegisterType<IProductService, ProductService>();
    }
  }
}