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
    ///     Concrete class with Ticket details properties
    /// 
    /// </summary>
    

    public class TicketDetails
    {
        private string bookingId;
        private string genre;
        private string movie;
        private string showTime;
        private string showDate;
        private int numberOfSeat;
        private string seatClass;
        private string name;
        private string city;
        private string service;
        private int price;

        public TicketDetails() { }
        
        public TicketDetails(string bookingID , string genre, string movie, string showTime, string showDate, int numberOfSeat, string seatClass, string name, string city, string service, int price)
        {
            this.bookingId = bookingID;
            this.genre = genre;
            this.movie = movie;
            this.showTime = showTime;
            this.showDate = showDate;
            this.numberOfSeat = numberOfSeat;
            this.seatClass = seatClass;
            this.name = name;
            this.city = city;
            this.service = service;
            this.price = price;
        }

        public string BookingID { get => bookingId; set => bookingId = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Movie { get => movie; set => movie = value; }
        public string ShowTime { get => showTime; set => showTime = value; }
        public string ShowDate { get => showDate; set => showDate = value; }
        public int NumberOfSeat { get => numberOfSeat; set => numberOfSeat = value; }
        public string SeatClass { get => seatClass; set => seatClass = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Servcie { get => service; set => service = value; }
        public int Price { get => price; set => price = value; }
    }
}
