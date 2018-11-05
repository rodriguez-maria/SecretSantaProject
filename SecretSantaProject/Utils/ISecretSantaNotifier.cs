using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Utils
{
    public interface ISecretSantaNotifier<K>
    {
        void Notify(IEnumerable<Tuple<K, K>> results);
    }
}
