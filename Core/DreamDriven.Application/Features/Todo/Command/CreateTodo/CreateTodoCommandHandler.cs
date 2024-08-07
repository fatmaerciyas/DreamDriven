using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.Todo.Command.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateTodoCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateTodoCommandRequest request, CancellationToken cancellationToken)
        {
            // Yeni Todo nesnesi oluşturma
            var todo = new Domain.Entities.Todo(
                title: request.Title,
                description: request.Description,
                dueDate: request.DueDate,
                isCompleted: request.IsCompleted,
                updatedAt: DateTime.Now, // Güncel tarih
                userId: request.UserId, // Kullanıcının ID'si
                isDeleted: false // Varsayılan olarak false
            );

            // Todo nesnesini ekleme
            await unitOfWork.GetWriteRepository<Domain.Entities.Todo>().AddAsync(todo);

            // Değişiklikleri kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // Boş dönmemizi sağlıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
