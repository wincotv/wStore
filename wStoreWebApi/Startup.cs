using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

/// Sources
/// http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1
/// http://angular2mvc5.codeplex.com/

[assembly: OwinStartup(typeof(wStoreWebApi.Startup))]

namespace wStoreWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
