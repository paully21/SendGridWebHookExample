using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using SendGridWebHookLibrary.Models;
using Website.Hubs;
using SendGridWebHookLibrary.Managers;

namespace Website.Controllers
{
    public class SendGridEventsController : ApiController
    {
        
        // POST api/values
        public void Post([FromBody]SendGridSentEvent[] eventList)
        {
            if (eventList.Length > 0)
            {
                List<SendGridEvent> sgEvents = eventList.Select(s => new SendGridEvent(s)).ToList();
                SendGridEventManager.AddEvents(sgEvents);
                
                
                //HttpContext.Current.Application["eventCount"] = sgEvents.Count;
                //if (HttpContext.Current.Application["events"] != null)
                //{
                //    List<SendGridEvent> currentEvents = (List<SendGridEvent>)HttpContext.Current.Application["events"];
                //    sgEvents.AddRange(currentEvents);
                //}
                //HttpContext.Current.Application["events"] = sgEvents.ToList();



                var hub = new SendGridEventHub();
                hub.UpdateEventList(SendGridEventManager.GetEvents(0, 40));
            }
        }



        
    }
}
