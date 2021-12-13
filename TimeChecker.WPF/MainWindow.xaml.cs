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

        CommentBox CommentBox = new CommentBox();

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
            var comment = CommentBox._commentTextBox.ToString();
            BusinessLogic bl = new BusinessLogic();
            bl.CreateTimeEntry(2, user, comment);
            CheckInButton.IsEnabled = true;
            CheckInButton.IsChecked = false;
            StatusScreen.Text = "Checked Out";
            TimeWatch.Text = "00:00:00";

            BreakButton.IsEnabled = true;
            BreakButton.Visibility = Visibility.Hidden;
            BreakTimeWatch.Visibility = Visibility.Hidden;
            CommentBox.CommentWindow.Close();
            CommentBox.CommentWindow.Content = null;
        }

        private void BreakButtonCommentCancel_OnClick(object sender, RoutedEventArgs e)
        {
            CheckInButton.IsEnabled = true;
            CheckInButton.IsChecked = true;
            StatusScreen.Text = "Checked In";
            TimeWatch.Text = "01:00:00";

            BreakButton.IsEnabled = true;
            CommentBox.CommentWindow.Close();
            CommentBox.CommentWindow = null;

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
            //Define Window
            CommentBox = new CommentBox();

            CommentBox.CommentWindow.Title = "Timeentry Comment";
            CommentBox.CommentWindow.Height = 280;
            CommentBox.CommentWindow.Width = 335;

          
            //Define new Grid & Col / Row definitions
            var commentWindowGrid = new Grid();
            commentWindowGrid.Background = Brushes.Black;
            //commentWindowGrid.ShowGridLines = true;
            //Column definition
            ColumnDefinition commentWindowColDef1 = new ColumnDefinition();
            commentWindowColDef1.Width = new GridLength(1, GridUnitType.Auto);
            ColumnDefinition commentWindowColDef2 = new ColumnDefinition();
            commentWindowColDef2.Width = new GridLength(1, GridUnitType.Auto);
            RowDefinition commentWindowRowDef1 = new RowDefinition();
            commentWindowRowDef1.Height = new GridLength(1, GridUnitType.Auto);
            RowDefinition commentWindowRowDef2 = new RowDefinition();
            commentWindowRowDef2.Height = new GridLength(1, GridUnitType.Auto);
            commentWindowGrid.ColumnDefinitions.Add(commentWindowColDef1);
            commentWindowGrid.ColumnDefinitions.Add(commentWindowColDef2);
            commentWindowGrid.RowDefinitions.Add(commentWindowRowDef1);
            commentWindowGrid.RowDefinitions.Add(commentWindowRowDef2);


            //Define Stack Panel 1
            StackPanel _commentStackPanel1 = new StackPanel();
            _commentStackPanel1.HorizontalAlignment = HorizontalAlignment.Stretch;
            _commentStackPanel1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetColumn(_commentStackPanel1, 0);
            Grid.SetRow(_commentStackPanel1, 0);
            Grid.SetColumnSpan(_commentStackPanel1, 2);

            //Define Stack Panel 2
            StackPanel _commentStackPanel2 = new StackPanel();
            _commentStackPanel2.HorizontalAlignment = HorizontalAlignment.Left;
            _commentStackPanel2.VerticalAlignment = VerticalAlignment.Top;
            _commentStackPanel2.Orientation = Orientation.Vertical;
            Grid.SetColumn(_commentStackPanel2, 0);
            Grid.SetRow(_commentStackPanel2, 1);

            //Define Stack Panel 3
            StackPanel _commentStackPanel3 = new StackPanel();
            _commentStackPanel3.HorizontalAlignment = HorizontalAlignment.Right;
            _commentStackPanel3.VerticalAlignment = VerticalAlignment.Top;
            _commentStackPanel3.Orientation = Orientation.Vertical;
            Grid.SetColumn(_commentStackPanel3, 1);
            Grid.SetRow(_commentStackPanel3, 1);

            CommentBox._commentTextBlock.Height = 50;
            CommentBox._commentTextBlock.Width = 300;
            CommentBox._commentTextBlock.Margin = new Thickness(10,10,0,5);
            CommentBox._commentTextBlock.Foreground = Brushes.White;
            CommentBox._commentTextBlock.TextWrapping = TextWrapping.Wrap;
            CommentBox._commentTextBlock.Text = "You have the possibility to enter a comment in the textbox below before saving the data:";

            CommentBox._commentTextBox.Height = 100;
            CommentBox._commentTextBox.Width = 300;
            CommentBox._commentTextBox.Margin = new Thickness(10,0,0,5);
            CommentBox._commentTextBox.TextWrapping = TextWrapping.Wrap;
            CommentBox._commentTextBox.Text = "";

            CommentBox._commentSendButton.Height = 50;
            CommentBox._commentSendButton.Width = 140;
            CommentBox._commentSendButton.Margin = new Thickness(10,5,0,0);
            CommentBox._commentSendButton.Content = "Save and Check Out";
            CommentBox._commentSendButton.Click += this.BreakButtonCommentSave_OnClick;


            CommentBox._abboardButton.Height = 50;
            CommentBox._abboardButton.Width = 140;
            CommentBox._abboardButton.Margin = new Thickness(0,5,0,0);
            CommentBox._abboardButton.Content = "Cancel Checking Out";
            CommentBox._abboardButton.Click += this.BreakButtonCommentCancel_OnClick;

            _commentStackPanel1.Children.Add(CommentBox._commentTextBlock);
            _commentStackPanel1.Children.Add(CommentBox._commentTextBox);
            _commentStackPanel2.Children.Add(CommentBox._commentSendButton);
            _commentStackPanel3.Children.Add(CommentBox._abboardButton);

            // Add child content to the parent Grid.
            commentWindowGrid.Children.Add(_commentStackPanel1);
            commentWindowGrid.Children.Add(_commentStackPanel2);
            commentWindowGrid.Children.Add(_commentStackPanel3);

            //Add Grid to the Window and show
            CommentBox.CommentWindow.Content = commentWindowGrid;
            CommentBox.CommentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CommentBox.CommentWindow.Show();
        }

    }

}
