using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsApplication.Application.EntityCQ.Admin.Announcements.Queries;
using NewsApplication.Application.EntityCQ.Announcements.Commands;
using NewsApplication.Application.EntityCQ.Announcements.Queries;
using NewsApplication.MVC.Contract;

namespace NewsApplication.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class AnnouncementController : Controller
{
    private readonly IMediator _mediator;

    public AnnouncementController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet(Routes.AdminAnnouncement.GetAll)]
    public async Task<IActionResult> Index()
    {
        var response  = await _mediator.Send(new GetAnnouncementForAdminQuery());

        return View(response);
    }
    
    [HttpGet(Routes.AdminAnnouncement.Get)]
    public async Task<IActionResult> Detail(int id)
    {
        var response  = await _mediator.Send(new GetSingleAnnouncementQuery{Id = id});
        
        return View(response);
    }

    [HttpGet(Routes.AdminAnnouncement.Create)]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(AnnouncementPostCommand command)
    {
        var response  = await _mediator.Send(command);
        
        return RedirectToAction("Create");
    }
}