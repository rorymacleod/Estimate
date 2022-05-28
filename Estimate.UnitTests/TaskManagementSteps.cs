using System;
using System.Collections.Generic;
using System.Linq;
using Estimate.Domain;
using FluentAssertions;

namespace Estimate.UnitTests;

public class TaskManagementSteps : IDisposable
{
    private readonly InMemoryDriver Driver = new();

    public void Dispose()
    {
    }

    public void GivenAnEmptyTaskList()
    {
    }

    public void ThenTaskListCountIs(int expected)
    {
        var taskList = this.Driver.GetTaskList();
        taskList.Count.Should().Be(expected);
    }

    public void WhenATaskIsAdded()
    {
        this.Driver.AddTask(new Task(string.Empty));
    }

    public void GivenTask(string title)
    {
        this.Driver.AddTask(new Task(title));
    }

    public void WhenTaskIsRemoved(string id)
    {
        this.Driver.RemoveTaskByTitle(id);
    }

    public void ThenTaskListContainsTask(string id)
    {
        var task = this.Driver.FindTask(id);
        task.Should().NotBeNull();
    }

    public void ThenTaskListDoesNotContainTask(string id)
    {
        var task = this.Driver.FindTask(id);
        task.Should().BeNull();
    }

    public void WhenANewSessionIsStarted()
    {
        this.Driver.Restart();
    }
}
