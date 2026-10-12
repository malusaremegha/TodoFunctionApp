
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TodoFunctionApp;

public class TodoHttpFunction
{
    private readonly ILogger<TodoHttpFunction> _logger;

    public TodoHttpFunction(ILogger<TodoHttpFunction> logger)
    {
        _logger = logger;
    }

    [Function("TodoHttpFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]
        HttpRequestData req)
    {
        _logger.LogInformation("Todo HTTP function was called.");

        var response = req.CreateResponse(HttpStatusCode.OK);

        await response.WriteAsJsonAsync(new
        {
            message = "Azure Function is working!",
            application = "TodoFunctionApp",
            status = "Success"
        });

        return response;
    }
}
