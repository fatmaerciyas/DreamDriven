using DreamDriven.Application.Bases;
using DreamDriven.Application.Interfaces.AutoMapper;
using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DreamDriven.Application.Features.Todo.Command.DeleteTodo
{
    public class DeleteTodoCommandHandler : BaseHandler, IRequestHandler<DeleteTodoCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public DeleteTodoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
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
