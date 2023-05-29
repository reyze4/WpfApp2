using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2Tests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2Tests1.Model;

namespace WpfApp2Tests.Pages.Tests
{
    [TestClass()]
    public class EAPageTests
    {
        [TestMethod()]
        public void EAPageTest()
        {
            Entities DB = new Entities();
            string name = "qwe";
            string description = "qwe";
            string cost = "123";

            var loginCheck = DB.User.Where(x => x.Login == name).FirstOrDefault();

            loginCheck.Login = description;

            DB.SaveChanges();


            var loginCheck2 = DB.User.Where(x => x.Login == name).FirstOrDefault();


            Assert.IsTrue(loginCheck2.Login == description);
        }

        [TestMethod()]
        public void EAPageTest1()
        {
            Entities DB = new Entities();
            string login = "123";

            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();

            DB.User.Remove(loginCheck);

            DB.SaveChanges();

            var loginCheck2 = DB.User.Where(x => x.Login == login).FirstOrDefault();


            Assert.IsTrue(loginCheck2 == null);
        }
    }
}