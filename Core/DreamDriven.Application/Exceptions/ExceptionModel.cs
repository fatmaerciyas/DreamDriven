using Newtonsoft.Json;

namespace DreamDriven.Application.Exceptions
{
    // Hata mesajlarim hp bu modelde donecekler
    public class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(Errors); // (this) = (Errors)
        }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
