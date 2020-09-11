using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Application.Features.Books.Queries.Details
{
    public class BookDetailsQuery : IRequest<BookDetailsOutputModel>
    {
        public int Id { get; set; }

        public class BookDetailsQueryyHandler : IRequestHandler<BookDetailsQuery, BookDetailsOutputModel>
        {
            public Task<BookDetailsOutputModel> Handle(BookDetailsQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult<BookDetailsOutputModel>(new BookDetailsOutputModel
                {
                    Id = request.Id,
                    Title = "Some Example Title"
                });
            }
        }
    }
}
