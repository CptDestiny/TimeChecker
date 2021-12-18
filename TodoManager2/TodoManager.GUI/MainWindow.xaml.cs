using System.Linq;
using System.Windows;
using TodoManager.DAL;

namespace TodoManager.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            GetTodoItems();
        }

        private void GetTodoItems()
        {
            var todoItems = _context.TodoItems.ToList();
            TodoItemGrid.ItemsSource = todoItems;
        }
    }
}
