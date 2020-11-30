using System.Linq;
using Lab3Selenium.Page;
using NUnit.Framework;

namespace Lab3Selenium.Tests
{
    public class CompleteTaskTest
    {
        [Test]
        public void Test()
        {
            using var page = new TodosPage();
            const string taskTitle = "testing task";

            page.AddTask("mock task");
            page.AddTask(taskTitle);
            var tasksCountOnPageBeforeAct = page.GetTasks().Count;

            page.CompleteTask(taskTitle);

            var completedTask = page.GetTasks().First(todoTask => todoTask.Completed);

            Assert.AreEqual(taskTitle, completedTask.Title);
            Assert.AreEqual(tasksCountOnPageBeforeAct - 1, page.GetActiveTasksCount());
        }
    }
}