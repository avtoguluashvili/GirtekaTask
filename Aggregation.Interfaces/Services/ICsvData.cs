using Aggregation.Domain;
using Aggregation.Dto;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aggregation.Interfaces
{
    public interface ICsvData
    {
        bool SaveCsvData<T>() where T : AggregateData;
        List<AggregateDataDto> GetCsvDataAsync<T>() where T : List<AggregateDataDto>;
    }
}