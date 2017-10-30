using NHibernate;
using NHibernate.Cfg;
using System;

namespace ServiceDesk.API.Infrastructure.Infra.NHibernate
{
    public class NHConfiguration
    {
        public ISessionFactory SessionFactory() => sessionFactory.Value;

        static Lazy<ISessionFactory> sessionFactory = new Lazy<ISessionFactory>(() =>
        {
            var cfg = new Configuration();
            cfg.Configure();

            return cfg.BuildSessionFactory();
        });
    }
}
