using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSantaProject.Repositories;

namespace SecretSantaProject.Test
{
    [TestClass]
    public class FileContactRepositoryTests
    {
        [TestMethod]
        public void TestReadFromFile()
        {
            FileContactRepository repository = new FileContactRepository("ContactstTest.txt");
            var contacts = repository.GetContacts();

            Assert.AreEqual(2, contacts.Count);
            Assert.AreEqual("Jane", contacts[0].Name);
            Assert.AreEqual("Jon", contacts[1].Name);
            Assert.AreEqual("+12345678999", contacts[0].Number);
            Assert.AreEqual("+12345678909", contacts[1].Number);
        }
    }
}
