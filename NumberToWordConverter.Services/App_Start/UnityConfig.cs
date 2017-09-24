using Microsoft.Practices.Unity;
using NumberToWordConverter.Repository.Classes;
using NumberToWordConverter.Repository.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using Unity.WebApi;

namespace NumberToWordConverter.Services
{
    /// <summary>
    /// UnityConfig
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class UnityConfig
    {
        /// <summary>
        /// RegisterComponents Method
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            #region Registering Interfaces

            container.RegisterType<IConvertRepository, ConvertRepository>();

            #endregion


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}