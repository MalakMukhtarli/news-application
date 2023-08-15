using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsApplication.MVC.Controllers;

public class CommentController : Controller
{
    [Authorize]
    public async Task<IActionResult> Create()
    {
        
        
        return RedirectToAction();
    }
}