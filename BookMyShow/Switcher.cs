using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
    ///     Switcher class to switch the page using Navigate method
    /// 
    /// </summary>
   
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(Page newPage)
        {
            pageSwitcher.Navigate(newPage);
        }
    }
}
