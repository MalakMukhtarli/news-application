using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewsApplication.Core.Repositories.Special;
using NewsApplication.Models.Entities;

namespace NewsApplication.Application.EntityCQ.Likes.Commands;

public class LikePostCommand : IRequest<int>
{
    public bool Like { get; set; }
    public bool Dislike { get; set; }

    public class LikePostCommandHandler : IRequestHandler<LikePostCommand, int>
    {
        protected readonly ILikeRepository _likeRepository;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly string? _clientIp;
        
        public LikePostCommandHandler(ILikeRepository likeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _likeRepository = likeRepository;
            _httpContextAccessor = httpContextAccessor;
            _clientIp = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();

        }

        public async Task<int> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            if (request.Like == request.Dislike)
                return 0;
            
            var isExistIp = await _likeRepository.GetQueryNoTracking().FirstOrDefaultAsync(x => x.CreatedIp == _clientIp, cancellationToken: cancellationToken);

            var entity = new Like();
            if (isExistIp is not null)
            {
                if (isExistIp.IsLike != request.Like)
                    isExistIp.IsLike = false;
                await _likeRepository.UpdateAsync(isExistIp, cancellationToken);
            }
            else
            {
                var like = new Like
                {
                    IsLike = request.Like,
                    CreatedIp = _clientIp
                };

                entity = await _likeRepository.AddAsync(like, cancellationToken);
            }
            
            return isExistIp?.Id??entity.Id;
        }
    }
}