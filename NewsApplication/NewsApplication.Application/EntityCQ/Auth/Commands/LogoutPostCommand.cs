using MediatR;
using Microsoft.AspNetCore.Identity;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Auth.Commands;

public class LogoutPostCommand : IRequest
{
    public class LogoutPostCommandHandler : IRequestHandler<LogoutPostCommand>
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutPostCommandHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task Handle(LogoutPostCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }
    }
}