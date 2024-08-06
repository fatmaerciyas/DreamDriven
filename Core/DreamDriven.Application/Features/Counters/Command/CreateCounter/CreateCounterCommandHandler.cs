using DreamDriven.Application.Interfaces.UnitOfWorks;
using DreamDriven.Domain.Entities;
using MediatR;

namespace DreamDriven.Application.Features.Counters.Command.CreateCounter
{
    public class CreateCounterCommandHandler : IRequestHandler<CreateCounterCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateCounterCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCounterCommandRequest request, CancellationToken cancellationToken)
        {
            Guid newGuid = Guid.NewGuid();

            //Yeni counter olustur
            Counter counter = new Counter(request.Updated_at, newGuid, false); //userId daha sonra giris yapan kullanicinin Id'si olarak degisecek

            //Yeni counter'i ekle
            await unitOfWork.GetWriteRepository<Counter>().AddAsync(counter);

            // Değişiklikleri kaydet
            await unitOfWork.SaveAsync(cancellationToken);

            // Bos dönmemizi saglıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
