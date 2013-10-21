using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendGridWebHookLibrary.Models
{
    public class SendGridSentEvent
    {
        public string @event { get; set; }
        public string email { get; set; }
        public string category { get; set; }
        public string response { get; set; }
        public string attempt { get; set; }
        public string timestamp { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public string type { get; set; }
    }
}