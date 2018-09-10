using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;

namespace FlunteNhibernate_Test0910
{
    /// <summary>
    /// 获取session实例
    /// </summary>
    public class SessionFactory
    {
        private static ISessionFactory sessionFactory = null;

        private static void InitializeSessionFactory()
        {
            Configuration cfg = new Configuration()
                .Configure()
                .SetProperty("NHibernate.Test", "connection.connection_string");
            sessionFactory = Fluently.Configure(cfg)
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<SessionFactory>())
                .BuildSessionFactory();

            #region 写死数据库连接字符串的方式
            //sessionFactory = Fluently.Configure()
            //    .Database(MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("localpersion").Username("root").Password("qq123456")))
            //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<SessionFactory>())
            //    .BuildSessionFactory(); 
            #endregion
        }

        private static ISessionFactory SessionFactoryProp
        {
            get
            {
                if (sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactoryProp.OpenSession();
        }
    }
}