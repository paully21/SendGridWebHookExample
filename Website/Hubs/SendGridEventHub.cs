using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SendGridWebHookLibrary.Models;

namespace Website.Hubs
{
    public class SendGridEventHub : Hub
    {
        public void UpdateEventList(List<SendGridEvent> eventList)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<SendGridEventHub>();
            context.Clients.All.receiveUpdatedEventList(eventList);
        }
    }
}