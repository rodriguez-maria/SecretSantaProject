using SecretSantaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Utils
{
    public class DefaultSecretSantaValidator : IValidator<IEnumerable<Tuple<Contact, Contact>>>
    {
        public bool Validate(IEnumerable<Tuple<Contact, Contact>> result)
        {
            return true;
        }
    }
}
