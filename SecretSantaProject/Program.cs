using Autofac;
using SecretSantaProject.Models;
using SecretSantaProject.Repositories;
using SecretSantaProject.Services;
using SecretSantaProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new Exception("File name should be provided as argument.");
            }

            var builder = new ContainerBuilder();
            // Register individual components
            builder.RegisterInstance(new FileContactRepository(args[0]))
                   .As<IContactRepository>();

            builder.RegisterInstance(new ConsoleNotificationService())
                   .As<INotificationService>();

            builder.RegisterInstance(new DefaultSecretSantaValidator())
                   .As<IValidator<IEnumerable<Tuple<Contact, Contact>>>>();

            builder.RegisterType<SecretSantaMatchMaker>().As<IMatchMaker<Contact>>();

            builder.RegisterType<SecretSantaNotifier>().As<ISecretSantaNotifier<Contact>>();

            builder.RegisterType<SecretSantaManager>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var manager = scope.Resolve<SecretSantaManager>();
                manager.CreateSecretSantaAndNotify();
            }
        }
    }
}
