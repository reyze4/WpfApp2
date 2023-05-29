using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;
using WpfApp2.Pages;


namespace WpfApp2.Pages.Tests
{
    [TestClass()]
    public class EAPageTests
    {
        [TestMethod()]
        public void EAPageTest()
        {
            Entities1 DB = new Entities1();
            

           

            DB.Product.Remove();

            DB.SaveChanges();

            var loginCheck2 = DB.User.Where(x => x.Login == login).FirstOrDefault();


            Assert.IsTrue(loginCheck2 == null);
        }
    }
}