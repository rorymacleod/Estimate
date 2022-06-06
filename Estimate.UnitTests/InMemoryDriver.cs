using System;
using System.Collections.Generic;
using System.Linq;
using Estimate.Data.InMemory;
using Estimate.Domain;

namespace Estimate.UnitTests;

public class InMemoryDriver : IDriver
{
    private readonly InMemoryTaskStoreFactory Factory = new();
    private TaskList Tasks;

    public InMemoryDriver()
    {
        this.Tasks = new TaskList(this.Factory);
    }

    public ICollection<Task> GetTaskList()
    {
        return this.Tasks.GetAll().ToList();
    }

    public void AddTask(Task task)
    {
        this.Tasks.Add(task);
    }

    public void RemoveTaskByTitle(string title)
    {
        Task? task = this.FindTask(title);
        if (task != null)
        {
            this.Tasks.Remove(task.Id);
        }
    }

    public Task? FindTask(string title)
    {
        var task = this.Tasks.GetAll().FirstOrDefault(t => t.Title == title);
        return task;
    }

    public void Restart()
    {
        this.Tasks = new TaskList(this.Factory);
    }
}
