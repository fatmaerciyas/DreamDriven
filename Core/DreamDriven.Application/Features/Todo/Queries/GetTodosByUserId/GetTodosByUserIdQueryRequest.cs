using MediatR;

namespace DreamDriven.Application.Features.Todo.Queries.GetTodosByUserId
{
    public class GetTodosByUserIdQueryRequest : IRequest<IList<GetTodosByUserIdQueryResponse>>
    {
        public Guid UserId { get; set; }
    }
}
