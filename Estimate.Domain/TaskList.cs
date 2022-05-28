namespace Estimate.Domain;

/// <summary>
/// Represents a collection of <see cref="Task"/> objects.
/// </summary>
public class TaskList
{
    private readonly ITaskStoreFactory Factory;

    public TaskList(ITaskStoreFactory factory)
    {
        this.Factory = factory;
    }

    public IEnumerable<Task> GetAll()
    {
        using var db = this.Factory.Create();
        return db.RetrieveAll();
    }

    public void Add(Task task)
    {
        using var db = this.Factory.Create();
        db.Create(task);
    }

    public void Remove(TaskId taskId)
    {
        using var db = this.Factory.Create();
        db.Delete(taskId);
    }
}
