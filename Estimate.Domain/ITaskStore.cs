namespace Estimate.Domain;

/// <summary>
/// Defines a data store containing <see cref="Task"/> entities.
/// </summary>
public interface ITaskStore : IDisposable
{
    IEnumerable<Task> RetrieveAll();
    void Create(Task task);
    void Delete(TaskId taskId);
}
