using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

/// Sources
/// http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-1
/// http://angular2mvc5.codeplex.com/

/// http://www.mitechdev.com/2016/08/crud-operations-in-kendo-grid-using-angularjs.html
/// http://www.mitechdev.com/2016/09/angular-text-editor-in-aspnet-mvc5.html#.V9EsGMhM_sk.linkedin
/// http://www.mitechdev.com/2016/09/How-to-read-and-display-xml-data-in-mvc5.html
/// http://www.mitechdev.com/2016/09/implementing-treeview-using-angularjs-in-mvc5.html

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
