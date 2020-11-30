using System.Linq;
using Lab3Selenium.Page;
using NUnit.Framework;

namespace Lab3Selenium.Tests
{
    public class ModifyTaskTest
    {
        [Test]
        public void Test()
        {
            using var page = new TodosPage();
            const string taskTitle = "task";
            const string modifiedTaskTitle = "modified";

            page.AddTask(taskTitle);
            page.ModifyTask(taskTitle, modifiedTaskTitle);

            var actual = page.GetTasks().First().Title;
            Assert.AreEqual(modifiedTaskTitle, actual);
        }
    }
}