﻿//using FluentNHibernate.Cfg;
//using NHibernate;
//using NHibernate.Cfg;

//namespace FlunteNhibernate_Test0910
//{
//    /// <summary>
//    /// 获取session实例
//    /// </summary>
//    public class SessionFactory
//    {
//        private static ISessionFactory sessionFactory = null;

//        private static void InitializeSessionFactory()
//        {
//Configure();              此方法会查询网站根目录下的 hibernate.cfg.xml 配置文件
//Configuration cfg = new Configuration().Configure();
/* 
 * 异常详细信息: System.IO.FileNotFoundException: 未能找到文件“D:\project_files\FlunteNhibernate_Test0910\FlunteNhibernate_Test0910\bin\hibernate.cfg.xml”。
 * 
 * 在修改了配置文件名称后，运行网站抛出异常以上异常
 *      从上面的异常信息可以看出，Nhibernate 配置文件默认的位置就是放在网站的根目录，且名称必须是
 *      hibernate.cfg.xml
 */


/* 
 * Configure("./src/...");   指定配置文件，有一个好处是可以修改配置文件的默认名称，且配置文件存放的位置
 *                           可自定义。查看源码之后，发现默认不填写文件名称的话也是使用下面两句代码获取
 *                           网站根目录的指定名称的配置文件。
 *                          
 */
//string domainPath = AppDomain.CurrentDomain.BaseDirectory;
//string fullPath = domainPath + "/hibernate.xml";
//Configuration cfg = new Configuration().Configure(fullPath);

//            sessionFactory = Fluently.Configure(cfg)
//                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<SessionFactory>())
//                .BuildSessionFactory();

//            #region 写死数据库连接字符串的方式
//            //sessionFactory = Fluently.Configure()
//            //    .Database(MySQLConfiguration.Standard.ConnectionString(db => db.Server("localhost").Database("localpersion").Username("root").Password("qq123456")))
//            //    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<SessionFactory>())
//            //    .BuildSessionFactory(); 
//            #endregion
//        }

//        private static ISessionFactory SessionFactoryProp
//        {
//            get
//            {
//                if (sessionFactory == null)
//                {
//                    InitializeSessionFactory();
//                }
//                return sessionFactory;
//            }
//        }

//        public static ISession OpenSession()
//        {
//            return SessionFactoryProp.OpenSession();
//        }
//    }
//}