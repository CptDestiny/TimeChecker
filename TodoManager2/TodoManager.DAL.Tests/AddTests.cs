using TodoManager.BL.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace TodoManager.DAL.Tests
{
    [TestFixture]
    public class AddTests
    {
        private AppDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoListManager;Trusted_Connection=True;MultipleActiveResultSets=true")
               .Options);
        }

        [Test]
        public void InsertTodoItem()
        {
            var record = new TodoItem()
            {
                Type = 2,
                Comment = "Organize meeting to discuss the project"
            };

            _context.TodoItems.Add(record);

            _context.SaveChanges();

            var addedTodoItem = _context.TodoItems.Single(x => x.Type == 2);

            Assert.Greater(addedTodoItem.Id, 0);
            Assert.AreEqual(record.Type, addedTodoItem.Type);
            Assert.AreEqual(record.Comment, addedTodoItem.Comment);
            Assert.AreEqual(record.Completed, addedTodoItem.Completed);
        }

        [TearDown]
        public void TearDown()
        {
            var todoItem = _context.TodoItems.Single(x => x.Type == 2);
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();
        }
    }
}
