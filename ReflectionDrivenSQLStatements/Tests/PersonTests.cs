using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library;

namespace Tests
{
    [TestClass]
    public class PersonTests
    {
        private const string BASE_SELECT = "SELECT [Id], [FirstName], [LastName] FROM [Person]";

        [TestMethod]
        public void SelectCmd_Normal_Success()
        {
            Assert.AreEqual(BASE_SELECT, Person.SelectCmd());
        }
    }
}
