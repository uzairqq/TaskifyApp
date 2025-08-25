using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskify.Domain.Entities
{
    internal class TodoItem
    {
        public TodoItem(string title, DateTime? dueDate = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title is required.", nameof(title));
            }
            Id = Guid.NewGuid();
            Title = title;
            DueDate = dueDate;
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime? DueDate { get; set; }


        public void Complete() => IsCompleted = true;
        public void Reschedule(DateTime newDueDate)
        {
            if (newDueDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Due date cannot be in the past.", nameof(newDueDate));
            }
            DueDate = newDueDate;
        }
    }
}