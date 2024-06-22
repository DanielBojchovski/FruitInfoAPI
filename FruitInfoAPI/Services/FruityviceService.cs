using FruitInfoAPI.Interfaces;
using FruitInfoAPI.Models;
using FruitInfoAPI.Requests;
using FruitInfoAPI.Responses;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace FruitInfoAPI.Services
{
    public class FruityviceService : IFruityviceService
    {
        private readonly HttpClient _httpClient;
        private static readonly Dictionary<string, string> _metadataStorage = new();
        private readonly IMemoryCache _cache;

        public FruityviceService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<Fruit?> GetFruitByName(GetFruitByNameRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return null;
                
            string fruitNameKey = request.Name.Trim().ToLower();

            if (_cache.TryGetValue(fruitNameKey, out Fruit? cachedFruit) && cachedFruit is not null)
            {
                return cachedFruit;
            }
            try
            {
                var response = await _httpClient.GetAsync($"https://www.fruityvice.com/api/fruit/{fruitNameKey}");

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error fetching fruit data: {errorContent}");
                    return null;
                }

                string json = await response.Content.ReadAsStringAsync();
                Fruit? fruit = JsonConvert.DeserializeObject<Fruit>(json);

                if (fruit == null)
                {
                    Console.WriteLine($"Error deserializing fruit data: {json}");
                    return null;
                }

                // Add metadata if available
                if (_metadataStorage.TryGetValue(fruitNameKey, out var metadata))
                {
                    fruit.Metadata = metadata;
                }

                if (fruit is not null) 
                {
                    _cache.Set(fruitNameKey, fruit, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15) });
                }            

                return fruit;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
                return null;
            }
        }

        public OperationStatusResponse AddMetadataAsync(SaveMetadataRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return new OperationStatusResponse { IsSuccessful = false, Message = "Invalid name." };

            if (string.IsNullOrWhiteSpace(request.Metadata))
                return new OperationStatusResponse { IsSuccessful = false, Message = "Invalid metadata." };

            string fruitNameKey = request.Name.Trim().ToLower();
            try
            {
                _metadataStorage.Add(fruitNameKey, request.Metadata);
                _cache.Remove(fruitNameKey);
                return new OperationStatusResponse { IsSuccessful = true, Message = "Fruit metadata successfully added." };
            }
            catch (Exception ex) 
            {
                return new OperationStatusResponse { IsSuccessful = false, Message = $"Error occurred: {ex.Message}" };
            }
        }

        public OperationStatusResponse RemoveMetadataAsync(DeleteMetadataRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return new OperationStatusResponse { IsSuccessful = false, Message = "Invalid name." };

            string fruitNameKey = request.Name.Trim().ToLower();
            try
            {
                _metadataStorage.Remove(fruitNameKey);
                _cache.Remove(fruitNameKey);
                return new OperationStatusResponse { IsSuccessful = true, Message = "Fruit metadata successfully removed." };
            }
            catch (Exception ex) 
            {
                return new OperationStatusResponse { IsSuccessful = false, Message = $"Error occurred: {ex.Message}" };
            }
        }

        public OperationStatusResponse UpdateMetadataAsync(SaveMetadataRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return new OperationStatusResponse { IsSuccessful = false, Message = "Invalid name." };

            if (string.IsNullOrWhiteSpace(request.Metadata))
                return new OperationStatusResponse { IsSuccessful = false, Message = "Invalid metadata." };

            string fruitNameKey = request.Name.Trim().ToLower();
            try
            {
                _metadataStorage[fruitNameKey] = request.Metadata;
                _cache.Remove(fruitNameKey);
                return new OperationStatusResponse { IsSuccessful = true, Message = "Fruit metadata successfully updated." };
            }
            catch (Exception ex)
            {
                return new OperationStatusResponse { IsSuccessful = false, Message = $"Error occurred: {ex.Message}" };
            }
        }
    }
}
