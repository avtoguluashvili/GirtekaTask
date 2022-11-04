using System.Globalization;
using Aggregation.Domain;
using Aggregation.Dto;
using Aggregation.Interfaces;
using Aggregation.Repository;
using AutoMapper;
using CsvHelper;

namespace Aggregation.Services
{
    public class CsvData : ICsvData
    {
        #region Constructor
        protected readonly IAggregateRepository _aggregateRepository;
        protected readonly IMapper _mapper;

        public CsvData(IAggregateRepository aggregateRepository, IMapper mapper)
        {
            _aggregateRepository = aggregateRepository;
            _mapper = mapper;
        }
        #endregion

        #region CsvOperations
        public List<AggregateDataDto> GetCsvDataAsync<T>() where T : List<AggregateDataDto>
        {
            using var reader = new StreamReader(@"C:\Users\Geekster PC\Downloads\2022-05.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<AggregateClassMap>();

            var records = csv.GetRecords<AggregateData>()
                .Where(x => x.OBT == "Butas")
                .ToList();

            var result = _mapper.Map<T>(records);
            return result;
        }

        public bool SaveCsvData<T>() where T : AggregateData
        {
            var result = true;
            try
            {
                var recordsDto = GetCsvDataAsync<List<AggregateDataDto>>();

                result = true;

                var records = new List<AggregateData>();

                foreach (var record in recordsDto.Select(item => new AggregateData
                {
                    Name = item.Name,
                    Type = item.Type,
                    OBT = item.OBT,
                    PLTime = item.PLTime,
                    ObjectNumber = item.ObjectNumber,
                    PMinus = item.PMinus,
                    PPlus = item.PPlus
                }))
                {
                    records.Add(record);
                    _aggregateRepository.SaveData(record);
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    } 
    #endregion
}
