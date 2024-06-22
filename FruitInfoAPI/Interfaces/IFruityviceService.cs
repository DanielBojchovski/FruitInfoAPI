using FruitInfoAPI.Models;
using FruitInfoAPI.Requests;
using FruitInfoAPI.Responses;

namespace FruitInfoAPI.Interfaces
{
    public interface IFruityviceService
    {
        Task<Fruit?> GetFruitByName(GetFruitByNameRequest request);
        OperationStatusResponse AddMetadataAsync(SaveMetadataRequest request);
        OperationStatusResponse RemoveMetadataAsync(DeleteMetadataRequest request);
        OperationStatusResponse UpdateMetadataAsync(SaveMetadataRequest request);
    }
}
