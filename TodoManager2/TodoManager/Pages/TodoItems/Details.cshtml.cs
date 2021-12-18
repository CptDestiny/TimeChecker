using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodoManager.BL.Entities;
using TodoManager.DAL;

namespace TodoManager.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public TodoItem TodoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TodoItem = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id);

            if (TodoItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
