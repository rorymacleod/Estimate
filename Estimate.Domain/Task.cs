namespace Estimate.Domain;

/// <summary>
/// Represents a unit of work to be estimated.
/// </summary>
public class Task
{
    public TaskId Id { get; init; }
    public string Title { get; }

    public Task(string title)
    {
        this.Id = TaskId.Empty;
        this.Title = title;
    }
}