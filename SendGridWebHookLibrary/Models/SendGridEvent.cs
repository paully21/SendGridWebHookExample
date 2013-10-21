using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SendGridWebHookLibrary.Models
{
    [Table("tbl_SendGridEvents")]
    public class SendGridEvent
    {
        public SendGridEvent()
        {

        }

        public SendGridEvent(SendGridSentEvent sentEvent)
        {
            Event = sentEvent.@event;
            EmailAddress = sentEvent.email;
            Category = sentEvent.category;
            Response = sentEvent.response;
            Attempt = sentEvent.attempt;
            EventDate = Util.TimeStampToDateTime(Convert.ToDouble(sentEvent.timestamp));
            Url = sentEvent.url;
            Status = sentEvent.status;
            Reason = sentEvent.reason;
            Type = sentEvent.type;
        }

        [Column("SendGridEventID")]
        public int SendGridEventID { get; set; }        
        [Column("Event")]
        public string Event { get; set; }
        [Column("EmailAddress")]
        public string EmailAddress { get; set; }
        [Column("Category")]
        public string Category { get; set; }
        [Column("Response")]
        public string Response { get; set; }
        [Column("Attempt")]
        public string Attempt { get; set; }
        [Column("EventDate")]
        public DateTime EventDate { get; set; }
        [Column("Url")]
        public string Url { get; set; }
        [Column("Status")]
        public string Status { get; set; }
        [Column("Reason")]
        public string Reason { get; set; }
        [Column("Type")]
        public string Type { get; set; }

        public override string ToString()
        {
            string ret = "Event : " + Event + "\n";
            ret += "EmailAddress : " + EmailAddress + "\n";
            ret += "Category : " + Category + "\n";
            ret += "Response : " + Response + "\n";
            ret += "Attempt : " + Attempt + "\n";
            ret += "EventDate : " + EventDate.ToString() + "\n";
            ret += "Url : " + Url + "\n";
            ret += "Status : " + Status + "\n";
            ret += "Reason : " + Reason + "\n";
            ret += "Type : " + Type + "\n";
            return ret;
        }

        public string ToHtmlString()
        {
            string ret = this.ToString().Replace("\n", "<br />\n");
            return ret;
        }

       
    }
}