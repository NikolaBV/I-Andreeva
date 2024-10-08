using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public class Details
    {
        public class Query : IRequest<Result<Post>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Post>> //First parameter is the query and second what we are returning
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<Post>> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Id);
                return Result<Post>.Success(post);
            }
        }
    }
}