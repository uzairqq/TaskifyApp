using System;

namespace Todo_App.Models
{
    public class Todo
    {
        public Todo()
        {

        }

        public int Id { get; set; }
        public string TodoName { get; set; }
        public string TodoDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ProrityLevel { get; set; }
        public DateTime ExpireOn { get; set; }
    }
}
