using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("asd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            AccountController accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(email);

            Assert.AreEqual(expectedResult, actualResult);
        }
        /*  
            Olyan eset, amikor nincs szám a jelszóban
            Olyan eset, amikor nincs kisbetű a jelszóban
            Olyan eset, amikor nincs nagybetű a jelszóban
            Olyan eset, amikor túl rövid a jelszó
            Olyan eset amikor megfelelő a jelszó
         */
        [
            Test,
            TestCase("aaAAAAAA", false),
            TestCase("A1AAAAAA", false),
            TestCase("a1aaaaaa", false),
            TestCase("a1aaaaa", false),
            TestCase("a1AAAAAA", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            AccountController accountController = new AccountController();

            var actualResult = accountController.ValidatePassword(password);

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
