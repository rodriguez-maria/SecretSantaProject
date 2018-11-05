using SecretSantaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Utils
{
    public interface IValidator<K>
    {
        bool Validate(K result);
    }
}
