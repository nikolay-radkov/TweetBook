using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TweetBook.Web.Startup))]
namespace TweetBook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
