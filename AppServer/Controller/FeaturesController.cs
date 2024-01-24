using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewComponents;

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using TypeInfo = System.Reflection.TypeInfo;

namespace AppServer.Controllers;

[ApiController]
[Route("api")]
public class FeaturesController : Controller
{
    private readonly ApplicationPartManager _partManager;

    public FeaturesController(ApplicationPartManager partManager)
    {
        _partManager = partManager;
    }

    [HttpGet]
    [Route("")]
    public IActionResult IndexHello() {
        return Ok("Hello World");
    }
    [HttpGet]
    [Route("Features")]
    public IActionResult Index()
    {
        var viewModel = new FeaturesViewModel();

        var controllerFeature = new ControllerFeature();
        _partManager.PopulateFeature(controllerFeature);
        viewModel.Controllers = controllerFeature.Controllers.ToList();

        var tagHelperFeature = new TagHelperFeature();
        _partManager.PopulateFeature(tagHelperFeature);
        viewModel.TagHelpers = tagHelperFeature.TagHelpers.ToList();

        var viewComponentFeature = new ViewComponentFeature();
        _partManager.PopulateFeature(viewComponentFeature);
        viewModel.ViewComponents = viewComponentFeature.ViewComponents.ToList();

        return View(viewModel);
    }
}

public class FeaturesViewModel
{
    public List<TypeInfo> Controllers { get; set; } = new();

    public List<TypeInfo> TagHelpers { get; set; } = new();  

    public List<TypeInfo> ViewComponents { get; set; } = new();
}
