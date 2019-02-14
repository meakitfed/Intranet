using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using IntranetPOPS1819.Models;

namespace Intranet
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			//BundleConfig.RegisterBundles(BundleTable.Bundles);

			IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
			Database.SetInitializer(init);
			init.InitializeDatabase(new BddContext());
			Dal d = new Dal();
			d.InitializeBdd();
		}
    }
}