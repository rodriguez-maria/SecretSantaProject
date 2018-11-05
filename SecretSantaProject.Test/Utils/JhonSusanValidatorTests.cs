using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SecretSantaProject.Models;
using SecretSantaProject.Utils;

namespace SecretSantaProject.Test.Utils
{
    [TestClass]
    public class JhonSusanValidatorTests
    {
        [TestMethod]
        public void TestValidateSuccess()
        {
            var results = new List<Tuple<Contact, Contact>>();
            results.Add(new Tuple<Contact, Contact>(new Contact { Name = "Ff", Number = "+1" },
                                                    new Contact { Name = "Mm", Number = "+2" }));
            results.Add(new Tuple<Contact, Contact>(new Contact { Name = "Mm", Number = "+2" },
                                                    new Contact { Name = "Ff", Number = "+1" }));
            Assert.IsTrue(new JhonSusanValidator().Validate(results));
        }

        [TestMethod]
        public void TestValidateFailed()
        {
            var results = new List<Tuple<Contact, Contact>>();
            results.Add(new Tuple<Contact, Contact>(new Contact { Name = "Ff", Number = "+1" },
                                                    new Contact { Name = "Mm", Number = "+2" }));
            results.Add(new Tuple<Contact, Contact>(new Contact { Name = "Jhon", Number = "+2" },
                                                    new Contact { Name = "Susan", Number = "+1" }));
            Assert.IsFalse(new JhonSusanValidator().Validate(results));
        }
    }
}
