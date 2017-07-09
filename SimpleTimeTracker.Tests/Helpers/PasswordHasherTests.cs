using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleTimeTracker.Core.Helpers;

namespace SimpleTimeTracker.Tests.Helpers
{
    [TestClass]
    public class PasswordHasherTests
    {

        [TestMethod]
        public void HashPassword_WillCreateHash()
        {
            var password = "admin";
            var hash = PasswordHasher.HashPassword(password);
            Console.WriteLine(hash);
        }


        [TestMethod]
        public void IsMatch_WithMatchedHash_WillReturnTrue()
        {
            var password = "sup3rC0mpl3$P@ssw0rD";
            var hash = PasswordHasher.HashPassword(password);
            Assert.IsTrue(PasswordHasher.IsMatch(password, hash));
        }

        [TestMethod]
        public void IsMatch_WithUnMatchedHash_WillReturnFalse()
        {
            var password = "sup3rC0mpl3$P@ssw0rD";
            Assert.IsFalse(PasswordHasher.IsMatch(password, "SomeRandomStringOfStuff"));
        }

    }
}
