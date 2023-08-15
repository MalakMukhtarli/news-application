using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsApplication.Application.EntityCQ.Auth.Commands;
using NewsApplication.MVC.Contract;

namespace NewsApplication.MVC.Controllers;

public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Routes.Auth.Register)]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost(Routes.Auth.Register)]
    public async Task<IActionResult> Register(RegisterPostCommand registerPostCommand)
    {
        await _mediator.Send(registerPostCommand);
        return RedirectToAction("Index","Announcement");
    }

    [HttpGet(Routes.Auth.Login)]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost(Routes.Auth.Login)]
    public async Task<IActionResult> Login(LoginPostCommand loginPostCommand)
    {
        await _mediator.Send(loginPostCommand);
        return RedirectToAction("Index","Announcement");
    }

    [HttpGet(Routes.Auth.Logout)]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutPostCommand());
        return RedirectToAction("Index","Announcement");
    }
}