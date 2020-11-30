﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab3Selenium.Page
{
    internal class TodosPage : IDisposable
    {
        private const int DefaultWaitTimeoutSeconds = 1;

        private readonly IWebDriver _driver;

        public TodosPage()
        {
            var firefoxOptions = new FirefoxOptions
            {
                BrowserExecutableLocation = (@"C:\Program Files\Mozilla Firefox\firefox.exe")
            };
            _driver = new FirefoxDriver(firefoxOptions);
            _driver.Navigate().GoToUrl(@"http://todomvc.com/examples/angularjs/#/");
        }

        public IReadOnlyCollection<TodoTask> GetTasks()
            => GetTaskElements().Select(GetTaskFromElement).ToList();

        public int GetActiveTasksCount()
        {
            IWebElement activeTaskCountElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWaitTimeoutSeconds))
                .Until(drv => drv.FindElement(By.ClassName("todo-count")).FindElement(By.TagName("strong")));

            return int.Parse(activeTaskCountElement.Text);
        }

        public TodosTab GetSelectedTab()
        {
            IWebElement selectedTabElement = GetSelectedTabElement();

            return Enum.Parse<TodosTab>(selectedTabElement.Text);
        }

        public void SelectTab(TodosTab tab)
        {
            IReadOnlyCollection<IWebElement> tabLinkElements = new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(drv => drv.FindElement(By.ClassName("filters")))
                .FindElements(By.TagName("a"));

            IWebElement tabLink = tabLinkElements.First(linkElement => linkElement.Text == tab.ToString());
            tabLink.Click();
        }

        public void AddTask(string taskTitle)
        {
            IWebElement newTaskInput = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWaitTimeoutSeconds))
                .Until(drv => drv.FindElement(By.ClassName("new-todo")));

            newTaskInput.SendKeys(taskTitle);
            newTaskInput.SendKeys(Keys.Enter);
        }

        public void ModifyTask(string currentTaskTitle, string newTitle)
        {
            IWebElement taskElement = GetTaskElement(currentTaskTitle);

            Actions actions = new Actions(_driver);
            actions.DoubleClick(taskElement).Perform();

            IWebElement editInput = GetCurrentEditInput();

            editInput.SendKeys(Keys.Control + "a");
            editInput.SendKeys(Keys.Delete);

            editInput.SendKeys(newTitle);
            editInput.SendKeys(Keys.Enter);
        }

        public void RemoveTask(string taskTitle)
        {
            Actions actions = new Actions(_driver);
            IWebElement taskElement = GetTaskElement(taskTitle);

            actions.MoveToElement(taskElement).Perform();

            IWebElement destroySubElement = taskElement.FindElement(By.ClassName("destroy"));
            actions.MoveToElement(destroySubElement);
            actions.Click().Perform();
        }

        public void CompleteTask(string taskTitle)
        {
            IWebElement taskElement = GetTaskElement(taskTitle);
            IWebElement completeToggle = taskElement.FindElement(By.ClassName("toggle"));
            completeToggle.Click();
        }

        public void CompleteAll()
        {
            IReadOnlyCollection<IWebElement> labelElements = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWaitTimeoutSeconds))
                .Until(drv => drv.FindElements(By.TagName("label")));

            IWebElement labelForCompleteAllToggleElement = labelElements.First(labelElement => labelElement.GetAttribute("for") == "toggle-all");

            labelForCompleteAllToggleElement.Click();
        }

        public void ClearCompleted()
        {
            IWebElement clearCompletedButtonElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(DefaultWaitTimeoutSeconds))
                .Until(drv => drv.FindElement(By.ClassName("clear-completed")));

            clearCompletedButtonElement.Click();
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }

        private static TodoTask GetTaskFromElement(IWebElement taskElement)
            => new TodoTask(GetTaskElementText(taskElement), GetCompleteState(taskElement));

        private static string GetTaskElementText(IWebElement taskElement)
            => taskElement.FindElement(By.TagName("label")).Text;

        private static bool GetCompleteState(IWebElement taskElement)
            => taskElement.GetAttribute("class").Split(' ').Contains("completed");

        private IReadOnlyCollection<IWebElement> GetTaskElements()
        {
            IWebElement taskList = new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(drv => drv.FindElement(By.ClassName("todo-list")));

            return taskList.FindElements(By.TagName("li"));
        }

        private IWebElement GetTaskElement(string taskTitle)
            => GetTaskElements().First(taskElement => GetTaskElementText(taskElement) == taskTitle);

        private IWebElement GetCurrentEditInput()
            => new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(drv => drv.FindElement(By.ClassName("edit")));

        private IWebElement GetSelectedTabElement()
            => new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(drv => drv.FindElement(By.ClassName("filters")))
                .FindElement(By.ClassName("selected"));
    }
}