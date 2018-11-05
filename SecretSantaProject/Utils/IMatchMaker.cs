using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Utils
{
    public interface IMatchMaker<K>
    {
        IEnumerable<Tuple<K, K>> MatchMake(IEnumerable<K> items, int retry = 20);
    }
}
