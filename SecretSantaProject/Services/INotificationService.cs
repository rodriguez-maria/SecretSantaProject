using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Services
{
    public interface INotificationService
    {
        void Notify(string to, string message);
    }
}
