using Aggregation.Domain;

namespace Aggregation.Repository;

public class AggregateRepository : IAggregateRepository
{
    #region Constructor

    protected readonly AggregationDbContext _aggregationDbContext;

    public AggregateRepository(AggregationDbContext aggregationDbContext)
    {
        _aggregationDbContext = aggregationDbContext;
    }

    #endregion

    public void SaveData<T>(T data) where T : AggregateData
    {
        var records = _aggregationDbContext.AggregateData.Add(data);
        _aggregationDbContext.SaveChanges();
    }
}