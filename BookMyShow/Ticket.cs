using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
    ///    Abstarct class with the properties of the ticket with and abstract method
    /// 
    /// </summary>


    [XmlInclude(typeof(GoldTicket))]
    [XmlInclude(typeof(PlatinumTicket))]
    [XmlInclude(typeof(SilverTicket))]
    public abstract class Ticket : ITicket
    {
        private TicketDetails tDetails;

        public Ticket() { TDetails = new TicketDetails(); }

        public Ticket(string bookinId,string genre, string movie, string showTime, string showDate, int numberOfSeat, string seatClass, string name, string city, int price)
        {
            TDetails = new TicketDetails
            {
                BookingID = bookinId,
                Genre = genre,
                Movie = movie,
                ShowTime = showTime,
                ShowDate = showDate,
                NumberOfSeat = numberOfSeat,
                SeatClass = seatClass,
                Name = name,
                City = city,
                Servcie = ProvidedService(),
                Price = price
            };

        }

        public TicketDetails TDetails { get => tDetails; set => tDetails = value; }
        public abstract string ProvidedService();
    }
}
