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
    ///     TicketDetailList with list of TicketDetails
    ///     Having Add, Indexer, Clear, Count method and implemets the IDisposable class
    /// 
    /// </summary>


    [XmlRoot("ShowTicketList")]
    public class TicketDetailList : IDisposable
    {
        [XmlArray("TicketDeatilList")]
        [XmlArrayItem("TitckeDetails", typeof(TicketDetails))]

        private List<TicketDetails> ticketList;

        public TicketDetailList() { TicketList = new List<TicketDetails>(); }

        public void CreateTicket(TicketDetails ticketDetails)
        {
            TicketList.Add(ticketDetails);
        }

        public void Clear()
        {
            TicketList.Clear();
        }

        public int Count()
        {
            return TicketList.Count();
        }

        public void Sort()
        {
            TicketList.Sort();
        }

        public TicketDetails this[int i]
        {
            get { return TicketList[i]; }

        }

        public List<TicketDetails> TicketList { get => ticketList; set => ticketList = value; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
       
    }
}
