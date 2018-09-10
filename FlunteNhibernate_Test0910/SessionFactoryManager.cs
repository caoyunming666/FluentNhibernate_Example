using FlunteNhibernate_Test0910.Models;
using System.Collections.Generic;

namespace FlunteNhibernate_Test0910
{
    /// <summary>
    /// persion数据操作
    /// </summary>
    public class SessionFactoryManager
    {
        public IList<Persion> GetAllPersion()
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var persionList = session.QueryOver<Persion>();
                    transaction.Commit();
                    return persionList.List();
                }
            }
        }

        public IList<Persion> GetPersionByName(string name)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var persionList = session.QueryOver<Persion>().Where(x => x.Name == name);
                    transaction.Commit();
                    return persionList.List();
                }
            }
        }

        public void SavePersion(Persion persion)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(persion);
                    session.Flush();
                    transaction.Commit();
                }
            }
        }

        public void DeleteById(int id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Persion p1 = new Persion();
                    p1.Id = id;

                    session.Delete(p1);
                    session.Flush();
                    transaction.Commit();
                }
            }
        }
    }
}