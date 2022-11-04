using Aggregation.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aggregation.Repository
{
    public interface IAggregateRepository
    {
        void SaveData<T>(T data) where T : AggregateData;
    }
}