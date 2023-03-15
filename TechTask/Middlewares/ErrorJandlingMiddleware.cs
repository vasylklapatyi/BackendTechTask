using Application.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Persistence.DAL;
using Formatting = Newtonsoft.Json.Formatting;

namespace TechTask.Web.Host.Middlewares;

public class ErrorHandlingMiddleWare
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception exception)
    {
        SecureException? secureException = exception as SecureException;
        long? id = null;
        if(secureException != null)
        {
            using StreamReader reader = new StreamReader(context.Request.Body);
            string body = reader.ReadToEnd();

            var dbContext = new TechTaskDbContext();

            id = dbContext.Logs.Add(new()
            {
                CreatedAt = DateTime.UtcNow,
                Message = secureException.Message,
                Type = nameof(secureException),
                StackTrace = secureException.StackTrace,
                Route = context.Request.Path,
                Headers = JsonConvert.SerializeObject(context.Request.Headers),
                Body = body
            }).Entity.Id;
            dbContext.SaveChanges();
        }

        var responseObject = new
        {
            Id = id,
            Data = new 
            {
                exception.Message,
            },
            Type = nameof(exception)
        };

        var result = JsonConvert.SerializeObject(responseObject, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;
        return context.Response.WriteAsync(result);
    }
}
