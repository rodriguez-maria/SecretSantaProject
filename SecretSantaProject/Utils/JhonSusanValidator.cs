using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSantaProject.Models;

namespace SecretSantaProject.Utils
{
    /*
     * Jhon is not allowed to have Susan as their Secret Santa.
     */
    public class JhonSusanValidator : IValidator<IEnumerable<Tuple<Contact, Contact>>>
    {
        public bool Validate(IEnumerable<Tuple<Contact, Contact>> result)
        {
            foreach (var pair in result)
            {
                if (pair.Item1.Name.Equals("Jhon") && pair.Item2.Name.Equals("Susan"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
