using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoManager.BL.Entities;
using TodoManager.DAL;

namespace TodoManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<TodoItem> TodoItem { get;set; }

        public async Task OnGetAsync()
        {
            TodoItem = await _context.TodoItems.ToListAsync();
        }
    }
}
