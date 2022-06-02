using System;
using Xunit.Abstractions;

namespace Estimate.UnitTests;

public abstract class StepsBase : IDisposable
{
    private readonly ITestOutputHelper Output;
    private bool HasGiven;
    private bool HasWhen;
    private bool HasThen;

    protected StepsBase(ITestOutputHelper output)
    {
        this.Output = output;
    }

    protected void Given(string message)
    {
        this.Output.WriteLine((this.HasGiven ? "  and given " : "Given ") + message);
        this.HasGiven = true;
    }

    protected void When(string message)
    {
        this.Output.WriteLine((this.HasWhen ? "  and when " : "When ") + message);
        this.HasWhen = true;
    }

    protected void Then(string message)
    {
        this.Output.WriteLine((this.HasThen ? "  and then " : "Then ") + message);
        this.HasThen = true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
}
