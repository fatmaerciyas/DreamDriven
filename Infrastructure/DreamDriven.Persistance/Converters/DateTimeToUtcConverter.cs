using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DreamDriven.Persistance.Converters
{
    public class DateTimeToUtcConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeToUtcConverter()
            : base(
                v => v.ToUniversalTime(), // Dönüştürme: Local'den UTC'ye
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)) // Geri dönüştürme: UTC'den Local'e
        {
        }
    }
}
