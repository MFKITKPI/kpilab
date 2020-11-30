using System.Linq;
using Lab3Selenium.Page;
using NUnit.Framework;

namespace Lab3Selenium.Tests
{
    public class CompletedTabTest
    {
        [Test]
        public void Test()
        {
            using var page = new TodosPage();

            string[] completedTaskTitles = { "completed1", "completed2" };
            string[] nonCompletedTaskTitles = { "active1", "active2", "active3" };

            foreach (var task in completedTaskTitles.Union(nonCompletedTaskTitles))
            {
                page.AddTask(task);
            }

            foreach (var taskToComplete in completedTaskTitles)
            {
                page.CompleteTask(taskToComplete);
            }

            page.SelectTab(TodosTab.Completed);

            var shownTasks = page.GetTasks();

            Assert.True(shownTasks.All(task => task.Completed));
            Assert.AreEqual(completedTaskTitles, shownTasks.Select(task => task.Title).ToArray());
        }
    }
}