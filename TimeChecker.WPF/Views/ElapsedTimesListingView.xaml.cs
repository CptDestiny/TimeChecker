using System.Windows.Controls;

namespace TimeChecker.WPF.Views
{
    /// <summary>
    /// Interaction logic for ElapsedTimeItemList.xaml
    /// </summary>
    public partial class ElapsedTimeItemList : UserControl
    {
        public ElapsedTimeItemList()
        {
            InitializeComponent();
        }

       public void AddItemToTimeItemList(string item)
       {
           ElapsedBreakItemList.Items.Add(item);
       }

    }
}
