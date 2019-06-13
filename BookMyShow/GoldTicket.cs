using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow
{
    /// <summary>
    /// 
    /// ==================================================================
    ///                             CREATED BY
    /// ------------------------------------------------------------------
    ///                             GAURAV BABBAR,
    ///                             JUNAID PATEL,
    ///                             PRIYANKA MONDAL,
    ///                             RUTAV KOTHARI.
    /// ==================================================================
    /// ==================================================================
    /// Description:
    ///     Type of ticket.
    ///     Implements Ticket class and overrides th ProvideService method
    /// 
    /// </summary>
    public class GoldTicket : Ticket
    {

        public GoldTicket() { }

        public GoldTicket(string bookinId, string genre, string movie, string showTime, string showDate, int numberOfSeat, string seatClass, string name, string city, int price) : base(bookinId, genre, movie, showTime, showDate, numberOfSeat, seatClass, name, city, price) { }
   
        public override string ProvidedService()
        {
            return "Service Drink";
        }
    }
}
