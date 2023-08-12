using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsApplication.Application.EntityCQ.Announcements.Commands;
using NewsApplication.Application.EntityCQ.Announcements.Queries;

namespace NewsApplication.MVC.Controllers;

public class AnnouncementController : Controller
{
    private readonly IMediator _mediator;

    public AnnouncementController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response  = await _mediator.Send(new GetAnnouncementQuery());

        return View(response);
    }
    
    [HttpGet("announcement/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        var response  = await _mediator.Send(new GetSingleAnnouncementQuery{Id = id});
        
        return View(response);
    }
    
    [HttpGet("announcement/post")]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(AnnouncementPostCommand command)
    {
        var response  = await _mediator.Send(command);
        
        return RedirectToAction("Index");
    }
}