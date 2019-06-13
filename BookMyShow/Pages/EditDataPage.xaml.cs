using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for EditDataPage.xaml
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
    ///     This class used edit the information like show time, name and city
    /// 
    /// ==================================================================
    /// </summary>
    public partial class EditDataPage : Page
    {
        private TicketDetails details;
        private TicketDetailList detailList;

        public EditDataPage(TicketDetails ticketDetails, TicketDetailList detailList)
        {
            InitializeComponent();
            Details = ticketDetails;
            DataContext = Details;
            DetailList = new TicketDetailList();
            DetailList = detailList;
            
        }
        bool hasError = false;

        public TicketDetails Details { get => details; set => details = value; }
        public TicketDetailList DetailList { get => detailList; set => detailList = value; }


        // GotFocus to hide the error and mark hasError false
        string oldShowTimeValue = string.Empty;
        private void comboBoxShowTime_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(oldShowTimeValue)) { oldShowTimeValue = (((FrameworkElement)sender).DataContext as TicketDetails).ShowTime; }
            if (lblErrorShowTime.Visibility == Visibility.Visible)
            {
                lblErrorShowTime.Visibility = Visibility.Hidden;
                comboBoxShowTime.BorderBrush = Brushes.Black;
                comboBoxShowTime.SelectedIndex = -1;
                hasError = false;
            }
        }

        // GotFocus to hide the error and mark hasError false
        string oldName = string.Empty;
        private void txtBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(oldName)) { oldName = (((FrameworkElement)sender).DataContext as TicketDetails).Name; }
            if (lblErrorName.Visibility == Visibility.Visible)
            {
                lblErrorName.Visibility = Visibility.Hidden;
                txtBoxName.BorderBrush = Brushes.Black;
                txtBoxName.Text = string.Empty;
                hasError = false;
            }
        }

        // GotFocus to hide the error and mark hasError false
        string oldCityValue = string.Empty;
        private void comboBoxCity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(oldCityValue)) { oldCityValue = (((FrameworkElement)sender).DataContext as TicketDetails).City; }
            if (lblErrorCity.Visibility == Visibility.Visible)
            {
                lblErrorCity.Visibility = Visibility.Hidden;
                comboBoxCity.BorderBrush = Brushes.Black;
                comboBoxCity.SelectedIndex = -1;
                hasError = false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if(oldCityValue == string.Empty) { oldCityValue = Details.City; }
            if (oldName == string.Empty) { oldName = Details.Name; }
            if (oldShowTimeValue == string.Empty) { oldShowTimeValue = Details.ShowTime; }
            DetailList.TicketList.Where(t => t.BookingID.Equals(Details.BookingID)).FirstOrDefault().City = oldCityValue;
            DetailList.TicketList.Where(t => t.BookingID.Equals(Details.BookingID)).FirstOrDefault().Name = oldName;
            DetailList.TicketList.Where(t => t.BookingID.Equals(Details.BookingID)).FirstOrDefault().ShowTime = oldShowTimeValue;

            DisplayDataGrid displayDataGrid = new DisplayDataGrid(DetailList);
            Switcher.Switch(displayDataGrid);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            // check showtime selection
            int showTimeIndex = comboBoxShowTime.SelectedIndex;
            string showTime = string.Empty;
            if (showTimeIndex != -1)
            {
                showTime = comboBoxShowTime.SelectedValue.ToString();
            }
            else
            {
                lblErrorShowTime.Visibility = Visibility.Visible;
                comboBoxShowTime.BorderBrush = Brushes.Red;
                hasError = true;
            }

            // check name
            string name = txtBoxName.Text;
            if ((string.IsNullOrWhiteSpace(name)) || name.Length <= 2)
            {
                lblErrorName.Visibility = Visibility.Visible;
                txtBoxName.BorderBrush = Brushes.Red;
                hasError = true;
            }

            // check the city
            // check showtime selection
            int cityIndex = comboBoxCity.SelectedIndex;
            string city = string.Empty;
            if (cityIndex != -1)
            {
                city = comboBoxCity.SelectedValue.ToString();
            }
            else
            {
                lblErrorCity.Visibility = Visibility.Visible;
                comboBoxCity.BorderBrush = Brushes.Red;
                hasError = true;
            }
            if (!hasError)
            {                
                string message = string.Format("Booking id: {0} is updated successfully. XML file has been updated.", Details.BookingID);
                MessageBox.Show(message, "Update Status", MessageBoxButton.OK, MessageBoxImage.Information);
                // send updated DetailList to DisplayDataGrid page
                DisplayDataGrid displayDataGrid = new DisplayDataGrid(DetailList);
                Switcher.Switch(displayDataGrid);
            }                       
        }       
    }
}
