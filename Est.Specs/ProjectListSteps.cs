using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Est.Specs
{
    [Binding]
    public class ProjectListSteps: IDisposable
    {
        private readonly IWebDriver Web = new ChromeDriver("..\\..\\..\\..\\tools\\chromedriver-76");

        [Given]
        public void Given_I_am_a_new_user()
        {
        }

        [When]
        public void When_I_view_the_project_list()
        {
            Web.Navigate().GoToUrl("http://localhost:53873/");
            this.Web.Title.Should().Contain("Estimate").And.Contain("Projects");
        }

        [Then]
        public void Then_the_page_contains_P0_projects(int count)
        {
            var list = this.Web.FindElement(By.ClassName("project-list"));
            list.Should().NotBeNull();

            var projects = list.FindElements(By.ClassName("project-list-item"));
            projects.Count.Should().Be(count);
        }

        public void Dispose()
        {
            Web?.Dispose();
        }
    }
}
