using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2Tests1.Model;


namespace WpfApp2Tests.Pages.Tests
{
    [TestClass()]
    public class RegPageTests
    {
        

        [TestMethod()]
        
        public void RegPageTest()
        {
            

            string login = "123";

            string password = "123";

            Entities DB = new Entities();
            

            User testuser = new User()
            { Login = login, Password = password };

            DB.User.Add(testuser);
            

            var loginCheck = DB.User.Where(x => x.Login == login).FirstOrDefault();
            Assert.IsFalse(loginCheck != null);
        }
    }


}