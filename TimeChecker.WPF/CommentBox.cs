using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TimeChecker.WPF
{
    public partial class CommentBox
    {

        internal Window commentWindow;
        internal TextBlock commentTextBlock;
        internal TextBox commentTextBox;
        internal Button commentSendButton;
        internal Button abboardButton;


        
        public CommentBox()
        {
            commentTextBlock = new TextBlock();
            commentTextBox = new TextBox();
            commentSendButton = new Button();
            abboardButton = new Button();
            commentWindow = new Window();
            
        }

        private void CreateWindow()
        {
            //Define Window
            
            commentWindow.Title = "Timeentry Comment";
            commentWindow.Height = 280;
            commentWindow.Width = 335;
            
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

            commentTextBlock.Height = 50;
            commentTextBlock.Width = 300;
            commentTextBlock.Margin = new Thickness(10, 10, 0, 5);
            commentTextBlock.Foreground = Brushes.White;
            commentTextBlock.TextWrapping = TextWrapping.Wrap;
            commentTextBlock.Text = "You have the possibility to enter a comment in the textbox below before saving the data:";

            commentTextBox.Height = 100;
            commentTextBox.Width = 300;
            commentTextBox.Margin = new Thickness(10, 0, 0, 5);
            commentTextBox.TextWrapping = TextWrapping.Wrap;
            commentTextBox.Text = "";

            commentSendButton.Height = 50;
            commentSendButton.Width = 140;
            commentSendButton.Margin = new Thickness(10, 5, 0, 0);
            commentSendButton.Content = "Save and Check Out";
            commentSendButton.Click += this.CommentSaveButton_OnClick;


            abboardButton.Height = 50;
            abboardButton.Width = 140;
            abboardButton.Margin = new Thickness(0, 5, 0, 0);
            abboardButton.Content = "Cancel Checking Out";
            abboardButton.Click += this.CommentCancelButton_OnClick;

            _commentStackPanel1.Children.Add(commentTextBlock);
            _commentStackPanel1.Children.Add(commentTextBox);
            _commentStackPanel2.Children.Add(commentSendButton);
            _commentStackPanel3.Children.Add(abboardButton);

            // Add child content to the parent Grid.
            commentWindowGrid.Children.Add(_commentStackPanel1);
            commentWindowGrid.Children.Add(_commentStackPanel2);
            commentWindowGrid.Children.Add(_commentStackPanel3);

            //Add Grid to the Window and show
            commentWindow.Content = commentWindowGrid;
            commentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            commentWindow.Show();
        }
    }
}
