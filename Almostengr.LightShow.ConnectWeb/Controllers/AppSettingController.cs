using Microsoft.AspNetCore.Mvc;
using Almostengr.Common.Common.Shared;
using Almostengr.LightShow.ConnectServices.AppSettingsManager;
using Almostengr.Common.Common.DomainServices.Interfaces;
using Almostengr.LightShow.ConnectWeb.Models;

namespace Almostengr.LightShow.ConnectWeb.Controllers;

public class AppSettingController : UiController
{
    private readonly IUpdateService<AppSettingsResource> _updateService;
    private readonly IQueryAppSettingsService _queryService;

    public AppSettingController(
        IQueryAppSettingsService queryService,
        IUpdateService<AppSettingsResource> updateService
    )
    {
        _updateService = updateService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = _queryService.Get();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit()
    {
        AppSettingsResource resource = _queryService.Get();

        AppSettingsViewModel model = new(resource);
        return PartialView("_Edit", model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AppSettingsViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_Edit", model);
        }

        AppSettingsResource resource = _queryService.Get();
        model.AssignToResource(resource);

        var result = await _updateService.ExecuteAsync(resource);
        if (result.Succeeded)
        {
            return NoContent();
        }

        AddErrorsToModelState(result.Errors);
        return PartialView("_Edit", model);
    }
}
