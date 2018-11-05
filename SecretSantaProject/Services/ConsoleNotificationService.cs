using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject.Services
{
    public class ConsoleNotificationService : INotificationService
    {
        public void Notify(string to, string message)
        {
            Console.WriteLine($"[{to}] -> {message}");
        }
    }
}
