using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NewsApplication.Application.Exceptions;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Auth.Commands;

public class LoginPostCommand : IRequest<int>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginPostCommandHandler : IRequestHandler<LoginPostCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;

        public LoginPostCommandHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        public async Task<int> Handle(LoginPostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                throw new NotFoundException("İstifadəçi tapılmadı.");

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!userHasValidPassword)
                throw new BadRequestException("Istifadəçi adı və yaxud şifrə doğru deyil.");
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("UserName", user.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2),
            };
            //
            // await _httpContextAccessor?.HttpContext?.SignInAsync(
            //     CookieAuthenticationDefaults.AuthenticationScheme,
            //     new ClaimsPrincipal(claimsIdentity),
            //     authProperties)!;
            
            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);
            
            if (signInResult.IsLockedOut)
                throw new BadRequestException("Zəhmət olmasa bir az sonra yenidən yoxlayın.");
            
            if (!signInResult.Succeeded)
                throw new BadRequestException("Istifadəçi adı və yaxud şifrə doğru deyil..");


            return user.Id;
        }
    }
}