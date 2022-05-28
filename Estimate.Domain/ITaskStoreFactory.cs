namespace Estimate.Domain;

/// <summary>
/// Defines a factory that creates <see cref="ITaskStore"/> objects.
/// </summary>
public interface ITaskStoreFactory
{
    ITaskStore Create();
}
