namespace Estimate.Domain;

/// <summary>
/// Uniquely identifies a <see cref="Task"/>.
/// </summary>
public abstract record TaskId
{
    private record EmptyTaskId : TaskId;

    public static readonly TaskId Empty = new EmptyTaskId();

    public static implicit operator string(TaskId id) => id.ToString();
}