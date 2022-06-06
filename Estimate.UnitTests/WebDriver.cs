using System;
using System.Collections.Generic;
using System.Linq;
using Estimate.Domain;

namespace Estimate.UnitTests
{
    public class WebDriver: IDriver
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Task> GetTaskList()
        {
            throw new NotImplementedException();
        }

        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTaskByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task? FindTask(string title)
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }
    }
}
