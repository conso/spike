
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace FunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "mona")]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            return name != null
                ? (ActionResult)new OkObjectResult($"Ciao mona, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
