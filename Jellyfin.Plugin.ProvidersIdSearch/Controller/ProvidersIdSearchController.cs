
using System.Net.Mime;
using MediaBrowser.Controller.Dto;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using static MediaBrowser.Model.Entities.MetadataProvider;

namespace Jellyfin.Plugin.ProvidersIdSearch.Controller;

[ApiController]
[Authorize]
[Route("/ProvidersIdSearch")]
[Produces(MediaTypeNames.Application.Json)]
public class ProvidersIdSearchController : ControllerBase
{

    private readonly ILibraryManager libraryManager;
    private readonly IDtoService dtoService;

    public ProvidersIdSearchController(ILibraryManager libraryManager, IDtoService dtoService)
    {
        this.libraryManager = libraryManager;
        this.dtoService = dtoService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<BaseItemDto>> FindItemsByProvidersId(
        [FromQuery] string ProviderId
    )
    {
        List<BaseItem> items = libraryManager.GetItemList(
            new InternalItemsQuery() { HasAnyProviderId = new Dictionary<string, string> { { nameof(Imdb), ProviderId } } }
            );

        return Ok(dtoService.GetBaseItemDtos(items, new DtoOptions()));
    }
}