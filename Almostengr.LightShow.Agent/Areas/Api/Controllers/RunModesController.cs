using Almostengr.Common.Common.Shared;
using Almostengr.LightShow.Agent.Services.RunModeManager;
using Microsoft.AspNetCore.Mvc;

namespace Almostengr.LightShow.Agent.Areas.Api.Controllers;

[Route("api/runmodes")]
public class RunModesController : ApiController
{
    private readonly IUpdateRunModeService _updateService;

    public RunModesController(
        IUpdateRunModeService updateService
    )
    {
        _updateService = updateService;
    }

    [HttpPost("offline")]
    public async Task<IActionResult> Offline()
    {
        RunModeResource resource = new() { ModeOption = Common.DisplayModeOption.Offline };
        var result = _updateService.Execute(resource);
        return result.Succeeded ? Ok(result) : BadRequest(result);
    }

    [HttpPost("disable")]
    public async Task<IActionResult> Disable()
    {
        RunModeResource resource = new() { ModeOption = Common.DisplayModeOption.OnlineRejectingRequests };
        var result = _updateService.Execute(resource);
        return result.Succeeded ? Ok(result) : BadRequest(result);
    }

    [HttpPost("enable")]
    public async Task<IActionResult> Enable()
    {
        RunModeResource resource = new() { ModeOption = Common.DisplayModeOption.OnlineAcceptingRequests };
        var result = _updateService.Execute(resource);
        return result.Succeeded ? Ok(result) : BadRequest(result);
    }
}