using Aggregation.Domain;
using Aggregation.Dto;
using AutoMapper;

namespace Aggregation.Mappings
{
    public class AggregateMappings : Profile
    {

        public AggregateMappings()
        {
            CreateMap<AggregateData, AggregateDataDto>()
                .ReverseMap();
        }
    }
}