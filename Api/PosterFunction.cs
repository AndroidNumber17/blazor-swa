using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api;

public class PosterFunction
{
    private readonly IActions actions;
    
    public PosterFunction(IActions actions)
    {
        this.actions = actions;
    }
    
    [Function("PosterFunction")]
    public async Task Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("PosterFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var posters = await actions.GetPostersAsync();
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(posters);
        
        var createPoster = actions.CreatePosterAsync(new Poster());
        var deletePoster = actions.DeletePosterAsync("id");
        var updatePoster = actions.UpdatePosterAsync(new Poster());
    }
}