using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.DeleteCounter
{
    // MediatR için delete counter komutunu işleyen handler sınıfı
    public class DeleteCounterCommandHandler : IRequestHandler<DeleteCounterCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public DeleteCounterCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // Handle metodunu async olarak tanımlıyoruz
        public async Task<Unit> Handle(DeleteCounterCommandRequest request, CancellationToken cancellationToken)
        {
            // Belirtilen ID'ye sahip ve silinmemiş counter'ı al
            var counter = await unitOfWork.GetReadRepository<Counter>().GetAsync(
                 x => x.Id == request.Id && !x.IsDeleted
            );

            // Counter mevcut değilse, bir hata fırlatıyoruz
            if ( counter == null )
            {
                throw new KeyNotFoundException("No counter found with the specified ID.");
            }

            // Counter'ı silinmiş olarak işaretle
            counter.IsDeleted = true;

            // Counter'ı güncelle
            await unitOfWork.GetWriteRepository<Counter>().UpdateAsync(counter);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
