using Microsoft.Owin;
using NumbersToWordsConverter.Core.Interfaces;
using NumbersToWordsConverter.Core.Services;
using Owin;

[assembly: OwinStartupAttribute(typeof(NumbersToWordsConverter.Web.Startup))]
namespace NumbersToWordsConverter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
