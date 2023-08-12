using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsApplication.Application.EntityCQ.Announcements.Queries;

namespace NewsApplication.MVC.Controllers;

public class AnnouncementController : Controller
{
    private readonly IMediator _mediator;

    public AnnouncementController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Index()
    {
        var response  = await _mediator.Send(new GetAnnouncementQuery());

        return View(response);
    }
    
    public async Task<IActionResult> Detail(int id)
    {
        var response  = await _mediator.Send(new GetSingleAnnouncementQuery{Id = id});
        
        return View(response);
    }
}