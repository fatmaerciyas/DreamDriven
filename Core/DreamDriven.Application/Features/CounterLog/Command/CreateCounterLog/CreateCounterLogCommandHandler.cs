using DreamDriven.Application.Interfaces.UnitOfWorks;
using MediatR;

namespace DreamDriven.Application.Features.CounterLog.Command.CreateCounterLog
{
    public class CreateCounterLogCommandHandler : IRequestHandler<CreateCounterLogCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCounterLogCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCounterLogCommandRequest request, CancellationToken cancellationToken)
        {
            // Yeni CounterLog oluştur
            CounterLog CounterLog = new CounterLog(request.StartTime, request.EndTime, request.Duration, request.CounterId);

            // Yeni CounterLog'u ekle
            await _unitOfWork.GetWriteRepository<CounterLog>().AddAsync(CounterLog, cancellationToken);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync(cancellationToken);

            // Boş dönmemizi sağlıyoruz; pipeline'ın doğru çalışması için
            return Unit.Value;
        }
    }
}
