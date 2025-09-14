using Microsoft.AspNetCore.Mvc;
using SchoolManager.Models;
using SchoolManager.Services;

namespace SchoolManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController(IStateProvider stateProvider, ILogger<SchoolController> logger) : ControllerBase
{
    [HttpGet]
    public ActionResult<State> GetState()
    {
        logger.LogInformation("Fetching state");
        return Ok(stateProvider.GetState());
    }

    [HttpPatch]
    public ActionResult<State> PatchState([FromBody]Request request)
    {
        logger.LogInformation("Patching state with {@Request}", request);
        State updatedState;
        try
        {
            updatedState = PupilClassManager.UpdatePupilClassDivision(stateProvider.GetState(), request);
            return Ok(updatedState);
        }
        catch (Exception)
        {
            logger.LogError("Failed to patch state with {@Request}", request);
            throw;
        }
    }
}
