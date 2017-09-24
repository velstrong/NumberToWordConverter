using Microsoft.Owin;
using Owin;
using System.Diagnostics.CodeAnalysis;

[assembly: OwinStartupAttribute(typeof(NumberToWordConverter.Startup))]
namespace NumberToWordConverter
{
    [ExcludeFromCodeCoverage]
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
