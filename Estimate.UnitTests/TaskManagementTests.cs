using System;
using Xunit;
using Xunit.Abstractions;

namespace Estimate.UnitTests;

public class TaskManagementTests
{
    private readonly ITestOutputHelper Output;

    public TaskManagementTests(ITestOutputHelper output)
    {
        this.Output = output;
    }

    [Fact]
    public void Empty_task_list_is_empty()
    {
        using var steps = new TaskManagementSteps(this.Output);
        steps.GivenAnEmptyTaskList();
        steps.ThenTaskListCountIs(0);
    }

    [Fact]
    public void Adding_task_increments_count()
    {
        using var steps = new TaskManagementSteps(this.Output);
        steps.GivenAnEmptyTaskList();
        steps.WhenATaskIsAdded();
        steps.ThenTaskListCountIs(1);
    }

    [Fact]
    public void Removing_task_decrements_count()
    {
        using var steps = new TaskManagementSteps(this.Output);
        steps.GivenTask("a");
        steps.GivenTask("b");
        steps.WhenTaskIsRemoved("a");
        steps.ThenTaskListCountIs(1);
        steps.ThenTaskListContainsTask("b");
        steps.ThenTaskListDoesNotContainTask("a");
    }

    [Fact]
    public void Loads_tasks_from_data_store()
    {
        using var steps = new TaskManagementSteps(this.Output);
        steps.GivenTask("Alpha");
        steps.WhenANewSessionIsStarted();
        steps.ThenTaskListContainsTask("Alpha");
    }

}