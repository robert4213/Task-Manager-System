using System;

namespace TaskManager.Core.Model.Response
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserFullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public char Priority { get; set; }
        public string Remarks { get; set; }
    }
}