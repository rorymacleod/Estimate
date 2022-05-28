namespace Estimate.Data.InMemory;

public class InMemoryTaskStoreFactory: ITaskStoreFactory
{
    private readonly InMemoryContext Context = new();

    public ITaskStore Create()
    {
        return new InMemoryTaskStore(this.Context);
    }
}