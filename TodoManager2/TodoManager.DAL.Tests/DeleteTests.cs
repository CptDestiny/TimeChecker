using System.Linq;
using TodoManager.BL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TodoManager.DAL.Tests
{
    [TestFixture]
    public class DeleteTests
    {
        private AppDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoListManager;Trusted_Connection=True;MultipleActiveResultSets=true")
               .Options);

            // add todo item record
            var record = new TodoItem()
            {
                Type = 2,
                Description = "Organize meeting to discuss the project"
            };

            _context.TodoItems.Add(record);

            _context.SaveChanges();
        }

        [Test]
        public void DeleteTodoItem()
        {
            var existing = _context.TodoItems.Single(x => x.Type == 2);

            var todoItemId = existing.Id;
            _context.TodoItems.Remove(existing);
            _context.SaveChanges();

            var found = _context.TodoItems.SingleOrDefault(x => x.Type == 2);
            Assert.IsNull(found);
        }
    }
}
