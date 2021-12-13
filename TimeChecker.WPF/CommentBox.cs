using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TimeChecker.WPF
{
    public partial class CommentBox
    {

        public Window CommentWindow;
        public TextBlock _commentTextBlock;
        public TextBox _commentTextBox;
        public Button _commentSendButton;
        public Button _abboardButton;


        
        public CommentBox()
        {
            _commentTextBlock = new TextBlock();
            _commentTextBox = new TextBox();
            _commentSendButton = new Button();
            _abboardButton = new Button();
            CommentWindow = new Window();
        }




    }
}
