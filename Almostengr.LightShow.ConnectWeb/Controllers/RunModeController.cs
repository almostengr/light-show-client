using Microsoft.AspNetCore.Mvc;
using Almostengr.Common.Common.Shared;
using Almostengr.LightShow.ConnectWeb.Models;
using Almostengr.LightShow.ConnectServices.RunModeManager;

namespace Almostengr.LightShow.ConnectWeb.Controllers;

public class RunModeController : UiController
{
    private readonly IQueryRunModeService _queryService;
    private readonly IUpdateRunModeService _updateService;

    public RunModeController(
        IQueryRunModeService queryService,
        IUpdateRunModeService updateService
    )
    {
        _queryService = queryService;
        _updateService = updateService;
    }

    [HttpGet]
    public IActionResult Edit()
    {
        var resource = _queryService.Get();

        RunModeViewModel model = new(resource);
        return PartialView("_Edit", model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RunModeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_Edit", model);
        }

        var resource = _queryService.Get();

        model.AssignToResource(resource);

        var result = _updateService.Execute(resource);
        if (result.Succeeded)
        {
            return NoContent();
        }

        AddErrorsToModelState(result.Errors);
        return PartialView("_Edit", model);
    }
}