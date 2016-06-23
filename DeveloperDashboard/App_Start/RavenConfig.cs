using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Embedded;

namespace DeveloperDashboard.App_Start
{
    public class RavenConfig
    {
        public static EmbeddableDocumentStore Store { get; set; }

        public static void Register()
        {
            Store = new EmbeddableDocumentStore
            {
                RunInMemory = true,
            };
            Store.Configuration.RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true;
            Store.Configuration.Storage.Voron.AllowOn32Bits = true;
            Store.Initialize();
        }
    }
    //public static IDocumentStore Store { get; set; }

    //public static void Register()
    //{
    //    Store = new DocumentStore
    //    {
    //        Url = "http://wernsen-pc:8080/",
    //        DefaultDatabase = "test"
    //    };
    //    Store.Initialize();
    //}
}