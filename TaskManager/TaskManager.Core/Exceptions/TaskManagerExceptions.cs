using System;

namespace TaskManager.Core.Exceptions
{
    public class TaskManagerExceptions
    {
        
    }
    
    public class NotFoundException : Exception
    {
        public NotFoundException(string type, int id):base($"No {type} found, id is {id}.")
        {
            
        }
        public NotFoundException(string type, string name, string value):base($"No {type} found, {name} is {value}.")
        {
            
        }
        public NotFoundException(string message):base(message)
        {
            
        }
    }

    public class FailedExecutionException : Exception
    {
        public FailedExecutionException(string message):base(message)
        {
            
        }
    }
}