using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public static class DataProcessingFunction
{
    [FunctionName("DataProcessingFunction")]
    public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");
        string requestBody =
        await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        // angenommen, wir erhalten ein JSON-Objekt mit einem "amount"-Feld
        if (data?.amount != null)
        {
            double amount = data.amount;
            double processedAmount = CalculateTax(amount);
            var result = new
            {
                originalAmount = amount,
                processedAmount = processedAmount,
                message = $"Processed amount with tax: {processedAmount}"
            };

            return new OkObjectResult(JsonConvert.SerializeObject(result));
        }
        else
        {
            return new BadRequestObjectResult("Please pass an amount in the request body");
        }
    }
    private static double CalculateTax(double amount)
    {
        // einfache Steuerberechnung (z. B. 19% MwSt)
        return amount * 1.19;
    }
}