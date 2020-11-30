using System.Linq;
using Lab3Selenium.Page;
using NUnit.Framework;

namespace Lab3Selenium.Tests
{
    public class AddTaskTest
    {
        [Test]
        public void Test()
        {
            using var page = new TodosPage();
            const string newTaskTitle = "testTask";

            page.AddTask(newTaskTitle);

            var tasks = page.GetTasks();
            var activeItemsCount = page.GetActiveTasksCount();
            Assert.AreEqual(newTaskTitle, tasks.First().Title);
            Assert.AreEqual(1, activeItemsCount);
        }
    }
}