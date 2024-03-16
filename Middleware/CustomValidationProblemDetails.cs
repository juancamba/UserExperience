using Microsoft.AspNetCore.Mvc;

namespace UserExperience.Middleware
{
    public class CustomValidationProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
