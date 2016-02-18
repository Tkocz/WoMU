using Microsoft.Owin;
using Owin;
using WoMU_lab1.Models;

[assembly: OwinStartupAttribute(typeof(WoMU_lab1.Startup))]
namespace WoMU_lab1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ShoppingCartVM vm = new ShoppingCartVM();
        }
    }
}