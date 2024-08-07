using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.Todo.Command.UpdateTodo
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public UpdateTodoCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(UpdateTodoCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş Todo'ı al
            var todo = await unitOfWork.GetReadRepository<Domain.Entities.Todo>().GetAsync(
                x => x.Id == request.Id && !x.IsDeleted
            );

            // Todo mevcut değilse, bir hata fırlatıyoruz
            if ( todo == null )
            {
                throw new KeyNotFoundException("No Todo found with the specified ID.");
            }

            // Todo'ı güncelle
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.DueDate = request.DueDate;
            todo.IsCompleted = request.IsCompleted;
            todo.UpdatedAt = request.UpdatedAt;


            await unitOfWork.GetWriteRepository<Domain.Entities.Todo>().UpdateAsync(todo);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
