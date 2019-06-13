using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace BookMyShow
{
    /// <summary>
    /// Interaction logic for DisplayDataGrid.xaml
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
    ///     This class used to display the booked shows in the data grid and saving/retriving data to the xml file
    ///     Display button will display the data from the file
    ///     Searh button to search the data in grid based on entered value like name, city and genre
    ///     Each row of data grid contais the Edit and Delete button.
    ///     Edit button to edit the name, City and Show time by redirecting to the edit page.
    ///     Delete button will delete the entry from the grid as well file
    /// 
    /// ==================================================================
    /// </summary>


    public partial class DisplayDataGrid : Page
    {
        private TicketDetails ticketData = null;
        private ObservableCollection<TicketDetails> ticketDetailCollection = null;
        TicketDetailList DetailList = null;

        // constructor with TicketDetailList to handle the drid item source, 
        //   writing & reading XML files and ObservableCollection
        public DisplayDataGrid(TicketDetailList detailList)
        {
            InitializeComponent();
            TicketData = new TicketDetails();
            DetailList = new TicketDetailList();
            DetailList = detailList;
            TicketDetailCollection = PopulateCollection(DetailList);
            dgShowDetails.ItemsSource = TicketDetailCollection.OrderBy(t=>t.ShowDate);

            GenerateXMLData(DetailList);

        }

        private void GenerateXMLData(TicketDetailList detailList)
        {
            if (detailList.Count() > 0)
            {
                XmlSerializer serializer =
                                   new XmlSerializer(typeof(TicketDetailList));
                TextWriter writer = new StreamWriter("BoockedShowsDetails.xml");
                serializer.Serialize(writer, detailList);
                writer.Close();
            }
        }

        // method to populate the ObservableCollection
        private ObservableCollection<TicketDetails> PopulateCollection(TicketDetailList detailListData)
        {
            TicketDetailCollection = new ObservableCollection<TicketDetails>();
            for (int i = 0; i < detailListData.Count(); ++i)
            {
                var tDetails = DetailList[i];
                TicketDetailCollection.Add(tDetails);
            }
            return TicketDetailCollection;
        }

        public ObservableCollection<TicketDetails> TicketDetailCollection { get => ticketDetailCollection; set => ticketDetailCollection = value; }
        public TicketDetails TicketData { get => ticketData; set => ticketData = value; }

        // Click event to redirect the user on Entry page
        private void btnBookNewShow_Click(object sender, RoutedEventArgs e)
        {
            ShowEntry ShowEntrypage = new ShowEntry(DetailList);
            Switcher.Switch(ShowEntrypage);
        }

       
        // Click to display the data from the file to the data grid
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            if (TicketDetailCollection.Count() > 0)
            {
                TicketDetailList ticketDetailList = null;
                XmlSerializer serializer = new XmlSerializer(typeof(TicketDetailList));
                StreamReader reader = new StreamReader("BoockedShowsDetails.xml");

                ticketDetailList = (TicketDetailList)serializer.Deserialize(reader);                
                dgShowDetails.ItemsSource = ticketDetailList.TicketList;
                reader.Close();                
            }
            else
            {
                MessageBox.Show("There are no data avaialbe to display.", "No Data Found", MessageBoxButton.OK, MessageBoxImage.Error);                
            }

        }

        // Click to search the data based on enter text
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (TicketDetailCollection.Count() > 0)
            {
                string searchText = txtBoxSearch.Text;
                if (!string.IsNullOrWhiteSpace(searchText) && searchText.Trim().Length > 0)
                {
                    var searhQuery = TicketDetailCollection.Where(t => t.City.ToLower().Contains(searchText.Trim().ToLower()) || t.Name.ToLower().Contains(searchText.Trim().ToLower()) || t.Genre.ToLower().Contains(searchText.Trim().ToLower()) || t.ShowTime.ToLower().Contains(searchText.Trim().ToLower()) || t.Price.ToString().ToLower().Contains(searchText.Trim().ToLower()));
                    dgShowDetails.ItemsSource = searhQuery;
                }
                else
                {
                    MessageBox.Show("Please enter City OR Name OR Genre OR Show Time OR Price to search the data", "Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("There are no data available to seacrh.", "No Data Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

     
        // Click to delete the data from the list and update the file
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (dgShowDetails.HasItems)
            {
                // take the data from the sender object
                TicketDetails ticketDetails = ((FrameworkElement)sender).DataContext as TicketDetails;
                // search for booking id and collect it in one variable
                var query = TicketDetailCollection.Where(t => t.BookingID.Equals(ticketDetails.BookingID));
                if (query != null && query.Count() > 0)
                {
                    foreach (TicketDetails td in query)
                    {
                        // delete the record and break the loop.
                        TicketDetailCollection.Remove(td);
                        DetailList.TicketList.Remove(td);
                        break;
                    }
                    // show the confirmation message and update the file
                    MessageBox.Show("Your booked ticket has been cancelled successfully. XML file has been updated", "Ticket Cancelation Status", MessageBoxButton.OK, MessageBoxImage.Information);
                    dgShowDetails.ItemsSource = TicketDetailCollection;
                    GenerateXMLData(DetailList);
                }
            }

        }

        // Click to edit the data, redirects to the EditShowData page
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TicketDetails obj = ((FrameworkElement)sender).DataContext as TicketDetails;
            
            // pass the whole list with booking id, so getting back to this page, we can use the constructer.
            EditDataPage editDataPage = new EditDataPage(obj, DetailList);
            Switcher.Switch(editDataPage);            
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtBoxSearch.Text;
            if (TicketDetailCollection.Count() > 0)
            {
                if (!string.IsNullOrWhiteSpace(searchText) && searchText.Trim().Length > 0)
                {
                    var searhQuery = TicketDetailCollection.Where(t => t.City.ToLower().Contains(searchText.Trim().ToLower()) || t.Name.ToLower().Contains(searchText.Trim().ToLower()) || t.Genre.ToLower().Contains(searchText.Trim().ToLower()) || t.ShowTime.ToLower().Contains(searchText.Trim().ToLower()) || t.Price.ToString().ToLower().Contains(searchText.Trim().ToLower())).OrderBy(t=>t.SeatClass);
                    dgShowDetails.ItemsSource = searhQuery;
                }
                else if (string.IsNullOrWhiteSpace(searchText) && searchText.Trim().Length == 0)
                {
                    dgShowDetails.ItemsSource = TicketDetailCollection.OrderBy(t=>t.ShowDate);
                }
            }
                
            
        }
    }
}
    



   



