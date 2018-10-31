using FlunteNhibernate_Test0910.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlunteNhibernate_Test0910.Controllers
{
    public class HomeController : Controller
    {
        readonly SessionFactoryManager sfm = new SessionFactoryManager();
        // GET: Home
        public ActionResult Index()
        {
            List<Persion> list = sfm.GetAllPersion().ToList();

            ViewBag.Persion = list;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Persion persion)
        {
            if (persion == null)
            {
                throw new NullReferenceException("Persion");
            }

            if (string.IsNullOrWhiteSpace(persion.Name))
            {
                throw new NullReferenceException("Persion.Name");
            }

            sfm.SavePersion(persion);

            return Redirect("/Home/Index");
        }


        public ActionResult Edit(int id)
        {
            Persion model = sfm.GetPersionById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Persion persion)
        {
            if (persion == null)
            {
                throw new NullReferenceException("Persion");
            }

            Persion model = sfm.GetPersionById(persion.Id);
            if (model == null)
            {
                throw new NullReferenceException("Persion.Id");
            }

            model.Name = persion.Name;
            model.Age = persion.Age;

            sfm.UpdatePersion(model);

            return Redirect("/Home/Index");
        }


        /// <summary>
        /// 消除if else测试
        /// </summary>
        /// <returns></returns>
        public ActionResult RemoveIfElse(int statu = 0)
        {
            #region 定义可能出现的情况(分支)

            string ruleStr = string.Empty;
            Dictionary<int, string> customerRule = new Dictionary<int, string>();
            customerRule.Add(0, "Zero");
            customerRule.Add(1, "One");
            customerRule.Add(2, "Two");
            customerRule.Add(3, "Three");
            if (customerRule.ContainsKey(statu))
            {
                ruleStr = customerRule[statu];
            }

            #endregion

            if (!string.IsNullOrWhiteSpace(ruleStr))
            {
                #region 重构前：使用多个if else
                /* 
                 * 在一个函数中，出现过多的分支 造成最明显的结果就是业务逻辑不清晰，代码不易阅读
                 * 且代码复杂度较高。这里引用网上的资料： https://blog.csdn.net/d29h1jqy3akvx/article/details/78211518
                 * 
                 *      它通过从上到下嵌套的 if，让单个函数内的控制流不停增长。不要以为控制流增长时，复杂度只会线性增加。
                        我们知道函数处理的是数据，而每个 if 内一般都会有对数据的处理逻辑。那么，即便在不存在嵌套的情形下，如果有 3 段这样的 if，那么根据每个 if 是否执行，数据状态就有 2 ^ 3 = 8 种。
                        如果有 6 段，那么状态就有 2 ^ 6 = 64 种。从而在项目规模扩大时，函数的调试难度会指数级上升！这在数量级上，与《人月神话》的经验一致。 

                    如何尽可能的消除if else?
                        由于现代编程语言摒弃了 goto，因此不论控制流再复杂，函数体内代码的执行顺序也都是从上而下的。
                        因此，我们完全有能力在不改变控制流逻辑的前提下，将一个单体的大函数，自上而下拆逐步分为多个小函数，而后逐个调用之。这是有经验的同学经常使用的技巧，具体代码实现在此不做赘述了。
                 */
                if (ruleStr == "Zero")
                {
                    //do something...
                }
                if (ruleStr == "One")
                {
                    //do something...
                }
                if (ruleStr == "Two")
                {
                    //do something...
                }
                if (ruleStr == "Three")
                {
                    //do something...
                }
                #endregion

                #region 重构后：使用函数代替分支
                /* 
                 * 重构之后的主函数(如果删除重构前的代码)体内，只会看到4行代码，极大提高了代码的易读性。业务逻辑只要
                 * 处理函数名称做到见名知意，那也是相当清晰的。
                 * 更方便的是，每一个分支都可以在单独的函数内独立处理。
                 */
                EqualZeroHandler(ruleStr);
                EqualOneHandler(ruleStr);
                EqualTwoHandler(ruleStr);
                EqualThreeHandler(ruleStr);
                #endregion
            }
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 这个函数只处理 ruleStr == "Zero" 的情况，其他的不处理
        ///     这么做有个好处就是在主函数中可以调用所有的分支函数，程序会按顺序执行下来
        ///     只有执行到与之匹配的函数时，才会进入分支处理代码
        /// </summary>
        /// <param name="ruleStr"></param>
        public void EqualZeroHandler(string ruleStr)
        {
            if (ruleStr == "Zero")
            {
                //do something...
            }
        }

        public void EqualOneHandler(string ruleStr)
        {
            if (ruleStr == "One")
            {
                //do something...
            }
        }

        public void EqualTwoHandler(string ruleStr)
        {
            if (ruleStr == "Two")
            {
                //do something...
            }
        }

        public void EqualThreeHandler(string ruleStr)
        {
            if (ruleStr == "Three")
            {
                //do something...
            }
        }
    }
}