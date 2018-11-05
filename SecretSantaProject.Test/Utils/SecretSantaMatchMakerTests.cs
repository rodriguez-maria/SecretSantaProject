using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSantaProject.Models;
using System.Collections.Generic;
using SecretSantaProject.Utils;
using System.Linq;

namespace SecretSantaProject.Test.Utils
{
    [TestClass]
    public class SecretSantaMatchMakerTests
    {
        [TestMethod]
        public void TestMatchMake()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Contact{ Name = "Ff", Number = "+12345678912"});
            contacts.Add(new Contact { Name = "Mm", Number = "+12345678912" });
            contacts.Add(new Contact { Name = "Ll", Number = "+12345678912" });
            contacts.Add(new Contact { Name = "Gg", Number = "+12345678912" });
            contacts.Add(new Contact { Name = "Jj", Number = "+12345678912" });
            contacts.Add(new Contact { Name = "Yy", Number = "+12345678912" });
            contacts.Add(new Contact { Name = "Pp", Number = "+12345678912" });
            contacts.Add(new Contact { Name = "Kk", Number = "+12345678912" });

            var ssmm = new SecretSantaMatchMaker(new DefaultSecretSantaValidator());
            var result = ssmm.MatchMake(contacts).ToList();

            Assert.AreEqual(contacts.Count, result.Count);

            for(int i = 0; i < result.Count; i++)
            {
                Assert.AreNotEqual(result[i].Item1.Name, result[i].Item2.Name);
            }

            for(int i = 0; i < contacts.Count; i++)
            {
                var leftCounter = 0;
                var rightCounter = 0;
                for (int k = 0; k < result.Count; k++)
                {
                    if (contacts[i].Name.Equals(result[k].Item1.Name))
                    {
                        leftCounter++;
                    }

                    if (contacts[i].Name.Equals(result[k].Item2.Name))
                    {
                        rightCounter++;
                    }
                }
                Assert.AreEqual(1, leftCounter);
                Assert.AreEqual(1, rightCounter);
            } 
        }
    }
}
