using System.Linq;
using Lab3Selenium.Page;
using NUnit.Framework;

namespace Lab3Selenium.Tests
{
    public class CompleteAllCompletedTasksTest
    {
        [Test]
        public void Test()
        {
            using var page = new TodosPage();

            string[] taskTitles = { "task1", "task2", "task3" };

            foreach (var task in taskTitles)
            {
                page.AddTask(task);
                page.CompleteTask(task);
            }

            page.CompleteAll();

            var shownTasks = page.GetTasks();

            Assert.True(shownTasks.All(task => !task.Completed));
            Assert.AreEqual(taskTitles, shownTasks.Select(task => task.Title).ToArray());
        }
    }
}