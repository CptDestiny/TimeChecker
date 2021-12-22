using System;
using System.Windows;
using TimeChecker.WPF.Services;
using TimeChecker.WPF.Utility;

namespace TimeChecker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public TimeWatch MainTimewatch { get; set; }

        public TimeWatch BreakTimewatch { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Exit += new ExitEventHandler(ExitApp);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MainTimewatch = new TimeWatch();
            BreakTimewatch = new TimeWatch();

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
                //Check if user is checking in or checking out
                if (CheckInButton.IsChecked == true)
                {
                    /*Since the User is checking in, we create a start timeentry, access the BLL and hand over the user and check-type data,
                    /change status and start stopwatch,
                    /Then make the break buttons appear
                    */
                    try
                    {
                        TimeManagerService timeSet = new TimeManagerService(user, 1,DateTime.Now, "");
                        StatusScreen.Text = "Checked In";
                        MainTimewatch.StopwatchStart();
                        BreakButton.Visibility = Visibility.Visible;
                        BreakTimeWatch.Visibility = Visibility.Visible;
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
                        CommentWindowService commentBox = new CommentWindowService();
                        MainTimewatch.StopwatchStop();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                }
            }

            private void BreakButton_OnClick(object sender, RoutedEventArgs e)
            {
                string user = "DummyUser";
                //User -> from config file (XML)??. Can't add the System.Configuration.dll reference in 5.0...
                //string sAttr = ConfigurationManager.AppSettings.Get("User");

                /*Since the User is pausing the TimeChecker, we create a start Break timeentry, access the BLL and hand over the user and check-type data,
                /change status, stop the maintime stopwatch, start the break stopwatch and disable the Checkin-button
                /
                */
                if (BreakButton.IsChecked == true)
                {
                    try
                    {
                    TimeManagerService timeSet = new TimeManagerService(user, 3, DateTime.Now, "");
                    StatusScreen.Text = "Check In paused";
                        MainTimewatch.StopwatchStop();
                        BreakTimewatch.StopwatchStart();
                        CheckInButton.IsEnabled = false;
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
                        TimeManagerService timeSet = new TimeManagerService(user, 4, DateTime.Now, "");
                        CheckInButton.IsEnabled = true;
                        StatusScreen.Text = "Checked In";
                        MainTimewatch.StopwatchStart();
                        BreakTimewatch.StopwatchStop();
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

            private void ExitApp(object sender, ExitEventArgs e)
            {
                MessageBox.Show("TimeChecker wurde beendet.");
            }


    }
}

