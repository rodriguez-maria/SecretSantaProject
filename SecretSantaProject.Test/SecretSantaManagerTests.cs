using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSantaProject.Repositories;
using Moq;
using System.Collections.Generic;
using SecretSantaProject.Models;
using SecretSantaProject.Utils;

namespace SecretSantaProject.Test
{
    [TestClass]
    public class SecretSantaManagerTests
    {
        [TestMethod]
        public void TestCreateSecretSantaAndNotify()
        {
            var mockContactRepository = new Mock<IContactRepository>();
            mockContactRepository.Setup(x => x.GetContacts()).Returns(new List<Contact>());

            var mockMatchMaker = new Mock<IMatchMaker<Contact>>();
            mockMatchMaker.Setup(x => x.MatchMake(It.IsAny<IEnumerable<Contact>>(), It.IsAny<int>())).Returns(new List<Tuple<Contact, Contact>>());

            var mockNotifier = new Mock<ISecretSantaNotifier<Contact>>();
            mockNotifier.Setup(x => x.Notify(It.IsAny<IEnumerable<Tuple<Contact, Contact>>>()));

            var manager = new SecretSantaManager(mockContactRepository.Object, mockMatchMaker.Object, mockNotifier.Object);

            manager.CreateSecretSantaAndNotify();
            mockContactRepository.Verify(x => x.GetContacts(), Times.Once);
            mockMatchMaker.Verify(x => x.MatchMake(It.IsAny<IEnumerable<Contact>>(), It.IsAny<int>()), Times.Once);
            mockNotifier.Verify(x => x.Notify(It.IsAny<IEnumerable<Tuple<Contact, Contact>>>()), Times.Once);

        }
    }
}
