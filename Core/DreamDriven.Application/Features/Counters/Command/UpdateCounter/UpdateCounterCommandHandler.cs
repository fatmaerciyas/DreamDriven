using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.UpdateCounter
{
    public class UpdateCounterCommandHandler : IRequestHandler<UpdateCounterCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        // Constructor: IUnitOfWork nesnesini alır ve sınıfın private alanına atar
        public UpdateCounterCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // Handle metodunu async olarak tanımlıyoruz
        public async Task<Unit> Handle(UpdateCounterCommandRequest request, CancellationToken cancellationToken)
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

            // Counter'ı güncelle
            counter.Updated_at = request.Updated_at;
            counter.Duration = request.Duration;
            counter.IsDeleted = request.IsDeleted;
            counter.Updated_at = request.Updated_at;


            await unitOfWork.GetWriteRepository<Counter>().UpdateAsync(counter);

            // Değişiklikleri veritabanına kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // İşlem tamamlandığında boş döner; MediatR kullanımı için
            return Unit.Value;
        }
    }
}
