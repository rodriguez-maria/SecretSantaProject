using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SecretSantaProject.Services
{
    public class TwilioSmsNotificationService : INotificationService
    {
        const string accountSid = "<Your Twilio Account Sid>";
        const string authToken = "<Your Twilio Account Auth Token>";

        public TwilioSmsNotificationService()
        {
            TwilioClient.Init(accountSid, authToken);
        }

        public void Notify(string to, string message)
        {
            var tMessage = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("<Your validated Twilio Phone Number>"),
                to: new Twilio.Types.PhoneNumber(to)
            );

            Console.WriteLine($"Sent to {to}. Messageid: {tMessage.Sid}");
        }
    }
}
