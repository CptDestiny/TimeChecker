using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TimeChecker.BLL;

namespace TimeChecker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
       

        private CommentBox commentBox;
        public CommentBox CommentBox { get; set; }

        private TimeWatch mainTimewatch;
        public TimeWatch MainTimewatch { get; set; }

        private TimeWatch breakTimewatch;
        public TimeWatch BreakTimewatch { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //Application.Current.Exit += new ExitEventHandler(ExitApp);
            //WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MainTimewatch = new TimeWatch();
            BreakTimewatch = new TimeWatch();
            CommentBox = new CommentBox();

            //Subscribing the MainTimeWatch and the BreakTimeWatch to the TickEvent delegate
            MainTimewatch.TickEvent += MainTimewatchTriggered;
            BreakTimewatch.TickEvent += BreakTimewatchTriggered;
        }
        

       private void CheckInButton_OnClick(object sender, RoutedEventArgs e)
        {
            string user = "DummyUser";
            //User -> from config file (XML)??. Can't add the System.Configuration.dll reference in 5.0...
            //string sAttr = ConfigurationManager.AppSettings.Get("User");

            //We need a BL object to access the BLL
            BusinessLogic bl = new BusinessLogic();

            //Check if user is checking in or checking out
            if (CheckInButton.IsChecked == true)
            {
                /*Since the User is checking in, we create a start timeentry, access the BLL and hand over the user and check-type data,
                /change status and start stopwatch,
                /Then make the break buttons appear
                */
                try
                {
                    var timeentry = bl.CreateTimeEntry(1, user, "");
                    StatusScreen.Text = "Checked In";
                    MainTimewatch.StopwatchStart();
                    BreakButton.Visibility = Visibility.Visible;
                    BreakTimeWatch.Visibility = Visibility.Visible;

                    string dictSet = "";
                    foreach (var element in timeentry)
                    {
                        dictSet = dictSet + $" {element},";
                    }
                    MessageBox.Show(dictSet);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
            else
            {
                /*Since the User is checking out, we disable the Checking-button and Break-Button and open a new Window, where the user can specify his/her work
                /change status and stop stopwatch,
                /Then make the break buttons disappear again
                 */
                try
                {
                    CheckInButton.IsEnabled = false;
                    BreakButton.IsEnabled = false;
                    StatusScreen.Text = "About to Check Out";
                    CommentBox.CreateWindow();
                    MainTimewatch.StopwatchStop();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        //private void CommentSaveButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    /*After filling the user-comment box, we get the Text from the Textbox and access the BLL to handover the dataset
        //    /Reset the Stopwatch and change the status now to checked out
        //    /Then we enable the Checkin-Button and Break-Button again
        //    /Finally we remove the visiblity of the break-themes and close and empty the CommentWindow Object.
        //    /TimeChecker has been entirely reset.
        //     */
        //    BusinessLogic bl = new BusinessLogic();
        //    var user = "DummyUser";
        //    var comment = CommentBox.commentTextBox.Text;

        //    var timeentry = bl.CreateTimeEntry(2, user, comment);
        //    StatusScreen.Text = "Checked Out";
        //    TimeWatch.Text = MainTimewatch.StopwatchReset();
        //    BreakTimeWatch.Text = BreakTimewatch.StopwatchReset();


        //    CheckInButton.IsEnabled = true;
        //    BreakButton.IsEnabled = true;

        //    BreakButton.Visibility = Visibility.Hidden;
        //    BreakTimeWatch.Visibility = Visibility.Hidden;

        //    CommentBox.commentWindow.Close();
        //    CommentBox.commentWindow.Content = null;

        //    string dictSet = "";
        //    foreach (var element in timeentry)
        //    {
        //        dictSet = dictSet + $" {element},";
        //    }
        //    MessageBox.Show(dictSet);
        //}

        //private void CommentCancelButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    /* Checking out was cancelled, so we reset back to check in status
        //    /Continue the stopwatch and change the status to checked in again
        //    /Then we enable the Checkin-Button and Break-Button again and reset the "isChecked" status, otherwise button is "checked out"
        //    /Finally we close and empty the CommentWindow Object.
        //    /TimeChecker has been reset back to checked in status.
        //     */

        //    StatusScreen.Text = "Checked In";
        //    MainTimewatch.StopwatchStart();
        //    CheckInButton.IsEnabled = true;
        //    CheckInButton.IsChecked = true;
        //    BreakButton.IsEnabled = true;

        //    CommentBox.commentWindow.Close();
        //    CommentBox.commentWindow = null;

        //}


        private void BreakButton_OnClick(object sender, RoutedEventArgs e)
        {
            string user = "DummyUser";
            //User -> from config file (XML)??. Can't add the System.Configuration.dll reference in 5.0...
            //string sAttr = ConfigurationManager.AppSettings.Get("User");

            //We need a BL object to access the BLL
            BusinessLogic bl = new BusinessLogic();

            /*Since the User is pausing the TimeChecker, we create a start Break timeentry, access the BLL and hand over the user and check-type data,
            /change status, stop the maintime stopwatch, start the break stopwatch and disable the Checkin-button
            /
            */
            if (BreakButton.IsChecked == true)
            {
                try
                {
                    var timeentry = bl.CreateTimeEntry(3, user, "");
                    StatusScreen.Text = "Check In paused";
                    MainTimewatch.StopwatchStop();
                    BreakTimewatch.StopwatchStart();
                    CheckInButton.IsEnabled = false;

                    string dictSet = "";
                    foreach (var element in timeentry)
                    {
                        dictSet = dictSet + $" {element},";
                    }
                    MessageBox.Show(dictSet);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
            else
            {
                /*Since the User is ending the break, we create a end Break timeentry, access the BLL and hand over the user and check-type data,
                /change status and start stopwatch,
                /Then make the break buttons disappear again
                 */
                try
                {
                    var timeentry = bl.CreateTimeEntry(4, user, "");
                    CheckInButton.IsEnabled = true;
                    StatusScreen.Text = "Checked In";
                    MainTimewatch.StopwatchStart();
                    BreakTimewatch.StopwatchStop();

                    string dictSet = "";
                    foreach (var element in timeentry)
                    {
                        dictSet = dictSet + $" {element},";
                    }
                    MessageBox.Show(dictSet);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }

            }
        }

        //Access the Timewatch Events to trigger, since its subscribed to the delegate
        // -> The MainTimeWatch Textbox is to be updated with as a running timewatch in the defined DispatchTimers interval
        private void MainTimewatchTriggered(object? sender, TickEventArgs e)
        {
            var CurrentTime = String.Format("{0:00}:{1:00}:{2:00}",
                e.TimeSpan.Hours, e.TimeSpan.Minutes, e.TimeSpan.Seconds);
            TimeWatch.Text = CurrentTime;
        }

        //Access the Timewatch Events to trigger, since its subscribed to the delegate
        // -> The BreakTimeWatch Textbox is to be updated with as a running timewatch in the defined DispatchTimers interval
        private void BreakTimewatchTriggered(object? sender, TickEventArgs e)
        {
            var CurrentTime = String.Format("{0:00}:{1:00}:{2:00}",
                e.TimeSpan.Hours, e.TimeSpan.Minutes, e.TimeSpan.Seconds);
            BreakTimeWatch.Text = CurrentTime;
        }

        //Create CommentWindow Function to create a new Window to enter a Comment. Should only live, when about to check out.
        //private void CreateCommentWindow()
        //{
        //    //Define Window
        //    CommentBox = new CommentBox();

        //    CommentBox.commentWindow.Title = "Timeentry Comment";
        //    CommentBox.commentWindow.Height = 280;
        //    CommentBox.commentWindow.Width = 335;


        //    //Define new Grid & Col / Row definitions
        //    var commentWindowGrid = new Grid();
        //    commentWindowGrid.Background = Brushes.Black;
        //    //commentWindowGrid.ShowGridLines = true;
        //    //Column definition
        //    ColumnDefinition commentWindowColDef1 = new ColumnDefinition();
        //    commentWindowColDef1.Width = new GridLength(1, GridUnitType.Auto);
        //    ColumnDefinition commentWindowColDef2 = new ColumnDefinition();
        //    commentWindowColDef2.Width = new GridLength(1, GridUnitType.Auto);
        //    RowDefinition commentWindowRowDef1 = new RowDefinition();
        //    commentWindowRowDef1.Height = new GridLength(1, GridUnitType.Auto);
        //    RowDefinition commentWindowRowDef2 = new RowDefinition();
        //    commentWindowRowDef2.Height = new GridLength(1, GridUnitType.Auto);
        //    commentWindowGrid.ColumnDefinitions.Add(commentWindowColDef1);
        //    commentWindowGrid.ColumnDefinitions.Add(commentWindowColDef2);
        //    commentWindowGrid.RowDefinitions.Add(commentWindowRowDef1);
        //    commentWindowGrid.RowDefinitions.Add(commentWindowRowDef2);


        //    //Define Stack Panel 1
        //    StackPanel _commentStackPanel1 = new StackPanel();
        //    _commentStackPanel1.HorizontalAlignment = HorizontalAlignment.Stretch;
        //    _commentStackPanel1.VerticalAlignment = VerticalAlignment.Top;
        //    Grid.SetColumn(_commentStackPanel1, 0);
        //    Grid.SetRow(_commentStackPanel1, 0);
        //    Grid.SetColumnSpan(_commentStackPanel1, 2);

        //    //Define Stack Panel 2
        //    StackPanel _commentStackPanel2 = new StackPanel();
        //    _commentStackPanel2.HorizontalAlignment = HorizontalAlignment.Left;
        //    _commentStackPanel2.VerticalAlignment = VerticalAlignment.Top;
        //    _commentStackPanel2.Orientation = Orientation.Vertical;
        //    Grid.SetColumn(_commentStackPanel2, 0);
        //    Grid.SetRow(_commentStackPanel2, 1);

        //    //Define Stack Panel 3
        //    StackPanel _commentStackPanel3 = new StackPanel();
        //    _commentStackPanel3.HorizontalAlignment = HorizontalAlignment.Right;
        //    _commentStackPanel3.VerticalAlignment = VerticalAlignment.Top;
        //    _commentStackPanel3.Orientation = Orientation.Vertical;
        //    Grid.SetColumn(_commentStackPanel3, 1);
        //    Grid.SetRow(_commentStackPanel3, 1);

        //    CommentBox.commentTextBlock.Height = 50;
        //    CommentBox.commentTextBlock.Width = 300;
        //    CommentBox.commentTextBlock.Margin = new Thickness(10, 10, 0, 5);
        //    CommentBox.commentTextBlock.Foreground = Brushes.White;
        //    CommentBox.commentTextBlock.TextWrapping = TextWrapping.Wrap;
        //    CommentBox.commentTextBlock.Text = "You have the possibility to enter a comment in the textbox below before saving the data:";

        //    CommentBox.commentTextBox.Height = 100;
        //    CommentBox.commentTextBox.Width = 300;
        //    CommentBox.commentTextBox.Margin = new Thickness(10, 0, 0, 5);
        //    CommentBox.commentTextBox.TextWrapping = TextWrapping.Wrap;
        //    CommentBox.commentTextBox.Text = "";

        //    CommentBox.commentSendButton.Height = 50;
        //    CommentBox.commentSendButton.Width = 140;
        //    CommentBox.commentSendButton.Margin = new Thickness(10, 5, 0, 0);
        //    CommentBox.commentSendButton.Content = "Save and Check Out";
        //    CommentBox.commentSendButton.Click += this.CommentSaveButton_OnClick;


        //    CommentBox.abboardButton.Height = 50;
        //    CommentBox.abboardButton.Width = 140;
        //    CommentBox.abboardButton.Margin = new Thickness(0, 5, 0, 0);
        //    CommentBox.abboardButton.Content = "Cancel Checking Out";
        //    CommentBox.abboardButton.Click += this.CommentCancelButton_OnClick;

        //    _commentStackPanel1.Children.Add(CommentBox.commentTextBlock);
        //    _commentStackPanel1.Children.Add(CommentBox.commentTextBox);
        //    _commentStackPanel2.Children.Add(CommentBox.commentSendButton);
        //    _commentStackPanel3.Children.Add(CommentBox.abboardButton);

        //    // Add child content to the parent Grid.
        //    commentWindowGrid.Children.Add(_commentStackPanel1);
        //    commentWindowGrid.Children.Add(_commentStackPanel2);
        //    commentWindowGrid.Children.Add(_commentStackPanel3);

        //    //Add Grid to the Window and show
        //    CommentBox.commentWindow.Content = commentWindowGrid;
        //    CommentBox.commentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //    CommentBox.commentWindow.Show();
        //}

        //Behavior on exiting the app.
        private void ExitApp(object sender, ExitEventArgs e)
        {
            MessageBox.Show("TimeChecker wurde beendet.");
        }

    }

}
