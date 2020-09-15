using System;

using EducationApi.Infra.Repository.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Data.SQLite;


namespace EducationApi.Infra.Repository.Util
{
    public class HibernateUtil
    {

        private static ISessionFactory factory;
  

        public static ISessionFactory Factory
        {
            get
            {
                //singleton..
                if (factory == null)
                {

                    // sesssionfactory
                    factory = Fluently.Configure().Database(
                                    SQLiteConfiguration.Standard.ConnectionString(System.Environment.GetEnvironmentVariable("SQLiteConnection")).ShowSql())
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EscolaMap>())                             
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TurmaMap>())                             
                              //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProfessorMap>())                             
                              //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<AlunoMap>())
                              .ExposeConfiguration(e => new SchemaExport(e).Create(true, true))
                              .BuildSessionFactory();
                }

                return factory;
            }
        }                      

    }
}
