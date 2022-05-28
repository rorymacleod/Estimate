namespace Estimate.Data.InMemory;

internal class InMemoryTaskStore: ITaskStore
{
    static Task Clone(Task task, TaskId id)
    {
        return new Task(task.Title) { Id = id };
    }

    private readonly InMemoryContext Context;

    internal InMemoryTaskStore(InMemoryContext context)
    {
        this.Context = context;
    }

    public void Dispose()
    {
    }

    public IEnumerable<Task> RetrieveAll()
    {
        return this.Context.Tasks.Select(t => Clone(t, t.Id));
    }

    public void Create(Task task)
    {
        this.Context.Tasks.Add(Clone(task, this.Context.NextTaskId()));
    }

    public void Delete(TaskId taskId)
    {
        var idx = this.Context.Tasks.FindIndex(t => t.Id == taskId);
        if (idx >= 0)
        {
            this.Context.Tasks.RemoveAt(idx);
        }
    }
}