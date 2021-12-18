using System.Linq;
using TodoManager.BL.Entities;

using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TodoManager.DAL.Tests
{
    [TestFixture]
    public class UpdateTests
    {
        private AppDbContext _context;
        private int _todoItemId;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoListManager;Trusted_Connection=True;MultipleActiveResultSets=true")
               .Options);

            var record = new TodoItem()
            {
                Type = 2,
                Comment = "Organize meeting to discuss the project"

            };

            _context.TodoItems.Add(record);

            _context.SaveChanges();

            _todoItemId = record.Id;
        }

        [Test]
        public void UpdateTodoItem()
        {
            var todoItem = _context.TodoItems.Single(x => x.Id == _todoItemId);
            string title = "Organize meeting - updated";
            string description = "Organize meeting to discuss the goals of the project";
            todoItem.Type = 2;
            todoItem.Comment = description;

            _context.SaveChanges();

            var updatedTodoItem = _context.TodoItems.Single(x => x.Id == _todoItemId);
            Assert.AreEqual("Organize meeting - updated", updatedTodoItem.Type);
            Assert.AreEqual("Organize meeting to discuss the goals of the project", updatedTodoItem.Comment);
        }

        [TearDown]
        public void TearDown()
        {
            var todoItem = _context.TodoItems.Single(x => x.Id == _todoItemId);
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();
        }
    }
}
