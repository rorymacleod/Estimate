using System;
using System.Collections.Generic;
using Estimate.Domain;

namespace Estimate.UnitTests
{
    public interface IDriver : IDisposable
    {
        ICollection<Task> GetTaskList();
        void AddTask(Task task);
        void RemoveTaskByTitle(string title);
        Task? FindTask(string title);
        void Restart();
    }
}
