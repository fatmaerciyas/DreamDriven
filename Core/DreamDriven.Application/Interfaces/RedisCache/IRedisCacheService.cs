namespace DreamDriven.Application.Interfaces.RedisCache
{

    // Her zaman db'ye uğramak yerine cache ile hızlı bir erisim gerceklestirecektir
    public interface IRedisCacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, DateTime? expirationTime = null);
    }
}
