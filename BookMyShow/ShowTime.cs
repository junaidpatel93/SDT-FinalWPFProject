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
    ///     Class used in data island for Show Time
    /// 
    /// </summary>
    public class ShowTime
    {
        private string name;
        private int id;

        public ShowTime()
        {
        }

        public ShowTime(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
    public class ShowTimeList : List<ShowTime> { }
}
