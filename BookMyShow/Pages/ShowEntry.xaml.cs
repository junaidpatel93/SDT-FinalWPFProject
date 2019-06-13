using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Page1.xaml
    /// ========================== ShowEntry.cs ==========================
    /// ==================================================================
    /// Controls: 
    ///     Genre: ComboBox
    ///             -- Master data bindig
    ///     Moview: ComboBox
    ///             -- Master data binding
    ///     Show Time: ComboBox
    ///             -- Data island binding
    ///     Show Day : ComboBox
    ///             -- Array list binding
    ///     Number of Seat: TextBox
    ///             -- user input, Conver to check the input
    ///     Seat Class : Group Box with RadioButtons within the stackpanel
    ///             -- User selection
    ///     Your Name: TextBox
    ///             -- User input
    ///     City: ComboBox
    ///             -- Data island binding
    ///     Book: Button
    ///             -- Button click by user
    ///     Check Deatils: Button
    ///             -- Button click by user
    ///             -- Redirect to the next page
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
    ///     This class validates the entred data by user.
    ///     Click on Book will book the show 
    ///         if all fields are valid
    ///         else display error.
    /// 
    /// ==================================================================
    /// </summary>
    /// 
    public partial class ShowEntry : Page
    {
        private const int TOTAL_DAYS = 15;
        TicketDetailList DetailList = null;

        // Total seat per day to check, if show is book for the day or few seats are left
        private const int TOTALSEATPERDAY = 25;

        // conts values for seat number
        private const int MINSEATNUMBER = 0;
        private const int MAXSEATNUMBER = 7;

        // ObservableCollection to store the list of ticket details. 
        private ObservableCollection<TicketDetails> ticketDetailCollection = null;

        // Titcket deatils to populate gold, platinum and silver type of ticket
        private TicketDetails ticketData = null;

        // List of string to populate the days list for the combobox. Assign the list to the combo box' item source
        List<string> DayList = new List<string>();
        public ShowEntry()
        {
            InitializeComponent();
            DetailList = new TicketDetailList();
            TicketDetailCollection = new ObservableCollection<TicketDetails>();
            TicketData = new TicketDetails();
            comboBoxShowDay.ItemsSource = GetDays();
            Group group = GenreMovieSelction();
            comboBoxGenre.DataContext = group;
            comboBoxMovie.DataContext = group;
            txtBoxNumberOfSeat.DataContext = this;
            txtBoxName.DataContext = this;
        }

        public ShowEntry(TicketDetailList detailList)
        {
            InitializeComponent();
            DetailList = new TicketDetailList();
            TicketDetailCollection = new ObservableCollection<TicketDetails>();
            DetailList = detailList;
            for (int i = 0; i < DetailList.Count(); ++i)
            {
                var tDetails = DetailList[i];
                TicketDetailCollection.Add(tDetails);
            }

            TicketData = new TicketDetails();
            comboBoxShowDay.ItemsSource = GetDays();
            Group group = GenreMovieSelction();
            comboBoxGenre.DataContext = group;
            comboBoxMovie.DataContext = group;
            txtBoxNumberOfSeat.DataContext = this;
            txtBoxName.DataContext = this;

        }

        private Ticket populateTicketDetails;

        public ObservableCollection<TicketDetails> TicketDetailCollection { get => ticketDetailCollection; set => ticketDetailCollection = value; }
        public TicketDetails TicketData { get => ticketData; set => ticketData = value; }
        public Ticket PopulateTicketDetails { get => populateTicketDetails; set => populateTicketDetails = value; }

        // flag to check error
        bool hasError = false;        

        // get dates in DD-MM-YY
        private List<string> GetDays()
        {
            for (int i = 0; i <= TOTAL_DAYS; i++)
            {
                DateTime dt = DateTime.Now.AddDays(i);
                string Day = dt.ToString("ddd, dd MMM yy");
                DayList.Add(Day.ToUpper());
            }
            return DayList;
        }

        private Group GenreMovieSelction()
        {
            Group group = new Group("MovieGenre");
            group.Genres = new List<Genre>();


            // Action
            List<Movie> actionMovieList = new List<Movie>();
            Movie actionMovieZero = new Movie("--Select Movie--");
            actionMovieList.Add(actionMovieZero);
            Movie actionMovieOne = new Movie("Avengers");
            actionMovieList.Add(actionMovieOne);
            Movie actionMovieTwo = new Movie("The Maze Runner");
            actionMovieList.Add(actionMovieTwo);
            Movie actionMovieThree = new Movie("Bad Boys");
            actionMovieList.Add(actionMovieThree);
            Movie actionMovieFour = new Movie("Tomb Raider");
            actionMovieList.Add(actionMovieFour);

            Genre genreSelect = new Genre("--Select Genre--", new List<Movie>());
            group.Genres.Add(genreSelect);

            Genre genreAction = new Genre("Action", actionMovieList);
            group.Genres.Add(genreAction);

            // Drama
            List<Movie> dramaMovieList = new List<Movie>();
            Movie dramaMovieZero = new Movie("--Select Movie--");
            dramaMovieList.Add(dramaMovieZero);
            Movie dramaMovieOne = new Movie("Adrift");
            dramaMovieList.Add(dramaMovieOne);
            Movie dramaMovieTwo = new Movie("Midnight Sun");
            dramaMovieList.Add(dramaMovieTwo);
            Movie dramaMovieThree = new Movie("Love, Simon");
            dramaMovieList.Add(dramaMovieThree);

            Genre dramaGenre = new Genre("Drama", dramaMovieList);
            group.Genres.Add(dramaGenre);

            // Horror
            List<Movie> horrorMovieList = new List<Movie>();
            Movie horrorMovieZero = new Movie("--Select Movie--");
            horrorMovieList.Add(horrorMovieZero);
            Movie horrorMovieOne = new Movie("The Nun");
            horrorMovieList.Add(horrorMovieOne);
            Movie horrorMovieTwo = new Movie("Slender Man");
            horrorMovieList.Add(horrorMovieTwo);
            Movie horrorMovieThree = new Movie("Holloween");
            horrorMovieList.Add(horrorMovieThree);
            Movie horrorMovieFour = new Movie("A Quiet Place");
            horrorMovieList.Add(horrorMovieFour);

            Genre horrorGenre = new Genre("Horror", horrorMovieList);
            group.Genres.Add(horrorGenre);


            return group;
        }

        private void btnBookClick(object sender, RoutedEventArgs e)
        {

            // check genre selection
            int genreIndex = comboBoxGenre.SelectedIndex;
            string genre = string.Empty;
            if (genreIndex != 0)
            {
                genre = ((Genre)comboBoxGenre.SelectedItem).Name;
            }
            else
            {
                lblErrorGenre.Visibility = Visibility.Visible;
                comboBoxGenre.BorderBrush = Brushes.Red;
                hasError = true;
            }


            // check move selection
            int movieIndex = comboBoxMovie.SelectedIndex;
            string movie = string.Empty;
            if (movieIndex != 0)
            {
                movie = ((Movie)comboBoxMovie.SelectedItem).Name;
            }
            else
            {
                lblErrorMovie.Visibility = Visibility.Visible;
                comboBoxMovie.BorderBrush = Brushes.Red;
                hasError = true;
            }

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

            // check showday selection
            int showDayIndex = comboBoxShowDay.SelectedIndex;
            string showDay = string.Empty;
            if (showTimeIndex != -1)
            {
                showDay = comboBoxShowDay.SelectionBoxItem.ToString();
            }
            else
            {
                lblErrorShowDay.Visibility = Visibility.Visible;
                comboBoxShowDay.BorderBrush = Brushes.Red;
                hasError = true;
            }

            // check the seat class            
            int seatIndex = comboBoxSeatClass.SelectedIndex;
            string seatClass = string.Empty;
            if (seatIndex != -1)
            {
                seatClass = comboBoxSeatClass.SelectedValue.ToString();
            }
            else
            {
                lblErrorSeatClass.Visibility = Visibility.Visible;
                comboBoxSeatClass.BorderBrush = Brushes.Red;
                hasError = true;
            }
                        

            // check the number of seat
            string seatNumberString = string.Empty;
            seatNumberString = txtBoxNumberOfSeat.Text;
            byte seatNumber = 0;
            if (!byte.TryParse(seatNumberString, out seatNumber) || (seatNumber <= MINSEATNUMBER) || (seatNumber >= MAXSEATNUMBER))
            {                
                lblErrorNumberOfSeat.Visibility = Visibility.Visible;
                txtBoxNumberOfSeat.BorderBrush = Brushes.Red;
                hasError = true;
            }           

            // check name
            string name = txtBoxName.Text;            
            if ((string.IsNullOrWhiteSpace(name)) || (name.Length <= 2))
            {
                lblErrorName.Visibility = Visibility.Visible;
                txtBoxName.BorderBrush = Brushes.Red;
                hasError = true;                
            }
            else if(!(string.IsNullOrWhiteSpace(name)))
            {
                Regex regex = new Regex(@"^[a-zA-Z-,]+(\s{0,1}[a-zA-Z-, ])*$");
                Match match = regex.Match(name);

                if (!match.Success)
                {
                    lblErrorName.Content = "Name contains only characters.";
                    lblErrorName.Visibility = Visibility.Visible;
                    txtBoxName.BorderBrush = Brushes.Red;
                    hasError = true;
                }                
            }

            // check the city            
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
                // check the day with total seat class values
                int totalBookedSeatPerClass = 0;
                if (TicketDetailCollection.Count() > 0 && !string.IsNullOrWhiteSpace(showDay))
                {
                    // gather the selected seat class details
                    var seatDetailWithTotalNumberOfSeatPerDay = TicketDetailCollection.Where(t => t.ShowDate.Equals(showDay));

                    if (seatDetailWithTotalNumberOfSeatPerDay.Count() > 0)
                    {
                        foreach (var number in seatDetailWithTotalNumberOfSeatPerDay)
                        {
                            totalBookedSeatPerClass += number.NumberOfSeat;
                        }
                        int leftSeat = TOTALSEATPERDAY - totalBookedSeatPerClass;

                        if (totalBookedSeatPerClass == TOTALSEATPERDAY)
                        {
                            hasError = CheckIfShowFullForAllDays(showDay);
                        }
                        else if (seatNumber > leftSeat)
                        {
                            string message = string.Format("Sorry. We have only {0} seats available for the day", leftSeat.ToString());
                            MessageBox.Show(message, "Seat availability", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            lblErrorNumberOfSeat.Visibility = Visibility.Visible;
                            txtBoxNumberOfSeat.BorderBrush = Brushes.Red;
                            hasError = true;
                        }
                    }
                }
            }
            if (!hasError)
            {
                // get the date time and pass it as bookingid
                string bookingID = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").ToString();

                switch (seatClass)
                {
                    case "Gold Class ($15)":
                        // create gold class object
                        int GoldPrice = (seatNumber * 15);
                        PopulateTicketDetails = new GoldTicket(bookingID, genre, movie, showTime, showDay, seatNumber, seatClass, name, city, GoldPrice);
                        break;
                    case "Platinum Class ($20)":
                        // create platinum class object
                        int PlatinumPrice = (seatNumber * 20);
                        PopulateTicketDetails = new PlatinumTicket(bookingID, genre, movie, showTime, showDay, seatNumber, seatClass, name, city, PlatinumPrice);
                        break;
                    case "Silver Class ($10)":
                        // create silver class object
                        int SilverPrice = (seatNumber * 10);
                        PopulateTicketDetails = new SilverTicket(bookingID, genre, movie, showTime, showDay, seatNumber, seatClass, name, city, SilverPrice);
                        break;
                    default:
                        MessageBox.Show("Seat class undefined");
                        break;
                }

                // add the ticket details to the DetailList and use same to write the data into xml file
                DetailList.TicketList.Add(PopulateTicketDetails.TDetails);

                // add the list to the collection to bind the data into the data grid
                TicketDetailCollection.Add(PopulateTicketDetails.TDetails);
                
                string message = string.Format("Hello {0}! Your show {1} has been booked on {2} at {3} successfully", name, movie.ToUpper().ToString(), showDay, showTime);
                MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();

            }
        }


        private void DisplayMessage(string seatClass, int AVAILABLE_SEAT_SLOT)
        {
            if (AVAILABLE_SEAT_SLOT < 0)
            {
                AVAILABLE_SEAT_SLOT = 0;
            }
            string message = string.Format(" {0} seats are available for {1}. Please try another seat class", AVAILABLE_SEAT_SLOT, seatClass);
            MessageBox.Show(message, "Seat availability", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            lblErrorSeatClass.Visibility = Visibility.Visible;            
        }

        private bool CheckIfShowFullForAllDays(string showDay)
        {
            string message = string.Format("Sorry. We are full for the day {0}. Please try another show day", showDay);
            MessageBox.Show(message, "Show is full", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            lblErrorShowDay.Visibility = Visibility.Visible;
            lblErrorShowDay.Content = message;
            comboBoxShowDay.BorderBrush = Brushes.Red;
            return true;
        }
                

        // GotFocus to hide the error and mark hasError false
        private void comboBoxGenre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorGenre.Visibility == Visibility.Visible)
            {
                lblErrorGenre.Visibility = Visibility.Hidden;
                comboBoxGenre.BorderBrush = Brushes.Black;
                comboBoxGenre.SelectedIndex = 0;
                hasError = false;
            }
        }

        // GotFocus to hide the error and mark hasError false
        private void comboBoxMovie_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorMovie.Visibility == Visibility.Visible)
            {
                lblErrorMovie.Visibility = Visibility.Hidden;
                comboBoxMovie.BorderBrush = Brushes.Black;
                comboBoxMovie.SelectedIndex = 0;
                hasError = false;
            }
        }

        // GotFocus to hide the error and mark hasError false
        private void comboBoxShowTime_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorShowTime.Visibility == Visibility.Visible)
            {
                lblErrorShowTime.Visibility = Visibility.Hidden;
                comboBoxShowTime.BorderBrush = Brushes.Black;
                comboBoxShowTime.SelectedIndex = -1;
                hasError = false;
            }
        }

        // GotFocus to hide the error and mark hasError false
        private void comboBoxShowDay_gotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorShowDay.Visibility == Visibility.Visible)
            {
                lblErrorShowDay.Visibility = Visibility.Hidden;
                comboBoxShowDay.BorderBrush = Brushes.Black;
                comboBoxShowDay.SelectedIndex = -1;
                hasError = false;
            }
        }

        // GotFocus to hide the error and mark hasError false
        private void txtBoxNumberOfSeat_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorNumberOfSeat.Visibility == Visibility.Visible)
            {
                lblErrorNumberOfSeat.Visibility = Visibility.Hidden;
                txtBoxNumberOfSeat.BorderBrush = Brushes.Black;
                txtBoxNumberOfSeat.Text = string.Empty;
                hasError = false;
            }
        }
               

        // GotFocus to hide the error and mark hasError false
        private void txtBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorName.Visibility == Visibility.Visible)
            {
                lblErrorName.Visibility = Visibility.Hidden;
                txtBoxName.BorderBrush = Brushes.Black;
                txtBoxName.Text = string.Empty;
                hasError = false;
            }

        }

        // GotFocus to hide the error and mark hasError false
        private void comboBoxCity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorCity.Visibility == Visibility.Visible)
            {
                lblErrorCity.Visibility = Visibility.Hidden;
                comboBoxCity.BorderBrush = Brushes.Black;
                comboBoxCity.SelectedIndex = -1;
                hasError = false;
            }
        }

        // Click to redirect user on DisplayDataGrid page
        private void btnCheckDetail_Click(object sender, RoutedEventArgs e)
        {
            if (DetailList.Count() > 0)
            {
                DisplayDataGrid displayDataGrid = new DisplayDataGrid(DetailList);
                Switcher.Switch(displayDataGrid);
            }
            else
            {
                MessageBox.Show("No one has booked yet", "Booking Status", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ClearFields()
        {
            comboBoxGenre.SelectedIndex = 0;
            comboBoxMovie.SelectedIndex = 0;
            comboBoxShowTime.SelectedIndex = -1;
            comboBoxShowDay.SelectedIndex = -1;
            comboBoxSeatClass.SelectedIndex = -1;
            txtBoxNumberOfSeat.Text = string.Empty;            
            txtBoxName.Text = string.Empty;
            comboBoxCity.SelectedIndex = -1;
        }

        private void comboBoxSeatClass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lblErrorSeatClass.Visibility == Visibility.Visible)
            {
                lblErrorSeatClass.Visibility = Visibility.Hidden;
                hasError = false;                    
            }
        }
    }
}
