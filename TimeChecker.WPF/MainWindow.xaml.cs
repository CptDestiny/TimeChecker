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
using TimeChecker.BLL;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;

namespace TimeChecker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly TextBlock _commentTextBlock = new TextBlock();
        private readonly TextBox _commentTextBox = new TextBox();
        private readonly Button _commentSendButton = new Button();
        private readonly Button _abboardButton = new Button();
        private readonly StackPanel _commentStackPanel = new StackPanel();
        private Window CommentWindow = new Window();

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Exit += new ExitEventHandler(ExitApp);
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CheckInButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool result;
            string user;
            BusinessLogic bl = new BusinessLogic();

            //Check if user is checkin in or checking out

            if (CheckInButton.IsChecked == true)
            {
                //CreateTimeentryInfo to check in:
                //User -> from config file (XML)??. Can't add the System.Configuration.dll reference in 5.0...
                //string sAttr = ConfigurationManager.AppSettings.Get("User");
                user = "DummyUser";

                //access the BLL and hand over the user and check-type data

                try
                {
                    bl.CreateTimeEntry(1, user, "");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                
                //CheckInButton.Content = "Check Out";
                StatusScreen.Text = "Checked In";
                //Start timewatch:
                TimeWatch.Text = "01:00:00";
                //Make pause options appear:
                BreakButton.Visibility = Visibility.Visible;
                BreakTimeWatch.Visibility = Visibility.Visible;

                //
            }
            else
            {
                //CreateTimeentryInfo to check in:
                //User -> from config file (XML)??. Can't add the System.Configuration.dll reference in 5.0...
                //string sAttr = ConfigurationManager.AppSettings.Get("User");
                user = "DummyUser";

                //access the BLL and hand over the user and check-type data
                
                // Open Textbox to enter comment
                
                try
                {
                    CheckInButton.IsEnabled = false;
                    CreateCommentWindow();

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }

                //CheckInButton.Content = "Check in";
                StatusScreen.Text = "About to Check Out";

                //Pause timewatch:
                TimeWatch.Text = "Freezed";

                //Make pause options disappear:
                BreakButton.IsEnabled = false;
                BreakTimeWatch.Visibility = Visibility.Hidden;


            }
        }

        private void BreakButtonCommentSave_OnClick(object sender, RoutedEventArgs e)
        {
            var user = "DummyUser";
            var comment = _commentTextBox.ToString();
            BusinessLogic bl = new BusinessLogic();
            bl.CreateTimeEntry(2, user, comment);
            CheckInButton.IsEnabled = true;
            CheckInButton.IsChecked = false;
            StatusScreen.Text = "Checked Out";
            TimeWatch.Text = "00:00:00";

            BreakButton.IsEnabled = true;
            BreakButton.Visibility = Visibility.Hidden;
            BreakTimeWatch.Visibility = Visibility.Hidden;
            BreakTimeWatchStackPanel.Children.Remove(_commentStackPanel);
            CommentWindow.Close();
        }

        private void BreakButtonCommentCancel_OnClick(object sender, RoutedEventArgs e)
        {
            CheckInButton.IsEnabled = true;
            CheckInButton.IsChecked = true;
            StatusScreen.Text = "Checked In";
            TimeWatch.Text = "01:00:00";

            BreakButton.IsEnabled = true;
            BreakTimeWatchStackPanel.Children.Remove(_commentStackPanel);
            CommentWindow.Close();

        }


        private void BreakButton_OnClick(object sender, RoutedEventArgs e) 
        {
            throw new NotImplementedException();
        }
    

        private void SendComment_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExitApp(object sender, ExitEventArgs e)
        {
            MessageBox.Show("TimeChecker wurde beendet.");
        }

        private void CreateCommentWindow()
        {
            CommentWindow.Title = "Timeentry Comment";
            CommentWindow.Height = 200;
            CommentWindow.Width = 400;

            _commentStackPanel.Background = Brushes.Black;
            //_commentStackPanel.Orientation = Orientation.Horizontal;


            _commentTextBlock.Height = 50;
            _commentTextBlock.Width = 200;
            _commentTextBlock.Foreground = Brushes.White;
            _commentTextBlock.TextWrapping = TextWrapping.Wrap;
            _commentTextBlock.Text = "You have the possibility to enter a comment in the textbox below before saving the data";

            _commentTextBox.Height = 50;
            _commentTextBox.Width = 200;
            _commentTextBox.TextWrapping = TextWrapping.Wrap;
            _commentTextBox.Text = "Enter your comment here or leave empty....";

            _commentSendButton.Height = 50;
            _commentSendButton.Width = 200;
            _commentSendButton.VerticalAlignment = VerticalAlignment.Bottom;
            _commentSendButton.Content = "Save and Check Out";
            _commentSendButton.Click += this.BreakButtonCommentSave_OnClick;


            _abboardButton.Height = 50;
            _abboardButton.Width = 200;
            _abboardButton.VerticalAlignment = VerticalAlignment.Bottom;
            _abboardButton.Content = "Cancel Checking Out";
            _abboardButton.Click += this.BreakButtonCommentCancel_OnClick;

            _commentStackPanel.Children.Add(_commentTextBlock);
            _commentStackPanel.Children.Add(_commentTextBox);
            _commentStackPanel.Children.Add(_commentSendButton);
            _commentStackPanel.Children.Add(_abboardButton);

            CommentWindow.Content = _commentStackPanel;
            CommentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CommentWindow.Show();
        }

    }

}
