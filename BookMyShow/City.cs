using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow
{
    /// <summary>
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
    ///     This class used to define data using data island
    ///     Properties is bind with the controls
    /// 
    /// ==================================================================
    /// </summary>


    public class City
    {
        // name to store the City name
        // id to store the id of the list
        private string name;
        private int id;

        public City()
        {
        }

        public City(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }

    public class Cities : List<City> { }
}
