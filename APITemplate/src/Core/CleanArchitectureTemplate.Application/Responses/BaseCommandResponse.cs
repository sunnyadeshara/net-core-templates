using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.Responses
{
    public class BaseCommandResponse
    {
        public int Id { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
