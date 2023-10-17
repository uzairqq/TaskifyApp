namespace Taskify_API.Dto
{
    public class ResponseMessageDto
    {
        public int Id { get; set; }
        public string SuccessMessage { get; set; }
        public bool IsSuccess { get; set; }
        public string FailureMessage { get; set; }
        public bool IsFailed { get; set; }
    }
}
