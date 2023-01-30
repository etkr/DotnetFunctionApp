using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Company.Function;

internal readonly record struct RequestBody(string Name);

public static class NameTrigger
{
    [FunctionName("NameTrigger")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log
    )
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        var name = req.Query["name"];
    // var data = await JsonSerializer.DeserializeAsync<RequestBody>(req.Body);
        var responseMessage = string.IsNullOrEmpty(name)
            ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            : $"Hello, {name}. This HTTP triggered function executed successfully.";
        return new OkObjectResult(responseMessage);
    }
}

