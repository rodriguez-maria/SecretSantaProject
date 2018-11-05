using SecretSantaProject.Models;
using SecretSantaProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Utils
{
    public class SecretSantaNotifier : ISecretSantaNotifier<Contact>
    {
        private INotificationService service;
        public const string MessageFormat = "Secret Santa: Hi {0}, you should buy a gift for {1}";

        public SecretSantaNotifier(INotificationService service)
        {
            this.service = service;
        }
        public void Notify(IEnumerable<Tuple<Contact, Contact>> results)
        {
            foreach(var item in results)
            {
                service.Notify(item.Item1.Number, string.Format(MessageFormat, item.Item1.Name, item.Item2.Name));
            }
        }
    }
}
