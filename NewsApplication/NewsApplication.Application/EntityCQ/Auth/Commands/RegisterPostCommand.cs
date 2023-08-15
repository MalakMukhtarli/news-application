using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using NewsApplication.Application.Exceptions;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Auth.Commands;

public class RegisterPostCommand : IRequest<int>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class RegisterPostCommandHandler : IRequestHandler<RegisterPostCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<User> _signInManager;

        public RegisterPostCommandHandler(UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
        }

        public async Task<int> Handle(RegisterPostCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new BadRequestException("İstifadəçi artıq mövcuddur.");

            var newUser = new User
            {
                Name = request.Email,
                Surname = request.Email,
                Email = request.Email,
                UserName = request.Email
            };

            var createdUser = await _userManager.CreateAsync(newUser, request.Password);
            if (!createdUser.Succeeded)
                throw new BadRequestException("Istifadəçi yaradılmada xəta baş verdi.");

            await _signInManager.SignInAsync(newUser, true);

            return newUser.Id;
        }
    }
}