using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSantaProject.Utils;
using Moq;
using SecretSantaProject.Services;
using System.Collections.Generic;
using SecretSantaProject.Models;

namespace SecretSantaProject.Test.Utils
{
    [TestClass]
    public class SecretSantaNotifierTests
    {
        [TestMethod]
        public void TestNotify()
        {
            var mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(x => x.Notify(It.IsAny<string>(), It.IsAny<string>()));

            var notifier = new SecretSantaNotifier(mockNotificationService.Object);

            var results = new List<Tuple<Contact, Contact>>();
            results.Add(new Tuple<Contact, Contact>(new Contact { Name = "Ff", Number = "+1" },
                                                    new Contact { Name = "Mm", Number = "+2" }));
            results.Add(new Tuple<Contact, Contact>(new Contact { Name = "Mm", Number = "+2" },
                                                    new Contact { Name = "Ff", Number = "+1" }));

            notifier.Notify(results);

            mockNotificationService.Verify(x => x.Notify(results[0].Item1.Number, string.Format(SecretSantaNotifier.MessageFormat, results[0].Item1.Name, results[0].Item2.Name)), Times.Once);
            mockNotificationService.Verify(x => x.Notify(results[1].Item1.Number, string.Format(SecretSantaNotifier.MessageFormat, results[1].Item1.Name, results[1].Item2.Name)), Times.Once);
        }
    }
}
