using System;
using Xunit;

namespace Estimate.UnitTests;

public class TaskManagement
{
    [Fact]
    public void Empty_task_list_is_empty()
    {
        using var steps = new TaskManagementSteps();
        steps.GivenAnEmptyTaskList();
        steps.ThenTaskListCountIs(0);
    }

    [Fact]
    public void Adding_task_increments_count()
    {
        using var steps = new TaskManagementSteps();
        steps.GivenAnEmptyTaskList();
        steps.WhenATaskIsAdded();
        steps.ThenTaskListCountIs(1);
    }

    [Fact]
    public void Removing_task_decrements_count()
    {
        using var steps = new TaskManagementSteps();
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
        using var steps = new TaskManagementSteps();
        steps.GivenTask("Alpha");
        steps.WhenANewSessionIsStarted();
        steps.ThenTaskListContainsTask("Alpha");
    }

}