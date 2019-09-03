using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Dtos
{
    public class TodoDto:BaseEntity
    {
        public string Name { get; set; }
    }
}
