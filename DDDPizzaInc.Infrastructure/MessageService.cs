using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.DomainModels.Interfaces;
using Twilio;

namespace DDDPizzaInc.Infrastructure
{
    public class MessageService : IMessageService 
    {
        private readonly TwilioRestClient _twilioRestClient;

        public MessageService()
        {
            _twilioRestClient = new TwilioRestClient(ConfigurationManager.AppSettings.Get("twilio:accountSid"),
                                        ConfigurationManager.AppSettings.Get("twilio:authToken"));
        }

        public void NotifyDelivery(Order order)
        {
            var message = String.Format("{0} has placed an order for delivery.", order.Name);
            _twilioRestClient.SendMessage("8315861310", "8319700072", message);
        }
    }
}
