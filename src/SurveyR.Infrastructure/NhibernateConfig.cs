using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using SurveyR.Core;
using SurveyR.Infrastructure.FluentNhibernate;

namespace SurveyR.Infrastructure
{
    public class NhibernateConfig
    {
         public static void BootStrap()
         {
             var fhnConventions = new SurveyRMappingConfiguration();

             var sessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey("Survey")))
                .Mappings(m =>
                    {
                        m.AutoMappings.Add(AutoMap.AssemblyOf<Survey>(fhnConventions));
                    })
                .ExposeConfiguration(x => new SchemaExport(x).Execute(false, true, false))
                .BuildSessionFactory();
         }
    }
}