using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSantaProject.Models;
using Medallion;

namespace SecretSantaProject.Utils
{
    public class SecretSantaMatchMaker : IMatchMaker<Contact>
    {
        private Random randomizer;
        private IValidator<IEnumerable<Tuple<Contact, Contact>>> validator;
        public SecretSantaMatchMaker(IValidator<IEnumerable<Tuple<Contact, Contact>>> validator)
        {
            randomizer = new Random();
            this.validator = validator;
        }

        public IEnumerable<Tuple<Contact, Contact>> MatchMake(IEnumerable<Contact> contacts, int retry=20)
        {
            List<Contact> shuffledContacts = contacts.Shuffled(randomizer).Shuffled(randomizer).ToList();
            List<Tuple<Contact, Contact>> ret = new List<Tuple<Contact, Contact>>();

            for(int i = 0; i < shuffledContacts.Count - 1; i++)
            {
                ret.Add(new Tuple<Contact, Contact> (shuffledContacts[i], shuffledContacts[i + 1]));
            }

            ret.Add(new Tuple<Contact, Contact>(shuffledContacts[shuffledContacts.Count-1], shuffledContacts[0]));

            if (validator.Validate(ret))
            {
                return ret;
            }
            else if(retry <= 0)
            {
                throw new Exception("Unable to match make.");
            }

            Console.WriteLine("Validation failed. Retrying...");
            return MatchMake(shuffledContacts, retry - 1);
        }
    }
}
