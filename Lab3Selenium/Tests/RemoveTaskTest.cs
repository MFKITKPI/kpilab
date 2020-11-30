using Lab3Selenium.Page;
using NUnit.Framework;

namespace Lab3Selenium.Tests
{
    public class RemoveTaskTest
    {
        [Test]
        public void Test()
        {
            using var page = new TodosPage();
            const string taskTitle = "testing task";

            page.AddTask("mock task");
            page.AddTask(taskTitle);
            var tasksCountOnPageBeforeAct = page.GetTasks().Count;

            page.RemoveTask(taskTitle);

            Assert.AreEqual(tasksCountOnPageBeforeAct - 1, page.GetActiveTasksCount());
        }
    }
}