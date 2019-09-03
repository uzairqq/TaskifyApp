using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Dtos
{
    public class ResponseMessageDto
    {
        public int Id { get; set; }
        public string SuccessMessage { get; set; }
        public bool Success { get; set; }
        public string FailureMessage { get; set; }
        public bool Failure { get; set; }
    }
}
