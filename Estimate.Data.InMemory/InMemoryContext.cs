namespace Estimate.Data.InMemory;

internal class InMemoryContext
{
    private int MaxTaskId = 0;

    public List<Task> Tasks { get; set; } = new();

    public TaskId NextTaskId() => new Int32TaskId(++this.MaxTaskId);
}
