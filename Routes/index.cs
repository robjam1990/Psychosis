using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

public class ExampleRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class ExampleRequestValidator : AbstractValidator<ExampleRequest>
{
    public ExampleRequestValidator()
    {
        RuleFor(x => x.Username).EmailAddress();
        RuleFor(x => x.Password).MinimumLength(5);
    }
}

public class ExampleController : ControllerBase
{
    private readonly ExampleRequestValidator _validator;

    public ExampleController(ExampleRequestValidator validator)
    {
        _validator = validator;
    }

    [HttpPost("/example")]
    public IActionResult Example(ExampleRequest request)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(new { errors });
        }

        // Process valid input
        return Ok("Valid input");
    }
}
