using SecretSantaProject.Models;
using SecretSantaProject.Repositories;
using SecretSantaProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject
{
    public class SecretSantaManager
    {
        private IContactRepository contactsRepo;
        private IMatchMaker<Contact> matchMaker;
        private ISecretSantaNotifier<Contact> notifier;

        public SecretSantaManager(
            IContactRepository contactsRepo,
            IMatchMaker<Contact> matchMaker,
            ISecretSantaNotifier<Contact> notifier)
        {
            this.contactsRepo = contactsRepo;
            this.matchMaker = matchMaker;
            this.notifier = notifier;
        }

        public void CreateSecretSantaAndNotify()
        {
            var contacts = contactsRepo.GetContacts();
            var pairedContacts = matchMaker.MatchMake(contacts);
            notifier.Notify(pairedContacts);
        }
    }
}
