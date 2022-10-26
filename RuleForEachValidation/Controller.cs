using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace RuleForEachValidation;

[ApiController]
[Route("/test")]
public class Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Test(QueryDto parameters)
    {
        return Ok();
    }
}

public class QueryDto
{
    public long[]? NotRequiredArrayOfRequiredValueElements { get; set; }
    public ReferenceType[]? NotRequiredArrayOfRequiredElements { get; set; }
}

public class ReferenceType
{
}

public class QueryValidator : AbstractValidator<QueryDto>
{
    public QueryValidator()
    {
        RuleForEach(x => x.NotRequiredArrayOfRequiredValueElements)
            .NotEmpty();
        RuleForEach(x => x.NotRequiredArrayOfRequiredElements)
            .NotNull();
    }
}