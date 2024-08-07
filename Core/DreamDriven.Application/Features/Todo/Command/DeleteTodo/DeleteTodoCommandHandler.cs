using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.Todo.Command.DeleteTodo
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public DeleteTodoCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(DeleteTodoCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş counter'ı al
            var todo = await unitOfWork.GetReadRepository<Domain.Entities.Todo>().GetAsync(
                 x => x.Id == request.Id && !x.IsDeleted
            );

            // Counter mevcut değilse, bir hata fırlatıyoruz
            if ( todo == null )
            {
                throw new KeyNotFoundException("No todo found with the specified ID.");
            }


            // Counter'ı silinmiş olarak işaretle
            todo.IsDeleted = true;

            // Counter'ı güncelle
            await unitOfWork.GetWriteRepository<Domain.Entities.Todo>().UpdateAsync(todo);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
