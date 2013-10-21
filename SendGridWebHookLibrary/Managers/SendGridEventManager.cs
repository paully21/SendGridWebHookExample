using SendGridWebHookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGridWebHookLibrary.Managers
{
    public class SendGridEventManager
    {
        /// <summary>
        /// Using Bulk Insert to add a list of posted events all at once to database
        /// </summary>
        /// <param name="sgEvents">The list of events to add</param>
        public static void AddEvents(List<SendGridEvent> sgEvents)
        {
            string[] propsToSkip = { "SendGridEventID" };

            Util.BulkInsert<SendGridEvent>(ConfigurationManager.ConnectionStrings["DataContext"].ConnectionString, "tbl_SendGridEvents", sgEvents, propsToSkip);
        }

        /// <summary>
        /// Adds a single event to the database
        /// </summary>
        /// <param name="sgEvent">The single event to add</param>
        /// <returns></returns>
        public static bool AddEvent(SendGridEvent sgEvent)
        {
           using(var ctx = new DataContext())
           {
               ctx.SendGridEvents.Add(sgEvent);
               return ctx.SaveChanges() > 0;
           }
        }

        /// <summary>
        /// Gets a list of events (by date descending) from the database
        /// </summary>
        /// <param name="numberToSkip">The starting record (used for paging)</param>
        /// <param name="numberToTake">The number of records to return (used for paging)</param>
        /// <returns></returns>
        public static List<SendGridEvent> GetEvents(int numberToSkip, int numberToTake)
        {
            using (var ctx = new DataContext())
            {
                var ret = ctx.SendGridEvents.OrderByDescending(sgEvent => sgEvent.EventDate)
                                            .Skip(numberToSkip)
                                            .Take(numberToTake)
                                            .ToList();
                return ret;
            }
        }
    }
}
