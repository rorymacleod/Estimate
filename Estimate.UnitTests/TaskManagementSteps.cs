using System;
using Estimate.Domain;
using FluentAssertions;
using Xunit.Abstractions;

namespace Estimate.UnitTests;

public class TaskManagementSteps: StepsBase
{
    private readonly InMemoryDriver Driver = new();

    public TaskManagementSteps(ITestOutputHelper output) : base(output)
    {
    }

    public void GivenAnEmptyTaskList()
    {
        this.Driver.GetTaskList();
        this.Given("an empty task list");
    }

    public void GivenTask(string title)
    {
        this.Given($"a task \"{title}\"");
        this.Driver.AddTask(new Task(title));
    }

    public void WhenATaskIsAdded()
    {
        this.When("a task is added");
        this.Driver.AddTask(new Task(string.Empty));
    }

    public void WhenTaskIsRemoved(string title)
    {
        this.When($"the \"{title}\" task is removed");
        this.Driver.RemoveTaskByTitle(title);
    }

    public void WhenANewSessionIsStarted()
    {
        this.When("a new session is started");
        this.Driver.Restart();
    }

    public void ThenTaskListCountIs(int expected)
    {
        this.Then($"the task list count is {expected}");

        var taskList = this.Driver.GetTaskList();
        taskList.Count.Should().Be(expected);
    }

    public void ThenTaskListContainsTask(string title)
    {
        this.Then($"the list contains \"{title}\"");

        var task = this.Driver.FindTask(title);
        task.Should().NotBeNull();
    }

    public void ThenTaskListDoesNotContainTask(string title)
    {
        this.Then($"the list does not contain \"{title}\"");

        var task = this.Driver.FindTask(title);
        task.Should().BeNull();
    }
}
