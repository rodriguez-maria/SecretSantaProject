using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecretSantaProject.Models;

namespace SecretSantaProject.Repositories
{
    public interface IContactRepository
    {
         List<Contact> GetContacts();
    }
}
